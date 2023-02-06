using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;


public partial class Facility_HallBookingApp : System.Web.UI.Page
{
    FillFunctions FillFunction;
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DatabaseFunctions DataBaseFunction;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            Pushdata();
            ViewState["ID"] = "";
            ViewState["ROOM_ID"] = "";
            ddlSts.SelectedValue = "-2";
            FillGrid();
            tblApprove.Visible = false;
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void Pushdata()
    {
        FillFunction.Fill(ddlComlx, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HallCmplx), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlEvt, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Evnt), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSts, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.VehStatus), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlemp, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpByDept, Session["DeptID"].ToString()), true, FillFunctions.FirstItem.All);
    }
    private void FillGrid()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.Status = ddlSts.SelectedValue;
        gvAppliedHall.DataSource = ObjFacBll.HallReqApproval(ObjFacBal).Tables[0];
        gvAppliedHall.DataBind();

    }
    protected void gvAppliedHall_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvAppliedHall.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString();
            ViewState["ROOM_ID"] = gvAppliedHall.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1].ToString();
            ifrmDetail.Attributes["src"] = "rptHallBooking.aspx?=" + ViewState["ID"].ToString();
            ifrmDetail.Visible = tblApprove.Visible = true;
            btnCancel.Visible = true;
            if (Session["UserId"].ToString() == gvAppliedHall.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[2].ToString())
                btnApprove.Visible = true;
            else
                btnRecommend.Visible = true;

        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlDate":
                if (ddlDate.SelectedValue == "3")
                {
                    txtFrmDt.Visible = true;
                    txtToDt.Visible = true;
                }
                else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
                {
                    txtFrmDt.Visible = true;
                    txtToDt.Visible = false;
                }
                else
                {
                    txtFrmDt.Visible = false;
                    txtToDt.Visible = false;
                }
                txtFrmDt.Text = txtToDt.Text = "";
                break;
            default:
                break;
        }
    }

    protected void btnRecommend_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtReamrk.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.TypeId = "12";
        ObjFacBal.Forward_To = (ViewState["ROOM_ID"].ToString() == "29") ? "3" : "5";
        ObjFacBll.HallReqRecommend(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Recommended for further approval')", true);
        ifrmDetail.Visible = tblApprove.Visible = false;
        FillGrid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtReamrk.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.TypeId = "12";
        ObjFacBal.Status = "4";
        ObjFacBll.HallReqCancel(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Hall Request Canceled.')", true);
        ifrmDetail.Visible = tblApprove.Visible = false;
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtReamrk.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.TypeId = "12";
        ObjFacBll.HallReqApprove(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Approved Sucessfully')", true);
        ifrmDetail.Visible = tblApprove.Visible = false;
    }
    private void PrepareQuery()
    {
        StringBuilder Query = new StringBuilder("SELECT *, (CONVERT(VARCHAR,FAC_HALL_BOOKING_MASTER.HALL_FROM_DT,103) + '-' + CONVERT(VARCHAR,FAC_HALL_BOOKING_MASTER.HALL_TO_DT,103)) AS BOOKING_ON");
        Query.Append(" FROM FAC_HALL_BOOKING_MASTER INNER JOIN"
                          + "  EVENT_INF ON FAC_HALL_BOOKING_MASTER.HALL_BOOK_FOR = EVENT_INF.EVENT_ID INNER JOIN "
                         + " PROC_STS_TYPE_INF ON FAC_HALL_BOOKING_MASTER.HALL_BOOK_STATUS = PROC_STS_TYPE_INF.STS_ID INNER JOIN "
                         + " FAC_COMPLEX_INF ON FAC_HALL_BOOKING_MASTER.HALL_ID = FAC_COMPLEX_INF.FAC_CMPLX_ID INNER JOIN "
                         + " EMP_VIEW ON FAC_HALL_BOOKING_MASTER.HALL_BOOK_BY = EMP_VIEW.USR_ID INNER JOIN "
                         + " FAC_HALL_BOOKING_TRAN ON FAC_HALL_BOOKING_MASTER.HALL_REQ_ID = FAC_HALL_BOOKING_TRAN.HALL_REQ_ID");
        if (ddlComlx.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_ID= '" + ddlComlx.SelectedValue + "'");
        if (ddlEvt.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_BOOK_FOR= '" + ddlEvt.SelectedValue + "'");
        if (ddlSts.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_BOOK_STATUS= '" + ddlSts.SelectedValue + "'");
        if (ddlemp.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_BOOKING_BY= '" + ddlemp.SelectedValue + "'");
        if (ddlDate.SelectedIndex > 0)
        {
            switch (ddlDate.SelectedValue)
            {
                case "1":
                    Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_FROM_DT < '" + CommonFunction.GetDateTime(txtFrmDt.Text) + "'");
                    break;
                case "2":
                    Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_FROM_DT < '" + CommonFunction.GetDateTime(txtFrmDt.Text) + "'");
                    break;
                case "3":
                    Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_FROM_DT '" + CommonFunction.GetDateTime(txtFrmDt.Text) + "' and " + CommonFunction.GetDateTime(txtToDt.Text) + "'");
                    break;
            }
        }
        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(Query.ToString());
        command.CommandType = CommandType.Text;
        ds = DataBaseFunction.GetDataSet(command);
        gvAppliedHall.DataSource = ds;
        gvAppliedHall.DataBind();
        Clear();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        PrepareQuery();
        ifrmDetail.Visible = tblApprove.Visible = false;
    }
    void Clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlComlx);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlDate);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEvt);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlSts);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEvt);
        gvAppliedHall.DataSource = "";
        gvAppliedHall.DataBind();
        txtFrmDt.Text = "";
        txtReamrk.Text = "";
        txtToDt.Text = "";
    }
}
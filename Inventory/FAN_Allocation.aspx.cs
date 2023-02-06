using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Inventory_FAN_Allocation : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;
    double total;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ViewState["data"] = "";
            ViewState["req_id"] = "";
            ViewState["amount"] = "";
            ViewState["fan_amt"] = "";
            pushData();
            step1.ActiveTabIndex = 1;
        }
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    public void pushData()
    {
        Bindgv_requisition();
        fillFunctions.Fill(ddl_FanId, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANId), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddl_Dept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddl_PurReqId, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurId), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddl_Assign, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AssignBy), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddl_Status, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANStatus), true, FillFunctions.FirstItem.All);
    }
    public void Bindgv_requisition()
    {
        objBal.SessionUserId = Session["UserId"].ToString();
        gv_requisition.DataSource = ViewState["data"] = databaseFunctions.GetDataSet(objBll.getFanPurReq(objBal));
        gv_requisition.DataBind();

    }
    public void Bindgv_ItemDetails()
    {
        objBal.ID = ViewState["req_id"].ToString();
        objBal.SessionUserId = Session["UserId"].ToString();
        DataSet ds;
        gv_ItemDetails.DataSource = ds = databaseFunctions.GetDataSet(objBll.getFanPurReqItem(objBal));
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("PUR_REQ_ID=" + ViewState["req_id"].ToString() + "");
        if (dt.Rows.Count > 0)
        {
            string pur_id = dr[0]["PUR_REQ_ID"].ToString();
            ViewState["fan_amt"] = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FanAmount, pur_id)).ToString();
        }
        gv_ItemDetails.DataBind();
        Bindgv_requisition();
    }
    protected void gv_requisition_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Print")
        {
        }
        else
        {
            txtFAN_Amt.Text = txtFAN_No.Text = txtFAN_Rmrk.Text = "";
            trItemDetails.Visible = true;
            ViewState["req_id"] = gv_requisition.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            DataSet ds = (DataSet)ViewState["data"];
            dt = ds.Tables[0];
            DataRow[] dr = dt.Select("PUR_REQ_ID=" + ViewState["req_id"].ToString() + "");
            ViewState["amount"] = dr[0]["AMOUNT"].ToString();
            Bindgv_ItemDetails();
            objBal.ID = ViewState["req_id"].ToString();
            fillFunctions.Fill(gv_FanDetails, objBll.getFanDetail(objBal));
            btnAllot.Visible = btnCancel.Visible = btnReject.Visible = trFAN_Details.Visible = trtext.Visible = true;
        }
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            Bindgv_requisition();
        }
        if (step1.ActiveTabIndex == 1)
        {

            fillFunctions.Fill(ddl_FanId, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANId), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddl_Dept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddl_PurReqId, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurId), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddl_Assign, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AssignBy), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddl_Status, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANStatus), true, FillFunctions.FirstItem.All);
        }
    }


    protected void gv_ItemDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_ItemDetails.EditIndex = e.NewEditIndex;
        Bindgv_ItemDetails();
    }
    protected void gv_ItemDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_ItemDetails.EditIndex = -1;
        Bindgv_ItemDetails();
    }
    protected void gv_ItemDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox qty = (TextBox)gv_ItemDetails.Rows[e.RowIndex].Cells[2].Controls[0];
        TextBox rate = (TextBox)gv_ItemDetails.Rows[e.RowIndex].Cells[4].Controls[0];
        ViewState["req_id"] = gv_ItemDetails.DataKeys[e.RowIndex].Value;
        objBal.ID = ViewState["req_id"].ToString();
        objBal.Quantity = qty.Text;
        objBal.Rate = rate.Text;
        msg = objBll.UpdateFanQtyRate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        gv_ItemDetails.EditIndex = -1;
        Bindgv_ItemDetails();
    }
    protected void btnAllot_Click(object sender, EventArgs e)
    {
        total = Convert.ToDouble(ViewState["fan_amt"]) + Convert.ToDouble(txtFAN_Amt.Text);
        if (Convert.ToDouble(ViewState["amount"]) < total)
        {

            msg = "FAN amount can not be greater then Purchase Requisition total Amount.!!";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
            txtFAN_Amt.Text = "";
            txtFAN_Amt.Focus();
            return;
        }
        if (Convert.ToDouble(ViewState["amount"]) == total)
        {
            objBal.Status = "0";
        }
        else
        {
            objBal.Status = "1";
        }
        objBal.ReqNo = txtFAN_No.Text;
        objBal.Rate = txtFAN_Amt.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.ID = ViewState["req_id"].ToString();
        objBal.Remark = txtFAN_Rmrk.Text;
        objBll.FAN_Allocation(objBal);
        msg = "FAN Allocation Completed Successfully.!!";
        trItemDetails.Visible = false;
        txtFAN_No.Text = txtFAN_Rmrk.Text = "";
        Bindgv_requisition();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }

    protected void gv_ItemDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        
        objBal.ID = ddl_FanId.SelectedValue;
        objBal.Dept = ddl_Dept.SelectedValue;
        objBal.ReqNo = ddl_PurReqId.SelectedValue;
        objBal.ActionBy = ddl_Assign.SelectedValue;
        objBal.Date = txtDate.Text;
        objBal.Status = ddl_Status.SelectedValue;
        fillFunctions.Fill(gvFanReport, objBll.FANAllotedReport(objBal));

    }

    protected void ddl_FanId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Assign.SelectedIndex = ddl_Dept.SelectedIndex = ddl_PurReqId.SelectedIndex = ddl_Sort.SelectedIndex = ddl_Status.SelectedIndex = 0;
    }
    protected void ddl_Dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Assign.SelectedIndex = ddl_FanId.SelectedIndex = ddl_PurReqId.SelectedIndex = ddl_Sort.SelectedIndex = ddl_Status.SelectedIndex = 0;
    }
    protected void ddl_PurReqId_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Assign.SelectedIndex = ddl_Dept.SelectedIndex = ddl_FanId.SelectedIndex = ddl_Sort.SelectedIndex = ddl_Status.SelectedIndex = 0;
    }

    protected void ddl_Assign_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_FanId.SelectedIndex = ddl_Dept.SelectedIndex = ddl_PurReqId.SelectedIndex = ddl_Sort.SelectedIndex = ddl_Status.SelectedIndex = 0;
    }
    protected void ddl_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_Assign.SelectedIndex = ddl_Dept.SelectedIndex = ddl_PurReqId.SelectedIndex = ddl_Sort.SelectedIndex = ddl_FanId.SelectedIndex = 0;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtFAN_Amt.Text = txtFAN_No.Text = txtFAN_Rmrk.Text = "";
    }
    protected void btnReject_Click(object sender, EventArgs e)
    {
        GetData();
        objBll.PurFanCanceled(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Reject successfully.')", true);
        Bindgv_requisition();
        trItemDetails.Visible = trFAN_Details.Visible = false;

    }
    protected void gv_requisition_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    public void GetData()
    {
        DataSet ds = (DataSet)ViewState["data"];
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("REQ_SUB_ID=" + ViewState["req_id"].ToString() + "");
        //objBal.ID = ViewState["req_id"].ToString();
        objBal.Identification = dr[0]["PUR_REQ_ID"].ToString();
        objBal.Remark = txtFAN_Rmrk.Text;
        objBal.Typ = "8";
        objBal.SessionUserId = Session["UserId"].ToString();
    }
}
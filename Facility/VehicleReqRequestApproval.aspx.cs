using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Facility_VehicleRequestApproval : System.Web.UI.Page
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
            ViewState["ID"] = "";
            ViewState["dt"] = "";
            ViewState["Action_By"] = "";
            Bind_GvVehReq();
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
    void Bind_GvVehReq()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjFacBll.VehReqApproval(ObjFacBal).Tables[0];
        ViewState["dt"] = dt;
        gvAppVehReq.DataSource = dt;
        gvAppVehReq.DataBind();
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    ViewState["Action_By"] = ds.Tables[0].Rows[0]["ACTION"].ToString();
        //    btnCancel.Visible = true;
        //    if (ViewState["Action_By"].ToString() == "1")
        //    {
        //        btnRecommend.Visible = true;
        //    }
        //    if (ViewState["Action_By"].ToString() == "2")
        //    {
        //        btnApprove.Visible = true;
        //    }
        //}
    }
    void Bind_GvVehRetReq()
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        gvRetJou.DataSource = ObjFacBll.VehRetDetail(ObjFacBal).Tables[0];
        gvRetJou.DataBind();
    }
    protected void btnRecommend_Click(object sender, EventArgs e)
    {
        ObjFacBal.Forward_To = "5";
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.TypeId = "9";
        ObjFacBll.FacVehReqReccomend(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request forwarded successfully.')", true);
        Bind_GvVehReq();
        Bind_GvVehRetReq();
        txtRemark.Text = "";
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.TypeId = "16";
        ObjFacBal.Forward_To = "9";
        ObjFacBll.FacVehReqApprove(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request forwarded successfully.')", true);
        Bind_GvVehReq();
        Bind_GvVehRetReq();
        txtRemark.Text = "";
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.TypeId = "9";
        if (ViewState["Action_By"].ToString() == "1")
        {
            ObjFacBal.Status = "3";
        }
        else if (ViewState["Action_By"].ToString() == "2")
        {
            ObjFacBal.Status = "4";
        }

        ObjFacBll.FacVehReqCancel(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Canceled successfully.')", true);
    }
    protected void gvAppVehReq_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvAppVehReq.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        dt = (DataTable)ViewState["dt"];       
        DataRow[] dr = dt.Select("VR_REQ_ID=" + ViewState["ID"].ToString() + "");
        ViewState["Action_By"] = dr[0]["ACTION"].ToString();
        Bind_GvVehRetReq();
        btnCancel.Visible = true;
        btnRecommend.Visible =(ViewState["Action_By"].ToString() == "1");
        btnApprove.Visible = (ViewState["Action_By"].ToString() == "2");       
    }
}
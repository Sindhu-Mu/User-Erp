using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class IssueTracking_IssueSolution : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DatabaseFunction;
    DataTable dt;
    string Msg;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ViewState["dt"] = "";
            ViewState["ID"] = "";
            FillgvPending();
            FillGvDetail();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void FillgvPending()
    {
        dt = ObjFacBll.IssuePendingRequest().Tables[0];
        ViewState["dt"] = dt;
        gvPending.DataSource = dt;
        gvPending.DataBind();
    }
    void FillGvDetail()
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.SessionUserID =Session["UserId"].ToString();
        ObjFacBal.Description = txtRemark.Text;
        dt = ObjFacBll.IssueDetail(ObjFacBal).Tables[0];
        ViewState["dt"] = dt;
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
    }
    protected void gvPending_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvPending.DataKeys[0].Value;
       // DataSet ds = (DataSet)ViewState["dt"];
        dt = (DataTable)ViewState["dt"];// ds.Tables[0];

        DataRow[] dr = dt.Select("ISSUE_ID=" + ViewState["ID"].ToString() + "");
        FillGvDetail();
    }
    protected void btnSolved_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Description = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjFacBll.IssueSolution(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
    }
    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Description = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjFacBll.IssueTransfer(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
    }
    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvDetail.DataKeys[0].Value;
        // DataSet ds = (DataSet)ViewState["dt"];
        dt = (DataTable)ViewState["dt"];// ds.Tables[0];

        DataRow[] dr = dt.Select("ISSUE_ID=" + ViewState["ID"].ToString() + "");
        btnSolved.Visible = true;
        btnTransfer.Visible = true;
        txtRemark.Visible = true;
    }
}
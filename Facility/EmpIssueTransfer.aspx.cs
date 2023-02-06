using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
using System.Data;

public partial class Facility_EmpIssueTransfer : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    FacBAL ObjfacBal;
    FacBLL ObjfacBll;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
        ObjfacBal = new FacBAL();
        ObjfacBll = new FacBLL();
    }
    void FillGrid()
    {
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
       dt =  ObjfacBll.EmpIssueTransferTo(ObjfacBal).Tables[0];
       gvIssues.DataSource = dt;
       gvIssues.DataBind();
    }
    protected void gvIssues_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjfacBal.KeyID = e.CommandArgument.ToString();
        ViewState["Id"] = ObjfacBal.KeyID;
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = ObjfacBll.EmpissuedetailSelect(ObjfacBal);
        lblComplx.Text = ds.Tables[0].Rows[0]["FAC_CMPLX_NAME"].ToString();
        lblTokenName.Text = ds.Tables[0].Rows[0]["ISSUE_TOKEN_NO"].ToString();
        lblContactNo.Text = ds.Tables[0].Rows[0]["Mobile_Off"].ToString();
        lblDetail.Text = ds.Tables[0].Rows[0]["ISSUE_DETAIL"].ToString();
        lblIssueAbt.Text = ds.Tables[0].Rows[0]["SUB_HEAD_VALUE"].ToString();
        lblIssueBY.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
        lblIssueOn.Text = ds.Tables[0].Rows[0]["ISSUE_DT"].ToString();
        lblLoc.Text = ds.Tables[0].Rows[0]["ISSUE_LOCATION"].ToString();
        ModalPopupExtender1.Show();
    }
    protected void btnFinish_Click(object sender, EventArgs e)
    {
        ObjfacBal.KeyID = ViewState["Id"].ToString();
        ObjfacBal.Description = txtWork.Text;
        ObjfacBal.Value = txtMaterial.Text;
        ObjfacBal.SrtDate = commonFunctions.GetDateTime(txtDt.Text);
        ObjfacBal.EmpId = commonFunctions.GetKeyID(txtActionby);
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        ObjfacBll.EmpIssueFinish(ObjfacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Issue is Solved Sucessfully ')", true);
        FillgvWorkDes();
        txtWork.Text = "";
        txtMaterial.Text = "";
        txtDt.Text = "";
        txtActionby.Text = "";
        FillGrid();
    }
    void FillgvWorkDes()
    {
        ObjfacBal.KeyID = ViewState["Id"].ToString();
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        gvWorkDes.DataSource = ObjfacBll.EmpissuedetailSelect(ObjfacBal).Tables[2];
        gvWorkDes.DataBind();
    }
    protected void gvWorkDes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjfacBal.Id = gvWorkDes.DataKeys[0].Value.ToString();
        Msg = ObjfacBll.EmpMaterialDelete(ObjfacBal);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillgvWorkDes();
    }
}
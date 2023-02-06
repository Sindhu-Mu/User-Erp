using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facility_popIssue : System.Web.UI.Page
{

    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    FacBAL ObjfacBal;
    FacBLL ObjfacBll;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.Count > 0)
        {
            commonFunctions = new CommonFunctions();
            databaseFunctions = new DatabaseFunctions();
            dt = new DataTable();
            ObjfacBal = new FacBAL();
            ObjfacBll = new FacBLL();
            ObjfacBal.KeyID = Request.QueryString[0].ToString();
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
            AssignDeatiil();
            FillgvWorkDes();
        }
    }
    void AssignDeatiil()
    {
        ObjfacBal.KeyID = ViewState["Id"].ToString();
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        gvAssign.DataSource = ObjfacBll.EmpissuedetailSelect(ObjfacBal).Tables[1];
        gvAssign.DataBind();
    }
    protected void btnAsign_Click(object sender, EventArgs e)
    {
        ObjfacBal.KeyID = ViewState["Id"].ToString();
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        ObjfacBal.Id = commonFunctions.GetKeyID(txtassign);
        ObjfacBal.Remark = txtRemark.Text;
        ObjfacBll.EmpAssignDeatil(ObjfacBal);        
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptIssueDetail.aspx?=" + ViewState["Id"].ToString() + "','_blank','alwaysRaised')", true);
        AssignDeatiil();
        txtassign.Text = "";
        txtRemark.Text = "";
       
    }
    protected void btnInProces_Click(object sender, EventArgs e)
    {
        ObjfacBal.KeyID = ViewState["Id"].ToString();
        ObjfacBal.Description = txtWork.Text;
        ObjfacBal.Value = txtMaterial.Text;
        ObjfacBal.SrtDate = commonFunctions.GetDateTime(txtDt.Text);
        ObjfacBal.EmpId = commonFunctions.GetKeyID(txtActionby);
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        ObjfacBll.EmpIssueInprocess(ObjfacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Issue is in Process Now ')", true);
        FillgvWorkDes();
        txtWork.Text = "";
        txtMaterial.Text = "";
        txtDt.Text = "";
        txtActionby.Text = "";
      
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
       
    }
    void FillgvWorkDes()
    {
        ObjfacBal.KeyID = ViewState["Id"].ToString();
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        gvWorkDes.DataSource = ObjfacBll.EmpissuedetailSelect(ObjfacBal).Tables[2];
        gvWorkDes.DataBind();
    }
    protected void gvAssign_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjfacBal.Id = gvAssign.DataKeys[0].Value.ToString();
        Msg = ObjfacBll.EmpTransferDelete(ObjfacBal);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
    protected void gvWorkDes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjfacBal.Id = gvWorkDes.DataKeys[0].Value.ToString();
        Msg = ObjfacBll.EmpMaterialDelete(ObjfacBal);
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillgvWorkDes();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptIssueDetail.aspx?=" + ViewState["Id"].ToString() + "','_blank','alwaysRaised')", true);
    }
}
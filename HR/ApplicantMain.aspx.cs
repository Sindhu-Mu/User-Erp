using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_InterviewCandidateMain : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();

        if (!IsPostBack)
        {
            FillFunction.Fill(ddlMailDomain, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlJob, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
        }
    }


    void clear()
    {
         txtConNo.Text = txtCrntCTC.Text = txtDays.Text = txtExpctCTC.Text = txtLocation.Text = txtRemark.Text =txtFirstName.Text=txtMiddleName.Text=txtLastName.Text= "";
         ddlAdmin.SelectedIndex = 0;
    }
    protected void newCanWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        ObjHrBAL.FName = txtFirstName.Text;
        ObjHrBAL.MName = txtMiddleName.Text;
        ObjHrBAL.LName = txtLastName.Text;
        ObjHrBAL.PhnNo = txtConNo.Text;
        ObjHrBAL.MailId = txtMail.Text;
        ObjHrBAL.MailDomain = ddlMailDomain.SelectedValue;
        ObjHrBAL.Location = txtLocation.Text;
        ObjHrBAL.Admin = ddlAdmin.SelectedValue;
        ObjHrBAL.CurCTC = txtCrntCTC.Text;
        ObjHrBAL.ExpCTC = txtExpctCTC.Text;
        ObjHrBAL.Total = txtDays.Text;
        ObjHrBAL.RemValue = txtRemark.Text;
        ObjHrBAL.KeyID = ddlJob.SelectedValue;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        string Msg = ObjHrBll.InterviewCandidateInsert(ObjHrBAL, ctrlAcademic.GetXML, ctrlExperience.GetXML);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        txtConNo.Text = txtCrntCTC.Text = txtDays.Text = txtExpctCTC.Text = txtFirstName.Text = txtLastName.Text = txtLocation.Text = txtMail.Text = txtMiddleName.Text = txtRemark.Text = "";
        ddlAdmin.SelectedIndex = ddlJob.SelectedIndex = ddlMailDomain.SelectedIndex = 0;


    }
}
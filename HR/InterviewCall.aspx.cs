using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_InterviewCall : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();

        if (!IsPostBack)
        {
            fillJobGrid();
        }
    }
    void fillJobGrid()
    {
        gvJob.DataSource = ObjHrBll.ApplicantForIntCall(ObjHrBAL).Tables[0];
        gvJob.DataBind();
    }
    void fillApplicantGrid()
    {
        ObjHrBAL.JobId = ViewState["Job_Id"].ToString();
        gvApplicant.DataSource = ObjHrBll.ApplicantForIntCall(ObjHrBAL).Tables[1];
        gvApplicant.DataBind();
        trApplicant.Visible = true;
    }
    protected void gvJob_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["Job_Id"] = gvJob.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        fillApplicantGrid();

    }
    protected void gvApplicant_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBAL.HeadID = gvApplicant.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('ShortlistedAppDetail.aspx?a=" + ObjHrBAL.HeadID + "&b=" + ViewState["Job_Id"].ToString() + "','_blank','resizable=1,width=1000,height=1000')", true);
        
    }
}
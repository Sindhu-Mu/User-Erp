using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_MajorMarksReprint : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    QueryFunctions queryFunctions;
    ExamFunctions.QueryFunctions query;
    ExamFunctions.FillFunctions fill;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        query = new ExamFunctions.QueryFunctions();
        fill = new ExamFunctions.FillFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlExam, query.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Examination), true, ExamFunctions.FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPrgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPrgm.Focus();
        }
        else
        {
            ddlPrgm.Items.Clear();
        }
    }
    protected void ddlPrgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPrgm.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlBranch.Focus();
        }
        else
        {
            ddlBranch.Items.Clear();
        }
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBranch.SelectedIndex > 0) && (ddlSem.SelectedIndex > 0))
        {
            fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseByBrnchSem, ddlBranch.SelectedValue, ddlSem.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPaper.Focus();
        }
        else
        {
            ddlPaper.Items.Clear();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjBal.Pap_Code = ddlPaper.SelectedValue;
        ObjBal.KeyValue = txtDate.Text;
        gvDetail.DataSource = ObjBll.GetMajorRePrint(ObjBal).Tables[0];
        gvDetail.DataBind();
    }
    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            string ss = gvDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString() ;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMajorMarks.aspx?" + ss + "','_blank','alwaysRaised')", true);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_ResultSummary : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    Messages Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        Msg = new Messages();
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
       
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }

    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlSemester, ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseFilePaper, ddlBranch.SelectedValue, ddlSemester.SelectedValue, ddlBatch.SelectedValue), true, FillFunctions.FirstItem.All);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            objBal.Brn_Id = ddlBranch.SelectedValue;
            objBal.Value = ddlBatch.SelectedValue;
            objBal.Semid = ddlSemester.SelectedValue;
            objBal.KeyValue = ddlPaper.SelectedValue;
            DataTable dt = objBll.GetResultSummaryForCourseFile(objBal);
            fillFunctions.Fill(gridSummary, dt);
            DivExport.Visible = (gridSummary.Rows.Count > 0);
        }
        catch
        {
            Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("CourseResultSummary.xls", gridSummary);
    }

}
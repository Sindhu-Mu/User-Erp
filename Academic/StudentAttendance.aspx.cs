using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_StudentAttendance : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            timeTableWizard.ActiveStepIndex = 0;
            FillData();
            ViewState["EVA_SCH_ID"] = "";       //with batch & branch, find EVA_SCH_ID.
            ViewState["EVA_SCH_SUB_ID"] = "";
        }
    }

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    void FillData()
    {
        fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), false, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSlot, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TimeSlot), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseName, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlBranch, ddlPaper);
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlPaper);
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBatch, ddlSemester);
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BranchName_ByCourse, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlBranch);
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBatch, ddlSemester);
        }
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlPaper);
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlBranch.Items.Count>0)
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBatch, ddlSemester);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlPaper);
    }
    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedIndex > 0)
        {
            if (ddlBatch.SelectedIndex > 0)
            {
                AcaBal.CommonId = ddlBranch.SelectedValue;
                AcaBal.KeyID = ddlBatch.SelectedValue;
                ViewState["EVA_SCH_ID"] = AcaBll.GetEvaSchID(AcaBal);
            }
            else
                commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlSemester);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select Branch then Batch !')", true);
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBatch, ddlSemester);
        }
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlPaper);
    }
    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemester.SelectedIndex > 0 && ddlBatch.SelectedIndex > 0)
        {
            AcaBal.Id = ViewState["EVA_SCH_ID"].ToString();
            AcaBal.TypeId = ddlSemester.SelectedValue;
            fillFunctions.Fill(ddlPaper, AcaBll.GetPaperCommand(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select Batch & Semester !')", true);
            ddlSemester.SelectedIndex = 0;
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlPaper);
        }
    }

    protected void ActivateWizard1(object sender, EventArgs e)
    {
        if (ddlPaper.SelectedIndex > 0)
        {
            timeTableWizard.ActiveStepIndex = 1;
            LoadStudent();
        }
        else
            timeTableWizard.ActiveStepIndex = 0;
    }
    public void LoadStudent()
    {
        AcaBal.TypeId = ddlSemester.SelectedValue;
        AcaBal.CommonId = ddlBranch.SelectedValue;
        fillFunctions.Fill(gridStudent, AcaBll.GetStudentForAtt(AcaBal).Tables[0]);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gridStudent.Rows)
        {
            AcaBal.Id = gridStudent.DataKeys[row.RowIndex].Values[0].ToString();
        }
    }
}
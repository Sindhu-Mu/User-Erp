using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_rptTimeTable : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        btnViewClass.Attributes.Add("OnClick", "return validation()");
        Initialize();
        if (!IsPostBack)
        {
            FillData();
        }
    }

    void FillData()
    {
        fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlSemesterBound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemesterBound.SelectedIndex > 0)
        {
            AcaBal.InsId = ddlInstitute.SelectedValue;
            fillFunctions.Fill(ddlChooseClass, AcaBll.GetClasses(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlChooseClass);
    }
    protected void btnViewClass_Click(object sender, EventArgs e)
    {
        LoadClassData();
    }
    void LoadClassData()
    {
        AcaBal.TypeId = "1";
        AcaBal.Id = ddlSemesterBound.SelectedValue;
        AcaBal.CommonId = ddlChooseClass.SelectedValue;
        AcaBal.KeyID = AcaBll.SaveClassSemester(AcaBal).Tables[0].Rows[0][0].ToString();
        AcaBal.FromDate = commonFunctions.GetDateTime(txtFromDate.Text);
        AcaBal.ToDate = commonFunctions.GetDateTime(txtEndDate.Text);

        //GridTimeTable.DataSource = AcaBll.GetTimeTable(AcaBal);
        //GridTimeTable.DataBind();

        AcaBll.GetTimeTable(tt_Calender, AcaBal, AcaBll.GetTimeTable(AcaBal));
        //tt_Calender.TimeScaleInterval = 30;
        //tt_Calender.DateField = "CLS_DATE";
        //tt_Calender.StartDate = AcaBal.FromDate;
        //TimeSpan span = AcaBal.ToDate.Subtract(AcaBal.FromDate);
        //tt_Calender.NumberOfDays = span.Days + 1;
        //tt_Calender.StartTimeField = "STR_TIME";
        //tt_Calender.EndTimeField = "END_TIME";
        //tt_Calender.DataSource = AcaBll.GetTimeTable(AcaBal).Tables[0];
        //tt_Calender.DataBind();

           //timeTable.GetTimeTable(tt_Calender, txtFromDate.Text, txtEndDate.Text, 30, timeTable.GetTimeTableClass(ddlChooseClass.SelectedValue), "DATE", "SRT_TIME", "END_TIME");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_rptFacultyTimeTable : System.Web.UI.Page
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
        Initialize();
        if (!IsPostBack)
        {
            FillData();
        }
    }

    void FillData()
    {
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlSemesterBound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemesterBound.SelectedIndex > 0)
        {
            AcaBal.SessionUserID = Session["UserId"].ToString();
            AcaBal.Semid = ddlSemesterBound.SelectedValue;
            fillFunctions.Fill(ddlChooseClass, AcaBll.GetFacClasses(AcaBal).Tables[0], true, FillFunctions.FirstItem.Select);
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
        AcaBal.TypeId = "2";
        AcaBal.SessionUserID = Session["UserId"].ToString();
        AcaBal.Id = ddlSemesterBound.SelectedValue;
        AcaBal.CommonId = ddlChooseClass.SelectedValue;
        AcaBal.KeyID = AcaBll.SaveClassSemester(AcaBal).Tables[0].Rows[0][0].ToString();
        AcaBal.FromDate = commonFunctions.GetDateTime(txtFromDate.Text);
        AcaBal.ToDate = commonFunctions.GetDateTime(txtEndDate.Text);
        AcaBll.GetTimeTable(tt_Calender, AcaBal, AcaBll.GetTimeTable(AcaBal));
    }
}
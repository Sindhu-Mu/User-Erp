using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_rptDailyAttSummaryForCord : System.Web.UI.Page
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
        btnView.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillData();
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlInstitute.SelectedIndex = 1;
        }
    }

    void FillData()
    {
        AcaBal.SessionUserID = Session["UserId"].ToString();
        fillFunctions.Fill(ddlInstitute, AcaBll.GetFacInstitute(AcaBal).Tables[0], true, FillFunctions.FirstItem.Select);
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
    protected void btnView_Click(object sender, EventArgs e)
    {
        AcaBal.InsId = ddlInstitute.SelectedValue;
        AcaBal.KeyID = ddlChooseClass.SelectedValue;
        AcaBal.CommonId = ddlSemesterBound.SelectedValue;
        AcaBal.Date = commonFunctions.GetDateTime(txtDate.Text);
        AcaBal.ChangeStatus = ddlstatus.SelectedValue;
        DataSet ds = new DataSet();
        ds = AcaBll.GetDailyAttSummaryForCord(AcaBal);
        gvShow.DataSource = ds.Tables[0];
        gvShow.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Appraisal_PA031 : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    protected void Page_Init()
    {
        PageManager aPage = new PageManager();
        System.Uri uri = Request.Url;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Reconnect", aPage.AddKeepAlive(uri.Segments[uri.Segments.GetUpperBound(0)].ToString()), true);
        APPBAL ObjBal = new APPBAL();
        APPBLL ObjBll = new APPBLL();
        ObjBal.SessionUserId = Session["UserId"].ToString();
        ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
        ObjBal.Year = DateTime.Now.Year.ToString();
        ObjBll.GetFaculty(ObjBal);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        this.MaintainScrollPositionOnPostBack = true;
        btnSave1A.Attributes.Add("OnClick", "return validation1A()");
        btnSave1B.Attributes.Add("OnClick", "return validation1B()");
        if (!IsPostBack)
        {
            pushData();
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();
            ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            pushData1A(ViewState["ID"].ToString());
            pushData1B(ViewState["ID"].ToString());
        }
    }
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }
    void pushData()
    {
        ObjBll.BuildGrid(gridData1A, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_1A, lblHeader1A, lblDescription1A);
        ObjBll.BuildGrid(gridData1B, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_1B, lblHeader1B, lblDescription1B);
    }
    void pushData1A(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData1A, ObjBll.PA03_1A_GetData(ObjBal));
    }
    void pushData1B(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData1B, ObjBll.PA03_1B_GetData(ObjBal));
    }
    protected void btnSave1A_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.PaperCode = txtCode.Text;
        ObjBal.PaperName = txtName.Text;
        ObjBal.Lecture = txtLecture.Text;
        ObjBal.Count = txtCount.Text;
        ObjBal.Practical = txtPractical.Text;
        ObjBal.Tutorail = txtTutorial.Text;
        ObjBal.Remark = txtRemark.Text;
        ObjBll.PA03_1A_SaveData(ObjBal);
        clear1A();
        pushData1A(ObjBal.Id);
    }
    void clear1A()
    {
        txtCode.Text = txtCount.Text = txtLecture.Text = txtName.Text = txtPractical.Text = txtRemark.Text = txtTutorial.Text = "";
    }
    protected void btnSave1B_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Detail = txtDetail.Text;
        ObjBll.PA03_1B_SaveData(ObjBal);
        txtDetail.Text = "";
        pushData1B(ObjBal.Id);
    }
    protected void gridData1A_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData1A.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_1A_DeleteData(ObjBal);
        pushData1A(ViewState["ID"].ToString());
    }
    protected void gridData1B_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData1B.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_1B_DeleteData(ObjBal);
        pushData1B(ViewState["ID"].ToString());
    }
}
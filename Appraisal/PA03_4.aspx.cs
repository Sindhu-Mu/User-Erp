using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_PA03_4 : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
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
        PageManager aPage = new PageManager();
        System.Uri uri = Request.Url;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Reconnect", aPage.AddKeepAlive(uri.Segments[uri.Segments.GetUpperBound(0)].ToString()), true);
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            pushData();
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();
            ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            pushData(ViewState["ID"].ToString());
        }
    }
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();

    }
    void pushData()
    {
        ObjBll.BuildGrid(gridData4A, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_4A, lblHeader4A, lblDescription4A);

    }
    void pushData(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData4A, ObjBll.PA03_4_GetData(ObjBal));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Others = txtOther.Text;
        ObjBal.FromDate = txtFromDate.Text;
        ObjBal.ToDate = txtToDate.Text;
        ObjBll.PA03_4_SaveData(ObjBal);
        clear();
        pushData(ViewState["ID"].ToString());
    }
    void clear()
    {
        txtFromDate.Text = txtOther.Text = txtToDate.Text = "";
    }
    protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData4A.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_4_DeleteData(ObjBal);
        pushData(ViewState["ID"].ToString());
    }
}
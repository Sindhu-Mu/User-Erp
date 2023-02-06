using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_PA036 : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;


    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialise();
        PageManager aPage = new PageManager();
        System.Uri uri = Request.Url;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Reconnect", aPage.AddKeepAlive(uri.Segments[uri.Segments.GetUpperBound(0)].ToString()), true);
        btnSave6A.Attributes.Add("OnClick", "return validation6A()");
        btnSave6B.Attributes.Add("OnClick", "return validation6B()");
        btnSave6C.Attributes.Add("OnClick", "return validation6C()");
        btnSave6D.Attributes.Add("OnClick", "return validation6D()");

        if (!IsPostBack)
        {
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();
            ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            pushData();
            pushData6A(ViewState["ID"].ToString());
            pushData6B(ViewState["ID"].ToString());
            pushData6C(ViewState["ID"].ToString());
            pushData6D(ViewState["ID"].ToString());
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
        FillFunction.FillYear(DateTime.Today.Year - 5, DateTime.Today.Year + 5, 1, FillFunctions.FirstItem.Select, ddlYear6A);
        FillFunction.FillInteger(1, 50, 1, FillFunctions.FirstItem.Select, ddlPeriod6A);
        FillFunction.Fill(ddlStatus6A, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PAStatus), true, FillFunctions.FirstItem.Select);
        ObjBll.BuildGrid(gridData6A, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData6B, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData6C, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData6D, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6A, lblHeader6A, lblDescription6A);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6B, lblHeader6B, lblDescription6B);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6C, lblHeader6C, lblDescription6C);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_6D, lblHeader6D, lblDescription6D);
    }
    #region 6A
    void pushData6A(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData6A, ObjBll.PA03_6A_GetData(ObjBal));
    }
    protected void btnSave6A_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Title = txtTitle6A.Text;
        ObjBal.Fund = txtFund6A.Text;
        ObjBal.Finance = txtFin6A.Text;
        ObjBal.Name = txtPI6A.Text;
        ObjBal.Year = ddlYear6A.SelectedValue;
        ObjBal.Month = ddlPeriod6A.SelectedValue;
        ObjBal.Status = ddlStatus6A.SelectedValue;
        ObjBll.PA03_6A_SaveData(ObjBal);
        clear6A();
        pushData6A(ViewState["ID"].ToString());
    }
    void clear6A()
    {
        txtFin6A.Text = txtFund6A.Text = txtPI6A.Text = txtTitle6A.Text = "";
        ddlPeriod6A.SelectedIndex = ddlStatus6A.SelectedIndex = ddlYear6A.SelectedIndex = 0;
    }
    protected void gridData6A_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData6A.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_6A_DeleteData(ObjBal);
        pushData6A(ViewState["ID"].ToString());
    }
    #endregion
    #region 6B
    void pushData6B(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData6B, ObjBll.PA03_6B_GetData(ObjBal));
    }
    protected void btnSave6B_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Title = txtTitle6B.Text;
        ObjBal.Detail = txtDetail6B.Text;
        ObjBal.Membership = txtMembers6B.Text;
        ObjBll.PA03_6B_SaveData(ObjBal);
        clear6B();
        pushData6B(ViewState["ID"].ToString());
    }
    void clear6B()
    {
        txtDetail6B.Text = txtMembers6B.Text = txtTitle6B.Text = "";
    }
    protected void gridData6B_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData6B.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_6B_DeleteData(ObjBal);
        pushData6B(ViewState["ID"].ToString());
    }
    #endregion

    #region 6C
    void pushData6C(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData6C, ObjBll.PA03_6C_GetData(ObjBal));
    }
    protected void btnSave6C_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Title = txtTitle6C.Text;
        ObjBal.FromDate = txtDate6C.Text;
        ObjBal.Place = txtPlace6C.Text;
        ObjBal.Program = txtProgramme6C.Text;
        ObjBal.Others = txtOther6C.Text;
        ObjBll.PA03_6C_SaveData(ObjBal);
        clear6C();
        pushData6C(ViewState["ID"].ToString());
    }
    void clear6C()
    {
        txtDate6C.Text = txtOther6C.Text = txtPlace6C.Text = txtProgramme6C.Text = txtTitle6C.Text = "";
    }
    protected void gridData6C_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData6C.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_6C_DeleteData(ObjBal);
        pushData6C(ViewState["ID"].ToString());
    }
    # endregion

    #region 6D
    void pushData6D(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData6D, ObjBll.PA03_6D_GetData(ObjBal));
    }
    protected void btnSave6D_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Task = txtTask6D.Text;
        ObjBal.FromDate = txtDate6D.Text;
        ObjBal.Place = txtPlace6D.Text;
        ObjBal.Program = txtProgramme6D.Text;
        ObjBal.Others = txtOther6D.Text;
        ObjBll.PA03_6D_SaveData(ObjBal);
        clear6D();
        pushData6D(ViewState["ID"].ToString());
    }
    void clear6D()
    {
        txtDate6D.Text = txtOther6D.Text = txtPlace6D.Text = txtProgramme6D.Text = txtTask6D.Text = "";
    }
    protected void gridData6D_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData6D.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_6D_DeleteData(ObjBal);
        pushData6D(ViewState["ID"].ToString());
    }
    # endregion

}
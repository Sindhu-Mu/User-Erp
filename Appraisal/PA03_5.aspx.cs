using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_PA035 : System.Web.UI.Page
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
        btnSave5A.Attributes.Add("OnClick", "return validation5A()");
        btnSave5B.Attributes.Add("OnClick", "return validation5B()");
        btnSave5C.Attributes.Add("OnClick", "return validation5C()");
        btnSave5D.Attributes.Add("OnClick", "return validation5D()");
        btnSave5E.Attributes.Add("OnClick", "return validation5E()");


        if (!IsPostBack)
        {
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();
            ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            pushData();
            pushData5A(ViewState["ID"].ToString());
            pushData5B(ViewState["ID"].ToString());
            pushData5C(ViewState["ID"].ToString());
            pushData5D(ViewState["ID"].ToString());
            pushData5E(ViewState["ID"].ToString());
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
        FillFunction.FillYear(DateTime.Today.Year - 5, DateTime.Today.Year + 5, 1, FillFunctions.FirstItem.Select, ddlReg5B);
        FillFunction.FillYear(DateTime.Today.Year - 5, DateTime.Today.Year + 5, 1, FillFunctions.FirstItem.Select, ddlYear5C);
        FillFunction.FillYear(DateTime.Today.Year - 5, DateTime.Today.Year + 5, 1, FillFunctions.FirstItem.Select, ddlYear5D);
        FillFunction.FillYear(DateTime.Today.Year - 5, DateTime.Today.Year + 5, 1, FillFunctions.FirstItem.Select, ddlYear5E);
        ObjBll.BuildGrid(gridData5A, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData5B, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData5C, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData5D, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData5E, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5A, lblHeader5A, lblDescription5A);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5B, lblHeader5B, lblDescription5B);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5C, lblHeader5C, lblDescription5C);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5D, lblHeader5D, lblDescription5D);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_5E, lblHeader5E, lblDescription5E);

    }
    #region 5A
    void pushData5A(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData5A, ObjBll.PA03_5A_GetData(ObjBal));
    }
    protected void btnSave5A_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Class = txtClass5A.Text;
        ObjBal.Name = txtStudents5A.Text;
        ObjBal.Supervisor = txtSupervisor5A.Text;
        ObjBal.Remark = txtRemarks5A.Text;
        ObjBal.Title = txtTitle5A.Text;
        ObjBll.PA03_5A_SaveData(ObjBal);
        clear5A();
        pushData5A(ViewState["ID"].ToString());
    }
    void clear5A()
    {
        txtClass5A.Text = txtRemarks5A.Text = txtStudents5A.Text = txtSupervisor5A.Text = txtTitle5A.Text = "";
    }
    protected void gridData5A_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData5A.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_5A_DeleteData(ObjBal);
        pushData5A(ViewState["ID"].ToString());
    }
    #endregion
    #region 5B
    void pushData5B(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData5B, ObjBll.PA03_5B_GetData(ObjBal));
    }
    protected void btnSave5B_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Name = txtName5B.Text;
        ObjBal.Title = txtTitle5B.Text;
        ObjBal.Supervisor = txtSupervisor5B.Text;
        ObjBal.Year = ddlReg5B.SelectedValue;
        ObjBll.PA03_5B_SaveData(ObjBal);
        clear5B();
        pushData5B(ViewState["ID"].ToString());
    }
    void clear5B()
    {
        txtName5B.Text = txtSupervisor5B.Text = txtTitle5B.Text = "";
        ddlReg5B.SelectedIndex = 0;
    }
    protected void gridData5B_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData5B.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_5B_DeleteData(ObjBal);
        pushData5B(ViewState["ID"].ToString());
    }
    #endregion

    #region 5C
    void pushData5C(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData5C, ObjBll.PA03_5C_GetData(ObjBal));
    }
    protected void btnSave5C_Click(object sender, EventArgs e)
    {

        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Author = txtAuthor5C.Text;
        ObjBal.Journal = txtJournal5C.Text;
        ObjBal.Title = txtTitle5C.Text;
        ObjBal.Volume = txtVol5C.Text;
        ObjBal.Page = txtPage5C.Text;
        ObjBal.Year = ddlYear5C.SelectedValue;
        ObjBll.PA03_5C_SaveData(ObjBal);
        clear5C();
        pushData5C(ViewState["ID"].ToString());
    }
    void clear5C()
    {
        txtAuthor5C.Text = txtJournal5C.Text = txtPage5C.Text = txtTitle5C.Text = txtVol5C.Text = "";
        ddlYear5C.SelectedIndex = 0;
    }
    protected void gridData5C_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData5C.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_5C_DeleteData(ObjBal);
        pushData5C(ViewState["ID"].ToString());
    }
    # endregion

    #region 5D
    void pushData5D(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData5D, ObjBll.PA03_5D_GetData(ObjBal));
    }
    protected void btnSave5D_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Author = txtAuthor5D.Text;
        ObjBal.Title = txtTitle5D.Text;
        ObjBal.Conference = txtConference5D.Text;
        ObjBal.Place = txtPlace5D.Text;
        ObjBal.Page = txtPage5D.Text;
        ObjBal.Year = ddlYear5D.SelectedValue;
        ObjBll.PA03_5D_SaveData(ObjBal);
        clear5D();
        pushData5D(ViewState["ID"].ToString());
    }
    void clear5D()
    {
        txtAuthor5D.Text = txtConference5D.Text = txtPage5D.Text = txtPlace5D.Text = txtTitle5D.Text = "";
        ddlYear5D.SelectedIndex = 0;
    }
    protected void gridData5D_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData5D.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_5D_DeleteData(ObjBal);
        pushData5D(ViewState["ID"].ToString());
    }
    # endregion

    #region 5E
    void pushData5E(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData5E, ObjBll.PA03_5E_GetData(ObjBal));
    }
    protected void btnSave5E_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Author = txtAuthor5E.Text;
        ObjBal.Title = txtTitle5E.Text;
        ObjBal.Publisher = txtPublisher5E.Text;
        ObjBal.Volume = txtVolume5E.Text;
        ObjBal.Page = txtPage5E.Text;
        ObjBal.Year = ddlYear5E.SelectedValue;
        ObjBll.PA03_5E_SaveData(ObjBal);
        clear();
        pushData5E(ViewState["ID"].ToString());
    }
    void clear()
    {
        txtAuthor5E.Text = txtPage5E.Text = txtPublisher5E.Text = txtTitle5E.Text = txtVolume5E.Text = "";
        ddlYear5E.SelectedIndex = 0;
    }
    protected void gridData5E_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData5E.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_5E_DeleteData(ObjBal);
        pushData5E(ViewState["ID"].ToString());
    }
    # endregion

}
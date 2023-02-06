using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Appraisal_PA033 : System.Web.UI.Page
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
        btnSave3A.Attributes.Add("OnClick", "return validation3A()");
        btnSave3B.Attributes.Add("OnClick", "return validation3B()");
        btnSave3C.Attributes.Add("OnClick", "return validation3C()");
        btnSave3D.Attributes.Add("OnClick", "return validation3D()");
        btnSave3E.Attributes.Add("OnClick", "return validation3E()");


        if (!IsPostBack)
        {
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();
            ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            pushData();
            pushData3A(ViewState["ID"].ToString());
            pushData3B(ViewState["ID"].ToString());
            pushData3C(ViewState["ID"].ToString());
            pushData3D(ViewState["ID"].ToString());
            pushData3E(ViewState["ID"].ToString());
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
        ObjBll.BuildGrid(gridData3A, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData3B, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData3C, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData3D, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData3E, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3A, lblHeader3A, lblDescription3A);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3B, lblHeader3B, lblDescription3B);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3C, lblHeader3C, lblDescription3C);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3D, lblHeader3D, lblDescription3D);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_3E, lblHeader3E, lblDescription3E);

    }
    #region 3A
    void pushData3A(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData3A, ObjBll.PA03_3A_GetData(ObjBal));
    }
    protected void btnSave3A_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Award = txtAward3A.Text;
        ObjBal.Remark = txtRemark3A.Text;
        ObjBll.PA03_3A_SaveData(ObjBal);
        clear();
        pushData3A(ViewState["ID"].ToString());
    }
    void clear()
    {
        txtAward3A.Text = txtRemark3A.Text = "";
    }
    protected void gridData3A_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData3A.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_3A_DeleteData(ObjBal);
        pushData3A(ViewState["ID"].ToString());
    }
    #endregion
    #region 3B
    void pushData3B(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData3B, ObjBll.PA03_3B_GetData(ObjBal));
    }
    protected void btnSave3B_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Membership = txtMembership3B.Text;
        ObjBal.Remark = txtRemark3B.Text;
        ObjBll.PA03_3B_SaveData(ObjBal);
        clear3B();
        pushData3B(ViewState["ID"].ToString());
    }
    void clear3B()
    {
        txtMembership3B.Text = txtRemark3B.Text = "";
    }
    protected void gridData3B_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData3B.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_3B_DeleteData(ObjBal);
        pushData3B(ViewState["ID"].ToString());
    }
    #endregion

    #region 3C
    void pushData3C(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData3C, ObjBll.PA03_3C_GetData(ObjBal));
    }
    protected void btnSave3C_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Name = txtName3C.Text;
        ObjBal.Sponsor = txtSponsoredBy3C.Text;
        ObjBal.FromDate = txtFromDate3C.Text;
        ObjBal.ToDate = txtToDate3C.Text;
        ObjBll.PA03_3C_SaveData(ObjBal);
        clear3C();
        pushData3C(ViewState["ID"].ToString());
    }
    void clear3C()
    {
        txtFromDate3C.Text = txtName3C.Text = txtSponsoredBy3C.Text = txtToDate3C.Text = "";
    }
    protected void gridData3C_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData3C.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_3C_DeleteData(ObjBal);
        pushData3C(ViewState["ID"].ToString());
    }
    # endregion

    #region 3D
    void pushData3D(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData3D, ObjBll.PA03_3D_GetData(ObjBal));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Institute = txtIns3D.Text;
        ObjBal.Purpose = txtPup3D.Text;
        ObjBal.FromDate = txtFromDate3D.Text;
        ObjBal.ToDate = txtToDate3D.Text;
        ObjBll.PA03_3D_SaveData(ObjBal);
        clear3D();
        pushData3D(ViewState["ID"].ToString());
    }
    void clear3D()
    {
        txtFromDate3D.Text = txtIns3D.Text = txtPup3D.Text = txtToDate3D.Text = "";
    }
    protected void gridData3D_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData3D.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_3D_DeleteData(ObjBal);
        pushData3D(ViewState["ID"].ToString());
    }
    # endregion

    #region 3E
    void pushData3E(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData3E, ObjBll.PA03_3E_GetData(ObjBal));
    }
    protected void btnSave3E_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Name = txtName3E.Text;
        ObjBal.Place = txtPlace3E.Text;
        ObjBal.Sponsor = txtSponsoredBy3E.Text;
        ObjBal.FromDate = txtFromDate3E.Text;
        ObjBal.ToDate = txtToDate3E.Text;
        ObjBll.PA03_3E_SaveData(ObjBal);
        clear3E();
        pushData3E(ViewState["ID"].ToString());
    }
    void clear3E()
    {
        txtFromDate3E.Text = txtName3E.Text = txtPlace3E.Text = txtSponsoredBy3E.Text = txtToDate3E.Text = "";
    }
    protected void gridData3E_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData3E.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_3E_DeleteData(ObjBal);
        pushData3E(ViewState["ID"].ToString());
    }
    # endregion
        
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Facility_VehicleMaster : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable dt;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillFunction.FillYear(2000, 2020, 1, FillFunctions.FirstItem.Select, ddlModelYer);
            ViewState["ID"] = "";
            FillgvVehMain();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        dt = new DataTable();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();

    }
    private void FillgvVehMain()
    {
        dt = ObjFacBll.VehicleMainSelect().Tables[0];
        ViewState["dt"] = dt;
        gvVehMain.DataSource = dt;
        gvVehMain.DataBind();
    }
    void clear()
    {
        txtRegNo.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlVehType);
        txtSetCap.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlModelYer);
        txtchasis.Text = "";
        txtEngine.Text = "";
        txtModelTyp.Text = "";
        txtColor.Text = "";
        txtInsUpto.Text = "";
        txtPolUpto.Text = "";
        txtRoadTax.Text = "";
        txtRoadPermit.Text = "";
        txtTokenTax.Text = "";
        txtFitness.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.VehCat = rdVehCat.SelectedValue;
        ObjFacBal.ValueType = ddlVehType.SelectedValue;
        ObjFacBal.RegId = txtRegNo.Text;
        ObjFacBal.Seat = txtSetCap.Text;
        ObjFacBal.Value = ddlModelYer.SelectedValue;
        ObjFacBal.Info = txtchasis.Text;
        ObjFacBal.No = txtEngine.Text;
        ObjFacBal.Color = txtColor.Text;
        if (txtInsUpto.Text != "")
            ObjFacBal.Date = CommonFunction.GetDateTime(txtInsUpto.Text);
        if (txtPolUpto.Text != "")
            ObjFacBal.ToDate = CommonFunction.GetDateTime(txtPolUpto.Text);
        ObjFacBal.TypeId = txtModelTyp.Text;
        if (txtRoadTax.Text != "")
            ObjFacBal.SrtDate = CommonFunction.GetDateTime(txtRoadTax.Text);
        if (txtRoadPermit.Text != "")
            ObjFacBal.RegSrtDate = CommonFunction.GetDateTime(txtRoadPermit.Text);
        if (txtTokenTax.Text != "")
            ObjFacBal.RegEndDate = CommonFunction.GetDateTime(txtTokenTax.Text);
        if (txtFitness.Text != "")
            ObjFacBal.RegFineDate = CommonFunction.GetDateTime(txtFitness.Text);
        Msg = ObjFacBll.VehicleMainInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillgvVehMain();
        clear();
    }

    protected void gvVehMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {


        ViewState["ID"] = gvVehMain.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        ObjFacBal.Id = ViewState["ID"].ToString();
        dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("VEH_ID=" + ViewState["ID"].ToString() + "");

        rdVehCat.SelectedValue = dr[0]["VEH_CAT"].ToString();
        ddlVehType.SelectedValue = dr[0]["VEH_TYPE"].ToString();
        txtRegNo.Text = dr[0]["VEH_REG_NO"].ToString();
        txtSetCap.Text = dr[0]["VEH_SEAT_CAPICITY"].ToString();
        ddlModelYer.SelectedValue = dr[0]["VEH_MODEL_YEAR"].ToString();
        txtchasis.Text = dr[0]["VEH_CHASIS_NO"].ToString();
        txtEngine.Text = dr[0]["VEH_ENGINE_NO"].ToString();
        txtColor.Text = dr[0]["VEH_COLOR"].ToString();
        txtInsUpto.Text = dr[0]["VEH_INSURANCE_UPTO"].ToString();
        txtPolUpto.Text = dr[0]["VEH_POLLUTION_UPTO"].ToString();
        txtModelTyp.Text = dr[0]["MODEL_TYPE"].ToString();
        txtRoadTax.Text = dr[0]["VEH_ROADTAX_DT"].ToString();
        txtRoadPermit.Text = dr[0]["RTE_PERMIT_UPTO"].ToString();
        txtTokenTax.Text = dr[0]["TOKEN_TAX_DT"].ToString();
        txtFitness.Text = dr[0]["FITNESS_DT"].ToString();
        // Msg = ObjFacBll.VehicleMainInsertUpdate(ObjFacBal);
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        //ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillgvVehMain();
    }
}
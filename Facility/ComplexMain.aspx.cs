using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Facility_ComplexMain : System.Web.UI.Page
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
        btnSave.Attributes.Add("OnClick", "return validateType()");
        btnAdd.Attributes.Add("OnClick", "return validateMain()");
            if(!IsPostBack)
            {
                ViewState["ID"]="";
                FillGvType();
                FillGvMain();
                FillFunction.Fill(ddlComType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ComplexType), true, FillFunctions.FirstItem.Select);
            }
    }
    private void FillGvType()
    {
        dt = ObjFacBll.ComplexTypeSelect().Tables[0];                                     
        ViewState["dt"] = dt;
        gvComType.DataSource = dt;
        gvComType.DataBind();

    }
    private void FillGvMain()
    {
        dt = ObjFacBll.ComplexMasterSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvAdd.DataSource = dt;
        gvAdd.DataBind();
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();

    }
    void clear()
    {
        txtComType.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlComType);
        txtComName.Text = "";
        txtNoRoom.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Value = txtComType.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjFacBll.ComplexTypeInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillGvType();
        clear();

    }
    protected void gvComType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvComType.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FAC_CMPLX_TYP_ID=" + ViewState["ID"].ToString());
            if (dr[0]["FAC_CMPLX_TYP_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtComType.Text = dr[0]["FAC_CMPLX_TYP_VALUE"].ToString();

        }
        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.KeyID = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.ComplexTypeModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillGvType();
            clear();

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Name = txtComName.Text;
        ObjFacBal.CommonId = ddlComType.SelectedValue;
        ObjFacBal.Value = txtNoRoom.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjFacBll.ComplexMasterInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillGvMain();
        clear();
    }
    protected void gvAdd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvAdd.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FAC_CMPLX_ID=" + ViewState["ID"].ToString());
            if (dr[0]["FAC_CMPLX_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtComName.Text = dr[0]["FAC_CMPLX_NAME"].ToString();
            ddlComType.SelectedValue = dr[0]["FAC_CMPLX_TYP_ID"].ToString();
            txtNoRoom.Text = dr[0]["FAC_CMPLX_ROOM_NO"].ToString();

        }

        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.KeyID = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.ComplexMasterModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillGvMain();
            clear();
        }
    }
}
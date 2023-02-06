using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_ComplexTypeMain : System.Web.UI.Page
{
    CommonFunctions common;
    FacBLL bll;
    DataTable dt;
    FacBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        txtCmplxTypeValue.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
            
        }
    }
    private void Initialize()
    {
        common = new CommonFunctions();      
        dt = new DataTable();
        bll = new FacBLL();
        bal = new FacBAL();
    }
    private void FillGrid()
    {

        dt = bll.ComplexTypeSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        bal.KeyID = ViewState["ID"].ToString();
        bal.Value = txtCmplxTypeValue.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.ComplexTypeInsertUpdate(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        common.Clear(this);
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FAC_CMPLX_TYP_ID=" + ViewState["ID"].ToString());
            if (dr[0]["FAC_CMPLX_TYP_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtCmplxTypeValue.Text = dr[0]["FAC_CMPLX_TYP_VALUE"].ToString();

        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.ComplexTypeModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            common.Clear(this);
            FillGrid();

        }
    }
}
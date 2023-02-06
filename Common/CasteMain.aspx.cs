using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Common_CasteMain : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onClick", "return validation()");
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
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    private void FillGrid()// fill grid view with select all record from table
    {
        dt = ObjHrBll.CasteSelect().Tables[0];                                      
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)                             //Insert and Update Information
    {
        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.FullName = txtCatseName.Text;
        ObjAcaBAL.AliasValue = txtCasteAlias.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();      
        Msg =   ObjHrBll.CasteInsertUpdate(ObjAcaBAL);      
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        common.Clear(this);
        FillGrid();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)          // Status Change In Update Forms
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("CAS_ID=" + ViewState["ID"].ToString());
            if (dr[0]["CAS_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtCatseName.Text = dr[0][1].ToString();
            txtCasteAlias.Text = dr[0][2].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.CasteModify(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }

}
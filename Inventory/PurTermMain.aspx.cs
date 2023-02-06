using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public partial class Inventory_PurTerm_Main : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;  
    DataTable dt;
    string msg;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        if (!IsPostBack)
        {
            btnSave.Attributes.Add("OnClick", "return validation()");
            ViewState["dt"] = dt;
            ViewState["ID"] = "";
            BindGridData();
            txtTerm.Focus();


        }

    }

    void Initialize()
    {
        databaseFunctions = new DatabaseFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();     
        dt = new DataTable();
    }
    void BindGridData()
    {      
        ViewState["dt"] = objBll.GetPurTerm(objBal).Tables[0];
        gvTerm.DataSource = ViewState["dt"];
        gvTerm.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objBal.ID = ViewState["ID"].ToString();
        objBal.Name = txtTerm.Text;
        objBal.Description = txtDesc.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.PurTermInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        txtTerm.Text = txtDesc.Text = "";        
        ViewState["ID"] = "";
        BindGridData();
        txtTerm.Focus();
    }
    protected void gvTerm_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            dt = (DataTable)ViewState["dt"];
            ViewState["ID"] = gvTerm.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            DataRow[] dr = dt.Select("PUR_TERM_ID=" + ViewState["ID"].ToString());
            if (dr[0]["PUR_TERM_STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtTerm.Text = dr[0]["PUR_TERM"].ToString();
            txtDesc.Text = dr[0]["PUR_TERM_DESC"].ToString();
        }
        else
        {
            objBal.Status = e.CommandName;
            objBal.KeyId = e.CommandArgument.ToString();
            objBal.SessionUserId = Session["UserId"].ToString();
            msg = objBll.PurTermModify(objBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
            BindGridData();
        }
    }
}
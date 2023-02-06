using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_UnitMain : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    string msg;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnUnit.Attributes.Add("onClick", "return validate()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            pushData();
        }
    }
    void pushData()
    {
        dt = objBll.getUnit().Tables[0];
        ViewState["dt"] = dt;
        gvUnit.DataSource = dt;
        gvUnit.DataBind();
    }
    void Initialize()
    {

        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    protected void btnUnit_Click(object sender, EventArgs e)
    {
        objBal.ID = ViewState["ID"].ToString();
        objBal.Unit = txtUnit.Text;
        msg = objBll.UnitInsertUpdate(objBal);
        txtUnit.Text = "";
        ViewState["ID"] = "";
        pushData();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }
    protected void gvUnit_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvUnit.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("UNIT_ID=" + ViewState["ID"].ToString());
            if (dr[0]["UNIT_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtUnit.Text = dr[0]["UNIT_NAME"].ToString();

        }
        else
        {
            objBal.Status = e.CommandName;
            objBal.KeyId = e.CommandArgument.ToString();
            msg = objBll.UnitModify(objBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
            pushData();

        }

    }
}
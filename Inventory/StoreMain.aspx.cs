using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Inventory_StoreMain : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnStoreSave.Attributes.Add("OnClick", "return validateBtnSaveStore()");
        btnInchargeSave.Attributes.Add("OnClick", "return validateIncharge()");
        if (!IsPostBack)
        {
            ViewState["STO_ID"] = ViewState["dt"] = "";
            step1.ActiveTabIndex = 1;
            fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
            BindInchargeGrid();
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();

    }
    void BindGrid()
    {
        
        ViewState["dt"] = objBll.getStore(objBal).Tables[0];
        gv_Store.DataSource = ViewState["dt"];
        gv_Store.DataBind();
    }
    void BindInchargeGrid()
    {
        objBal.ID = ddlStore.SelectedValue;
        ViewState["dt"] = objBll.getStoreInCharge(objBal).Tables[0];
        gvIncgarge.DataSource = ViewState["dt"];
        gvIncgarge.DataBind();
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            BindGrid();
            ViewState["STO_ID"] = "";
            txtStoreName.Text = txtDesc.Text = "";
        }
        else
        {
            fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
            BindInchargeGrid();
        }

    }
    protected void gv_Store_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["STO_ID"] = gv_Store.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt= (DataTable)ViewState["dt"];           
            DataRow[] dr = dt.Select("STO_ID=" + ViewState["STO_ID"].ToString() + "");
            txtStoreName.Text = dr[0]["STO_Name"].ToString();
            txtDesc.Text = dr[0]["STO_DESC"].ToString();
        }
    }

    protected void btnStoreSave_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ViewState["STO_ID"].ToString();
        objBal.StoreName = txtStoreName.Text;
        objBal.Description = txtDesc.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.StoreInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        BindGrid();
        ViewState["STO_ID"] = "";
        txtStoreName.Text = txtDesc.Text = "";
    }
    protected void btnInchargeSave_Click(object sender, EventArgs e)
    {
        objBal.ID = ddlStore.SelectedValue;
        objBal.KeyId = commonFunctions.GetKeyID(txtEmp);
        objBal.Date = txtFromDt.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.StoreInchargeInsert(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);        
        ddlStore.SelectedIndex = 0;
        txtEmp.Text = txtFromDt.Text = "";
        BindInchargeGrid();
    }
}
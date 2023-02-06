using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Inventory_ItemMain : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    String msg;
    DataTable dt;
   
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        dt = new DataTable();
        databaseFunctions = new DatabaseFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        btnSaveCat.Attributes.Add("OnClick", "return validateCategory()");
        btnSaveSubCat.Attributes.Add("OnClick", "return validateSubCat()");
        btnSaveItem.Attributes.Add("OnClick", "return validateItem()");
        if (!IsPostBack)
        {

            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            step1.ActiveTabIndex = 2;
            fillFunctions.Fill(ddlItemStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item_Store, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlUnit, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Unit), true, FillFunctions.FirstItem.Select);
            bind_DropDownCat(ddlItemCat);
        }
    }
    public void BindCategory()
    {
        ViewState["dt"] = objBll.getCategory(objBal).Tables[0];
        gridCategory.DataSource = ViewState["dt"];
        gridCategory.DataBind();
    }
    public void BindSubCat()
    {
        objBal.CatId = ddlCategory.SelectedValue;
        ViewState["dt"] = objBll.getSubCategory(objBal).Tables[0];
        gridSubCat.DataSource = ViewState["dt"];
        gridSubCat.DataBind();
    }
    public void BindItem()
    {

        objBal.ID = ddlItemStore.SelectedValue;
        objBal.CatId = ddlItemCat.SelectedValue;
        objBal.Typ = ddlSubCat.SelectedValue;
        ViewState["dt"] = objBll.getStoreItem(objBal).Tables[0];
        gridItem.DataSource = ViewState["dt"];
        gridItem.DataBind();
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {

        if (step1.ActiveTabIndex == 0)
        {
            ViewState["ID"] = "";
            BindCategory();
            txtCatName.Text = "";
        }
        else if (step1.ActiveTabIndex == 1)
        {
            ViewState["ID"] = "";
            bind_DropDownCat(ddlCategory);
            BindSubCat();
            txtSubCatDesc.Text = "";

        }
        else if (step1.ActiveTabIndex == 2)
        {
            ViewState["ID"] = "";
            fillFunctions.Fill(ddlItemStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item_Store, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlUnit, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Unit), true, FillFunctions.FirstItem.Select);
            bind_DropDownCat(ddlItemCat);
            //Bind_GVItem();
        }



    }

    protected void btnSaveCat_Click(object sender, EventArgs e)
    {
        objBal.CatName = txtCatName.Text;
        objBal.KeyId = ViewState["ID"].ToString();
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.CategoryInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        BindCategory();
        ViewState["ID"] = "";
        txtCatName.Text = "";
    }


    public void bind_DropDownCat(DropDownList ddl)
    {
      
        //    fillFunctions.Fill(ddl, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY,"4"), true, FillFunctions.FirstItem.Select);
        //else
        fillFunctions.Fill(ddl, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
    }
    protected void btnSaveSubCat_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ViewState["ID"].ToString();
        objBal.SubCatName = txtSubCatName.Text;
        objBal.CatId = ddlCategory.SelectedValue.ToString();
        objBal.Description = txtSubCatDesc.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.SubCategoryInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        ViewState["ID"] = "";
        txtSubCatName.Text = txtSubCatDesc.Text = "";
        BindSubCat();
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSubCat();
    }
    protected void gridCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gridCategory.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("CAT_ID=" + ViewState["ID"].ToString() + "");
        txtCatName.Text = dr[0]["CAT_NAME"].ToString();
    }
    protected void gridSubCat_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gridSubCat.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("SUB_CAT_ID=" + ViewState["ID"].ToString() + "");
        ddlCategory.SelectedValue = dr[0]["CAT_ID"].ToString();
        txtSubCatName.Text = dr[0]["SUB_CAT_NAME"].ToString();
        txtSubCatDesc.Text = dr[0]["SUB_CAT_DESC"].ToString();
    }
    protected void ddlItemStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlItemStore.SelectedIndex > 0)
        {
            //fillFunctions.Fill(ddlItemCat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sto_Cat, ddlItemStore.SelectedValue), true, FillFunctions.FirstItem.All);
            BindItem();
        }
    }
    protected void ddlItemCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlSubCat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubCategory, ddlItemCat.SelectedValue), true, FillFunctions.FirstItem.Select);
        BindItem();
    }
    protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindItem();
    }
    protected void btnSaveItem_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ViewState["ID"].ToString();
        objBal.ID = ddlItemStore.SelectedValue;
        objBal.SubCatId = ddlSubCat.SelectedValue;
        objBal.ItemName = txtItemName.Text;
        objBal.ReorderLevel = txtReorderLevel.Text;
        objBal.Quantity = txtQuantity.Text;
        objBal.Description = txtDescription.Text;
        objBal.Unit = ddlUnit.SelectedValue;
        objBal.Typ = Rlist.SelectedValue;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.ItemInsertUpdate(objBal);
        BindItem();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        ddlUnit.SelectedIndex = ddlItemCat.SelectedIndex = ddlItemStore.SelectedIndex = ddlSubCat.SelectedIndex = Rlist.SelectedIndex = 0;
        txtDescription.Text = txtItemName.Text = txtQuantity.Text = txtQuantity.Text =txtReorderLevel.Text= "";
    }

    protected void gridItem_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gridItem.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("ITEM_ID=" + ViewState["ID"].ToString() + "");
        ddlItemCat.SelectedValue = dr[0]["CAT_ID"].ToString();
        fillFunctions.Fill(ddlSubCat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubCategory, ddlItemCat.SelectedValue.ToString()), true, FillFunctions.FirstItem.Select);
        ddlSubCat.SelectedValue = dr[0]["SUB_CAT_ID"].ToString();
        txtItemName.Text = dr[0]["ITEM_NAME"].ToString();
        txtQuantity.Text = dr[0]["QTY"].ToString();
        txtReorderLevel.Text = dr[0]["RDR_LVL"].ToString();
        fillFunctions.Fill(ddlUnit, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Unit), true, FillFunctions.FirstItem.Select);
        ddlUnit.SelectedValue = dr[0]["UNIT_ID"].ToString();
        fillFunctions.Fill(ddlItemStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item_Store, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
        ddlItemStore.SelectedValue = dr[0]["STO_ID"].ToString();
        Rlist.SelectedIndex = Convert.ToInt32(dr[0]["IS_RTN_APP"]);
        txtDescription.Text = dr[0]["ITEM_DESC"].ToString();

    }

    protected void btnCancelItem_Click(object sender, EventArgs e)
    {
       // commonFunctions.Clear(this);
        ddlItemCat.SelectedIndex = ddlItemStore.SelectedIndex = ddlSubCat.SelectedIndex = ddlUnit.SelectedIndex = 0;
        txtItemName.Text = txtReorderLevel.Text = txtQuantity.Text = txtDescription.Text = "";
    }


}
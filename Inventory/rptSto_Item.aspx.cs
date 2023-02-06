using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class Inventory_rptSto_Item : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string strCh;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnView.Attributes.Add("onClick", "return validate()");
        Initialize();
        if (!IsPostBack)
        {
            ViewState["index"] = "";
            ViewState["GRN"] = "";
            ViewState["SIV"] = "";
            pushData();

        }
        for (int i = 65; i < 91; i++)
        {
            LinkButton lb = new LinkButton();
            lb.Text = Char.ConvertFromUtf32(i) + " ";
            lb.CommandArgument = Char.ConvertFromUtf32(i);
            lb.ForeColor = Color.White;
            lb.CssClass = "whitelink";
            lb.Click += new EventHandler(lb_Click);
            cell.Controls.Add(lb);
        }
    }
    protected void lb_Click(object sender, EventArgs e)
    {
        strCh = ((LinkButton)sender).Text.Trim();
        bindgvItems();
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
        strCh = "";
    }
    void pushData()
    {
        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item_Store, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.All);
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlSubCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubCategory, ddlCategory.SelectedValue), true, FillFunctions.FirstItem.All);
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlCategory);
        }
    }
    void bindgvItems()
    {
        objBal.Typ = "";
        objBal.StoreName = ddlStore.SelectedValue;
        objBal.CatId = ddlCategory.SelectedValue;
        objBal.Typ = "3";
        objBal.SubCatId = ddlSubCategory.SelectedValue;
        objBal.ItemName = strCh;
        objBal.ItemId = txtContains.Text;
        fillFunctions.Fill(gvItems, objBll.GetItemReport(objBal).Tables[0]);
        UpdatePanel3.Update();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        bindgvItems();
    }

    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {        
            objBal.ItemId = gvItems.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            fillFunctions.Fill(gvGRN_SIV, objBll.GetStockGRNSIVReport(objBal).Tables[0]);
            double amt = 0;
            foreach (GridViewRow row in gvGRN_SIV.Rows)
            {
                double cr = Convert.ToDouble(row.Cells[4].Text);
                double dr = Convert.ToDouble(row.Cells[5].Text);
                amt = amt + cr - dr;
                row.Cells[3].Text = amt.ToString("N2");
            }
            UpdatePanel4.Update();
        }
    }
    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sto_Cat, ddlStore.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }

}
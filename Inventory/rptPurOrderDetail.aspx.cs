using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Inventory_rptPurOrderDetail : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {

            fillFunctions.Fill(ddlPOID, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurOrderRpt, ddlYear.SelectedValue), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSupplier, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.Select);
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

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ddlYear.SelectedValue;
        objBal.PurNo = ddlPOID.SelectedValue;
        objBal.VenId = ddlSupplier.SelectedValue;
        objBal.Identification = ddlDate.SelectedValue;
        objBal.ItemId = ddlItem.SelectedValue;
        if (ddlDate.SelectedValue == "3")
        {
            objBal.ToDate = commonFunctions.GetDateTime(txtToDT.Text).ToString();
            objBal.Date = commonFunctions.GetDateTime(txtFromDT.Text).ToString();

        }
        else
        {
            objBal.ToDate = txtToDT.Text;
            objBal.Date = txtFromDT.Text;
        }
        objBal.ID = ddlSort.SelectedValue;
        gvPurchase.DataSource = objBll.GetPurOrderDetails(objBal);
        gvPurchase.DataBind();


    }
    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlDate":
                if (ddlDate.SelectedValue == "3")
                {
                    txtFromDT.Enabled = true;
                    txtToDT.Enabled = true;
                }
                else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
                {
                    txtFromDT.Enabled = true;
                    txtToDT.Enabled = false;
                }
                else
                {
                    txtFromDT.Enabled = false;
                    txtToDT.Enabled = false;
                }
                txtToDT.Text = txtFromDT.Text = "";
                break;



            default:
                break;
        }
    }
 
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("PODetail.xls", gvPurchase);
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlPOID, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurOrderRpt, ddlYear.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
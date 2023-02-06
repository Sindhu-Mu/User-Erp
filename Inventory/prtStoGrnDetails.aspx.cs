using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
public partial class Inventory_prtStoGrnDetails : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (Request.QueryString.Count > 0)
        {
            objBal.ID = Request.QueryString["GRN_ID"].ToString();
            //objBal.ItemId = "";
            DataSet ds = objBll.GetItemBoundGrnDetail(objBal);
            fillFunctions.Fill(repStoreIssueVoucher, ds.Tables[0]);
            GridView gridItem = repStoreIssueVoucher.Items[0].FindControl("gridItem") as GridView;
            gridItem.DataSource = ds.Tables[1];
            gridItem.DataBind();
            //fillFunctions.Fill(gridItem, ds.Tables[1]);
            ((GridView)repStoreIssueVoucher.Items[0].FindControl("gridItem")).FooterRow.Cells[3].Text = "Total: ";
            ((GridView)repStoreIssueVoucher.Items[0].FindControl("gridItem")).FooterRow.Cells[4].Text = ds.Tables[2].Rows[0][0].ToString();

        }
    }
}
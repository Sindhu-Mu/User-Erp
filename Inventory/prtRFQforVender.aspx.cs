using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Inventory_prtRFQforVender : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    public void Initialize()
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
            objBal.ID = Request.QueryString[0].ToString();
            //objBal.VenId = Request.QueryString["venId"].ToString();
            Repeater1.DataSource = databaseFunctions.GetDataSet(objBll.RFQPrintSupplierDetails(objBal)).Tables[0];
            Repeater1.DataBind();
        }

    }
    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ((GridView)e.Item.FindControl("gvItemDetail")).DataSource = databaseFunctions.GetDataSet(objBll.RFQPrintItemDetails(objBal)).Tables[0];
        ((GridView)e.Item.FindControl("gvItemDetail")).DataBind();
    }

    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
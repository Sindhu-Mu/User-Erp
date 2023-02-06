using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_rptPur_Count : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            DataSet ds = objBll.GetPurCount(objBal);
            fillFunctions.Fill(gvStore, ds.Tables[0]);
            fillFunctions.Fill(gvCategory, ds.Tables[1]);
            fillFunctions.Fill(gvSubCategory, ds.Tables[2]);
            fillFunctions.Fill(gvItem, ds.Tables[3]);
            fillFunctions.Fill(gvStatus, ds.Tables[4]);
            fillFunctions.Fill(gvVendor, ds.Tables[5]);
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
}
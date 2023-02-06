using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_prntSto_SIV : System.Web.UI.Page
{
    
  
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;    
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        if (Request.QueryString[0].ToString() == "Select")
            return;
        if (Request.QueryString[0].ToString() == "NULL")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Valid SIV NO.')", true);
        }
        else
        {
            objBal.Typ = "2";
            objBal.ID = Request.QueryString[0].ToString();
            dt = objBll.GetStockGRNReport(objBal).Tables[0];
            lbldate.Text = Convert.ToDateTime(dt.Rows[0]["INS_DATE"]).ToString("dd-MMM-yyyy hh:m tt");
            lblsiv.Text = dt.Rows[0]["SIV_CAL_ID"].ToString();
            lblReceiveBy.Text = dt.Rows[0]["Received_By"].ToString();
            lblIssuedBy.Text = dt.Rows[0]["Issued_By"].ToString();
            if (Convert.ToInt32(dt.Rows[0]["IND_BY_TYPE_ID"]) == 2)
            {
                lblDept.Text = dt.Rows[0]["LOC_VALUE"] + " (Location)";

            }
            else if (Convert.ToInt32(dt.Rows[0]["IND_BY_TYPE_ID"]) == 3)
            {
                lblDept.Text = dt.Rows[0]["DEPT_VALUE"] + " (Departmental)";
            }
            else
            {
                lblDept.Text = dt.Rows[0]["DEPT_VALUE"].ToString();

            }
            lblIndent.Text = dt.Rows[0]["IND_CAL_ID"].ToString();
            lblReceiveAs.Text = dt.Rows[0]["IND_BY_TYPE_VALUE"].ToString();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
    void Initialize()
    {   objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
}
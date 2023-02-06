using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Control_LeaveBalance : System.Web.UI.UserControl
{
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        //int ecode=(HiddenField1.Value!="")?Convert.ToInt32(HiddenField1.Value):;
        //int year = (HiddenField2.Value != "") ? Convert.ToInt32(HiddenField2.Value) : DateTime.Now.Year;
        show(Session["UserId"].ToString(), DateTime.Now.Year.ToString());
    }
    public void show(string User_id, string year)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SELECT REPLACE(LV_TYPE_INF.LV_VALUE, 'Leave', '') AS LV_VALUE, EMP_LV_BAL_INF.CURRENT_BAL, EMP_LV_BAL_INF.LAPSED_BAL, EMP_LV_BAL_INF.AVAILED_BAL, EMP_LV_BAL_INF.APPLIED_BAL "
            + " FROM  EMP_LV_BAL_INF INNER JOIN LV_TYPE_INF ON EMP_LV_BAL_INF.LV_ID = LV_TYPE_INF.LV_ID WHERE (EMP_LV_BAL_INF.USR_ID = " + User_id + ") AND LV_TYPE_INF.LV_STS=1 AND EMP_LV_BAL_INF.CUR_YEAR = " + year;

        dt = databaseFunctions.GetDataSet(cmd).Tables[0];

        GridView1.DataSource = dt;
        GridView1.DataBind();

    }
}
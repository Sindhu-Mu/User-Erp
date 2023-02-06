using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class Control_QuickLinks : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["QUICKLINK"] ==null)
            {
                DatabaseFunctions databaseFunctions = new DatabaseFunctions();
                SqlCommand command = new SqlCommand("GET_QUICK_LINKS");
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@USR_ID", Session["UserId"].ToString());
                Session["QUICKLINK"] = databaseFunctions.GetDataSet(command);

            }
        }
        if (Session["QUICKLINK"].ToString() != "")
        {
            RptQuickLinks.DataSource = ((DataSet)Session["QUICKLINK"]).Tables[0];
            RptQuickLinks.DataBind();
        }

    }

}
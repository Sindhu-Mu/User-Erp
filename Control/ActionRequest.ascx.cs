using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Control_ActionRequest : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ActnRqrdLinks.Visible = false;
            if (Session["QUICKLINK"].ToString() != "")
            {
                //DatabaseFunctions databaseFunctions = new DatabaseFunctions();
                //SqlCommand command = new SqlCommand("GET_ACTION_RQRD");
                //command.CommandType = CommandType.StoredProcedure;
                //command.Parameters.AddWithValue("@USR_ID", Session["UserId"].ToString());
                //ActnRqrdLinks.DataSource = databaseFunctions.GetDataSet(command).Tables[0];
                if (((DataSet)Session["QUICKLINK"]).Tables.Count > 1)
                {
                    DataTable dt=((DataSet)Session["QUICKLINK"]).Tables[1];
                    if (dt.Rows.Count > 0)
                    {
                        ActnRqrdLinks.DataSource = dt;
                        ActnRqrdLinks.DataBind();
                        ActnRqrdLinks.Visible = true;
                    }
                }

            }
        }
    }
}
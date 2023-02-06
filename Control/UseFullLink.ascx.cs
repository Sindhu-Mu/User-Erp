using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Control_UseFullLink : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            RptUserFullLinks.Visible = false;
            if (Session["QUICKLINK"].ToString() != "")
            {
                
                if (((DataSet)Session["QUICKLINK"]).Tables.Count > 2)
                {
                    DataTable dt = ((DataSet)Session["QUICKLINK"]).Tables[2];
                    if (dt.Rows.Count > 0)
                    {
                        RptUserFullLinks.DataSource = dt;
                        RptUserFullLinks.DataBind();
                        RptUserFullLinks.Visible = true;
                    }
                }

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_iqaclink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"].ToString() != "")
        {
            string userid = Session["LoginId"].ToString();
            String host = Request.Url.Host.ToString();
            String url = "http://" + host + "/iqacportal/admin/login.aspx";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('" + url + "','_top','alwaysRaised')", true);
        }
    }
}
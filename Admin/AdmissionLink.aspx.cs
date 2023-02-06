using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_AdmissionLink : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            String host = Request.Url.Host.ToString();
            String url = "http://" + host + "/admissionportal/login.aspx";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('" + url + "','_top','alwaysRaised')", true);
        
    }
}
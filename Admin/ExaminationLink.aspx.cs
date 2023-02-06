using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ExaminationLink : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"].ToString() != "")
        {
            string userid = Session["UserId"].ToString();
            String host=Request.Url.Host.ToString();
            String url = "http://" + host + "/ExaminationPortal/Common/EmployeeLink.aspx?" + userid;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('"+url+"','_top','alwaysRaised')", true);
        }
    }
}
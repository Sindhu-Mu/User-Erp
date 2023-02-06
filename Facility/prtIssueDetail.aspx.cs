using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facility_prtIssueDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = (DataTable)Session["dt"];
        gvIssueDetail.DataSource = dt;
        gvIssueDetail.DataBind();
    }
}
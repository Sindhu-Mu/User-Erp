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

public partial class control_maritalStatus : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int SelectedIndex
    {
        set
        {

            ddlMaritalStatus.SelectedIndex = value;
        }
        get
        {
            return ddlMaritalStatus.SelectedIndex;
        }
    }

    public string SelectedValue
    {
        get
        {
            return ddlMaritalStatus.SelectedValue;
        }
    }
    public string SelectedItem
    {
        get
        {
            return ddlMaritalStatus.SelectedItem.Text.ToString();
        }
    }
}

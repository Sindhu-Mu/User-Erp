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

public partial class control_bollean : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public int SelectedIndex
    {
        set
        {

            ddlBoolean.SelectedIndex = value;
        }
        get
        {
            return ddlBoolean.SelectedIndex;
        }
    }

    public string SelectedValue
    {
        get
        {
            return ddlBoolean.SelectedValue;
        }
    }
    public string SelectedItem
    {
        get
        {
            return ddlBoolean.SelectedItem.Text.ToString();
        }
    }
}

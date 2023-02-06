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

public partial class control_ddlNationality : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public int SelectedIndex
    {
        set
        {
            ddlNationalty.SelectedIndex = value;
        }
        get
        {
            return ddlNationalty.SelectedIndex;
        }
    }

    public string SelectedValue
    {
        get
        {
            return ddlNationalty.SelectedValue;
        }
    }
    public string SelectedItem
    {
        get
        {
            return ddlNationalty.SelectedItem.Text.ToString();
        }
    }
}

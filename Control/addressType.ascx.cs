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
using System.ComponentModel;

public partial class control_ddladdressType : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    public bool Enabled
    {
        set
        {
            ddladdressType.Enabled = value;
        }
        get
        {
            return ddladdressType.Enabled;
        }
    }
    public int SelectedIndex
    {
        set
        {
            ddladdressType.SelectedIndex = value;
        }
        get
        {
            return ddladdressType.SelectedIndex;
        }
    }

    public string SelectedValue
    {
        get
        {
            return ddladdressType.SelectedValue;
        }
    }
    public string SelectedItem
    {
        get
        {
            return ddladdressType.SelectedItem.Text.ToString();
        }
    }
}

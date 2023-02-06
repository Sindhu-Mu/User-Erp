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

public partial class control_ddlJobType : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }


    public int SelectedIndex
    {
        set
        {
            ddlJobType.SelectedIndex = value;
        }
        get
        {
            return ddlJobType.SelectedIndex;
        }
    }

    public string SelectedValue
    {
        get
        {
            return ddlJobType.SelectedValue;
        }
    }
    public string SelectedItem
    {
        get
        {
            return ddlJobType.SelectedItem.Text.ToString();
        }
    }
}

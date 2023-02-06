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

public partial class DatePicker : System.Web.UI.UserControl
{
    Global global;

    void Initialize()
    {
        global = new Global();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }

    public string getDate
    {
        get
        {
            return global.GetDateTime(txtDate.Text);
        }
    }


    public string getDateSql
    {
        get
        {
            return txtDate.Text;
        }
    }
    public string getToDateSql
    {
        get
        {
            return global.GetToDate(txtDate.Text);
        }
    }
}

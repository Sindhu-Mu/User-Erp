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

public partial class control_percentage : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PushData();
        }
    }
    void PushData()
    {
        FillFunctions fillFunctions = new FillFunctions();
        fillFunctions.FillInteger(1, 100, 1, FillFunctions.FirstItem.Select, ddlPercentageBef);
        fillFunctions.FillInteger(0, 99, 1, FillFunctions.FirstItem.Select, ddlPercentageAft);
    }
    public bool HasPercentage
    {
        get
        {
            if (ddlPercentageAft.SelectedIndex > 0 && ddlPercentageBef.SelectedIndex > 0)
                return true;
            return false;
        }
    }
    public string GetPercentage
    {
        get
        {
            return ddlPercentageBef.SelectedValue + "." + ddlPercentageAft.SelectedValue;
        }
    }


}

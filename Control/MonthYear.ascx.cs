using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_MonthYear : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillFunctions fill = new FillFunctions();
            fill.FillYear(DateTime.Now.Year - 7, DateTime.Now.Year , 1, FillFunctions.FirstItem.Select, ddlYear);
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString("D2");
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();          
        }

    }
}
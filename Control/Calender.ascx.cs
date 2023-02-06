using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Control_Calender : System.Web.UI.UserControl
{
    bool IIndSat;
    DateTime firstDate, lastDate;
    SqlDataReader sdr;
    SqlCommand cmd;
    int intSat;
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        cmd = new SqlCommand();
        Calendar1.VisibleDate = DateTime.Today;
        ShowHoliday(new DateTime(Calendar1.VisibleDate.Year, Calendar1.VisibleDate.Month, 1));
    }
   
    protected void ShowHoliday(DateTime FirstDate)
    {
        IIndSat = true;
        firstDate = FirstDate;
        Calendar1.VisibleDate = firstDate;
        Calendar1.SelectedDates.Clear();
        lastDate = GetFirstDayOfNextMonth(firstDate);
        cmd.CommandText = "SELECT [HOLIDAY_DT],[HOLIDAY_NAME] FROM HOLIDAYS_INF  WHERE HOLIDAY_STS=1 AND [HOLIDAY_DT]   BETWEEN '" + firstDate.ToString("MM/dd/yyyy") + "' AND '" + lastDate.ToString("MM/dd/yyyy") + "'";
        sdr = databaseFunctions.GetReader(cmd);
        while (sdr.Read())
        {
            DateTime d = Convert.ToDateTime(sdr["HOLIDAY_DT"]);
            Calendar1.SelectedDates.Add(new DateTime(d.Year, d.Month, d.Day));
        }
        sdr.Close();
    }
    protected DateTime GetFirstDayOfNextMonth(DateTime date)
    {
        int monthNumber, yearNumber;
        if (date.Month == 12)
        {
            monthNumber = 1;
            yearNumber = date.Year + 1;
        }
        else
        {
            monthNumber = date.Month + 1;
            yearNumber = date.Year;
        }
        DateTime lastDate = new DateTime(yearNumber, monthNumber, 1);
        return lastDate;
    }
    protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
    {
        ShowHoliday(new DateTime(Calendar1.VisibleDate.Year, Calendar1.VisibleDate.Month, 1));
    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date >= firstDate && e.Day.Date < lastDate)
        {
            if (e.Day.Date.DayOfWeek.ToString().ToUpper() == "SUNDAY")
            {
                e.Cell.BackColor = System.Drawing.Color.Pink;
                e.Cell.ToolTip = "Sunday";
            }
            if (e.Day.Date.DayOfWeek.ToString().ToUpper() == "SATURDAY")
                intSat++;
            if (intSat == 2 && IIndSat)
            {
                IIndSat = false;
                e.Cell.BackColor = System.Drawing.Color.Pink;
                e.Cell.ToolTip = "Second Saturday";
            }
            if (e.Day.IsSelected)
            {
                cmd.CommandText = "SELECT HOLIDAY_NAME FROM [HOLIDAYS_INF] WHERE HOLIDAY_STS=1 AND HOLIDAY_DT='" + e.Day.Date.ToString("MM/dd/yyyy") + "'";
                sdr = databaseFunctions.GetReader(cmd);
                while (sdr.Read())
                {
                    e.Cell.ToolTip = sdr["HOLIDAY_NAME"].ToString();
                    e.Cell.BackColor = System.Drawing.Color.LightBlue;
                }
            }
        }
    }
}

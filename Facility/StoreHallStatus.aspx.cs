using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Facility_StoreHallStatus : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String str2, strname;
    DataTable Dt;
    StringBuilder StrBldr;
    DateTime strdate;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnshow.Attributes.Add("OnClick", "return ValidateHall()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlBookedHall, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HallCmplx), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        Dt = new DataTable();
        StrBldr = new StringBuilder();
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        showdeatil();
    }
    private void showdeatil()
    {
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        SqlDataReader dr;
        int year = Convert.ToInt32(ddlYY.SelectedValue);
        int month = Convert.ToInt32(ddlMM.SelectedValue);
        int TotalDay = System.DateTime.DaysInMonth(year, month);

        str2 = "<table cellspacing=1 cellpadding=0 border=1  bordercolor=Black bgcolor='White'  style=font-family:Verdana;font-size:10pt; ><tr class=heading style=background-color:#336666>";
        str2 += "<th style=color:White>DATE</th><th style=color:White>DAY</th><th style=color:White>EVENT DETAIL</th></tr>";
        for (int n = 0; n < TotalDay; )
        {
            strname = "&nbsp;";
            n++;
            strdate = Convert.ToDateTime(n + "-" + ddlMM.SelectedItem + "-" + year);
            ObjFacBal.Date = strdate;
            dr = ObjFacBll.GetHolidays(ObjFacBal);
            if (dr.HasRows)
            {
                dr.Read();
                str2 += "<tr style=background-color:#FF8080 title='" + dr["HOLIDAY_NAME"].ToString() + "'>";
            }
            else if (strdate.DayOfWeek == DayOfWeek.Sunday)
                str2 += "<tr style=background-color:#FFFF80 title='Sunday'>";
            else if (strdate.DayOfWeek == DayOfWeek.Saturday && strdate.Day > 7 && strdate.Day < 15)
                str2 += "<tr style=background-color:#FFFF80 title='Second Saturday'>";
            else
                str2 += "<tr>";

             ObjFacBal.FromDate = strdate;
            ObjFacBal.No = ddlMM.SelectedValue;
            ObjFacBal.RateDay = ddlYY.SelectedValue;
            ObjFacBal.TypeId = ddlBookedHall.SelectedValue;
            DataSet ds = ObjFacBll.GetHallSts(ObjFacBal);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string arg = "\"rptHallBooking.aspx?=" + dt.Rows[i]["HALL_REQ_ID"].ToString() + "\",\"_blank\",\"width=700, height=450,left=150,top=200, scrollbars=1\"";
                strname += "<a href='#' onclick='javascript:window.open(" + arg + ")'>" + dt.Rows[i]["DEPT_VALUE"].ToString() + "TIME:-" + dt.Rows[i]["BOOKINGON"].ToString() + "(" + dt.Rows[i]["STS_VALUE"].ToString() + ")</a><br/>";
            }
            str2 += "<td >" + strdate.ToString("dd-MMM-yyyy") + "</td><td align='center'>" + strdate.DayOfWeek.ToString() + "</td><td><b>" + strname + "</b></td></tr>";

        }

        str2 += "</table>";
        StrBldr.Append(str2);
        tdMain.InnerHtml = StrBldr.ToString();
    }
}
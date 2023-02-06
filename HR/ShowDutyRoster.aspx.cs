using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class HR_ShowDutyRoster : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    HRBAL ObjHrBAL;
    HRBLL ObjHrBll;
    DataSet ds;
    DateTime date;
    SqlDataReader dr;
    DateTime strdate;
    DataTable dTable;
    StringBuilder strBldr;
    string  strname = "";
    void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
        dTable = new DataTable();
        strBldr = new StringBuilder();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
            DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
            if (Request.QueryString.Count > 0)
            {
                date = Convert.ToDateTime(Request.QueryString[0]);
                ddlMM.SelectedValue = date.Month.ToString();
                ddlYear.SelectedValue = date.Year.ToString();
            }
            else
            {
                ddlMM.SelectedValue = System.DateTime.Now.Month.ToString();
                ddlYear.SelectedValue = System.DateTime.Now.Year.ToString();
            }
            fillfunctions.Fill(ddlinstitution, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void ddlinstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlinstitution.SelectedIndex > 0)
        {
            fillfunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlinstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
        {
            ViewState["Dept"] = ddlDept.SelectedValue;
            fnexit();
        }
    }


    void fnexit()
    {
        try
        {

            date = Convert.ToDateTime(Request.QueryString[0]);
            ObjHrBAL.DeptId = ddlDept.SelectedValue;
            ObjHrBAL.Max = date.Month.ToString();
            ObjHrBAL.TypeId = "1";
            ds = ObjHrBll.getDeptEmpList(ObjHrBAL);
            GridShow.DataSource = ds.Tables[0];
            GridShow.DataBind();
            gvShift.DataSource = ObjHrBll.getShift();
            gvShift.DataBind();
            strBldr.Append(" <table cellspacing=0 border=1><tr style=background-color:#0c9007;color:White><th style='color:White'>Name</th>");
            int n = System.DateTime.DaysInMonth(date.Year, date.Month);
            int i = 0;
            while (i++ < n)
            {
                if (i < 10)
                    strBldr.Append("<th style='background-color:#468b3c;color:White'>0" + i + "</th>");
                else
                     strBldr.Append("<th style='background-color:#468b3c;color:White'>" + i + "</th>");
            }
            strBldr.Append("</tr>");
            for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
            {
                strBldr.Append("<tr><td style='text-align:left;background-color:#468b3c;color:White' nowrap>" + ds.Tables[0].Rows[c]["EMP_NAME"].ToString() + "</td>");
                for (int dd = 1; dd <= n; dd++)
                {
                    if (dd == 13)
                    {
                    }
                    strdate = Convert.ToDateTime(date.Month + "/" + dd + "/" + date.Year);
                    ObjHrBAL.Date = strdate;
                    ObjHrBAL.EmpId = ds.Tables[0].Rows[c]["EMP_ID"].ToString();
                    dr = ObjHrBll.DutyRosterSelect(ObjHrBAL);
                    int LeaveCount = Convert.ToInt32(ObjHrBll.getLvCnt(ObjHrBAL).Tables[0].Rows[0][0].ToString());
                    strname = "-";
                    if (dr.Read())
                    {
                        strname = (dr[5].ToString() == "0") ? "O" : dr[5].ToString();
                    }
                    dr.Close();
                    // Check for Holiday
                    bool bHoliday = false;
                    string strHolidayName = "";
                    //ObjHrBAL.Date = common.GetDateTime(strdate.ToString());
                    dr = ObjHrBll.getHolidays(ObjHrBAL);
                    if (dr.Read())
                    {
                        bHoliday = true;
                        strHolidayName = dr["HOLIDAY_NAME"].ToString();
                    }
                    // End Holiday
                    strBldr.Append("<td");
                    if (strdate.DayOfWeek == DayOfWeek.Sunday)
                        strBldr.Append(" style='background-color:#FF8' title='Sunday'>");
                    else if (strdate.DayOfWeek == DayOfWeek.Saturday && strdate.Day > 7 && strdate.Day < 15)
                        strBldr.Append(" style='background-color:#FF8' title='Second Saturday'>");
                    else if (bHoliday)
                        strBldr.Append(" style='background-color:#ffa07a' title='" + strHolidayName + "'>");
                    else if (LeaveCount > 0)
                        strBldr.Append(" style='background-color:#fcf' title='Leave'>");
                    else
                        strBldr.Append(">");
                    strBldr.Append(strname + "</td>");
                }
                strBldr.Append("</tr>");
            }

            strBldr.Append("</table>");
            tdMain.InnerHtml = strBldr.ToString();
            
        }
        catch
        {
            
        }
    }
}
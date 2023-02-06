using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
public partial class HR_DutyRoaster : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    //DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    string strname = "";
    DateTime strdate;
    StringBuilder strBldr3;
    DataSet ds;
    SqlDataReader dr;
    DataTable dtt;
    DatabaseFunctions databaseFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            dtt = ObjHrBll.getDept(ObjHrBAL);
            ViewState["Dept"] = dtt.Rows[0][0].ToString();
            ViewState["HOD"] = dtt.Rows[0][1].ToString();
           
        }
    }
    
    private void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        strBldr3 = new StringBuilder();
        ds = new DataSet();
        dtt = new DataTable();
        databaseFunctions = new DatabaseFunctions();
    }
    void Fill()
    {
    
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
        ObjHrBAL.Max = ddlMM.SelectedValue;
        ObjHrBAL.DeptId = ViewState["Dept"].ToString();
        ObjHrBAL.TypeId = "1";
        gvShow.DataSource = ObjHrBll.getDeptEmpList(ObjHrBAL);
        gvShow.DataBind();
    }
    void DetailShow()
    {
        DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ArrayList ar = new ArrayList();
        int year = Convert.ToInt32((ddlYY.SelectedValue == "") ? DateTime.Now.Year.ToString() : ddlYY.SelectedValue);
        int month = Convert.ToInt32(ddlMM.SelectedValue);
        ObjHrBAL.DeptId = ViewState["Dept"].ToString(); 
        dtt = ObjHrBll.getDeptShift(ObjHrBAL).Tables[0];
        if (dtt.Rows.Count > 0)
        {
            ViewState["Dept"] = dtt.Rows[0]["DEPT_ID"].ToString();
        }
        int TotalDay = System.DateTime.DaysInMonth(year, month);
        strBldr3.Append("<table cellspacing=1 cellpadding=0 border=1 Class=lbl bordercolor=Black bgcolor=White ><tr class=heading style=background-color:#468b3c><th style=color:White>Date</th>");
        for (int sh = 0; sh < dtt.Rows.Count; sh++)
            strBldr3.Append("<th style=color:White>" + dtt.Rows[sh]["TIMING"].ToString() + "</th>");
        for (int n = 0; n < TotalDay; )
        {

            n++;
            strdate = Convert.ToDateTime(ddlMM.SelectedItem+"/"+n+"/" + year);
            ObjHrBAL.Date = strdate;
            dr = ObjHrBll.getHolidays(ObjHrBAL);
            if (dr.HasRows)
            {
                dr.Read();
                strBldr3.Append("<tr style=background-color:#FF8080 title='" + dr["HOLIDAY_NAME"].ToString() + "'>");
            }
            else if (strdate.DayOfWeek == DayOfWeek.Sunday)
                strBldr3.Append("<tr style=background-color:#FFFF80 title='Sunday'>");
            else if (strdate.DayOfWeek == DayOfWeek.Saturday && strdate.Day > 7 && strdate.Day < 15)
                strBldr3.Append("<tr style=background-color:#FFFF80 title='Second Saturday'>");
            else
                strBldr3.Append("<tr>");
            strBldr3.Append("<td align=right style=color:White;background-color:#468b3c Class=heading>" + n + "</td>");
            try
            {
                for (int j = 0; j < dtt.Rows.Count; j++)
                {
                    if (strdate.Day == 13)
                    { 
                    
                    }
                    strBldr3.Append("<td>");
                    if (strdate >= System.DateTime.Now)
                    {
                        string arg = "\"entry_Duty.aspx?0;" + strdate.ToString("dd/MM/yyyy") + ";" + dtt.Rows[j]["SHIFT_ID"] + ";" + ViewState["Dept"] + "\",\"_blank\",\"width=1000, height=450,left=250,top=200, scrollbars=1\"";
                        strBldr3.Append("[<a href='#' onclick='javascript:window.open(" + arg + ")' style='font-family:Verdana;font-size:10pt'>Add</a>]<br/>");
                    }
                    else
                        strBldr3.Append("&nbsp");

                    //ObjHrBAL.Date =strdate;
                    ObjHrBAL.KeyID = dtt.Rows[j]["SHIFT_ID"].ToString();
                    ObjHrBAL.DeptId = ViewState["Dept"].ToString(); 
                    ds = ObjHrBll.getDutyRosterDetails(ObjHrBAL);
                    strname = "";
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ViewState["DUTY_ID"] = ds.Tables[0].Rows[0][2].ToString();
                        if (!ar.Contains(ds.Tables[0].Rows[0][2].ToString()))
                            ar.Add(ds.Tables[0].Rows[0][2].ToString());
                        for (int g = 0; g < ds.Tables[0].Rows.Count; g++)
                            strname += ds.Tables[0].Rows[g]["EMP_NAME"].ToString() + "<br/>";
                        strBldr3.Append("" + strname + "");
                        if (strdate >= System.DateTime.Now)
                        {
                            string arg = "\"entry_Duty.aspx?0;" + strdate.ToString("dd/MM/yyyy") + ";" + dtt.Rows[j]["SHIFT_ID"] + ";" + ViewState["Dept"] + "\",\"_blank\",\"width=1000, height=450,left=250,top=200, scrollbars=1\"";
                            strBldr3.Append("[<a href='#' onclick='javascript:window.open(" + arg + ")' style='font-family:Verdana;font-size:10pt'>Remove</a>]<br/>");
                        }
                    }
                    strBldr3.Append("</td>");
                }

                strBldr3.Append("</tr>");
            }
            catch { }
        }

        strBldr3.Append("</table>"); 
        tdMain.InnerHtml = strBldr3.ToString();
        ViewState["AR"] = ar;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ViewState["HOD"].ToString() == "1")
        {
            lnk1.Visible = false;
            lnk2.Visible = true;
        }
        else if (ViewState["HOD"].ToString() == "0")
        {
            lnk1.Visible = true;
            lnk2.Visible = false;
        }
        Fill();
        DetailShow();
    }
    protected void lnk1_Click(object sender, EventArgs e)
    {
        ObjHrBAL.KeyID = ViewState["DUTY_ID"].ToString();
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        string msg = ObjHrBll.DutyRosterApply(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        Fill();
        DetailShow();
    }
    protected void lnk2_Click(object sender, EventArgs e)
    {
        if (ViewState["DUTY_ID"].ToString() != "")
        {
            ArrayList ar = new ArrayList();
            ar = (ArrayList)ViewState["AR"];
            string duty_list = "";
            for (int i = 0; i < ar.Count; i++)
            {
                duty_list += ar[i].ToString() + ",";
            }
            if (duty_list != "")
            {
                duty_list = duty_list.Remove(duty_list.Length - 1, 1);
            }
         }
        DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
        string date = common.GetDateTime(ddlMM.SelectedItem+"/"+1+"/" + ddlYY.SelectedItem).ToString();
        ObjHrBAL.KeyID = ViewState["DUTY_ID"].ToString();
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        string msg = ObjHrBll.DutyRosterApprove(ObjHrBAL);
        Fill();
        DetailShow();
        lnk1.Visible = false;
        lnk2.Visible = false;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "CheckSessionOut", "window.open('ShowDutyRoster.aspx?=" + date + "',alwaysraised='yes')", true);
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        
    }
}
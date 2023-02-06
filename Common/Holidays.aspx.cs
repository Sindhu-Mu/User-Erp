using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Common_Holidays : System.Web.UI.Page
{
    DatabaseFunctions databasefunctions;
    FillFunctions fillfunction = new FillFunctions();
    QueryFunctions queryfunction;
    CommonFunctions common;
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        databasefunctions = new DatabaseFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillfunction.Fill(ddlIns, queryfunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillfunction.FillYear(2010, DateTime.Now.Year, 1, FillFunctions.FirstItem.All, ddlHolidayYear);
            BindHolidayGridView();            
        }
    }
    protected void BindHolidayGridView()
    
    {
        string Year=(ddlHolidayYear.SelectedIndex==0)?DateTime.Now.Year.ToString():ddlHolidayYear.SelectedValue;
        string strSql = "SELECT HOLIDAY_DT, DATENAME(dw,HOLIDAY_DT) as DayName, HOLIDAY_NAME,"
          + " DAY_TYPE_NAME, CASE WHEN HOLIDAY_TYPE=1 THEN 'Normal' ELSE 'Restricted' END as 'TYPE' ,FORE=CASE WHEN MONTH(GETDATE())=MONTH(HOLIDAY_DT) THEN 'System.Drawing.Color.Blue' ELSE 'System.Drawing.Color.Transparent' END,"
          + " BACK=CASE WHEN MONTH(GETDATE())=MONTH(HOLIDAY_DT) THEN 'System.Drawing.Color.Pink' ELSE 'System.Drawing.Color.Transparent' END"
          + " FROM HOLIDAYS_INF HD INNER JOIN DAY_TYPE_INF DP ON DP.DAY_TYPE_ID=HD.DAY_TYPE_ID  LEFT OUTER JOIN UNIV_INS_INF ON INSTITUTE=INS_ID WHERE YEAR(HOLIDAY_DT)=" + Year;
        if (ddlIns.SelectedIndex > 0)
            strSql += " AND INSTITUTE IN ('" + ddlIns.SelectedValue + "','0')";
        strSql += " ORDER BY HOLIDAY_DT";
        gvHoliday.DataSource = databasefunctions.GetDataSetByQuery(strSql).Tables[0];
        gvHoliday.DataBind();
        foreach (GridViewRow itm in gvHoliday.Rows)
        {
         
            DateTime Hdate =common.GetDateTime(itm.Cells[1].Text);
            if ((Hdate.Month == DateTime.Now.Month) && (Hdate.Year.ToString() ==Year))
            {
                itm.ForeColor = System.Drawing.Color.Blue;
                itm.BackColor = System.Drawing.Color.Pink;
            }
        }
    }
    protected void ddlHolidayYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHolidayGridView();
       
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindHolidayGridView();
       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class HR_rptSubmittedSalery : System.Web.UI.Page
{
    HRBLL hrbll = null;
    DataTable dt = null;
    DataSet ds = null;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunction;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        page_div_block.Visible = false;
        hrbll = new HRBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions=new CommonFunctions();
        databaseFunction = new DatabaseFunctions();
        ScriptManager.GetCurrent(this).AsyncPostBackTimeout =0;
        if (!IsPostBack)
        {
          // AddKeepAlive();
            fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        }
    }
    protected String GetDropDownAll(String val)
    {
        String a ="0";
        if (val == ".")
        {
            a ="0";
        }
        else
        {
            a = val;
        }
        return a;
    }
   
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitution.SelectedValue), true,FillFunctions.FirstItem.Select);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        string str = "";

        if (ddlInstitution.SelectedIndex > 0)
            str += " AND INS_ID='" + ddlInstitution.SelectedValue + "'";
        if (ddlDepartment.SelectedIndex > 0)
            str += " AND DEPT_ID='" + ddlDepartment.SelectedValue + "'";
        if (ddlCodeType.SelectedIndex > 0 && ddlCodeType.SelectedValue!="2")
            str += " AND JOB_TYPE_ID='" + ddlCodeType.SelectedValue + "'";
        if (ddlSubmittedStatus.SelectedIndex == 1)
            str += " AND ATT_SUB_ID IS NOT NULL ";
        if (ddlSubmittedStatus.SelectedIndex == 2)
            str += " AND ATT_SUB_ID IS NULL ";
        if (txtClosingDate.Text != "")
            str += " AND CONVERT(VARCHAR,ATT_TRAN_DT,103)='" + txtClosingDate.Text + "'";
        string query = "SELECT EMP_VIEW.USR_ID,EMP_VIEW.EMP_ID, EMP_VIEW.EMP_NAME, EMP_VIEW.JOB_TYPE_VALUE, EMP_VIEW.DEPT_VALUE,EMP_VIEW.INI_VALUE, " +
                        "SUM(EMP_MONTHLY_ATT_TRAN_INF.ATT_TRAN_NOD) AS NOD,EMP_MONTHLY_ATT_MAIN_INF.ATT_MONTH, " +
                         "EMP_MONTHLY_ATT_MAIN_INF.ATT_YEAR, EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID, EMP_VIEW.DES_VALUE FROM " +
                        "EMP_MONTHLY_ATT_TRAN_INF INNER JOIN EMP_MONTHLY_ATT_MAIN_INF ON EMP_MONTHLY_ATT_TRAN_INF.MNTH_ATT_ID = EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID " +
                         " INNER JOIN EMP_VIEW ON EMP_MONTHLY_ATT_MAIN_INF.USR_ID = EMP_VIEW.USR_ID " +
                        "WHERE(EMP_MONTHLY_ATT_MAIN_INF.ATT_MONTH =" + (Convert.ToInt32(ddlMonth.SelectedValue)) + ") AND (EMP_MONTHLY_ATT_MAIN_INF.ATT_YEAR = " + (Convert.ToInt32(ddlYear.SelectedValue)) + ")" +
                         " AND MNTH_STATUS=" + ddlStatus.SelectedValue + str +
                        " GROUP BY EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID," +
                        " EMP_VIEW.EMP_ID, EMP_VIEW.EMP_NAME, EMP_VIEW.JOB_TYPE_VALUE, EMP_VIEW.DEPT_VALUE,EMP_VIEW.INI_VALUE," +
                        " EMP_MONTHLY_ATT_MAIN_INF.ATT_MONTH," +
                        " EMP_MONTHLY_ATT_MAIN_INF.ATT_YEAR,EMP_VIEW.DES_VALUE,EMP_VIEW.USR_ID ORDER BY EMP_VIEW.EMP_ID"; 
        SqlCommand query_1 = new SqlCommand();
        query_1.CommandText = query;
        ds = databaseFunction.GetDataSet(query_1);
        Session["ds"] = ds;
        gridView.DataSource = ds;
        gridView.DataBind();
    }


    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMonthAttedance.aspx',alwaysraised='yes')", true);

    }
    protected void btnExport1_Click(object sender, EventArgs e)
    {
        ds = (DataSet)Session["ds"];
        GridViewExportUtil.ExportFromDs("AttendanceDetail.xls", ds);
    }
    protected void viewDetail(String emp_code)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        string str = "";

        if (ddlInstitution.SelectedIndex > 0)
            str += " AND INS_ID='" + ddlInstitution.SelectedValue + "'";
        if (ddlDepartment.SelectedIndex > 0)
            str += " AND DEPT_ID='" + ddlDepartment.SelectedValue + "'";
        if (ddlCodeType.SelectedIndex > 0)
            str += " AND JOB_TYPE_ID='" + ddlCodeType.SelectedValue + "'";
        if (ddlSubmittedStatus.SelectedIndex == 1)
            str += " AND ATT_SUB_ID IS NOT NULL ";
        if (ddlSubmittedStatus.SelectedIndex == 2)
            str += " AND ATT_SUB_ID IS NULL ";
        if (txtClosingDate.Text != "")
            str += " AND CONVERT(VARCHAR,ATT_TRAN_DT,103)='" + txtClosingDate.Text + "'";
        string query = " SELECT EMP_VIEW.EMP_ID,HRD_ATTENDANCE_SUBMIT.Insert_date,EMP_VIEW.EMP_NAME, EMP_VIEW.JOB_TYPE_VALUE,"+ 
                        " EMP_VIEW.DEPT_VALUE,EMP_VIEW.INS_VALUE,EMP_MONTHLY_ATT_TRAN_INF.ATT_SUB_ID," +
                        " EMP_MONTHLY_ATT_TRAN_INF.ATT_TRAN_DT, SUM(EMP_MONTHLY_ATT_TRAN_INF.ATT_TRAN_NOD) AS NOD,"+
                         "  EMP_MONTHLY_ATT_MAIN_INF.ATT_MONTH, EMP_MONTHLY_ATT_MAIN_INF.ATT_YEAR," +
                        " EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID, EMP_VIEW.DES_VALUE FROM EMP_MONTHLY_ATT_TRAN_INF"+ 
                        " INNER JOIN EMP_MONTHLY_ATT_MAIN_INF ON EMP_MONTHLY_ATT_TRAN_INF.MNTH_ATT_ID = EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID"+
                        " INNER JOIN EMP_VIEW ON EMP_MONTHLY_ATT_MAIN_INF.USR_ID = EMP_VIEW.USR_ID LEFT OUTER JOIN HRD_ATTENDANCE_SUBMIT ON" + 
                        " HRD_ATTENDANCE_SUBMIT.id=EMP_MONTHLY_ATT_TRAN_INF.ATT_SUB_ID  " +
                        " WHERE(EMP_MONTHLY_ATT_MAIN_INF.ATT_MONTH =" + (Convert.ToInt32(ddlMonth.SelectedValue)) + ") AND (EMP_MONTHLY_ATT_MAIN_INF.ATT_YEAR =" + (Convert.ToInt32(ddlYear.SelectedValue)) + ")" +
                         "AND  EMP_VIEW.USR_ID=" + emp_code + "  AND MNTH_STATUS=" + ddlStatus.SelectedValue + str +
                        "GROUP BY"+
                        " HRD_ATTENDANCE_SUBMIT.Insert_date, EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID,"+
                        " EMP_VIEW.EMP_ID, EMP_VIEW.EMP_NAME, EMP_VIEW.JOB_TYPE_VALUE, EMP_VIEW.DEPT_VALUE,EMP_VIEW.INS_VALUE,EMP_MONTHLY_ATT_TRAN_INF.ATT_SUB_ID,"+
                        " EMP_MONTHLY_ATT_TRAN_INF.ATT_TRAN_DT, EMP_MONTHLY_ATT_TRAN_INF.ATT_TRAN_NOD, EMP_MONTHLY_ATT_MAIN_INF.ATT_MONTH, EMP_MONTHLY_ATT_MAIN_INF.ATT_YEAR,"+ 
                        " EMP_MONTHLY_ATT_MAIN_INF.MNTH_ATT_ID,EMP_VIEW.DES_VALUE ORDER BY EMP_VIEW.EMP_ID";
        SqlCommand query_1 = new SqlCommand();
        query_1.CommandText = query;
        ds = databaseFunction.GetDataSet(query_1);
        Session["ds"] = ds;
        gridView1.DataSource = ds;
        gridView1.DataBind();
        page_div_block.Visible = true;


    }
    protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string emp_code = gridView.DataKeys[Convert.ToInt16(e.CommandArgument)].Value.ToString();
        viewDetail(emp_code);
    }
    protected void close_window(object sender, EventArgs e)
    {
        page_div_block.Visible = false;
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;
public partial class HR_prtEmpLvDetail : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    SqlCommand cmd;
    HRBAL ObjHrBAL = new HRBAL();
    HRBLL ObjHrBll = new HRBLL();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            if (Request.QueryString.Count > 0)
            {
                cmd = new SqlCommand("SELECT INI_VALUE, EMP_NAME FROM EMP_VIEW WHERE EMP_ID=" + Request.QueryString[0].ToString() + "");
                cmd.CommandType = CommandType.Text;
                ds = databaseFunctions.GetDataSet(cmd);
                ObjHrBAL.EmpId = Request.QueryString[0].ToString();
                ObjHrBAL.Year = Request.QueryString[1].ToString();
                lblInitial.Text = ds.Tables[0].Rows[0][0].ToString();
                lblName.Text = ds.Tables[0].Rows[0][1].ToString();
                lblYear.Text = Request.QueryString[1].ToString();
            }
            ds = ObjHrBll.GetLeaveBalance(ObjHrBAL);
            gvLvBalance.DataSource = ds.Tables[0];
            gvLvBalance.DataBind();
            cmd = new SqlCommand("SELECT EMP_NAME AS NAME,CONVERT(VARCHAR,REQ_DT,103) AS APPLIED_DATE , LV_VALUE AS LEAVE,CONVERT(VARCHAR,FROM_DT,103) AS FROM_DATE, " +
                "CONVERT(VARCHAR,TO_DT,103) AS TO_DATE, TOT_DAYS, DAY_TYPE_NAME AS DAY_TYPE,REASON, STS_VALUE AS STATUS, ACT_BY,CONVERT(VARCHAR, ACT_DT,103) AS ACTION_DATE " +
                "FROM EMP_LV_VIEW WHERE   (EMP_ID = " + Request.QueryString[0].ToString() + ") AND (YEAR(FROM_DT) = " + Request.QueryString[1].ToString() + ") " +
                "AND (ACT_DT IN (SELECT MAX(ACT_DT) AS Expr1 FROM EMP_LV_VIEW AS EMP_LV_VIEW_1 WHERE (EMP_ID = " + Request.QueryString[0].ToString() + ") AND (YEAR(FROM_DT) = " + Request.QueryString[1].ToString() + ") " +
                "GROUP BY LV_APP_ID)) ORDER BY ACT_DT DESC");
            cmd.CommandType = CommandType.Text;
            ds= databaseFunctions.GetDataSet(cmd);
            gvDetail.DataSource = ds.Tables[0];
            gvDetail.DataBind();
            foreach (GridViewRow itm in gvLvBalance.Rows)
            {
                itm.Cells[0].Text = (itm.RowIndex + 1).ToString() + ".";

            }
            foreach (GridViewRow itm in gvDetail.Rows)
            {
                itm.Cells[0].Text = (itm.RowIndex + 1).ToString() + ".";

            }
        }
        catch (Exception ee)
        { ee.Message.ToString(); }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Appraisal_PA03_CountReport : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;

    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PAFacSts), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlSDate":
                if (ddlSDate.SelectedValue == "3")
                {
                    txtSSDt.Enabled = true;
                    txtSEDt.Enabled = true;
                }
                else if (ddlSDate.SelectedValue == "1" || ddlSDate.SelectedValue == "2")
                {
                    txtSSDt.Enabled = true;
                    txtSEDt.Enabled = false;
                }
                else
                {
                    txtSSDt.Enabled = false;
                    txtSEDt.Enabled = false;
                }
                txtSEDt.Text = txtSSDt.Text = "";
                break;
            case "ddlEDate":
                if (ddlEDate.SelectedValue == "3")
                {
                    txtESDt.Enabled = true;
                    txtEEDt.Enabled = true;
                }
                else if (ddlEDate.SelectedValue == "1" || ddlEDate.SelectedValue == "2")
                {
                    txtESDt.Enabled = true;
                    txtEEDt.Enabled = false;
                }
                else
                {
                    txtESDt.Enabled = false;
                    txtEEDt.Enabled = false;
                }
                txtEEDt.Text = txtESDt.Text = "";
                break;


            default:
                break;
        }

    }
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        FillFunction.Fill(gridReportInfo, BuildQuery(true));
        lblCount.Text = gridReportInfo.Rows.Count.ToString();
    }

    SqlCommand BuildQuery(bool addFilter)
    {
        bool can = false;
        StringBuilder query = new StringBuilder();
        query.Append("SELECT PVT_TABLE.[Institution]");
        for (int i = 0; i < chkFeild.Items.Count; i++)
        {
            if (!can)
            {
                if (chkFeild.Items[i].Selected)
                {
                    query.Append(",PVT_TABLE.[" + chkFeild.Items[i].Text+"]");
                    can = true;
                }
            }
            else if (can)
            {
                if (chkFeild.Items[i].Selected)
                    query.Append(",PVT_TABLE.[" + chkFeild.Items[i].Text+"]");
                // query.Append(", '" + chkFeild.Items[i].Text + "' = " + chkFeild.Items[i].Value.ToString());
            }
        }
        query.Append(" ,ISNULL(PVT_TABLE.[Not Started],0) AS [Not Started],ISNULL(PVT_TABLE.[Pending With Self],0) AS [Pending With Self],ISNULL(PVT_TABLE.[Pending With Senior],0) AS [Pending With Senior],ISNULL([Completed],0) as [Completed] FROM ( ");
        can = false;
        query.Append("SELECT ");

        for (int i = 0; i < chkFeild.Items.Count; i++)
        {
            if (!can)
            {
                if (chkFeild.Items[i].Selected)
                {
                    query.Append("'" + chkFeild.Items[i].Text + "' = " + chkFeild.Items[i].Value.ToString());
                    can = true;
                }
            }
            else if (can)
            {
                if (chkFeild.Items[i].Selected)
                    query.Append(", '" + chkFeild.Items[i].Text + "' = " + chkFeild.Items[i].Value.ToString());
            }
        }

        if (can)
            query.Append(",INS_VALUE AS Institution, STATUS AS Status, COUNT (*) AS Count ");
        else
            query.Append(" INS_VALUE AS Institution,STATUS AS Status, COUNT (*) AS Count ");


        can = false;

        query.Append(" FROM (SELECT EMP_VIEW.INS_VALUE, EMP_VIEW.EMP_ID, EMP_VIEW.EMP_NAME, PA03_FAC_INF.PA03_FAC_SEM_TYPE, PA03_FAC_INF.PA03_FAC_YEAR, CONVERT(VARCHAR, EMP_VIEW.DOJ, 103) " +
                     " AS DOJ, EMP_VIEW.DES_VALUE, EMP_VIEW.DEPT_VALUE, PA03_FAC_STATUS_INF.STAT_VALUE AS STATUS, PA03_FAC_STATUS_INF.STAT_ID, " +
                     " PA03_FAC_CMT_INF.PA03_FAC_FAC_DATE_TIME AS SUBMIT_DATE ,EMP_VIEW.INS_ID,EMP_VIEW.DEPT_ID,PA03_RULE_INF.R_FEED_START AS STARTDATE, PA03_RULE_INF.R_FEED_END AS ENDDATE,dbo.GET_APP_PENDING_WITH(PA03_FAC_INF.PA03_FAC_ID) AS PENDING " +
                     " FROM PA03_FAC_INF INNER JOIN  EMP_VIEW ON PA03_FAC_INF.USR_ID = EMP_VIEW.USR_ID " +
                     " INNER JOIN PA03_FAC_STATUS_INF ON PA03_FAC_INF.PA03_FAC_STATUS = PA03_FAC_STATUS_INF.STAT_ID INNER JOIN " +
                     " PA03_RULE_INF ON PA03_FAC_INF.R_ID = PA03_RULE_INF.R_ID LEFT OUTER JOIN " +
                     " PA03_FAC_CMT_INF ON PA03_FAC_INF.PA03_FAC_ID = PA03_FAC_CMT_INF.PA03_FAC_ID "+
                     " WHERE     (EMP_VIEW.EMP_ID > 0) AND (EMP_VIEW.STS_ID = 1) ");
        if (addFilter)
            AddFilter(query);

        //
        query.Append(" ) AS A2 GROUP BY ALL ");

        can = false;
        for (int i = 0; i < chkFeild.Items.Count; i++)
        {
            if (!can)
            {
                if (chkFeild.Items[i].Selected)
                {
                    query.Append(chkFeild.Items[i].Value.ToString());
                    can = true;
                }
            }
            else if (can)
            {
                if (chkFeild.Items[i].Selected)
                    query.Append("," + chkFeild.Items[i].Value.ToString());
            }
        }
        if (can)
            query.Append(", STATUS,INS_VALUE");
        else
            query.Append(" STATUS,INS_VALUE");

        can = false;

        query.Append(" ) AS APP PIVOT (SUM(Count) FOR Status IN ([Not Started],[Pending With Self],[Pending With Senior],[Completed]))AS PVT_TABLE ");

        query.Append(" ORDER BY Institution");
        for (int i = 0; i < chkFeild.Items.Count; i++)
        {
            if (!can)
            {
                if (chkFeild.Items[i].Selected)
                {
                    query.Append(",["+chkFeild.Items[i].Text.ToString()+"]");
                    can = true;
                }
            }
            else if (can)
            {
                if (chkFeild.Items[i].Selected)
                    query.Append(",[" + chkFeild.Items[i].Text.ToString()+"]");
            }
        }
        
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        return command;
    }
    void AddFilter(StringBuilder query)
    {
        if (ddlIns.SelectedIndex > 0)
            query.Append(" AND INS_ID = '" + ddlIns.SelectedValue + "'");
        if (ddlStatus.SelectedIndex > 0)
            query.Append(" AND A1.STAT_ID = '" + ddlStatus.SelectedValue + "'");
        if (ddlDept.SelectedIndex > 0)
            query.Append(" AND DEPT_ID = " + ddlDept.SelectedValue);

        switch (Convert.ToInt32(ddlSDate.SelectedIndex))
        {
            case 1:
                query.Append(" AND R_FEED_START < '" + commonFunctions.GetDateTime(txtSSDt.Text) + "'");
                break;
            case 2:
                query.Append(" AND R_FEED_START > '" + commonFunctions.GetDateTime(txtSSDt.Text) + "'");
                break;
            case 3:
                query.Append(" AND R_FEED_START BETWEEN '" + commonFunctions.GetDateTime(txtSSDt.Text) + "' AND '" + commonFunctions.GetDateTime(txtSEDt.Text) + "'");
                break;
            default:
                break;
        }
        switch (Convert.ToInt32(ddlEDate.SelectedIndex))
        {
            case 1:
                query.Append(" AND R_FEED_END < '" + commonFunctions.GetDateTime(txtESDt.Text) + "'");
                break;
            case 2:
                query.Append(" AND R_FEED_END > '" + commonFunctions.GetDateTime(txtESDt.Text) + "'");
                break;
            case 3:
                query.Append(" AND R_FEED_END BETWEEN '" + commonFunctions.GetDateTime(txtESDt.Text) + "' AND '" + commonFunctions.GetDateTime(txtEEDt.Text) + "'");
                break;
            default:
                break;
        }
    }
}
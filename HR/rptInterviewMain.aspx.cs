using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class HR_rptInterviewMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;
    DatabaseFunctions databaseFunctions;

    public void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
        databaseFunctions = new DatabaseFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();

        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlCrs, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.EmpCrs), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlQual, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Academic), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlExpType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ExpType), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlDes, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntSts), true, FillFunctions.FirstItem.Select);

        }
    }
    protected void ddlCTC_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCTC.SelectedIndex > 0)
            txtCTC.Visible = true;
        else
            txtCTC.Visible = false;
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        }
        else
            ddlDept.Items.Clear();
    }

    protected void ddlIntDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIntDate.SelectedIndex > 0)
            fillFunctions.Fill(ddlIntTime, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntTime, ddlIntDate.SelectedItem.ToString()), true, FillFunctions.FirstItem.Select);
        else
            ddlIntDate.Items.Clear();
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedIndex > 0)
            fillFunctions.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DeptJob, ddlDepartment.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            fillFunctions.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJob.SelectedIndex > 0)
            fillFunctions.Fill(ddlIntDate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobIntDate, ddlJob.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            fillFunctions.Fill(ddlIntDate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntDate), true, FillFunctions.FirstItem.Select);
    }

    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlCrs, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.EmpCrs), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlQual, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Academic), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlExpType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ExpType), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlDes, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntSts), true, FillFunctions.FirstItem.Select);
        }
        else if (step1.ActiveTabIndex == 1)
        {
            fillFunctions.Fill(ddlIntDate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntDate), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlIntMode, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntMode), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSts, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntSts), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void btnExecute_Click(object sender, EventArgs e)
    {
        int f = 0, flagJob = 0, flagApp = 0, flagAca = 0, flagExp = 0;
        StringBuilder query = new StringBuilder("SELECT ");
        StringBuilder queryTab = new StringBuilder("");
        StringBuilder queryCon = new StringBuilder("");
        foreach (ListItem item in chkBox.Items)
        {
            if (item.Selected)
            {
                if (f == 1)
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;

            }
        }
        if (f == 1)
        {
            flagJob = 1;
            queryTab.Append("INT_JOB_MAIN_INF AS JOB INNER JOIN " +
                            "DES_INF AS DES ON JOB.DESIG_ID = DES.DES_ID INNER JOIN " +
                            "INS_DEPT_INF AS DEPT ON JOB.DEPT_ID = DEPT.DEPT_ID INNER JOIN " +
                            "UNIV_INS_INF AS INS ON DEPT.INS_ID = INS.INS_ID ");
        }
        f = 0;
        foreach (ListItem item in chkApplicants.Items)
        {
            if (item.Selected)
            {
                if ((f == 1) || (flagJob == 1))
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;
                flagApp = 1;
            }
        }
        f = 0;
        foreach (ListItem item in chkAca.Items)
        {
            if (item.Selected)
            {
                if ((f == 1) || (flagJob == 1) || (flagApp == 1))
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;
                flagAca = 1;
            }
        }

        f = 0;
        foreach (ListItem item in chkExp.Items)
        {
            if (item.Selected)
            {
                if ((f == 1) || (flagJob == 1) || (flagApp == 1) || (flagAca == 1))
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;
                flagExp = 1;
            }
        }
        f = 0;
        if ((flagJob == 1) && ((flagApp == 1) || (flagAca == 1) || (flagExp == 1)))
        {
            queryTab = new StringBuilder("");
            queryTab.Append("EXP_TYPE_INF INNER JOIN " +
                            "INT_CAN_EXP_INF ON EXP_TYPE_INF.EXP_TYPE_ID = INT_CAN_EXP_INF.EXP_TYPE_ID INNER JOIN " +
                            "EXP_ORG_INF ON INT_CAN_EXP_INF.ORG_ID = EXP_ORG_INF.ORG_ID RIGHT OUTER JOIN " +
                            "INT_JOB_MAIN_INF AS JOB INNER JOIN " +
                            "DES_INF AS DES ON JOB.DESIG_ID = DES.DES_ID INNER JOIN " +
                            "INS_DEPT_INF AS DEPT ON JOB.DEPT_ID = DEPT.DEPT_ID INNER JOIN " +
                            "UNIV_INS_INF AS INS ON DEPT.INS_ID = INS.INS_ID INNER JOIN " +
                            "INT_JOB_CAN_MAP ON JOB.JOB_ID = INT_JOB_CAN_MAP.INT_JOB_ID INNER JOIN " +
                            "INT_CAN_INF AS CAN ON INT_JOB_CAN_MAP.INT_CAN_ID = CAN.INT_CAN_ID INNER JOIN " +
                            "INT_STS_INF ON CAN.STS = INT_STS_INF.INT_STS_ID INNER JOIN " +
                            "MAIL_DOM_INF ON CAN.MAIL_DOMAIN_ID = MAIL_DOM_INF.MAIL_DOM_ID INNER JOIN " +
                            "INT_CAN_ACA_INF ON CAN.INT_CAN_ID = INT_CAN_ACA_INF.INT_CAN_ID INNER JOIN " +
                            "ACA_BASE_INF ON INT_CAN_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID INNER JOIN " +
                            "ACA_BRD_INF ON INT_CAN_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID INNER JOIN " +
                            "ACA_CRS_INF ON INT_CAN_ACA_INF.ACA_CRS_ID = ACA_CRS_INF.ACA_CRS_ID INNER JOIN " +
                            "DIV_INF ON INT_CAN_ACA_INF.DIV_ID = DIV_INF.ACA_DIV_ID ON INT_CAN_EXP_INF.INT_CAN_ID = CAN.INT_CAN_ID");

        }
        else if ((flagApp == 1) || (flagAca == 1) || (flagExp == 1))
        {
            queryTab.Append("EXP_TYPE_INF INNER JOIN  INT_CAN_EXP_INF ON EXP_TYPE_INF.EXP_TYPE_ID = INT_CAN_EXP_INF.EXP_TYPE_ID " +
                               "INNER JOIN  EXP_ORG_INF ON INT_CAN_EXP_INF.ORG_ID = EXP_ORG_INF.ORG_ID RIGHT OUTER JOIN " +
                               "INT_CAN_INF AS CAN ON INT_CAN_EXP_INF.INT_CAN_ID = CAN.INT_CAN_ID " +
                               "INNER JOIN INT_STS_INF ON CAN.STS = INT_STS_INF.INT_STS_ID " +
                               "INNER JOIN MAIL_DOM_INF ON CAN.MAIL_DOMAIN_ID = MAIL_DOM_INF.MAIL_DOM_ID " +
                               "INNER JOIN INT_CAN_ACA_INF ON CAN.INT_CAN_ID = INT_CAN_ACA_INF.INT_CAN_ID " +
                               "INNER JOIN ACA_BASE_INF ON INT_CAN_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID " +
                               "INNER JOIN ACA_BRD_INF ON INT_CAN_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID " +
                               "INNER JOIN ACA_CRS_INF ON INT_CAN_ACA_INF.ACA_CRS_ID = ACA_CRS_INF.ACA_CRS_ID " +
                               "INNER JOIN DIV_INF ON INT_CAN_ACA_INF.DIV_ID = DIV_INF.ACA_DIV_ID ");
        }

        if (ddlIns.SelectedIndex > 0)
            queryCon.Append("AND (INS.INS_ID = " + ddlIns.SelectedValue + ") ");
        if (ddlDept.SelectedIndex > 0)
            queryCon.Append("AND (DEPT.DEPT_ID = " + ddlDept.SelectedValue + ") ");
        if (ddlDes.SelectedIndex > 0)
            queryCon.Append("AND (DES.DES_ID = " + ddlDes.SelectedValue + ") ");
        if (ddlStatus.SelectedIndex > 0)
            queryCon.Append("AND (INT_STS_INF.INT_STS_ID = " + ddlStatus.SelectedValue + ") ");
        if (ddlQual.SelectedIndex > 0)
            queryCon.Append("AND (INT_CAN_ACA_INF.ACA_BASE_ID = " + ddlQual.SelectedValue + ") ");
        if (ddlCrs.SelectedIndex > 0)
            queryCon.Append("AND (INT_CAN_ACA_INF.ACA_CRS_ID = " + ddlCrs.SelectedValue + ") ");
        if (ddlExpType.SelectedIndex > 0)
            queryCon.Append("AND (INT_CAN_EXP_INF.EXP_TYPE_ID = " + ddlExpType.SelectedValue + ") ");
        if (ddlCTC.SelectedIndex > 0)
        {
            if (ddlCTC.SelectedValue == "1")
                queryCon.Append("AND (CAN.CURRENT_CTC <= " + txtCTC.Text + ") ");
            else if (ddlCTC.SelectedValue == "2")
                queryCon.Append(" AND (CAN.EXPECTED_CTC <=" + txtCTC.Text + ") ");
        }
        if (txtExp.Text != "")
            queryCon.Append("AND (DATEDIFF(MONTH,INT_CAN_EXP_INF.FRM_DATE,INT_CAN_EXP_INF.TO_DATE)=" + txtExp.Text + ")");

        query.Append(" FROM ");
        query.Append(queryTab.ToString());
        query.Append(" WHERE (INT_STS_INF.INT_STS_ID >0 ) ");
        query.Append(queryCon.ToString());
        ds = databaseFunctions.GetDataSetByQuery(query.ToString());
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptLeave.aspx','_blank','resizable=1,width=900,height=650')", true);
    }

    protected void btnExe_Click(object sender, EventArgs e)
    {
        StringBuilder query = new StringBuilder("SELECT DISTINCT ");
        int f = 0;
        foreach (ListItem item in chkInt.Items)
        {
            if (item.Selected)
            {
                if (f == 1)
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;
            }
        }
        foreach (ListItem item in CheckBoxList1.Items)
        {
            if (item.Selected)
            {
                if (f == 1)
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;

            }
        }
        foreach (ListItem item in CheckBoxList2.Items)
        {
            if (item.Selected)
            {
                if (f == 1)
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;

            }
        }
        foreach (ListItem item in CheckBoxList3.Items)
        {
            if (item.Selected)
            {
                if (f == 1)
                    query.Append(",");
                query.Append("'" + item.Text + "' =" + item.Value);
                f = 1;

            }
        }
        //query.Append(" FROM INT_MAIN_INF INNER JOIN " +
        //             "INT_SUB_INF ON INT_MAIN_INF.INT_MAIN_ID = INT_SUB_INF.INT_MAIN_ID INNER JOIN " +
        //             "INT_CAN_INF AS CAN ON INT_SUB_INF.INT_CAN_ID = CAN.INT_CAN_ID INNER JOIN " +
        //             "INT_CAN_ATT_INF ON INT_SUB_INF.INT_SUB_ID = INT_CAN_ATT_INF.INT_SUB_ID INNER JOIN " +
        //             "INT_MODE_INF ON INT_MAIN_INF.INT_MODE_ID = INT_MODE_INF.INT_MODE_ID INNER JOIN " +
        //             "INT_STS_INF ON CAN.STS = INT_STS_INF.INT_STS_ID INNER JOIN " +
        //             "INT_JOB_MAIN_INF AS JOB ON INT_MAIN_INF.INT_JOB_ID = JOB.JOB_ID INNER JOIN " +
        //             "INT_STS_INF AS ATT ON INT_CAN_ATT_INF.INT_ATT_STS = ATT.INT_STS_ID INNER JOIN "+
        //             "MAIL_DOM_INF ON CAN.MAIL_DOMAIN_ID = MAIL_DOM_INF.MAIL_DOM_ID");
        query.Append(" FROM EXP_TYPE_INF INNER JOIN " +
                     " INT_CAN_EXP_INF ON EXP_TYPE_INF.EXP_TYPE_ID = INT_CAN_EXP_INF.EXP_TYPE_ID INNER JOIN " +
                     " EXP_ORG_INF ON INT_CAN_EXP_INF.ORG_ID = EXP_ORG_INF.ORG_ID RIGHT OUTER JOIN " +
                     " INT_MAIN_INF INNER JOIN " +
                     " INT_SUB_INF ON INT_MAIN_INF.INT_MAIN_ID = INT_SUB_INF.INT_MAIN_ID INNER JOIN " +
                     " INT_CAN_INF AS CAN ON INT_SUB_INF.INT_CAN_ID = CAN.INT_CAN_ID INNER JOIN " +
                     " INT_CAN_ATT_INF ON INT_SUB_INF.INT_SUB_ID = INT_CAN_ATT_INF.INT_SUB_ID INNER JOIN " +
                     " INT_MODE_INF ON INT_MAIN_INF.INT_MODE_ID = INT_MODE_INF.INT_MODE_ID INNER JOIN " +
                     " INT_STS_INF ON CAN.STS = INT_STS_INF.INT_STS_ID INNER JOIN " +
                     " INT_JOB_MAIN_INF AS JOB ON INT_MAIN_INF.INT_JOB_ID = JOB.JOB_ID INNER JOIN " +
                     " INT_STS_INF AS ATT ON INT_CAN_ATT_INF.INT_ATT_STS = ATT.INT_STS_ID INNER JOIN " +
                     " MAIL_DOM_INF ON CAN.MAIL_DOMAIN_ID = MAIL_DOM_INF.MAIL_DOM_ID INNER JOIN " +
                     " INT_CAN_ACA_INF ON CAN.INT_CAN_ID = INT_CAN_ACA_INF.INT_CAN_ID INNER JOIN " +
                     " ACA_BASE_INF ON  INT_CAN_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID INNER JOIN " +
                     " ACA_BRD_INF ON INT_CAN_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID INNER JOIN " +
                     " ACA_CRS_INF ON INT_CAN_ACA_INF.ACA_CRS_ID = ACA_CRS_INF.ACA_CRS_ID INNER JOIN " +
                     " DIV_INF ON INT_CAN_ACA_INF.DIV_ID = DIV_INF.ACA_DIV_ID ON INT_CAN_EXP_INF.INT_CAN_ID = CAN.INT_CAN_ID");
        query.Append(" WHERE (INT_STS_INF.INT_STS_ID >0 ) ");

        if (ddlIntDate.SelectedIndex > 0)
            query.Append(" AND (CONVERT(VARCHAR, INT_MAIN_INF.INT_DATE, 103) = '" + ddlIntDate.SelectedItem + "')");
        if (ddlIntTime.SelectedIndex > 0)
            query.Append(" AND (CONVERT(VARCHAR(5), INT_MAIN_INF.INT_DATE, 108) = '" + ddlIntTime.SelectedItem + "')");
        if (ddlIntMode.SelectedIndex > 0)
            query.Append(" AND (INT_MAIN_INF.INT_MODE_ID = " + ddlIntMode.SelectedValue + ")");
        if (ddlRound.SelectedIndex > 0)
            query.Append(" AND (INT_MAIN_INF.INT_ROUND = " + ddlRound.SelectedValue + ")");
        if (ddlPre.SelectedIndex > 0)
            query.Append(" AND (ATT.INT_STS_ID = " + ddlPre.SelectedValue + ")");
        if (ddlSts.SelectedIndex > 0)
            query.Append(" AND (INT_STS_INF.INT_STS_ID = " + ddlSts.SelectedValue + ")");
        if (ddlJob.SelectedIndex > 0)
            query.Append(" AND (JOB.JOB_ID = "+ddlJob.SelectedValue+")");
        ds = databaseFunctions.GetDataSetByQuery(query.ToString());
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptInterview.aspx','_blank','resizable=1,width=900,height=650')", true);
    }
    
}
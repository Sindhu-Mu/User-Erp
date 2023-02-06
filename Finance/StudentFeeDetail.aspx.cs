using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Finance_StudentFeeDetail : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DatabaseFunctions db;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {
            fillfunction.Fill(ddlInstitute,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Institution),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlBatch,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Batch),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlSemester,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Semester),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlSection,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Section),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlSession,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Session),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlStatus,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Status),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlQuota,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Quota),true,FillFunctions.FirstItem.Select);
        }
       
        
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        db = new DatabaseFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        StringBuilder query = new StringBuilder();
        StringBuilder query1 = new StringBuilder();
        StringBuilder query2 = new StringBuilder();
        StringBuilder query3 = new StringBuilder();
        if (ddlInstitute.SelectedIndex > 0)
            query1.Append(" AND StuView.INS_ID= '" + ddlInstitute.SelectedValue + "'");
        if (ddlCourse.SelectedIndex > 0)
            query1.Append(" AND StuView.INS_PGM_ID ='" + ddlCourse.SelectedValue + "'");
        if (ddlBranch.SelectedIndex > 0)
            query1.Append("AND StuView.PGM_BRN_ID='" + ddlBranch.SelectedValue + "'");
        if (ddlBatch.SelectedIndex > 0)
            query1.Append(" AND StuView.ACA_BATCH_ID='" + ddlBatch.SelectedValue + "'");
        if (ddlSection.SelectedIndex > 0)
           query1.Append("AND StuView.ACA_SEC_ID='"+ddlSection.SelectedValue+"'");  
        if (ddlStatus.SelectedIndex > 0)
           query1.Append("AND StuView.STU_STS_ID='"+ddlStatus.SelectedValue+"'");
        if (ddlSemester.SelectedIndex > 0)
           query1.Append("AND StuView.ACA_SEM_ID='"+ddlSemester.SelectedValue+"'");
        if ((ddlShowType.SelectedIndex == 0) && (ddlFeeHead.SelectedIndex > 0))
           query1.Append("AND STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID='"+ddlFeeHead.SelectedValue+"'");
        if (ddlSession.SelectedIndex > 0)
           query1.Append("AND STU_FIN_FEE_PROCESS_INF.SESSION_ID='"+ddlSession.SelectedValue+"'");
        if (ddlSemType.SelectedIndex > 0)
            query1.Append("AND STU_FIN_FEE_PROCESS_INF.SEM_TYPE_ID ='"+ddlSemType.SelectedValue+"'");
        else if ((ddlShowType.SelectedIndex == 1) && (ddlFeeHead.SelectedIndex > 0))
            query1.Append(" AND STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID ='" + ddlFeeHead.SelectedValue + "'");
        if (ddlStuType.SelectedIndex == 1)
        {
            query2.Append("And StuView.STU_MAIN_ID not in(select stu_main_id from STU_fin_Inactive_student)");
           
        }
        else if (ddlStuType.SelectedIndex == 2)
            query2.Append("AND StuView.STU_MAIN_ID in(select stu_main_id from STU_fin_Inactive_student)");

        if (ddlShowType.SelectedIndex == 0)
        {
            query.Append("SELECT STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_NAME AS HEAD,NOS=COUNT(DISTINCT STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID), SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_FEE_AMT) AS DEMAND,SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_ADJUST_AMT)AS ADJUST,SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_RCV_AMT)AS RECEIVE, "
                    + " SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT)AS BALANCE FROM  STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID= STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID INNER JOIN STU_FIN_FEE_MAIN_HEAD_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID INNER JOIN"
                    + " StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID INNER JOIN"
                    + " STU_FIN_FEE_GROUP_HEAD_INF ON STU_FIN_FEE_MAIN_HEAD_INF.FEE_GROUP_HEAD_ID = STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID INNER JOIN"
                    + " STU_FIN_FEE_PROCESS_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_PROS_ID = STU_FIN_FEE_PROCESS_INF.FEE_PROS_ID "
                    + " WHERE   STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID>0  " + query1.ToString() + query2.ToString()
                    + " GROUP BY STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_NAME,STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID"
                    + " ORDER BY STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID");

            query3.Append("SELECT DISTINCT (SELECT        SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT) "
                       + " FROM            STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN "
                       + " STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN "
                       + "  StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID WHERE  (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID > 0) " + query2.ToString() + ")AS CURRENT_DUE, "
                       + " (SELECT       ISNULL( SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT),0) FROM            STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN "
                       + "  STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID "
                       + " WHERE        (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = - 1) " + query2.ToString() + ")AS PREV_DUE, "
                       + " ( SELECT        SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT) FROM            STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN "
                       + " StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID WHERE        (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID > 0) " + query2.ToString() + ") +  (SELECT       ISNULL( SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT) ,0) FROM STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN "
                       + " STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID WHERE        (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = - 1) " + query2.ToString() + ")AS TOTAL_DUE "
                       + " FROM  STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID= STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID INNER JOIN STU_FIN_FEE_MAIN_HEAD_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID INNER JOIN StuView "
                       + " ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID INNER JOIN STU_FIN_FEE_GROUP_HEAD_INF ON STU_FIN_FEE_MAIN_HEAD_INF.FEE_GROUP_HEAD_ID = STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID INNER JOIN STU_FIN_FEE_PROCESS_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_PROS_ID = STU_FIN_FEE_PROCESS_INF.FEE_PROS_ID "
                       + " WHERE     STU_FIN_FEE_PROCESS_INF.SEM_TYPE_ID ='1' " + query2.ToString());


            }
       
        else 
         {
             query.Append("SELECT STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_NAME  AS HEAD,NOS=COUNT(DISTINCT STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID), SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_FEE_AMT) AS DEMAND,SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_ADJUST_AMT)AS ADJUST,SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_RCV_AMT)AS RECEIVE,"
         + " SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT)AS BALANCE FROM STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID= STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID INNER JOIN STU_FIN_FEE_MAIN_HEAD_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID INNER JOIN"
         + " StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID INNER JOIN"
         + " STU_FIN_FEE_PROCESS_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_PROS_ID = STU_FIN_FEE_PROCESS_INF.FEE_PROS_ID INNER JOIN"
                      + "  STU_FIN_INACTIVE_STUDENT ON StuView.STU_MAIN_ID = STU_FIN_INACTIVE_STUDENT.STU_MAIN_ID AND" 
                      + "   STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = STU_FIN_INACTIVE_STUDENT.STU_MAIN_ID"
         + " WHERE  STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID>0 " + query1.ToString() + query2.ToString()
         + " GROUP BY STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_NAME,STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID,FEE_MAIN_HEAD_PRIORITY ORDER BY FEE_MAIN_HEAD_PRIORITY");

             query3.Append("SELECT DISTINCT (SELECT        SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT) "
                       + " FROM            STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN "
                       + " STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN "
                       + "  StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID WHERE  (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID > 0) " + query2.ToString() + ")AS CURRENT_DUE, "
                       + " (SELECT       ISNULL( SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT),0) FROM            STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN "
                       + "  STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID "
                       + " WHERE        (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = - 1) " + query2.ToString() + ")AS PREV_DUE, "
                       + " ( SELECT        SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT) FROM            STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN "
                       + " StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID WHERE        (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID > 0) " + query2.ToString() + ") +  (SELECT       ISNULL( SUM(STU_FIN_FEE_DEMAND_SUB_INF.FD_BALANCE_AMT) ,0) FROM STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN "
                       + " STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID = STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID INNER JOIN StuView ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID WHERE        (STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = - 1) " + query2.ToString() + ")AS TOTAL_DUE "
                       + " FROM  STU_FIN_FEE_DEMAND_SUB_INF INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID= STU_FIN_FEE_DEMAND_SUB_INF.FEE_DEMAND_ID INNER JOIN STU_FIN_FEE_MAIN_HEAD_INF ON STU_FIN_FEE_DEMAND_SUB_INF.FEE_MAIN_HEAD_ID = STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID INNER JOIN StuView "
                       + " ON STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO = StuView.STU_MAIN_ID INNER JOIN STU_FIN_FEE_GROUP_HEAD_INF ON STU_FIN_FEE_MAIN_HEAD_INF.FEE_GROUP_HEAD_ID = STU_FIN_FEE_GROUP_HEAD_INF.FEE_GROUP_HEAD_ID INNER JOIN STU_FIN_FEE_PROCESS_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_PROS_ID = STU_FIN_FEE_PROCESS_INF.FEE_PROS_ID "
                       + " WHERE     STU_FIN_FEE_PROCESS_INF.SEM_TYPE_ID ='1' " + query2.ToString());

        }
        gvDemand.DataSource = db.GetDataSetByQuery(query.ToString());
        gvDemand.DataBind();
        GvDue.DataSource = db.GetDataSetByQuery(query3.ToString());
        GvDue.DataBind();
        double TotD, TotA, TotR, TotB;
        TotD = TotA = TotR = TotB = 0;
        foreach (GridViewRow itm in gvDemand.Rows)
        {
            TotD += Convert.ToDouble(itm.Cells[3].Text);
            TotA += Convert.ToDouble(itm.Cells[4].Text);
            TotR += Convert.ToDouble(itm.Cells[5].Text);
            TotB += Convert.ToDouble(itm.Cells[6].Text);
        }
        if (gvDemand.Rows.Count > 0)
        {
            gvDemand.FooterRow.Cells[3].Text = TotD.ToString("N2");
            gvDemand.FooterRow.Cells[4].Text = TotA.ToString("N2");
            gvDemand.FooterRow.Cells[5].Text = TotR.ToString("N2");
            gvDemand.FooterRow.Cells[6].Text = TotB.ToString("N2");
        }


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("StudentFeeDemand.xls", gvDemand);
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillfunction.Fill(ddlCourse, queryfunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCourse.SelectedIndex>0)
        {
         fillfunction.Fill(ddlBranch, queryfunction.GetCommand(QueryFunctions.QueryBaseType.Branch,ddlCourse.SelectedValue),true,FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlShowType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlShowType.SelectedIndex == 0)
        {
            fillfunction.Fill(ddlFeeHead,queryfunction.GetCommand(QueryFunctions.QueryBaseType.MainHeadId),true,FillFunctions.FirstItem.Select);
        }
        if (ddlShowType.SelectedIndex == 1)
        {
           fillfunction.Fill(ddlFeeHead,queryfunction.GetCommand(QueryFunctions.QueryBaseType.GroupHeadId),true,FillFunctions.FirstItem.Select);
        
        }

    }
}
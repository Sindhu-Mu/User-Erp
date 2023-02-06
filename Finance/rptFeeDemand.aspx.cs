using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DatabaseFunctions databaseFunctions;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {

            fillFunctions.Fill(ddlInstitute,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSemester,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSection,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlStatus,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Stu_Status), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlQuota,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Quota), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlState,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlCaste,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlReligion,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSession, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.All);
            




        }
       
        
    }
    protected void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
    }







    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        balObj.balInsId=ddlInstitute.SelectedValue;
        balObj.balCourseId=ddlCourse.SelectedValue;
        balObj.balBranchId=ddlBranch.SelectedValue;
        balObj.balBatchId=ddlBatch.SelectedValue;
        balObj.balSem=ddlSemester.SelectedValue;
        balObj.balSession=ddlSession.SelectedValue;
        balObj.balSemType=ddlSemType.SelectedValue;
        balObj.balCommonID=ddlShowType.SelectedValue;

         
        DataSet ds = bllObj.GetStudentDemand(balObj);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvDemand.DataSource = ds;
            gvDemand.DataBind();

        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No record found.')", true);

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("StudentFeeDemand.xls", gvDemand);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        StringBuilder query = new StringBuilder();
        //query.Append("SELECT ToP " + ddlCount.SelectedValue + "  " + ddlPrint.SelectedValue + ", StuView2.STU_ADM_NO, StuView2.STU_NAME, 'Mr.'+ StuView2.FATHERS_NAME AS PARENT_NAME,FEE_SEM_NO AS SEM,STU_MOBILE,COURSE=COURSE_SHORT_NAME+'-'+BRANCH_SHORT_NAME, PADD=CASE  WHEN  LEN(ADD2)>0 THEN ADD1+'<br/>'+ ADD2+'<br/>CITY:-'+CITY+' STATE:- '+STATE ELSE ADD1+'<br/>CITY:-'+CITY+' STATE:- '+STATE END,CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_LTR_PRINT_DT,106) AS DATE,REF=SEM_TYPE_VALUE+'/'+StuView2.STU_ADM_NO+'/'+CONVERT(VARCHAR,FEE_DEMAND_ID),SEM_TYPE_VALUE,"
        //  + " SESSION_VALUE,CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_PROS_ST_DT,106) AS STARTDATE, CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_LAST_CLS_DT,106) AS CLS_DT,"
        //  + " CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_PROS_ED_DT,106) AS ENDDATE,CURR_SEMISTAR_NO,SECTION_ID FROM StuView2 INNER JOIN"
        //  + " STU_FIN_FEE_DEMAND_MAIN_INF ON StuView2.STU_ADM_NO = STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO "
        //  + " INNER JOIN STU_FIN_FEE_PROCESS_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_PROS_ID = STU_FIN_FEE_PROCESS_INF.FEE_PROS_ID"
        //  + " INNER JOIN ACA_SEM_TYPE_INF ON STU_FIN_FEE_PROCESS_INF.SEM_TYPE_ID=ACA_SEM_TYPE_INF.SEM_TYPE_ID"
        //  + " INNER JOIN ACA_SESSION_INF ON STU_FIN_FEE_PROCESS_INF.SESSION_ID=ACA_SESSION_INF.SESSION_ID"
        //  + " WHERE FD_STATUS=1");
        query.Append("SELECT ToP " + ddlCount.SelectedValue + "  " + ddlPrint.SelectedValue + ", StuFullView.ENROLLMENT_NO, StuFullView.STU_FULL_NAME, 'Mr.'+ StuFullView.FATHER_NAME AS PARENT_NAME,FEE_SEM_NO AS SEM,StuFullView.PHN_NO, "
           + "COURSE=StuFullView.PGM_SHORT_NAME+'-'+StuFullView.BRN_SHORT_NAME, PADD=CASE  WHEN  LEN(StuFullView.ADD_2)>0 THEN StuFullView.ADD_1+'<br/>'+ StuFullView.ADD_2+'<br/>CITY:-'+StuFullView.CIT_VALUE+' STATE:- '+StuFullView.STA_VALUE ELSE StuFullView.ADD_1+'<br/>CITY:-'+StuFullView.CIT_VALUE+' STATE:- '+StuFullView.STA_VALUE END, "
           + "CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_LTR_PRINT_DT,106) AS DATE,REF='MU'+'/'+StuFullView.INS_VALUE+'/'+ SEM_TYPE_VALUE+'/'+'2017'+'/'+ CONVERT(VARCHAR,FEE_DEMAND_ID)+'/'+case when StuFullView.CAS_VALUE!='Schedule Caste' then '' else 'SC' end,"
           + "SEM_TYPE_VALUE,ACA_SESSION_INF.ACA_SESN_VALUE,CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_PROS_ST_DT,106) "
           + "AS STARTDATE, CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_LAST_CLS_DT,106) AS CLS_DT,"
           + "CONVERT(VARCHAR,STU_FIN_FEE_PROCESS_INF.FEE_PROS_ED_DT,106) AS ENDDATE,ACA_SEM_ID,StuFullView.ACA_SEC_NAME " 
           + "FROM StuFullView INNER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON StuFullView.STU_MAIN_ID = STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO "  
           + "INNER JOIN STU_FIN_FEE_PROCESS_INF ON STU_FIN_FEE_DEMAND_MAIN_INF.FEE_PROS_ID = STU_FIN_FEE_PROCESS_INF.FEE_PROS_ID " 
           + "INNER JOIN ACA_SEM_TYPE_INF ON STU_FIN_FEE_PROCESS_INF.SEM_TYPE_ID=ACA_SEM_TYPE_INF.SEM_TYPE_ID "
           + "INNER JOIN ACA_SESSION_INF ON STU_FIN_FEE_PROCESS_INF.SESSION_ID=ACA_SESSION_INF.ACA_SESN_ID WHERE FD_STATUS=1" 
           );
        if (ddlInstitute.SelectedIndex > 0)
            query.Append(" AND StuFullView.INS_ID='" + ddlInstitute.SelectedValue + "'");
        if (ddlCourse.SelectedIndex > 0)
            query.Append(" AND StuFullView.INS_PGM_ID='" + ddlCourse.SelectedValue + "'");
        if (ddlBranch.SelectedIndex > 0)
            query.Append(" AND StuFullView.PGM_BRN_ID='" + ddlBranch.SelectedValue + "'");
        if (ddlBatch.SelectedIndex > 0)
            query.Append(" AND StuFullView.ACA_BATCH_ID='" + ddlBatch.SelectedValue + "'");
        if (ddlSection.SelectedIndex > 0)
            query.Append(" AND ACA_SEC_ID='" + ddlSection.SelectedValue + "'");
        if (ddlCaste.SelectedIndex > 0)
            query.Append(" AND CAS_ID='" + ddlCaste.SelectedValue + "'");
        if (ddlReligion.SelectedIndex > 0)
            query.Append(" AND REL_ID='" + ddlReligion.SelectedValue + "'");
        if (ddlSession.SelectedIndex > 0)
            query.Append(" AND STU_FIN_FEE_PROCESS_INF.SESSION_ID='" + ddlSession.SelectedValue + "'");
        if (ddlSemType.SelectedIndex > 0)
            query.Append(" AND STU_FIN_FEE_PROCESS_INF.SEM_TYPE_ID='" + ddlSemType.SelectedValue + "'");
        if (ddlQuota.SelectedIndex > 0)
            query.Append(" AND QUOTA_ID='" + ddlQuota.SelectedValue + "'");
        if (ddlSex.SelectedIndex > 0)
            query.Append(" AND GEN_ID='" + ddlSex.SelectedValue + "'");
        if (ddlStatus.SelectedIndex > 0)
            query.Append(" AND StuFullView.STU_STS_ID ='" + ddlStatus.SelectedValue + "'");
        if (ddlSemester.SelectedIndex > 0)
            query.Append(" AND FEE_SEM_NO ='" + ddlSemester.SelectedValue + "'");
        if (ddlState.SelectedIndex > 0)
            query.Append(" AND STA_ID ='" + ddlState.SelectedValue + "'");
        if (ddlCity.SelectedIndex > 0)
            query.Append(" AND CIT_ID ='" + ddlCity.SelectedValue + "'");
        if (txtFromEnroll.Text != "" && txtToEnroll.Text != "")
            query.Append(" AND StuFullView.ENROLLMENT_NO BETWEEN '" + txtFromEnroll.Text + "' AND '" + txtToEnroll.Text + "'");
        if (ddlPrint.SelectedValue == "1")
            query.Append(" AND fee_demand_id not in (select fee_demand_id from STU_FIN_FEE_DEMAND_PRNT_INF where fee_prnt_sts=1)");
        query.Append(" ORDER BY STU_FIN_FEE_DEMAND_MAIN_INF.FEE_DEMAND_ID");
        //query.Append((ddlSort.SelectedIndex > 0) ? " STUVIEW.STU_ADM_NO,STU_NAME," + ddlSort.SelectedValue : "");
        DataSet ds = new DataSet();
        DatabaseFunctions dfunc = new DatabaseFunctions();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = databaseFunctions.GetDataSet(command);
        if (ds.Tables[0].Rows.Count > 0)
            Session["ds"] = ds.GetXml();
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No record found.')", true);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtDemandLetter.aspx','_blank','resizable=1,width=900,height=650')", true);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class TrainingAndPlacement_rptTnp_Main : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DataTable dt;


    public void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        dt = new DataTable();

    }
    public void pushdata()
    {
        fillFunction.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunction.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        fillFunction.Fill(ddlQuaLevel, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Stu_Qual), true, FillFunctions.FirstItem.All);
        fillFunction.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        fillFunction.Fill(ddlSection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        fillFunction.Fill(ddlCompProfile, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Comp_profile), true, FillFunctions.FirstItem.All);
        fillFunction.Fill(ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.All);

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            pushdata();
        }
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseName, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void ddlCompProf_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompProfile.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlCompany, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Company, ddlCompProfile.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCompany.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlJobProfile, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job_profile, ddlCompany.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlJobProfile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJobProfile.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlJobLocation, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job_Location, ddlJobProfile.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddldate":
                if (ddlDate.SelectedValue == "4")
                {
                    txtDt1.Enabled = true;
                    txtDt2.Enabled = true;
                }
                else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2" || ddlDate.SelectedValue == "3")
                {
                    txtDt1.Enabled = true;
                    txtDt2.Enabled = false;
                }
                else
                {
                    txtDt1.Enabled = false;
                    txtDt2.Enabled = false;
                }
                txtDt1.Text = txtDt2.Text = "";
                break;

            case "ddlsalary":
                if (ddlsalary.SelectedValue == "4")
                {
                    txtSal1.Enabled = true;
                    txtSal2.Enabled = true;
                }
                else if (ddlsalary.SelectedValue == "1" || ddlsalary.SelectedValue == "2" || ddlsalary.SelectedValue == "3")
                {
                    txtSal1.Enabled = true;
                    txtSal2.Enabled = false;
                }
                else
                {
                    txtSal1.Enabled = false;
                    txtSal2.Enabled = false;
                }
                txtSal1.Text = txtSal2.Text = "";
                break;

            case "ddlIntDt":
                if (ddlIntDt.SelectedValue == "4")
                {
                    txtIntDt1.Enabled = true;
                    txtIntDt2.Enabled = true;
                }
                else if (ddlIntDt.SelectedValue == "1" || ddlIntDt.SelectedValue == "2" || ddlIntDt.SelectedValue == "3")
                {
                    txtIntDt1.Enabled = true;
                    txtIntDt2.Enabled = false;
                }
                else
                {
                    txtIntDt1.Enabled = false;
                    txtIntDt2.Enabled = false;
                }
                txtIntDt1.Text = txtIntDt2.Text = "";
                break;

            case "ddlIntRegDate":
                if (ddlIntRegDate.SelectedValue == "4")
                {
                    txtIntRegDt1.Enabled = true;
                    txtIntRegDt2.Enabled = true;
                }
                else if (ddlIntRegDate.SelectedValue == "1" || ddlIntRegDate.SelectedValue == "2" || ddlIntRegDate.SelectedValue == "3")
                {
                    txtIntRegDt1.Enabled = true;
                    txtIntRegDt2.Enabled = false;
                }
                else
                {
                    txtIntRegDt1.Enabled = false;
                    txtIntRegDt2.Enabled = false;
                }
                txtIntRegDt1.Text = txtIntRegDt2.Text = "";
                break;

            default:
                break;
        }

    }

    private StringBuilder PrepareQuery()
    {
        StringBuilder query = new StringBuilder("Select DISTINCT 'Enrollment_No'=SV.ENROLLMENT_NO ,'Name'= SV.STU_FULL_NAME ");
        foreach (ListItem item in ChStureg1.Items)
        {
            if (item.Selected && item.Text != "TNP Details")
                query.Append(", '" + item.Text + "' =" + item.Value);
            else if (item.Selected && item.Text == "TNP Details")
                query.Append(" ," + item.Value);
        }
        foreach (ListItem item in ChPersonal1.Items)
        {
            if (item.Selected)
                query.Append(",'" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChQualification1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
            }
        }
        foreach (ListItem item in ChIntShed1.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChIntreg1.Items)
        {
            if (item.Selected)
                query.Append(",'" + item.Text + "'=" + item.Value);
        }
        foreach (ListItem item in ChIntAtt1.Items)
        {
            if (item.Selected)
                query.Append(",'" + item.Text + "'=" + item.Value);
        }
        foreach (ListItem item in ChIntSel1.Items)
        {
            if (item.Selected)
                query.Append(",'" + item.Text + "'=" + item.Value);
        }

        int i = 0;
        StringBuilder query1 = new StringBuilder("");
        foreach (ListItem item in ChMUQualification1.Items)
        {

            if (item.Selected)
            {
                if (item.Selected)
                {
                    query1.Append(",'" + item.Text + "'=" + item.Value);
                    query.Append(",[" + item.Text+"]");
                } i = 1;
            }
        }

        query.Append(" FROM   StuFullView AS SV LEFT OUTER JOIN "
                        + " STU_ACA_INF ON SV.STU_MAIN_ID = STU_ACA_INF.STU_MAIN_ID INNER JOIN "
                        + " ACA_BASE_INF ON STU_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID INNER JOIN STU_ACA_MARKS ON STU_ACA_INF.STU_MAIN_ID = STU_ACA_MARKS.STU_MAIN_ID LEFT OUTER JOIN "
                        + " ACA_BRD_INF ON STU_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID LEFT OUTER JOIN "
                         + " TNP_INTERVIEW_RESULT_INF INNER JOIN "
                         + " TNP_STU_INT_ATTENDANCE_INF ON TNP_INTERVIEW_RESULT_INF.STU_INT_ATT_ID = TNP_STU_INT_ATTENDANCE_INF.STU_INT_ATT_ID RIGHT OUTER JOIN "
                         + " TNP_COMP_MAIN_INF INNER JOIN "
                         + " TNP_JOB_MAIN_INF ON TNP_COMP_MAIN_INF.COMP_ID = TNP_JOB_MAIN_INF.COMP_ID INNER JOIN "
                         + " TNP_INT_SHEDULE_MAIN_INF ON TNP_JOB_MAIN_INF.JOB_MAIN_ID = TNP_INT_SHEDULE_MAIN_INF.JOB_MAIN_ID INNER JOIN "
                         + " TNP_INTERVIEW_REGISTERATION ON TNP_INT_SHEDULE_MAIN_INF.INT_SHEDULE_MAIN_ID = TNP_INTERVIEW_REGISTERATION.INT_SHEDULE_MAIN_ID ON "
                         + " TNP_STU_INT_ATTENDANCE_INF.INT_REG_ID = TNP_INTERVIEW_REGISTERATION.INT_REG_ID ON SV.STU_MAIN_ID = TNP_INTERVIEW_REGISTERATION.STU_MAIN_ID LEFT OUTER JOIN "
                         + " TNP_STU_REGISTERATION_INF ON SV.STU_MAIN_ID = TNP_STU_REGISTERATION_INF.STU_MAIN_ID LEFT OUTER JOIN "
                         + " TNP_ACAD_EDIT_DETAILS ON TNP_STU_REGISTERATION_INF.STU_REG_ID=TNP_ACAD_EDIT_DETAILS.STU_REG_ID ");



        if (i == 1)
        {
            query.Append("LEFT OUTER JOIN (SELECT  ENROLLMENT_NO,MAX(SESSION_VALUE) AS SESSION");
            query.Append(query1);
            query.Append(" FROM Examination.dbo.ExamStuView INNER JOIN "
+ " Examination.dbo.PGM_RESULT_MAIN_INF ON ExamStuView.PGM_MAPP_ID=PGM_RESULT_MAIN_INF.PGM_MAPP_ID AND ExamStuView.ACA_SEM_ID=PGM_RESULT_MAIN_INF.ACA_SEM_ID INNER JOIN "
+ " Examination.dbo.EXAM_STU_CRS_INF ON EXAM_STU_CRS_INF.EXAM_STU_ID = ExamStuView.EXAM_STU_ID  INNER JOIN "
+ " Examination.dbo.EXAM_STU_CRS_MRKS_INF ON EXAM_STU_CRS_INF.STU_CRS_ID = EXAM_STU_CRS_MRKS_INF.STU_CRS_ID INNER JOIN "
+ " Examination.dbo.EXAM_CRS_MAIN_INF ON EXAM_STU_CRS_INF.CRS_EXAM_ID = EXAM_CRS_MAIN_INF.CRS_EXAM_ID AND Examination.dbo.ExamStuView.ACA_SEM_ID=EXAM_CRS_MAIN_INF.ACA_SEM_ID Inner JOIN"
+ " Examination.dbo.EXAM_STU_MAIN_INF ON EXAM_STU_CRS_INF.EXAM_STU_ID = Examination.dbo.EXAM_STU_MAIN_INF.EXAM_STU_ID "
+ " WHERE (CRS_MRKS_STS=1) AND (CRS_EXAM_STS=1) "
+ " GROUP BY Examination.dbo.ExamStuView.STU_MAIN_ID,ENROLLMENT_NO, STU_FULL_NAME,ACA_BATCH_NAME, FATHER_NAME,MOTHER_NAME,INS_DESC,ExamStuView.PGM_MAPP_ID,ACA_BATCH_ID "
+ " HAVING  Examination.dbo.ExamStuView.STU_MAIN_ID IN (SELECT DISTINCT STU_MAIN_ID FROM ERP.DBO.StuView "
+ " WHERE STU_STS_ID=1  ) ) AS A ON A.ENROLLMENT_NO=SV.ENROLLMENT_NO ");

        }

        query.Append(" where SV.STU_STS_ID=1");



        if (ddlInstitute.SelectedIndex > 0)
        {
            query.Append(" AND (SV.INS_ID =" + ddlInstitute.SelectedValue + ")");
        }

        if (ddlCourse.SelectedIndex > 0)
        {
            query.Append(" AND (SV.INS_PGM_ID =" + ddlCourse.SelectedValue + ")");
        }
        if (ddlBatch.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ACA_BATCH_ID=" + ddlBatch.SelectedValue + ")");
        }
        if (ddlBranch.SelectedIndex > 0)
        {
            query.Append(" AND (SV.PGM_BRN_ID=" + ddlBranch.SelectedValue + ")");
        }
        if (ddlSemester.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ACA_SEM_ID=" + ddlSemester.SelectedValue + ")");
        }
        if (ddlSection.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ACA_SEC_ID=" + ddlSection.SelectedValue + ")");
        }
        if (ddlCompProfile.SelectedIndex > 0)
        {
            query.Append(" AND (TNP_COMP_MAIN_INF.COMP_PROFILE=" + ddlCompProfile.SelectedValue + ")");
        }
        if (ddlCompany.SelectedIndex > 0)
        {
            query.Append(" AND (TNP_COMP_MAIN_INF.COMP_NAME=" + ddlCompany.SelectedValue + ")");
        }
        if (ddlJobProfile.SelectedIndex > 0)
        {
            query.Append(" AND (TNP_JOB_MAIN_INF.JOB_PROFILE_ID=" + ddlJobProfile.SelectedValue + ")");
        }
        if (ddlJobLocation.SelectedIndex > 0)
        {
            query.Append(" AND (TNP_JOB_MAIN_INF.JOB_LOCATION=" + ddlJobLocation.SelectedValue + ")");
        }
        if (ddlIntStatus.SelectedIndex > 0)
        {
            query.Append(" AND (TNP_INTERVIEW_REGISTERATION.INT_STATUS=" + ddlIntStatus.SelectedValue + ")");
        }
        if (ddlState.SelectedIndex > 0)
        {
            query.Append("  AND (SV.STA_ID = " + ddlState.SelectedValue + ")");
        }
        if (ddlCity.SelectedIndex > 0)
        {
            query.Append(" AND (SV.CIT_ID = " + ddlCity.SelectedValue + ")");
        }
        if (ddlRegid.SelectedIndex > 0)
        {
            if (ddlRegid.SelectedValue == "0")
            {
                query.Append(" AND ((TNP_STU_REGISTERATION_INF.STU_STATUS=" + ddlRegid.SelectedValue + ") OR (TNP_STU_REGISTERATION_INF.STU_REG_ID IS NULL)) ");
            }
            else
            {
                query.Append(" AND (TNP_STU_REGISTERATION_INF.STU_STATUS=" + ddlRegid.SelectedValue + ")");
            }
        }
        if (ddlIntRegId.SelectedIndex > 0)
        {
            if (ddlIntRegId.SelectedValue == "0")
            {
                query.Append(" AND ((TNP_INTERVIEW_REGISTERATION.INT_STATUS=" + ddlIntRegId.SelectedValue + ") OR (TNP_INTERVIEW_REGISTERATION.INT_REG_ID IS NULL)) ");
            }
            else
            {
                query.Append(" AND (TNP_INTERVIEW_REGISTERATION.INT_STATUS=" + ddlIntRegId.SelectedValue + ")");
            }
        }
        if (ddlIntAttSts.SelectedIndex > 0)
        {
            query.Append(" AND (TNP_STU_INT_ATTENDANCE_INF.INT_ATT_STS=" + ddlIntAttSts.SelectedValue + ")");
        }
        if (ddlQualificationType.SelectedIndex > 0)
        {
            query.Append(" AND (STU_ACA_INF.ACA_TOP_STS = " + ddlQualificationType.SelectedValue + ")");
        }
        if (ddlQuaLevel.SelectedIndex > 0)
        {
            query.Append(" AND (STU_ACA_INF.ACA_BASE_ID = " + ddlQuaLevel.SelectedValue + ")");
        }
        if (ddlDate.SelectedIndex > 0)
        {
            switch (ddlDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND TNP_STU_REGISTERATION_INF.STU_REG_DT = ' " + txtDt1.Text + " '");
                    break;
                case "2":
                    query.Append(" AND TNP_STU_REGISTERATION_INF.STU_REG_DT < ' " + txtDt1.Text + " '");
                    break;
                case "3":
                    query.Append(" AND TNP_STU_REGISTERATION_INF.STU_REG_DT > ' " + txtDt1.Text + " '");
                    break;
                case "4":
                    query.Append(" AND TNP_STU_REGISTERATION.STU_REG_DT between ' " + txtDt1.Text + " ' and ' " + txtDt2.Text + " '");
                    break;
                default:
                    break;
            }
        }

        if (ddlsalary.SelectedIndex > 0)
        {
            switch (ddlsalary.SelectedValue)
            {
                case "1":
                    query.Append(" AND TNP_JOB_MAIN_INF.SALARY = ' " + txtSal1.Text + " '");
                    break;
                case "2":
                    query.Append(" AND TNP_JOB_MAIN_INF.SALARY < ' " + txtSal1.Text + " '");
                    break;
                case "3":
                    query.Append(" AND TNP_JOB_MAIN_INF.SALARY > ' " + txtSal1.Text + " '");
                    break;
                case "4":
                    query.Append(" AND TNP_JOB_MAIN_INF.SALARY between ' " + txtSal1.Text + " ' AND '" + txtSal2.Text + "' ");
                    break;
                default:
                    break;
            }
        }
        if (ddlIntDt.SelectedIndex > 0)
        {

            switch (ddlIntDt.SelectedValue)
            {
                case "1":
                    query.Append(" AND TNP_INT_SHEDULE_MAIN_INF.INTERVIEW_DT = ' " + txtIntDt1.Text + " '");
                    break;
                case "2":
                    query.Append(" AND TNP_INT_SHEDULE_MAIN_INF.INTERVIEW_DT < ' " + txtIntDt1.Text + " '");
                    break;
                case "3":
                    query.Append(" AND TNP_INT_SHEDULE_MAIN_INF.INTERVIEW_DT > ' " + txtIntDt1.Text + " '");
                    break;
                case "4":
                    query.Append(" AND TNP_INT_SHEDULE_MAIN_INF.INTERVIEW_DT between ' " + txtIntDt1.Text + " ' AND ' " + txtIntDt2.Text + " '");
                    break;
                default:
                    break;

            }
        }

        if (ddlIntRegDate.SelectedIndex > 0)
        {
            switch (ddlIntRegDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND TNP_INTERVIEW_REGISTERATION.INT_REG_DT = ' " + txtIntRegDt1.Text + " '");
                    break;
                case "2":
                    query.Append(" AND TNP_INTERVIEW_REGISTERATION.INT_REG_DT < ' " + txtIntRegDt1.Text + " '");
                    break;
                case "3":
                    query.Append(" AND TNP_INTERVIEW_REGISTERATION.INT_REG_DT > ' " + txtIntRegDt1.Text + " '");
                    break;
                case "4":
                    query.Append(" AND TNP_INTERVIEW_REGISTERATION.INT_REG_DT between ' " + txtIntRegDt1.Text + " ' AND ' " + txtIntRegDt2.Text + " '");
                    break;
                default:
                    break;
            }

        }
        if (ddldivision.SelectedIndex > 0)
        {
            switch (ddldivision.SelectedValue)
            {
                case "1":
                    query.Append(" AND (STU_ACA_INF.PRSNT>=60)");
                    break;
                case "2":
                    query.Append(" AND (STU_ACA_INF.PRSNT<60 and STU_ACA_INF.PRSNT>=45) ");
                    break;
                case "3":
                    query.Append(" AND (STU_ACA_INF.PRSNT<45 and STU_ACA_INF.PRSNT>=33)");
                    break;

                default:
                    break;
            }
        }

        if (ddlSort.SelectedIndex > 0)
        {
            query.Append(" ORDER BY " + ddlSort.SelectedValue);
        }


        return query;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        SqlCommand command = new SqlCommand(PrepareQuery().ToString());
        command.CommandType = CommandType.Text;
        DataSet ds = databaseFunctions.GetDataSet(command);
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptTnp.aspx','_blank','resizable=1,width=900,height=650')", true);
    }

}
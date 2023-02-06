using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ExamFunctions;
using System.Text;

public partial class Academic_rptStuResultStatus : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    DatabaseFunctions databasefunction;
    ExamFunctions.QueryFunctions Qf;
    ExamFunctions.FillFunctions ff;
    string Msg;
    DataSet ds;
    int rpttype;
    StringBuilder query;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (rbtn.SelectedValue == "0")
        {
            btnView.Attributes.Add("OnClick", "return validation()");
        }
        if (!IsPostBack)
        {

            FillFunction.Fill(ddlInstitute, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlSemester, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.All);

        }

    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        Qf = new ExamFunctions.QueryFunctions();
        ff = new ExamFunctions.FillFunctions();
        databasefunction = new DatabaseFunctions();
        query = new StringBuilder();
    }
    protected void rbtn_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtn.SelectedValue == "0")
        {
            head.Visible = true;
            res.Visible = true;
            rpttype = 1;


        }
        else
        {
            head.Visible = false;
            res.Visible = false;

        }
    }
    protected void ddlSemester_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlSemester.SelectedIndex > 0 && ddlBranch.SelectedIndex > 0 && ddlBatch.SelectedIndex > 0)
        //    ff.Fill(ddlCourse, Qf.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Paper, ddlProgramm.SelectedValue, ddlSemester.SelectedValue), true, ExamFunctions.FillFunctions.FirstItem.Select);
        //else
        //    ddlCourse.SelectedIndex = 0;

    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
            FillFunction.Fill(ddlProgramm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlProgramm.SelectedIndex = 0;

    }

    protected void ddlProgramm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProgramm.SelectedIndex > 0)
            FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlProgramm.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlBranch.SelectedIndex = 0;

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        string query = "";

        if (rbtn.SelectedValue == "0")
        {
            query = FullDetailQuery();
        }
        else
        {
            query = CountQuery();
        }
        try
        {
            SqlCommand command = new SqlCommand(query);
            command.CommandType = CommandType.Text;
            DataSet ds = databasefunction.GetDataSet(command);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["ds"] = ds.GetXml();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptStu.aspx','_blank','resizable=1,width=900,height=650')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('no records found.')", true);
        }
        catch
        {
        }


    }
    private string CountQuery()
    {
        int Credit = 0;
        StringBuilder queryColume = new StringBuilder();
        query.Append("select 'Enrollment'=SV.ENROLLMENT_NO,'Name'=SV.STU_FULL_NAME,'Back'=SRSI.TOTAL_BACK,'Detained'=SRSI.TOTAL_DETAINED");
        foreach (ListItem item in ChPersonal1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                queryColume.Append("," + item.Value);
            }
        }
        foreach (ListItem item in ChAcademic1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                queryColume.Append("," + item.Value);
            }
        }
        foreach (ListItem item in ChExamination1.Items)
        {
            if (item.Selected)
            {
                Credit = 1;
                query.Append(", '" + item.Text + "' =" + item.Value);

            }
        }
        query.Append(" from StuFullView as SV inner join Examination.dbo.STU_RESULT_STATUS_INFO as SRSI " +
 " on SV.STU_MAIN_ID = SRSI.STU_MAIN_ID where SV.STU_MAIN_ID>0");
        if (ddlStudentStatusId.SelectedIndex > 0)
            query.Append(" AND (SV.STU_STS_ID =" + ddlStudentStatusId.SelectedValue + ")");
        if (ddlSemester.SelectedIndex > 0)
            query.Append(" AND (SV.ACA_SEM_ID =" + ddlSemester.SelectedValue + ")");
        if (ddlProgramm.SelectedIndex > 0)
            query.Append(" AND (SV.INS_PGM_ID =" + ddlProgramm.SelectedValue + ")");
        if (ddlBranch.SelectedIndex > 0)
            query.Append(" AND (SV.PGM_BRN_ID =" + ddlBranch.SelectedValue + ")");
        if (ddlInstitute.SelectedIndex > 0)
            query.Append(" AND (SV.INS_ID =" + ddlInstitute.SelectedValue + ")");
        if (ddlBatch.SelectedIndex > 0)
            query.Append(" AND (SV.ACA_BATCH_ID=" + ddlBatch.SelectedValue + ")");

        //if (ddlCourse.SelectedIndex > 0)
        //    query.Append(" AND (SV.CRS_EXAM_ID =" + ddlCourse.SelectedValue + ")");

        if (txtCredit.Text != "")
        {

            Credit = 1;
            if (ddlCondition.SelectedIndex > 0)
            {
                if (ddlCondition.SelectedValue == "1")
                {
                    query.Append(" AND ( SRSI.TOTAL_DETAINED  = " + txtCredit.Text + ")");
                }
                if (ddlCondition.SelectedValue == "2")
                {
                    query.Append(" AND (  SRSI.TOTAL_DETAINED <= " + txtCredit.Text + ")");
                }
                if (ddlCondition.SelectedValue == "3")
                {
                    query.Append(" AND (  SRSI.TOTAL_DETAINED >= " + txtCredit.Text + ")");
                }
            }

        }
        if (Credit == 1)
        {
            query.Append(" AND (SV.ACA_BATCH_ID >=7 )");
        }
        query.Append(" GROUP BY ENROLLMENT_NO,STU_FULL_NAME,SRSI.TOTAL_BACK,SRSI.TOTAL_DETAINED, " +
          " SRSI.TOTAL_CREDIT,SRSI.TOTAL_CREDIT_EARN");
        query.Append(queryColume.ToString());
        query.Append(" ORDER BY ENROLLMENT_NO,STU_FULL_NAME");
        return query.ToString();

    }



    private string FullDetailQuery()
    {
        int Credit = 0;
        query.Append("SELECT  [Enrollment No]=ENROLLMENT_NO,[Name]=Stu_Full_Name,[Course Code]= CRS_CODE,[Course Name]=CRS_NAME,[Status]=CRS_RESULT_SHORT,[Internal Marks]= INTERNAL_MRKS");

        foreach (ListItem item in ChPersonal1.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChAcademic1.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChExamination1.Items)
        {
            if (item.Selected)
            {
                Credit = 1;
                query.Append(", '" + item.Text + "' =" + item.Value);

            }
        }

        query.Append(" FROM Examination.dbo.EXAM_CRS_MAIN_INF INNER JOIN Examination.dbo.EXAM_STU_CRS_INF ON  " +
                       "  EXAM_CRS_MAIN_INF.CRS_EXAM_ID =EXAM_STU_CRS_INF.CRS_EXAM_ID INNER JOIN " +
                      " Examination.dbo.EXAM_STU_CRS_MRKS_INF ON  " +
                      "   EXAM_STU_CRS_INF.STU_CRS_ID = EXAM_STU_CRS_MRKS_INF.STU_CRS_ID INNER JOIN " +
                      "   Examination.dbo.ExamStuView as SV ON EXAM_STU_CRS_INF.EXAM_STU_ID = SV.EXAM_STU_ID INNER JOIN " +
                     "      Examination.dbo.CRS_RESLT_TYPE_INF ON  " +
                     "     CRS_RESLT_TYPE_INF.CRS_RESULT_ID = EXAM_STU_CRS_INF.CRS_RESULT_ID LEFT OUTER JOIN Examination.dbo.STU_RESULT_STATUS_INFO as SRSI " +
      "  ON SRSI.EXAM_STU_ID=SV.EXAM_STU_ID " +
          "  WHERE (EXAM_STU_CRS_MRKS_INF.CRS_MRKS_STS = 1) AND (EXAM_STU_CRS_INF.CRS_RESULT_ID IN (2, 3)) ");



        if (txtCredit.Text != "")
        {

            Credit = 1;
            if (ddlCondition.SelectedIndex > 0)
            {
                if (ddlCondition.SelectedValue == "1")
                {
                    query.Append(" AND ( SRSI.TOTAL_DETAINED  = " + txtCredit.Text + ")");
                }
                if (ddlCondition.SelectedValue == "2")
                {
                    query.Append(" AND (  SRSI.TOTAL_DETAINED <= " + txtCredit.Text + ")");
                }
                if (ddlCondition.SelectedValue == "3")
                {
                    query.Append(" AND (  SRSI.TOTAL_DETAINED >= " + txtCredit.Text + ")");
                }
            }


        }
        if (ddlInstitute.SelectedIndex > 0)
            query.Append(" AND (SV.INS_ID =" + ddlInstitute.SelectedValue + ")");
        if (ddlBatch.SelectedIndex > 0)
            query.Append(" AND (SV.ACA_BATCH_ID=" + ddlBatch.SelectedValue + ")");
        if (ddlProgramm.SelectedIndex > 0)
            query.Append(" AND (SV.INS_PGM_ID =" + ddlProgramm.SelectedValue + ")");
        if (ddlBranch.SelectedIndex > 0)
            query.Append(" AND (SV.PGM_BRN_ID =" + ddlBranch.SelectedValue + ")");
        if (ddlSemester.SelectedIndex > 0)
            query.Append(" AND (SV.ACA_SEM_ID =" + ddlSemester.SelectedValue + ")");
        //if (ddlCourse.SelectedIndex > 0)
        //    query.Append(" AND (SV.CRS_EXAM_ID =" + ddlCourse.SelectedValue + ")");
        if (ddlStudentStatusId.SelectedIndex > 0)
            query.Append(" AND (SV.STU_STS_ID =" + ddlStudentStatusId.SelectedValue + ")");
        if (Credit == 1)
            query.Append(" AND (SV.ACA_BATCH_ID >=7 )");

        return query.ToString();
    }


}
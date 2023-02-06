using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;

public partial class Academic_rptEvaluationScheme : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    Messages Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        Msg = new Messages();
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSubjectType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubjectType), true, FillFunctions.FirstItem.All);
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand command = new SqlCommand(BuildQuery());
            command.CommandType = System.Data.CommandType.Text;
            fillFunctions.Fill(gridScheme, command);
        }
        catch
        {
            Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    string BuildQuery()
    {
        StringBuilder query = new StringBuilder(GetFirstQuery);
        query.Append(GetFirstFilter);
        AddFilter(query);
        query.Append(GetFirstOrder);
        return query.ToString();
    }

    string GetFirstQuery
    {
        get
        {
            string query = "SELECT ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_ID, ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID, ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE, " + 
                " ACA_SUBJECT_INF.ACA_SUB_NAME, INS_PGM_INF.PGM_SHORT_NAME, ACA_BATCH_INF.ACA_BATCH_NAME, INS_PGM_BRN_INF.BRN_SHORT_NAME, " +
                " ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID, ACA_EVA_SCH_SUBJECT_INF.CREDIT_POINT,ACA_SUB_TYPE_INF.SUB_TYPE_VALUE, ACA_EXAM_TEMP_MAIN_INF.EXAM_TEMP_MAIN_HEAD, ACA_ELE_TYPE_INF.ELE_VALUE " +
                " FROM  ACA_EVALUATION_SCHEME_INF INNER JOIN ACA_EVA_SCH_SUBJECT_INF ON ACA_EVALUATION_SCHEME_INF.EVA_SCH_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID " +
                " INNER JOIN ACA_BATCH_INF ON ACA_EVALUATION_SCHEME_INF.ACA_BATCH_ID = ACA_BATCH_INF.ACA_BATCH_ID INNER JOIN INS_PGM_BRN_INF ON " +
                " ACA_EVALUATION_SCHEME_INF.PGM_BRN_ID = INS_PGM_BRN_INF.PGM_BRN_ID INNER JOIN INS_PGM_INF ON INS_PGM_BRN_INF.INS_PGM_ID = INS_PGM_INF.INS_PGM_ID " +
                " INNER JOIN ACA_SUBJECT_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SUB_ID = ACA_SUBJECT_INF.ACA_SUB_ID INNER JOIN ACA_SUB_TYPE_INF ON " +
                " ACA_EVA_SCH_SUBJECT_INF.SUB_TYPE_ID = ACA_SUB_TYPE_INF.SUB_TYPE_ID INNER JOIN ACA_EXAM_TEMP_MAIN_INF ON " +
                " ACA_EVA_SCH_SUBJECT_INF.EXAM_TEMP_MAIN_ID = ACA_EXAM_TEMP_MAIN_INF.EXAM_TEMP_MAIN_ID INNER JOIN ACA_ELE_TYPE_INF ON ACA_EVA_SCH_SUBJECT_INF.ELE_ID = ACA_ELE_TYPE_INF.ELE_ID";
            return query;
        }
    }

    string GetFirstFilter
    {
        get
        {
            return " WHERE (ACA_EVALUATION_SCHEME_INF.EVA_SCH_STS = 1) AND (ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_STS = 1)";
        }
    }

    string GetFirstOrder
    {
        get
        {
            return " ORDER BY INS_PGM_INF.INS_PGM_ID, ACA_BATCH_INF.ACA_BATCH_ID, INS_PGM_BRN_INF.PGM_BRN_ID, ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID, ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE";
        }
    }

    void AddFilter(StringBuilder query)
    {
        if (ddlInstitution.SelectedIndex > 0)
            query.Append(" AND INS_PGM_INF.INS_ID = '" + ddlInstitution.SelectedValue + "'");
        if (ddlCourse.SelectedIndex > 0)
            query.Append(" AND INS_PGM_INF.INS_PGM_ID = '" + ddlCourse.SelectedValue + "'");
        if (ddlBatch.SelectedIndex > 0)
            query.Append(" AND ACA_EVALUATION_SCHEME_INF.ACA_BATCH_ID = " + ddlBatch.SelectedValue);
        if (ddlBranch.SelectedIndex > 0)
            query.Append(" AND INS_PGM_BRN_INF.PGM_BRN_ID = " + ddlBranch.SelectedValue);
        if (ddlSemester.SelectedIndex > 0)
            query.Append(" AND ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = " + ddlSemester.SelectedValue);
        if (ddlSubjectType.SelectedIndex > 0)
            query.Append(" AND ACA_EVA_SCH_SUBJECT_INF.SUB_TYPE_ID = " + ddlSubjectType.SelectedValue);
        if (ddlPaperType.SelectedIndex > 0)
            query.Append(" AND ACA_EVA_SCH_SUBJECT_INF.ELE_ID = " + ddlPaperType.SelectedValue);
    }

}
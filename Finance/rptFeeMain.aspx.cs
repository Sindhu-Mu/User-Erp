using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
public partial class Finance_rptFeeMain : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            pushData();
        }
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();

    }

    public void pushData()
    {
        fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Stu_Status), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlQuota, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Quota), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdmCategory), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlCaste, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CasteAlias), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlReligion, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlRegConfig, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Reg_Sem), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlAdmType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdmType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSession, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSemType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SemType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);



    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlPgmType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgmType.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByType, ddlPgmType.SelectedValue), true, FillFunctions.FirstItem.All);
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
    protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHeadType.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlFeeHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FacilityMainHeadId), true, FillFunctions.FirstItem.All);
        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        //DropDownList ddl = (DropDownList)sender;
        //switch (ddl.ID)
        //{
        //    case "ddlRank":
        //        if (ddlRank.SelectedValue == "4")
        //        {
        //            txtRank1.Enabled = true;
        //            txtRank2.Enabled = true;
        //        }
        //        else if (ddlRank.SelectedValue == "1" || ddlRank.SelectedValue == "2" || ddlRank.SelectedValue == "3")
        //        {
        //            txtRank1.Enabled = true;
        //            txtRank2.Enabled = false;
        //        }
        //        else
        //        {
        //            txtRank1.Enabled = false;
        //            txtRank2.Enabled = false;
        //        }
        //        txtRank1.Text = txtRank2.Text = "";
        //        break;

        //    case "ddlAdmissionDt":
        //        if (ddlAdmissionDt.SelectedValue == "4")
        //        {
        //            txtADM1.Enabled = true;
        //            txtADM2.Enabled = true;
        //        }
        //        else if (ddlAdmissionDt.SelectedValue == "1" || ddlAdmissionDt.SelectedValue == "2" || ddlAdmissionDt.SelectedValue == "3")
        //        {
        //            txtADM1.Enabled = true;
        //            txtADM2.Enabled = false;
        //        }
        //        else
        //        {
        //            txtADM1.Enabled = false;
        //            txtADM2.Enabled = false;
        //        }
        //        txtADM1.Text = txtADM2.Text = "";
        //        break;

        //    default:
        //        break;
        //}

    }
    private StringBuilder PrepareQuery()
    {
        StringBuilder query = new StringBuilder("SELECT 'Enrollment No.'=SV.ENROLLMENT_NO ,'Name'= SV.STU_FULL_NAME ");
        string Groupquery = "SV.ENROLLMENT_NO,SV.STU_FULL_NAME";
        int f, i, P, E;
        f = i = P = E = 0;
        foreach (ListItem item in ChPersonal1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                Groupquery = Groupquery + "," + item.Value;
            }
        }
        foreach (ListItem item in ChAcademic1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                Groupquery = Groupquery + "," + item.Value;
            }
        }
        foreach (ListItem item in ChCommunication1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
                Groupquery = Groupquery + "," + item.Value;
                f = 1;
            }
        }


        foreach (ListItem item in ChFeeMain.Items)
        {
            if (item.Selected)
            {
                i = 1;
                query.Append(", '" + item.Text + "' =" + item.Value);
               
            }
        }
        foreach (ListItem item in chReg.Items)
        {
            if (item.Selected)
            {
                P = 1;
                if (item.Text == "Status")
                    query.Append(",[Reg.Status]=CASE WHEN STU_SEM_REG_MAIN.SEM_REG_STS IS NULL THEN 'Not Started' WHEN STU_SEM_REG_MAIN.SEM_REG_STS=0 THEN 'Pending For Fee' ELSE 'Completed' END");
                else
                    query.Append(", '" + item.Text + "' =" + item.Value);
                Groupquery = Groupquery + "," + item.Value;
            }
        }
        foreach (ListItem item in chExam.Items)
        {
            if (item.Selected)
            {
                E = 1;
                query.Append(", '" + item.Text + "' =" + item.Value);
                if (item.Text == "Last Examination")               
                Groupquery = Groupquery + ",SV.STU_MAIN_ID";
            }
        }
        query.Append(" FROM StuFullView SV  LEFT OUTER JOIN "
                        + " ADM_ENT_EXAM_INF ON SV.ENT_EXAM_ID = ADM_ENT_EXAM_INF.ENT_EXAM_ID");
        if (f == 1)
        {
            query.Append(" INNER JOIN STU_ADD_CNG_INF ON STU_MAIN_INF.STU_MAIN_ID = STU_ADD_CNG_INF.STU_MAIN_ID");
        }
        if (i == 1)
        {
            if(ddlSemYear.SelectedIndex==0)
            query.Append(" LEFT OUTER JOIN Stu_Fin_View AS SF ON SV.STU_MAIN_ID =SF.STU_ADM_NO ");
            else 
                query.Append(" LEFT OUTER JOIN STU_FIN_SEM_VIEW AS SF ON SV.STU_MAIN_ID =SF.STU_ADM_NO ");
        }
        if (P == 1)
        {
            query.Append(" LEFT OUTER JOIN STU_SEM_REG_CONFIG_INF LEFT OUTER JOIN "
                         + " STU_SEM_REG_MAIN ON STU_SEM_REG_CONFIG_INF.CON_REG_ID = STU_SEM_REG_MAIN.CON_REG_ID ON "
                         + " STU_SEM_REG_MAIN.STU_MAIN_ID = SV.STU_MAIN_ID");
        }
        //if (E == 1)
        //{
        //    query.Append(" LEFT OUTER JOIN EXAMSTUVIEW AS EV SV.STU_MAIN_ID = EV.STU_MAIN_ID");
        //}
        query.Append(" WHERE (SV.STU_MAIN_ID > 0 )");

        //int t = 0;
        //foreach (ListItem item in chReg.Items)
        //{
        //    if (item.Selected)
        //        t = 1;
        //}
        //if (t == 1)
        //{
        //    query.Append(" AND STU_SEM_REG_CONFIG_INF.CON_REG_STS = 1");
        //}

        if (ddlInstitute.SelectedIndex > 0)
        {
            query.Append(" AND (SV.INS_ID =" + ddlInstitute.SelectedValue + ")");
        }
        if (ddlPgmType.SelectedIndex > 0)
        {
            query.Append(" AND (SV.PGM_TYPE_ID =" + ddlPgmType.SelectedValue + ")");
        }
        if (ddlBatch.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ACA_BATCH_ID=" + ddlBatch.SelectedValue + ")");
        }

        if (ddlCourse.SelectedIndex > 0)
        {
            query.Append(" AND (SV.INS_PGM_ID =" + ddlCourse.SelectedValue + ")");
        }

        if (ddlBranch.SelectedIndex > 0)
        {
            query.Append(" AND (SV.PGM_BRN_ID=" + ddlBranch.SelectedValue + ")");
        }

        if (ddlSection.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ACA_SEC_ID=" + ddlSection.SelectedValue + ")");
        }

        if (ddlSemester.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ACA_SEM_ID=" + ddlSemester.SelectedValue + ")");
        }

        if (ddlStatus.SelectedIndex > 0)
        {
            query.Append(" AND (SV.STU_STS_ID =" + ddlStatus.SelectedValue + ")");
        }

        if (ddlQuota.SelectedIndex > 0)
        {
            query.Append(" AND (SV.QUOTA_ID =" + ddlQuota.SelectedValue + ")");
        }
        if (ddlCategory.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ENT_EXAM_ID =" + ddlCategory.SelectedValue + ")");
        }

        if (ddlCaste.SelectedIndex > 0)
        {
            query.Append(" AND (SV.CAS_ID = " + ddlCaste.SelectedValue + ")");
        }
        if (ddlReligion.SelectedIndex > 0)
        {
            query.Append(" AND (SV.REL_ID = " + ddlReligion.SelectedValue + ")");
        }
        if (ddlSex.SelectedIndex > 0)
        {
            query.Append(" AND (SV.GEN_ID = " + ddlSex.SelectedValue + ")");
        }
        if (ddlState.SelectedIndex > 0)
        {
            query.Append("  AND (SV.STA_ID = " + ddlState.SelectedValue + ")");
        }
        if (ddlCity.SelectedIndex > 0)
        {
            query.Append(" AND (SV.CIT_ID = " + ddlCity.SelectedValue + ")");
        }
        if (ddlAdmType.SelectedIndex > 0)
        {
            query.Append(" AND (SV.ADM_TYPE_ID = " + ddlAdmType.SelectedValue + ")");
        }
        //if (ddlQualificationType.SelectedIndex > 0)
        //{
        //    query.Append(" AND (STU_ACA_INF.ACA_TOP_STS = " + ddlQualificationType.SelectedValue + ")");
        //}
        #region Fees Fillter
        if (ddlSession.SelectedIndex > 0)
        {
            query.Append(" AND (SF.SESSION_ID IS NULL OR SF.SESSION_ID = " + ddlSession.SelectedValue+")");
        }
        if (ddlSemType.SelectedIndex > 0)
        {
            query.Append(" AND (SF.SEM_TYPE_ID IS NULL OR SF.SEM_TYPE_ID = " + ddlSemType.SelectedValue+")");
        }
        #endregion
        if (ddlFeeHead.SelectedIndex>0)
        {
            query.Append(" AND (SF.FEE_MAIN_HEAD_ID= " + ddlFeeHead.SelectedValue + ")");
        }

        if (ddlRegConfig.SelectedIndex > 0)
        {
            query.Append(" AND (STU_SEM_REG_CONFIG_INF.CON_REG_ID = " + ddlRegConfig.SelectedValue + " OR  STU_SEM_REG_CONFIG_INF.CON_REG_ID IS NULL)");
        }
        if (ddlRegStatus.SelectedIndex > 0)
        {
            query.Append(" AND (STU_SEM_REG_MAIN.SEM_REG_STS " + ddlRegStatus.SelectedValue + ")");
        }

        if (ddlAcommadation.SelectedIndex > 0)
        {
            query.Append(" AND dbo.GET_STU_ACCOMM_STATUS(SV.STU_MAIN_ID) ='" + ddlAcommadation.SelectedItem.Text + "'");
        }

        //if (ddlAdmissionDt.SelectedIndex > 0)
        //{
        //    switch (ddlAdmissionDt.SelectedValue)
        //    {
        //        case "1":
        //            query.Append(" AND CONVERT(VARCHAR,SV.STU_ENROLL_DT,103) = '" + commonFunctions.GetDate(txtADM1.Text) + "'");
        //            break;
        //        case "2":
        //            query.Append(" AND SV.STU_ENROLL_DT < '" + commonFunctions.GetDateTime(txtADM1.Text) + "'");
        //            break;
        //        case "3":
        //            query.Append(" AND SV.STU_ENROLL_DT > '" + commonFunctions.GetDateTime(txtADM1.Text) + "'");
        //            break;
        //        case "4":
        //            query.Append(" AND SV.STU_ENROLL_DT between '" + commonFunctions.GetDateTime(txtADM1.Text) + "' and '" + commonFunctions.GetDateTime(txtADM2.Text) + "'");
        //            break;
        //        default:
        //            break;
        //    }
        //}

        //if (ddlAddType.SelectedIndex > 0)
        //{
        //    query.Append("  AND (STU_ADD_CNG_INF.ADD_TYPE_ID = " + ddlAddType.SelectedValue + ")");
        //}        
        query.Append(" GROUP BY " + Groupquery);
        query.Append(" ORDER BY SV.ENROLLMENT_NO");
        return query;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        SqlCommand command = new SqlCommand(PrepareQuery().ToString());
        command.CommandType = CommandType.Text;
        DataSet ds = databaseFunctions.GetDataSet(command);
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptFees.aspx','_blank','resizable=1,width=900,height=650')", true);
    }

   
}
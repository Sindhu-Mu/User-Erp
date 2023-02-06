using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Academic_rpt_StudentMain : System.Web.UI.Page
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
        fillFunctions.Fill(ddlCaste, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlReligion, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBloodGp, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BloodGroup), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlAddType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdrsType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPattern, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Pattern), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlQuaLevel, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Stu_Qual), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBoard, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Board), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlRegConfig, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Reg_Sem), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlAdmType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdmType), true, FillFunctions.FirstItem.All);
        
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddldepart, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department,ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.All);
        }

    }

    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlRank":
                if (ddlRank.SelectedValue == "4")
                {
                    txtRank1.Enabled = true;
                    txtRank2.Enabled = true;
                }
                else if (ddlRank.SelectedValue == "1" || ddlRank.SelectedValue == "2" || ddlRank.SelectedValue == "3")
                {
                    txtRank1.Enabled = true;
                    txtRank2.Enabled = false;
                }
                else
                {
                    txtRank1.Enabled = false;
                    txtRank2.Enabled = false;
                }
                txtRank1.Text = txtRank2.Text = "";
                break;

            case "ddlAdmissionDt":
                if (ddlAdmissionDt.SelectedValue == "4")
                {
                    txtADM1.Enabled = true;
                    txtADM2.Enabled = true;
                }
                else if (ddlAdmissionDt.SelectedValue == "1" || ddlAdmissionDt.SelectedValue == "2" || ddlAdmissionDt.SelectedValue == "3")
                {
                    txtADM1.Enabled = true;
                    txtADM2.Enabled = false;
                }
                else
                {
                    txtADM1.Enabled = false;
                    txtADM2.Enabled = false;
                }
                txtADM1.Text = txtADM2.Text = "";
                break;

            default:
                break;
        }

    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }

    private StringBuilder PrepareQuery()
    {
        StringBuilder query = new StringBuilder("SELECT DISTINCT 'Enrollment No.'=SV.ENROLLMENT_NO ,'Name'= SV.STU_FULL_NAME ");
        
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
        foreach (ListItem item in ChCommunication1.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
       
        foreach (ListItem item in ChQualification1.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
            }
        }
        foreach (ListItem item in ChStaus.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
            }
        }
        foreach (ListItem item in chReg.Items)
        {
            if (item.Selected)
            {
                if (item.Text == "Status")

                    query.Append(",[Reg.Status]=CASE WHEN STU_SEM_REG_MAIN.SEM_STS IS NULL THEN 'Not Started' WHEN STU_SEM_REG_MAIN.SEM_STS=-2 THEN 'Pending For Library' WHEN STU_SEM_REG_MAIN.SEM_STS=-1 THEN 'Pending For Accounts' WHEN STU_SEM_REG_MAIN.SEM_STS=0 THEN 'Pending For Documents' ELSE 'Completed' END");
                else
                    query.Append(", '" + item.Text + "' =" + item.Value);
            }
        }
        foreach (ListItem item in ChOthers.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        query.Append(" FROM StuFullView SV "
                        //+ " LEFT OUTER JOIN "
                        //+ " ADM_ENT_EXAM_INF ON SV.ENT_EXAM_ID = ADM_ENT_EXAM_INF.ENT_EXAM_ID"
                        );
        //if (ddlRegStatus.SelectedIndex > 0)
        //{
        //    query.Append(" INNER JOIN STU_SEM_REG_MAIN ON SV.STU_MAIN_ID = STU_SEM_REG_MAIN.STU_MAIN_ID AND SV.ACA_SEM_ID = STU_SEM_REG_MAIN.REG_FOR_SEM");
        //}
        
        int f = 0;
        foreach (ListItem item in ChCommunication1.Items)
        {
            if (item.Selected)
                f = 1;
        }
        if (f == 1)
        {
            query.Append(" inner JOIN STU_ADD_CNG_INF ON SV.STU_MAIN_ID = STU_ADD_CNG_INF.STU_MAIN_ID");
        }

        int i = 0;

        foreach (ListItem item in ChQualification1.Items)
        {
            if (item.Selected)
            {
                i = 1;
            }
        }
        if (i == 1)
        {
            query.Append(" INNER JOIN STU_ACA_INF ON SV.STU_MAIN_ID = STU_ACA_INF.STU_MAIN_ID LEFT OUTER JOIN "
                         + " ACA_BASE_INF ON STU_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID LEFT OUTER JOIN "
                         + " ACA_BRD_INF ON STU_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID");// LEFT OUTER JOIN "
                        // + " ACA_PATTERN_INF ON STU_ACA_INF.ACA_PATTERN = ACA_PATTERN_INF.PTRN_ID");                   
        }
        int r = 0;
        foreach (ListItem item in ChStaus.Items)
        {
            if (item.Selected)
            {
                r = 1;
            }
        }
        if (r == 1)
        {
            query.Append(" INNER JOIN STU_STS_TRAN_INF ON STU_STS_TRAN_INF.STU_MAIN_ID = SV.STU_MAIN_ID INNER JOIN "
                         + " UserView ON STU_STS_TRAN_INF.STS_TRAN_BY = UserView.USR_ID INNER JOIN "
                         + " STU_STS_INF ON STU_STS_TRAN_INF.STU_STS_ID = STU_STS_INF.STU_STS_ID");
        }
        int p = 0;
        foreach (ListItem item in chReg.Items)
        {
            if (item.Selected)
            {
                p = 1;
            }
        }
        if (p == 1)
        {
            query.Append(" LEFT OUTER JOIN STU_SEM_REG_CONFIG_INF LEFT OUTER JOIN "
                         + " STU_SEM_REG_MAIN ON STU_SEM_REG_CONFIG_INF.CON_REG_ID = STU_SEM_REG_MAIN.CON_REG_ID  ON "
                         + " STU_SEM_REG_MAIN.STU_MAIN_ID = SV.STU_MAIN_ID AND (STU_SEM_REG_CONFIG_INF.CON_REG_STS=1)");					 
        }
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
            query.Append(" AND (SV.INS_ID ="+ddlInstitute.SelectedValue+")");
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
        if(ddlBloodGp.SelectedIndex>0)
        {
            query.Append(" AND (SV.BLO_GRP_ID = "+ddlBloodGp.SelectedValue+")");
        }
        if(ddlCaste.SelectedIndex>0)
        {
            query.Append(" AND (SV.CAS_ID = "+ddlCaste.SelectedValue+")");
        }
        if(ddlReligion.SelectedIndex>0)
        {
            query.Append(" AND (SV.REL_ID = "+ddlReligion.SelectedValue+")");
        }
        if(ddlSex.SelectedIndex>0)
        {
            query.Append(" AND (SV.GEN_ID = "+ddlSex.SelectedValue+")");
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
        if (ddlQualificationType.SelectedIndex > 0)
        {
            query.Append(" AND (STU_ACA_INF.ACA_TOP_STS = " + ddlQualificationType.SelectedValue + ")");
        }
        if (ddlPattern.SelectedIndex > 0)
        {
            query.Append(" AND (STU_ACA_INF.ACA_PATTERN = " + ddlPattern.SelectedValue + ")");
        }
        if (ddlQuaLevel.SelectedIndex > 0)
        {
            query.Append(" AND (STU_ACA_INF.ACA_BASE_ID = " + ddlQuaLevel.SelectedValue + ")");
        }
        if (ddlBoard.SelectedIndex > 0)
        {
            query.Append(" AND (STU_ACA_INF.ACA_BRD_ID = " + ddlBoard.SelectedValue + ")");
        }
        if (ddlRegConfig.SelectedIndex > 0)
        {
            query.Append(" AND  (STU_SEM_REG_CONFIG_INF.CON_REG_ID = " + ddlRegConfig.SelectedValue +")");
        }
        if (ddlRegStatus.SelectedIndex > 0)
        {
            query.Append(" AND (SV.REG_STATUS " + ddlRegStatus.SelectedValue + ")");
        }
        if (ddlRegDate.SelectedIndex > 0)
        {
            switch (ddlRegDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND CONVERT(VARCHAR,STU_SEM_REG_MAIN.REG_DATE,103) = '" + commonFunctions.GetDate(txtADM1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND STU_SEM_REG_MAIN.REG_DATE < '" + commonFunctions.GetDateTime(txtADM1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND STU_SEM_REG_MAIN.REG_DATE > '" + commonFunctions.GetDateTime(txtADM1.Text) + "'");
                    break;
                case "4":
                    query.Append(" AND STU_SEM_REG_MAIN.REG_DATE between '" + commonFunctions.GetDateTime(txtADM1.Text) + "' and '" + commonFunctions.GetDateTime(txtADM2.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlAcommadation.SelectedIndex > 0)
        {
            query.Append(" AND dbo.GET_STU_ACCOMM_STATUS(SV.STU_MAIN_ID) ='" + ddlAcommadation.SelectedItem.Text + "'");
        }
        if (ddlRank.SelectedIndex > 0)
        {
            switch (ddlRank.SelectedValue)
            {
                case "1":
                    query.Append(" AND SV.STU_TEST_RANK = '" + txtRank1.Text + "'");
                    break;
                case "2":
                    query.Append(" AND SV.STU_TEST_RANK < '" + txtRank1.Text + "'");
                    break;
                case "3":
                    query.Append(" AND SV.STU_TEST_RANK > '" + txtRank1.Text + "'");
                    break;
                case "4":
                    query.Append(" AND SV.STU_TEST_RANK between '" + txtRank1.Text + "' and '" + txtRank2.Text + "'");
                    break;
                default:
                    break;
            }
        }

        if (ddlAdmissionDt.SelectedIndex > 0)
        {
            switch (ddlAdmissionDt.SelectedValue)
            {
                case "1":
                    query.Append(" AND CONVERT(VARCHAR,SV.STU_ENROLL_DT,103) = '" + commonFunctions.GetDate(txtADM1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND SV.STU_ENROLL_DT < '" + commonFunctions.GetDateTime(txtADM1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND SV.STU_ENROLL_DT > '" + commonFunctions.GetDateTime(txtADM1.Text) + "'");
                    break;
                case "4":
                    query.Append(" AND SV.STU_ENROLL_DT between '" + commonFunctions.GetDateTime(txtADM1.Text) + "' and '" + commonFunctions.GetDateTime(txtADM2.Text) + "'");
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

        if (ddlAddType.SelectedIndex > 0)
        {
            query.Append("  AND (STU_ADD_CNG_INF.ADD_TYPE_ID = " + ddlAddType.SelectedValue + ")");
        }
        query.Append((ddlCard.SelectedIndex == 1) ? " AND SV.STU_MAIN_ID IN(SELECT STU_MAIN_ID FROM STU_ID_CARD_PRT_INF) " : (ddlCard.SelectedIndex == 2) ? " AND SV.STU_MAIN_ID NOT IN(SELECT  STU_MAIN_ID FROM STU_ID_CARD_PRT_INF) " : "");
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
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptStu.aspx','_blank','resizable=1,width=900,height=650')", true);
    }
}
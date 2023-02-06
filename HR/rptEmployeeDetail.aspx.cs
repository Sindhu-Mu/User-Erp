using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

public partial class HR_rptEmployeeDetail : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;

    void Initialize()
    {
        databaseFunctions = new DatabaseFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        this.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            LoadDropDownData();
        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlDOB":
                txtDOB1.Text = txtDOB2.Text = "";
                if (ddlDOB.SelectedValue == "3")
                {
                    txtDOB1.Enabled = true;
                    txtDOB2.Enabled = true;
                }
                else if (ddlDOB.SelectedValue == "1" || ddlDOB.SelectedValue == "2")
                {
                    txtDOB1.Enabled = true;
                    txtDOB2.Enabled = false;
                }
                else
                {
                    txtDOB1.Enabled = false;
                    txtDOB2.Enabled = false;
                }
                break;
            case "ddlDOJ":
                txtDOJ1.Text = txtDOJ2.Text = "";
                if (ddlDOJ.SelectedValue == "3")
                {
                    txtDOJ1.Enabled = true;
                    txtDOJ2.Enabled = true;
                }
                else if (ddlDOJ.SelectedValue == "1" || ddlDOJ.SelectedValue == "2")
                {
                    txtDOJ1.Enabled = true;
                    txtDOJ2.Enabled = false;
                }
                else
                {
                    txtDOJ1.Enabled = false;
                    txtDOJ2.Enabled = false;
                }
                break;
            case "ddlDOR":
                txtDOR1.Text = txtDOR2.Text = "";
                if (ddlDOR.SelectedValue == "3")
                {
                    txtDOR1.Enabled = true;
                    txtDOR2.Enabled = true;
                }
                else if (ddlDOR.SelectedValue == "1" || ddlDOR.SelectedValue == "2")
                {
                    txtDOR1.Enabled = true;
                    txtDOR2.Enabled = false;
                }
                else
                {
                    txtDOR1.Enabled = false;
                    txtDOR2.Enabled = false;
                }
                break;
            case "ddlExpOption":
                txtExpCountMin.Text = txtExpCountMax.Text = "";
                if (ddlExpOption.SelectedValue == "3")
                {
                    txtExpCountMin.Enabled = true;
                    txtExpCountMax.Enabled = true;
                }
                else if (ddlExpOption.SelectedValue == "1")
                {
                    txtExpCountMin.Enabled = true;
                    txtExpCountMax.Enabled = false;
                }
                else
                {
                    txtExpCountMin.Enabled = false;
                    txtExpCountMax.Enabled = false;
                }
                break;

            case "ddlTenureTime":
                txtTenureTime1.Text = txtTenureTime2.Text = "";
                if (ddlTenureTime.SelectedValue == "3")
                {
                    txtTenureTime1.Enabled = true;
                    txtTenureTime2.Enabled = true;
                }
                else if ((ddlTenureTime.SelectedValue == "1") || (ddlTenureTime.SelectedValue == "2"))
                {
                    txtTenureTime1.Enabled = true;
                    txtTenureTime2.Enabled = false;
                }
                else
                {
                    txtTenureTime1.Enabled = false;
                    txtTenureTime2.Enabled = false;
                }
                break;

            case "ddlEOL":
                txtEOL1.Text = txtEOL2.Text = "";
                if (ddlEOL.SelectedValue == "3")
                {
                    txtEOL1.Enabled = true;
                    txtEOL2.Enabled = true;
                }
                else if ((ddlEOL.SelectedValue == "1") || (ddlEOL.SelectedValue == "2"))
                {
                    txtEOL1.Enabled = true;
                    txtEOL2.Enabled = false;
                }
                else
                {
                    txtEOL1.Enabled = false;
                    txtEOL2.Enabled = false;
                }
                break;
            case "ddlLA":
                txtLA1.Text = txtLA2.Text = "";
                if (ddlLA.SelectedValue == "3")
                {
                    txtLA1.Enabled = true;
                    txtLA2.Enabled = true;
                }
                else
                {
                    txtLA1.Enabled = false;
                    txtLA2.Enabled = false;
                }
                break;
            default:
                break;
        }
    }
    private void LoadDropDownData()
    {
        fillFunctions.Fill(ddlNationality, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Nationality), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlMotherTongue, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MotherTongue), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlCaste, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDesignation, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlEmpType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ServiceType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDeptType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DeptType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlHOD, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.HOD), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Category), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlNextSeniorCode, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.NextSenior), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlYear, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Year), false, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.EmployeeStatus), true, FillFunctions.FirstItem.All);
        // fillFunctions.Fill(ddlSpecl, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Pattern), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBoard, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Board), true, FillFunctions.FirstItem.All);
        ddlYear.SelectedIndex = 1;
        fillFunctions.Fill(ddlQualificationLevel, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Academic), true, FillFunctions.FirstItem.All);

    }

    protected void ddlExperience_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExperience.SelectedIndex ==2)
            fillFunctions.Fill(ddlExpType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ExpType), true, FillFunctions.FirstItem.All);
        else
            ddlExpType.Items.Clear();
    }
    private void PrepareQuery()
    {

        StringBuilder query = new StringBuilder("SELECT 'Employee Code' = EV.EMP_MUID, 'Name' = ISNULL(EV.INI_VALUE,'')+EV.EMP_NAME");
        foreach (ListItem item in chkPerInfo.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in chkOffInfo.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        //foreach (ListItem item in chDeputation.Items)
        //{
        //    if (item.Selected)
        //        query.Append(", '" + item.Text + "' =" + item.Value);
        //}

        foreach (ListItem item in chkQualification.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in chExperienceInfo.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in chkPayRoll.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        if (ddlExperience.SelectedIndex == 1)
            query.Append(",'Total Experience'= DBO.TOT_EXP(EV.EMP_ID)");
        else if (ddlExperience.SelectedIndex == 2)
            query.Append(",'Experience'=DATEDIFF(MM, EMP_EXP_INF.FRM_DATE, EMP_EXP_INF.TO_DATE)");

        if (ddlTenure.SelectedIndex > 0)
        {
            //string tenure = txtTenure1.Text == "" ? "getdate()" : txtTenure1.Text;
            query.Append(",CONVERT(varchar, datediff(mm, EV.doj, '" +commonFunctions.GetDateTime(txtTenure1.Text)+ "')) AS 'Tenure(Months)'");
        }
        int EOL = 0;
        foreach (ListItem item in chkLeaveInfo.Items)
        {
            if (item.Selected)
            {
                switch (item.Value)
                {
                    case "EOL":
                        query.Append(", 'From Date'= CONVERT(VARCHAR,LV.FROM_DT,103)");
                        query.Append(", 'To Date'=CONVERT(VARCHAR,LV.TO_DT,103)");
                        query.Append(", 'Duration'=CONVERT(VARCHAR, LV.TOT_DAYS )+ ' day(s)'");
                        EOL = 1;
                        break;
                }
            }
        }
        query.Append(" FROM EMP_VIEW AS EV LEFT OUTER JOIN " +
                     " EMP_PERSONAL_INF AS PER ON EV.EMP_ID = PER.EMP_ID LEFT OUTER JOIN " +
                     " NATION_INF ON PER.NAT_ID = NATION_INF.NAT_ID LEFT OUTER JOIN " +
                     " REL_INF ON PER.REL_ID = REL_INF.REL_ID LEFT OUTER JOIN " +
                     " BLO_GRP_INF AS BLOOD ON PER.BLO_GRP_ID = BLOOD.BLO_GRP_ID LEFT OUTER JOIN " +
                     " MOT_TON_INF ON PER.MOT_TON_ID = MOT_TON_INF.MOT_TON_ID LEFT OUTER JOIN " +
                     " CAS_INF ON PER.CAS_ID = CAS_INF.CAS_ID LEFT OUTER JOIN " +
                     " EMP_ADDRESS AS EA ON EV.EMP_ID = EA.EMP_ID LEFT OUTER JOIN " +
                     " EMP_PHN_NO AS EP ON EP.EMP_ID = EV.EMP_ID  LEFT OUTER JOIN " +
                  
                     " EMP_MAIL_CNG_INF ON EMP_MAIL_CNG_INF.EMP_ID = EV.EMP_ID AND (EMP_MAIL_CNG_INF.MAIL_TYPE_ID = 0) and (EMP_MAIL_CNG_INF.TO_DATE is null) LEFT OUTER JOIN " +
                     " MAIL_DOM_INF ON EMP_MAIL_CNG_INF.MAIL_DOM_ID = MAIL_DOM_INF.MAIL_DOM_ID ");

        foreach (ListItem item in chkQualification.Items)
        {
            if (item.Selected)
            {
                query.Append(" LEFT OUTER JOIN EMP_ACA_INF ON EV.EMP_ID=EMP_ACA_INF.EMP_ID LEFT OUTER JOIN ACA_BASE_INF ON EMP_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID "
                    + "LEFT OUTER JOIN ACA_BRD_INF ON EMP_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID LEFT OUTER JOIN ACA_CRS_INF ON EMP_ACA_INF.ACA_CRS_ID = ACA_CRS_INF.ACA_CRS_ID ");
                break;
            }
        }

        foreach (ListItem item in chExperienceInfo.Items)
        {
            if (item.Selected)
            {
                query.Append(" LEFT OUTER JOIN EMP_EXP_INF ON EV.EMP_ID=EMP_EXP_INF.EMP_ID LEFT OUTER JOIN EXP_TYPE_INF ON EMP_EXP_INF.EXP_TYPE_ID = EXP_TYPE_INF.EXP_TYPE_ID "
                    + "LEFT OUTER JOIN EXP_ORG_INF ON EMP_EXP_INF.ORG_ID = EXP_ORG_INF.ORG_ID");
                break;
            }
        }

        foreach (ListItem item in chkLeaveInfo.Items)
        {
            if (item.Selected)
            {
                switch (item.Value)
                {
                    case "EOL":
                        query.Append(" LEFT OUTER JOIN EMP_LV_APP_INF AS LV ON LV.USR_ID = EV.USR_ID ");
                        break;
                }
            }
        }
        if (ddlDOR.SelectedIndex > 0)
        {
            query.Append(" LEFT OUTER JOIN EMP_RESIG_MAIN_INF ON EMP_RESIG_MAIN_INF.EMP_ID= EV.EMP_ID " +
                         " INNER JOIN EMP_RESIG_TRAN_INF ON EMP_RESIG_MAIN_INF.EMP_RESIG_ID = EMP_RESIG_TRAN_INF.EMP_RESIG_ID ");
        }

        query.Append(" WHERE EV.EMP_ID > 0 AND EV.EMP_CODE_TYPE_ID = '" + ddlCodeType.SelectedValue + "'");

        if (txtActive.Text != "")
        {
            query.Append(" AND DOJ<=CONVERT(DATETIME,'" + txtActive.Text + "',103)  AND (EV.EMP_ID NOT IN (SELECT EMP_ID FROM  EMP_RESIG_MAIN_INF " +
                          " WHERE      (RELVNG_DATE<=CONVERT(DATETIME,'"+txtActive.Text+"',103))))");
           // query.Append(" AND ( CONVERT(DATETIME,EV.DOJ,103) <=CONVERT(DATETIME,'" + txtActive.Text + "',103)) and (CONVERT(DATETIME,EMP_RESIG_MAIN_INF. RELVNG_DATE,103) >CONVERT(DATETIME,'" + txtActive.Text + "',103) OR EMP_RESIG_MAIN_INF. RELVNG_DATE is null )");
        }

        bool canContinue = false;

        foreach (ListItem item in chkQualification.Items)
        {
            if (item.Selected)
            {
                canContinue = true;
                break;
            }
        }


        if (canContinue)
        {
            query.Append(" AND ACA_STS = 1");

            if (ddlQualiOption.SelectedIndex == 1)
                query.Append(" AND TOP_STATUS = 1");

            if (ddlBoard.SelectedIndex > 0)
                query.Append(" AND EMP_ACA_INF.ACA_BRD_ID=" + ddlBoard.SelectedValue);

            if (ddlQualificationLevel.SelectedIndex > 0)
                query.Append(" AND EMP_ACA_INF.ACA_BASE_ID = " + ddlQualificationLevel.SelectedValue);
        }


        canContinue = false;

        foreach (ListItem item in chExperienceInfo.Items)
        {
            if (item.Selected)
            {
                canContinue = true;
                break;
            }
        }



        if (canContinue)
        {
            query.Append(" AND EXP_STS = 1");
            if (ddlExpType.SelectedIndex > 0)
                query.Append(" AND EXP_TYPE_INF.EXP_TYPE_VALUE = '" + ddlExpType.SelectedItem + "'");
            if (ddlExpOption.SelectedIndex > 0)
            {
                switch (ddlExpOption.SelectedValue)
                {
                    case "1":
                        query.Append(" AND DBO.TOT_EXP(EV.EMP_ID) < '" + txtExpCountMin.Text + "'");
                        break;
                    case "2":
                        query.Append(" AND DBO.TOT_EXP(EV.EMP_ID) > '" + txtExpCountMin.Text + "'");
                        break;
                    case "3":
                        query.Append(" AND DBO.TOT_EXP(EV.EMP_ID) BETWEEN '" + txtExpCountMin.Text + "' AND '" + txtExpCountMax.Text + "'");
                        break;
                    default:
                        break;
                }
            }
        }


        if (ddlSex.SelectedIndex > 0)
            query.Append(" AND EV.GEN_ID = '" + ddlSex.SelectedValue + "'");



        if (ddlTenure.SelectedIndex > 0 && ddlTenureTime.SelectedIndex > 0)
        {
            switch (Convert.ToInt32(ddlTenure.SelectedValue))
            {
                case 2:
                    query.Append(" AND CAST(CAST(DATEDIFF(DD,EV.DOJ,'" + txtTenure1.Text + "') AS DECIMAL (10,2))/ CAST (365 AS DECIMAL(10,2)) AS DECIMAL(10,2))");
                    break;
                default:
                    break;
            }
            switch (Convert.ToInt32(ddlTenureTime.SelectedValue))
            {
                case 1:
                    query.Append(" < '" + txtTenureTime1.Text+"'");
                    break;
                case 2:
                    query.Append(" > " + txtTenureTime1.Text+"'");
                    break;
                case 3:
                    query.Append(" BETWEEN '" + txtTenureTime1.Text + " 'AND '" + txtTenureTime2.Text+"'");
                    break;
                default:
                    break;
            }
        }

        if (EOL == 1)
        {
            query.Append(" AND (LV.LV_ID = 5)");
        }
         if (ddlEOL.SelectedIndex > 0)
        {
            switch (ddlEOL.SelectedValue)
            {
                case "1":
                    query.Append(" AND ((CONVERT(VARCHAR,LV.FROM_DT,103) <  '" + txtEOL1.Text + "') OR (CONVERT(VARCHAR,LV.TO_DT,103) < '" + txtEOL1.Text + "') )");
                    break;
                case "2":
                    query.Append(" AND ((CONVERT(VARCHAR,LV.FROM_DT,103) >  '" + txtEOL1.Text + "') OR (CONVERT(VARCHAR,LV.TO_DT,103) > '" + txtEOL1.Text + "') )");
                    break;
                case "3":
                    query.Append(" AND ((LV.FROM_DT BETWEEN CONVERT(VARCHAR,'" + commonFunctions.GetDateTime(txtEOL1.Text) + "',101) AND CONVERT(VARCHAR,'" + commonFunctions.GetDateTime(txtEOL2.Text) + "',101)) OR (LV.TO_DT BETWEEN CONVERT(VARCHAR, '" + commonFunctions.GetDateTime(txtEOL1.Text) + "',101) AND CONVERT(VARCHAR,'" + commonFunctions.GetDateTime(txtEOL2.Text) + "',101))) ");
                    break;
                default:
                    break;
            }
        }
        
        if (ddlDOB.SelectedIndex > 0)
        {
            switch (ddlDOB.SelectedValue)
            {
                case "1":
                    query.Append(" AND EV.DOB < '" + commonFunctions.GetDateTime(txtDOB1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND EV.DOB > '" + commonFunctions.GetDateTime(txtDOB1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND EV.DOB BETWEEN '" + commonFunctions.GetDateTime(txtDOB1.Text) + "' AND  '" + commonFunctions.GetDateTime(txtDOB2.Text) + "'");
                    break;
                default:
                    break;
            }
        }

        if (ddlMaritalStatus.SelectedIndex > 0)
            query.Append(" AND EV.MAR_STS_ID = '" + ddlMaritalStatus.SelectedValue + "'");
        if (ddlNationality.SelectedIndex > 0)
            query.Append(" AND PER.NAT_ID = '" + ddlNationality.SelectedValue + "'");
        if (ddlMotherTongue.SelectedIndex > 0)
            query.Append(" AND PER.MOT_TON_ID = '" + ddlMotherTongue.SelectedValue + "'");
        if (ddlCaste.SelectedIndex > 0)
            query.Append(" AND PER.CAS_ID = '" + ddlCaste.SelectedValue + "'");
        if (ddlTeaching.SelectedIndex > 0)
            query.Append(" AND EV.JOB_TYPE_ID = '" + ddlTeaching.SelectedValue + "'");
        if (ddlDOJ.SelectedIndex > 0)
        {
            switch (ddlDOJ.SelectedValue)
            {
                case "1":
                    query.Append(" AND EV.DOJ < '" + commonFunctions.GetDateTime(txtDOJ1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND EV.DOJ > '" + commonFunctions.GetDateTime(txtDOJ1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND EV.DOJ BETWEEN '" + commonFunctions.GetDateTime(txtDOJ1.Text) + "' AND '" + commonFunctions.GetDateTime(txtDOJ2.Text) + "'");
                    break;
                default:
                    break;
            }
            //query.Append(ActiveFindCode);

        }
        if (ddlEmpType.SelectedIndex > 0)
            query.Append(" AND EV.SERV_TYPE_ID = '" + ddlEmpType.SelectedValue + "'");

        if (ddlDesignation.SelectedIndex > 0)
            query.Append(" AND EV.DES_ID = '" + ddlDesignation.SelectedValue + "'");

        if (ddlDepartment.SelectedIndex > 0)
            query.Append(" AND EV.DEPT_ID = '" + ddlDepartment.SelectedValue + "'");
        if (ddlDeptType.SelectedIndex > 0)
            query.Append(" AND EV.DEPT_TYPE_ID = '" + ddlDeptType.SelectedValue + "'");
        if (ddlStatus.SelectedIndex > 0)
            query.Append(" AND EV.STS_ID = '" + ddlStatus.SelectedValue + "'");
        if (ddlHOD.SelectedIndex > 0)
            query.Append(" AND EV.HOD_ID = '" + ddlHOD.SelectedValue + "'");
        if (ddlCategory.SelectedIndex > 0)
            query.Append(" AND EV.CAT_ID = '" + ddlCategory.SelectedValue + "'");


        if (ddlNextSeniorCode.SelectedIndex > 0)
            query.Append(" AND EV.EMP_NEXT_SNR_ID = '" + ddlNextSeniorCode.SelectedValue + "'");
        if (ddlInstitution.SelectedIndex > 0)
            query.Append(" AND EV.INS_ID = '" + ddlInstitution.SelectedValue + "'");
        if (ddlDOR.SelectedIndex > 0)
        {
            switch (ddlDOR.SelectedValue)
            {
                case "1":
                    query.Append(" AND EMP_RESIG_MAIN_INF.RELVNG_DATE < '" + commonFunctions.GetDateTime(txtDOR1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND EMP_RESIG_MAIN_INF.RELVNG_DATE > '" + commonFunctions.GetDateTime(txtDOR1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND EMP_RESIG_MAIN_INF.RELVNG_DATE BETWEEN '" + commonFunctions.GetDateTime(txtDOR1.Text) + "' AND  '" + commonFunctions.GetDateTime(txtDOR2.Text) + "'");
                    break;
                default:
                    break;
            }
        }

        if (ddlHYJ.SelectedIndex > 0)
        {
            switch (ddlHYJ.SelectedIndex)
            {
                case 1:
                    query.Append(" AND EV.DOJ BETWEEN '4/1/" + ddlYear.SelectedValue + "' AND '9/30/" + ddlYear.SelectedValue + "'");
                    break;
                case 2:
                    query.Append(" AND EV.DOJ BETWEEN '10/1/" + ddlYear.SelectedValue + "' AND '3/31/" + (Convert.ToInt32(ddlYear.SelectedValue) + 1).ToString() + "'");
                    break;
                default:
                    break;
            }
        }
        StringBuilder query1 = new StringBuilder("");
        foreach (ListItem item in chkLeaveInfo.Items)
        {
            if (item.Selected)
                switch (item.Value)
                {
                    case "LA":

                        query1.Append(GetLongAbsent(query.ToString()));
                        query = query1;
                        break;
                }
        }

        if (query1 != query)
        {
            query.Append(" ORDER BY EV.EMP_ID");
        }
        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = databaseFunctions.GetDataSet(command);

        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtEmployeeDetail.aspx','_blank','resizable=1,width=900,height=650')", true);

    }
    protected void btnExecute_Click1(object sender, EventArgs e)
    {
        PrepareQuery();
    }


    string GetLongAbsent(string Query)
    {
        string query = Query;
        DateTime date1;
        DateTime date2;
        if (ddlLA.SelectedIndex == 0)
        {
            date2 = System.DateTime.Now;
            date1 = date2.AddDays(-4);
        }
        else
        {
            date1 = commonFunctions.GetDateTime(txtLA1.Text);
            date2 = commonFunctions.GetDateTime(txtLA2.Text);
        }
        StringBuilder strlong = new StringBuilder("SET NOCOUNT ON " +
"BEGIN " +
"DECLARE @EMP_ID INT DECLARE @DATE DATETIME DECLARE @LEAVE_COUNT INT " +
"SET @LEAVE_COUNT=0 " +
"DECLARE @MyCursor CURSOR " +
"CREATE TABLE LONG_ABSENSE (EMP_ID INT,FROM_DT DATETIME) " +
"SET @MyCursor = CURSOR FAST_FORWARD FOR " +
"SELECT USR_ID FROM EMP_VIEW WHERE EMP_ID >0 AND STS_ID=1 AND USR_ID NOT IN " +
"(SELECT USR_ID FROM EMP_ATT_REG_MAIN_INF WHERE DUTY_DATE BETWEEN '" + date1 + "' AND '" + date2 + "')" +
"AND USR_ID NOT IN (SELECT USR_ID FROM EMP_BLOCK_CNG_INF )" +
"OPEN @MyCursor " +
"FETCH NEXT FROM @MyCursor " +
"INTO @EMP_ID " +
"WHILE @@FETCH_STATUS = 0 " +
"BEGIN " +
"SELECT @LEAVE_COUNT= COUNT(*) FROM EMP_LV_APP_INF WHERE ((FROM_DT BETWEEN '" + date1 + "' AND '" + date2 + "') OR (TO_DT BETWEEN '" + date1 + "' AND '" + date2 + "') OR TO_DT>='" + date1 + "' )  AND STS_ID=2 AND USR_ID=@EMP_ID " +
"IF(@LEAVE_COUNT=0) " +
"BEGIN " +
"SELECT @DATE=MAX(DUTY_DATE)FROM  EMP_ATT_REG_MAIN_INF WHERE USR_ID=@EMP_ID AND (DUTY_DATE <'" + date1 + "')" +
"INSERT INTO LONG_ABSENSE VALUES(@EMP_ID,@DATE) " +
"SET @LEAVE_COUNT=0 " +
"END " +
"FETCH NEXT FROM @MyCursor " +
"INTO @EMP_ID " +
"END " +
"CLOSE @MyCursor " +
"DEALLOCATE @MyCursor " +
"SELECT DISTINCT A.*,B.[From Date] FROM(" + query + ") AS A INNER JOIN " +
"(SELECT 'Code'=EMP_VIEW.EMP_ID,'From Date'=CONVERT(VARCHAR,FROM_DT,103)  FROM LONG_ABSENSE INNER JOIN EMP_VIEW ON EMP_VIEW.USR_ID=LONG_ABSENSE.EMP_ID WHERE STS_ID=1 " +
" ) AS B  ON A.Code=B.Code " +
"DROP TABLE LONG_ABSENSE " +
"END ");
        return strlong.ToString();
    }


}

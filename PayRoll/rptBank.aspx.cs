using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class PayRoll_rptBank : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryfunctions;
    CommonFunctions commonFunctions;
    PRBLL ObjBll;
    PRBAL ObjBAL;
    private void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new PRBLL();
        ObjBAL = new PRBAL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadDropDownData();
        }
    }

    public void LoadDropDownData()
    {
        fillFunctions.Fill(ddlByRef, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Ref),true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDate, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.TranDate), false, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlInstitution, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDes, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.All);
        fillFunctions.FillYear(DateTime.Now.Year - 5, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlAppYear);
        fillFunctions.FillYear(DateTime.Now.Year - 5, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlTranYear);
        fillFunctions.Fill(ddlCat, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlempType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.JobTypeWithoutAll), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlGender, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Gender), true, FillFunctions.FirstItem.All);

    }

    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.All);
        }
        else
        {
            fillFunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.All);
        }
    }

    private void PrepareQuery()
    {
        StringBuilder query = new StringBuilder("declare @EAR_FLD varchar(max),@SQL varchar(max),@FLD_SUM VARCHAR(MAX)");
        if (ddlTranMonth.SelectedIndex > 0)
        {
            query.Append(" SELECT  @EAR_FLD = COALESCE(@EAR_FLD + ',','')+ '[' +  CONVERT(VARCHAR,TRAN_DATE,103) + ']' , @FLD_SUM = COALESCE(@FLD_SUM + ';','')+ 'ISNULL([' +  CONVERT(VARCHAR,TRAN_DATE,103) + '],0)'"
            + " FROM SAL_EMP_FUND_TRAN WHERE MONTH(TRAN_DATE)=" + ddlTranMonth.SelectedValue + " AND YEAR(TRAN_DATE)=" + ddlTranYear.SelectedValue + " GROUP BY CONVERT(VARCHAR,TRAN_DATE,103) ;");
        }
        else if (ddlAppMnth.SelectedIndex > 0)
        {
            query.Append(" SELECT  @EAR_FLD = COALESCE(@EAR_FLD + ',','')+ '[' +  CONVERT(VARCHAR,TRAN_DATE,103) + ']' , @FLD_SUM = COALESCE(@FLD_SUM + ';','')+ 'ISNULL([' +  CONVERT(VARCHAR,TRAN_DATE,103) + '],0)'"
    + " FROM SAL_EMP_FUND_TRAN INNER JOIN SAL_REC_MASTER ON REC_ID=SAL_REC_ID WHERE SAL_REC_MONTH=" + ddlAppMnth.SelectedValue + " AND SAL_REC_YEAR=" + ddlAppYear.SelectedValue + "  GROUP BY CONVERT(VARCHAR,TRAN_DATE,103);");
        }
        query.Append("  SET @FLD_SUM = REPLACE(@FLD_SUM,';','+');"
       + " SET @SQL='SELECT [CODE]=EMP_ID,[NAME]=EMP_NAME,[GROSS_SALARY]=ES_TOTAL_GROSS_SALARY,[NOD]=SAL_NOD,[For Month]=convert(varchar(100),SAL_REC_MONTH)+''-''+convert(varchar(100),SAL_REC_YEAR),[PAYBALE]=SAL_PAYBALE,'+@EAR_FLD+', [REMAININIG SALARY]=(SAL_PAYBALE-('+@FLD_SUM+')),[Salary Paid]=convert(DECIMAL(10,2),'+@FLD_SUM+'),[Account Number]=BANK_AC_NO,[Payment Mode]=TRAN_TYPE,Remarks");
        foreach (ListItem item in chkFeild.Items)
        {
            if (item.Selected)
                query.Append(", '+'" + item.Text + "'+' =" + item.Text);
        }
        query.Append(" FROM (SELECT DISTINCT SAL_EMP_STRUCT_MASTER.ES_TOTAL_GROSS_SALARY,case TRAN_TYPE WHEN 1 THEN ''Bank Transfer'' ELSE ''Cash'' END AS TRAN_TYPE," +
            "EV.EMP_ID, EV.EMP_NAME, SAL_EMP_FUND_TRAN.REC_ID,SAL_REC_MONTH,SAL_REC_YEAR, SAL_EMP_FUND_TRAN.TRAN_AMT,SAL_NOD,SAL_PAYBALE,EV.ACC_NO AS BANK_AC_NO,convert(varchar(10),SAL_EMP_FUND_TRAN.TRAN_DATE,103) as date,remarks");
        foreach (ListItem item in chkFeild.Items)
        {
            if (item.Selected)
                query.Append("," + item.Value);
        }
        query.Append(" FROM SAL_EMP_STRUCT_MASTER INNER JOIN " +
                     " SAL_REC_MASTER ON SAL_EMP_STRUCT_MASTER.ES_ID = SAL_REC_MASTER.ES_ID INNER JOIN " +
                     " EMP_VIEW AS EV ON SAL_EMP_STRUCT_MASTER.ES_EMP_CODE = EV.EMP_ID INNER JOIN " +
                     " SAL_EMP_FUND_TRAN ON SAL_REC_MASTER.SAL_REC_ID = SAL_EMP_FUND_TRAN.REC_ID INNER JOIN " +
                     " EMP_PERSONAL_INF AS PER ON EV.EMP_ID = PER.EMP_ID");

        query.Append(" WHERE     (SAL_EMP_STRUCT_MASTER.ES_STATUS = 1)");
        if (ddlInstitution.SelectedIndex > 0)
        {
            query.Append("AND (EV.INS_ID=''" + ddlInstitution.SelectedValue + "'')");
        }
        if (ddlDept.SelectedIndex > 0)
        {
            query.Append("AND (EV.DEPT_ID=''" + ddlDept.SelectedValue + "'')");
        }

        if (ddlDes.SelectedIndex > 0)
            query.Append(" AND (EV.DES_ID = ''" + ddlDes.SelectedValue + "'')");

        if (txtEmp.Text != "")
        {
            //string[] str = txtEmp.Text.Split(':');
            query.Append(" AND EV.EMP_ID = " + commonFunctions.GetKeyID(txtEmp) + "");
        }
        if (ddlGender.SelectedIndex > 0)
        {
            query.Append(" and(EV.GEN_ID = ''" + ddlGender.SelectedValue + "'')");
        }
        if (ddlCat.SelectedIndex > 0)
        {
            query.Append(" AND (PER.CAS_ID LIKE ''%" + ddlCat.SelectedValue + "%'')");
        }
        if (ddlAppMnth.SelectedIndex > 0)
        {
            query.Append(" AND SAL_REC_MONTH =" + ddlAppMnth.SelectedValue + "");
        }
        if (ddlAppYear.SelectedIndex > 0)
        {
            query.Append(" AND SAL_REC_YEAR =" + ddlAppYear.SelectedValue + "");
        }
        if (ddlTranMonth.SelectedIndex > 0)
        {
            query.Append(" AND (month(SAL_EMP_FUND_TRAN.TRAN_DATE) =" + ddlTranMonth.SelectedValue + ")");
        }
        if (ddlTranYear.SelectedIndex > 0)
        {
            query.Append(" AND (year(SAL_EMP_FUND_TRAN.TRAN_DATE) =" + ddlTranYear.SelectedValue + ")");
        }
        if (ddlMode.SelectedIndex > 0)
        {
            query.Append(" AND (TRAN_TYPE=" + ddlMode.SelectedValue + ")");
        }
        if (ddlempType.SelectedIndex > 0)
        {
            query.Append(" AND (EV.JOB_TYPE_ID=''" + ddlempType.SelectedValue + "'')");
        }
        if (ddlDate.SelectedIndex > 0)
        {
            query.Append(" AND (CONVERT(VARCHAR(24),TRAN_DATE,20)=CONVERT(VARCHAR(24),''" + ddlDate.SelectedItem + "'',20))");
        }
        if (txtMinSalary.Text != "")
        {
            query.Append(" AND (SAL_EMP_STRUCT_MASTER.ES_TOTAL_GROSS_SALARY >=''" + txtMinSalary.Text + "'')");
        }
        if (txtMaxSalary.Text != "")
        {
            query.Append(" AND (SAL_EMP_STRUCT_MASTER.ES_TOTAL_GROSS_SALARY <''" + txtMaxSalary.Text + "'')");
        }
        query.Append(") AS SOURCETABLE" +
                                  " PIVOT (sum(TRAN_AMT)FOR date IN ('+@EAR_FLD+')) AS PivotTable ORDER BY [CODE]'" +
                                  " exec (@SQL)");
        DataSet ds = new DataSet();
        DatabaseFunctions dfunc = new DatabaseFunctions();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = dfunc.GetDataSet(command);
        Session["dt"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["ds"] = ds.GetXml();
            Session["dt"] = ds;
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No record found.')", true);
    }

    protected void btnExecute_Click(object sender, EventArgs e)
    {
        PrepareQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptBankDetail.aspx','_blank','resizable=1,width=900,height=650')", true);
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        MakePrintQuery();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtBankDetail.aspx?mode=" + ddlMode.SelectedValue + "&month=" + ddlAppMnth.SelectedItem.Text + "&year=" + ddlAppYear.SelectedItem.Text + "','_blank','resizable=1,scrollbars=yes')", true);
    }
    private void MakePrintQuery()
    {
        DataSet ds = new DataSet();
        ObjBAL.balData = ddlByRef.SelectedValue;
        ObjBAL.balMonth = ddlAppMnth.SelectedValue;
        ObjBAL.balYear = ddlAppYear.SelectedValue;
        ds = ObjBll.PrintBankSheet(ObjBAL);
        Session["dt"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["ds"] = ds.GetXml();
            Session["dt"] = ds;
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No record found.')", true);
    }
}
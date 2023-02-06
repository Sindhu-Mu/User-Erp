using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;
public partial class PayRoll_EqualSalaryEffect : System.Web.UI.Page
{
    string str;
    PRBAL prbal;
    PRBLL prbll;
    StringBuilder strBldr;
    DataSet ds;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunction;
    DropDownList ddlYY;
    DropDownList ddlMM;
    double Total;
    TextBox txtAmount;
    TextBox txtRemark;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnEntry.Attributes.Add("onclick", "return validation()");
        btnSave.Attributes.Add("onclick", "return validation()");
        Initialisetion();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        }

    }
    private void Initialisetion()
    {
        prbll = new PRBLL();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunction = new CommonFunctions();
        strBldr = new StringBuilder();
        prbal = new PRBAL();
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
    }

    protected void btnEntry_Click(object sender, EventArgs e)
    {
        trEntry.Visible = true; trDetail.Visible = false;
        BindGridData();

    }
    protected void btnDetail_Click(object sender, EventArgs e)
    {
        trEntry.Visible = false;
        trDetail.Visible = true;
        BindEntredData();
    }

    private void BindGridData()
    {
        ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        str = "SELECT EMP_ID, EMP_NAME,DEPT_VALUE,SAL_EMP_STRUCT_MASTER.ES_ID,SAL_EMP_STRUCT_DETAIL.ED_HEAD_VALUE,AMOUNT=ROUND((CONVERT(FLOAT,SAL_EMP_STRUCT_DETAIL.ED_HEAD_VALUE)*" + txtValue.Text + "/100),0,0),'' as TRAN_REMARKS "
        + " FROM SAL_EMP_STRUCT_MASTER  INNER JOIN Emp_View ON SAL_EMP_STRUCT_MASTER.ES_EMP_CODE = Emp_View.EMP_ID "
        + " INNER JOIN SAL_EMP_STRUCT_DETAIL  ON SAL_EMP_STRUCT_MASTER.ES_ID = SAL_EMP_STRUCT_DETAIL.ES_ID "
        + "  WHERE ES_STATUS=1 AND ED_HEAD_ID=2";
        if (ddlInstitution.SelectedIndex > 0)
            str += " AND INS_ID='" + ddlInstitution.SelectedValue + "'";
        if (ddlDepartment.SelectedIndex > 0)
            str += " AND DEPT_ID='" + ddlDepartment.SelectedValue + "'";
        if (ddlEmpType.SelectedIndex > 0)
            str += " AND JOB_TYPE_ID='" + ddlEmpType.SelectedValue + "'";
        str += " ORDER BY EMP_ID";
        prbal.balData = str;
        ds = prbll.execQuery(prbal);
        gvTranDetail.DataSource = ds.Tables[0];
        gvTranDetail.DataBind();
    }
    private void BindEntredData()
    {
        ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        str = "SELECT EMP_MAIN_INF.EMP_ID,EMP_MAIN_INF.EMP_NAME,DEPT_VALUE,ISNULL(SAL_EMP_MONTHLY_TRAN.HEAD_VALUE,0) AS HEAD_VALUE,HEAD_NAME, SAL_EMP_MONTHLY_TRAN.TRAN_REMARKS, SAL_EMP_MONTHLY_TRAN.TRAN_IN_DT, INBY.EMP_NAME AS TRAN_BY"
        + " FROM EMP_MAIN_INF INNER JOIN SAL_EMP_STRUCT_MASTER ON EMP_MAIN_INF.EMP_ID = SAL_EMP_STRUCT_MASTER.ES_EMP_CODE INNER JOIN"
        + " SAL_EMP_MONTHLY_TRAN ON SAL_EMP_STRUCT_MASTER.ES_ID = SAL_EMP_MONTHLY_TRAN.ES_ID"
        + " INNER JOIN SAL_HEAD_MASTER ON SAL_EMP_MONTHLY_TRAN.HEAD_ID = SAL_HEAD_MASTER.HEAD_ID"
        + " INNER JOIN EMP_MAIN_INF AS INBY ON INBY.EMP_ID = SAL_EMP_MONTHLY_TRAN.TRAN_BY"
        + " WHERE  SAL_EMP_STRUCT_MASTER.ES_STATUS = 1 AND SAL_EMP_MONTHLY_TRAN.TRAN_STATUS=1 AND TRAN_MONTH = " + ddlMM.SelectedValue + " AND TRAN_YEAR = " + ddlYY.SelectedValue;
        if (ddlInstitution.SelectedIndex > 0)
            str += " AND INS_ID='" + ddlInstitution.SelectedValue + "'";
        if (ddlDepartment.SelectedIndex > 0)
            str += " AND DEPT_ID='" + ddlDepartment.SelectedValue + "'";
        if (ddlEmpType.SelectedIndex > 0)
            str += " AND JOB_TYPE_ID='" + ddlEmpType.SelectedValue + "'";
        str += " ORDER BY EMP_MAIN_INF.EMP_ID";
        prbal.balData = str;
        ds = prbll.execQuery(prbal);
        gvDetail.DataSource = ds.Tables[0];
        gvDetail.DataBind();
        Total = 0;
        foreach (GridViewRow itm in gvDetail.Rows)
        {
            Total += Convert.ToDouble(itm.Cells[5].Text);
        }
        if (gvDetail.Rows.Count > 0)
            gvDetail.FooterRow.Cells[5].Text = Total.ToString("N2");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int Count = 0;string Msg = "";
        ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        strBldr.AppendFormat("<MONTH>");
       
        foreach (GridViewRow row in gvTranDetail.Rows)
        {
            Count = 1;
            txtAmount = (TextBox)row.FindControl("txtAmount");
            txtRemark = (TextBox)row.FindControl("txtRemark");
            strBldr.AppendFormat("<DATA  ES_ID=\"" + gvTranDetail.DataKeys[row.RowIndex].Values[0].ToString() + "\" HEAD_VALUE=\"" + txtAmount.Text + "\" TRAN_REMARKS= \"" + txtRemark.Text + "\"/>");
        }
        strBldr.AppendFormat("</MONTH>");
        if (Count == 1)
        {
            prbal.balHeadId = ddlHeadName.SelectedValue;
            prbal.balData = strBldr.ToString();
            prbal.balMonth = ddlMM.SelectedValue;
            prbal.balYear = ddlYY.SelectedValue;
            prbal.balCurEmpCode = Session["LoginId"].ToString();
            Msg = prbll.SalaryMonthTranInsert(prbal);
            if (Msg.Contains("successfully"))
            {
                gvTranDetail.DataSource = "";
                gvTranDetail.DataBind();
                txtData.Text = "";
                ddlHeadName.SelectedIndex = ddlInstitution.SelectedIndex = ddlDepartment.SelectedIndex = 0;
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        }
    }
    protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlHeadName, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.HeadType, ddlHeadType.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        Total = 0;
        foreach (GridViewRow itm in gvTranDetail.Rows)
        {
            txtAmount = ((TextBox)gvTranDetail.Rows[itm.RowIndex].FindControl("txtAmount"));
            Total += (txtAmount.Text != "") ? Convert.ToDouble(txtAmount.Text) : 0;

        }
        lblTotal.Text = "Total amount will deducted:-" + Total.ToString("N2");
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("MonthlyTransactionDetail.xls", gvDetail);
    }

}
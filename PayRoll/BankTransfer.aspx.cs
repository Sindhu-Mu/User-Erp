using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;

public partial class PayRoll_BankTransfer : System.Web.UI.Page
{
   
    PRBAL prbal;
    PRBLL prbll;
    StringBuilder strBldr;   
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunction;  
    DataTable dt;
    string listboxstring="";
    int count;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialisetion();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlInsitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
           
            txtPay.Text = txtSalaryMin.Text = txtSalaryMax.Text = "0";
            //  BindDetail();

        }
    }
    public override void VerifyRenderingInServerForm(Control control) //Added this for export to excel
    {
        //base.VerifyRenderingInServerForm(control);
    }
    private void Initialisetion()
    {
        prbll = new PRBLL();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunction = new CommonFunctions();
        strBldr = new StringBuilder();
        prbal = new PRBAL();
        count = 0;
    }
    private void BindDetail()
    {
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        string yy = DateTime.Now.Year.ToString();
        if (ddlYY.SelectedValue == "")
        {
            ddlMM.SelectedValue = DateTime.Now.Month.ToString();
            yy = DateTime.Now.Year.ToString();
        }
        else
            yy = ddlYY.SelectedValue;

        string salToPayMax = txtPay.Text;
        string query = "";
        if (salToPayMax == "0")
        {
            query = "SAL_PAYBALE-ISNULL(SUM(SAL_EMP_FUND_TRAN.TRAN_AMT),0)";
        }
        else
        {
            query = "CASE WHEN (SAL_PAYBALE-ISNULL(SUM(SAL_EMP_FUND_TRAN.TRAN_AMT),0))<=" + salToPayMax + " THEN (SAL_PAYBALE-ISNULL(SUM(SAL_EMP_FUND_TRAN.TRAN_AMT),0)) ELSE " + salToPayMax + " END ";
        }


        strBldr.Append("SELECT EMP_VIEW.EMP_NAME, EMP_VIEW.EMP_ID,SAL_REC_MASTER.SAL_REC_ID, SAL_REC_MASTER.SAL_REC_MONTH, SAL_REC_MASTER.SAL_REC_YEAR, "
        + " SAL_REC_MASTER.SAL_NOD,SAL_PAYBALE," + query + " AS SalToPay,ES_TOTAL_GROSS_SALARY,CONVERT(VARCHAR,SAL_REC_MONTH)+'-'+CONVERT(VARCHAR,SAL_REC_YEAR) AS MONTH,ACC_NO AS AC_NO ,'CASH PAYMENT' AS TYPE FROM SAL_REC_MASTER "
        + "  INNER JOIN SAL_EMP_STRUCT_MASTER ON SAL_REC_MASTER.ES_ID=SAL_EMP_STRUCT_MASTER.ES_ID INNER JOIN EMP_VIEW ON SAL_EMP_STRUCT_MASTER.ES_EMP_CODE = EMP_VIEW.EMP_ID  LEFT OUTER JOIN SAL_EMP_FUND_TRAN ON SAL_EMP_FUND_TRAN.REC_ID=SAL_REC_MASTER.SAL_REC_ID"
        + " GROUP BY EMP_NAME,EMP_ID,SAL_REC_MONTH,ACC_NO,ES_TOTAL_GROSS_SALARY,ES_STATUS,SAL_REC_YEAR,SAL_NOD,SAL_REC_MASTER.SAL_REC_STATUS,INS_ID,DEPT_ID,JOB_TYPE_ID,SAL_PAYBALE,SAL_EMP_FUND_TRAN.REC_ID,SAL_REC_MASTER.SAL_REC_ID"
        + "   HAVING SAL_REC_MASTER.SAL_REC_STATUS=1 AND ES_STATUS=1 AND SAL_PAYBALE-ISNULL(SUM(SAL_EMP_FUND_TRAN.TRAN_AMT),0)>0 AND SAL_REC_MONTH=" + ddlMM.SelectedValue + " AND SAL_REC_YEAR=" + yy + "");
        if (ddlInsitution.SelectedIndex > 0)
            strBldr.Append(" AND INS_ID='" + ddlInsitution.SelectedValue + "'");
        if (ddlDepartment.SelectedIndex > 0)
            strBldr.Append(" AND DEPT_ID=" + ddlDepartment.SelectedValue);
        if (ddlCategory.SelectedIndex > 0)
            strBldr.Append(" AND JOB_TYPE_ID='" + ddlCategory.SelectedValue + "'");
        if (txtSalaryMax.Text != "0")
            strBldr.Append(" AND ES_TOTAL_GROSS_SALARY BETWEEN " + txtSalaryMin.Text + " AND " + txtSalaryMax.Text + "");
        else if (txtSalaryMin.Text != "0")
        {
            strBldr.Append( " AND ES_TOTAL_GROSS_SALARY <=" + Convert.ToDouble(txtSalaryMin.Text));
            // str += " AND ES_TOTAL_GROSS_SALARY <=" +Convert.ToDouble(txtSallery.Text);
            //str += (ddlType.SelectedValue == "1") ? " AND ES_TOTAL_GROSS_SALARY>=5000" : " AND ES_TOTAL_GROSS_SALARY<5000";
        }

        foreach (ListItem item in listEmpCode.Items)
        {
            if (count > 0)
            {
                String[] emp_code = item.Text.Split(':');
                listboxstring = listboxstring + "," + emp_code[1];
            }
            else
            {
                String[] emp_code = item.Text.Split(':');
                listboxstring = emp_code[1];
                count++;
            }
        }
        if (listboxstring != "")
        {
            strBldr.Append(" OR ( EMP_VIEW.EMP_ID IN (" + listboxstring + ") AND SAL_REC_MASTER.SAL_REC_STATUS=1 AND ES_STATUS=1 AND SAL_REC_MONTH=" + ddlMM.SelectedValue + " AND SAL_REC_YEAR=" + yy + ")");
        }
        if (ddlOrder.SelectedValue.Equals("0"))
        {
            strBldr.Append(" ORDER BY EMP_ID");
        }
        else
        {
            strBldr.Append(" ORDER BY ES_TOTAL_GROSS_SALARY");
        }
        //DataTable dt = new DataTable();
        prbal.balData = strBldr.ToString();
        dt=prbll.execQuery(prbal).Tables[0];
        Session["dt"] = dt;
        if (dt.Rows.Count > 0)
        {

            divCalculateButton.Visible = true;
        }
        else
        {
            divCalculateButton.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No Records Found')", true);
        }
        GridShow.DataSource = dt;
        GridShow.DataBind();
       
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindDetail();

    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("BankTransferDetail.xls", GridShow);
    }
    protected void ddlInsitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department,ddlInsitution.SelectedValue), true, FillFunctions.FirstItem.Select);
      
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        if (ddlType.SelectedIndex > 0)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtBankDetail.aspx?" + ddlType.SelectedValue + "','_blank','alwaysRaised')", true);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        add();
        addDataToDb();
       
    }
    public void add()
    {

        XmlDocument XmlData = new XmlDocument();
        XmlElement Root;
        if (txtXML.Text != "")
        {
            XmlData.LoadXml(txtXML.Text);
            Root = XmlData.DocumentElement;
        }
        else
        {
            Root = XmlData.CreateElement("ORG");
            XmlData.AppendChild(Root);
        }

        foreach (GridViewRow row in GridShow.Rows)
        {
            CheckBox chkBx = (CheckBox)row.FindControl("chk");
            TextBox txtAmount = ((TextBox)row.FindControl("txtAmount"));
            TextBox txtRemark = ((TextBox)row.FindControl("txtRemark"));
            if (chkBx.Checked && txtAmount.Text != "0" && txtAmount.Text != " ")
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);

                XmlElement element = XmlData.CreateElement("REC_ID");
                element.InnerText = GridShow.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("TRAN_AMT");
                element.InnerText = txtAmount.Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("TRAN_BY");
                element.InnerText = Session["LoginId"].ToString();
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("TRAN_TYPE");
                element.InnerText = ddlType.SelectedValue;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("REMARKS");
                element.InnerText = txtRemark.Text;
                dataElement.AppendChild(element);




                txtXML.Text = XmlData.OuterXml;

            }
        }

    }


    public void addDataToDb()
    {
        prbal.balkeyId = txtRefNo.Text;
        prbal.balData = txtXML.Text;
        int status=prbll.BankTransferInsert(prbal);
        if (status == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientScript", "alert('Reference Number Already Present')", true);
        }
        else
        {

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientScript", "alert('Operation Successful..!')", true);
        
        }
        txtXML.Text = "";

    }
    protected void btnAddEmp_Click(object sender, EventArgs e)
    {
        String empCode = txtEmp.Text;
        if (empCode != "")
        {
            listEmpCode.Items.Add(new ListItem(empCode, empCode));
            txtEmp.Text = "";
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "ClientScript", "alert('Please Provide Code')", true);
        }
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double amt = 0;
        CheckBox chkBx = null;
        foreach (GridViewRow row in GridShow.Rows)
        {
            chkBx = (CheckBox)row.FindControl("chk");


            if (chkBx != null && chkBx.Checked)
            {
                TextBox tb = (TextBox)row.FindControl("txtAmount");
                amt = amt + Convert.ToDouble(tb.Text);
            }
        }
        if (GridShow.Rows.Count > 0)
        {
            GridShow.FooterRow.Cells[4].Text = amt.ToString("N2");
        }
    }

    protected void add_employee_CheckedChanged(object sender, EventArgs e)
    {
        if (add_employee.Checked)
        {
            add_employee_div.Visible = true;
        }
        else
        {
            add_employee_div.Visible = false;
        }
    }
   
}
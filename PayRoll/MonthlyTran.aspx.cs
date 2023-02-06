using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;

public partial class Monthly_Tran : System.Web.UI.Page
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

        // if (Convert.ToString(Session["UserName"]) == "") Response.Redirect("../common/login.aspx");

        Initialisetion();
       
        if (!IsPostBack)
        {
            

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
    protected void btnEntry_Click(object sender, EventArgs e)
    {
        trEntry.Visible = true; trDetail.Visible = false;
        BindGridData();
        change_colour();
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
        str = "SELECT EMP_ID, EMP_NAME,DEPT_VALUE,SAL_EMP_STRUCT_MASTER.ES_ID,AMOUNT=HEAD_VALUE,TRAN_REMARKS"
         + " FROM SAL_EMP_STRUCT_MASTER  INNER JOIN Emp_View ON SAL_EMP_STRUCT_MASTER.ES_EMP_CODE = Emp_View.EMP_ID"
         + " LEFT OUTER JOIN  SAL_EMP_MONTHLY_TRAN  ON SAL_EMP_STRUCT_MASTER.ES_ID = SAL_EMP_MONTHLY_TRAN.ES_ID"
         + " AND TRAN_STATUS=1 AND SAL_SUB_ID IS NULL AND TRAN_MONTH = " + ddlMM.SelectedValue + "   AND TRAN_YEAR =  " + ddlYY.SelectedValue + "  AND HEAD_ID=" + ddlHeadName.SelectedValue
         + "  WHERE ES_STATUS=1";
        if (ddlEmpType.SelectedIndex > 0)
            str += " AND JOB_TYPE_ID='" + ddlEmpType.SelectedValue + "'";
        if (txtEmp.Text != "")
            str += " AND EMP_ID=" + commonFunction.GetKeyID(txtEmp);
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
        str = "SELECT Emp_View.EMP_ID,Emp_View.EMP_NAME,DEPT_VALUE,ISNULL(SAL_EMP_MONTHLY_TRAN.HEAD_VALUE,0) AS HEAD_VALUE,HEAD_NAME,      SAL_EMP_MONTHLY_TRAN.TRAN_REMARKS, SAL_EMP_MONTHLY_TRAN.TRAN_IN_DT, EMP_VIEW.EMP_NAME AS TRAN_BY"
        + " FROM Emp_View INNER JOIN SAL_EMP_STRUCT_MASTER ON Emp_View.EMP_ID = SAL_EMP_STRUCT_MASTER.ES_EMP_CODE INNER JOIN"
        + " SAL_EMP_MONTHLY_TRAN ON SAL_EMP_STRUCT_MASTER.ES_ID = SAL_EMP_MONTHLY_TRAN.ES_ID"
       + " INNER JOIN SAL_HEAD_MASTER ON SAL_EMP_MONTHLY_TRAN.HEAD_ID = SAL_HEAD_MASTER.HEAD_ID"
        + " WHERE  SAL_EMP_STRUCT_MASTER.ES_STATUS = 1 AND SAL_EMP_MONTHLY_TRAN.TRAN_STATUS=1 AND TRAN_MONTH = " + ddlMM.SelectedValue + " AND TRAN_YEAR = " + ddlYY.SelectedValue;
        if (ddlEmpType.SelectedIndex > 0)
            str += " AND Emp_View.JOB_TYPE_ID='" + ddlEmpType.SelectedValue + "'";
        if (ddlHeadType.SelectedIndex > 0)
            str += " AND HEAD_TYPE_ID='" + ddlHeadType.SelectedValue + "'";
        if (ddlHeadName.SelectedIndex > 0)
            str += " AND SAL_HEAD_MASTER.HEAD_ID='" + ddlHeadName.SelectedValue + "'";
        if (txtEmp.Text != "")
            str += " AND Emp_View.EMP_ID=" + commonFunction.GetKeyID(txtEmp);

        str += " ORDER BY Emp_View.EMP_ID";
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
        int Count = 0; string Msg = "";
        ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        strBldr.AppendFormat("<MONTH>");
        foreach (GridViewRow row in gvTranDetail.Rows)
        {
            Count = 1;
            strBldr.AppendFormat("<DATA  ES_ID=\"" + gvTranDetail.DataKeys[row.RowIndex].Values[0].ToString() + "\" HEAD_VALUE=\"" + txtAmount.Text + "\" TRAN_REMARKS= \"" + txtRemark.Text + "\"/>");
        }
        if (Count == 1)
        {
            strBldr.AppendFormat("</MONTH>");
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
                txtEmp.Text = txtData.Text = "";
                ddlHeadName.SelectedIndex = 0;
                txtEmp.Focus();
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        }
    }
    void Add()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("MONTH");
            xmlData.AppendChild(ROOT);
        }

        foreach (GridViewRow itm in gvTranDetail.Rows)
        {
            txtAmount = ((TextBox)gvTranDetail.Rows[itm.RowIndex].FindControl("txtAmount"));
            txtRemark = ((TextBox)gvTranDetail.Rows[itm.RowIndex].FindControl("txtRemark"));
            if ((txtAmount.Text != "") && ((txtAmount.Text != gvTranDetail.DataKeys[itm.RowIndex].Values[1].ToString()) || (txtRemark.Text != gvTranDetail.DataKeys[itm.RowIndex].Values[2].ToString())))
            {
                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);
                XmlElement element = xmlData.CreateElement("ES_ID");
                element.InnerText = gvTranDetail.DataKeys[itm.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("HEAD_VALUE");
                element.InnerText = txtAmount.Text;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("TRAN_REMARKS");
                element.InnerText = txtRemark.Text;
                dataElement.AppendChild(element);
                txtData.Text = xmlData.OuterXml;
            }
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
        lblTotal.Text = Total.ToString("N2");
    }
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("MonthlyTransactionDetail.xls", gvDetail);
    }
    protected void change_colour()
    {
        foreach (GridViewRow itm in gvTranDetail.Rows)
        {
            String a = ((TextBox)gvTranDetail.Rows[itm.RowIndex].FindControl("txtAmount")).Text;
            if (a != "")
            {
                gvTranDetail.Rows[itm.RowIndex].BackColor = System.Drawing.Color.Blue;
            }
        }
    }
}
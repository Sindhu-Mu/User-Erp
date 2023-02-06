using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;

public partial class Payroll_SalEmpProfile : System.Web.UI.Page
{

    PRBAL prbal;
    PRBLL prbll;
    StringBuilder strBldr;
    TextBox txtValue;
    RadioButtonList Rlist;
    DataSet ds;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialisetion();
        btnShow.Attributes.Add("onclick", "return validation()");
       
        btnSubmit.Attributes.Add("onclick", "return validat()");
        if (!IsPostBack)
        {
            btnSubmit.Enabled = false;
            ViewState["EMPID"] = "";
            fillFunctions.Fill(ddlTemplate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TempType), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlPayScale, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PayScale), true, FillFunctions.FirstItem.Select);
           
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
   
    protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTemplate.SelectedIndex > 0)
            showDetail();
    }
    private void showDetail()
    {

        ddlPayScale.Enabled = (ddlTemplate.SelectedIndex > 1) ? true : false;
        ddlIncrement.Enabled = (ddlTemplate.SelectedIndex > 1) ? true : false;
        prbal.balTempId = ddlTemplate.SelectedValue;
        DataSet ds = new DataSet();
        ds = prbll.SalaryProfileSelect(prbal);
        gvEarnings.DataSource = ds.Tables[0];
        gvEarnings.DataBind();
        gvDeductions.DataSource = ds.Tables[1];
        gvDeductions.DataBind();
        foreach (GridViewRow itm in gvEarnings.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            txtValue = (TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue");
            Rlist = (RadioButtonList)gvEarnings.Rows[itm.RowIndex].FindControl("Rlist1");
            txtValue.Enabled = (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "3") ? true : false;
            if (ds.Tables[0].Rows[itm.RowIndex]["ED_CALCULATION"].ToString() == "False")
                Rlist.SelectedIndex = 1;
            else
                Rlist.SelectedIndex = 0;
        }
        foreach (GridViewRow itm in gvDeductions.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            txtValue = (TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue");
            Rlist = (RadioButtonList)gvEarnings.Rows[itm.RowIndex].FindControl("Rlist1");
            txtValue.Enabled = (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "3") ? true : false;
            Rlist.SelectedValue = ds.Tables[0].Rows[itm.RowIndex]["ED_CALCULATION"].ToString();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Clear();

        ViewState["EMPID"] = commonFunction.GetKeyID(txtEmp);
        prbal.balEmpCode = commonFunction.GetKeyID(txtEmp);
        if (prbll.CheckEmpStruc(prbal) != "0")
        {

            Employee1.ShowEmployeeInfo(ViewState["EMPID"].ToString());
            BindSalaryDetail(ViewState["EMPID"].ToString());
           
        }
        else
        {
            Employee1.ShowEmployeeInfo(ViewState["EMPID"].ToString());
             ddlTemplate.SelectedIndex = 0;
            

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string[] st = new string[5];
        st = ddlPayScale.SelectedItem.Text.Split('-');
        if (st.Length > 2)
        {
            //showDetail();
            strBldr.Remove(0, strBldr.Length);
            ded.InnerHtml = strBldr.ToString();
            ear.InnerHtml = strBldr.ToString();
            btnSubmit.Enabled = false;
            txtValue = (TextBox)gvEarnings.Rows[0].FindControl("txtValue");
            if (ddlIncrement.SelectedIndex > 0)
            {
                if (Convert.ToInt32(ddlIncrement.SelectedValue) < 11)
                    txtValue.Text = (Convert.ToInt32(st[0]) + (Convert.ToInt32(st[1]) * Convert.ToInt32(ddlIncrement.SelectedValue))).ToString("N2");
                if ((Convert.ToInt32(ddlIncrement.SelectedValue) - 10) > 0)
                    txtValue.Text = (Convert.ToInt32(st[2]) + (Convert.ToInt32(st[3]) * (Convert.ToInt32(ddlIncrement.SelectedValue) - 10))).ToString("N2");
            }
            else
                txtValue.Text = st[0].ToString();
        }
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {  // Earnings
        txtData.Text = ""; strBldr.Remove(0, strBldr.Length);
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("SALARY");
            xmlData.AppendChild(ROOT);
        }
        double basic = 0; double DP = 0; double GP = 0; double totalEr = 0; double pfSalary = 0; double amt = 0; double value = 0;
        prbal.balEmpCode = ViewState["EMPID"].ToString();
        int CountPf = Convert.ToInt16(prbll.GetEmpEpf(prbal));
        txtValue = (TextBox)gvEarnings.Rows[0].FindControl("txtValue");
        if (txtValue.Text != "")
        {

            strBldr.Remove(0, strBldr.Length);
            strBldr.Append("<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; font-family: Tahoma; font-size: 11px'>");
            basic = Convert.ToDouble(txtValue.Text);
            foreach (GridViewRow itm in gvEarnings.Rows)
            {

                txtValue = (TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue");
                Rlist = (RadioButtonList)gvEarnings.Rows[itm.RowIndex].FindControl("Rlist1");
                value = Convert.ToDouble(txtValue.Text);
                if (value > 0)
                {
                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);
                    if (itm.Cells[1].Text == "GRADE PAY")
                        GP = value;
                    if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "1")
                        amt = DP = (basic * value / 100);
                    else if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "4")
                        amt = ((basic + System.Math.Round(DP, 0, MidpointRounding.AwayFromZero)) * value / 100);
                    else if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "5")
                        amt = ((basic + System.Math.Round(GP, 0, MidpointRounding.AwayFromZero)) * value / 100);
                    else
                        amt = value;

                    totalEr += System.Math.Round(amt, 0, MidpointRounding.AwayFromZero);
                    strBldr.Append("<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + itm.Cells[1].Text + "</td><td height='20' width='20%' align='right' style='padding-right:20px'>" + System.Math.Round(amt, 0, MidpointRounding.AwayFromZero).ToString("N2") + "</td></tr>");
                    XmlElement element = xmlData.CreateElement("ED_HEAD_ID");
                    element.InnerText = gvEarnings.DataKeys[itm.RowIndex].Values[0].ToString();
                    dataElement.AppendChild(element);
                    element = xmlData.CreateElement("ED_HEAD_VALUE");
                    element.InnerText = amt.ToString();
                    dataElement.AppendChild(element);
                    element = xmlData.CreateElement("ED_CALCULATION");
                    element.InnerText = Rlist.SelectedValue;
                    dataElement.AppendChild(element);
                }
                value = 0;
            }
            //txtData.Text = xmlData.OuterXml;

            strBldr.Append("</table>");
            ear.InnerHtml = strBldr.ToString();
            lblTOTER.Text = System.Math.Round(totalEr, 0, MidpointRounding.AwayFromZero).ToString("N2");

            //DEDUCTIONS
            strBldr.Remove(0, strBldr.Length);
            double totalEDc = 0; amt = 0;
            strBldr.Append("<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; font-family: Tahoma; font-size: 11px; '>");
            foreach (GridViewRow itm in gvDeductions.Rows)
            {
                txtValue = (TextBox)gvDeductions.Rows[itm.RowIndex].FindControl("txtValue");
                Rlist = (RadioButtonList)gvDeductions.Rows[itm.RowIndex].FindControl("Rlist1");
                value = Convert.ToDouble(txtValue.Text);
                if (value > 0)
                {

                    if (itm.Cells[1].Text == "PROVIDENT FUND")
                    {
                        pfSalary = ((basic > 15000) && (CountPf > 0)) ? 15000 : basic;
                        if (pfSalary > 15000)
                            continue;
                        else
                            amt = ((pfSalary + System.Math.Round(DP, 0, MidpointRounding.AwayFromZero)) * value / 100);
                    }
                    else if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "1")
                        amt = (basic * value / 100);
                    else
                        amt = value;
                    totalEDc += System.Math.Round(amt, 0, MidpointRounding.AwayFromZero);
                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);
                    XmlElement element = xmlData.CreateElement("ED_HEAD_ID");
                    element.InnerText = gvDeductions.DataKeys[itm.RowIndex].Values[0].ToString();
                    dataElement.AppendChild(element);
                    element = xmlData.CreateElement("ED_HEAD_VALUE");
                    element.InnerText = amt.ToString();
                    dataElement.AppendChild(element);
                    element = xmlData.CreateElement("ED_CALCULATION");
                    element.InnerText = Rlist.SelectedValue;
                    dataElement.AppendChild(element);
                    strBldr.Append("<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + itm.Cells[1].Text + "</td><td height='20' width='20%' align='right' style='padding-right:20px'>" + System.Math.Round(amt, 0, MidpointRounding.AwayFromZero).ToString("N2") + "</td></tr>");
                }
            }
            strBldr.Append("</table>");
            ded.InnerHtml = strBldr.ToString();
            txtData.Text = xmlData.OuterXml;
            lblTOtdE.Text = System.Math.Round(totalEDc, 0, MidpointRounding.AwayFromZero).ToString("N2");
            netSal.InnerHtml = "<b>NET PAY: [A] - [B] = Rs. " + System.Math.Round((totalEr - totalEDc), 0, MidpointRounding.AwayFromZero).ToString("N2") + "";
            btnSubmit.Enabled = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('First add Sacle Information of employee then Calculate!!')", true);
            ddlPayScale.Focus();
        }
    }
    private void Clear()
    {
        txtOrderDate.Text = txtOrderNo.Text = lblScale.Text = lblTOtdE.Text = lblTOTER.Text = "";
        ddlIncrement.SelectedIndex = 0;
        //Employee1.ShowEmployeeInfo(-100);
        gvDeductions.DataSource = "";
        gvDeductions.DataBind();
        gvEarnings.DataSource = "";
        gvEarnings.DataBind();
        txtData.Text = "";
        strBldr.Remove(0, strBldr.Length);
        ded.InnerHtml = strBldr.ToString();
        ear.InnerHtml = strBldr.ToString();
        netSal.InnerHtml = strBldr.ToString();
        btnSubmit.Enabled = false;
        ViewState["PF"] = "";
       
        

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string payscale = (ddlPayScale.SelectedValue == ".") ? "0" : ddlPayScale.SelectedValue;
        string Increment = (ddlIncrement.SelectedValue == "Nill") ? "0" : ddlIncrement.SelectedValue;
        prbal.balEmpCode = ViewState["EMPID"].ToString();
        prbal.balTempId = ddlTemplate.SelectedValue;
        prbal.balPayScl = payscale;
        prbal.balIncrement = Increment;
        prbal.balRemark = "";
        prbal.balCurEmpCode = Session["LoginId"].ToString();
        string id = prbll.SalaryStrucMasterInsert(prbal);
        if (id == "-1")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Salary Structure for this employee already exists!!')", true);
        else
        {
            prbal.balEsId = id;
            prbal.balData = txtData.Text;
            prbal.balCurEmpCode = Session["LoginId"].ToString();
            prbal.balOrderNo = txtOrderNo.Text;
            prbal.balOrderDt = commonFunction.GetDateTime(txtOrderDate.Text);
            prbll.InsertSalaryStrucDetail(prbal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Salary Structure for this employee Created Successfully!!')", true);
        }
        Clear(); ddlTemplate.SelectedIndex = 0;
        txtEmp.Focus();
       
        BindSalaryDetail(ViewState["EMPID"].ToString());
    }
    void BindSalaryDetail(string EmpCode)
    {
        prbal.balEmpCode = EmpCode;
        ds = prbll.GetEmpProf(prbal);
        gvEarnings.DataSource = ds.Tables[0];
        gvEarnings.DataBind();
        ddlTemplate.SelectedValue = ds.Tables[0].Rows[0]["ES_TEMPLATE_ID"].ToString();
        double Total = 0;
        ddlPayScale.Enabled = (ddlTemplate.SelectedIndex > 1) ? true : false;
        ddlIncrement.Enabled = (ddlTemplate.SelectedIndex > 1) ? true : false;
        foreach (GridViewRow itm in gvEarnings.Rows)
        {

            Total += Convert.ToDouble(ds.Tables[0].Rows[itm.RowIndex]["HEAD_ENTRY_VALUE"]);
        }
        if (gvEarnings.Rows.Count > 0)
        {
            ViewState["ES_ID"] = ds.Tables[0].Rows[0]["ES_ID"].ToString();
            prbal.balEsId = ViewState["ES_ID"].ToString();
            ddlPayScale.SelectedValue = (ds.Tables[0].Rows[0]["ES_PAY_SCALE"].ToString() != "0") ? ds.Tables[0].Rows[0]["ES_PAY_SCALE"].ToString() : ".";
            ddlIncrement.SelectedValue = ds.Tables[0].Rows[0]["ES_WITH_INCREMENT"].ToString();
            gvEarnings.FooterRow.Cells[2].Text = Total.ToString("N2");
        }
        gvDeductions.DataSource = ds.Tables[1];
        gvDeductions.DataBind();
        Total = 0;
        foreach (GridViewRow itm in gvDeductions.Rows)
        {
            Total += Convert.ToDouble(ds.Tables[1].Rows[itm.RowIndex]["HEAD_ENTRY_VALUE"]);
        }
        if (gvDeductions.Rows.Count > 0)
            gvDeductions.FooterRow.Cells[2].Text = Total.ToString("N2");

    }

   
}



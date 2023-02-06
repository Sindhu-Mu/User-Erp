using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;
using System.IO;
public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        btnShow.Attributes.Add("onClick", "return valid()");
        btnModeAdd.Attributes.Add("OnClick", "return Cashvalidat()");
        if (!IsPostBack)
        {

            trRefDetail.Visible = false;
            ViewState["TotalAmt"] = "0";
            LoadData();
            btnRefund.Visible = false;
            
        }
       
        
    }
    void LoadData()
    {
        glb_ff.Fill(ddlSemester, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlAcountNo, glb_qf.GetCommand(QueryFunctions.QueryBaseType.AcNo), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlBank, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Bank), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlBank, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Bank), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(RlistMode, glb_qf.GetCommand(QueryFunctions.QueryBaseType.PayMode), true);
        RlistMode.Items[0].Selected = true;

    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        double TotalFee = 0;
        Student.ShowStudent(txtEnrollment.Text);
        if (ddlBranch.Items.Count == 0)
        {
            glb_ff.Fill(ddlBranch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.StuBranch, txtEnrollment.Text), true, FillFunctions.FirstItem.Select);
            ddlBranch.SelectedIndex = 1;
        }
        balObj.balEnrol=txtEnrollment.Text;
        balObj.balSem=ddlSemester.SelectedValue;
        balObj.balBatchId=ddlBranch.SelectedValue;
        DataSet ds = bllObj.StudentFeeToRefund(balObj);
    
        if (ds.Tables.Count > 0)
        {
            gvFees.DataSource = ds;
            gvFees.DataBind();

               
            foreach (GridViewRow itm in gvFees.Rows)
            {
                TotalFee += Convert.ToDouble(itm.Cells[1].Text);
                gvFees.FooterRow.Cells[1].Text = TotalFee.ToString("N2");


            }
         }
    }
    
    protected void btnModeAdd_Click(object sender, EventArgs e)
    {
        double PayTotal = 0;
        foreach (GridViewRow itm in gvFees.Rows)
        {
            CheckBox chk = (CheckBox)itm.FindControl("chk1");
            if (chk.Checked)
                PayTotal += Convert.ToDouble(itm.Cells[1].Text);
        }
        gvFees.FooterRow.Cells[2].Text = PayTotal.ToString("N2");
        Add();
        txtBranchName.Text = txtDate.Text = txtRefNo.Text =  "";
        RlistMode.SelectedIndex = ddlBank.SelectedIndex = ddlAcountNo.SelectedIndex = 0;
        trRefDetail.Visible = false;
        btnRefund.Visible = true;
        //if (gvFees.FooterRow.Cells[2].Text == gvRefDetail.FooterRow.Cells[5].Text)
        //    btnRefund.Visible = true;
        //else
        //    btnRefund.Visible = false;
    }

    protected void RlistMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblRefType.Text = RlistMode.SelectedItem.Text + " No.";
        if (RlistMode.SelectedIndex == 0)
        {
            trRefDetail.Visible = false;
            btnModeAdd.Attributes.Add("OnClick", "return Cashvalidat()");
        }
        else if (RlistMode.SelectedIndex == 7)
        {
            trRefDetail.Visible = false;
            btnModeAdd.Attributes.Add("OnClick", "return Cashvalidat()");
        }
        else
        {
            trRefDetail.Visible = true;
            btnModeAdd.Attributes.Add("OnClick", "return Othervalidat()");
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
            ROOT = xmlData.CreateElement("MODE");
            xmlData.AppendChild(ROOT);
        }
        XmlNodeList nodeList = xmlData.SelectNodes("MODE/DATA/PAY_MODE_ID");
        XmlNodeList nodeList1 = xmlData.SelectNodes("MODE/DATA/FEE_RFD_MODE_NO");
        for (int i = 0; i < nodeList.Count; i++)
        {
            if ((nodeList[i].InnerText == RlistMode.SelectedValue) && (nodeList1[i].InnerText == txtRefNo.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Reference no detail already inserted!!')", true);
                return;
            }
        }
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("PAY_MODE_ID");
        element.InnerText = RlistMode.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("PAY_MODE");
        element.InnerText = RlistMode.SelectedItem.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_RFD_MODE_NO");
        element.InnerText = (txtRefNo.Text == "") ? "0" : txtRefNo.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_RFD_MODE_DT");
        element.InnerText = (txtDate.Text == "") ? DateTime.Now.ToString() : Convert.ToDateTime(txtDate.Text).ToString();
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_RFD_MODE_AMT");
        element.InnerText = txtModeAmount.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_RFD_TO_BANK");
        element.InnerText = (ddlBank.SelectedIndex == 0) ? "0" : ddlBank.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("BANK");
        element.InnerText = (ddlBank.SelectedIndex == 0) ? "0" : ddlBank.SelectedItem.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_RFD_TO_BRANCH");
        element.InnerText = (txtBranchName.Text == "") ? "Non" : txtBranchName.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("BANK_AC_ID");
        element.InnerText = (ddlAcountNo.SelectedIndex == 0) ? "0" : ddlAcountNo.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_RFD_TO_AC_NO");
        element.InnerText = (ddlAcountNo.SelectedIndex == 0) ? "0" : ddlAcountNo.SelectedItem.Text;
        dataElement.AppendChild(element);
        txtData.Text = xmlData.OuterXml;
        ddlAcountNo.SelectedIndex = ddlBank.SelectedIndex = RlistMode.SelectedIndex = 0;
        txtDate.Text = txtBranchName.Text = txtRefNo.Text = "";
        AddXmlData(Convert.ToDouble(txtModeAmount.Text));
    }

    void AddXmlData(double TotalFee)
    {
        if (txtData.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtData.Text));
            gvRefDetail.DataSource = dataSet.Tables[0];
            gvRefDetail.DataBind();
            TotalFee = Convert.ToDouble(ViewState["TotalAmt"].ToString()) + TotalFee;
            if (gvRefDetail.Rows.Count > 0)
                gvRefDetail.FooterRow.Cells[5].Text = TotalFee.ToString("N2");
            ViewState["TotalAmt"] = TotalFee;

        }
        else
        {
            gvRefDetail.DataSource = null;
            gvRefDetail.DataBind();
            ViewState["TotalAmt"] = 0;

        }
    }

    protected void gvRefDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("MODE/DATA");
        XmlNodeList nodeList1 = xmlData.SelectNodes("MODE/DATA/FEE_RFD_MODE_AMT");
        double AMT = Convert.ToDouble(nodeList1[e.RowIndex].InnerText);
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
           txtData.Text = xmlData.OuterXml;

        
        else
          txtData.Text = "";
        AddXmlData(-AMT);
        //lblRefType.Text=Convert.ToDouble(nodeList1[e.RowIndex].InnerText).ToString();
        
            btnRefund.Visible = true;

    }


    protected void btnRefund_Click(object sender, EventArgs e)
    {
        double Total = 0;
        double RefundAmt = 0;
        double Amt = 0;
          Total = Convert.ToDouble(gvFees.FooterRow.Cells[2].Text);
          RefundAmt=  Convert.ToDouble(txtModeAmount.Text);
          if (Total >= RefundAmt)
            //gvRefDetail.FooterRow.Cells[5].Text)
            {
           // try
            //{
                string FeeRfdTranID = "";
                double txtAmount;
                foreach (GridViewRow itm in gvFees.Rows)
                {
                    CheckBox chk = (CheckBox)itm.FindControl("chk1");
                    if (chk.Checked)
                    {
                        Amt = Convert.ToDouble(itm.Cells[1].Text);
                        txtAmount = Amt;
                            //Convert.ToDouble(txtModeAmount.Text);
                            //Convert.ToDouble(itm.Cells[1].Text);
                        balObj.balMainHeadId=gvFees.DataKeys[itm.RowIndex].Values[1].ToString();
                        balObj.balDemandId=gvFees.DataKeys[itm.RowIndex].Values[0].ToString();
                        balObj.balAmt=txtAmount.ToString();
                        balObj.balReason="Refund";
                        balObj.balCurUser=Session["UserId"].ToString();
                        FeeRfdTranID = bllObj.FeeRefundInsert(balObj);
                    }
                }
                if (FeeRfdTranID != "")
                {
                    balObj.balCommonID=FeeRfdTranID;
                    balObj.balData=txtData.Text;
                    bllObj.FeeRefundModeInsert(balObj);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtFeeRefundSlip.aspx?=" + FeeRfdTranID + "','_blank','scrollbars=1')", true);
                }
                txtData.Text = txtEnrollment.Text = txtModeAmount.Text="";
                ddlSemester.SelectedIndex = 0;
                gvFees.DataSource = "";
                gvFees.DataBind();
                gvRefDetail.DataSource = "";
                ViewState["TotalAmt"] = "0";
                gvRefDetail.DataBind();
                txtEnrollment.Focus();
                btnRefund.Visible = false;
            //}
            //catch
            //{
            //}
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected amount and refund amount are not equal.')", true);

    }
}
    
       


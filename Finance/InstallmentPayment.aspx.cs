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
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    int pay = 0;
    int percent = 0;
    float Amount;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {
            fillfunction.Fill(ddlSem,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Sem),true, FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlGroupHead,queryfunction.GetCommand(QueryFunctions.QueryBaseType.GroupHeadId),true,FillFunctions.FirstItem.Select);
            ViewState["pay"] = "0";
            btnAdd.Enabled = true;
            btnInsert.Visible = false;
        }
       
        
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
       balObj.balEnrol = txtEnroll.Text;
       Student.ShowStudent(txtEnroll.Text);
       balObj.balAmt = txtAmt.Text;
       if (ddlAmtPer.SelectedValue == "0")
       {
           txtInstall.Text = balObj.balAmt;
       }
       else
       { 
            
       }
       if (ddlBranch.Items.Count == 0)
       {
           fillfunction.Fill(ddlBranch,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Branch,txtEnroll.Text),true,FillFunctions.FirstItem.Select);
       }
    }
    protected void btnShowAmount_Click(object sender, EventArgs e)
    {
     
    }
    protected void ddlGroupHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlGroupHead.SelectedIndex>0)
        {
            balObj.balEnrol = txtEnroll.Text;
            balObj.balFeeGroupHeadId = ddlGroupHead.SelectedValue;
            pay =bllObj.GetAmount(balObj);
            if (pay == 0)
            {
                btnAdd.Enabled = false;
            }
            else
            {
                btnAdd.Enabled = true;
            }
            ViewState["pay"] = pay;
            lblHeadAmt.Text = pay.ToString();
        }
    }
    protected void ddlAmtPer_SelectedIndexChanged(object sender, EventArgs e)
    {
        balObj.balAmt = txtAmt.Text;

        if (ddlAmtPer.SelectedValue == "0")
        {
            txtInstall.Text = balObj.balAmt;
        }
        if(ddlAmtPer.SelectedValue == "1")
        {
            pay = Convert.ToInt32(ViewState["pay"].ToString()); 
            percent = Convert.ToInt32(txtAmt.Text);
            Amount = (pay * percent) / 100;
            txtInstall.Text = Amount.ToString();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        btnInsert.Visible = true;
        addItem();
        Clear();
    }
    public void addItem()
    {
        XmlDocument XmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtXML.Text != "")
        {
            XmlData.LoadXml(txtXML.Text);
            ROOT = XmlData.DocumentElement;
        }
        else
        {
            ROOT = XmlData.CreateElement("INSTALL");
            XmlData.AppendChild(ROOT);
        }

        XmlElement dataElement = XmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);

        XmlElement element = XmlData.CreateElement("GROUP_HEAD");
        element.InnerText = ddlGroupHead.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("GROUP_HEAD_NAME");
        element.InnerText = ddlGroupHead.SelectedItem.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("HEAD_AMOUNT");
        element.InnerText = lblHeadAmt.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("AMT_OR_PER");
        element.InnerText = txtAmt.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("INSTALLMNT_TYPE");
        element.InnerText = ddlAmtPer.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("INSTALLEMT_AMT");
        element.InnerText = txtInstall.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("IN_DATE");
        element.InnerText = txtDate.Text;
        dataElement.AppendChild(element);
        txtXML.Text = XmlData.OuterXml;
        AddItemData();
           
    }

    public void AddItemData()
    {
        if (txtXML.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtXML.Text));
            gvShow.DataSource = dataSet.Tables[0];
            gvShow.DataBind();

        }
        else
        {
            gvShow.DataSource = null;
            gvShow.DataBind();
        }
    
    
    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
     
        balObj.balData = txtXML.Text;
        balObj.balEnrol = txtEnroll.Text;
        balObj.balSem = ddlSem.SelectedValue;
        //balObj.balBranch = ddlBranch.SelectedValue;
        balObj.balSession = Session["UserId"].ToString();
        bllObj.InstallmentPaymentInsert(balObj);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Installment Inserted.')", true);
        
    }

    public void Clear()
    {
        ddlAmtPer.SelectedIndex = 0;
        ddlGroupHead.SelectedIndex = 0;
        txtAmt.Text = "";
        txtDate.Text = "";
        txtInstall.Text = "";
    
    }
    protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("INSTALL/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtXML.Text = xmlData.OuterXml;
        else
            txtXML.Text = "";
        AddItemData();
    }
}
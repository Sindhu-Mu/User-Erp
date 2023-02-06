using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

public partial class Inventory_itemGatePass : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            other1.Visible = false;
            other2.Visible = false;
            ddlSupp.Visible = true;
            txtOtherRecpt.Visible = false;
            txtItem.Visible = false;
            txtOthrSender.Visible = false;
            fillFunctions.Fill(ddlSupp, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TotlItem), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    protected void gvItemDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtxml.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ADD/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtxml.Text = xmlData.OuterXml;
        else
        {
            txtxml.Text = "";
        }
       string msg = "One item delete from list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        AddItemData();
    }
    void AddItemData()
    {

        if (txtxml.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtxml.Text));
            gvItemDetail.DataSource = dataSet.Tables[0];
            gvItemDetail.DataBind();

        }
        else
        {
            gvItemDetail.DataSource = null;
            gvItemDetail.DataBind();
        }
        Clear();
        txtItem.Focus();
    }
    private void Clear()
    {
        
        txtItem.Text = txtQty.Text = txtRemark.Text = "";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Add();
        txtItem.Text = "";
        txtQty.Text = "";
        txtRemark.Text = "";

    }
    public void Add()
    {
        XmlDocument xmlData = new XmlDocument();


        XmlElement ROOT;
        if (txtxml.Text != "")
        {
            xmlData.LoadXml(txtxml.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("ADD");
            xmlData.AppendChild(ROOT);
        }

        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);

        XmlElement element0 = xmlData.CreateElement("ITEM_TYPE");
         element0.InnerText = ddlItemType.SelectedValue;
        dataElement.AppendChild(element0);

        XmlElement element = xmlData.CreateElement("ITEM");
        if (ddlItemType.SelectedValue == "1")
        {
            element.InnerText = ddlItem.SelectedItem.Text;
        }
        else
        {
            element.InnerText = txtItem.Text;
        }
        dataElement.AppendChild(element);

        XmlElement element01 = xmlData.CreateElement("UNIT");
        element01.InnerText = txtUnit.Text;
        dataElement.AppendChild(element01);

        XmlElement element1 = xmlData.CreateElement("QTY");
        element1.InnerText = txtQty.Text;
        dataElement.AppendChild(element1);

        XmlElement element2 = xmlData.CreateElement("REMARK");
        element2.InnerText = txtRemark.Text;
        dataElement.AppendChild(element2);

        XmlElement element4 = xmlData.CreateElement("SENDER_TYPE");
            element4.InnerText = ddlSenderType.SelectedValue;
        dataElement.AppendChild(element4);


        XmlElement element3 = xmlData.CreateElement("SENDER");
        if (ddlSenderType.SelectedValue == "1")
        {
            element3.InnerText = txtSender.Text;
        }
        else
        {
            element3.InnerText = txtOthrSender.Text;
        }
        dataElement.AppendChild(element3);
        txtxml.Text = xmlData.OuterXml;
        AddXmlData();

    }
    public void AddXmlData()
    {
        if (txtxml.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtxml.Text));
            gvItemDetail.DataSource = dataSet.Tables[0];
            gvItemDetail.DataBind();
        }
        else
        {
            gvItemDetail.DataSource = null;
            gvItemDetail.DataBind();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        objBal.TypeId=ddlType.SelectedValue;
        objBal.ActionBy = ddlEmp_type.SelectedValue;
        if (ddlEmp_type.SelectedValue == "1")
        {
            objBal.KeyId = commonFunctions.GetKeyID(txtEmp);
        }
        else {
            objBal.KeyId = "0";
        }
        objBal.Name = txtOther.Text;
        objBal.Description = txtDesc.Text;
        objBal.ItemName = txtxml.Text;
        objBal.Typ = ddlRecpt.SelectedValue;
        if (ddlRecpt.SelectedValue == "1")
        {
            objBal.VenId = ddlSupp.SelectedValue;
        }
        else
        {
            objBal.VenId = "0";
           objBal.OrgName=txtOtherRecpt.Text;
        }
       
      
        if (ddlType.SelectedValue == "1")
        {
            objBal.ToDate = txtRtnDate.Text;
        }
        else
        {
            objBal.ToDate = "NULL";
        }
        objBal.SessionUserId = Session["UserId"].ToString();
        string s = objBll.GatePass(objBal).Tables[0].Rows[0][0].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtGatePass.aspx?id=" + s + "',alwaysraised='yes')", true);
        clearControls();
       
    }
    void clearControls()
    {
        txtEmp.Text = txtOther.Text = txtDesc.Text = txtItem.Text = txtQty.Text = txtRemark.Text =  txtRtnDate.Text = "";

        txtxml.Text = "";
        gvItemDetail.DataSource = "";
        gvItemDetail.DataBind();
       
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlType.SelectedValue == "1")
        {
            rDt1.Visible = true;
            rDt2.Visible = true;
        }
        else
        {
            rDt1.Visible = false;
            rDt2.Visible = false;
        }
    }
    protected void ddlEmp_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlEmp_type.SelectedValue == "1")
        {
            EmpUniv1.Visible = true;
            EmpUniv2.Visible = true;
            other1.Visible = false;
            other2.Visible = false;
        }
        else
        {
            EmpUniv1.Visible = false;
            EmpUniv2.Visible = false;
            other1.Visible = true;
            other2.Visible = true;
        }
    }
    protected void ddlRecpt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRecpt.SelectedValue == "1")
        {
            ddlSupp.Visible = true;
            txtOtherRecpt.Visible = false;
        }
        else
        {
            ddlSupp.Visible = false;
            txtOtherRecpt.Visible = true;
        }
    }
  
    protected void ddlSenderType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSenderType.SelectedValue == "1")
        {
            txtSender.Visible = true;
            txtOthrSender.Visible = false;
        }
        else
        {
            txtSender.Visible = false;
            txtOthrSender.Visible = true;
        }
    }
 
    protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlItemType.SelectedValue == "1")
        {
            ddlItem.Visible = true;
            txtItem.Visible = false;
        }
        else
        {
            ddlItem.Visible = false;
            txtItem.Visible = true;
        }
    }
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtUnit.Text = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UNIT, ddlItem.SelectedValue));
    }
}
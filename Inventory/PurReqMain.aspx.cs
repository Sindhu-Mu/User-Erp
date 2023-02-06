using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
public partial class Purchase_PurReqMain : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataSet ds;
    string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAdd.Attributes.Add("OnClick", "return validateAdd()");
        if (!IsPostBack)
        {
            step1.ActiveTabIndex = 0;
           
            ViewState["ds"] = ds;
            ViewState["REQ_ID"] = "";
            pushData();
            btnSave.Visible = false;
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
        ds = new DataSet();

    }
    void pushData()
    {
        fillFunctions.Fill(ddl_Category, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddl_Store, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddl_Vendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddl_Status, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Req_Status), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddl_RequestNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.Select);
    }

    protected void ddl_Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Category.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddl_SubCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubCategory, ddl_Category.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddl_SubCategory.Focus();
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddl_Category);
        }
    }
    protected void ddl_SubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_SubCategory.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddl_Item, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item, ddl_SubCategory.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddl_Item.Focus();
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddl_Item);
        }
    }
    protected void ddl_Item_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Item.SelectedIndex > 0)
        {
            ddl_Vendor.Focus();
        }
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            
            fillFunctions.Fill(ddl_Category, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddl_Store, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddl_Vendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
            txtJst.Text = txtQuantity.Text = txtRate.Text = txtRemark.Text = txtXML.Text = "";
            commonFunctions.Clear(gvItemDetail); btnUpdate.Visible = false; btnAdd.Visible = true;
           
        }
        else if (step1.ActiveTabIndex == 1)
        {
            commonFunctions.Clear(gvRequest);
            fillFunctions.Fill(ddl_Status, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Req_Status), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddl_RequestNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.Select);            
            Bind_GVRequest();                  
            txtXML.Text = "";
        }

    }
    void Bind_GVRequest()
    {
        commonFunctions.Clear(gvRequestItem);
        objBal.KeyId = ddlStore.SelectedValue;
        objBal.Date = ddl_Year.SelectedValue;
        objBal.PurNo = ddl_RequestNo.SelectedValue;
        objBal.Status = ddl_Status.SelectedValue;
        ds= objBll.getPurchaseRequisition(objBal);
        ViewState["ds"] = ds;
        gvRequest.DataSource = ds.Tables[0];
        gvRequest.DataBind();
    }
    protected void ddl_RequestNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_RequestNo.SelectedIndex > 0)
        {
            ddl_Year.SelectedIndex = 0;
            ddl_Status.SelectedValue = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.STATUS, ddl_RequestNo.SelectedItem.ToString()));
            Bind_GVRequest();
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddl_Status);
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddl_Year);
        }
    }
    private void ShowItemData(DataTable dt)
    {
        StringWriter writer = new StringWriter();
        dt.WriteXml(writer);
        string xmlString = writer.GetStringBuilder().ToString();
        xmlString = xmlString.Replace("<NewDataSet>", "<ORDER>");
        xmlString = xmlString.Replace("</NewDataSet>", "</ORDER>");
        xmlString = xmlString.Replace("<Table2>", "<DATA>");
        xmlString = xmlString.Replace("</Table2>", "</DATA>");
        txtXML.Text = xmlString;
        AddItemData();

    }
    protected void gvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ds = (DataSet)ViewState["ds"];
        ViewState["REQ_ID"] = gvRequest.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        DataTable dt = ds.Tables[1];
        dt.DefaultView.RowFilter = "PUR_REQ_ID=" + ViewState["REQ_ID"].ToString();
        dt = dt.DefaultView.ToTable();
        if (e.CommandName == "Select")
        {
          
            DataRow[] dr = ds.Tables[0].Select("PUR_REQ_ID=" + ViewState["REQ_ID"].ToString() + "");
            fillFunctions.Fill(ddl_Store, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
            ddl_Store.SelectedValue = dr[0]["STO_ID"].ToString();
            fillFunctions.Fill(ddl_Vendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor, ddl_Store.SelectedValue), true, FillFunctions.FirstItem.Select);
            txtRemark.Text = dr[0]["REMARK"].ToString();          
            ShowItemData(dt);
            step1.ActiveTabIndex = TabPanel2.TabIndex;
            btnUpdate.Visible = true;
            btnSave.Visible = false;
        }
        else
        {         
            gvRequestItem.DataSource = dt;
            gvRequestItem.DataBind();

        }
    }
    protected void ddl_Status_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Status.SelectedIndex > 0)
        {
            ddl_RequestNo.SelectedIndex = 0;
            Bind_GVRequest();

        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddl_RequestNo);
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ViewState["REQ_ID"].ToString();
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.PurNo = generatePurReqNo();
        objBal.ID = ddl_Store.SelectedValue;
        objBal.Remark = txtRemark.Text;
        objBal.Status = "-2";
        objBal.OrderData = txtXML.Text;
        string msg = objBll.PurchaseRequisitionInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        txtXML.Text = "";
        btnSave.Visible = false;
        commonFunctions.Clear(gvItemDetail); 
        clear();
       
    }
    string generatePurReqNo()
    {
        string strPurReqId;
       SqlDataReader dr = objBll.GetFinancialYear();
        if (dr.Read())
            strPurReqId = "PR/" + CommonFunctions.getFinancialYear() + "/" + dr[0].ToString();
        else
            strPurReqId = "PR/" + CommonFunctions.getFinancialYear() + "/01";
        return strPurReqId;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        objBal.ItemId = ddl_Item.SelectedValue;
        objBal.Quantity = txtQuantity.Text;
        objBal.Rate = txtRate.Text;
        objBal.Justification = txtJst.Text;
        objBal.VenId = ddl_Vendor.SelectedValue;
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.PurNo = ddl_RequestNo.SelectedItem.ToString();
        objBal.ID = ddl_Store.SelectedValue;
        objBal.Status = "-2";
        objBal.Remark = txtRemark.Text;
        string msg = objBll.PurchaseRequisitionInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        clear();
    }
    void addItem()
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
            Root = XmlData.CreateElement("ORDER");
            XmlData.AppendChild(Root);
        }
        XmlNodeList nodeList = XmlData.SelectNodes("ORDER/DATA/ITEM_NAME");
        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i].InnerText == ddl_Item.SelectedItem.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Item is already inserted!!')", true);
                return;
            }
        }
        XmlElement dataElement = XmlData.CreateElement("DATA");
        Root.AppendChild(dataElement);
        XmlElement element = XmlData.CreateElement("ITEM_ID");
        element.InnerText = ddl_Item.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("ITEM_NAME");
        element.InnerText = ddl_Item.SelectedItem.Text;
        dataElement.AppendChild(element);   

        element = XmlData.CreateElement("REQ_ITEM_QTY");
        element.InnerText = txtQuantity.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_ITEM_RATE");
        element.InnerText = txtRate.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_JUSTIFICATION");
        element.InnerText = txtJst.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("VENDOR_ID");
        element.InnerText = ddl_Vendor.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("ORG_NAME");
        element.InnerText = ddl_Vendor.SelectedItem.Text;
        dataElement.AppendChild(element);
        element = XmlData.CreateElement("REQ_ITEM_AMOUNT");
        element.InnerText = (Convert.ToDouble(txtQuantity.Text) * Convert.ToDouble(txtRate.Text)).ToString("N2");
        dataElement.AppendChild(element);
        txtXML.Text = XmlData.OuterXml;
        AddItemData();
    }
    void AddItemData()
    {

        if (txtXML.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtXML.Text));
            gvItemDetail.DataSource = dataSet.Tables[0];
            gvItemDetail.DataBind();
        }
        else
        {
            gvItemDetail.DataSource = null;
            gvItemDetail.DataBind();
        }
    }
    protected void btnAdd_Click1(object sender, EventArgs e)
    {

        addItem();
        msg = "Item added to List";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        clear();
        if (txtXML.Text != "")
        {
            btnSave.Visible = true;
        }
        ddl_Category.Focus();
    }

    protected void gvItemDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ORDER/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtXML.Text = xmlData.OuterXml;
        else
        {
            txtXML.Text = "";
        }
        msg = "One item delete from list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        AddItemData();
    }
    protected void ddl_Store_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Store.SelectedIndex > 0)
        {
            ddl_Category.Focus();
        }
    }
    protected void ddl_Vendor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Vendor.SelectedIndex > 0)
        {
            txtQuantity.Focus();
        }
    }
    protected void ddl_Year_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Year.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddl_RequestNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.Select);
            Bind_GVRequest();

        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddl_RequestNo);
        }

    }
    void clear()
    {
        ddl_Item.SelectedIndex = ddl_Category.SelectedIndex = ddl_SubCategory.SelectedIndex = ddl_Vendor.SelectedIndex = 0;
        txtJst.Text = txtQuantity.Text = txtRate.Text = txtRemark.Text = "";
        //commonFunctions.Clear(gvItemDetail); 
        btnUpdate.Visible = false; btnAdd.Visible = true;
    }
  
    protected void btnView_Click(object sender, EventArgs e)
    {
        Bind_GVRequest();
    }
    protected void gvRequest_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}
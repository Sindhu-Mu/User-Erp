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
public partial class Purchase_Req_Master : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    SqlDataReader dr;
    string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            step1.ActiveTabIndex = 0;
            btnAdd.Attributes.Add("OnClick", "return validateAdd()");
            Session["STORE_ID"] = "1";
            ViewState["dt"] = "";
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
        dt = new DataTable();

    }
    void pushData()
    {
        fillFunctions.Fill(ddl_Category, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddl_Store, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
        //fillFunctions.Fill(ddl_Vendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.VendorName), true, FillFunctions.FirstItem.Select);
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
            //fillFunctions.Fill(ddl_Vendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.VendorName), true, FillFunctions.FirstItem.Select);
            if ((ddl_RequestNo.SelectedIndex = ddl_RequestNo.SelectedIndex) == 0)
            {
                ddl_Store.SelectedIndex = ddl_Category.SelectedIndex = ddl_Vendor.SelectedIndex = 0;
                txtQuantity.Text = txtRate.Text = txtJst.Text = txtRemark.Text = "";
            }
        }
        else if (step1.ActiveTabIndex == 1)
        {
            fillFunctions.Fill(ddl_Status, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Req_Status), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddl_RequestNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.Select);
            ddl_Year.SelectedIndex = 0;
            if (ddl_RequestNo.SelectedIndex > 0)
            {
                Bind_GVRequest();
            }
            commonFunctions.Clear(gvRequest);
            btnAdd.Visible = false;
            txtXML.Text = "";
        }

    }
    void Bind_GVRequest()
    {
        objBal.Typ = "0";
        if (ddl_Year.SelectedIndex > 0)
        {
            objBal.Typ = "3";
        }
        if (ddl_RequestNo.SelectedIndex > 0)
        {
            objBal.Typ = "1";
        }
        else if (ddl_Status.SelectedIndex > 0)
        {
            objBal.Typ = "2";
        }
        objBal.Date = ddl_Year.SelectedValue;
        objBal.PurNo = ddl_RequestNo.SelectedItem.ToString();
        objBal.Status = ddl_Status.SelectedValue;
        ViewState["dt"] =objBll.getPurchaseRequisition(objBal).Tables[0];
        gvRequest.DataSource = ViewState["dt"];
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
    protected void gvRequest_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        ViewState["REQ_ID"] = gvRequest.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        DataSet ds = (DataSet)ViewState["dt"];
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("PUR_REQ_ID=" + ViewState["REQ_ID"].ToString() + "");
        fillFunctions.Fill(ddl_Store, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
        ddl_Store.SelectedValue = dr[0]["STO_ID"].ToString();
        fillFunctions.Fill(ddl_Category, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
        ddl_Category.SelectedValue = dr[0]["CAT_ID"].ToString();
        fillFunctions.Fill(ddl_SubCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubCategory, ddl_Category.SelectedValue), true, FillFunctions.FirstItem.Select);
        ddl_SubCategory.SelectedValue = dr[0]["SUB_CAT_ID"].ToString();
        fillFunctions.Fill(ddl_Item, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.Select);
        ddl_Item.SelectedValue = dr[0]["ITEM_ID"].ToString();
        //fillFunctions.Fill(ddl_Vendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.VendorName), true, FillFunctions.FirstItem.Select);
        ddl_Vendor.SelectedValue = dr[0]["VENDOR_ID"].ToString();
        txtQuantity.Text = dr[0]["REQ_ITEM_QTY"].ToString();
        txtRate.Text = dr[0]["REQ_ITEM_RATE"].ToString();
        txtJst.Text = dr[0]["REQ_JUSTIFICATION"].ToString();
        txtRemark.Text = dr[0]["REQ_REMARK"].ToString();
        step1.ActiveTabIndex = TabPanel2.TabIndex;
        btnUpdate.Visible = true;
        btnSave.Visible = false;
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
        objBal.Status = "-2";
        objBal.OrderData = txtXML.Text;
        string msg = objBll.PurchaseRequisitionInsertUpdate(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        clear();
        ddl_Store.SelectedIndex = 0;
        commonFunctions.Clear(gvItemDetail);
    }
    string generatePurReqNo()
    {
        string strPurReqId;
        dr = objBll.GetFinancialYear();
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

        XmlElement element = XmlData.CreateElement("PUR_REQ_ID");
        element.InnerText = ViewState["REQ_ID"].ToString();
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_ITEM_NAME");
        element.InnerText = ddl_Item.SelectedItem.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_ITEM_ID");
        element.InnerText = ddl_Item.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_ITEM_QTY");
        element.InnerText = txtQuantity.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_ITEM_RATE");
        element.InnerText = Convert.ToDecimal(txtRate.Text).ToString();
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_JUSTIFICATION");
        element.InnerText = txtJst.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_SUPP_ID");
        element.InnerText = ddl_Vendor.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_SUPP_NAME");
        element.InnerText = ddl_Vendor.SelectedItem.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_BY");
        element.InnerText = Session["UserId"].ToString();
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_REMARK");
        element.InnerText = txtRemark.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("REQ_ITEM_AMOUNT");
        element.InnerText = (Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text)).ToString("N2");
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
    }

    protected void btnView_Click(object sender, EventArgs e)
    {

    }
}
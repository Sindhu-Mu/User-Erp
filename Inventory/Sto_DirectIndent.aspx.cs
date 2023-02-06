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
public partial class Inventory_Sto_DirectIndent : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;  
    int id;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Initialize();
        btnAdd.Attributes.Add("onClick", "return validateBtnAdd()");
        btnSave.Attributes.Add("onClick", "return validateBtnSave()");
        
        if (!IsPostBack)
        {
            ViewState["dt"] = dt;
            pushData();
        }
    }
    void pushData()
    {
        objBal.SessionUserId = Session["UserId"].ToString();
        fillFunctions.Fill(ddlReceivingAs, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IND_BY_TYPE), true, FillFunctions.FirstItem.Select);
        objBal.Typ = "1";
        fillFunctions.Fill(ddlStore, objBll.GetStore(objBal), true, FillFunctions.FirstItem.Select);
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
    protected void ddlReceivingAs_SelectedIndexChanged1(object sender, EventArgs e)
    {

        if (ddlReceivingAs.SelectedIndex > 0)
        {
            objBal.ID = ddlReceivingAs.SelectedValue;      
            objBal.SessionUserId = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Usr_id, commonFunctions.GetKeyID(txtEmpId)));
            fillFunctions.Fill(ddlReceivingAs, ddlLocation, objBll.GetDepartmentLocation(objBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlLocation);
    }
    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
            fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DirIndStore_Item, ddlStore.SelectedValue), true, FillFunctions.FirstItem.Select);

        else
            commonFunctions.Clear(ddlItem);
        if (txtData.Text.Length > 0)
        {
            txtData.Text = "";
            LoadItemData();
        }
    }
    void AddNewItem()
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
            ROOT = xmlData.CreateElement("ITEM");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;

        foreach (XmlNode node in xmlData.SelectNodes("ITEM/DATA/ITEM_ID"))
        {
            if (node.InnerText == ddlItem.SelectedValue)
            {
                msg = "Item entry already exists";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
                add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("ITEM_ID");
            element.InnerText = ddlItem.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ITEM_VALUE");
            element.InnerText = ddlItem.SelectedItem.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("REQ_QTY");
            element.InnerText = txtReqQuantity.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("APR_QTY");
            element.InnerText = txtAprQuantity.Text;
            dataElement.AppendChild(element);
            txtData.Text = xmlData.OuterXml;

        }
        LoadItemData();
    }
    void LoadItemData()
    {
        if (txtData.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtData.Text));
            gridItems.DataSource = dataSet.Tables[0];
            gridItems.DataBind();
            btnSave.Enabled = true;
        }
        else
        {
            commonFunctions.Clear(gridItems);
            btnSave.Enabled = false;
        }
    }
    protected void gridItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ITEM/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
            txtData.Text = "";
        LoadItemData();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddNewItem();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objBal.SessionUserId = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Usr_id, commonFunctions.GetKeyID(txtEmpId)));
        objBal.StoreName = ddlStore.SelectedValue;
        objBal.IndId = ddlReceivingAs.SelectedValue;
        objBal.ID = ddlLocation.SelectedValue;
        objBal.State = "4";
        objBal.Status = "21";
        objBal.Remark = txtRemark.Text;
        objBal.OrderData = txtData.Text;
        msg = objBll.NewIndent(objBal);
        Clear();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        id =Convert.ToInt32(objBll.GetIndId(objBal));
        Response.Redirect("DirectSIVMain.aspx?=" + id);
    }
    void Clear()
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlStore, ddlReceivingAs);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlItem);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlLocation);
        txtEmpId.Text= txtReqQuantity.Text= txtAprQuantity.Text= txtData.Text= txtRemark.Text="";
    }

   
}
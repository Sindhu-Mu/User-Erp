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
using System.Drawing;

public partial class Inventory_IndentMain : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    string msg;
    DataTable dt;
    DatabaseFunctions databaseFunctions;
    void Initialize()
    {
        databaseFunctions = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        dt = new DataTable();


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAdd.Attributes.Add("onClick", "return validateBtnAdd()");
        if (!IsPostBack)
        {
            step1.ActiveTabIndex = 1;
            btnSave.Enabled = false;
            fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Status_Ind), true, FillFunctions.FirstItem.All);
            objBal.Typ = "1";
            objBal.SessionUserId = Session["UserId"].ToString();
            ddlStatus.SelectedValue = "1";
            objBal.Status = ddlStatus.SelectedValue;
            fillFunctions.Fill(gvIndent, objBll.GetIndentProgress(objBal));
        }
    }
    protected void ddlReceivingAs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlReceivingAs.SelectedIndex > 0)
        {
            objBal.ID = ddlReceivingAs.SelectedValue;
            objBal.SessionUserId = Session["UserId"].ToString();
            fillFunctions.Fill(ddlReceivingAs, ddlLocation, objBll.GetDepartmentLocation(objBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlLocation);

    }
    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
            fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.StoreItemForIndent, ddlStore.SelectedValue), true, FillFunctions.FirstItem.Select);

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
            element.InnerText = txtQuantity.Text;
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
    void Clear()
    {    
        txtQuantity.Text = txtData.Text = txtRemark.Text = "";
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlStore, ddlReceivingAs);
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlItem);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlLocation);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        AddNewItem();
        txtQuantity.Text = "";      
        ddlItem.SelectedIndex = 0;
        ddlItem.Focus();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        objBal.Typ = "1";
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.StoreName = ddlStore.SelectedValue;
        string[] flag = objBll.BtnSelect(objBal);
        objBal.State = flag[0].ToString();
        objBal.Status = flag[1].ToString();
        objBal.IndId = ddlReceivingAs.SelectedValue;
        objBal.ID = ddlLocation.SelectedValue;
        objBal.Remark = txtRemark.Text;
        objBal.OrderData = txtData.Text;
        msg = objBll.NewIndent(objBal);
        if (msg.Contains("successfully"))
        {
            Clear();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);

    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {

            fillFunctions.Fill(ddlReceivingAs, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IND_BY_TYPE), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlStore, objBll.GetStore(objBal), true, FillFunctions.FirstItem.Select);
        }
        else if (step1.ActiveTabIndex == 1)
        {
            fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Status_Ind), true, FillFunctions.FirstItem.All);
            ddlStatus.SelectedValue = "1";
            objBal.SessionUserId = Session["UserId"].ToString();
            objBal.Status = ddlStatus.SelectedValue;
            fillFunctions.Fill(gvIndent, objBll.GetIndentProgress(objBal));
        }
    }
    protected void gvIndent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        foreach (GridViewRow row in gvIndent.Rows)
        {
            row.BackColor = Color.Transparent;
            row.Enabled = true;
        }

        gvIndent.Rows[index].BackColor = Color.Yellow;
        gvIndent.Rows[index].Enabled = false;

        objBal.IndId = gvIndent.DataKeys[index].Value.ToString();
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.Typ = "2";


        DataSet dataSet = objBll.GetIndentDetails(objBal);

        fillFunctions.Fill(gvIndentDetails, dataSet.Tables[0]);
        fillFunctions.Fill(gvTransactionDetails, dataSet.Tables[1]);
        fillFunctions.Fill(gvReceiving, dataSet.Tables[2]);
        fillFunctions.Fill(gvIssue, dataSet.Tables[3]);
    }


    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
            objBal.SessionUserId = Session["UserId"].ToString();
            objBal.Status = ddlStatus.SelectedValue;
            fillFunctions.Fill(gvIndent, objBll.GetIndentProgress(objBal));
            gvIndentDetails.DataSource = gvTransactionDetails.DataSource = gvReceiving.DataSource = gvIssue.DataSource = "";
            gvIndentDetails.DataBind();
            gvTransactionDetails.DataBind();
            gvReceiving.DataBind();
            gvIssue.DataBind();
        
    }
}
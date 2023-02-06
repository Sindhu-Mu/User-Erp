using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class Inventory_GrnMain : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;
    Messages Msg;
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        btnSave.Attributes.Add("onClick", "return validate()");
        if (!IsPostBack)
        {
            ViewState["dt"] = dt;
            pushData();
        }
    }
    void pushData()
    {
        fillFunctions.Fill(ddlPurchaseOrder, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurOrder, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlReceivedBy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sto_Rcv_By), true, FillFunctions.FirstItem.Select);
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
        Msg = new Messages();
    }
    protected void ddlPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
    {
        objBal.ID = ddlPurchaseOrder.SelectedValue;
        if (ddlPurchaseOrder.SelectedIndex > 0)
            fillFunctions.Fill(gridPurchaseDetails, objBll.GetGRNDetails(objBal).Tables[0]);
        else
            commonFunctions.Clear(gridPurchaseDetails);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT = xmlData.CreateElement("ITEM");
        xmlData.AppendChild(ROOT);

        XmlElement dataElement;
        XmlElement element;

        string quantity = null, rate = null;
        foreach (GridViewRow row in gridPurchaseDetails.Rows)
        {
            quantity = ((TextBox)row.FindControl("txtQuantity")).Text;
            rate = ((TextBox)row.FindControl("txtRate")).Text;
            if (quantity != "0")
            {
                dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                element = xmlData.CreateElement("ITEM_ID");
                element.InnerText = gridPurchaseDetails.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("QTY");
                element.InnerText = quantity;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("RATE");
                element.InnerText = rate;
                dataElement.AppendChild(element);
            }
        }
        try
        {
            objBal.ID = ddlPurchaseOrder.SelectedValue;
            objBal.ReqNo = generateGRNNo();
            objBal.Description = txtGrnDetails.Text;
            objBal.Date = commonFunctions.GetDateTime(txtDate.Text).ToShortDateString();
            objBal.ActionBy = ddlReceivedBy.SelectedValue;
            objBal.Rate = txtExtraCharges.Text;
            objBal.SessionUserId = Session["UserId"].ToString();
            objBal.OrderData = xmlData.OuterXml;
            objBal.AcNo = txtChallanNo.Text;
            objBal.Service_Tax_No = txtBillNo.Text;
            objBal.Identification = objBll.InsertGRN(objBal);
            Clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtStoGrnDetails.aspx?GRN_ID=" + objBal.Identification + "')", true);

        }
        catch
        {
            msg = Msg.GetMessage(Messages.DataMessType.Error);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        }


    }
    string generateGRNNo()
    {
        string strGRNNo;
        dr = objBll.GetGRNFinancialYear();
        if (dr.Read())
            strGRNNo = "GRN/" + CommonFunctions.getFinancialYear() + "/" + dr[0].ToString();
        else
            strGRNNo = "GRN/" + CommonFunctions.getFinancialYear() + "/01";
        return strGRNNo;
    }
    void Clear()
    {
        ddlReceivedBy.SelectedIndex = ddlPurchaseOrder.SelectedIndex = 0;
        gridPurchaseDetails.DataSource = txtBillNo.Text = txtChallanNo.Text = txtDate.Text = txtGrnDetails.Text = "";
        gridPurchaseDetails.DataBind();
        txtExtraCharges.Text = "0";
        //UpdatePanel3.Update();
    }
}
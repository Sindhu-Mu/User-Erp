﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Inventory_GatePass_Returnable : System.Web.UI.Page
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

            pushData();
        }
    }
    void pushData()
    {
        fillFunctions.Fill(ddlGatePass, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Gate_Pass_Rcv), true, FillFunctions.FirstItem.Select);
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
    protected void ddlGatePass_SelectedIndexChanged(object sender, EventArgs e)
    {
        objBal.ID = ddlGatePass.SelectedValue;
        if (ddlGatePass.SelectedIndex > 0)
            fillFunctions.Fill(gridRtrnGatePass, objBll.GetRtnGatePass(objBal).Tables[0]);
        else
            commonFunctions.Clear(gridRtrnGatePass);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT = xmlData.CreateElement("ITEM");
        xmlData.AppendChild(ROOT);

        XmlElement dataElement;
        XmlElement element;

        string quantity = null;
        foreach (GridViewRow row in gridRtrnGatePass.Rows)
        {
            quantity = ((TextBox)row.FindControl("txtQuantity")).Text;
            if (quantity != "0")
            {
                dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                element = xmlData.CreateElement("ITEM_ID");
                element.InnerText = gridRtrnGatePass.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("QTY");
                element.InnerText = quantity;
                dataElement.AppendChild(element);
            }
        }
        try
        {
            objBal.ID = ddlGatePass.SelectedValue;
            objBal.ReqNo = generateRtnGatePassNo();
            objBal.Description = txtGAtePassDetails.Text;
            objBal.Date = commonFunctions.GetDateTime(txtDate.Text).ToShortDateString();
            objBal.ActionBy = commonFunctions.GetKeyID(txtRcvBy);
            objBal.SessionUserId = Session["UserId"].ToString();
            objBal.OrderData = xmlData.OuterXml;
            objBal.AcNo = txtChallanNo.Text;
            objBal.Service_Tax_No = txtBillNo.Text;
            objBal.Identification = objBll.InsertRtnGatePass(objBal);
            Clear();
            // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtStoGrnDetails.aspx?GRN_ID=" + objBal.Identification + "')", true);

        }
        catch
        {
            msg = Msg.GetMessage(Messages.DataMessType.Error);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        }

    }
    string generateRtnGatePassNo()
    {
        string strRtnGatePassNo;
        dr = objBll.GetRtnPassFinancialYear();
        if (dr.Read())
            strRtnGatePassNo = "RTN_GPASS/" + CommonFunctions.getFinancialYear() + "/" + dr[0].ToString();
        else
            strRtnGatePassNo = "RTN_GPASS/" + CommonFunctions.getFinancialYear() + "/01";
        return strRtnGatePassNo;
    }
    void Clear()
    {
        ddlGatePass.SelectedIndex = 0;
        gridRtrnGatePass.DataSource = txtBillNo.Text = txtChallanNo.Text = txtDate.Text = txtGAtePassDetails.Text = "";
        gridRtrnGatePass.DataBind();
    }
}
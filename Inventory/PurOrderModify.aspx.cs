using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;
public partial class Inventory_PurOrderModify : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    String msg;
    DataTable dt;
    DatabaseFunctions databaseFunctions;
    double dis = 0;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        dt = new DataTable();
        databaseFunctions = new DatabaseFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ds"] = "";
            ViewState["Total"] = "";
            ViewState["dis"] = "";
            ViewState["net"] = "";
            objBal.Typ = "2";
            objBal.SessionUserId = Session["UserId"].ToString();
            fillFunctions.Fill(ddlStore, objBll.GetStore(objBal), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlPO, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.POMod), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSupplier, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlTerm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurTerm), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPO, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.POModify, ddlStore.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlPO_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPO.SelectedIndex > 0)
        {
            objBal.ID = ddlPO.SelectedValue;
            DataSet ds = objBll.ModifyPurOrder(objBal);
            ViewState["ds"] = ds;
            DataRow dr = ds.Tables[0].Rows[0];
            ddlSupplier.SelectedValue = dr["PO_SUPP_CODE"].ToString();
            ddlDis.SelectedIndex = 1;
            txtRefNo.Text = dr["PO_REF_NO"].ToString();
            lblDate.Text = dr["PO_DATE"].ToString();
            txtOther.Text = dr["PO_OTHER_CHARGES"].ToString();
            txtDiscount.Text = dr["PO_DISCOUNT"].ToString();
            lblNetAmount.Text = dr["PO_AMOUNT"].ToString();
            fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store_Item, ddlStore.SelectedValue), true, FillFunctions.FirstItem.Select);
            ShowItemData(ds.Tables[1]);
            ShowPaymentData(ds.Tables[2]);
            ShowTermData(ds.Tables[3]);
        }
    }

    #region Item
    private void ShowItemData(DataTable dt)
    {
        StringWriter writer = new StringWriter();
        dt.WriteXml(writer);
        string xmlString = writer.GetStringBuilder().ToString();
        xmlString = xmlString.Replace("<DocumentElement>", "<ORDER>");
        xmlString = xmlString.Replace("</DocumentElement>", "</ORDER>");
        xmlString = xmlString.Replace("<Table1>", "<DATA>");
        xmlString = xmlString.Replace("</Table1>", "</DATA>");
        txtXML.Text = xmlString;
        AddItemData();

    }
    void AddItemData()
    {

        if (txtXML.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtXML.Text));
            ViewState["dt"]=gvItemDetail.DataSource = dataSet.Tables[0];
            gvItemDetail.DataBind();

        }
        else
        {
            gvItemDetail.DataSource = null;
            gvItemDetail.DataBind();
        }
        int slno = 0;
        double grandTotal = 0;
        foreach (GridViewRow row in gvItemDetail.Rows)
        {
            slno++;
            row.Cells[0].Text = slno.ToString();
            Label lblNetAmt = (Label)row.FindControl("lblNetAmt");
            grandTotal = grandTotal + Convert.ToDouble(lblNetAmt.Text);
        }
        GridViewRow footer = gvItemDetail.FooterRow;
        footer.Cells[7].Text = grandTotal.ToString();

        if (gvItemDetail.Rows.Count > 0)
        {
            double NetAmount = Convert.ToDouble(gvItemDetail.FooterRow.Cells[7].Text);
            if ((txtDiscount.Text != "") && (ddlDis.SelectedIndex > 0))
            {
                if ((ddlDis.SelectedIndex == 2) && (Convert.ToDouble(txtDiscount.Text) > 99))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('In Case of % Discount total value should not greater then 99.!!')", true);
                    txtDiscount.Text = "";
                    txtDiscount.Focus();
                    return;
                }
                ViewState["dis"] = dis = (ddlDis.SelectedIndex == 1) ? Convert.ToDouble(txtDiscount.Text) : (Convert.ToDouble(txtDiscount.Text) * NetAmount) / 100;
                ViewState["net"] = NetAmount = NetAmount - dis;
            }
            if (txtOther.Text != "")
            {
                ViewState["net"] = NetAmount = NetAmount + Convert.ToDouble(txtOther.Text);
            }
            lblNetAmount.Text = NetAmount.ToString("N2");
        }
    }
    protected void gvItemDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        double qty = 0, rate = 0, tax = 0, disc = 0, netAmt = 0, amt = 0;
        //DataSet ds = (DataSet)ViewState["ds"];
        DataTable dt = (DataTable)ViewState["dt"];
        GridViewRow row = gvItemDetail.Rows[e.RowIndex];
        if ((Convert.ToDouble(dt.Rows[e.RowIndex]["QTY"]) != Convert.ToDouble(((TextBox)row.FindControl("txtQty")).Text)) ||
                (Convert.ToDouble(dt.Rows[e.RowIndex]["RATE"]) != Convert.ToDouble(((TextBox)row.FindControl("txtPrice")).Text)) ||
                (Convert.ToDouble(dt.Rows[e.RowIndex]["TAX"]) != Convert.ToDouble(((TextBox)row.FindControl("txtTax")).Text)) ||
                (Convert.ToDouble(dt.Rows[e.RowIndex]["DISCOUNT"]) != Convert.ToDouble(((TextBox)row.FindControl("txtDis")).Text))
               )
        {
            ddlPO.Enabled = false;

            qty = Convert.ToDouble(((TextBox)row.FindControl("txtQty")).Text);
            rate = Convert.ToDouble(((TextBox)row.FindControl("txtPrice")).Text);
            disc = Convert.ToDouble(((TextBox)row.FindControl("txtDis")).Text);
            tax = Convert.ToDouble(((TextBox)row.FindControl("txtTax")).Text);
            row.Cells[4].Text = Convert.ToDouble(qty * rate).ToString("N2");
            amt = qty * rate;
            netAmt = rate - (rate * disc / 100);
            netAmt = netAmt + (netAmt * tax / 100);
            netAmt *= qty;
            dt.Rows[e.RowIndex]["QTY"] = qty.ToString();
            dt.Rows[e.RowIndex]["RATE"] = rate.ToString();
            dt.Rows[e.RowIndex]["TAX"] = tax.ToString();
            dt.Rows[e.RowIndex]["DISCOUNT"] = disc.ToString();

            dt.Rows[e.RowIndex]["AMOUNT"] = amt.ToString();
            dt.Rows[e.RowIndex]["NET_AMOUNT"] = netAmt.ToString();

        }
        gvItemDetail.EditIndex = -1;
        ShowItemData(dt);

    }
    protected void gvItemDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvItemDetail.EditIndex = e.NewEditIndex;
        ShowItemData((DataTable)ViewState["dt"]);
    }
    protected void gvItemDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvItemDetail.EditIndex = -1;
        ShowItemData((DataTable)ViewState["dt"]);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
         dt = (DataTable)ViewState["dt"];
        addItem();
        objBal.PurNo = ddlPO.SelectedValue;
        objBal.VenId = ddlSupplier.SelectedValue;
        objBal.ReqNo = txtRefNo.Text;
        objBal.Tax = txtOther.Text;
        objBal.Discount = ViewState["dis"].ToString();
        objBal.Amount = ViewState["net"].ToString();
        objBal.Remark = txtRemark.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.OrderData = txtXML.Text;
        objBal.PaymentData = txtPay.Text;
        objBal.TermData = txtTerm.Text;
        objBll.UpdatePurOrder(objBal);
        gvItemDetail.EditIndex = -1; 
        ShowItemData((DataTable)ViewState["dt"]);
        ItmClear();
        msg = "Item added to List";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }
    void addItem()
    {
        double rate, tax, dis, total, qty;
        ViewState["net"] = (ViewState["net"].ToString() == "") ? 0 : Convert.ToDouble(ViewState["net"]);
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

        XmlNodeList nodeList = XmlData.SelectNodes("ORDER/Table1/ITEM_NAME");

        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i].InnerText == ddlItem.SelectedItem.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Item is already inserted!!')", true);
                return;
            }
        }

        XmlElement dataElement = XmlData.CreateElement("DATA");
        Root.AppendChild(dataElement);

        XmlElement element = XmlData.CreateElement("ITEM_ID");
        element.InnerText = ddlItem.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("ITEM_NAME");
        element.InnerText = ddlItem.SelectedItem.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("UNIT");
        element.InnerText = txtUnit.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("QTY");
        element.InnerText = txtQty.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("RATE");
        element.InnerText = txtrate.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("TAX");
        element.InnerText = txtTax.Text;
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("DISCOUNT");
        element.InnerText = txtdisc.Text;
        dataElement.AppendChild(element);

        qty = Convert.ToDouble(txtQty.Text);
        rate = Convert.ToDouble(txtrate.Text);
        total = (qty * rate);
        tax = Convert.ToDouble(txtTax.Text);
        dis = Convert.ToDouble(txtdisc.Text);
        total = rate - (rate * dis / 100);
        total = total + (total * tax / 100);
        total = (total < 0) ? 0 : total * qty;

        element = XmlData.CreateElement("AMOUNT");
        element.InnerText = Convert.ToDecimal(total).ToString();
        dataElement.AppendChild(element);

        
        ViewState["net"] = Convert.ToDouble(ViewState["net"]) + total;
        element = XmlData.CreateElement("NET_AMOUNT");
        element.InnerText = total.ToString();
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("SPECIFICATION");
        element.InnerText = txtSpecification.Text.Trim(' ');
        dataElement.AppendChild(element);

        txtXML.Text = XmlData.OuterXml;
        AddItemData();

    }
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlItem.SelectedIndex > 0)
        {


            dt = (DataTable)ViewState["dt"]; ;
            DataRow[] drow = dt.Select("ITEM_ID='" + ddlItem.SelectedValue + "'");
            if (drow.Length > 0)
            {
                txtQty.Text = drow[0]["REQ_ITEM_QTY"].ToString();
                txtrate.Text = Convert.ToDouble(drow[0]["REQ_ITEM_RATE"]).ToString();
            }

            ViewState["dt"] = dt;
            txtQty.Focus();
            txtUnit.Text = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UNIT, ddlItem.SelectedValue));

        }
    }

    private void ItmClear()
    {
        txtQty.Text = txtrate.Text = txtUnit.Text = txtSpecification.Text = "";
        txtdisc.Text = txtTax.Text = "0";
    }
    #endregion
    #region Payment
    private void ShowPaymentData(DataTable dt)
    {
        StringWriter writer = new StringWriter();
        dt.WriteXml(writer);
        string xmlString = writer.GetStringBuilder().ToString();
        xmlString = xmlString.Replace("<NewDataSet>", "<PAYMENT>");
        xmlString = xmlString.Replace("</NewDataSet>", "</PAYMENT>");
        xmlString = xmlString.Replace("<Table2>", "<DATA>");
        xmlString = xmlString.Replace("</Table2>", "</DATA>");
        txtPay.Text = xmlString;
        AddPaymentData();

    }
    void AddPaymentData()
    {

        if (txtPay.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtPay.Text));
            if (dataSet.Tables[0].Rows.Count > 1)
            {
                gvPayment.DataSource = dataSet.Tables[0];
                gvPayment.DataBind();
            }

        }
        else
        {
            gvPayment.DataSource = null;
            gvPayment.DataBind();
        }


    }

    void addPayment()
    {

        ViewState["Total"] = (ViewState["Total"].ToString() == "") ? 0 : Convert.ToInt32(ViewState["Total"]);
        foreach (GridViewRow row in gvPayment.Rows)
        {
            ViewState["Total"] = Convert.ToInt32(ViewState["Total"]) + Convert.ToInt32(row.Cells[2].Text);

        }
        XmlDocument XmlPayment = new XmlDocument();
        XmlElement RootPayment;
        if (txtPay.Text != "")
        {
            XmlPayment.LoadXml(txtPay.Text);
            RootPayment = XmlPayment.DocumentElement;
        }
        else
        {
            RootPayment = XmlPayment.CreateElement("PAYMENT");
            XmlPayment.AppendChild(RootPayment);
        }
        XmlNodeList nodeList = XmlPayment.SelectNodes("PAYMENT/DATA/PO_ON");
        XmlNodeList nodeList1 = XmlPayment.SelectNodes("PAYMENT/DATA/PO_PAY_AT");


        if (Convert.ToInt32(txtPayment.Text) > 100)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Payment percentage!!')", true);
            return;
        }

        ViewState["Total"] = Convert.ToInt32(ViewState["Total"]) + Convert.ToInt32(txtPayment.Text);

        for (int i = 0; i < nodeList1.Count; i++)
        {

            if ((nodeList1[i].InnerText == ddlPayment.SelectedValue) || ((Convert.ToInt32(ViewState["Total"])) > 100))
            {
                ViewState["Total"] = Convert.ToInt32(ViewState["Total"]) - Convert.ToInt32(txtPayment.Text);
                msg = "Invalid payment condition.";
                txtPayDay.Text = txtPayment.Text = "";
                ddlPayment.SelectedIndex = 0;
                ddlPayment.Focus();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
                return;
            }
        }
        XmlElement dataElement = XmlPayment.CreateElement("DATA");
        RootPayment.AppendChild(dataElement);

        XmlElement element = XmlPayment.CreateElement("PO_ON");
        element.InnerText = ddlPayment.SelectedValue;
        dataElement.AppendChild(element);


        element = XmlPayment.CreateElement("PO_PAY_PER");
        element.InnerText = txtPayment.Text;
        dataElement.AppendChild(element);

        element = XmlPayment.CreateElement("PO_PAY_DAY");
        element.InnerText = txtPayDay.Text;
        dataElement.AppendChild(element);

        element = XmlPayment.CreateElement("PO_PAY_AT");
        element.InnerText = ddlPayment.SelectedItem.Text;
        dataElement.AppendChild(element);

        txtPay.Text = XmlPayment.OuterXml;
        AddPaymentData();

    }




    protected void btnPayAdd_Click(object sender, EventArgs e)
    {
        addPayment();
        txtPayDay.Text = txtPayment.Text = "";
        ddlPayment.SelectedIndex = 0;
        ddlPayment.Focus();
        msg = "Payment Condition added to List";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }
    protected void gvPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ViewState["Total"] = (ViewState["Total"].ToString() == "") ? 0 : Convert.ToInt32(ViewState["Total"]);
        foreach (GridViewRow row in gvPayment.Rows)
        {
            ViewState["Total"] = Convert.ToInt32(ViewState["Total"]) + Convert.ToInt32(row.Cells[2].Text);

        }
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtPay.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PAYMENT/DATA");
        XmlNodeList nodeList1 = xmlData.SelectNodes("PAYMENT/DATA/PO_PAY_PER");
        double amt = Convert.ToDouble(nodeList1[e.RowIndex].InnerText);
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtPay.Text = xmlData.OuterXml;
        else
        {
            txtPay.Text = "";
        }
        ViewState["Total"] = Convert.ToDouble(ViewState["Total"]) - amt;
        msg = "One payment condition delete from list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        AddPaymentData();
    }
    #endregion

    #region Term
    private void ShowTermData(DataTable dt)
    {
        StringWriter writer = new StringWriter();
        dt.WriteXml(writer);
        string xmlString = writer.GetStringBuilder().ToString();
        xmlString = xmlString.Replace("<NewDataSet>", "<TERM>");
        xmlString = xmlString.Replace("</NewDataSet>", "</TERM>");
        xmlString = xmlString.Replace("<Table3>", "<DATA>");
        xmlString = xmlString.Replace("</Table3>", "</DATA>");
        txtTerm.Text = xmlString;
        AddTermData();

    }
    void AddTermData()
    {

        if (txtTerm.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtTerm.Text));
            gvTermCondition.DataSource = dataSet.Tables[0];
            gvTermCondition.DataBind();

        }
        else
        {
            gvTermCondition.DataSource = null;
            gvTermCondition.DataBind();
        }


    }
    void addTerm()
    {
        XmlDocument XmlTerm = new XmlDocument();
        XmlElement RootTerm;
        if (txtTerm.Text != "")
        {
            XmlTerm.LoadXml(txtTerm.Text);
            RootTerm = XmlTerm.DocumentElement;
        }
        else
        {
            RootTerm = XmlTerm.CreateElement("TERM");
            XmlTerm.AppendChild(RootTerm);
        }
        XmlNodeList nodeList = XmlTerm.SelectNodes("TERM/DATA/PUR_TERM");
        XmlNodeList nodeList1 = XmlTerm.SelectNodes("TERM/DATA/PUR_TERM_CONDITION");
        for (int i = 0; i < nodeList.Count; i++)
        {
            if ((nodeList[i].InnerText == ddlTerm.SelectedItem.Text) || (nodeList1[i].InnerText == txtCondition.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Term Has Already Been Enetered !!')", true);

                return;
            }
        }
        XmlElement dataElement = XmlTerm.CreateElement("DATA");
        RootTerm.AppendChild(dataElement);

        XmlElement element = XmlTerm.CreateElement("TERM_ID");
        element.InnerText = ddlTerm.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlTerm.CreateElement("PUR_TERM");
        element.InnerText = ddlTerm.SelectedItem.Text;
        dataElement.AppendChild(element);

        element = XmlTerm.CreateElement("PUR_TERM_CONDITION");
        element.InnerText = txtCondition.Text;
        dataElement.AppendChild(element);

        txtTerm.Text = XmlTerm.OuterXml;
        AddTermData();

    }

    protected void gvTermCondition_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtTerm.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("TERM/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtTerm.Text = xmlData.OuterXml;
        else
        {
            txtTerm.Text = "";
        }
        msg = "One term condition delete from list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        AddTermData();
    }
    protected void btnTermAdd_Click(object sender, EventArgs e)
    {
        addTerm();
        txtCondition.Text = "";
        ddlTerm.SelectedIndex = 0;
        msg = "One Term & Condition added to List";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }
    #endregion



    protected void ddlDis_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (gvItemDetail.Rows.Count > 0)
        {
            double NetAmount = Convert.ToDouble(gvItemDetail.FooterRow.Cells[7].Text);
            if ((txtDiscount.Text != "") && ddlDis.SelectedIndex > 0)
            {
                if ((ddlDis.SelectedIndex == 2) && (Convert.ToDouble(txtDiscount.Text) > 99))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('In Case of % Discount total value should not greater then 99.!!')", true);
                    txtDiscount.Text = "";
                    txtDiscount.Focus();
                    return;
                }
                ViewState["dis"] = dis = (ddlDis.SelectedIndex == 1) ? Convert.ToDouble(txtDiscount.Text) : (Convert.ToDouble(txtDiscount.Text) * NetAmount) / 100;
                ViewState["net"] = NetAmount = NetAmount - dis;
            }
            if (txtOther.Text != "")
            {
                ViewState["net"] = NetAmount = NetAmount + Convert.ToDouble(txtOther.Text);
            }
             lblNetAmount.Text = NetAmount.ToString("N2");
        }
    }
    #region Modify
    protected void btnModify_Click(object sender, EventArgs e)
    {
        objBal.PurNo = ddlPO.SelectedValue;
        objBal.VenId = ddlSupplier.SelectedValue;
        objBal.ReqNo = txtRefNo.Text;
        objBal.Tax = txtOther.Text;
        objBal.Discount = ViewState["dis"].ToString();
        objBal.Amount = ViewState["net"].ToString();
        objBal.Remark = txtRemark.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.OrderData = txtXML.Text;
        objBal.PaymentData = txtPay.Text;
        objBal.TermData = txtTerm.Text;
        objBll.UpdatePurOrder(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prntPurOrder.aspx?id=" + objBal.PurNo + "',alwaysraised='yes')", true);
        clear();
    }
    #endregion
    private void clear()
    {
        ddlStore.SelectedIndex = ddlPO.SelectedIndex = ddlSupplier.SelectedIndex = ddlDis.SelectedIndex = ddlPayment.SelectedIndex = ddlTerm.SelectedIndex = 0;
        txtCondition.Text = txtDiscount.Text = txtOther.Text = txtPay.Text = txtPayDay.Text = txtPayment.Text = txtRefNo.Text = txtRemark.Text = txtTerm.Text = txtXML.Text = "";
        lblDate.Text = lblFAN.Text = lblNetAmount.Text = lblPayMsg.Text = lblPUR.Text = lblTermMsg.Text = "";
        gvItemDetail.DataSource = gvPayment.DataSource = gvTermCondition.DataSource = "";
        gvItemDetail.DataBind();
        gvPayment.DataBind();
        gvTermCondition.DataBind();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTerm.SelectedIndex > 0)
        {
            AutoComExt1.ContextKey = ddlTerm.SelectedValue;
        }
    }

    protected void gvItemDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objBal.PurNo = ddlPO.SelectedValue;
        objBal.TypeId = gvItemDetail.DataKeys[e.RowIndex].Value.ToString();
        objBll.DeletePurOrderDetail(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('One term condition delete from list')", true);
    }
}
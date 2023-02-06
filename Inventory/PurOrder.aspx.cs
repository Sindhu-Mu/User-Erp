using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Xml;
using System.IO;
public partial class Inventory_PurOrder : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    StringBuilder strBill;
    INVBAL objBal;
    INVBLL objBll;
    DataTable dt;
    string msg, strPoID;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        btnAdd.Attributes.Add("onClick", "return validate()");
        btnPayAdd.Attributes.Add("onClick", "return validatPay()");
        btnTermAdd.Attributes.Add("onClick", "return validat()");
        cmdSubmit.Attributes.Add("onclick", "return validateDate()");
        this.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            ViewState["dt"] = dt;
            ViewState["NETAMOUNT"] = "";
            ViewState["Total"] = "";
            pushData();
            thQuot.Visible = tdQuot.Visible = trTerm.Visible = false;
        }
    }
    void pushData()
    {
        fillFunctions.Fill(ddlPurReq, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PO_PurReqNo), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item_Store, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSupp, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlTerm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurTerm), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlCat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);

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
        strBill = new StringBuilder();
        if (ddlRef.SelectedItem.ToString() == "Quotation")
        {
            thQuot.Visible = tdQuot.Visible = true;
        }
    }
    protected void btnPurchaseReq_Click(object sender, EventArgs e)
    {
        trPurReq.Visible = true;
        btnPurchaseReq.BackColor = Color.Gray;
        btnDirect.BackColor = Color.Green;
        clearControls();
    }
    protected void btnDirect_Click(object sender, EventArgs e)
    {
        trPurReq.Visible = false;
        btnDirect.BackColor = Color.Gray;
        btnPurchaseReq.BackColor = Color.Green;
        trPurReq.Visible = false;
        clearControls();
        pushData();
    }
    #region clear
    void clearControls()
    {
        ddlStore.Enabled = true;
        ddlPurReq.SelectedIndex = ddlStore.SelectedIndex = ddlSupp.SelectedIndex = ddlDis.SelectedIndex = ddlRef.SelectedIndex = 0;
        Clear();
        lblPurDate.Text = lblDept.Text = lblFANAMT.Text = lblFanDate.Text = "";
        txtdiscount.Text = txtOtherCharges.Text = lblNetAmount.Text = "0";
        txtCondition.Text = txtPayDay.Text = "";
        gvItemDetail.DataSource = "";
        gvItemDetail.DataBind();
        gvPayment.DataSource = gvTermCondition.DataSource = "";
        gvPayment.DataBind();
        gvTermCondition.DataBind();
        gvTermCondition.DataSource = "";
        cmdSubmit.Enabled = false;
        txtXML.Text = txtPay.Text = txtTerm.Text = txtrefNo.Text = txtremark.Text = "";
        ViewState["NETAMOUNT"] = ViewState["Total"] = "";
        tdQuot.Visible = thQuot.Visible = false;
        trTerm.Visible = false;
    }
    private void Clear()
    {
        txtTax.Text = txtdisc.Text = "0";
        txtSpecification.Text = txtrate.Text = txtQty.Text = "";
    }
    #endregion
    #region ddlIndexChanged
    protected void ddlPurReq_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlItem.Items.Clear();
        ddlStore.Items.Clear();
        if (ddlPurReq.SelectedIndex > 0)
        {

            ddlSupp.SelectedIndex = 0;
            lblFANAMT.Text = lblFanDate.Text = lblPurDate.Text = lblDept.Text = "";
            fillFunctions.Fill(ddlFAN, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FanNo, ddlPurReq.SelectedValue), true, FillFunctions.FirstItem.Select);
            objBal.PurNo = ddlPurReq.SelectedValue;
            DataSet ds = databaseFunctions.GetDataSet(objBll.GetPurDeptDate(objBal));
            dt = ds.Tables[0];
            lblDept.Text = dt.Rows[0][0].ToString();
            lblPurDate.Text = dt.Rows[0][1].ToString();
            ViewState["dt"] = dt = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem l1 = new ListItem();
                    l1.Value = dt.Rows[i]["STO_ID"].ToString();
                    l1.Text = dt.Rows[i]["STO_NAME"].ToString();
                    ddlStore.Items.Add(l1);
                }
                ViewState["dt"] = dt;
            }
            ddlItem.Items.Add(dt.Rows[0][1].ToString());
            ddlFAN.Focus();
        }
        else
        {
            ddlFAN.Items.Clear();
            lblDept.Text = lblPurDate.Text = "";
        }
    }
    protected void ddlFAN_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFAN.SelectedIndex > 0)
        {
            objBal.ID = ddlFAN.SelectedValue;
            DataSet ds = databaseFunctions.GetDataSet(objBll.GetFanAmtDate(objBal));
            dt = ds.Tables[0];
            lblFANAMT.Text = dt.Rows[0][0].ToString();
            lblFanDate.Text = dt.Rows[0][1].ToString();
            ddlStore.Focus();
        }
        else
        {
            lblFANAMT.Text = lblFanDate.Text = "";
        }
    }
    protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlItem.SelectedIndex > 0)
        {

            if (trPurReq.Visible == true)
            {
                dt = (DataTable)ViewState["dt"];
                DataRow[] drow = dt.Select("ITEM_ID='" + ddlItem.SelectedValue + "'");
                if (drow.Length > 0)
                {
                    txtQty.Text = drow[0]["REQ_ITEM_QTY"].ToString();
                    txtrate.Text = Convert.ToDouble(drow[0]["REQ_ITEM_RATE"]).ToString();
                }
            }
            ViewState["dt"] = dt;
            txtQty.Focus();
            txtUnit.Text = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UNIT, ddlItem.SelectedValue));
        }
        else
        {
            txtQty.Text = txtrate.Text = "0";
        }

    }

    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (trPurReq.Visible == true)
        {
            ddlItem.Items.Clear();
            ddlSupp.SelectedIndex = 0;
            dt = (DataTable)ViewState["dt"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListItem l1 = new ListItem();
                    l1.Value = dt.Rows[i]["ITEM_ID"].ToString();
                    l1.Text = dt.Rows[i]["ITEM_NAME"].ToString();
                    ddlItem.Items.Add(l1);
                }
                ViewState["dt"] = dt;
            }

        }
        else
            fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store_Item, ddlStore.SelectedValue), true, FillFunctions.FirstItem.Select);

        ddlStore.Enabled = true;
        ddlSupp.Focus();
    }
    protected void ddlRef_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRef.SelectedItem.ToString() == "Quotation")
        {
            thQuot.Visible = tdQuot.Visible = true;
            txtrefNo.Focus();
        }
        else
        {
            thQuot.Visible = tdQuot.Visible = false;
        }
        trTerm.Visible = true;
    }

    protected void ddlPayment_SelectedIndexChanged(object sender, EventArgs e)
    {
        trTerm.Visible = true;

    }
    protected void ddlTerm_SelectedIndexChanged(object sender, EventArgs e)
    {
        trTerm.Visible = true;
        if (ddlTerm.SelectedIndex > 0)
        {
            AutoComExt1.ContextKey = ddlTerm.SelectedValue;
        }

    }
    protected void ddlSupp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlItem.Focus();
    }
    protected void ddlDis_SelectedIndexChanged(object sender, EventArgs e)
    {
        trTerm.Visible = true;

        if (gvItemDetail.Rows.Count > 0)
        {
            double NetAmount = Convert.ToDouble(gvItemDetail.FooterRow.Cells[8].Text);
            if (txtdiscount.Text != "")
            {
                if ((ddlDis.SelectedIndex == 2) && (Convert.ToDouble(txtdiscount.Text) > 99))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('In Case of % Discount total value should not greater then 99.!!')", true);
                    txtdiscount.Text = "";
                    txtdiscount.Focus();
                    return;
                }
                double dis = (ddlDis.SelectedIndex == 1) ? (Convert.ToDouble(txtdiscount.Text) * 100) / 100 : Convert.ToDouble(txtdiscount.Text);
                NetAmount = NetAmount - dis;
            }
            if (txtOtherCharges.Text != "")
            {
                NetAmount = NetAmount + Convert.ToDouble(txtOtherCharges.Text);
            }
            ViewState["NETAMOUNT"] = lblNetAmount.Text = NetAmount.ToString("N2");
        }
    }
    #endregion
    #region Item
    void addItem()
    {
        double rate, tax, dis, total, qty;
        ViewState["NETAMOUNT"] = (ViewState["NETAMOUNT"].ToString() == "") ? 0 : Convert.ToDouble(ViewState["NETAMOUNT"]);
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
            if (nodeList[i].InnerText == ddlItem.SelectedItem.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Item is already inserted!!')", true);
                return;
            }
        }

        XmlElement dataElement = XmlData.CreateElement("DATA");
        Root.AppendChild(dataElement);

        XmlElement element = XmlData.CreateElement("ITEM_CODE");
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

        total = rate - (rate * dis / 100);
        total = total + (total * tax / 100);
        total = (total < 0) ? 0 : total * qty;
        ViewState["NETAMOUNT"] = Convert.ToDouble(ViewState["NETAMOUNT"]) + total;
        element = XmlData.CreateElement("TOTAL");
        element.InnerText = total.ToString("N2");
        dataElement.AppendChild(element);

        element = XmlData.CreateElement("SPECIFICATION");
        element.InnerText = txtSpecification.Text.Trim(' ');
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
        gvItemDetail.FooterRow.Cells[7].Text = "Total Amt.";
        lblNetAmount.Text = gvItemDetail.FooterRow.Cells[8].Text = ViewState["NETAMOUNT"].ToString();
        Clear();
        txtUnit.Text = "";
        ddlItem.Focus();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (trPurReq.Visible == true)
        {
            dt = (DataTable)ViewState["dt"];
        }
        addItem();
        trTerm.Visible = true;
        msg = "Item added to List";
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }


    protected void gvItemDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ORDER/DATA");
        XmlNodeList nodeList1 = xmlData.SelectNodes("ORDER/DATA/AMOUNT");
        double amt = Convert.ToDouble(nodeList1[e.RowIndex].InnerText);
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtXML.Text = xmlData.OuterXml;
        else
        {
            txtXML.Text = "";
        }
        ViewState["NETAMOUNT"] = Convert.ToDouble(ViewState["NETAMOUNT"]) - amt;
        msg = "One item delete from list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        AddItemData();

    }
    #endregion Item
    #region Payment
    void addPayment()
    {

        ViewState["Total"] = (ViewState["Total"].ToString() == "") ? 0 : Convert.ToInt32(ViewState["Total"]);
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
        XmlNodeList nodeList = XmlPayment.SelectNodes("PAYMENT/DATA/PAYPER");
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

        XmlElement element = XmlPayment.CreateElement("PO_PAY_AT");
        element.InnerText = ddlPayment.SelectedValue;
        dataElement.AppendChild(element);


        element = XmlPayment.CreateElement("PAYPER");
        element.InnerText = txtPayment.Text;
        dataElement.AppendChild(element);

        element = XmlPayment.CreateElement("PAYDAYS");
        element.InnerText = txtPayDay.Text;
        dataElement.AppendChild(element);

        element = XmlPayment.CreateElement("PAYON");
        element.InnerText = ddlPayment.SelectedItem.Text;
        dataElement.AppendChild(element);

        txtPay.Text = XmlPayment.OuterXml;
        AddPaymentData();

    }

    void AddPaymentData()
    {

        if (txtPay.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtPay.Text));
            gvPayment.DataSource = dataSet.Tables[0];
            gvPayment.DataBind();

        }
        else
        {
            gvPayment.DataSource = null;
            gvPayment.DataBind();
        }
        trTerm.Visible = true;
        Clear();
        ddlPayment.Focus();
    }
    protected void btnPayAdd_Click(object sender, EventArgs e)
    {
        addPayment();
        trTerm.Visible = true;
        txtPayDay.Text = txtPayment.Text = "";
        ddlPayment.SelectedIndex = 0;
        ddlPayment.Focus();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Payment Condition added to List')", true);
    }

    protected void gvPayment_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtPay.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PAYMENT/DATA");
        XmlNodeList nodeList1 = xmlData.SelectNodes("PAYMENT/DATA/PAYPER");
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
    #endregion Payment
    #region Term

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
        XmlNodeList nodeList = XmlTerm.SelectNodes("TERM/DATA/TERM");
        XmlNodeList nodeList1 = XmlTerm.SelectNodes("TERM/DATA/CONDITION");
        for (int i = 0; i < nodeList.Count; i++)
        {
            if ((nodeList[i].InnerText == ddlTerm.SelectedItem.Text) || (nodeList1[i].InnerText == txtCondition.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Term Has Already Been Enetered !!')", true);
                Clear();
                return;
            }
        }
        XmlElement dataElement = XmlTerm.CreateElement("DATA");
        RootTerm.AppendChild(dataElement);

        XmlElement element = XmlTerm.CreateElement("TERM_ID");
        element.InnerText = ddlTerm.SelectedValue;
        dataElement.AppendChild(element);

        element = XmlTerm.CreateElement("TERM");
        element.InnerText = ddlTerm.SelectedItem.Text;
        dataElement.AppendChild(element);

        element = XmlTerm.CreateElement("CONDITION");
        element.InnerText = txtCondition.Text;
        dataElement.AppendChild(element);

        txtTerm.Text = XmlTerm.OuterXml;
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
        trTerm.Visible = true;
        Clear();
        ddlTerm.Focus();
    }
    protected void btnTermAdd_Click(object sender, EventArgs e)
    {
        cmdSubmit.Enabled = true;
        addTerm();
        trTerm.Visible = true;
        txtCondition.Text = "";
        ddlTerm.SelectedIndex = 0;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('One Term & Condition added to List')", true);

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

    #endregion
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        objBal.Status = "";
        objBal.ID = "";
        if (Convert.ToDouble(ViewState["NETAMOUNT"]) <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Net Amount of this Purchase order Invalid.!!')", true);
            return;
        }
        if (trPurReq.Visible == true)
        {
            objBal.Status = "2";
            objBal.ID = ddlFAN.SelectedValue;
        }
        objBal.PurNo = generatePONo();
        objBal.StoreName = ddlStore.SelectedValue;
        objBal.SupplierName = ddlSupp.SelectedValue;
        if (txtrefNo.Text == "")
            objBal.ReqNo = "0";
        else
            objBal.ReqNo = txtrefNo.Text;
        objBal.Rate = Convert.ToDecimal(txtOtherCharges.Text).ToString();
        objBal.Discount = Convert.ToDecimal(txtdiscount.Text).ToString();
        objBal.Remark = txtremark.Text;
        objBal.Amount = lblNetAmount.Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.OrderData = txtXML.Text;
        objBal.PaymentData = txtPay.Text;
        objBal.TermData = txtTerm.Text;
        objBal.Date = txtDate.Text;
        objBal.Dept = (ddlDepartment.SelectedIndex > 0) ? ddlDepartment.SelectedValue : "";
        strPoID = objBll.PurOrderInsert(objBal).Tables[0].Rows[0][0].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prntPurOrder.aspx?id=" + strPoID + "',alwaysraised='yes')", true);
        clearControls();

    }
    private string generatePONo()
    {
        string strPONo;
        SqlDataReader dr = objBll.GetPOFinancialYear();
        if (dr.Read())
            strPONo = "PO/" + CommonFunctions.getFinancialYear() + "/" + dr[0].ToString();
        else
            strPONo = "PO/" + CommonFunctions.getFinancialYear() + "/01";
        return strPONo;
    }


    protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCat.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlSubCat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubCategory, ddlCat.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlSubCat.Items.Clear();
    }
    protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubCat.SelectedIndex > 0)
        {
            objBal.ID = ddlStore.SelectedValue;
            objBal.CatId = ddlCat.SelectedValue;
            objBal.Typ = ddlSubCat.SelectedValue;
            ViewState["dt"] = objBll.getStoreItem(objBal).Tables[0];
            fillFunctions.Fill(ddlItem, (DataTable)ViewState["dt"], true, FillFunctions.FirstItem.Select);
        }
    }
}

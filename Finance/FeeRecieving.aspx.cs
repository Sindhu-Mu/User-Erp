using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;
using System.Threading;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DataSet ds;
    StringBuilder data;
    static decimal glb_credit;
    static decimal glb_credit_left;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        btnShow.Attributes.Add("onClick", "return valid()");
        btnModeAdd.Attributes.Add("OnClick", "return Cashvalidat()");
        btnReceive.Attributes.Add("OnClick", "return validation()");
        lblMsg.Text = "";
        if (!IsPostBack)
        {
            trRefDetail.Visible = divAdv.Visible = false;
            ViewState["TotalAmt"] = "0";
            ViewState["DEMAND_ID"] = "0";
            HiddenField1.Value = "";
            LoadData();
            btnReceive.Visible = false;
        }


    }
    void LoadData()
    {
        glb_ff.Fill(ddlSem, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlAcountNo, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FeeAccount), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlBank, glb_qf.GetCommand(QueryFunctions.QueryBaseType.BankName), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlPaymentMode, glb_qf.GetCommand(QueryFunctions.QueryBaseType.PayMode), true, FillFunctions.FirstItem.Select);
        ddlPaymentMode.SelectedIndex = 1;
    }

    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        ds = new DataSet();
        cf = new CommonFunctions();
        data = new StringBuilder();
    }
    protected void showAlert(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        double TotalAmt = 0;
        ViewState["DEMAND_ID"] = 0;
        Student.ShowStudent(txtEnrollment.Text);
        balObj.balCommonID = txtEnrollment.Text;
        dt = bllObj.GetStudentDetails(balObj).Tables[0];
        if (dt.Rows.Count > 0)
        {
            if (HiddenField1.Value != txtEnrollment.Text)
            {
                HiddenField1.Value = txtEnrollment.Text;
                ddlBranch.Items.Clear();
                glb_ff.Fill(ddlBranch, dt, true, FillFunctions.FirstItem.Select);
                ddlBranch.SelectedIndex = 1;
                ddlSem.SelectedValue = dt.Rows[0][2].ToString();
            }

        }
        ds = bllObj.StudentDueFeeSelect(txtEnrollment.Text, ddlBranch.SelectedValue, ddlSem.SelectedValue);
        gvFees.DataSource = ds.Tables[0];
        gvFees.DataBind();
        //HyperLink.NavigateUrl = "prtStuReport.aspx?=" + ds.Tables[0].Rows[0][0].ToString();
        foreach (GridViewRow row in gvFees.Rows)
        {
            TextBox tb1 = (TextBox)row.FindControl("txtPayAmt");
            //tb1.Enabled = Convert.ToBoolean(ds.Tables[0].Rows[row.RowIndex][5]);
            TotalAmt += Convert.ToDouble(row.Cells[1].Text);
        }
        if (gvFees.Rows.Count > 0)
        {
            divDemand.Visible = true;
            gvFees.FooterRow.Cells[1].Text = TotalAmt.ToString();
            txtModeAmount.Focus();
            HyperLink.NavigateUrl = "prtStuReport.aspx?=" + ds.Tables[0].Rows[0][0].ToString();
            ViewState["DEMAND_ID"] = ds.Tables[0].Rows[0][0].ToString();
        }
        else if (ds.Tables[1].Rows.Count > 0)
        {
            divDemand_2.Visible = false;
            divAdv.Visible = true;
            HyperLink.NavigateUrl = "prtStuReport.aspx?=" + ds.Tables[1].Rows[0][0].ToString();
            ViewState["DEMAND_ID"] = ds.Tables[1].Rows[0][0].ToString();
        }
        gvRefDetail.DataSource = "";
        gvRefDetail.DataBind();
        txtData.Text = "";
        ViewState["TotalAmt"] = "0";
        ViewState["DiscountSts"] = "0";

        if (Convert.ToInt32(ds.Tables[2].Rows[0][0].ToString()) == 0)
        {
            ViewState["DiscountSts"] = 1;
        }
        DataTable lcl_dt = new DataTable();
        lcl_dt = ds.Tables[3];
        if (lcl_dt.Rows.Count != 0)
        {

            glb_credit = Convert.ToDecimal(lcl_dt.Rows[0]["credit"].ToString());
            glb_credit_left = glb_credit;
            lblCredit.Text = glb_credit.ToString();
        }
        else
        {
            glb_credit = 0;
            glb_credit_left = glb_credit;
            lblCredit.Text = glb_credit.ToString();
        }


    }
    #region Code for PayMode
    protected void btnModeAdd_Click(object sender, EventArgs e)
    {
        if (ddlPaymentMode.SelectedValue == "7")
        {
            if (Convert.ToDecimal(txtModeAmount.Text) <= Convert.ToDecimal(lblCredit.Text))
            {
                double PayTotal = 0;
                double PayCredit = 0;
                glb_credit_left = Convert.ToDecimal(lblCredit.Text) - Convert.ToDecimal(txtModeAmount.Text);
                Add();
                assignAmt();
                foreach (GridViewRow itm in gvFees.Rows)
                {
                    if (((TextBox)itm.FindControl("txtPayAmt")).Text != "")
                        PayTotal += Convert.ToDouble(((TextBox)itm.FindControl("txtPayAmt")).Text);
                    if (((TextBox)itm.FindControl("txtCredit")).Text != "")
                        PayCredit += Convert.ToDouble(((TextBox)itm.FindControl("txtCredit")).Text);
                }
                if (gvFees.Rows.Count > 0)
                    gvFees.FooterRow.Cells[2].Text = PayTotal.ToString();
                gvFees.FooterRow.Cells[3].Text = PayCredit.ToString();

                if (gvFees.Rows.Count > 0)
                    btnReceive.Visible = ((Convert.ToDouble(gvFees.FooterRow.Cells[2].Text)) + (Convert.ToDouble(gvFees.FooterRow.Cells[3].Text))) == Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text);
                else
                {

                    txtFees.Text = (txtFees.Text == "") ? "0" : txtFees.Text;
                    btnReceive.Visible = (Convert.ToDouble(txtFees.Text) == Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text));
                }
                lblCredit.Text = (Convert.ToDecimal(lblCredit.Text) - Convert.ToDecimal(txtModeAmount.Text)).ToString();
                txtBranchName.Text = txtDate.Text = txtRefNo.Text = txtModeAmount.Text = "";
                ddlPaymentMode.SelectedIndex = ddlBank.SelectedIndex = ddlAcountNo.SelectedIndex = 0;
                trRefDetail.Visible = false;
                txtModeAmount.Focus();

            }
            else
            {
                showAlert("Don't Have Enough Credit..!");
            }
        }
        else
        {
            double PayTotal = 0;
            double PayCredit = 0;
            Add();
            assignAmt();
            foreach (GridViewRow itm in gvFees.Rows)
            {
                if (((TextBox)itm.FindControl("txtPayAmt")).Text != "")
                    PayTotal += Convert.ToDouble(((TextBox)itm.FindControl("txtPayAmt")).Text);
                if (((TextBox)itm.FindControl("txtCredit")).Text != "")
                    PayCredit += Convert.ToDouble(((TextBox)itm.FindControl("txtCredit")).Text);
            }
            if (gvFees.Rows.Count > 0)
                gvFees.FooterRow.Cells[2].Text = PayTotal.ToString();
            gvFees.FooterRow.Cells[3].Text = PayCredit.ToString();

            if (gvFees.Rows.Count > 0)
                btnReceive.Visible = ((Convert.ToDouble(gvFees.FooterRow.Cells[2].Text)) + (Convert.ToDouble(gvFees.FooterRow.Cells[3].Text))) == (Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text));
            else
            {

                txtFees.Text = (txtFees.Text == "") ? "0" : txtFees.Text;
                btnReceive.Visible = (Convert.ToDouble(txtFees.Text) == Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text));
            }

            txtBranchName.Text = txtDate.Text = txtRefNo.Text = txtModeAmount.Text = "";
            ddlPaymentMode.SelectedIndex = ddlBank.SelectedIndex = ddlAcountNo.SelectedIndex = 0;
            trRefDetail.Visible = false;
            txtModeAmount.Focus();
        }



    }
    protected void gvRefDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (gvRefDetail.Rows[e.RowIndex].Cells[1].Text == "A/c Credit")
        {

            glb_credit_left = glb_credit_left + Convert.ToDecimal(gvRefDetail.Rows[e.RowIndex].Cells[5].Text);
            lblCredit.Text = glb_credit_left.ToString();

        }
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("MODE/DATA");
        XmlNodeList nodeList1 = xmlData.SelectNodes("MODE/DATA/RCV_TRAN_MODE_AMT");
        double amt = Convert.ToDouble(nodeList1[e.RowIndex].InnerText);
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
        {
            txtData.Text = "";
            ViewState["TotalAmt"] = '0';
        }
        AddXmlData(-amt);
        if (gvFees.Rows.Count > 0)
            btnReceive.Visible = (gvFees.FooterRow.Cells[2].Text == gvRefDetail.FooterRow.Cells[2].Text);
        else
        {

            txtFees.Text = (txtFees.Text == "") ? "0" : txtFees.Text;
            btnReceive.Visible = (Convert.ToDouble(txtFees.Text) == Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text));
        }

        assignAmt();
    }
    void Add()
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
            ROOT = xmlData.CreateElement("MODE");
            xmlData.AppendChild(ROOT);
        }
        XmlNodeList nodeList = xmlData.SelectNodes("MODE/DATA/PAY_MODE_ID");
        XmlNodeList nodeList1 = xmlData.SelectNodes("MODE/DATA/RCV_TRAN_MODE_NO");
        for (int i = 0; i < nodeList.Count; i++)
        {
            if ((nodeList[i].InnerText == ddlPaymentMode.SelectedValue) && (nodeList1[i].InnerText == txtRefNo.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Reference no detail already inserted!!')", true);
                return;
            }
        }
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("PAY_MODE_ID");
        element.InnerText = ddlPaymentMode.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("PAY_MODE");
        element.InnerText = ddlPaymentMode.SelectedItem.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("RCV_TRAN_MODE_NO");
        element.InnerText = (txtRefNo.Text == "") ? "0" : txtRefNo.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("RCV_TRAN_MODE_DT");
        element.InnerText = (txtDate.Text == "") ? DateTime.Now.ToString() : cf.GetDateTime(txtDate.Text).ToString();
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("RCV_TRAN_MODE_AMT");
        element.InnerText = txtModeAmount.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("TRAN_DRAWEE_BANK");
        element.InnerText = (ddlBank.SelectedIndex == 0) ? "0" : ddlBank.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("BANK");
        element.InnerText = (ddlBank.SelectedIndex == 0) ? "0" : ddlBank.SelectedItem.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("TRAN_DRAWEE_BRANCH");
        element.InnerText = (txtBranchName.Text == "") ? "Non" : txtBranchName.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("BANK_AC_ID");
        element.InnerText = (ddlAcountNo.SelectedIndex == 0) ? "3" : ddlAcountNo.SelectedValue;
        dataElement.AppendChild(element);
        txtData.Text = xmlData.OuterXml;
        ddlAcountNo.SelectedIndex = ddlBank.SelectedIndex = ddlPaymentMode.SelectedIndex = 0;
        txtDate.Text = txtBranchName.Text = txtRefNo.Text = "";
        AddXmlData(Convert.ToDouble(txtModeAmount.Text));
    }
    void AddXmlData(double TotalFee)
    {
        if (txtData.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtData.Text));
            gvRefDetail.DataSource = dataSet.Tables[0];
            gvRefDetail.DataBind();
            TotalFee = Convert.ToDouble(ViewState["TotalAmt"].ToString()) + TotalFee;
            if (gvRefDetail.Rows.Count > 0)
                gvRefDetail.FooterRow.Cells[5].Text = TotalFee.ToString();
            ViewState["TotalAmt"] = gvRefDetail.FooterRow.Cells[5].Text;

        }
        else
        {
            gvRefDetail.DataSource = null;
            gvRefDetail.DataBind();
        }
    }
    #endregion
    
    protected void btnReceive_Click(object sender, EventArgs e)
    {
        Thread.Sleep(1000);
        if (validateAmt())
        {
            try
            {
                string FeeRcvTranID = "";
                data = new StringBuilder();
                TextBox txtAmount = new TextBox();
                TextBox txtCredit = new TextBox();
                int count1 = 0;
                if (gvFees.Rows.Count > 0)
                {
                    if (Convert.ToDouble(gvFees.FooterRow.Cells[2].Text) + Convert.ToDouble(gvFees.FooterRow.Cells[3].Text) == Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text))
                    {
                        data.AppendFormat("<TRAN>");
                        foreach (GridViewRow itm in gvFees.Rows)
                        {
                            //if ((gvFees.DataKeys[itm.RowIndex].Values[1].ToString().Equals("12") || gvFees.DataKeys[itm.RowIndex].Values[1].ToString().Equals("11")) && gvFees.Rows.Count==2)
                            //{

                            //    txtAmount = (TextBox)gvFees.Rows[itm.RowIndex].FindControl("txtPayAmt");
                            //    txtAmount.Text = (txtAmount.Text == "") ? "0" : txtAmount.Text;
                            //    ViewState["TotalAmt"] = txtAmount.Text;
                            //      FeeRcvTranID = bllObj.AdvanceFeeInsert(txtEnrollment.Text, ddlSem.SelectedValue, txtAmount.Text, gvFees.DataKeys[itm.RowIndex].Values[1].ToString(), Session["UserId"].ToString(), txtData.Text, cf.GetDateTime(txtDepositDate.Text));
                            //}
                            //else
                            //{
                            count1 = 1;
                            txtAmount = (TextBox)gvFees.Rows[itm.RowIndex].FindControl("txtPayAmt");
                            txtAmount.Text = (txtAmount.Text == "") ? "0" : txtAmount.Text;
                            txtCredit = (TextBox)gvFees.Rows[itm.RowIndex].FindControl("txtCredit");
                            txtCredit.Text = (txtCredit.Text == "") ? "0" : txtCredit.Text;
                            if (Convert.ToDouble(txtAmount.Text) > 0)
                                data.AppendFormat("<DATA  FEE_MAIN_HEAD_ID= \"" + gvFees.DataKeys[itm.RowIndex].Values[1].ToString() + "\" FEE_RCV_TRAN_AMT= \"" + txtAmount.Text + "\" FEE_CREDIT_ADJUST= \"" + txtCredit.Text + "\" />");

                            // }
                        }
                        if (count1 == 1)
                        {
                            data.AppendFormat("</TRAN>");
                            balObj.XmlValue = data.ToString();
                            balObj.balDemandId = gvFees.DataKeys[0].Values[0].ToString();
                            balObj.balRemark = txtRemark.Text;
                            balObj.balSession = Session["UserId"].ToString();
                            balObj.FromDate = cf.GetDateTime(txtDepositDate.Text);
                            balObj.XmlValue2 = txtData.Text;
                            FeeRcvTranID = bllObj.FeeReceiveTranInsert(balObj);
                        }
                        if (FeeRcvTranID != "")
                        {
                            ddlBranch.Items.Clear();
                            txtData.Text = txtEnrollment.Text = txtFees.Text = txtRemark.Text = txtDepositDate.Text = "";
                            ddlSem.SelectedIndex = 0;
                            gvFees.DataSource = "";
                            gvFees.DataBind();
                            data.Clear();
                            gvRefDetail.DataSource = "";
                            ViewState["TotalAmt"] = "0";
                            gvRefDetail.DataBind();
                            txtEnrollment.Focus();
                            btnReceive.Visible = divAdv.Visible = false;
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtFeeReceipt.aspx?=" + FeeRcvTranID + "','_blank','scrollbars=1')", true);
                        }

                    }
                    else
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fee amount and mode amount not matching.')", true);

                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fee detail not avilable.')", true);


                //else
                //{

                //    if (txtFees.Text != "")
                //    {
                //        FeeRcvTranID = bllObj.AdvanceFeeInsert(txtEnrollment.Text, ddlSem.SelectedValue, txtFees.Text, ddlAdvance.SelectedValue, Session["EMP_CODE"].ToString(), txtData.Text, txtDepositDate.Text);
                //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtFeeReceipt.aspx?=" + FeeRcvTranID + "','_blank','scrollbars=1')", true);
                //    }
                //}



            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Exception Occurred " + ex.ToString() + "')", true);
            }
            finally
            {
                btnReceive.Enabled = true;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Kindly Check The Amount Total !!')", true);
        }
    }
    protected void dueAmt()
    {

        double headValue = 0.0;
        double dueAmt = 0.0;
        double amtpay = 0.0;
        foreach (GridViewRow itm in gvFees.Rows)
        {
            headValue = Convert.ToDouble(itm.Cells[1].Text);
            TextBox t = (TextBox)itm.FindControl("txtPayAmt");
            amtpay = Convert.ToDouble(t.Text);

            if (gvFees.DataKeys[itm.RowIndex].Values[1].ToString().Equals("52"))
            {

                dueAmt = 0;
            }
            else
            {

                dueAmt = headValue - amtpay;
            }
            t.Text = Convert.ToString(headValue);
            itm.Cells[1].Text = Convert.ToString(dueAmt);
        }
    }
    protected Boolean validateAmt()
    {
        if (gvFees.Rows.Count > 0)
        {
            double total = 0;
            double total_credit = 0;
            foreach (GridViewRow itm in gvFees.Rows)
            {
                TextBox txtAmount = (TextBox)gvFees.Rows[itm.RowIndex].FindControl("txtPayAmt");
                txtAmount.Text = (txtAmount.Text == "") ? "0" : txtAmount.Text;
                total = total + Convert.ToDouble(txtAmount.Text);
                TextBox txtCredit = (TextBox)gvFees.Rows[itm.RowIndex].FindControl("txtCredit");
                txtCredit.Text = (txtCredit.Text == "") ? "0" : txtCredit.Text;
                total_credit = Convert.ToDouble(txtCredit.Text);
                total += total_credit;
            }
            if (Convert.ToDouble(gvFees.FooterRow.Cells[2].Text) + Convert.ToDouble(gvFees.FooterRow.Cells[3].Text) == total)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected void assignAmt()
    {
        double lcl_credit_use = (Convert.ToDouble(glb_credit) - Convert.ToDouble(glb_credit_left));
        double TotalAmt = Convert.ToDouble(gvRefDetail.FooterRow.Cells[5].Text) - (Convert.ToDouble(lcl_credit_use));
        double headValue = 0.0;
        foreach (GridViewRow itm in gvFees.Rows)
        {
            headValue = Convert.ToDouble(itm.Cells[1].Text);

            if (lcl_credit_use >= 0)
            {
                if (gvFees.DataKeys[itm.RowIndex].Values[1].ToString().Equals("52"))
                {
                    headValue = lcl_credit_use;
                    lcl_credit_use=0;
                    
                }
                else
                {

                    if (lcl_credit_use >= headValue)
                    {
                        lcl_credit_use = lcl_credit_use - headValue;


                    }
                    else
                    {

                        headValue = lcl_credit_use;
                        lcl_credit_use = 0;


                    }
                }
                TextBox t = (TextBox)itm.FindControl("txtCredit");
                t.Text = Convert.ToString(headValue);
            }

            if (TotalAmt > 0)
            {
                headValue = Convert.ToDouble(itm.Cells[1].Text) - headValue;
                if (gvFees.DataKeys[itm.RowIndex].Values[1].ToString().Equals("52"))
                {
                    headValue = TotalAmt;
                    TotalAmt = 0;
                }
                else
                {

                    if (TotalAmt >= headValue)
                    {
                        TotalAmt = TotalAmt - headValue;


                    }
                    else
                    {

                        headValue = TotalAmt;
                        TotalAmt = 0;
                    }
                }
                TextBox t = (TextBox)itm.FindControl("txtPayAmt");
                t.Text = Convert.ToString(headValue);
            }


        }
    }

    protected void btnAdvRcv_Click(object sender, EventArgs e)
    {
        if (txtFees.Text != "")
        {
            string FeeRcvTranID = bllObj.AdvanceFeeInsert(txtEnrollment.Text, ddlSem.SelectedValue, txtFees.Text, ddlAdvance.SelectedValue, Session["UserId"].ToString(), txtData.Text, cf.GetDateTime(txtDepositDate.Text));
            lblRegIg.Text = "Amount received successfully against R.NO.:-" + FeeRcvTranID + "";
        }
    }

    protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaymentMode.SelectedIndex > 0)
        {
            trRefDetail.Visible = DivAdjustment.Visible = false;
            lblRefType.Text = ddlPaymentMode.SelectedItem.Text + " No.";
            if (ddlPaymentMode.SelectedIndex == 1)
            {
                trRefDetail.Visible = false;
                btnModeAdd.Attributes.Add("OnClick", "return Cashvalidat()");
            }
            else if (ddlPaymentMode.SelectedValue == "7")
            {
                trRefDetail.Visible = false;
                btnModeAdd.Attributes.Add("OnClick", "return Cashvalidat()");
                txtModeAmount.Text = lblCredit.Text;
            }
            else if (ddlPaymentMode.SelectedValue == "13")
            {
                DivAdjustment.Visible = true;
                btnModeAdd.Attributes.Add("OnClick", "return Adjustmentvalidat()");
            }
            else
            {
                trRefDetail.Visible = true;
                btnModeAdd.Attributes.Add("OnClick", "return Othervalidat()");
            }
        }
    }
}
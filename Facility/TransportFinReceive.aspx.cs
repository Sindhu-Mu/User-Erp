using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Transactions;
using System.IO;

public partial class Facility_TransportFinReceive : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions databaseFunctions;
    FacBAL objFacBal;
    FacBLL objFacBll;
    DataTable dt;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            trReg.Visible = false;
            trPayment.Visible = false;
            trBankOption.Visible = false;
            ViewState["PayAmt"] = "";
            ViewState["REG_ROUTE_ID"] = "";
            txtEnroll.Focus();
            FillFunction.Fill(ddlPaymode, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.PayMode), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlBank, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Bank), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlAccNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AcNo), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        objFacBal = new FacBAL();
        objFacBll = new FacBLL();
        dt = new DataTable();
    }
    public int ShowDetail(string Enrollment)
    {
        objFacBal.StuAdmNo = Enrollment;
        trBankOption.Visible = false;
        trReg.Visible = true;
        trPayment.Visible = true;
        dt = objFacBll.FinRecSelect(objFacBal).Tables[0];
        ViewState["PayAmt"] = "0";
        if (dt.Rows.Count > 0)
        {
            
            ViewState["REG_ROUTE_ID"] = dt.Rows[0]["REG_ROUTE_ID"].ToString();
            lblRoute.Text = dt.Rows[0]["RTE_NAME"].ToString();
            lblCity.Text = dt.Rows[0]["CITY_NAME"].ToString();
            lblStoppage.Text = dt.Rows[0]["STOPPAGE"].ToString();
            lblAppBy.Text = dt.Rows[0]["APP_BY"].ToString();
            lblRegDt.Text = Convert.ToDateTime(dt.Rows[0]["APP_DATE"]).ToString("dd/MM/yyyy");
            lblChallan.Text = dt.Rows[0]["CHALLAN_NO"].ToString();
            lblNOD.Text = dt.Rows[0]["DAYS"].ToString();
            lblFromDt.Text = Convert.ToDateTime(dt.Rows[0]["SRT_DATE"]).ToString("dd/MM/yyyy");
            lblToDt.Text = Convert.ToDateTime(dt.Rows[0]["END_DATE"]).ToString("dd/MM/yyyy");
            lblAmount.Text = dt.Rows[0]["AMOUNT"].ToString();
            if (Convert.ToDouble(dt.Rows[0]["BALANCE"]) > 0)
            {
                txtAmount.Text = dt.Rows[0]["BALANCE"].ToString();
                ViewState["PayAmt"] = dt.Rows[0]["BALANCE"].ToString();
            }
            else
                return 2;
                return 1;
            }
        else
            return 0;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        int x=ShowDetail(txtEnroll.Text);
         ctrlStudent.ShowStudent(CommonFunction.GetKeyID(txtEnroll));      
        string[] st = new string[2];
        st = txtEnroll.Text.Split(':');
        if (st.Length > 1)
        {
            ctrlStudent.ShowStudent(st[1]);
            txtAmount.Focus();
            switch (ShowDetail(st[1]))
            {
                case 0:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Transport registration not processed.')", true);
                    txtEnroll.Focus();
                    return;
                case 2:
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Payment already done for this!!')", true);
                    txtEnroll.Focus();
                    return;
            }
            trReg.Visible = btnModeAdd.Enabled = true;
            txtEnroll.Text = "";

        }
    }
    protected void btnModeAdd_Click(object sender, EventArgs e)
     {
        XmlDocument XmlData = new XmlDocument();
        XmlElement Root;
        if (txtData.Text != "")
        {
            XmlData.LoadXml(txtData.Text);
            Root = XmlData.DocumentElement;
        }
        else
        {
            Root = XmlData.CreateElement("ADDTRAN");
            XmlData.AppendChild(Root);
        }
        
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);
                XmlElement element = XmlData.CreateElement("PAY_MODE_ID");
                element.InnerText = ddlPaymode.SelectedValue;  
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("PAY_MODE_VALUE");
                element.InnerText = ddlPaymode.SelectedItem.Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("TRAN_MODE_DATE");
                element.InnerText = CommonFunction.GetDateTime(txtDate.Text).ToString();
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("TRAN_MODE_AMT");
                element.InnerText = txtAmount.Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("BANK_ID");
                element.InnerText = ddlBank.SelectedValue;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("BANK_VALUE");
                element.InnerText = ddlBank.SelectedItem.Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("TRAN_MODE_NO");
                element.InnerText = txtRefNo.Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("DRAWEE_BRANCH");
                element.InnerText = txtBranchName.Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("BRANCH_AC_ID");
                element.InnerText = ddlAccNo.SelectedValue;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("BRANCH_AC_NO");
                element.InnerText = ddlAccNo.SelectedItem.Text;
                dataElement.AppendChild(element); 

               txtData.Text = XmlData.OuterXml;
               AddXmlData();
     
       
    }
    void AddXmlData()
    {
        if (txtData.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtData.Text));
            gvAddDetail.DataSource = dataSet.Tables[0];
            gvAddDetail.DataBind();
        }
        else
        {
            gvAddDetail.DataSource = null;
            gvAddDetail.DataBind();
        }
    }
    void clear()
    {
        txtBranchName.Text = "";
        txtRemark.Text = "";
        txtAmount.Text = "";
    }
    protected void btnReceive_Click(object sender, EventArgs e)
    {
        objFacBal.RegRteId = ViewState["REG_ROUTE_ID"].ToString();
        objFacBal.FeeDemand = lblAmount.Text;
        objFacBal.DiscAmt = "0";
        objFacBal.XmlValue = txtData.Text;
        objFacBal.TranRemark = txtRemark.Text;
        objFacBal.TranAmt = txtAmount.Text;
        objFacBal.SessionUserID = Session["UserID"].ToString();
        objFacBal.BankAccId = ddlAccNo.SelectedValue;
        Msg = objFacBll.TptFinRecInsert(objFacBal);
        CommonFunction.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+Msg+"')", true);
        clear();
    }
    protected void gvAddDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);

        XmlNodeList nodeList = xmlData.SelectNodes("ADDTRAN/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
        {
            txtData.Text = xmlData.OuterXml;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        }
        else
        {
            txtData.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        }
        AddXmlData();
    }
    protected void ddlPaymode_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtBranchName.Text = "";
        ddlAccNo.SelectedIndex = 1;
        if (ddlPaymode.SelectedIndex > 1)
        {
            trBankOption.Visible = true;
            ddlBank.SelectedIndex = 0; txtBranchName.Text = "";
            lblRefNo.Text = (ddlPaymode.SelectedIndex == 2) ? "Cheque No." : "DD NO.";
        }
        else
        {
            lblRefNo.Text = lblChallan.Text;
            ddlBank.SelectedValue = "15";
            txtBranchName.Text = "Mu Campus";
            trBankOption.Visible = false;

        }
    }
}
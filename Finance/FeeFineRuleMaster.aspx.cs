using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;
using System.IO;
public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunctions;
    FillFunctions fillfunctions;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DatabaseFunctions databasefunction;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        btnAdd.Attributes.Add("onClick", "return validate()");
        if (!IsPostBack)
        {
            fillfunctions.Fill(ddlFineHead, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.FineHeads,"7"), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlRule,queryfunctions.GetCommand(QueryFunctions.QueryBaseType.FeeFineRule),true,FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlCalType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.CalculationType), true, FillFunctions.FirstItem.Select);
            
        }
       
        
    }
    protected void Initialize()
    {
        queryfunctions = new QueryFunctions();
        fillfunctions = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        databasefunction = new DatabaseFunctions();
    }
    protected void gvCondition_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtdata.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("FINE/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtdata.Text = xmlData.OuterXml;
        else
        txtdata.Text = "";
        AddXmlData();


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            balObj.balRule = ddlRule.SelectedValue;
            balObj.balSession = Session["UserId"].ToString();
            balObj.balData = txtdata.Text;
            //balObj.balNod = txtNOD.Text;
            //balObj.balAmount = txtAmount.Text;
            bllObj.FeeFineConditionInsert(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fees Fine Condition Created.')", true);
            txtdata.Text = "";
            gvCondition.DataSource = "";
            gvCondition.DataBind();
        }


        catch (SqlException k)
        {

            if (k.ErrorCode.ToString() == "-2146232060")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected fee head already existed in this stracture.')", true);
                ddlRule.Focus();
                return;
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlRule.SelectedIndex <= 0)
        {
            balObj.balRule = txtRuleName.Text;
            balObj.balFeeGroupHeadId = ddlFineHead.SelectedValue;
            balObj.balType = ddlCalType.SelectedValue;
            bllObj.FeeFineInsert(balObj);
            fillfunctions.Fill(ddlRule,queryfunctions.GetCommand(QueryFunctions.QueryBaseType.FeeFineRule),true,FillFunctions.FirstItem.Select);
            ddlRule.SelectedIndex = 1;
            txtRuleName.Text = "";
        }
        Add();
    }
    void Add()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtdata.Text != "")
        {
            xmlData.LoadXml(txtdata.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("FINE");
            xmlData.AppendChild(ROOT);
        }
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("FINE_RULE_ID");
        element.InnerText = ddlRule.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FINE_CND_DAYS");
        element.InnerText = txtNOD.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FINE_CND_AMT");
        element.InnerText = txtAmount.Text;
        dataElement.AppendChild(element);
        //element = xmlData.CreateElement("EMP_NAME");
        //element.InnerText = bllObj.GetEmpName(Convert.ToInt32(Session["EMP_CODE"]));
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FINE_CND_IN_DT");
        element.InnerText = cf.CurrentDate();
        dataElement.AppendChild(element);
        txtdata.Text = xmlData.OuterXml;
        AddXmlData();
        txtAmount.Text = txtNOD.Text = "";

    }
    void AddXmlData()
    {
        if (txtdata.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtdata.Text));
            gvCondition.DataSource = dataSet.Tables[0];
            gvCondition.DataBind();
            dataSet.Dispose();
        }
        else
        {
            gvCondition.DataSource = null;
            gvCondition.DataBind();
        }
    }
}
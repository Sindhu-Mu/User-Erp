using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.IO;
using System.Data.SqlClient;


public partial class control_email : System.Web.UI.UserControl
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages messages;
    HRBAL hrBal;
    HRBLL hrBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initilize();
        btnAddEmail.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlMailDomain, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
            //fillFunctions.Fill(ddlMailType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initilize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        messages = new Messages();
        hrBal = new HRBAL();
        hrBll = new HRBLL();
    }
    public string MailType
    {
        set
        {
            ddlMailType.SelectedValue = value;
        }
        get
        {
            return ddlMailType.SelectedValue;
        }
    }
    public int SelectedIndex
    {
        set
        {
            ddlMailType.SelectedIndex = value;
        }
        get
        {
            return ddlMailType.SelectedIndex;
        }
    }
    public string MailId
    {
        set
        {
            txtMailId.Text = value;
        }
        get
        {
            return txtMailId.Text;
        }
    }
    public string MailDomain
    {
        set
        {
            ddlMailDomain.Text = value;
        }
        get
        {
            return ddlMailDomain.Text;
        }
    }
    protected void btnAddEmail_Click(object sender, EventArgs e)
    {
        AddNewItem();
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
            ROOT = xmlData.CreateElement("MAIL");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;
        foreach (XmlNode node in xmlData.SelectNodes("MAIL/DATA/MAIL_TYPE_ID"))
        {
            if (node.InnerText == ddlMailType.SelectedValue)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Selected mail type already inserted')", true);
                add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("MAIL_TYPE_ID");
            element.InnerText = ddlMailType.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEYID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MAIL_TYPE_VALUE");
            element.InnerText = ddlMailType.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MAIL_VALUE");
            element.InnerText = txtMailId.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MAIL_DOM_ID");
            element.InnerText = ddlMailDomain.SelectedValue;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("MAIL_DOM_VALUE");
            element.InnerText = ddlMailDomain.SelectedItem.Text;
            dataElement.AppendChild(element);
            txtData.Text = xmlData.OuterXml;
            LoadItemData();
            txtMailId.Text = ""; ddlMailDomain.SelectedIndex = ddlMailType.SelectedIndex = 0;
        }

    }
    void LoadItemData()
    {
        DataSet dataSet = new DataSet();
        if (txtData.Text != "")
        {
            dataSet.ReadXml(new StringReader(txtData.Text));
            gvAddEmail.DataSource = dataSet.Tables[0];
            gvAddEmail.DataBind();
            foreach (GridViewRow row in gvAddEmail.Rows)
            {
                if (gvAddEmail.DataKeys[row.RowIndex].Value.ToString() == "2")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        else
        {
            gvAddEmail.DataSource = "";
            gvAddEmail.DataBind();
        }
    }

    public string GetXML
    {
        get
        {
            return txtData.Text;
        }
    }

    protected void gvAddEmail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("MAIL/DATA/KEYID");
        nodeList[e.RowIndex].InnerText = "2";
        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
            txtData.Text = "";
        LoadItemData();
    }
    public void ShowMailData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<MAIL>");
            xmlString = xmlString.Replace("</NewDataSet>", "</MAIL>");
            xmlString = xmlString.Replace("<Table4>", "<DATA>");
            xmlString = xmlString.Replace("</Table4>", "</DATA>");
            txtData.Text = xmlString;
        }
        else
        {
            txtData.Text = "";
        }
        LoadItemData();

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("MAIL/DATA");
        nodeList[index]["MAIL_TYPE_ID"].InnerText = ddlMailType.SelectedValue;
        nodeList[index]["MAIL_TYPE_VALUE"].InnerText = ddlMailType.SelectedItem.Text;
        nodeList[index]["MAIL_VALUE"].InnerText = txtMailId.Text;
        nodeList[index]["MAIL_DOM_ID"].InnerText = ddlMailDomain.SelectedValue;
        nodeList[index]["MAIL_DOM_VALUE"].InnerText = ddlMailDomain.SelectedItem.Text;
        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
            txtData.Text = "";
        LoadItemData();
        Clear();
    }
    protected void gvAddEmail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(txtData.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("MAIL/DATA");
            ddlMailDomain.SelectedValue = nodeList[index]["MAIL_DOM_ID"].InnerText.ToString();
            ddlMailType.SelectedValue = nodeList[index]["MAIL_TYPE_ID"].InnerText.ToString();
            txtMailId.Text = nodeList[index]["MAIL_VALUE"].InnerText;
            btnAddEmail.Visible = false;
            btnUpdate.Visible = true;
        }
    }

    void Clear()
    {
        txtMailId.Text = "";
        ddlMailDomain.SelectedIndex=ddlMailType.SelectedIndex=0;
    }
}

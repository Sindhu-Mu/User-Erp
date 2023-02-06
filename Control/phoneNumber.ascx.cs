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

public partial class control_phoneNumber : System.Web.UI.UserControl
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
        btnAddPhone.Attributes.Add("onclick", "return Phonevalidation()");
        if (!IsPostBack)
            PushData();
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
    void PushData()
    {
        fillFunctions.Fill(ddlPhoneType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PhoneType), true, FillFunctions.FirstItem.Select);
    }
    public string PhoneType
    {
        set
        {
            ddlPhoneType.SelectedValue = value;
        }
        get
        {
            return ddlPhoneType.SelectedValue;
        }
    }
    public int SelectedIndex
    {
        set
        {
            ddlPhoneType.SelectedIndex = value;
        }
        get
        {
            return ddlPhoneType.SelectedIndex;
        }
    }
    public string PhoneNumber
    {
        set
        {
            txtPhoneNumber.Text = value;
        }
        get
        {
            return txtPhoneNumber.Text;
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
            ROOT = xmlData.CreateElement("PHONE");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;
        foreach (XmlNode node in xmlData.SelectNodes("PHONE/DATA/PHN_TYPE_ID"))
        {
            if (node.InnerText == ddlPhoneType.SelectedValue)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Selected phone type already inserted')", true);
                add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("PHN_TYPE_ID");
            element.InnerText = ddlPhoneType.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEYID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("PHN_TYPE_VALUE");
            element.InnerText = ddlPhoneType.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("PHN_NO");
            element.InnerText = txtPhoneNumber.Text;
            dataElement.AppendChild(element);
            txtData.Text = xmlData.OuterXml;
            LoadItemData();
            txtPhoneNumber.Text = ""; ddlPhoneType.SelectedIndex = 0;
        }

    }
    void LoadItemData()
    {
        DataSet dataSet = new DataSet();
        if (txtData.Text != "")
        {

            dataSet.ReadXml(new StringReader(txtData.Text));
            gvAddPhone.DataSource = dataSet.Tables[0];
            gvAddPhone.DataBind();
            foreach (GridViewRow row in gvAddPhone.Rows)
            {
                if (gvAddPhone.DataKeys[row.RowIndex].Value.ToString() == "2")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
            }

        }
        else
        {
            gvAddPhone.DataSource = "";
            gvAddPhone.DataBind();

        }
    }

    public string GetXML
    {
        get
        {
            return txtData.Text;
        }
    }

    protected void btnAddPhone_Click(object sender, EventArgs e)
    {
        AddNewItem();
    }
    protected void gvAddPhone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PHONE/DATA/KEYID");
        nodeList[e.RowIndex].InnerText = "2";
        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
            txtData.Text = "";
        LoadItemData();
    }
    public void ShowPhoneData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<PHONE>");
            xmlString = xmlString.Replace("</NewDataSet>", "</PHONE>");
            xmlString = xmlString.Replace("<Table3>", "<DATA>");
            xmlString = xmlString.Replace("</Table3>", "</DATA>");
            xmlString = xmlString.Replace("<NewDataSet />", "");
            txtData.Text = xmlString;
            LoadItemData();
        }
        else
        {
            txtData.Text = "";
            LoadItemData();
        }

    }

    protected void gvAddPhone_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(txtData.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("PHONE/DATA");
            ddlPhoneType.SelectedValue = nodeList[index]["PHN_TYPE_ID"].InnerText.ToString();
            txtPhoneNumber.Text = nodeList[index]["PHN_NO"].InnerText;
            btnAddPhone.Visible = false;
            btnUpdate.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("PHONE/DATA");
        nodeList[index]["PHN_TYPE_ID"].InnerText = ddlPhoneType.SelectedValue;
        nodeList[index]["PHN_TYPE_VALUE"].InnerText = ddlPhoneType.SelectedItem.Text;
        nodeList[index]["PHN_NO"].InnerText = txtPhoneNumber.Text;

        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
            txtData.Text = "";
        LoadItemData();
        Clear();
    }

    void Clear()
    {
        txtPhoneNumber.Text = "";
        ddlPhoneType.SelectedIndex = 0;
    }
}

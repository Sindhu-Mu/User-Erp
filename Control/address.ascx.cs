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

public partial class control_address : System.Web.UI.UserControl
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;


    protected void Page_Load(object sender, EventArgs e)
    {
        Initilize();
        btnAdd.Attributes.Add("onclick", "return Addressvalidation()");
        if (!IsPostBack)
        {
            ViewState["dt"] = "";
            PushData();
           // fillFunctions.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CITY), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlAddressType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdrsType), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initilize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();

    }
    void PushData()
    {
        fillFunctions.Fill(ddlCountry, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Country), true, FillFunctions.FirstItem.Select);

    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (TextBox1.Text != "")
        {
            xmlData.LoadXml(TextBox1.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("ADD");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("ADD/DATA/ADD_TYPE_ID");
        foreach (XmlNode node in nodeList)
        {
            if (node.InnerText == ddlAddressType.SelectedValue)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Selected address type already inserted')", true);
                add = false;
                break;
            }
        }

        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("ADD_TYPE_ID");
            element.InnerText = ddlAddressType.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEYID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ADD_TYPE_VALUE");
            element.InnerText = ddlAddressType.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ADD_1");
            element.InnerText = txtAddress1.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ADD_2");
            element.InnerText = txtAddress2.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("COU_ID");
            element.InnerText = ddlCountry.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("COU_VALUE");
            element.InnerText = ddlState.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("STA_ID");
            element.InnerText = ddlState.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("STA_VALUE");
            element.InnerText = ddlState.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("CIT_VALUE");
            element.InnerText = ddlCity.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("CIT_ID");
            element.InnerText = ddlCity.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("PINCODE");
            element.InnerText = txtPin.Text;
            dataElement.AppendChild(element);

            TextBox1.Text = xmlData.OuterXml;
            txtAddress1.Text = txtAddress2.Text = txtPin.Text="";
            ddlAddressType.SelectedIndex = ddlCity.SelectedIndex = ddlState.SelectedIndex = ddlCountry.SelectedIndex = 0;

        }
        LoadData();
    }
    protected void gridData_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(TextBox1.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("ADD/DATA");
            ddlAddressType.SelectedValue = nodeList[index]["ADD_TYPE_ID"].InnerText.ToString();           
            ddlCountry.SelectedValue = nodeList[index]["COU_ID"].InnerText.ToString();
            fillFunctions.Fill(ddlCountry, ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State, ddlCountry.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlState.SelectedValue = nodeList[index]["STA_ID"].InnerText.ToString();
            fillFunctions.Fill(ddlState, ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlCity.SelectedValue = nodeList[index]["CIT_ID"].InnerText.ToString();
            txtAddress1.Text = nodeList[index]["ADD_1"].InnerText;
            txtAddress2.Text = nodeList[index]["ADD_2"].InnerText;
            txtPin.Text = nodeList[index]["PINCODE"].InnerText.ToString();
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("ADD/DATA");
        nodeList[index]["ADD_TYPE_ID"].InnerText = ddlAddressType.SelectedValue;
        nodeList[index]["ADD_TYPE_VALUE"].InnerText = ddlAddressType.SelectedItem.Text;
        nodeList[index]["ADD_1"].InnerText = txtAddress1.Text;
        nodeList[index]["ADD_2"].InnerText = txtAddress2.Text;
        nodeList[index]["COU_ID"].InnerText = ddlCountry.SelectedValue;
        nodeList[index]["STA_ID"].InnerText = ddlState.SelectedValue;
        nodeList[index]["COU_VALUE"].InnerText = ddlCountry.SelectedItem.Text;
        nodeList[index]["STA_VALUE"].InnerText = ddlState.SelectedItem.Text;
        nodeList[index]["CIT_VALUE"].InnerText = ddlCity.SelectedItem.Text;
        nodeList[index]["CIT_ID"].InnerText = ddlCity.SelectedValue;
        nodeList[index]["PINCODE"].InnerText = txtPin.Text;
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
        Clear();
    }

    void Clear()
    {
        ddlCity.SelectedIndex = ddlState.SelectedIndex = ddlAddressType.SelectedIndex =ddlCountry.SelectedIndex= 0;
        txtAddress1.Text = txtAddress2.Text =txtPin.Text= "";
    }
    void LoadData()
    {
        try
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox1.Text));

            if (TextBox1.Text != "")
            {
                gridData.DataSource = dataSet.Tables[0];
                gridData.DataBind();
                foreach (GridViewRow row in gridData.Rows)
                {
                    if (gridData.DataKeys[row.RowIndex].Value.ToString() == "2")
                    {
                        row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                gridData.DataSource = "";
                gridData.DataBind();
            }

        }
        catch
        {
            gridData.Columns[3].Visible = false;
            gridData.DataBind();

        }
    }
    protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ADD/DATA/KEYID");
        nodeList[e.RowIndex].InnerText = "2";
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCountry, ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State, ddlCountry.SelectedValue), true, FillFunctions.FirstItem.Select);

        }
        else
            commonFunctions.Clear(ddlCountry, CommonFunctions.ClearType.Value, ddlState);
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlState, ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.Select);

        }
        else
            commonFunctions.Clear(ddlState, CommonFunctions.ClearType.Value, ddlCity);

    }
    public string GetXML
    {
        get
        {
            return TextBox1.Text;
        }
    }

    public void ShowAddData(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            ViewState["dt"] = dt;
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<ADD>");
            xmlString = xmlString.Replace("</NewDataSet>", "</ADD>");
            xmlString = xmlString.Replace("<Table2>", "<DATA>");
            xmlString = xmlString.Replace("</Table2>", "</DATA>");
            TextBox1.Text = xmlString;
            LoadData();
        }
        else
        {
            TextBox1.Text = "";
            LoadData();
        }

    }
  
}

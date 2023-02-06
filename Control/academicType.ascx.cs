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
using System.Text;
using System.Xml;
using System.IO;
using System.Data.SqlClient;

public partial class control_academicType : System.Web.UI.UserControl
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
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlAcademicBase, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Academic), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlBoard, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Board), true, FillFunctions.FirstItem.Select);
            fillFunctions.FillYear(DateTime.Now.Year - 40, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlYear);
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

    protected void btnAddAcademic_Click(object sender, EventArgs e)
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
            ROOT = xmlData.CreateElement("ACA");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA/ACA_BASE_ID");
        foreach (XmlNode node in nodeList)
        {
            if (node.InnerText == ddlAcademicBase.SelectedValue)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Selected Qualification type already inserted')", true);
                add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("ACA_BASE_ID");
            element.InnerText = ddlAcademicBase.SelectedValue;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("STU_ACA_ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEYID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_BASE_FULL_NAME");
            element.InnerText = ddlAcademicBase.SelectedItem.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("ACA_BRD_ID");
            element.InnerText = ddlBoard.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_BRD_FULL_NAME");
            element.InnerText = ddlBoard.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("SCH");
            element.InnerText = txtSchool.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("SPEC");
            element.InnerText = txtSpec.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("YER");
            element.InnerText = ddlYear.SelectedValue;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("TOT_MARKS");
            element.InnerText = txtTotalMks.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("TOT_GAIN");
            element.InnerText = txtObtMrks.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("PRSNT");
            element.InnerText = txtPercentage.Text;
            dataElement.AppendChild(element);

            

            TextBox1.Text = xmlData.OuterXml;
        }
        LoadData();
        Clear();
    }
    void LoadData()
    {
        try
        {
            DataSet dataSet = new DataSet();
            DataSet ds = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox1.Text));
            ds = dataSet;
            gridAcademic.DataSource = dataSet.Tables[0];
            if (TextBox1.Text != "")
            {
                gridAcademic.DataBind();
            }
            foreach (GridViewRow row in gridAcademic.Rows)
            {
                if (gridAcademic.DataKeys[row.RowIndex].Value.ToString() == "2")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        catch
        {
            gridAcademic.DataBind();
        }
    }
    protected void gridAcademic_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA/KEYID");
        nodeList[e.RowIndex].InnerText = "2";
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
    }

    public string GetXML
    {
        get
        {
            return TextBox1.Text;
        }
    }
    public void ShowAcademic(DataTable dt)
    {

        StringWriter writer = new StringWriter();
        dt.WriteXml(writer);
        string xmlString = writer.GetStringBuilder().ToString();
        xmlString = xmlString.Replace("<NewDataSet>", "<ACA>");
        xmlString = xmlString.Replace("</NewDataSet>", "</ACA>");
        xmlString = xmlString.Replace("<Table5>", "<DATA>");
        xmlString = xmlString.Replace("</Table5>", "</DATA>");
        TextBox1.Text = xmlString;
        LoadData();
    }
    protected void txtObtMrks_TextChanged(object sender, EventArgs e)
    {
        double total = Convert.ToDouble(txtTotalMks.Text);
        double obtained = Convert.ToDouble(txtObtMrks.Text);
        double percent = (obtained * 100) / total;
        txtPercentage.Text = percent.ToString("N2");
    }
    protected void gridAcademic_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(TextBox1.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA");
            ddlAcademicBase.SelectedValue = nodeList[index]["ACA_BASE_ID"].InnerText.ToString();
            ddlBoard.SelectedValue = nodeList[index]["ACA_BRD_ID"].InnerText.ToString();
            txtSchool.Text = nodeList[index]["SCH"].InnerText;
            txtSpec.Text = nodeList[index]["SPEC"].InnerText;
            ddlYear.SelectedValue = nodeList[index]["YER"].InnerText.ToString();
            txtPercentage.Text = nodeList[index]["PRSNT"].InnerText;
            txtTotalMks.Text = nodeList[index]["TOT_MARKS"].InnerText;
            txtObtMrks.Text = nodeList[index]["TOT_GAIN"].InnerText;
            btnAddAcademic.Visible = false;
            btnUpdate.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA");
        nodeList[index]["ACA_BASE_ID"].InnerText = ddlAcademicBase.SelectedValue;
        nodeList[index]["ACA_BASE_FULL_NAME"].InnerText = ddlAcademicBase.SelectedItem.Text;
        nodeList[index]["ACA_BRD_ID"].InnerText = ddlBoard.SelectedValue;
        nodeList[index]["ACA_BRD_FULL_NAME"].InnerText = ddlBoard.SelectedItem.Text;
        nodeList[index]["SCH"].InnerText = txtSchool.Text;
        nodeList[index]["SPEC"].InnerText = txtSpec.Text;
        nodeList[index]["YER"].InnerText = ddlYear.SelectedValue;
        nodeList[index]["PRSNT"].InnerText = txtPercentage.Text;
        nodeList[index]["TOT_MARKS"].InnerText = txtTotalMks.Text;
        nodeList[index]["TOT_GAIN"].InnerText = txtObtMrks.Text;
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
        Clear();
    }
    void Clear()
    {
        ddlAcademicBase.SelectedIndex = ddlBoard.SelectedIndex = ddlYear.SelectedIndex = 0;
        txtObtMrks.Text = txtPercentage.Text = txtSchool.Text = txtSpec.Text = txtTotalMks.Text = "";
    }
}

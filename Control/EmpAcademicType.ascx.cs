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

public partial class Control_EmpAcademicType : System.Web.UI.UserControl
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
            fillFunctions.FillYear(DateTime.Now.Year - 55, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlYear);
            fillFunctions.Fill(ddlQual, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.EmpCrs), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlDivision, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Div), true, FillFunctions.FirstItem.Select);
            ViewState["index"] = "";
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
        XmlNodeList nodeList1 = xmlData.SelectNodes("ACA/DATA/ACA_CRS_ID");
        XmlNodeList nodeList2 = xmlData.SelectNodes("ACA/DATA/SPEC");
        foreach (XmlNode node in nodeList)
        {

            if (node.InnerText == ddlAcademicBase.SelectedValue)
            {
                foreach (XmlNode node1 in nodeList1)
                {
                    if (node.InnerText == ddlQual.SelectedValue)
                    {
                        foreach (XmlNode node2 in nodeList2)
                        {
                            if (node.InnerText == txtSpec.Text)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Selected Qualification type with same course name already inserted')", true);
                                add = false;
                                break;
                            }
                        }
                    }
                }
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("ACA_BASE_ID");
            element.InnerText = ddlAcademicBase.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("EMP_ACA_ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEYID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_BASE_FULL_NAME");
            element.InnerText = ddlAcademicBase.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_CRS_ID");
            element.InnerText = ddlQual.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_CRS_VALUE");
            element.InnerText = ddlQual.SelectedItem.Text;
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

            element = xmlData.CreateElement("ACA_TYPE_ID");
            element.InnerText = ddlBaseType.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_TYPE_VALUE");
            element.InnerText = ddlBaseType.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("SPEC");
            element.InnerText = txtSpec.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("YER");
            element.InnerText = ddlYear.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("PRSNT");
            element.InnerText = txtPercentage.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("TOTAL_MARKS");
            element.InnerText = txtTotalMks.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("OBT_MARKS");
            element.InnerText = txtObtMrks.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("DIV_ID");
            element.InnerText = ddlDivision.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("DIV_VALUE");
            element.InnerText = ddlDivision.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("IN_BY");
            element.InnerText = Session["UserId"].ToString();
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
            dataSet.ReadXml(new StringReader(TextBox1.Text));

            if (TextBox1.Text != "")
            {
                gridAcademic.DataSource = dataSet.Tables[0];
                gridAcademic.DataBind();
                foreach (GridViewRow row in gridAcademic.Rows)
                {
                    if (gridAcademic.DataKeys[row.RowIndex].Value.ToString() == "2")
                    {
                        row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                gridAcademic.DataSource = "";
                gridAcademic.DataBind();
            }


        }
        catch
        {
            gridAcademic.Columns[5].Visible = false;
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
        if (dt.Rows.Count > 0)
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
        else
        {
            TextBox1.Text = "";
            LoadData();
        }
    }
    void Clear()
    {
        txtObtMrks.Text = txtPercentage.Text = txtSchool.Text = txtSpec.Text = txtTotalMks.Text = "";
        ddlAcademicBase.SelectedIndex = ddlBoard.SelectedIndex = ddlDivision.SelectedIndex = ddlBaseType.SelectedIndex = ddlQual.SelectedIndex = ddlYear.SelectedIndex = 0;
    }
    protected void txtObtMrks_TextChanged(object sender, EventArgs e)
    {
        double total = Convert.ToDouble(txtTotalMks.Text);
        double obtained = Convert.ToDouble(txtObtMrks.Text);
        double percent = (obtained * 100) / total;
        txtPercentage.Text = (obtained == 0 && total == 0) ? "0" : percent.ToString("N2");
        if (ViewState["index"].ToString()!= "")
        {
            btnUpdate.Visible = true;
            btnAddAcademic.Visible = false;
        }
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
            ddlYear.SelectedValue = nodeList[index]["YER"].InnerText.ToString();
            ddlQual.SelectedValue = nodeList[index]["ACA_CRS_ID"].InnerText;
            txtSchool.Text = nodeList[index]["SCH"].InnerText;
            ddlBaseType.SelectedValue = nodeList[index]["ACA_TYPE_ID"].InnerText;
            txtSpec.Text = nodeList[index]["SPEC"].InnerText;
            ddlYear.SelectedValue = nodeList[index]["YER"].InnerText;
            txtPercentage.Text = nodeList[index]["PRSNT"].InnerText;
            ddlDivision.SelectedValue = (nodeList[index]["DIV_ID"].InnerText != "0") ? nodeList[index]["DIV_ID"].InnerText : ".";
            btnAddAcademic.Visible = false;
            btnUpdate.Visible = true;
        }
    }
    protected void btnUpdateAcademic_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA");
        nodeList[index]["ACA_BASE_ID"].InnerText = ddlAcademicBase.SelectedValue;
        nodeList[index]["ACA_BASE_FULL_NAME"].InnerText = ddlAcademicBase.SelectedItem.Text;
        nodeList[index]["ACA_BRD_ID"].InnerText = ddlBoard.SelectedValue;
        nodeList[index]["ACA_BRD_FULL_NAME"].InnerText = ddlBoard.SelectedItem.Text;
        nodeList[index]["ACA_CRS_ID"].InnerText = ddlQual.SelectedValue;
        nodeList[index]["SCH"].InnerText = txtSchool.Text;
        nodeList[index]["ACA_TYPE_ID"].InnerText = ddlBaseType.SelectedValue;
        nodeList[index]["ACA_TYPE_VALUE"].InnerText = ddlBaseType.SelectedItem.Text;
        nodeList[index]["SPEC"].InnerText = txtSpec.Text;
        nodeList[index]["YER"].InnerText = ddlYear.SelectedValue;
        nodeList[index]["PRSNT"].InnerText = txtPercentage.Text;
        nodeList[index]["DIV_ID"].InnerText = (ddlDivision.SelectedValue != ".") ? ddlDivision.SelectedValue : "0";
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
        Clear();
    }
}
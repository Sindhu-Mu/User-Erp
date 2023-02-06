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

public partial class control_experienceType : System.Web.UI.UserControl
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    string Msg;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initilize();
        btnAddExp.Attributes.Add("onclick", "return validation()");
        btnOrgSave.Attributes.Add("onclick", "return validate()");
        if (!IsPostBack)
        {
            PushData();
        }

    }
    void Initilize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
    }

    void PushData()
    {

        fillFunctions.Fill(ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlOrg, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Organization), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OrgType), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlExpType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ExpType), true, FillFunctions.FirstItem.Select);
    }
    protected void btnAddExp_Click(object sender, EventArgs e)
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
            ROOT = xmlData.CreateElement("EXP");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        //XmlNodeList nodeList = xmlAcademic.SelectNodes("EXP/DATA/FRM_DATE");
        //foreach (XmlNode node in nodeList)
        //{
        //    if (node.InnerText == txtFromDate.getDate)
        //    {
        //        Messages.DisplayMessage(Page, Messages.GetMessage(Messages.MessType.DuplicateRecord));
        //        add = false;
        //        break;
        //    }
        //}
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);
            XmlElement element = xmlData.CreateElement("EXP_TYPE_ID");
            element.InnerText = ddlExpType.SelectedValue;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("KEYID");
            element.InnerText = "0";
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("EXP_TYPE_VALUE");
            element.InnerText = ddlExpType.SelectedItem.Text;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("EXP_DESIG");
            element.InnerText = txtDesignation.Text;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("ORG_ID");
            element.InnerText = ddlOrg.SelectedValue;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("ORG_NAME");
            element.InnerText = ddlOrg.SelectedItem.Text;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("FRM_DATE");

            element.InnerText = commonFunctions.GetDateTime(txtFromDT.Text).ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("TO_DATE");
            element.InnerText = commonFunctions.GetDateTime(txtToDT.Text).ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);
            TextBox1.Text = xmlData.OuterXml;
        }
        Clear();
        LoadData();
    }
    void LoadData()
    {
        if (TextBox1.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox1.Text));
            gridExperience.DataSource = dataSet.Tables[0];
            gridExperience.DataBind();
            foreach (GridViewRow row in gridExperience.Rows)
            {
                //row.Cells[4].Text = commonFunctions.GetDateTime(row.Cells[4].Text).ToString("dd/MM/yyyy");
                //row.Cells[5].Text = commonFunctions.GetDateTime(row.Cells[5].Text).ToString("dd/MM/yyyy");
                if (gridExperience.DataKeys[row.RowIndex].Value.ToString() == "2")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        else
        {
            gridExperience.DataSource = "";
            gridExperience.DataBind();
        }
    }
    void Clear()
    {
        txtAddress.Text = txtFromDT.Text = txtToDT.Text = txtDesignation.Text = txtJobDesc.Text = "";
        ddlOrg.SelectedIndex = ddlExpType.SelectedIndex = 0;
    }
    protected void gridExperience_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("EXP/DATA/KEYID");
        nodeList[e.RowIndex].InnerText = "2";
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
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
    protected void btnOrgSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.ORGNAME = txtOrgName.Text;
        ObjHrBal.ORGADD = txtAddress.Text;
        ObjHrBal.ORGTYPEID = ddlType.SelectedValue;
        ObjHrBal.CITYID = ddlCity.SelectedValue;
        ObjHrBal.ORGNAME = txtOrgName.Text;
        Msg = ObjHrBll.OrganizationInsert(ObjHrBal);
        fillFunctions.Fill(ddlOrg, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Organization), true, FillFunctions.FirstItem.Select);
    }
    public string GetXML
    {
        get
        {
            return TextBox1.Text;
        }
    }
    public void ShowExperience(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<EXP>");
            xmlString = xmlString.Replace("</NewDataSet>", "</EXP>");
            xmlString = xmlString.Replace("<Table6>", "<DATA>");
            xmlString = xmlString.Replace("</Table6>", "</DATA>");
            TextBox1.Text = xmlString;
            LoadData();
        }
        else
        {
            TextBox1.Text = "";
            LoadData();
        }
    }


    protected void gridExperience_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(TextBox1.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("EXP/DATA");

            ddlExpType.SelectedValue = nodeList[index]["EXP_TYPE_ID"].InnerText.ToString();
            ddlOrg.SelectedValue = nodeList[index]["ORG_ID"].InnerText.ToString();
            txtDesignation.Text = nodeList[index]["EXP_DESIG"].InnerText;
            DateTime date = commonFunctions.GetDateTime(nodeList[index]["FRM_DATE"].InnerText);
            txtFromDT.Text = date.ToString("dd/MM/yyyy");
            date = commonFunctions.GetDateTime(nodeList[index]["TO_DATE"].InnerText);
            txtToDT.Text = date.ToString("dd/MM/yyyy");
            btnAddExp.Visible = false;
            btnUpdate.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("EXP/DATA");
        nodeList[index]["KEYID"].InnerText = "3";
        nodeList[index]["EXP_TYPE_ID"].InnerText = ddlExpType.SelectedValue;
        nodeList[index]["EXP_TYPE_VALUE"].InnerText = ddlExpType.SelectedItem.Text;
        nodeList[index]["ORG_ID"].InnerText = ddlOrg.SelectedValue;
        nodeList[index]["ORG_NAME"].InnerText = ddlOrg.SelectedItem.Text;
        nodeList[index]["FRM_DATE"].InnerText = commonFunctions.GetDateTime(txtFromDT.Text).ToString();
        nodeList[index]["TO_DATE"].InnerText = commonFunctions.GetDateTime(txtToDT.Text).ToString();
        nodeList[index]["EXP_DESIG"].InnerText = txtDesignation.Text;
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
        Clear();
    }
}

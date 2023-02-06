using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Finance_FeeFineAppDateCase : System.Web.UI.Page
{
    QueryFunctions queryfunctions;
    FillFunctions fillfunction;
    SFBAL Objbal;
    SFBLL Objbll;
    DataTable dt;
    CommonFunctions cf;

    protected void Initialize()
    {
        queryfunctions = new QueryFunctions();
        fillfunction = new FillFunctions();
        Objbal = new SFBAL();
        Objbll = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Visible = false;
      
        if (!IsPostBack)
        {
            //btnshow.Attributes.Add("OnClick", "return validation()");
            btnAdd.Attributes.Add("OnClick", "return validation1()");
        }
    }
    protected void gvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
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
       Objbal.balData = txtdata.Text;
       Objbll.FineAppDateCaseInsert(Objbal);
       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Inserted Succesfully.')", true);
       txtEnroll.Text = txtdate.Text = txtRemark.Text = "";
       gvAdd.DataSource = "";
       gvAdd.DataBind();
    }
    //protected void btnshow_Click(object sender, EventArgs e)
    //{
    //    Objbal.balEnrollment = txtEnroll.Text;
    //    Student.ShowStudent(txtEnroll.Text);
    //}
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Add();
        btnSave.Visible = true;
        txtEnroll.Text=txtdate.Text=txtRemark.Text = "";
       
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
        XmlElement element = xmlData.CreateElement("STU_ADM_NO");
        element.InnerText = txtEnroll.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("INSERT_BY");
        element.InnerText = Session["UserId"].ToString();
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("REMARK");
        element.InnerText = txtRemark.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FINE_START_DATE");
        element.InnerText = cf.GetDateTime(txtdate.Text).ToString("yyyy-MM-dd");
       
        dataElement.AppendChild(element);
        txtdata.Text = xmlData.OuterXml;
        AddXmlData();
    }
    void AddXmlData()
    {
        if (txtdata.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtdata.Text));
            gvAdd.DataSource = dataSet.Tables[0];
            gvAdd.DataBind();
            dataSet.Dispose();
        }
        else
        {
            gvAdd.DataSource = null;
            gvAdd.DataBind();
        }
       
    }
}
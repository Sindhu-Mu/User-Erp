using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class StudentFinance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunctions;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["UserName"]) == "") Response.Redirect("../common/login.aspx");
        Page.Title = "Welcome To MangalDarpan | Fee Lab Fine";
        btnShow.Attributes.Add("OnClick", "return valid()");
        btnSave.Attributes.Add("OnClick", "return validSave()");
        Initialize();  
        if (!IsPostBack)
        {
            trfine.Visible = false;
            fillfunction.Fill(ddlSemester,queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Semester),true,FillFunctions.FirstItem.Select);
            FillGrid();
            
        }
        
    }
    protected void Initialize()
    {
        queryfunctions= new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        balObj.balEnrollment = txtEnrollment.Text;
        Student.ShowStudent(txtEnrollment.Text);
        if (ddlBranch.Items.Count == 0)
        {
            fillfunction.Fill(ddlBranch, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.StuBranch, txtEnrollment.Text), true, FillFunctions.FirstItem.Select);
            ddlBranch.SelectedIndex = 1;
        }
        trfine.Visible = true;
        fillfunction.Fill(ddlCase, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.FineCase), true, FillFunctions.FirstItem.Select);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        balObj.balEnrollment = txtEnrollment.Text;
        balObj.balAmount = txtAmount.Text;
        balObj.balRemark = txtRemark.Text;
        balObj.balCase = ddlCase.SelectedValue;
        balObj.balSession = Session["UserId"].ToString();
        balObj.balStatus = "1";
        bllObj.FineInsert(balObj);
       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fine detail inserted successfully.')", true);
       FillGrid();
       Clear();
       trfine.Visible = false;

    }
    protected void gvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        txtData.Text = "";
        Add(gvShow.DataKeys[e.RowIndex].Value.ToString(), "4");
        if (txtData.Text != "")
        {
            bllObj.FineTranInsert(txtData.Text);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fine detail Deleted successfully.')", true);
            FillGrid();
            txtData.Text = "";
        }
        FillGrid();


    }
    public void Clear()
    {
        txtEnrollment.Text = txtAmount.Text = txtRemark.Text = "";
        ddlSemester.SelectedIndex = ddlCase.SelectedIndex = 0;
        cf.Clear(CommonFunctions.ClearType.Value, ddlBranch);
        
    }
    public void FillGrid()
    {
        balObj.balSession = Session["UserId"].ToString();
        dt = bllObj.FineProcessSelect(balObj);
        gvShow.DataSource = dt;
        gvShow.DataBind();
        
    
    }
    void Add(string Fine_Id, string Fine_Status_Id)
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
            ROOT = xmlData.CreateElement("FINE");
            xmlData.AppendChild(ROOT);
        }
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("FINE_ID");
        element.InnerText = Fine_Id;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("INSERT_BY");
        element.InnerText = Session["UserId"].ToString();
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("REMARK");
        element.InnerText = "";
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FINE_STATUS_ID");
        element.InnerText = Fine_Status_Id;
        dataElement.AppendChild(element);
        txtData.Text = xmlData.OuterXml;
    }

}
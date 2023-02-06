using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml;

public partial class TrainingAndPlacement_TNP_Interview_Shedule : System.Web.UI.Page
{
    FillFunctions fillFunction;
    QueryFunctions queryFunctions;
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunction;
    TPBAL ObjBal;
    TPBLL ObjBll;
    DataSet ds;
    string msg;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            btnAdd.Attributes.Add("OnClick", "return validation()");
            fillFunction.Fill(ddlprofile, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Comp_profile), true, FillFunctions.FirstItem.Select);
            fillFunction.Fill(ddlcourse,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Course), true, FillFunctions.FirstItem.Select);
            fillFunction.Fill(ddlSession, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
            fillFunction.Fill(ddlsem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            //fillFunction.Fill(ddljobprofile,quer)
            btnsave.Visible = false;
        }
    }
    void initialise()
    {
        fillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        commonFunction = new CommonFunctions();
        ObjBal = new TPBAL();
        ObjBll = new TPBLL();
        ds = new DataSet();
    }
  
    public void Add()
    {
        XmlDocument xmlData = new XmlDocument();


        XmlElement ROOT;
        if (txtxml.Text != "")
        {
            xmlData.LoadXml(txtxml.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("TNP");
            xmlData.AppendChild(ROOT);
        }
        
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("COMP_Name");
            element.InnerText = ddlcompany.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("COMP_ID");
            element.InnerText = ddlcompany.SelectedValue;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("JOB_PROFILE");
            element.InnerText = ddljobprofile.SelectedItem.Text;
            dataElement.AppendChild(element);
            
            element = xmlData.CreateElement("JOB_PROFILE_ID");
            element.InnerText = ddljobprofile.SelectedValue;
            dataElement.AppendChild(element);

            
            element = xmlData.CreateElement("PGM_BRN_ID");
            element.InnerText = ddlbranch.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("BRN_SHORT_NAME");
            element.InnerText = ddlbranch.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_SEM_ID");
            element.InnerText = ddlsem.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_SEM_NO");
            element.InnerText = ddlsem.SelectedItem.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("ACA_SESN_ID");
            element.InnerText =ddlSession.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ACA_SESN_VALUE");
            element.InnerText = ddlSession.SelectedItem.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("SALARY");
            element.InnerText =txtsalary.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("VACANCY");
            element.InnerText =txtvacancy.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("JOB_LOCATION");
            element.InnerText =txtlocation.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("INTERVIEW_DT");
            element.InnerText =commonFunction.GetDateTime(txtdate.Text).ToString("yyyy-MM-dd");
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("OTHERS");
            element.InnerText =txtothers.Text;
            dataElement.AppendChild(element);


            txtxml.Text = xmlData.InnerXml;
            AddXmlData();
        }
    public void AddXmlData()
    {
        if (txtxml.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtxml.Text));
            GvShow.DataSource = dataSet.Tables[0];
            GvShow.DataBind();
        }
        else
        {
            GvShow.DataSource = null;
            GvShow.DataBind();
        }
    }
    public void clear()
    {
        ddlprofile.SelectedIndex = 0;
        ddljobprofile.SelectedIndex = 0; ddlcompany.SelectedIndex= ddlbranch.SelectedIndex = ddlsem.SelectedIndex = ddlSession.SelectedIndex = 0;
            txtvacancy.Text = txtsalary.Text = txtothers.Text = txtlocation.Text = txtdate.Text = "";
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ObjBal.xml = txtxml.Text;
        ObjBll.GetIntSchedule(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Interview Schedule Inserted Successfully.')", true);
        GvShow.DataSource = "";
        GvShow.DataBind();
        txtxml.Text = "";
    }
    protected void ddlprofile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlprofile.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlcompany, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Company, ddlprofile.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
   
    
    protected void ddlcourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcourse.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlbranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlcourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcompany.SelectedIndex > 0)
        {
            fillFunction.Fill(ddljobprofile, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job_profile, ddlcompany.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        btnsave.Visible = true;
        Add();
       clear();
    }
    protected void GvShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtxml.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("TNP/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtxml.Text = xmlData.OuterXml;
        else
        {
            txtxml.Text = "";
        }
        msg = "Shedule deleted from list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        AddXmlData();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

public partial class TrainingAndPlacement_TNP_Add_Interview_Reg : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    TPBAL ObjBal;
    TPBLL ObjBll;

    void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        ObjBal=new TPBAL();
        ObjBll=new TPBLL();
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
            ROOT = xmlData.CreateElement("ADD");
            xmlData.AppendChild(ROOT);
        }
    
           XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            
            XmlElement element = xmlData.CreateElement("ENROLLMENT_NO");
            element.InnerText = txtEnrollment.Text;
            dataElement.AppendChild(element);

            txtxml.Text = xmlData.OuterXml;
            AddXmlData();
       
    }
    public void AddXmlData()
    {
        if (txtxml.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtxml.Text));
            GvAdd.DataSource = dataSet.Tables[0];
            GvAdd.DataBind();
        }
        else
        {
            GvAdd.DataSource = null;
            GvAdd.DataBind();
        }
    }
    public void clear()
    {
        ddlcompany.SelectedIndex = ddljobprofile.SelectedIndex = ddlInterviewDate.SelectedIndex = 0;
        txtEnrollment.Text = "";
        GvShow.DataSource = "";
        GvShow.DataBind();
        GvAdd.DataSource = "";
        GvAdd.DataBind();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            btnshow.Attributes.Add("OnClick", "return validation()");
            btnsave.Attributes.Add("OnClick", "return validation1()");
            fillFunction.Fill(ddlcompany, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.cmpny), true, FillFunctions.FirstItem.Select);
            trOld.Visible = false;
            GvAdd.Visible = false;
            btnsave.Visible = false;
        }
    }
    protected void ddlcompany_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlcompany.SelectedIndex > 0)
        {
            fillFunction.Fill(ddljobprofile, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Job_profile,ddlcompany.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddljobprofile_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddljobprofile.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlInterviewDate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Intdate, ddljobprofile.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ddlInterviewDate.SelectedValue;
        fillFunction.Fill(GvShow, ObjBll.INT_ATT_SELECT(ObjBal).Tables[0]);
        trOld.Visible = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        GvAdd.Visible = true;
        btnsave.Visible = true;
        Add();   
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        ObjBal.xml = txtxml.Text;
        
        ObjBal.Id = ddlInterviewDate.SelectedValue;

       // ObjBal.Enrollment = txtEnrollment.Text;
        ObjBll.ADD_INT_REG(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Added Enrollments Are Registered.')", true);
        clear();
    }
}
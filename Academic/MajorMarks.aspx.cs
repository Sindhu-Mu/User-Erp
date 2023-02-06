using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;
public partial class Academic_MajorMarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    QueryFunctions queryFunctions;
    String msg;
    ExamFunctions.QueryFunctions query;
    ExamFunctions.FillFunctions fill;
    DataSet ds;
    
    int i = 0;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        query = new ExamFunctions.QueryFunctions();
        fill = new ExamFunctions.FillFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            btnAdd.Attributes.Add("OnClick", "return validation()");
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlExam, query.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Examination), true, ExamFunctions.FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPrgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPrgm.Focus();
        }
        else
            ddlPrgm.Items.Clear();

    }
    protected void ddlPrgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPrgm.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlBranch.Focus();
        }
        else
            ddlBranch.Items.Clear();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBranch.SelectedIndex > 0) && (ddlSem.SelectedIndex > 0))
        {
            fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseByBrnchSem, ddlBranch.SelectedValue, ddlSem.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPaper.Focus();
        }
        else
        {
            ddlPaper.Items.Clear();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ddlBranch.Enabled = false;
        ObjBal.Enroll_No = txtEnroll.Text;
        ObjBal.Marks = txtMarks.Text;
        ObjBal.KeyValue = rbWeightage.SelectedValue;
        ObjBal.Pap_Code = ddlPaper.SelectedValue;
        ds = ObjBll.getMarksWeightage(ObjBal);
        if (ds.Tables.Count > 0)
        {
            if (Convert.ToDouble(ds.Tables[1].Rows[0][0].ToString()) < ((Convert.ToDouble(txtMarks.Text) * Convert.ToDouble(rbWeightage.SelectedValue)) / 100))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Weightage marks cannot be more than maximum marks')", true);
                txtMarks.Focus();
                return;
            }
            else if (ds.Tables[0].Rows[0]["EVA_SCH_SUB_ID"].ToString() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Enrollment No.')", true);
                return;
            }
            else
            {
                dt = ds.Tables[0];
                Add(dt);
                LoadData();
                txtEnroll.Text = txtMarks.Text = "";
                txtEnroll.Focus();
                btnSave.Visible = true;
            }
        }
        else
            return;
    }
    void Add(DataTable dt)
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
            ROOT = xmlData.CreateElement("MARKS");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        i = i + 1;

        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("EVA_SCH_SUB_ID");
            element.InnerText = dt.Rows[0]["EVA_SCH_SUB_ID"].ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("STU_MAIN_ID");
            element.InnerText = dt.Rows[0]["STU_MAIN_ID"].ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("MARKS");
            element.InnerText = dt.Rows[0]["MARKS"].ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("ENROLLMENT_NO");
            element.InnerText = dt.Rows[0]["ENROLLMENT_NO"].ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("WEIGHTAGE_MARKS");
            element.InnerText = dt.Rows[0]["WEIGHTAGE_MARKS"].ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("STU_FULL_NAME");
            element.InnerText = dt.Rows[0]["STU_FULL_NAME"].ToString();
            dataElement.AppendChild(element);
        }
        TextBox1.Text = xmlData.OuterXml;
    }
    void LoadData()
    {
        if (TextBox1.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox1.Text));
            gvDetail.DataSource = dataSet.Tables[0];
        }
        else
        {
            gvDetail.DataSource = "";
        }
        gvDetail.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            lblMsg.Text = "Add Student Marks";
            return;
        }
        else
        {
            ObjBal.XmlValue = TextBox1.Text;
            ObjBal.KeyID = ddlExam.SelectedValue;
            ObjBal.KeyValue = rbWeightage.SelectedValue;
            ObjBal.Id = commonFunctions.GetKeyID(txtExaminor);
            ObjBal.EmpId = commonFunctions.GetKeyID(txtScrut);
            ObjBal.SessionUserID = Session["UserId"].ToString();
            msg = ObjBll.MajorMarksInsert(ObjBal).Tables[0].Rows[0][0].ToString();
        }
        Clear();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMajorMarks.aspx?=" + msg + "','_blank','alwaysRaised')", true);
    }
    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("MARKS/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
    }
    void Clear()
    {
        ddlBranch.Enabled = true;
        txtEnroll.Text = txtExaminor.Text = txtMarks.Text = txtScrut.Text = "";
        ddlPaper.SelectedIndex = 0;
        gvDetail.DataSource = "";
        gvDetail.DataBind();
        ddlPaper.Focus();
        TextBox1.Text = "";
    }
}
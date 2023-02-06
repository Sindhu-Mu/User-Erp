using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;
public partial class HR_InterviewPanel : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;


    public void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRound.SelectedIndex = 0;
        ddlInt.Items.Clear();
        trEntry.Visible = false;
    }
    protected void ddlRound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlJob.SelectedIndex > 0) && (ddlRound.SelectedIndex > 0))
        {
            FillFunction.Fill(ddlInt, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntNo, ddlJob.SelectedValue, ddlRound.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlInt.Items.Clear();
        trEntry.Visible = false;
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
            ROOT = xmlData.CreateElement("PANEL");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("PANEL/DATA/EMP_ID");
        foreach (XmlNode node in nodeList)
        {
            if (node.InnerText == common.GetKeyID(txtName))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('This Interviewer already inserted')", true);
                add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("EMP_ID");
            element.InnerText = common.GetKeyID(txtName);
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NAME");
            element.InnerText = txtName.Text.Split(':').GetValue(0).ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("INT_PANEL_SUB_ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEY_ID");
            element.InnerText = "0";
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("MEM_ID");
            ObjHrBAL.EmpId = common.GetKeyID(txtName);
            element.InnerText = ObjHrBll.GetUserId(ObjHrBAL);
            dataElement.AppendChild(element);

            TextBox1.Text = xmlData.OuterXml;
        }
        LoadData();
        Clear();
    }

    public void Show(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<PANEL>");
            xmlString = xmlString.Replace("</NewDataSet>", "</PANEL>");
            xmlString = xmlString.Replace("<Table>", "<DATA>");
            xmlString = xmlString.Replace("</Table>", "</DATA>");
            TextBox1.Text = xmlString;
        }
        else
            TextBox1.Text = "";
        LoadData();
    }
    void LoadData()
    {
        DataSet dataSet = new DataSet();
        if (TextBox1.Text != "")
        {
            dataSet.ReadXml(new StringReader(TextBox1.Text));

            gvInterviewer.DataSource = dataSet.Tables[0];
            if (TextBox1.Text != "")
            {
                gvInterviewer.DataBind();
            }
            foreach (GridViewRow row in gvInterviewer.Rows)
            {
                if (gvInterviewer.DataKeys[row.RowIndex].Values[1].ToString() == "2")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        else
        {
            gvInterviewer.DataSource = "";
            gvInterviewer.DataBind();
        }   
    }
    void Clear()
    {
        txtName.Text = "";
    }
    protected void ddlInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInt.SelectedIndex > 0)
        {
            bindGrid();
        }
        else
            trEntry.Visible = false;
    }
    void bindGrid()
    {
        ObjHrBAL.KeyID = ddlInt.SelectedValue;
        DataTable dt = ObjHrBll.getJobInterviewDetail(ObjHrBAL).Tables[0];
        //if (dt.Rows.Count > 0)
        Show(dt);
        //else
        //    gvInterviewer.Visible = false;
        trEntry.Visible = true;
    }
    protected void gvInterviewer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PANEL/DATA/KEY_ID");
        nodeList[e.RowIndex].InnerText = "2";
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBAL.KeyID = ddlInt.SelectedValue;
        ObjHrBAL.JobId = ddlJob.SelectedValue;
        ObjHrBAL.XmlData = TextBox1.Text;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBll.IntPanelInsert(ObjHrBAL);
        bindGrid();
    }

}
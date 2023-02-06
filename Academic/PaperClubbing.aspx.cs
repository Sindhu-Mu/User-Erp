using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Xml;
public partial class Academic_PaperClubbing : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    string Msg;
    DataSet ds;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillData();
            btnSave.Enabled = false;
        }
    }
    void FillData()
    {
        fillFunctions.Fill(ddlInst, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
    }

    protected void ddlInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        //commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlSemesterBound);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSemester, ddlChooseClass, ddlSection);

    }
    protected void ddlSemesterBound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemesterBound.SelectedIndex > 0)
        {
            AcaBal.InsId = ddlInst.SelectedValue;
            fillFunctions.Fill(ddlChooseClass, AcaBll.GetClasses(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlChooseClass);
    }
    protected void ddlChooseClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlChooseClass.SelectedIndex > 0)
        {
            AcaBal.Semid = ddlSemesterBound.SelectedValue;
            AcaBal.KeyID = ddlChooseClass.SelectedValue;
            fillFunctions.Fill(ddlChoosePaper, AcaBll.GetClassPaper(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlChoosePaper);

    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSemester, ddlSection);

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlCourse, ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlCourse, ddlSection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch, ddlSemester, ddlSection);

    }
    void ClearSelect()
    {
        gridPaperCombination.DataSource = "";
        gridPaperCombination.DataBind();
        txtData.Text = ""; btnSave.Enabled = false;
        ddlSemesterBound.SelectedIndex = ddlInstitution.SelectedIndex = ddlInst.SelectedIndex = 0;
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSemester, ddlSection, ddlPaper, ddlChoosePaper);
    }
    protected void ddlSection_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlSection.SelectedIndex > 0) && (ddlSemester.SelectedIndex > 0) && (ddlBranch.SelectedIndex > 0))
        {
            AcaBal.DeptId = ddlBranch.SelectedValue;
            AcaBal.Semid = ddlSemester.SelectedValue;
            AcaBal.TypeId = ddlSection.SelectedValue;
            fillFunctions.Fill(ddlPaper, AcaBll.GetPaperForMapping(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlPaper);
    }

    protected void gridPaperCombination_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gridPaperCombination.DataKeys[e.RowIndex].Value.ToString();
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtData.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PAP/DATA/TT_ID");
        foreach (XmlNode node in nodeList)
        {
            if (node.InnerText == id)
                xmlData.FirstChild.RemoveChild(node.ParentNode);
        }
        if (xmlData.FirstChild.HasChildNodes)
            txtData.Text = xmlData.OuterXml;
        else
            txtData.Text = "";
    }



    protected void btnMapped_Click(object sender, EventArgs e)
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
            ROOT = xmlData.CreateElement("PAP");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("PAP/DATA/EVA_SCH_SUB_ID");
        foreach (XmlNode node in nodeList)
        {
            if (add)
            {
                if (node.InnerText == ddlPaper.SelectedValue)
                {
                    add = false;
                    break;
                }
            }
            else
                break;
        }
        if (add)
        {
            XmlElement dataElement;
            XmlElement element;
            if (ddlPaper.SelectedIndex > 0)
            {

                dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);
                element = xmlData.CreateElement("TT_ID");
                element.InnerText = ddlChoosePaper.SelectedValue;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("EVA_SCH_SUB_ID");
                element.InnerText = ddlPaper.SelectedValue;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("PAPER_CODE");
                element.InnerText = ddlPaper.SelectedItem.Text;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("SEC_ID");
                element.InnerText = ddlSection.SelectedValue;
                dataElement.AppendChild(element);
            }

            txtData.Text = xmlData.OuterXml;
        }
        if (txtData.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtData.Text));
            gridPaperCombination.DataSource = dataSet.Tables[0];
            gridPaperCombination.DataBind();
            btnSave.Enabled = true;
        }
        else
        {
            gridPaperCombination.DataSource = null;
            gridPaperCombination.DataBind();
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AcaBal.XmlValue = txtData.Text;
        Msg = AcaBll.SavePaperMapping(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        ClearSelect();

    }
}
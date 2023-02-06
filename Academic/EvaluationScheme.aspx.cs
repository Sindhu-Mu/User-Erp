using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.IO;

public partial class Academic_EvaluationScheme : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    Messages Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();

        btnAdd.Attributes.Add("OnClick", "return validation()");
        btnCopy.Attributes.Add("OnClick", "return validationCopy()");
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        Msg = new Messages();
    }

    void LoadData()
    {
        commonFunctions.Clear(repMarksTemplateDetails);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSubjectType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubjectType), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSubject, objBll.GetSubjectName(), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitutionCopy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatchCopy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterCopy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        //
    }

    #region dropdown fill
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);

    }

    protected void ddlInstitutionCopy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitutionCopy.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitutionCopy, ddlCourseCopy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitutionCopy.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitutionCopy, CommonFunctions.ClearType.Value, ddlCourseCopy, ddlBranchCopy);
    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }

    protected void ddlCourseCopy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourseCopy.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourseCopy, ddlBranchCopy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourseCopy.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourseCopy, CommonFunctions.ClearType.Value, ddlBranchCopy);
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedIndex > 0)
        {
            objBal.KeyID = ddlBatch.SelectedValue;
            objBal.ValueType = ddlBranch.SelectedValue;
            fillFunctions.Fill(ddlBranch, ddlSchemeName, objBll.EvaluationSchemeHeading(objBal), true, FillFunctions.FirstItem.Select);
            if (ddlSchemeName.Items.Count > 1)
            {
                ddlscheme.Visible = true;
                txtscheme.Visible = false;
            }
            else
            {
                ddlscheme.Visible = false;
                txtscheme.Visible = true;
            }
        }
        else
            commonFunctions.Clear(ddlBranch, CommonFunctions.ClearType.Value, ddlSchemeName);
    }

    protected void ddlBranchCopy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranchCopy.SelectedIndex > 0)
        {
            objBal.KeyID = ddlBatchCopy.SelectedValue;
            objBal.ValueType = ddlBranchCopy.SelectedValue;
            fillFunctions.Fill(ddlBranchCopy, ddlSchemeNameCopy, objBll.EvaluationSchemeHeading(objBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlBranchCopy, CommonFunctions.ClearType.Value, ddlSchemeNameCopy);
    }


    protected void ddlSubjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubjectType.SelectedIndex > 0)
        {
            objBal.TypeId = ddlSubjectType.SelectedValue;
            fillFunctions.Fill(ddlSubjectType, ddlMarksTemplate, objBll.GetMarksTemplate(objBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlSubjectType, CommonFunctions.ClearType.Value, ddlMarksTemplate);
    }
    protected void ddlMarksTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMarksTemplate.SelectedIndex > 0)
        {
            objBal.Id = ddlMarksTemplate.SelectedValue;
            fillFunctions.Fill(repMarksTemplateDetails, objBll.GetMarksTemplateDetails(objBal));
        }
        else
            commonFunctions.Clear(repMarksTemplateDetails);
    }

    protected void ddlBatch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.Items.Count > 0)
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBranch);
        if (ddlSchemeName.Items.Count > 0)
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlSchemeName);
    }
    protected void ddlBatchCopy_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBranchCopy);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlSchemeNameCopy);
    }
    protected void ddlSemesterCopy_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBranchCopy);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlSchemeNameCopy);
    }
    protected void ddlSchemeNameCopy_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSchemeNameCopy.SelectedIndex > 0)
        {
            objBal.CommonId = ddlSemesterCopy.SelectedValue;
            objBal.FullName = ddlSchemeNameCopy.SelectedValue;
            fillFunctions.Fill(gridExistingPapers, objBll.GetExistingPapers(objBal));
            if (gridExistingPapers.Rows.Count > 0)
                btnCopy.Enabled = true;
        }
        else
            commonFunctions.Clear(gridExistingPapers);

    }

    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Save();
    }

    void Clear()
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSchemeName, ddlMarksTemplate,
            ddlCourseCopy, ddlBranchCopy, ddlSchemeNameCopy);
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlInstitution, ddlBatch, ddlSemester, ddlSubjectType, ddlSubject,
            ddlInstitutionCopy, ddlBatchCopy, ddlSemesterCopy);
        commonFunctions.Clear(txtPaperCode);
        commonFunctions.Clear(txtXML);
        commonFunctions.Clear(repMarksTemplateDetails);
        commonFunctions.Clear(gridXMLAdd);
        commonFunctions.Clear(gridExistingPapers);
        btnCopy.Enabled = false;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        Clear();
    }

    void Save()
    {
        try
        {
            if (txtXML.Text != "")
            {
                objBal.XmlValue = txtXML.Text;
                string Msg = objBll.SaveNewEvaluationScheme(objBal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
                Clear();
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Enter the required fields.')", true);

        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        }
    }
    void Add()
    {
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/syllabus/" + ddlSchemeName.SelectedValue + "/"));
        if (folders.Exists == false)
            folders.Create();

        if (FileUpload1.PostedFile.FileName != null)
        {

            if (Path.GetExtension(FileUpload1.PostedFile.FileName).ToString()== ".pdf")
            {
                objBal.Remark = "../UploadedFile/syllabus/" + ddlSchemeName.SelectedValue + "/" + txtPaperCode.Text + ".pdf";
                FileUpload1.PostedFile.SaveAs(Server.MapPath(objBal.Remark));
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Upload only pdf file.')", true);
                return;
            }

            XmlDocument xmlData = new XmlDocument();
            XmlElement ROOT;
            if (txtXML.Text != "")
            {
                xmlData.LoadXml(txtXML.Text);
                ROOT = xmlData.DocumentElement;
            }
            else
            {
                ROOT = xmlData.CreateElement("EVAL");
                xmlData.AppendChild(ROOT);
            }
            bool add = true;

            if (add)
            {
                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("EVA_SCH_ID");
                element.InnerText = ddlSchemeName.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ACA_SEM_ID");
                element.InnerText = ddlSemester.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ACA_SEM_NAME");
                element.InnerText = ddlSemester.SelectedItem.Text;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("EXAM_TEMP_MAIN_ID");
                element.InnerText = ddlMarksTemplate.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ACA_SUB_ID");
                element.InnerText = ddlSubject.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("SUB_TYPE_NAME");
                element.InnerText = ddlSubject.SelectedItem.Text;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("EVA_SCH_PAPER_CODE");
                element.InnerText = txtPaperCode.Text;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("SUB_TYPE_ID");
                element.InnerText = ddlSubjectType.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("CREDIT_POINT");
                element.InnerText = ddlPoint.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ELE_ID");
                element.InnerText = ddlPaperType.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ELE_VALUE");
                element.InnerText = ddlPaperType.SelectedItem.Text;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("EVA_SCH_SUB_IN_BY");
                element.InnerText = Session["UserId"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("FILE_PATH");
                element.InnerText = objBal.Remark;
                dataElement.AppendChild(element);
                txtXML.Text = xmlData.OuterXml;
                AddXmlData();


            }

        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please select file again to upload.')", true);
    }

    void AddXmlData()
    {
        if (txtXML.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtXML.Text));
            gridXMLAdd.DataSource = dataSet.Tables[0];
            gridXMLAdd.DataBind();
            DivButton.Visible = true;
        }
        else
        {
            gridXMLAdd.DataSource = null;
            gridXMLAdd.DataBind();
            DivButton.Visible = false;
        }
    }

    protected void gridXMLAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("EVAL/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        string path = Server.MapPath(gridXMLAdd.DataKeys[e.RowIndex].Value.ToString());
        FileInfo file = new FileInfo(path);
        if (file.Exists)
        {
            file.Delete();
        }
        if (xmlData.FirstChild.HasChildNodes)
            txtXML.Text = xmlData.OuterXml;
        else
            txtXML.Text = "";
        AddXmlData();
       
    }

    void AddCopy()
    {
        if (ddlSchemeName.SelectedIndex <= 0)
        {
            objBal.KeyID = ddlBatch.SelectedValue;
            objBal.ValueType = ddlBranch.SelectedValue;
            objBal.Name = txtSchemeName.Text;
            objBal.SessionUserID = Session["UserId"].ToString();
            fillFunctions.Fill(ddlSchemeName, objBll.GetEvaluationSchemeHeading(objBal), true, FillFunctions.FirstItem.Select);
            ddlSchemeName.SelectedIndex = 1;
            txtSchemeName.Text = "";
        }


        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT = xmlData.CreateElement("EVAL");
        xmlData.AppendChild(ROOT);
        CheckBox chkAdd = null;
        foreach (GridViewRow row in gridExistingPapers.Rows)
        {
            chkAdd = (CheckBox)row.FindControl("chkAdd");

            if (chkAdd.Checked)
            {
                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("EVA_SCH_ID");
                element.InnerText = ddlSchemeName.SelectedValue;
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ACA_SEM_ID");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["ACA_SEM_ID"].ToString();
                dataElement.AppendChild(element);


                element = xmlData.CreateElement("EXAM_TEMP_MAIN_ID");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["EXAM_TEMP_MAIN_ID"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ACA_SUB_ID");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["ACA_SUB_ID"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("EVA_SCH_PAPER_CODE");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["EVA_SCH_PAPER_CODE"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("SUB_TYPE_ID");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["SUB_TYPE_ID"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("CREDIT_POINT");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["CREDIT_POINT"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("ELE_ID");
                element.InnerText = gridExistingPapers.DataKeys[row.RowIndex].Values["ELE_ID"].ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("EVA_SCH_SUB_IN_BY");
                element.InnerText = Session["UserId"].ToString();
                dataElement.AppendChild(element);

            }
            txtXML.Text = xmlData.OuterXml;

        }
        Save();
    }
    protected void btnCopy_Click(object sender, EventArgs e)
    {
        AddCopy();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (ddlSchemeName.SelectedIndex <= 0)
        {
            objBal.KeyID = ddlBatch.SelectedValue;
            objBal.ValueType = ddlBranch.SelectedValue;
            objBal.Name = txtSchemeName.Text;
            objBal.SessionUserID = Session["UserId"].ToString();
            try
            {
                fillFunctions.Fill(ddlSchemeName, objBll.GetEvaluationSchemeHeading(objBal), true, FillFunctions.FirstItem.Select);
                ddlSchemeName.SelectedIndex = 1;
                ddlscheme.Visible = true;
                txtscheme.Visible = false;
                Add();
                commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlSemester, ddlSubjectType, ddlSubject, ddlPoint);
                commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlMarksTemplate);
                commonFunctions.Clear(txtPaperCode);
                commonFunctions.Clear(txtSchemeName);
            }
            catch
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Can not insert dublicate evaluation scheme for same same batch and branch.')", true);
            }
            txtSchemeName.Text = "";
        }
        else
        {
            Add();
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlSemester, ddlSubjectType, ddlSubject, ddlPoint);
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlMarksTemplate);
            commonFunctions.Clear(txtPaperCode);
            commonFunctions.Clear(txtSchemeName);
        }

    }


    protected void chkCopy_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCopy.Checked)
        {
            tblCopy.Visible = true;
            tblAdd.Visible = false;
            DivButton.Visible = false;
        }
        else
        {
            tblCopy.Visible = false;
            tblAdd.Visible = true;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;

public partial class Academic_ClassName : System.Web.UI.Page
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
        //btnSaveClassName.Attributes.Add("OnClick", "return validationClassSave()");
        btnAdd.Attributes.Add("OnClick", "return validationAddBranch()");
        btnCordSave.Attributes.Add("OnClick", "return validationCordSave()");
        if (!IsPostBack)
        {
            FillData();
            newClassWizard.ActiveStepIndex = 0;
            ViewState["CLS_SEM_ID"] = "";
        }
    }

    #region FillFunction
    void FillData()
    {
        fillFunctions.Fill(ddlInst, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
    }

    void FillClassGrid()
    {
        if (ddlInst.SelectedIndex > 0)
        {
            AcaBal.InsId = ddlInst.SelectedValue;
            fillFunctions.Fill(gridClassName, AcaBll.GetClasses(AcaBal));
        }
        else
            commonFunctions.Clear(gridClassName);
    }
    #endregion

    #region DropDown Selected Index Change
    protected void ddlInst_SelectedIndexChanged(object sender, EventArgs e)
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlSemesterBound);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSemester, ddlChooseClass, ddlSection);
        FillClassGrid();
        update2.Update();
    }
    protected void ddlSemesterBound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemesterBound.SelectedIndex > 0)
        {
            AcaBal.InsId = ddlInst.SelectedValue;
            //AcaBal.Id = ddlSemesterBound.SelectedValue;
            fillFunctions.Fill(ddlChooseClass, AcaBll.GetClasses(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlChooseClass);
    }
    protected void ddlChooseClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        ClearSelect();
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
            fillFunctions.Fill(ddlCourse, ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_Batch), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlCourse, ddlSection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch, ddlSemester, ddlSection);
        LoadDataStep2();
    }
    #endregion

    #region Button Click
    //protected void btnSaveClassName_Click(object sender, EventArgs e)
    //{
    //    AcaBal.InsId = ddlInst.SelectedValue;
    //    AcaBal.Name = txtClassName.Text;
    //    AcaBal.SessionUserID = Session["UserId"].ToString();

    //    Msg = AcaBll.SaveNewClass(AcaBal);
    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    //    ddlInst.SelectedIndex = 0;
    //    txtClassName.Text = "";
    //    commonFunctions.Clear(gridClassName);
    //}
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtStep2.Text != "")
        {
            xmlData.LoadXml(txtStep2.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("BRN");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("BRN/DATA/BRANCH_ID");
        XmlNodeList nodeList1 = xmlData.SelectNodes("BRN/DATA/SEMESTER_NO");

        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i].InnerText == ddlBranch.SelectedValue && nodeList1[i].InnerText == ddlSemester.SelectedItem.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Record for the specified value already exists')", true); add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("COURSE_SHORT_NAME");
            element.InnerText = ddlCourse.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("BATCH_ID");
            element.InnerText = ddlSemester.SelectedValue;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("BRANCH_ID");
            element.InnerText = ddlBranch.SelectedValue;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("BRANCH_SHORT_NAME");
            element.InnerText = ddlBranch.SelectedItem.Text;
            dataElement.AppendChild(element);


            element = xmlData.CreateElement("SEMESTER_NO");
            element.InnerText = ddlSemester.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("SECTION");
            element.InnerText = ddlSection.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("SECTION_ID");
            element.InnerText = ddlSection.SelectedValue;
            dataElement.AppendChild(element);

            txtStep2.Text = xmlData.OuterXml;
        }
        LoadDataStep2();
    }
    protected void btnGeneratePaperCombination_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtStep3.Text != "")
        {
            xmlData.LoadXml(txtStep3.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("PAP");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("PAP/DATA/EVA_SCH_SUB_ID");
        DropDownList ddlPaperCode;
        Label lblSection;
        foreach (XmlNode node in nodeList)
        {
            if (add)
            {
                for (int i = 0; i < repPaperCode.Items.Count; i++)
                {
                    ddlPaperCode = (DropDownList)repPaperCode.Items[i].FindControl("ddlPaperCode");
                    if (node.InnerText == ddlPaperCode.SelectedValue)
                    {
                        add = false;
                        break;
                    }
                }
            }
            else
                break;

        }
        if (add)
        {
            XmlElement dataElement;
            XmlElement element;
            int index;

            if (txtStep3.Text != "")
                index = Convert.ToInt32(xmlData.FirstChild.LastChild.FirstChild.InnerText) + 1;
            else
                index = 1;


            for (int i = 0; i < repPaperCode.Items.Count; i++)
            {
                ddlPaperCode = (DropDownList)repPaperCode.Items[i].FindControl("ddlPaperCode");

                if (ddlPaperCode.SelectedIndex > 0)
                {

                    dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    element = xmlData.CreateElement("STEP_ID");
                    element.InnerText = index.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("EVA_SCH_SUB_ID");

                    element.InnerText = ddlPaperCode.SelectedValue;
                    dataElement.AppendChild(element);


                    element = xmlData.CreateElement("PAPER_CODE");
                    element.InnerText = ddlPaperCode.SelectedItem.Text;
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("SEC_ID");
                    lblSection = (Label)repPaperCode.Items[i].FindControl("lblSection_id");
                    element.InnerText = lblSection.Text;
                    dataElement.AppendChild(element);
                }
            }

            txtStep3.Text = xmlData.OuterXml;
        }
        LoadDataStep3();
    }
    protected void btnSavePaperCombination_Click(object sender, EventArgs e)
    {
        AcaBal.XmlValue = txtStep3.Text;
        AcaBal.KeyID = ViewState["CLS_SEM_ID"].ToString();
        AcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = AcaBll.SavePaperData(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        ClearAll();
    }

    protected void btnCordSave_Click(object sender, EventArgs e)
    {
        AcaBal.EmpId = commonFunctions.GetKeyID(txtCordinator);
        AcaBal.SessionUserID = Session["UserId"].ToString();
        AcaBal.KeyID = ViewState["CLS_SEM_ID"].ToString();
        Msg = AcaBll.SaveClassCordinator(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        trCordBtn.Visible = false;
        lblCord.Text = txtCordinator.Text;
        lblCord.Visible = true;
    }
    #endregion

    //protected void newClassWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    //{

    //}
    #region Grid RowDeleting
    protected void gridClassName_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AcaBal.KeyID = gridClassName.DataKeys[e.RowIndex].Value.ToString();
        AcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = AcaBll.DeleteClass(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        FillClassGrid();
    }

    protected void gridBranch_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtStep2.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("BRN/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtStep2.Text = xmlData.OuterXml;
        else
            txtStep2.Text = "";
        LoadDataStep2();
    }
    protected void gridPaperCombination_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = gridPaperCombination.DataKeys[e.RowIndex].Value.ToString();

        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtStep3.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PAP/DATA/STEP_ID");

        foreach (XmlNode node in nodeList)
        {
            if (node.InnerText == id)
                xmlData.FirstChild.RemoveChild(node.ParentNode);
        }

        if (xmlData.FirstChild.HasChildNodes)
            txtStep3.Text = xmlData.OuterXml;
        else
            txtStep3.Text = "";
        LoadDataStep3();
    }
    #endregion
    
    #region Change wizard step
    protected void ActivateStep1(object sender, EventArgs e)
    {
        if (ddlInst.SelectedIndex <= 0)
            newClassWizard.ActiveStepIndex = 0;
    }
    protected void ActivateBranch(object sender, System.EventArgs e)
    {
         if (ddlSemesterBound.SelectedIndex>0 && ddlChooseClass.SelectedIndex > 0)
        {
            AcaBal.Id = ddlSemesterBound.SelectedValue;
            AcaBal.CommonId = ddlChooseClass.SelectedValue;
            ds = AcaBll.SaveClassSemester(AcaBal);
            ViewState["CLS_SEM_ID"] = ds.Tables[0].Rows[0][0];
            if (ds.Tables[1].Rows.Count>0)
            {
                lblCord.Visible = true;
                trCordBtn.Visible = false;
                lblCord.Text = ds.Tables[1].Rows[0][0].ToString();
                
            }
            else
            {
                lblCord.Visible = false;
                trCordBtn.Visible = true;
            }

            if (txtStep2Ex.Text == "")
            {
                AcaBal.KeyID = ViewState["CLS_SEM_ID"].ToString();
                DataSet dataSetClass = AcaBll.GetClassData(AcaBal);
                fillFunctions.Fill(gridExistingBranch, dataSetClass.Tables[0]);
                StringWriter writer = new StringWriter();
                dataSetClass.Tables[0].WriteXml(writer);
                txtStep2Ex.Text = writer.GetStringBuilder().ToString();
                writer.Close();
                writer.Dispose();
                if (txtStep2Ex.Text == "<NewDataSet />")
                    txtStep2Ex.Text = "";


                if (txtStep2Ex.Text == "")
                {
                    if (txtStep2.Text != "")
                    {
                        DataSet dataSet = new DataSet();
                        dataSet.ReadXml(new StringReader(txtStep2.Text));
                        gridBranch.DataSource = dataSet.Tables[0];
                        gridBranch.DataBind();
                        update6.Update();
                    }
                }
                else
                {
                    btnAdd.Enabled = false;
                }
            }
            else
            {
                DataSet dataSet = new DataSet();
                ddlInstitution.SelectedIndex = 0;
                gridExistingBranch.DataSource = "";
                gridExistingBranch.DataBind();
                dataSet.ReadXml(new StringReader(txtStep2Ex.Text));
                fillFunctions.Fill(gridExistingBranch, dataSet.Tables[0]);              
                update4.Update();
            }
        }
        else
            newClassWizard.ActiveStepIndex = 1;
    }
    protected void ActivatePaper(object sender, System.EventArgs e)
    {

        if (txtStep2Ex.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtStep2Ex.Text));
            repPaperCode.DataSource = dataSet.Tables[0];
            repPaperCode.DataBind();

            AcaBal.XmlValue = txtStep2Ex.Text;
            DataSet dataSetPaperCode = AcaBll.GetPaperCodeAlt(AcaBal);
            int limit = dataSetPaperCode.Tables.Count;
            DropDownList ddlPaperCode;
            for (int i = 0; i < limit; i++)
            {
                ddlPaperCode = (DropDownList)repPaperCode.Items[i].FindControl("ddlPaperCode");
                fillFunctions.Fill(ddlPaperCode, dataSetPaperCode.Tables[i], true, FillFunctions.FirstItem.Select);
            }
            dataSet.Dispose();
            dataSetPaperCode.Dispose();
            txtStep3.Text = "";
            LoadDataStep3();
        }
        else if (txtStep2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtStep2.Text));
            repPaperCode.DataSource = dataSet.Tables[0];
            repPaperCode.DataBind();

            AcaBal.XmlValue = txtStep2.Text;
            DataSet dataSetPaperCode = AcaBll.GetPaperCode(AcaBal);
            int limit = dataSetPaperCode.Tables.Count;
            DropDownList ddlPaperCode;
            for (int i = 0; i < limit; i++)
            {
                ddlPaperCode = (DropDownList)repPaperCode.Items[i].FindControl("ddlPaperCode");
                fillFunctions.Fill(ddlPaperCode, dataSetPaperCode.Tables[i], true, FillFunctions.FirstItem.Select);
            }
            dataSet.Dispose();
            dataSetPaperCode.Dispose();
            txtStep3.Text = "";
            LoadDataStep3();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Complete this step to continue')", true);
            newClassWizard.ActiveStepIndex = 2;
        }
    }
    #endregion

    void ClearSelect()
    {
        txtStep2.Text = "";
        txtStep3.Text = "";
        txtStep2Ex.Text = "";

        LoadDataStep2();
        LoadDataStep3();

        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlInstitution);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSemester, ddlSection);

        UpdatePanel11.Update();
    }
    void ClearAll()
    {
        txtStep2.Text = "";
        txtStep3.Text = "";
        txtStep2Ex.Text = "";

        LoadDataStep2();
        LoadDataStep3();

        newClassWizard.ActiveStepIndex = 0;
        ddlInst.SelectedIndex = 0;

        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlInst, ddlSemesterBound);
        commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch, ddlSemester, ddlChooseClass, ddlSection);

        UpdatePanel11.Update();
    }

    void LoadDataStep2()
    {
        if (txtStep2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtStep2.Text));
            gridBranch.DataSource = dataSet.Tables[0];
            gridBranch.DataBind();
        }
        else
        {
            gridBranch.DataSource = null;
            gridBranch.DataBind();
        }
        update6 .Update();
    }

    public void LoadDataStep3()
    {

        if (txtStep3.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtStep3.Text));
            gridPaperCombination.DataSource = dataSet.Tables[0];
            gridPaperCombination.DataBind();
            commonFunctions.MergeRows(gridPaperCombination, 0, 1, 2, 3);
        }
        else
        {
            gridPaperCombination.DataSource = null;
            gridPaperCombination.DataBind();
        }
    }

}
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
using System.Data.SqlClient;
using System.Xml;
using System.IO;
public partial class HR_EmpMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages Msgfun;
    HRBAL HrBal;
    HRBLL HrBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        newEmpWizard.Attributes.Add("OnFinishButtonClick", "return ValidateWizard()");
        Initialize();
        if (!IsPostBack)
        {
            newEmpWizard.ActiveStepIndex = 0;
            PushData();
            Hd1.Value = "0";
            tbPic.Visible = false;
        }
    }

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        Msgfun = new Messages();
        HrBal = new HRBAL();
        HrBll = new HRBLL();
    }
    private void PushData()
    {

        fillFunctions.Fill(ddlInitial, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Initial), true, FillFunctions.FirstItem.Select);
        fillFunctions.FillDouble(ddlCaste, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.Select, FillFunctions.FillDoubleType.Item);
        fillFunctions.Fill(ddlCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Category), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlReligion, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlMotherTongue, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MotherTongue), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBloodGroup, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BloodGroup), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlNextKinType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.NextKinType), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlServiceType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ServiceType), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlDesignation, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBank, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Bank), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlShift, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ShiftWithTime), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlNationality, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Nationality), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlJobType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobTypeWithoutAll), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CITY), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSalaryTemplate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TempType), true, FillFunctions.FirstItem.Select);

    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlInstitution, ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlDepartment.Focus();
        }
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
            fillFunctions.Fill(ddlState, ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlState, CommonFunctions.ClearType.Value, ddlCity);
    }
    protected void ddlSalaryTemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSalaryTemplate.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlSalaryTemplate, ddlHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SalaryHead, ddlSalaryTemplate.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlHead.Focus();
        }
    }
    protected void newEmpWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        if (UploadImage(Hd1.Value))
        {
            string Msg = HrBll.SaveNewUser(Hd1.Value, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddlGender.SelectedValue, txtDOB.Text, txtDOJ.Text, txtConfirm.Text, ddlCaste.SelectedValue,
             ddlReligion.SelectedValue, ddlNationality.SelectedValue, ddlMotherTongue.SelectedValue, ddlBloodGroup.SelectedValue, txtFatherName.Text, txtMotherName.Text, ddlNextKinType.SelectedValue,
             txtNextKinName.Text, ddlIsHandicapped.SelectedValue, txtPanNumber.Text, txtAdhar.Text, ddlMaritalStatus.SelectedValue, ddlInitial.SelectedValue, ddlJobType.SelectedValue, ddlServiceType.SelectedValue,
             ddlCategory.SelectedValue, ddlDesignation.SelectedValue, ddlDepartment.SelectedValue, commonFunctions.GetKeyID(txtNextSenior), ddlShift.SelectedValue, ctrlAddress.GetXML, ctrlPhone.GetXML, ctrlMail.GetXML, ctrlAcademic.GetXML,
             ctrlExperience.GetXML, ddlBank.SelectedValue, txtBranch.Text, txtAddress.Text, ddlCity.SelectedValue, txtAccountNo.Text, txtSpouse.Text, ddlEmployment.SelectedValue, ddlContract.SelectedValue, ddlProb.SelectedValue, txtSalaryXml.Text);
            //commonFunctions.Clear(this);
            txtEmployee.Text = "";
            clear();
            newEmpWizard.ActiveStepIndex = 0;
            Hd1.Value = "0";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        clear();
        newEmpWizard.ActiveStepIndex = 0;
        ShowData();
    }
    public void ShowData()
    {

        SqlCommand command = new SqlCommand("GET_EMP_INF_SINGLE_EMP_CURRENT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EMP_ID", commonFunctions.GetKeyID(txtEmployee));
        command.Parameters.AddWithValue("@VIEW_TYPE", 3);
        DataSet ds = databaseFunctions.GetDataSet(command);
        if (ds.Tables[0].Rows.Count > 0)
        {
            tbPic.Visible = true;
            Hd1.Value = commonFunctions.GetKeyID(txtEmployee);
            string empImage = "../images/emp_images/" + commonFunctions.GetKeyID(txtEmployee) + "_thumb.jpg";
            if (System.IO.File.Exists(Server.MapPath(empImage)))
                imgEmp.Src = empImage;
            else
                imgEmp.Src = "../images/emp_images/empImage.jpg";
            lblName.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
            lblStatus.Text = ds.Tables[0].Rows[0]["STS_VALUE"].ToString();
            ddlGender.SelectedValue = ds.Tables[0].Rows[0]["GEN_ID"].ToString();
            ddlInitial.SelectedValue = ds.Tables[0].Rows[0]["INI_ID"].ToString();
            ddlCaste.SelectedValue = ds.Tables[0].Rows[0]["CAS_ID"].ToString();
            ddlReligion.SelectedValue = ds.Tables[0].Rows[0]["REL_ID"].ToString();
            ddlNationality.SelectedValue = ds.Tables[0].Rows[0]["NAT_ID"].ToString();
            if (ds.Tables[0].Rows[0]["MOT_TON_ID"].ToString() != "0")
                ddlMotherTongue.SelectedValue = ds.Tables[0].Rows[0]["MOT_TON_ID"].ToString();
            ddlBloodGroup.SelectedValue = ds.Tables[0].Rows[0]["BLO_GRP_ID"].ToString();
            if (ds.Tables[0].Rows[0]["NEXT_KIN_ID"].ToString() != "0")
                ddlNextKinType.SelectedValue = ds.Tables[0].Rows[0]["NEXT_KIN_ID"].ToString();
            ddlMaritalStatus.SelectedValue = ds.Tables[0].Rows[0]["MAR_STS_ID"].ToString();
            txtPanNumber.Text = ds.Tables[0].Rows[0]["PAN_NO"].ToString();
            txtAdhar.Text = ds.Tables[0].Rows[0]["ADHAR_NO"].ToString();
            txtFirstName.Text = ds.Tables[0].Rows[0]["F_NAME"].ToString();
            txtMiddleName.Text = ds.Tables[0].Rows[0]["M_NAME"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["L_NAME"].ToString();
            txtDOB.Text = ds.Tables[0].Rows[0]["DOB"].ToString();
            txtFatherName.Text = ds.Tables[0].Rows[0]["EMP_FTH_NAME"].ToString();
            txtMotherName.Text = ds.Tables[0].Rows[0]["EMP_MTH_NAME"].ToString();
            txtNextKinName.Text = ds.Tables[0].Rows[0]["NEXT_KIN_NAME"].ToString();
            txtSpouse.Text = ds.Tables[0].Rows[0]["SPOUSE_NAME"].ToString();
            txtDOJ.Text = ds.Tables[0].Rows[0]["DOJ"].ToString();
            txtConfirm.Text = ds.Tables[0].Rows[0]["DOC"].ToString();
            ddlIsHandicapped.SelectedValue = ds.Tables[0].Rows[0]["IS_HAND_ID"].ToString();
            ddlProb.SelectedValue = ds.Tables[0].Rows[0]["PROB_PRD"].ToString();
            ddlContract.SelectedValue = ds.Tables[0].Rows[0]["CONTRACT_PRD"].ToString();
        }

        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlJobType.SelectedValue = ds.Tables[1].Rows[0][1].ToString();
            ddlServiceType.SelectedValue = ds.Tables[1].Rows[0][2].ToString();
            ddlEmployment.SelectedValue = ds.Tables[1].Rows[0][9].ToString();
            if (ds.Tables[1].Rows[0][3].ToString() != "0")
            {
                ddlCategory.SelectedValue = ds.Tables[1].Rows[0][3].ToString();
            }
            ddlDesignation.SelectedValue = ds.Tables[1].Rows[0][4].ToString();
            ddlInstitution.SelectedValue = ds.Tables[1].Rows[0][5].ToString();
            ddlDepartment.SelectedValue = ds.Tables[1].Rows[0][6].ToString();
            ddlShift.SelectedValue = ds.Tables[1].Rows[0][8].ToString();
            txtNextSenior.Text = ds.Tables[1].Rows[0][7].ToString();
        }

        ctrlAddress.ShowAddData(ds.Tables[2]);
        ctrlPhone.ShowPhoneData(ds.Tables[3]);
        ctrlMail.ShowMailData(ds.Tables[4]);
        ctrlAcademic.ShowAcademic(ds.Tables[5]);
        ctrlExperience.ShowExperience(ds.Tables[6]);
        if (ds.Tables[7].Rows.Count > 0)
        {
            txtBranch.Text = ds.Tables[7].Rows[0][4].ToString();
            txtAddress.Text = ds.Tables[7].Rows[0][5].ToString();
            txtAccountNo.Text = ds.Tables[7].Rows[0][6].ToString();
            ddlBank.SelectedValue = ds.Tables[7].Rows[0][1].ToString();
            ddlState.SelectedValue = ds.Tables[7].Rows[0][2].ToString();
            ddlCity.SelectedValue = ds.Tables[7].Rows[0][3].ToString();
        }
        if (ds.Tables[8].Rows.Count > 0)
        {
            ddlSalaryTemplate.SelectedValue = ds.Tables[8].Rows[0][0].ToString();
            fillFunctions.Fill(ddlSalaryTemplate, ddlHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SalaryHead, ddlSalaryTemplate.SelectedValue), true, FillFunctions.FirstItem.Select);
            StringWriter writer = new StringWriter();
            ds.Tables[8].WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<SALARY>");
            xmlString = xmlString.Replace("</NewDataSet>", "</SALARY>");
            xmlString = xmlString.Replace("<Table8>", "<DATA>");
            xmlString = xmlString.Replace("</Table8>", "</DATA>");
            txtSalaryXml.Text = xmlString;
            AddXmlData();
        }

    }
    private bool UploadImage(string empid)
    {
        try
        {
            if (empid == "0")
                return true;
            string ext = Path.GetExtension(ImgUpload.PostedFile.FileName);
            if (Path.GetExtension(ImgUpload.PostedFile.FileName) != ".jpg")
                return false;
            else
            {
                ImgUpload.PostedFile.SaveAs(Server.MapPath("../images/empimages/" + empid + ".jpg"));
                return true;
            }
        }
        catch
        {
            return true;
        }

    }
    void clear()
    {
        tbPic.Visible = false;
        txtAccountNo.Text = txtAddress.Text = txtBranch.Text = txtConfirm.Text = txtDOB.Text = txtDOJ.Text = txtFatherName.Text = txtFirstName.Text = txtLastName.Text = "";
        txtMiddleName.Text = txtMotherName.Text = txtNextKinName.Text = txtNextSenior.Text = txtPanNumber.Text = txtSpouse.Text = "";
        ddlBank.SelectedIndex = ddlBloodGroup.SelectedIndex = ddlCaste.SelectedIndex = ddlCategory.SelectedIndex = ddlCity.SelectedIndex = ddlDepartment.SelectedIndex = 0;
        ddlDesignation.SelectedIndex = ddlEmployment.SelectedIndex = ddlGender.SelectedIndex = ddlInitial.SelectedIndex = ddlInstitution.SelectedIndex = ddlIsHandicapped.SelectedIndex = 0;
        ddlJobType.SelectedIndex = ddlMaritalStatus.SelectedIndex = ddlMotherTongue.SelectedIndex = ddlNationality.SelectedIndex = ddlNextKinType.SelectedIndex = ddlReligion.SelectedIndex = 0;
        ddlServiceType.SelectedIndex = ddlShift.SelectedIndex = ddlState.SelectedIndex = 0;
    }

    void Add()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtSalaryXml.Text != "")
        {
            xmlData.LoadXml(txtSalaryXml.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("SALARY");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;

        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("SAL_TEMPLATE_ID");
            element.InnerText = ddlSalaryTemplate.SelectedValue;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("SAL_TEMPLATE_NAME");
            element.InnerText = ddlSalaryTemplate.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("HEAD_ID");
            element.InnerText = ddlHead.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("HEAD_NAME");
            element.InnerText = ddlHead.SelectedItem.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("SAL_HEAD_VALUE");
            element.InnerText = txtValue.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("EFFECTIVE_DT");
            element.InnerText = txtEffectiveDate.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("ENTRY_BY");
            element.InnerText = Session["UserId"].ToString();
            dataElement.AppendChild(element);
            txtSalaryXml.Text = xmlData.OuterXml;

            AddXmlData();
        }
    }

    void AddXmlData()
    {
        if (txtSalaryXml.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtSalaryXml.Text));
            SalaryGrid.DataSource = dataSet.Tables[0];
            SalaryGrid.DataBind();

        }
        else
        {
            SalaryGrid.DataSource = null;
            SalaryGrid.DataBind();

        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Add();
    }
    protected void SalaryGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtSalaryXml.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("SALARY/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtSalaryXml.Text = xmlData.OuterXml;
        else
            txtSalaryXml.Text = "";
        AddXmlData();
    }
}


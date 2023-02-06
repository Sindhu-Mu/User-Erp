using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;

public partial class Academic_StudentMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            NewStudentWizard.ActiveStepIndex = 0;
            PushData();
            trNew.Visible = false;
            trOld.Visible = true;
            tbPic.Visible = false;
        }

    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        commonFunctions = new CommonFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        Msg = new Messages();
    }
    private void PushData()
    {
        fillFunctions.Fill(ddlInitial, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Initial), true, FillFunctions.FirstItem.Select);
        fillFunctions.FillDouble(ddlCaste, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.Select, FillFunctions.FillDoubleType.Item);
        fillFunctions.Fill(ddlReligion, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBloodGroup, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BloodGroup), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlNationality, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Nationality), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlQuota, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Quota), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlAdmCategory, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdmCategory), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlGender, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Gender), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlAdmType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AdmType), true, FillFunctions.FirstItem.Select);
    }

    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }

    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
            if (Rlist.SelectedIndex == 1)
            {
                GetDocument();
            }
        }
    }
    protected void NewStudentWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
            string Enrollment = (Rlist.SelectedIndex == 0) ? commonFunctions.GetKeyID(txtStudent) : txtEnrollment.Text;
        if (UploadImage(Enrollment))
        {
            DocumentXml();
             string msg= ObjAcaBll.SaveNewStudent(Enrollment, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, ddlGender.SelectedValue, txtDOB.Text, ddlCaste.SelectedValue, ddlReligion.SelectedValue,
                                      ddlNationality.SelectedValue, ddlBloodGroup.SelectedValue, txtFatherName.Text, txtMotherName.Text, txtFatherOcc.Text, Rlist.SelectedValue,
                                      ddlInitial.SelectedValue, address.GetXML, phoneNumber.GetXML, email.GetXML, academicType.GetXML, txtForm.Text, ddlBatch.SelectedValue, txtAdmDt.Text,
                                      txtTestRank.Text, ddlAdmType.SelectedValue, ddlQuota.SelectedValue, ddlAdmCategory.SelectedValue, ddlPgm.SelectedValue, ddlBranch.SelectedValue, ddlSem.SelectedValue, ddlSection.SelectedValue, txtData.Text, txtRemark.Text, Session["UserId"].ToString());
             if (msg.Contains("successfully"))
             {
                 tbPic.Visible = false;
                 msg = (Rlist.SelectedIndex == 0) ? Msg.GetMessage(Messages.DataMessType.Update) : Msg.GetMessage(Messages.DataMessType.Insert);
                 NewStudentWizard.ActiveStepIndex = 0;
                 clear();
                 Rlist.SelectedIndex = 0;
             }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Upload only .jpg file.')", true);
            ImgUpload.Focus();
        }
    }
    private bool UploadImage(string Enrollment)
    {
        // string ext = ;
        try
        {
            if (Path.GetExtension(ImgUpload.PostedFile.FileName) != ".jpg")
                return false;
            ImgUpload.PostedFile.SaveAs(Server.MapPath("../images/Stuimages/" + Enrollment + ".jpg"));
        }
        catch
        {
            return true;
        }
        return true;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        NewStudentWizard.ActiveStepIndex = 0;
        ShowData();
    }
    private void GetDocument()
    {
        SqlCommand command = new SqlCommand("GET_PROGRAM_DOC_INF");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@INS_PGM_ID", ddlPgm.SelectedValue);
        DataTable dt = databaseFunctions.GetDataSet(command).Tables[0];
        if (dt.Rows.Count > 0)
        {
            gvDoc.DataSource = dt;
            gvDoc.DataBind();
        }
    }
    private void ShowData()
    {
        SqlCommand command = new SqlCommand("GET_STUDENT_INF");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ENROLLMENT_NO", commonFunctions.GetKeyID(txtStudent));
        DataSet ds = databaseFunctions.GetDataSet(command);
        if (ds.Tables[0].Rows.Count > 0)
        {

            tbPic.Visible = true;
            Rlist.SelectedValue = "0";
            ddlBatch.SelectedValue = ds.Tables[0].Rows[0]["ACA_BATCH_ID"].ToString();
            txtForm.Text = ds.Tables[0].Rows[0]["FORM_NO"].ToString();
            //if (ddlBatch.SelectedValue == "9")
            //{
            //    imgStu.Src = "../images/Stuimages/2015/" + txtForm.Text + ".jpg";
            //}
            //else
            //{
            //    imgStu.Src = "../images/Stuimages/" + ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
            //}
            imgStu.Src = "../images/Stuimages/" + ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
            lblName.Text = ds.Tables[0].Rows[0]["STU_FULL_NAME"].ToString();
            lblStatus.Text = ds.Tables[0].Rows[0]["STU_STS_VALUE"].ToString();
            txtRemark.Text = ds.Tables[0].Rows[0]["REMARK"].ToString();
            ddlGender.SelectedValue = ds.Tables[0].Rows[0]["GEN_ID"].ToString();
            ddlInitial.SelectedValue = (ds.Tables[0].Rows[0]["INI_ID"] != DBNull.Value) ? ds.Tables[0].Rows[0]["INI_ID"].ToString() : ".";
            txtFirstName.Text = ds.Tables[0].Rows[0]["FIRST_NAME"].ToString();
            txtMiddleName.Text = ds.Tables[0].Rows[0]["MIDDLE_NAME"].ToString();
            txtLastName.Text = ds.Tables[0].Rows[0]["LAST_NAME"].ToString();
            txtDOB.Text = ds.Tables[0].Rows[0]["DT_OF_BIRTH"].ToString();
            ddlCaste.SelectedValue = (ds.Tables[0].Rows[0]["CAS_ID"] != DBNull.Value) ? ds.Tables[0].Rows[0]["CAS_ID"].ToString() : ".";
            ddlReligion.SelectedValue =(ds.Tables[0].Rows[0]["REL_ID"] != DBNull.Value) ? ds.Tables[0].Rows[0]["REL_ID"].ToString(): ".";
            ddlNationality.SelectedValue = (ds.Tables[0].Rows[0]["NAT_ID"] != DBNull.Value) ? ds.Tables[0].Rows[0]["NAT_ID"].ToString() : ".";
            ddlBloodGroup.SelectedValue = (ds.Tables[0].Rows[0]["BLO_GRP_ID"] != DBNull.Value) ? ds.Tables[0].Rows[0]["BLO_GRP_ID"].ToString() : ".";
            txtFatherName.Text = ds.Tables[0].Rows[0]["FATHER_NAME"].ToString();
            txtMotherName.Text = ds.Tables[0].Rows[0]["MOTHER_NAME"].ToString();
            txtFatherOcc.Text = ds.Tables[0].Rows[0]["FATHER_OCCUP"].ToString();
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            ddlBatch.SelectedValue = ds.Tables[1].Rows[0]["ACA_BATCH_ID"].ToString();
            ddlIns.SelectedValue = ds.Tables[1].Rows[0]["INS_ID"].ToString();
            ddlPgm.SelectedValue = ds.Tables[1].Rows[0]["INS_PGM_ID"].ToString();
            ddlBranch.SelectedValue = ds.Tables[1].Rows[0]["PGM_BRN_ID"].ToString();
            ddlSem.SelectedValue = ds.Tables[1].Rows[0]["ACA_SEM_ID"].ToString();
            ddlSection.SelectedValue = (ds.Tables[1].Rows[0]["ACA_SEC_ID"] != DBNull.Value) ? ds.Tables[1].Rows[0]["ACA_SEC_ID"].ToString() : ".";
            ddlQuota.SelectedValue = (ds.Tables[1].Rows[0]["QUOTA_ID"] != DBNull.Value) ? ds.Tables[1].Rows[0]["QUOTA_ID"].ToString() : ".";
            ddlAdmType.SelectedValue = ds.Tables[1].Rows[0]["ADM_TYPE_ID"].ToString();
            txtForm.Text = ds.Tables[1].Rows[0]["FORM_NO"].ToString();
            ddlAdmCategory.SelectedValue = (ds.Tables[1].Rows[0]["ENT_EXAM_ID"] != DBNull.Value) ? ds.Tables[1].Rows[0]["ENT_EXAM_ID"].ToString() : ".";
            txtTestRank.Text =(ds.Tables[1].Rows[0]["STU_TEST_RANK"] != DBNull.Value) ? ds.Tables[1].Rows[0]["STU_TEST_RANK"].ToString() : "";
            txtAdmDt.Text = ds.Tables[1].Rows[0]["STU_ENROLL_DT"].ToString();
        }

        address.ShowAddData(ds.Tables[2]);
        phoneNumber.ShowPhoneData(ds.Tables[3]);
        email.ShowMailData(ds.Tables[4]);
        if (ds.Tables[5].Rows.Count > 0)
            academicType.ShowAcademic(ds.Tables[5]);
        DocumentBind(ds.Tables[6]);

    }
    private void DocumentBind(DataTable dt)
    {
        gvDoc.DataSource = dt;
        gvDoc.DataBind();

    }
    private void DocumentXml()
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
            ROOT = xmlData.CreateElement("STU");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in gvDoc.Rows)
        {
            XmlElement dataElement = xmlData.CreateElement("DOC");
            ROOT.AppendChild(dataElement);
            XmlElement element = xmlData.CreateElement("PGM_DOC_MAP_ID");
            element.InnerText = gvDoc.DataKeys[row.RowIndex].Values[0].ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("DOC_IN_REMARK");
            element.InnerText = ((TextBox)row.FindControl("txtRemark")).Text;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("DOC_IN_STS");
            element.InnerText = Convert.ToInt32(((CheckBox)row.FindControl("ChkBox")).Checked).ToString();
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("STU_DOC_ID");
            element.InnerText = gvDoc.DataKeys[row.RowIndex].Values[1].ToString();
            dataElement.AppendChild(element);
            txtData.Text = xmlData.OuterXml;
        }

    }
    protected void Doc_Click(object sender, EventArgs e)
    {
        if ((ddlPgm.SelectedIndex < 1) || (ddlQuota.SelectedIndex < 1))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Select program and qouta to view document.')", true);
            NewStudentWizard.ActiveStepIndex = 1;
        }
        else
        {
            ObjAcaBal.KeyID = ddlPgm.SelectedValue;
            ObjAcaBal.KeyValue = ddlQuota.SelectedValue;
            DocumentBind(ObjAcaBll.GetStudentDocument(ObjAcaBal));

        }

    }
    protected void Rlist_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rlist.SelectedIndex == 1)
        {
            trNew.Visible = true;
            trOld.Visible = false;
        }
        else
        {
            trNew.Visible = false;
            trOld.Visible = true;
        }
    }

    void clear()
    {
        txtAdmDt.Text = txtData.Text = txtDOB.Text = txtEnrollment.Text = txtFatherName.Text = txtFatherOcc.Text = txtFirstName.Text = txtForm.Text = txtLastName.Text = txtMiddleName.Text = "";
        txtMotherName.Text = txtRemark.Text = txtStudent.Text = txtTestRank.Text = "";
        ddlAdmCategory.SelectedIndex = ddlBatch.SelectedIndex = ddlBloodGroup.SelectedIndex = ddlBranch.SelectedIndex = ddlCaste.SelectedIndex = 0;
        ddlGender.SelectedIndex = ddlInitial.SelectedIndex = ddlIns.SelectedIndex = ddlPgm.SelectedIndex = ddlQuota.SelectedIndex = 0;
        ddlReligion.SelectedIndex = ddlSection.SelectedIndex = ddlSem.SelectedIndex = 0;
    }

}
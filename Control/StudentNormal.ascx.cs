using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ExamFunctions;

public partial class Control_StudentNormal : System.Web.UI.UserControl
{
    DatabaseFunctions databaseFunctions;
    SqlCommand cmd;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }
    void Initialize()
    {
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    public void ShowStudent(string StuAdmNo)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_STU_SHORT_INFO";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", StuAdmNo);
        dt = databaseFunctions.GetDataSet(cmd).Tables[0];
        if (dt.Rows.Count > 0)
        {
            lblName.Text = dt.Rows[0]["STU_FULL_NAME"].ToString();
            imgPicture.Src = "../images/Stuimages/" + dt.Rows[0]["ENROLLMENT_NO"].ToString() + ".jpg";
            lblEnrollment.Text = dt.Rows[0]["ENROLLMENT_NO"].ToString();
            lblAddress.Text = dt.Rows[0]["ADD_1"].ToString() + ' ' + dt.Rows[0]["ADD_2"].ToString() + ' ' + dt.Rows[0]["CIT_VALUE"].ToString();
            lblBatch.Text = dt.Rows[0]["ACA_BATCH_NAME"].ToString();
            lblBranch.Text = dt.Rows[0]["BRN_SHORT_NAME"].ToString();
            lblSection.Text = dt.Rows[0]["ACA_SEC_NAME"].ToString();
            lblCourse.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString();
            lblDob.Text = dt.Rows[0]["DT_OF_BIRTH"].ToString();
            lblEmail.Text = dt.Rows[0]["EMAIL"].ToString();
            lblAdmType.Text = dt.Rows[0]["ADM_TYPE_VALUE"].ToString();
            lblFatherName.Text = dt.Rows[0]["FATHER_NAME"].ToString();
            lblMotherName.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
            lblInstitute.Text = dt.Rows[0]["INS_VALUE"].ToString();
            lblMobile.Text = dt.Rows[0]["PHN_NO"].ToString();
            lblSem.Text = dt.Rows[0]["ACA_SEM_ID"].ToString();
            lblStatus.Text = dt.Rows[0]["ADM_TYPE_VALUE"].ToString();
        }
    }
    public void Clear()
    {
        lblName.Text = "";
        lblEnrollment.Text = "";
        lblAddress.Text = "";
        lblBatch.Text = "";
        lblBranch.Text = "";
        lblCourse.Text = "";
        lblDob.Text = "";
        lblEmail.Text = "";
        lblFatherName.Text = "";
        lblInstitute.Text = "";
        lblMobile.Text = "";
        lblSem.Text = "";
        lblStatus.Text = "";
        lblMotherName.Text = "";

    }
}
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

public partial class Academic_prtCharacterCertificate : System.Web.UI.Page
{
    DatabaseFunctions DataBaseFunction;
    CommonFunctions CommonFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        if (Request.QueryString != null)
        {

            string str = "SELECT ENROLLMENT_NO,PGM_SHORT_NAME,BRN_SHORT_NAME,FATHER_NAME,StuView.GEN_ID,ACA_BATCH_NAME,REF_NO ,STU_FULL_NAME,ISSUE_TYPE,DES_VALUE,EMP_NAME  FROM StuView INNER JOIN STU_DOC_ISSUE ON StuView.STU_MAIN_ID = STU_DOC_ISSUE.STU_MAIN_ID INNER JOIN "
            + " EMP_VIEW ON STU_DOC_ISSUE.DOC_SIGN_BY = EMP_VIEW.EMP_ID WHERE DOC_ID = 29 AND STU_DOC_ISSUE.REF_NO = " + Request.QueryString[0] + "";
            DataTable dt = DataBaseFunction.GetDataSetByQuery(str).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblCourse.Text = lblCourse2.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString() + "-" + dt.Rows[0]["BRN_SHORT_NAME"].ToString();
                lblName.Text = lblStuName.Text = (dt.Rows[0]["GEN_ID"].ToString() == "2") ? "Ms. " + dt.Rows[0]["STU_FULL_NAME"].ToString() : "Mr. " + dt.Rows[0]["STU_FULL_NAME"].ToString();
                lblEnroll.Text = lblErollment.Text = dt.Rows[0]["ENROLLMENT_NO"].ToString();
                lblFather.Text = lblFather.Text = (dt.Rows[0]["GEN_ID"].ToString() == "2") ? "D/O SHRI." + dt.Rows[0]["FATHER_NAME"].ToString() : "S/O SHRI." + dt.Rows[0]["FATHER_NAME"].ToString();
                lblRefNo.Text = "MU/CHAR/";
                lblRefNo.Text += (dt.Rows[0]["ISSUE_TYPE"].ToString() == "0") ? dt.Rows[0]["REF_NO"].ToString() : "D" + dt.Rows[0]["REF_NO"].ToString();
                //lblDesig.Text = dt.Rows[0]["DES_VALUE"].ToString();
                lblBatch.Text = dt.Rows[0]["ACA_BATCH_NAME"].ToString();
                lblAuthorty.Text = dt.Rows[0]["EMP_NAME"].ToString();
            }
        }
    }
    void Initailize()
    {
        DataBaseFunction = new DatabaseFunctions();
        CommonFunction = new CommonFunctions();
    }
}
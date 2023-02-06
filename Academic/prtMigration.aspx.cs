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

public partial class Academic_prtMigration : System.Web.UI.Page
{
    DatabaseFunctions DataBaseFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        if (Request.QueryString != null)
        {
            string str = "SELECT STU_FULL_NAME,StuView.GEN_ID,ISSUE_TYPE,REF_NO,PGM_SHORT_NAME,BRN_SHORT_NAME,FATHER_NAME,ENROLLMENT_NO,DES_VALUE,EMP_NAME  FROM StuView INNER JOIN STU_DOC_ISSUE ON StuView.STU_MAIN_ID = STU_DOC_ISSUE.STU_MAIN_ID INNER JOIN "
            + " EMP_VIEW ON STU_DOC_ISSUE.DOC_SIGN_BY = EMP_VIEW.EMP_ID WHERE DOC_ID =28 AND STU_DOC_ISSUE.REF_NO = " + Request.QueryString[0] + "";
            DataTable dt = DataBaseFunction.GetDataSetByQuery(str).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblCourse.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString() + "-" + dt.Rows[0]["BRN_SHORT_NAME"].ToString();
                lblDate1.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblFather.Text = "SHRI " + dt.Rows[0]["FATHER_NAME"].ToString();
                lblName.Text = lblStuName.Text = (dt.Rows[0]["GEN_ID"].ToString() == "2") ? "MS. " + dt.Rows[0]["STU_FULL_NAME"].ToString() : "MR. " + dt.Rows[0]["STU_FULL_NAME"].ToString();
                lblNet.Text = lblErollment.Text = dt.Rows[0]["ENROLLMENT_NO"].ToString();
                lblRefNo.Text = "MU/MIG";
                lblRefNo.Text += (dt.Rows[0]["ISSUE_TYPE"].ToString() == "1") ? dt.Rows[0]["REF_NO"].ToString() : "D" + dt.Rows[0]["REF_NO"].ToString();
                //lblDesig.Text = dt.Rows[0]["DES_VALUE"].ToString();
                lblAuthorty.Text = dt.Rows[0]["EMP_NAME"].ToString();
            }
        }

    }
    void Initailize()
    {
        DataBaseFunction = new DatabaseFunctions();

    }
}
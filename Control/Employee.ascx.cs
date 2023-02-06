using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Control_Employee : System.Web.UI.UserControl
{

    DatabaseFunctions databaseFunctions;
    HRBLL ObjHrBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        databaseFunctions = new DatabaseFunctions();
        ObjHrBll = new HRBLL();
    }
    public void ShowEmployeeInfo(string EmpCode)
    {
        DataTable dt = ObjHrBll.GetEmpProfileDetail(EmpCode).Tables[0];
        if (dt.Rows.Count > 0)
        {
            div1.Attributes["class"] = (dt.Rows[0]["JOB_TYPE_ID"].ToString() == "1") ? "main-div" : "main-div-2";
            lblCode.Text = dt.Rows[0]["EMP_MUID"].ToString();
            lblName.Text = dt.Rows[0]["INI_VALUE"].ToString()+dt.Rows[0]["EMP_NAME"].ToString();
            lblFatherName.Text = dt.Rows[0]["EMP_FTH_NAME"].ToString();
            lblDob.Text = dt.Rows[0]["DOB"].ToString();
            lblEmail.Text = dt.Rows[0]["EMAIL"].ToString();
            lblNextS.Text = dt.Rows[0]["NEXT_SENIOR"].ToString();
            lblDoj.Text = dt.Rows[0]["DOJ"].ToString();
            lblDesg.Text = dt.Rows[0]["DES_VALUE"].ToString();
            lblDepartment.Text = dt.Rows[0]["DEPT_VALUE"].ToString();
            lblInstitute.Text = dt.Rows[0]["INS_VALUE"].ToString();
            lblStatus.Text = dt.Rows[0]["STS_VALUE"].ToString();
            lblAddress.Text = dt.Rows[0]["ADDRESS"].ToString();
            if (dt.Rows[0]["STS_ID"].ToString() == "0")
                lblRlvngDate.Text = "From :" + dt.Rows[0]["RELVNG_DATE"].ToString();
            string empImage = "../images/emp_images/" + EmpCode + "_thumb.jpg";
            if (System.IO.File.Exists(Server.MapPath(empImage)))
                imgPicture.Src = empImage;
            else
                imgPicture.Src = "../images/emp_images/empImage.jpg";
        }
        else
        {
            Clear();
        }
    }
    void Clear()
    {
        lblCode.Text = "";
        lblName.Text = "";
        lblDob.Text = "";
        lblEmail.Text = "";
        lblMobile.Text = "";
        //lblExt.Text = "";
        lblNextS.Text = "";
        lblDoj.Text = "";
        lblDesg.Text = "";
        lblDepartment.Text = "";
        lblInstitute.Text = "";
        lblStatus.Text = "";
        lblRlvngDate.Text = "";
        lblFatherName.Text = "";
        lblAddress.Text = "";
        imgPicture.Src = "../images/emp_images/empImage.jpg";
    }
}

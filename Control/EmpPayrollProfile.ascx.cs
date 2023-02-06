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

public partial class Control_EmpPayrollProfile : System.Web.UI.UserControl
{
    PRBAL prbal;
    PRBLL prbll;
    DataTable dt;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunction;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialisetion();
    }
    private void Initialisetion()
    {
        prbll = new PRBLL();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunction = new CommonFunctions();
        prbal = new PRBAL();
    }
    public void ShowEmployeeInfo(string EmpCode)
    {
        prbal.balEmpCode = EmpCode;
        dt=prbll.GetPayrollProf(prbal);
        
        if (dt.Rows.Count>0)
        {
           
            
            lblCode.Text = dt.Rows[0]["EMP_ID"].ToString();
            lblName.Text = dt.Rows[0]["EMP_NAME"].ToString();
            lblDob.Text = dt.Rows[0]["DOB"].ToString();
            lblEmail.Text = dt.Rows[0]["EMAIL"].ToString();
            lblMobile.Text = dt.Rows[0]["PHONE"].ToString();
            lblGross.Text = dt.Rows[0]["ES_TOTAL_GROSS_SALARY"].ToString();
            lblTemplate.Text = dt.Rows[0]["SAL_TEMPLATE_NAME"].ToString();
            if (dt.Rows[0]["TYPE"].ToString() == "2")
                lblScale.Text = dt.Rows[0]["SCALE"].ToString() + " With Grade Pay-" + dt.Rows[0]["NOI"].ToString();
            else
                lblScale.Text = dt.Rows[0]["SCALE"].ToString();
            lblAccount.Text = dt.Rows[0]["ACC_NO"].ToString();
            lblPan.Text = (dt.Rows[0]["PAN_NO"].ToString() == "") ? "NA" : dt.Rows[0]["PAN_NO"].ToString();
            if (dt.Rows[0]["STATUS"].ToString() == "1")
            {
                lblStatus.Text = "ACTIVE";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
            else if (dt.Rows[0]["STATUS"].ToString() == "2")
            {
                lblStatus.Text = "ON EOL";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblStatus.Text = "LEFT-" + Convert.ToDateTime(dt.Rows[0]["RELIVING_DATE"]).ToString("dd/MM/yyyy");
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }

            lblDoj.Text = dt.Rows[0]["DOJ"].ToString();
            lblDesg.Text = dt.Rows[0]["DES_VALUE"].ToString();
            lblDepartment.Text = dt.Rows[0]["DEPT_VALUE"].ToString();
            lblInstitute.Text = dt.Rows[0]["INS_VALUE"].ToString();
            string empImage = "../images/emp_images/" + EmpCode + "_thumb.jpg";
            if (System.IO.File.Exists(Server.MapPath(empImage)))
                imgPicture.Src = empImage;
            else
                imgPicture.Src = "../images/emp_images/empImage.jpg";

        }
        else
            Clear();
       
    }
    public void Clear()
    {
        lblCode.Text = "";
        lblName.Text = "";
        lblDob.Text = "";
        lblEmail.Text = "";
        lblMobile.Text = "";
        lblStatus.Text = "";
        lblScale.Text = "";
        lblDoj.Text = "";
        lblDesg.Text = "";
        lblDepartment.Text = "";
        lblInstitute.Text = "";
        imgPicture.Src = "../images/emp_images/empImage.jpg";
    }
}

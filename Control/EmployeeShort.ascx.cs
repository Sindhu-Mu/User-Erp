using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Control_EmployeeShort : System.Web.UI.UserControl
{
    DatabaseFunctions databaseFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        databaseFunctions = new DatabaseFunctions();
    }
    public void ShowEmployeeInfo(int EmpCode)
    {
        string str = "SELECT  EMP_VIEW.*,CONVERT(VARCHAR,EMP_RESIG_MAIN_INF.RELVNG_DATE,103) AS RELVNG_DATE FROM  EMP_VIEW Left Outer JOIN " +
                     " EMP_RESIG_MAIN_INF ON EMP_VIEW.EMP_ID = EMP_RESIG_MAIN_INF.EMP_ID WHERE EMP_VIEW.EMP_ID=" + EmpCode;

        SqlDataReader dr;
        dr = databaseFunctions.GetReaderByQuery(str);
        if (dr.HasRows)
        {
            dr.Read();
            lblCode.Text = dr["EMP_ID"].ToString();
            lblName.Text = dr["EMP_NAME"].ToString();
            lblNextS.Text = dr["NEXT_SENIOR"].ToString();
            lblDoj.Text = Convert.ToDateTime(dr["DOJ"]).ToString("dd-MMM-yyyy");
            lblDepartment.Text = dr["DEPT_VALUE"].ToString();
            lblInstitute.Text = dr["INS_VALUE"].ToString();
            lblStatus.Text = dr["STS_VALUE"].ToString();
            if (dr["STS_VALUE"].ToString() == "DEACTIVE")
            {
                lblRlvngDate.Text = ":" + dr["RELVNG_DATE"].ToString();
            }
            else
            {
                lblRlvngDate.Text = "";
            }
            string empImage = "../images/emp_images/" + Convert.ToString(EmpCode) + "_thumb.jpg";
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
        lblNextS.Text = "";
        lblDoj.Text = "";
        lblDepartment.Text = "";
        lblInstitute.Text = "";
        lblStatus.Text = "";
        lblRlvngDate.Text = "";
        imgPicture.Src = "../images/emp_images/empImage.jpg";
    }
}
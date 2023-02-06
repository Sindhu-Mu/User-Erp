using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Finance_Auditattendance : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    DataSet ds;
    AcaBAL objbal;
    AcaBLL objBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        div1.Visible = false;
    }
    void Initialize()
    {
        databaseFunctions = new DatabaseFunctions();
        objbal = new AcaBAL();
        objBll = new AcaBLL();
        ds = new DataSet();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        div1.Visible = true;
        objbal.Enroll_No = txtEnroll.Text;
        ds = objBll.AuditSelect(objbal);

        lblName.Text = ds.Tables[0].Rows[0]["NAME"].ToString();
        //lblEnrollment.Text = ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString();
        lblCourse.Text = ds.Tables[0].Rows[0]["COURSE"].ToString();
        lblInstitute.Text = ds.Tables[0].Rows[0]["INSTITUTE"].ToString();
        gvStuAtt.DataSource = ds;
        gvStuAtt.DataBind();



    }
}

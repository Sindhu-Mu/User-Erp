using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StudentAttandence : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataTable Dt;
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        Dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        Initialize();
        if (!IsPostBack)
        {
            txtEnroll.Text = "";

        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            string Enroll = CommonFunction.GetKeyID(txtEnroll);
            Student.ShowStudent(Enroll);
            ObjAcaBal.Stu_AdmNo = Enroll;
            gvStuAtt.DataSource = ObjAcaBll.GetStuAttandence_2(ObjAcaBal);
            gvStuAtt.DataBind();
        }
    }
}
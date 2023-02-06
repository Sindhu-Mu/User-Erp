using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_rptStuProfile : System.Web.UI.Page
{
    FillFunctions FillFunctin;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DatabaseFunctions DataBasefunction;
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();

    }

    public void Initialize()
    {
        QueryFunction = new QueryFunctions();
        FillFunctin = new FillFunctions();
        CommonFunction = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        DataBasefunction = new DatabaseFunctions();
        Dt = new DataTable();

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtAdmit.Text != "")
        {
            ObjBal.Stu_AdmNo = CommonFunction.GetKeyID(txtAdmit);
            ObjBal.Id = ObjBll.GetStudentMainId(ObjBal);
            StuFullProfile.StudentFullProfile(ObjBal.Id);
        }
    }
}
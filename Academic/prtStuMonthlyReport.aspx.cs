using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Data;
public partial class Academic_prtStuMonthlyReport : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 9)
            {
                Save(Request.QueryString);
            }
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        ds = new DataSet();
    }
    void Save(NameValueCollection parameters)
    {
        ObjBal.InsId = parameters.Get(0);
        ObjBal.Pgm_Id = parameters.Get(1);
        ObjBal.KeyID = parameters.Get(2);
        ObjBal.Semid = parameters.Get(3);
        ObjBal.Id = parameters.Get(4);
        ObjBal.CommonId = parameters.Get(5);
        ObjBal.Brn_Id = parameters.Get(6);
        ObjBal.Sec_Id = parameters.Get(7);
        ObjBal.Enroll_No = parameters.Get(8);
        ds = ObjBll.getStuMonthlyReportDetail(ObjBal);
        repeatStudentData.DataSource = ds;
        repeatStudentData.DataBind();

        for (int i = 0; i < (ds.Tables.Count - 1); i++)
        {
            FillFunction.Fill((GridView)repeatStudentData.Items[i].FindControl("gvAttendance1"), ds.Tables[i + 1]);
            //FillFunction.Fill((GridView)repeatStudentData.Items[i].FindControl("gvAttendance11"), ds.Tables[i + 1]);
            //string due = ds.Tables[i + 1].Rows[0]["DUE_AMT"].ToString();
            //if (Convert.ToDouble(due) > 0)
            //{
                //((Label)repeatStudentData.Items[i].FindControl("lblFee")).Text = ((Label)repeatStudentData.Items[i].FindControl("lblDue")).Text = due;
                //repeatStudentData.Items[i].FindControl("trAmt").Visible = true;
            //}
            //else
                //repeatStudentData.Items[i].FindControl("trAmt").Visible = false;
        }


    }
}
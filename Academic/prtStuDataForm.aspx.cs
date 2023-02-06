using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_prtStuDataForm : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataTable Dt;
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    DatabaseFunctions DataBasefunction;
    FillFunctions FillFunction;
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            str = " SELECT StuFullView.STU_MAIN_ID,'../Images/StuImages/'+ENROLLMENT_NO+'.jpg' AS IMG, StuFullView.ENROLLMENT_NO, StuFullView.SEM_ROLL_NO, StuFullView.FORM_NO, StuFullView.FIRST_NAME, StuFullView.MIDDLE_NAME, StuFullView.LAST_NAME, StuFullView.STU_FULL_NAME, StuFullView.DT_OF_BIRTH, StuFullView.FATHER_NAME, "
  + " StuFullView.MOTHER_NAME,INS_VALUE, StuFullView.FATHER_OCCUP, StuFullView.INS_VALUE, StuFullView.PGM_SHORT_NAME,StuFullView.PGM_FULL_NAME, StuFullView.PGM_DURATION,StuFullView.BRN_SHORT_NAME, StuFullView.BRN_FULL_NAME, "
  + " StuFullView.ACA_SEC_NAME, StuFullView.ACA_SEM_NO, StuFullView.SEM_STATUS,StuFullView.ACA_BATCH_NAME, StuFullView.ACA_BATCH_START_DT,StuFullView.BLO_GRP_VALUE, "
  + " StuFullView.CAS_ALIAS, StuFullView.REL_VALUE,StuFullView.NAT_VALUE,StuFullView.STU_STS_VALUE, StuFullView.PHN_NO, StuFullView.QUOTA_NAME, StuFullView.REG_STATUS,StuFullView.STA_VALUE, "
  + "StuFullView.COU_VALUE, StuFullView.GEN_VALUE, StuFullView.EMAIL,STU_ADD_CNG_INF.ADD_1, STU_ADD_CNG_INF.ADD_2, STU_ADD_CNG_INF.CIT_ID,ADD_INF.ADD_TYPE_VALUE,StuFullView.CIT_VALUE "
  + " FROM  ADD_INF INNER JOIN STU_ADD_CNG_INF ON ADD_INF.ADD_TYPE_ID = STU_ADD_CNG_INF.ADD_TYPE_ID RIGHT OUTER JOIN "
  + " StuFullView ON STU_ADD_CNG_INF.STU_MAIN_ID = StuFullView.STU_MAIN_ID ";
            if (Request.QueryString.Count > 0)
                str += " WHERE StuFullView.STU_MAIN_ID in (" + Request.QueryString["STU_MAIN_ID"].ToString() + ")";
            else
                str += " WHERE StuFullView.STU_MAIN_ID in (" + Session["STU_MAIN_ID"].ToString() + ")";
            str += " ORDER BY StuFullView.ENROLLMENT_NO";
            Repeater1.DataSource = DataBasefunction.GetDataSetByQuery(str);
            Repeater1.DataBind();


        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        Dt = new DataTable();
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        DataBasefunction = new DatabaseFunctions();
        FillFunction = new FillFunctions();
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        HiddenField hiddenID = (HiddenField)e.Item.FindControl("HiddenID");
        string id = hiddenID.Value;
        GridView gv = new GridView();
        gv = (GridView)e.Item.FindControl("GridView1");
        str = " SELECT STU_ACA_INF.STU_MAIN_ID, ACA_BASE_INF.ACA_BASE_FULL_NAME, STU_ACA_INF.TOT_MARKS, STU_ACA_INF.TOT_GAIN, STU_ACA_INF.PRSNT,"
                        + "STU_ACA_INF.ACA_SCHOOL, ACA_BRD_INF.ACA_BRD_SHORT_NAME "
                         + "FROM STU_ACA_INF INNER JOIN "
                         + "ACA_BASE_INF ON STU_ACA_INF.ACA_BASE_ID = ACA_BASE_INF.ACA_BASE_ID INNER JOIN "
                        + " ACA_BRD_INF ON STU_ACA_INF.ACA_BRD_ID = ACA_BRD_INF.ACA_BRD_ID "
                         + "WHERE  (STU_ACA_INF.STU_MAIN_ID = " + id + ")";
        gv.DataSource = DataBasefunction.GetDataSetByQuery(str);
        gv.DataBind();

    }
}
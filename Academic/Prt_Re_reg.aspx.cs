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
using System.Data.SqlClient;

public partial class Academic_Prt_Re_reg : System.Web.UI.Page
{
    DatabaseFunctions databaseFnction;
    FacBAL ObjFacBal;
    FacBLL ObjfacBll;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            string str = "SELECT distinct StuFullView.STU_FULL_NAME, CASE WHEN SEM_STS = 1 THEN 'APPROVED' ELSE 'PENDING' END AS SEM_STS, CONVERT(VARCHAR, STU_SEM_REG_MAIN.REG_DATE, 103) AS REG_DATE, "
                         + " StuFullView.ENROLLMENT_NO, STU_SEM_REG_MAIN.SEM_REG_ID, StuFullView.PGM_FULL_NAME, "
                         + " StuFullView.BRN_FULL_NAME, StuFullView.INS_VALUE, STU_SEM_REG_CONFIG_INF.CON_REG_NAME, STU_SEM_REG_CONFIG_INF.CON_REG_SESSION, "
                         + " STU_SEM_REG_MAIN.REG_FOR_SEM AS ACA_SEM_NO "
                         + " FROM STU_SEM_REG_CONFIG_INF INNER JOIN "
                         + " STU_SEM_REG_MAIN ON STU_SEM_REG_CONFIG_INF.CON_REG_ID = STU_SEM_REG_MAIN.CON_REG_ID INNER JOIN "
                         + " STU_SEM_REG_SUB_INF ON STU_SEM_REG_MAIN.SEM_REG_ID = STU_SEM_REG_SUB_INF.SEM_REG_ID INNER JOIN "
                         + " StuFullView ON STU_SEM_REG_MAIN.STU_MAIN_ID = StuFullView.STU_MAIN_ID LEFT OUTER JOIN "
                         + " STU_SEM_REG_PRNT_INF ON STU_SEM_REG_MAIN.SEM_REG_ID = STU_SEM_REG_PRNT_INF.SEM_REG_ID ";

            if (Request.QueryString.Count > 0)
                str += " WHERE STU_SEM_REG_MAIN.SEM_REG_ID in(" + Request.QueryString["SEM_REG_ID"].ToString() + ")";
            else
                str += " WHERE STU_SEM_REG_MAIN.SEM_REG_ID in(" + Session["REG_ID"].ToString() + ")";
            Repeater1.DataSource = databaseFnction.GetDataSetByQuery(str);
            Repeater1.DataBind();
        }
    }

    protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //object RARM_ID = DataBinder.Eval(e.Item.DataItem, "RARM_ID");
        object REG_ID = DataBinder.Eval(e.Item.DataItem, "SEM_REG_ID");
        ObjFacBal.RegId = REG_ID.ToString();
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjfacBll.StuReRegPrint(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
    void Initialize()
    {
        databaseFnction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjfacBll = new FacBLL();
    }
}
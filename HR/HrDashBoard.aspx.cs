using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_HrDashBoard : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjAcaBAL;
    HRBLL ObjHrBll;
    DataSet ds;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjAcaBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ds=ObjHrBll.getHrDashBoard();
            gvAttendance.DataSource = ds.Tables[0];
            gvAttendance.DataBind();
            gvNewJoin.DataSource = ds.Tables[1];
            gvNewJoin.DataBind();
            gvReleived.DataSource = ds.Tables[2];
            gvReleived.DataBind();
            gvLongAbsent.DataSource = ds.Tables[3];
            gvLongAbsent.DataBind();
            gvEolStart.DataSource = ds.Tables[4];
            gvEolStart.DataBind();
            gvEolFinish.DataSource = ds.Tables[5];
            gvEolFinish.DataBind();
            gvDeptChng.DataSource = ds.Tables[6];
            gvDeptChng.DataBind();
            gvDeputation.DataSource = ds.Tables[7];
            gvDeputation.DataBind();
            gvAppointment.DataSource = ds.Tables[8];
            gvAppointment.DataBind();
            gvDocument.DataSource = ds.Tables[9];
            gvDocument.DataBind();
        }

    }
}
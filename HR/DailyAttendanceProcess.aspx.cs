using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_AttendanceProcess : System.Web.UI.Page
{
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;
    DataSet ds;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunction;
    string Msg = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnUpload.Attributes.Add("OnClick", "return valid()");
        Initialize();
        if (!IsPostBack)
        {
           
        }
    }
    public void Initialize()
    {
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        databaseFunction = new DatabaseFunctions();
        dt = new DataTable();
        ds = new DataSet();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();   
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyValue = txtTodayDate.Text;
        Msg = ObjHrBll.GetDaliyAttendanceUpload(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+Msg+"')", true);   

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Common_NewJoining : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
      
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    void FillGrid()
    {
        dt = ObjHrBll.GetNewJoining().Tables[0];
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
}
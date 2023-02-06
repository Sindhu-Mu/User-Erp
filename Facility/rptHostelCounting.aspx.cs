using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_rptHostelCounting : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = objBll.GetHostelStuCount();
            fillFunctions.Fill(gvIns, ds.Tables[1]);
            fillFunctions.Fill(gvCourse, ds.Tables[2]);
            fillFunctions.Fill(GvBatch, ds.Tables[3]);
            fillFunctions.Fill(gvCaste, ds.Tables[4]);
            fillFunctions.Fill(gvBranch, ds.Tables[5]);
            fillFunctions.Fill(gvFloor, ds.Tables[6]);
            fillFunctions.Fill(gvSem, ds.Tables[7]);
            fillFunctions.Fill(gvBrnSem, ds.Tables[8]);
            fillFunctions.Fill(gvRel, ds.Tables[9]);
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
    }
}
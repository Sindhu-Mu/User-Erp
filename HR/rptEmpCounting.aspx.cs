using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_rptEmpCounting : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    HRBLL ObjHrBll;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjHrBll = new HRBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            DataSet ds = new DataSet();
            ds = ObjHrBll.EmployeeCount();
            lblSearch.Text = "Employee Counting ..." + ds.Tables[0].Rows[0][0].ToString();
            FillDetail(gvInstituion, ds.Tables[1]);
            FillDetail(gvDepartment, ds.Tables[2]);
            FillDetail(gvType, ds.Tables[3]);
            FillDetail(gvStatus, ds.Tables[4]);
            FillDetail(gvCategory, ds.Tables[5]);
            FillDetail(gvDesignation, ds.Tables[6]);
            FillDetail(gvTeaching, ds.Tables[7]);
            FillDetail(gvGender, ds.Tables[8]);
            FillDetail(gvMarital, ds.Tables[9]);
            FillDetail(gvCaste, ds.Tables[10]);
            FillDetail(gvReligion, ds.Tables[11]);
            FillDetail(gvEOL, ds.Tables[12]);
        }
    }

    void FillDetail(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }
}
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


public partial class Facility_prtEmpRoomAlmt : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DatabaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable dt;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        if (Request.QueryString != null)    
        {
            ObjFacBal.Id = Request.QueryString[0];
            dt = ObjFacBll.GetDetailRoomAlmt(ObjFacBal).Tables[0];
            if (dt.Rows.Count > 0)
            {
                lblempname.Text = dt.Rows[0]["EMP_NAME"].ToString();
                lblcomplexname.Text = dt.Rows[0]["FAC_CMPLX_NAME"].ToString();
                lblempid.Text = dt.Rows[0]["EMP_ID"].ToString();
                lblfromdate.Text = dt.Rows[0]["OCCUPIED_DATE"].ToString();
                lblinsertby.Text = dt.Rows[0]["ALLOT_BY"].ToString();
                lblinsertdate.Text = dt.Rows[0]["ALLOT_DT"].ToString();
                lblroomno.Text = dt.Rows[0]["ROOM_NO"].ToString();
            }
        }
    }
    void Initailize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
}
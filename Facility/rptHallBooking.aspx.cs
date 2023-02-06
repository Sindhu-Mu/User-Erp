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

public partial class Facility_rptHallBooking : System.Web.UI.Page
{
    DatabaseFunctions Databasefunction;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DataTable Dt;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = "";
            FillDetail();
        }
    }
    void Initialize()
    {
        Databasefunction = new DatabaseFunctions();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        Dt = new DataTable();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
    }
    void FillDetail()
    {
        ObjFacBal.Id = Request.QueryString[0].ToString();
        Dt = ObjFacBll.HallDeatil(ObjFacBal).Tables[0];
        if (Dt.Rows.Count > 0)
        {
            ViewState["ID"] = Dt.Rows[0]["HALL_REQ_ID"].ToString();
            lblHall.Text = Dt.Rows[0]["FAC_CMPLX_NAME"].ToString();
            lblDate.Text = Dt.Rows[0]["BOOKINGON"].ToString();
            lblEvent.Text = Dt.Rows[0]["EVENT_INFO"].ToString();
            lblNOStudent.Text = Dt.Rows[0]["HALL_BOOK_NO"].ToString();
            lblTime.Text = Dt.Rows[0]["BOOKINGTIME"].ToString();
            lblAdmReq.Text = Dt.Rows[0]["ADM_REQ"].ToString();
            lblFacility.Text = Dt.Rows[0]["HALL_SERVICE_REQ"].ToString();
            lblName.Text = Dt.Rows[0]["EMP_NAME"].ToString();
            lblDept.Text = Dt.Rows[0]["DEPT_VALUE"].ToString();
            lblGuestName.Text = Dt.Rows[0]["GUEST_NAME"].ToString();
            lblGuestNo.Text = Dt.Rows[0]["GUEST_NO"].ToString();
            lblGuestAddress.Text = Dt.Rows[0]["GUEST_ADD"].ToString();
            lblDetail.Text = Dt.Rows[0]["HALL_BOOK_DETAIL"].ToString();
            FillFunction.Fill(GvFac, ObjFacBll.HallDeatil(ObjFacBal).Tables[1]);
            FillFunction.Fill(gvHall, ObjFacBll.HallDeatil(ObjFacBal).Tables[0]);
        }

    }
}
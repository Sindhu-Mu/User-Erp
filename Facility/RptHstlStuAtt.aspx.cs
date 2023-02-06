using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_RptHstlStuAtt : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    DatabaseFunctions DatabaseFunction;
    QueryFunctions QueryFunction;
    FillFunctions Fillfunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return Allotvalidate()");
        if (!IsPostBack)
        {
            txtDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ddlSts.SelectedIndex = 1;
            if (Session["HostelId"].ToString() != "")
            {
                Fillfunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HostelComplex, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.All);
                Fillfunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
                Fillfunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNo, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
            }
            else
            {
                Fillfunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlCmplx), true, FillFunctions.FirstItem.All);
            }
            Fillfunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            Fillfunction.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        DatabaseFunction = new DatabaseFunctions();
        QueryFunction = new QueryFunctions();
        Fillfunction = new FillFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    protected void ddlComplex_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillfunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, ddlComplex.SelectedValue), false, FillFunctions.FirstItem.All);
        Fillfunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNo, ddlComplex.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        Fillfunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, ddlComplex.SelectedValue,ddlFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
            ObjFacBal.AuthFor = txtEnroll.Text;
            if (ObjFacBal.AuthFor != "")
            {
                ObjFacBal.StuAdmNo = ObjFacBll.GetStudentMainId(ObjFacBal);
                ObjFacBal.frdt = txtDt.Text;
                ObjFacBal.cmpxId = ddlComplex.SelectedValue;
                ObjFacBal.RoomFloor = ddlFloor.SelectedValue;
                ObjFacBal.RoomId = ddlRoom.SelectedValue;
                ObjFacBal.Id = ddlCourse.SelectedValue;
                ObjFacBal.RateSem = ddlSem.SelectedValue;
                ObjFacBal.Status = ddlSts.SelectedValue;
            }
            else
            {
                ObjFacBal.frdt = txtDt.Text;
                ObjFacBal.cmpxId = ddlComplex.SelectedValue;
                ObjFacBal.RoomFloor = ddlFloor.SelectedValue;
                ObjFacBal.RoomId = ddlRoom.SelectedValue;
                ObjFacBal.Id = ddlCourse.SelectedValue;
                ObjFacBal.RateSem = ddlSem.SelectedValue;
                ObjFacBal.Status = ddlSts.SelectedValue;
            }
            dt = ObjFacBll.HstlAttRpt(ObjFacBal).Tables[0];
            gvDetail.DataSource = dt;
            gvDetail.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO; 

public partial class Academic_HostelStuInf : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    DataTable Dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return Allotvalidate()");
        if(!IsPostBack)
        {
            Student.Visible = false;
            if (Session["HostelId"].ToString() != "")
            {
                FillFunction.Fill(ddlCmplx, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HostelComplex, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.All);
                FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNo, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
                FillFunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
            }
            else
            {
                FillFunction.Fill(ddlCmplx, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlCmplx), true, FillFunctions.FirstItem.All);
            }
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        Dt = new DataTable();
    }
    void FillGrid()
    {
       
            ObjAcaBal.CommonId = ddlCmplx.SelectedValue;
            ObjAcaBal.Id = "0";
            ObjAcaBal.Value = ddlRoom.SelectedValue;
            ObjAcaBal.DeptId = ddlFloor.SelectedValue;
        gvStu.DataSource =  ObjAcaBll.HostelStuDetail(ObjAcaBal);
        gvStu.DataBind();
    }
    protected void gvStu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            Student.Visible = true;
            Student.StudentFullProfile(gvStu.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        }

    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCmplx.SelectedIndex > 0)
            FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNo, ddlCmplx.SelectedValue), true, FillFunctions.FirstItem.Select);
        if (ddlFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, ddlCmplx.SelectedValue, ddlFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
         FillGrid();
    }
    protected void ddlCmplx_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, ddlCmplx.SelectedValue), false, FillFunctions.FirstItem.Select);

    }
}
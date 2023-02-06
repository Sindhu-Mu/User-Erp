using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_rpt_Department_Student : System.Web.UI.Page
{
    FillFunctions FillFunctin;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DatabaseFunctions DataBasefunction;
    DataTable Dt;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();

        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            bindDropDown();
        }
    }

    public void Initialize()
    {
        QueryFunction = new QueryFunctions();
        FillFunctin = new FillFunctions();
        CommonFunction = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        DataBasefunction = new DatabaseFunctions();
        Dt = new DataTable();

    }
    private void bindDropDown()
    {
        //ViewState["ID"] = DataBasefunction.GetSingleData(QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Emp_Dept, "340"/*Session["UserId"].ToString()*/));
        FillFunctin.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.pgm_dept, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
        FillFunctin.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        FillFunctin.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        FillFunctin.Fill(ddlSec, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        FillFunctin.Fill(ddlGroup, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Group), true, FillFunctions.FirstItem.All);
        FillFunctin.Fill(ddlStatus, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Stu_Status), true, FillFunctions.FirstItem.All);
    }

    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunctin.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.BranchName_ByCourse, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.All);
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjBal.InsId = ViewState["ID"].ToString();
        ObjBal.Id = ddlCourse.SelectedValue;
        ObjBal.KeyID = ddlBatch.SelectedValue;
        ObjBal.KeyValue = ddlBranch.SelectedValue;
        ObjBal.TypeId = ddlSem.SelectedValue;
        ObjBal.Value = ddlSec.SelectedValue;
        ObjBal.UseFor = ddlGroup.SelectedValue;
        ObjBal.ChangeStatus = ddlStatus.SelectedValue;
        ObjBal.Description = ddlSort.SelectedValue;
        gvDetail.DataSource = ObjBll.GetInsStudent(ObjBal);
        gvDetail.DataBind();
    }
}
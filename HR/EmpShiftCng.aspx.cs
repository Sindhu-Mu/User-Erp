using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class HR_AttendanceShiftChange : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
    CommonFunctions commonFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["dt"] = dt;
            FillFunction.Fill(ddlShift, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ShiftWithTime), true, FillFunctions.FirstItem.Select);
            step1.ActiveTabIndex = 0;
        }
    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.EmpId = common.GetKeyID(txtEmp);
        ObjAcaBAL.KeyID = ddlShift.SelectedValue;
        ObjAcaBAL.FromDate = common.GetDateTime(txtFromDt.Text);
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ObjAcaBAL.RemValue = txtRemark.Text;
        ObjHrBll.EmployeeShiftChangeInsertUpdate(ObjAcaBAL);
        clear();
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Inserted')", true);

    }
    public void FillGrid()
    {
        ObjAcaBAL.EmpId = common.GetKeyID(txtEmp);
        ViewState["dt"] = gvShow.DataSource = ObjHrBll.EmployeeShiftChangeSelect(ObjAcaBAL).Tables[0];
        gvShow.DataBind();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SFT_CNG_ID=" + ViewState["ID"].ToString());
            txtEmp.Text = dr[0]["EMP"].ToString();
            txtFromDt.Text = dr[0]["FROM_DATE"].ToString();
            ddlShift.SelectedIndex = Convert.ToInt32(dr[0]["TIME_ID"].ToString());

        }
    }
    void clear()
    {
        txtEmp.Text = txtFromDt.Text = txtRemark.Text = "";
        ddlShift.SelectedIndex = 0;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Employee.ShowEmployeeInfo(commonFunctions.GetKeyID(txtEmp));
        FillGrid();
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            FillFunction.Fill(ddlShift, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ShiftWithTime), true, FillFunctions.FirstItem.Select);
            Employee.ShowEmployeeInfo("0");
            txtEmp.Text = "";
            gvShow.DataSource = "";
            gvShow.DataBind();
        }
        if (step1.ActiveTabIndex == 1)
        {
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlShiftRpt, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ShiftWithTime), true, FillFunctions.FirstItem.Select);
            ddlDept.Items.Clear();
            gvShift.DataSource = "";
            gvShift.DataBind();
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
       }
        else
            ddlDept.Items.Clear();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.InsId = ddlIns.SelectedValue;
        ObjAcaBAL.DeptId = ddlDept.SelectedValue;
        ObjAcaBAL.KeyID = ddlShiftRpt.SelectedValue;
        ObjAcaBAL.Min = txtFrom.Text;
        ObjAcaBAL.Max = txtTo.Text;
        gvShift.DataSource = ObjHrBll.GetEmployeeShiftChange(ObjAcaBAL).Tables[0];
        gvShift.DataBind();

    }
}
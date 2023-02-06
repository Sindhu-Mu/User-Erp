using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_EmpDepartmentCng : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;   
    HRBLL ObjHrBll;   
    HRBAL ObjAcaBAL;
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();      
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("onClick", "return validat()");
        btnSave.Attributes.Add("onClick", "return validation()");
        if (!IsPostBack)
           fill.Fill(ddlDeptName, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        
    }    
    private void FillGrid()
    {
        ObjAcaBAL.EmpId = common.GetKeyID(txtName);
        GVTransfer.DataSource = ObjHrBll.EmpDeptCngSelect(ObjAcaBAL).Tables[0]; 
        GVTransfer.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Employee.ShowEmployeeInfo(common.GetKeyID(txtName));
        FillGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.EmpId = common.GetKeyID(txtName);     
        ObjAcaBAL.DeptId = ddlDeptName.SelectedValue;
        ObjAcaBAL.Date = common.GetDateTime(txtDate.Text);
        ObjAcaBAL.Description = txtRemark.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('"+ObjHrBll.EmpDeptCngInsert(ObjAcaBAL)+"')", true);
        //common.Clear(this);
        ddlDeptName.SelectedIndex = 0;
        txtDate.Text = txtRemark.Text = "";
        FillGrid();      
    }
    
}
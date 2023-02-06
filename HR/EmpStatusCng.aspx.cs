using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class HR_EmpStatusCng : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions commonFunctions;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validat()");
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            fill.Fill(ddlStatus, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.EmployeeStatus), true, FillFunctions.FirstItem.Select);

        }
    }
    private void FillGrid()
    {
        ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtEmp);
        fill.Fill(GridShow, ObjHrBll.EmpStatusCngSelect(ObjAcaBAL).Tables[0]);
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.KeyValue = ddlStatus.SelectedValue;
        ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtEmp);
        ObjAcaBAL.Date = commonFunctions.GetDateTime(txtDate.Text);
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert(" + ObjHrBll.EmpStatusCngInsert(ObjAcaBAL) + ")", true);
        txtDate.Text = txtEmp.Text = "";
        ddlStatus.SelectedIndex = 0;
        txtEmp.Focus();
        FillGrid();
        
    }
   
    protected void btnView_Click(object sender, EventArgs e)
    {
        Employee.ShowEmployeeInfo(commonFunctions.GetKeyID(txtEmp));
        FillGrid();
    }
}

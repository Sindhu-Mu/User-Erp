using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_EmpLvBalModify : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    HRBLL ObjBll;
    DataTable dt;
    HRBAL ObjBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        //btnSave.Attributes.Add("OnClick", "return validate()");
        btnShow.Attributes.Add("OnClick", "return validat()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            
        }
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjBll = new HRBLL();
        ObjBAL = new HRBAL();
    }
    private void FillGrid()
    {
        ObjBAL.EmpId = common.GetKeyID(txtEmployee);
        ObjBAL.Year = DateTime.Now.Year.ToString();
        dt = ObjBll.GetLeaveBalance(ObjBAL).Tables[0];                                     // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvBalance.DataSource = dt;
        gvBalance.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Employee.ShowEmployeeInfo(common.GetKeyID(txtEmployee));
        FillGrid();
        
    }
 
    protected void gvBalance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBAL.KeyID =gvBalance.DataKeys[e.RowIndex].Value.ToString();
        ObjBAL.Value1 = ((TextBox)gvBalance.Rows[e.RowIndex].FindControl("txtCredit")).Text;
        ObjBAL.Value2 = ((TextBox)gvBalance.Rows[e.RowIndex].FindControl("txtLapsed")).Text;         
        ObjBAL.KeyValue = ((TextBox)gvBalance.Rows[e.RowIndex].FindControl("txtAvailed")).Text;
        ObjBAL.ValueType = ((TextBox)gvBalance.Rows[e.RowIndex].FindControl("txtApplied")).Text;
        ObjBAL.InBy=Session["UserId"].ToString();
        string Msg=ObjBll.EmpLeaveBalanceUpdate(ObjBAL);
        if(Msg.Contains("successfully"))
        {
            FillGrid();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
}
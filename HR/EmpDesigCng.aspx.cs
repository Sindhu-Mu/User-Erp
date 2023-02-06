using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_EmpDesignationCng : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    Messages msg;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        btnShow.Attributes.Add("OnClick", "return validat()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            fill.Fill(ddlGrade, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Category), true, FillFunctions.FirstItem.Select);
        }
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    private void FillGrid()
    {
        ObjAcaBAL.EmpId = common.GetKeyID(txtEmployee);
        dt = ObjHrBll.EmpDesChangeSelect(ObjAcaBAL).Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        GridShow.DataSource = dt;
        GridShow.DataBind();
    }
    protected void ddlGrade_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGrade.SelectedIndex > 0)
            fill.Fill(ddlDesignation, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DesigByCategory, ddlGrade.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            common.Clear(CommonFunctions.ClearType.Value, ddlDesignation);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ObjAcaBAL.EmpId = common.GetKeyID(txtEmployee);
            ObjAcaBAL.Date = common.GetDateTime(txtFromDate.Text);
            ObjAcaBAL.ValueType = ddlDesignation.SelectedValue;
            ObjAcaBAL.KeyID = ViewState["ID"].ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            string msg = ObjHrBll.EmpDesChangeInsert(ObjAcaBAL);
            ViewState["ID"] = "";
            txtFromDate.Text = "";
            ddlGrade.SelectedIndex = 0;
            ddlDesignation.SelectedIndex = 0;
            FillGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Employee designation has changed. Now it can't change.')", true);
        }
    }
    
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Employee.ShowEmployeeInfo(common.GetKeyID(txtEmployee));
        FillGrid();
        txtFromDate.Text = "";
        ddlGrade.SelectedIndex = 0;
    }
}
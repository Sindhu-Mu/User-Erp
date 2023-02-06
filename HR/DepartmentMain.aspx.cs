using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_DepartmentMain : System.Web.UI.Page
{

    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        btnHeadSave.Attributes.Add("onclick", "return validationHead()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
            fillfunctions.Fill(ddlInstitue, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlDeptType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DeptType), true, FillFunctions.FirstItem.Select);
        }
    }
    private void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {

            fillfunctions.Fill(ddlInstitue, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillGrid();
            ViewState["ID"] = ""; ddlInstitue.SelectedIndex = 0;
            txtDeptName.Text = txtDeptShortName.Text = "";
        }
        else
        {
            fillfunctions.Fill(ddlIns, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillfunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
            txtFromDt.Text = txtEmp.Text = "";
            FillHeadGrid();

        }

    }
    private void FillGrid()   // fill grid view with select all record from table
    {
        ObjHrBAL.InsId = ddlInstitue.SelectedValue;
        dt = ObjHrBll.DepartmentSelect(ObjHrBAL).Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    private void FillHeadGrid()   // fill grid view with select all record from table
    {
        ObjHrBAL.InsId = ddlIns.SelectedValue;
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        dt = ObjHrBll.GetDeptHead(ObjHrBAL).Tables[0];
        ViewState["dt"] = dt;
        gvDeptHead.DataSource = dt;
        gvDeptHead.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e) // Department insert & Update Information
    {

        ObjHrBAL.KeyID = ViewState["ID"].ToString();
        ObjHrBAL.InsId = ddlInstitue.SelectedValue;
        ObjHrBAL.KeyValue = txtDeptName.Text;
        ObjHrBAL.AliasValue = txtDeptShortName.Text;
        ObjHrBAL.TypeId = ddlDeptType.SelectedValue;
        ObjHrBAL.ValueType = RbEssential.SelectedValue;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.DepartmentInsertUpdate(ObjHrBAL);
        ViewState["ID"] = "";
        clear();
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);

    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("DEPT_ID=" + ViewState["ID"].ToString());
            if (dr[0]["DEPT_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlInstitue.SelectedValue = dr[0][2].ToString();
            txtDeptName.Text = dr[0][1].ToString();
            txtDeptShortName.Text = dr[0][3].ToString();
            ddlDeptType.SelectedValue = dr[0][7].ToString();
            RbEssential.SelectedValue = dr[0][8].ToString();
        }
        else
        {
            ObjHrBAL.ChangeStatus = e.CommandName;
            ObjHrBAL.KeyID = e.CommandArgument.ToString();
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.DepartmentModify(ObjHrBAL);                                            // Department Status Change In Update Formss
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
    protected void ddlInstitue_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillfunctions.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            FillHeadGrid();
        }
    }
    protected void btnHeadSave_Click(object sender, EventArgs e)
    {
        ObjHrBAL.SessionUserID = common.GetKeyID(txtEmp);
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        ObjHrBAL.FromDate = common.GetDateTime(txtFromDt.Text);
        Msg = ObjHrBll.Dept_Head_Insert(ObjHrBAL);
        FillHeadGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clearHead();

    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillHeadGrid();
    }
    void clear()
    {
        ddlInstitue.SelectedIndex = ddlDeptType.SelectedIndex = 0;
        txtDeptName.Text = txtDeptShortName.Text = "";
    }
    void clearHead()
    {
        ddlIns.SelectedIndex = ddlDept.SelectedIndex = 0;
        txtEmp.Text = txtFromDt.Text= "";
    }
   
}
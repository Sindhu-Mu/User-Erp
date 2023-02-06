using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_BranchDeptMapp : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    Messages msg;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("OnClick", "return validation()");
        Initialize();

        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            fill.Fill(ddlInstitute, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            //fill.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        }
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    private void FillGrid()
    {
        dt = bll.PgmDeptMapSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        bal.KeyID = ViewState["ID"].ToString();
        bal.DeptId = ddlDept.SelectedValue;
        bal.CommonId = ddlCourse.SelectedValue;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.PgmDeptMapInsertUpdate(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        ddlDept.SelectedIndex = ddlCourse.SelectedIndex = 0;
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {

            common.Clear(ddlCourse, CommonFunctions.ClearType.Index);
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("DEPT_PGM_MAP_ID=" + ViewState["ID"].ToString());
            if (dr[0]["MAP_STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlInstitute.SelectedValue = dr[0]["INS_ID"].ToString();
            fill.Fill(ddlCourse, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlDept.SelectedValue = dr[0]["DEPT_ID"].ToString();
            ddlCourse.SelectedValue = dr[0]["INS_PGM_ID"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.PgmDeptMapModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();


        }
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fill.Fill(ddlCourse, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            ddlCourse.Items.Clear();
            ddlDept.Items.Clear();
        }
    }
}
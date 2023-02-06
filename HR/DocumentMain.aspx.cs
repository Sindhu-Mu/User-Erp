using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class HR_DocumentMain : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    string Msg;
    HRBLL ObjHrBll;
    HRBAL ObjHrBal;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
            fill.Fill(ddlType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.JobType), true, FillFunctions.FirstItem.Select);
          //  fill.Fill(ddlDocFor, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DocFor), true, FillFunctions.FirstItem.Select);
        }
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBal = new HRBAL();
    }
    private void FillGrid()
    {
        dt = ObjHrBll.EmpDocTypeSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)// Employee Update Information(Modify)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.Name = txtDocName.Text;
        ObjHrBal.ValueType = ddlType.SelectedValue;
        ObjHrBal.TypeId = ddlDocFor.SelectedValue;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.EmpDocTypeInsertUpdate(ObjHrBal);
        clear();
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e) // Employee Status Change In Update Formss
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("DOC_ID=" + ViewState["ID"].ToString());
            if (dr[0]["DOC_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtDocName.Text = dr[0]["DOC_NAME"].ToString();
            ddlType.SelectedValue = dr[0]["JOB_TYPE_ID"].ToString();
            ddlDocFor.SelectedValue = dr[0]["DOC_FOR_ID"].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.EmpDocTypeModify(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
    void clear()
    {
        txtDocName.Text = "";
        ddlDocFor.SelectedIndex = ddlType.SelectedIndex = 0;
    }
}
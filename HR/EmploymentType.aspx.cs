using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_EmploymentType : System.Web.UI.Page
{
    CommonFunctions common;
    string Msg;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();

        }
    }
    private void Initialize()
    {
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }


    private void FillGrid()
    {
        dt = ObjHrBll.ServiceTypeSelect().Tables[0];                           // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.ValueType = txtTypeValue.Text;
        ObjAcaBAL.Description = txtDescription.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.ServiceTypeInsert(ObjAcaBAL);                                   //Employee Insert Information
        common.Clear(this);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);


    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SERV_TYPE_ID=" + ViewState["ID"].ToString());
            if (dr[0]["SERV_TYPE_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtTypeValue.Text = dr[0][1].ToString();
            txtDescription.Text = dr[0][2].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = (e.CommandName == "Deactivate") ? "0" : "1";
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.ServiceTypeModify(ObjAcaBAL);                                            // Employee Status Change In Update Formss
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }

}
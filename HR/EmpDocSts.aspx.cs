using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;



public partial class HR_EmpDocSts : System.Web.UI.Page
{
    CommonFunctions common;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
    String Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        btnSave.Attributes.Add("OnClick", "return validate()"); 
        Initialize();
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

        dt = ObjHrBll.DocumentMasterStatus().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        grdShow.DataSource = dt;
        grdShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.Name = common.GetKeyID(txtEmp);
        ObjAcaBAL.Date = common.GetDateTime(txtDate.Text);
        ObjAcaBAL.ValueType = txtReamrk.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.DocumentMasterStatusInsert(ObjAcaBAL);                                   //Employee Insert Information
        Clear();
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);

    }
    void Clear()
    {
        txtDate.Text = txtEmp.Text = txtReamrk.Text = "";
    }
    protected void grdShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = grdShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("DOC_STS_ID =" + ViewState["ID"].ToString());
            if (dr[0]["DOC_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtEmp.Text = dr[0]["EMP"].ToString();
            txtDate.Text =Convert.ToDateTime(dr[0][1].ToString()).ToString("dd/MM/yyyy");
            txtReamrk.Text = dr[0][2].ToString();

        }
        else
        {
            ObjAcaBAL.ChangeStatus = (e.CommandName == "Deactivate") ? "0" : "1";
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg=ObjHrBll.DocumentMasterStatusModify(ObjAcaBAL);                                               // Employee Status Change In Update Formss           
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
}
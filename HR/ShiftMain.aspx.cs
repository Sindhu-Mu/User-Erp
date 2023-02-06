using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_ShiftMain : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    DataTable dt;
    string Msg;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onClick", "return validation()");
        btnSaveTime.Attributes.Add("onClick", "return Validat()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            TabContainer1.ActiveTabIndex = 0;
            FillShiftGrid();
        }
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ViewState["ID"] = "";
        if (TabContainer1.ActiveTabIndex == 0)
              FillShiftGrid();        
        else
        {              
            fillfunction.Fill(ddlShiftName, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ShiftValue), true, FillFunctions.FirstItem.All);
            FillTimeGrid();
        }
    }
    private void FillShiftGrid()                             // fill grid view with select all record from table
    {
        dt = ObjHrBll.ShiftSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.KeyValue = txtShiftName.Text;
        ObjAcaBAL.InTime = txtInTime.Hour.ToString() + ":" + txtInTime.Minute.ToString() + ":" + txtInTime.Second.ToString();
        ObjAcaBAL.OutTime = txtOutTime.Hour.ToString() + ":" + txtOutTime.Minute.ToString() + ":" + txtOutTime.Second.ToString();
        ObjAcaBAL.ShortName = txtShortName.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.ShiftInsertUpdate(ObjAcaBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        common.Clear(this);
        ViewState["ID"] = "";
        FillShiftGrid();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SHIFT_ID=" + ViewState["ID"].ToString());
            if (dr[0]["SHIFT_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtShiftName.Text = dr[0][1].ToString();
            txtShortName.Text = dr[0][2].ToString();           
        }
        else
        {

            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.ShiftModify(ObjAcaBAL);                                          // Employee Status Change In Update Formss           
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillShiftGrid();
        }
    }

    private void FillTimeGrid()                             // fill grid view with select all record from table
    {
        ObjAcaBAL.TypeId = ddlShiftName.SelectedValue;
        dt = ObjHrBll.ShiftTimeSelect(ObjAcaBAL).Tables[0];
        ViewState["dt"] = dt;
        gvTime.DataSource = dt;
        gvTime.DataBind();
    }

    protected void ddlShiftName_SelectedIndexChanged(object sender, EventArgs e)
    {       
        FillTimeGrid();
    }
    protected void btnSaveTime_Click(object sender, EventArgs e)
    {     
        ObjAcaBAL.TypeId = ddlShiftName.SelectedValue;
        ObjAcaBAL.ShiftMinBefore = txtInBeforeTime.Text;
        ObjAcaBAL.ShiftMinAfter = txtInAfterTime.Text;
        ObjAcaBAL.ShiftMaxBefore = txtOutBeforeTime.Text;
        ObjAcaBAL.ShiftMaxAfter = txtOutAfterTime.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg=ObjHrBll.ShiftTimeInsert(ObjAcaBAL);
        common.Clear(this);
        FillTimeGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);      
      
    }
    protected void gvTime_RowCommand(object sender, GridViewCommandEventArgs e)
    {
         if (e.CommandName != "Select")
        {       
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.ShiftTimeModify(ObjAcaBAL);                                          // Employee Status Change In Update Formss           
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillTimeGrid();
        }

    }
}

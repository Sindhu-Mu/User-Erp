using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_DesignationMain : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    DataTable dt;
    string Msg;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
            fillfunctions.Fill(ddlCatId, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Category), true, FillFunctions.FirstItem.Select);
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
    private void FillGrid() // fill grid view with select all record from table
    {
        ObjHrBAL.KeyID = ddlCatId.SelectedValue;
        dt = ObjHrBll.DesignationSelect(ObjHrBAL).Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)   // Desigantion insert and Update Information
    {

        ObjHrBAL.KeyID = ViewState["ID"].ToString();
        ObjHrBAL.TypeId = ddlCatId.SelectedValue;
        ObjHrBAL.KeyValue = txtDesignationValue.Text;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.DesignationInsertUpdate(ObjHrBAL);
        common.Clear(this);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        ddlCatId.SelectedIndex = 0;
        txtDesignationValue.Text = "";
    }


    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)  // Desigantion Status Change in Update Forms
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("DES_ID=" + ViewState["ID"].ToString());
            if (dr[0]["DES_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlCatId.SelectedValue = dr[0][2].ToString();
            txtDesignationValue.Text = dr[0][3].ToString();
         

        }
        else
        {
            ObjHrBAL.ChangeStatus = e.CommandName;
            ObjHrBAL.KeyID = e.CommandArgument.ToString();
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.DesignationModify(ObjHrBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }



    protected void ddlCatId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
}
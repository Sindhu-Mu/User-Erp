using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class HR_DeptShiftMapp : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    DataTable dt;
    CommonFunctions common;
    HRBLL ObjHrBll;
    string Msg;
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
            FillFunction.Fill(ddlDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlShift, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ShiftWithTime), true, FillFunctions.FirstItem.Select);

        }
    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ObjHrBAL.KeyID = ViewState["ID"].ToString();
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        ObjHrBAL.CommonId = ddlShift.SelectedValue;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.DepatShiftMapInsert(ObjHrBAL);
        common.Clear(this);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);


    }
    public void FillGrid()
    {
        dt = ObjHrBll.DeptShiftMapSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("MAP_ID =" + ViewState["ID"].ToString());
            ddlDept.SelectedValue = dr[0][1].ToString();
            ddlShift.SelectedValue = dr[0][3].ToString();
        }
        else
        {
            ObjHrBAL.ChangeStatus = e.CommandName;
            ObjHrBAL.KeyID = e.CommandArgument.ToString();
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.DeptShiftMapModify(ObjHrBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["dt"] = "";
            FillGrid();
        }
    }
}
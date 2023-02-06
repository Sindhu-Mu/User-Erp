using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_OpeningMain : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlDes, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlQual, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Academic), true, FillFunctions.FirstItem.Select);
            fillGrid();
        }
    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
    }
    void fillGrid()
    {
        gvDetail.DataSource = ObjHrBll.getJobOpening(ObjHrBAL);
        gvDetail.DataBind();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            FillFunction.Fill(ddlDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlDept.Items.Clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBAL.DesignationId = ddlDes.SelectedValue;
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        ObjHrBAL.Total = txtTotal.Text;
        ObjHrBAL.Min = txtMin.Text;
        ObjHrBAL.Max = txtMax.Text;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBAL.KeyID = ddlQual.SelectedValue;
        ObjHrBll.JobOpeningInsert(ObjHrBAL);
        fillGrid();
        clear();
    }

    void clear()
    {
        ddlDept.SelectedIndex = ddlDes.SelectedIndex = ddlIns.SelectedIndex = ddlQual.SelectedIndex = 0;
        txtMax.Text = txtMin.Text = txtTotal.Text = "";
    }
    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBAL.ChangeStatus = "2";
        ObjHrBAL.JobId = e.CommandArgument.ToString();
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        string Msg = ObjHrBll.UpdateJobSts(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        fillGrid();
    }
}
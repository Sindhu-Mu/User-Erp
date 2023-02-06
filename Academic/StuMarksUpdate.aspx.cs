using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_StuMarksUpdate : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("OnClick()", " return validat()");
        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {

            fill.Fill(ddlDept, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.UsrDept, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
        }
    }

    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
        {
            fill.Fill(ddlPgm, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DeptPgm, ddlDept.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            ddlPgm.Items.Clear();
        }
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            fill.Fill(ddlBrnch, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlBrnch.Items.Clear();
    }
    protected void ddlBrnch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBrnch.SelectedIndex > 0)
        {
            bal.DeptId = ddlDept.SelectedValue;
            bal.Pgm_Id = ddlPgm.SelectedValue;
            bal.Brn_Id = ddlBrnch.SelectedValue;
            fill.Fill(ddlFac, bll.GetFacultyByDept(bal).Tables[0], true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlFac_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFac.SelectedIndex > 0)
        {
            bal.DeptId = ddlDept.SelectedValue;
            bal.Pgm_Id = ddlPgm.SelectedValue;
            bal.Brn_Id = ddlBrnch.SelectedValue;
            bal.SessionUserID = ddlFac.SelectedValue;
            fill.Fill(ddlPaper, bll.GetPaperCodeByFaculty(bal).Tables[0], true, FillFunctions.FirstItem.Select);
        }
    }


    protected void ddlPaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaper.SelectedIndex > 0)
        {
            bal.KeyID = ddlPaper.SelectedValue;
            fill.Fill(ddlExam, bll.GetCourseExamType(bal).Tables[0], true, FillFunctions.FirstItem.Select);
        }
    }
    protected void gvDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        bal.Stu_AdmNo = gvDetail.DataKeys[e.RowIndex].Values[2].ToString();
        bal.KeyID = gvDetail.DataKeys[e.RowIndex].Values[0].ToString();
        bal.Id = ddlExam.SelectedValue;
        RadioButtonList rlist = (RadioButtonList)gvDetail.Rows[e.RowIndex].FindControl("rblAtt");
        bal.ChangeStatus = rlist.SelectedValue;
        bal.ChangeStatus = (bal.ChangeStatus == "False") ? "0" : "1";
        TextBox txtMarks = (TextBox)gvDetail.Rows[e.RowIndex].FindControl("txtMarks");
        bal.Marks = txtMarks.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        string msg= bll.UpdateIntMarks(bal);
        gvDetail.EditIndex = -1;
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(" + msg + ")", true);
    }
    protected void gvDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetail.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void gvDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetail.EditIndex = -1;
        FillGrid();
    }
    void FillGrid()
    {
        bal.DeptId = ddlDept.SelectedValue;
        bal.Pgm_Id = ddlPgm.SelectedValue;
        bal.Brn_Id = ddlBrnch.SelectedValue;
        bal.SessionUserID = ddlFac.SelectedValue;
        bal.KeyID = ddlPaper.SelectedValue;
        bal.Id = ddlExam.SelectedValue;
        gvDetail.DataSource = bll.GetIntMarksForUpdate(bal);
        gvDetail.DataBind();
        RadioButtonList rlist;
        foreach (GridViewRow row in gvDetail.Rows)
        {
            rlist = (RadioButtonList)row.FindControl("rblAtt");
            rlist.SelectedValue = gvDetail.DataKeys[row.RowIndex].Values[1].ToString();
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_MajorMarksUpdate : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    QueryFunctions queryFunctions;
    ExamFunctions.QueryFunctions query;
    ExamFunctions.FillFunctions fill;
    DataSet ds;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        query = new ExamFunctions.QueryFunctions();
        fill = new ExamFunctions.FillFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        btnShow.Attributes.Add("OnClick", "return validation()");
        btnUpdate.Attributes.Add("OnClick", "return SaveValidation()");
        Initialize();
       
        if (!IsPostBack)
        {

            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlExam, query.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Examination), true, ExamFunctions.FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPrgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPrgm.Focus();
        }
    }
    protected void ddlPrgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPrgm.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlBranch.Focus();
        }
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBranch.SelectedIndex > 0) && (ddlSem.SelectedIndex > 0))
        {
            fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseByBrnchSem, ddlBranch.SelectedValue, ddlSem.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPaper.Focus();
        }
    }

    void FillGrid()
    {
        
        ObjBal.Pap_Code = ddlPaper.SelectedValue;
        ObjBal.Id = ddlExam.SelectedValue;
        ObjBal.KeyID = ddlAward.SelectedValue;
        ds=ObjBll.GetMajorMarks(ObjBal);
        gvMarks.DataSource = ds.Tables[1];
        gvMarks.DataBind();
        rbWeightage.SelectedValue = ds.Tables[0].Rows[0][0].ToString();
        tdWeigtage.Visible = thWeigtage.Visible = true;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlAward, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AwardId, ddlPaper.SelectedValue, ddlExam.SelectedValue),false,FillFunctions.FirstItem.Select);
        tdWeigtage.Visible = thWeigtage.Visible = false;
        gvMarks.DataSource = "";
        gvMarks.DataBind();
    }
    protected void gvMarks_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvMarks.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void gvMarks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvMarks.EditIndex = -1;
        FillGrid();
    }
    protected void gvMarks_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ObjBal.Id = gvMarks.DataKeys[e.RowIndex].Values[0].ToString();
        ObjBal.KeyID = gvMarks.DataKeys[e.RowIndex].Values[1].ToString();
        TextBox txtEnroll = (TextBox)gvMarks.Rows[e.RowIndex].FindControl("txtEnroll");
        TextBox txtMarks = (TextBox)gvMarks.Rows[e.RowIndex].FindControl("txtMarks");
        ObjBal.Enroll_No = txtEnroll.Text;
        ObjBal.Marks = txtMarks.Text;
        ObjBal.KeyValue = rbWeightage.SelectedValue;
        ObjBal.TypeId = "1";
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBll.MajorMarksUpdate(ObjBal);
        gvMarks.EditIndex = -1;
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Marks updated successfully')", true);
    }
    protected void ddlAward_SelectedIndexChanged(object sender, EventArgs e)
    {
       
        FillGrid();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ddlAward.SelectedValue;
        ObjBal.KeyID = "0";
        ObjBal.Enroll_No = "0";
        ObjBal.Marks = "0";
        ObjBal.KeyValue = rbWeightage.SelectedValue;
        ObjBal.TypeId = "0";
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBll.MajorMarksUpdate(ObjBal);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Weightage updated successfully')", true);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Examination_MinorExamInvigilation : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    DataSet ds;
    DataTable dt;
    string Msg;
    ExaminationBal Objbal;
    ExaminationBll Objbll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        //btnSave.Attributes.Add("OnClick", "return validation();");
        if (!IsPostBack)
        {
            ViewState["Id"] = "";
            ViewState["dt"] = dt;
            FillFunction.Fill(ddlMinorExam, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MinorExam), true, FillFunctions.FirstItem.Select);
            GridStudent1.Visible = true;
            GridStudent2.Visible = false;


        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        Objbal = new ExaminationBal();
        Objbll = new ExaminationBll();
        ds = new DataSet();
    }
    protected void ddlMinorExam_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMinorExam.SelectedIndex > 0)
        {
            GridStudent1.Visible = true;
            GridStudent2.Visible = false;
            lblDatetime.Text = lnkStarted.Text = lnkUploaded.Text = lnkTotal.Text = "";
            FillFunction.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.FacultyCourse, ddlMinorExam.SelectedValue, Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);
        }


    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
        {
            Objbal.KeyID = ddlCourse.SelectedValue;
            Objbal.ExamId = ddlMinorExam.SelectedValue;
            Objbal.SessionUserID = Session["UserId"].ToString();
            dt = Objbll.GetMinorOnlinePaperWiseCount(Objbal).Tables[0];
            if (dt.Rows.Count > 0)
            {

                lblDatetime.Text = dt.Rows[0][0].ToString();
                lnkStarted.Text = dt.Rows[0][1].ToString();
                lnkUploaded.Text = dt.Rows[0][2].ToString();
                lnkTotal.Text = dt.Rows[0][3].ToString();
            }
        }
        else
        {
            lblDatetime.Text = lnkStarted.Text = lnkUploaded.Text = lnkTotal.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Course not scheduled for select examination.')", true);
        }

    }

    protected void lnkTotal_Click(object sender, EventArgs e)
    {
        GridStudent1.Visible = true;
        GridStudent2.Visible=GridStudent3.Visible = false;
        Objbal.KeyID = ddlCourse.SelectedValue;
        Objbal.ExamId = ddlMinorExam.SelectedValue;
        Objbal.SessionUserID = Session["UserId"].ToString();
        GridStudent1.DataSource = Objbll.GetMinorOnlinePaperStudentDetail(Objbal).Tables[0];
        GridStudent1.DataBind();


    }
    void FillGrid()
    {
        
        Objbal.KeyID = ddlCourse.SelectedValue;
        Objbal.KeyValue = HiddenField1.Value;
        Objbal.ExamId = ddlMinorExam.SelectedValue;
        Objbal.SessionUserID = Session["UserId"].ToString();
        ds = Objbll.GetMinorOnlineExamStudent(Objbal);
        GridStudent2.DataSource = ds.Tables[0];
        GridStudent2.DataBind();
        GridStudent3.DataSource = ds.Tables[1];
        GridStudent3.DataBind();

    }

    protected void lnkStarted_Click(object sender, EventArgs e)
    {
        GridStudent1.Visible = GridStudent3.Visible = false;
        GridStudent2.Visible = true;
        HiddenField1.Value = "1";
        FillGrid();


    }
    protected void lnkUploaded_Click(object sender, EventArgs e)
    {
        GridStudent1.Visible = GridStudent2.Visible = false;
        GridStudent3.Visible = true;
        HiddenField1.Value = "2";
        FillGrid();

    }
    protected void GridStudent2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Objbal.ChangeStatus = "0";
        Objbal.KeyID = GridStudent2.DataKeys[e.RowIndex].Value.ToString();
        Objbal.SessionUserID = Session["UserId"].ToString();
        Msg = Objbll.MinorOnlineStudentStatus(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
    }
    protected void GridStudent3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Objbal.ChangeStatus = "1";
        Objbal.KeyID = GridStudent3.DataKeys[e.RowIndex].Value.ToString();
        Objbal.SessionUserID = Session["UserId"].ToString();
        Msg = Objbll.MinorOnlineStudentStatus(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();

    }
}
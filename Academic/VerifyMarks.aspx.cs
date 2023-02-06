using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class Academic_VerifyMarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    ExamFunctions.QueryFunctions ExamQueryFnctn;
    ExamFunctions.FillFunctions ExamFillFunctn;
    DataSet ds;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("onClick", "return validateType()");
        btnVerify.Attributes.Add("onClick", "return VerifyMarks()");
        if (!IsPostBack)
        {
            tdVerify.Visible = false;
            fillFunctions.Fill(ddlIns,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution),true,FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            ExamFillFunctn.Fill(ddlExam, ExamQueryFnctn.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Exam), true, ExamFunctions.FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlPaperType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Paper_type), true, FillFunctions.FirstItem.Select);
            ddlType.SelectedValue = "1";
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
        ExamQueryFnctn = new ExamFunctions.QueryFunctions();
        ExamFillFunctn = new ExamFunctions.FillFunctions();
        ds = new DataSet();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlPaperType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaperType.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PaperByBrnchSem, ddlBranch.SelectedValue, ddlSem.SelectedValue, ddlPaperType.SelectedValue), true, FillFunctions.FirstItem.Select);
            gvStudent.DataSource = "";
            gvStudent.DataBind();
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        gvStudent.DataSource = "";
        gvStudent.DataBind();

        if (ddlType.SelectedValue == "1")
        {
            AcaBal.Brn_Id = ddlBranch.SelectedValue;
            AcaBal.Semid = ddlSem.SelectedValue;
            AcaBal.Id = ddlPaper.SelectedValue;
            ds = AcaBll.GetStuMarksDetail(AcaBal);
            if (ds.Tables[1].Rows.Count > 0)
                gvStudent.DataSource = ds.Tables[1];
            gvStudent.DataBind();
            tdVerify.Visible = (gvStudent.Rows.Count > 0);
            tblUpdate.Visible = false;
        }
        else
        {
            AcaBal.Id = ddlPaper.SelectedValue;
            ds = AcaBll.GetVerifiedMarks(AcaBal);
            gvEdit.DataSource = ds.Tables[0];
            gvEdit.DataBind();
            btnUpdate.Visible = (ds.Tables[0].Rows.Count > 0);
            tblVerify.Visible = false;
        }
    }
    void clear()
    {
         ddlPaper.SelectedIndex = 0;
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();

        data.AppendFormat("<STUDENT>");
        foreach(GridViewRow row in gvStudent.Rows)
        {
                data.AppendFormat("<MARKS ENROLLMENT_NO=\"" + gvStudent.DataKeys[row.RowIndex].Values[0].ToString() + "\" INTERNAL_MARKS= \"" + gvStudent.DataKeys[row.RowIndex].Values[1].ToString() +
                      "\" MAJOR_MARKS= \"" + gvStudent.DataKeys[row.RowIndex].Values[2].ToString() + "\"  />");
           
        }
        data.AppendFormat("</STUDENT>");
        AcaBal.XmlValue = data.ToString();
        AcaBal.KeyID = ddlPaper.SelectedValue;
        AcaBal.TypeId = ddlVerifyType.SelectedValue;
        AcaBal.SessionUserID = Session["UserId"].ToString();
        string Msg = AcaBll.VerifyStuMarks(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        gvStudent.DataSource = "";
        gvStudent.DataBind();
        ddlPaper.SelectedIndex = 0;
        ddlPaper.Focus();
        clear();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
        TextBox txtIntMarks;
        TextBox txtMajorMarks;
        data.AppendFormat("<STUDENT>");
        foreach (GridViewRow row in gvEdit.Rows)
        {
            txtMajorMarks = (TextBox)row.FindControl("txtMajorMarks");
            txtIntMarks = (TextBox)row.FindControl("txtIntMarks");

            data.AppendFormat("<MARKS ENROLLMENT_NO=\"" + gvEdit.DataKeys[row.RowIndex].Values[0].ToString() + "\" INTERNAL_MARKS= \"" + txtIntMarks.Text + "\"  MAJOR_MARKS= \"" + txtMajorMarks.Text + "\"/>");
        }
        data.AppendFormat("</STUDENT>");
        AcaBal.XmlValue = data.ToString();
        AcaBal.KeyID = ddlPaper.SelectedValue;
        AcaBal.TypeId = ddlVerifyType.SelectedValue;
        AcaBal.SessionUserID = Session["UserId"].ToString();
        string Msg = AcaBll.VerifyStuMarks(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        gvEdit.DataSource = "";
        gvEdit.DataBind();
        clear();
    }
}
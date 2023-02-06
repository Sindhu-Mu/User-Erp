using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_DetainedRegisteredList : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataSet ds;
    string Msg;
    ExamFunctions.FillFunctions examFillFunctions;
    ExamFunctions.QueryFunctions ExamQueryFunctions;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        ds = new DataSet();
        ExamQueryFunctions = new ExamFunctions.QueryFunctions();
        examFillFunctions = new ExamFunctions.FillFunctions();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();

        if (!IsPostBack)
        {
            btnSubmit.Attributes.Add("OnClick", "return validation()");
            examFillFunctions.Fill(ddlExamination, ExamQueryFunctions.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Examination), true, ExamFunctions.FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            gvDetained.Visible = false;
            btnSubmit.Visible = false;
            btnPrint.Visible = false;
            FillData();
        }
    }
    void FillData()
    {
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ds = ObjBll.GetAllDetainPaperMarksList(ObjBal);
        GvDetainPaper.DataSource = ds.Tables[0];
        GvDetainPaper.DataBind();
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlProgram, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProgram.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlProgram.SelectedValue), true, FillFunctions.FirstItem.Select);

        }
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = ddlBranch.SelectedValue;
        if (ddlBranch.SelectedIndex > 0)
        {

            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SemByBranch, ddlBranch.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlDetained_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvDetained.Visible = true;
        btnSubmit.Visible = true;
        ObjBal.EXAMID = ddlExamination.SelectedValue;
        ObjBal.Pap_Code = ddlDetained.SelectedValue;
        ds = ObjBll.GetDetainedStudentInfo(ObjBal);
        ViewState["myTable"] = ds;
        gvDetained.DataSource = ds.Tables[0];
        gvDetained.DataBind();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
        TextBox txtminor1;
        TextBox txtminor2;
        TextBox txtClassPerfo;
        TextBox txtTotlAttend;
        TextBox txtAttended;
        TextBox txtAttMarks;
        CheckBox chkSelect;
        data.AppendFormat("<INTERNAL>");
        foreach (GridViewRow row in gvDetained.Rows)
        {
            txtminor1 = (TextBox)row.FindControl("txtminor1");
            txtminor2 = (TextBox)row.FindControl("txtminor2");
            txtClassPerfo = (TextBox)row.FindControl("txtClassPerfo");
            txtTotlAttend = (TextBox)row.FindControl("txtTotlAttend");
            txtAttended = (TextBox)row.FindControl("txtAttended");
            txtAttMarks = (TextBox)row.FindControl("txtAttMarks");
            chkSelect = (CheckBox)row.FindControl("chkSelect");

            if (chkSelect.Checked)
            {
                data.AppendFormat("<MARKS  STU_MAIN_ID= \"" + gvDetained.DataKeys[row.RowIndex].Values[0].ToString() +
                        "\" CRS_EXAM_ID= \"" + gvDetained.DataKeys[row.RowIndex].Values[1].ToString() + "\" MINOR1= \"" + txtminor1.Text + "\"  MINOR2= \"" + txtminor2.Text + "\"  CLASS_PERFORM= \"" + txtClassPerfo.Text + "\"  TOTAL_ATTENDANCE= \"" + txtTotlAttend.Text + "\"  CLASS_ATTENDED= \"" + txtAttended.Text + "\" ATT_MARKS= \"" + txtAttended.Text + "\"/>");
            }
        }
        data.AppendFormat("</INTERNAL>");
        ObjBal.XmlValue = data.ToString();
        ObjBal.KeyID = ddlExamination.SelectedValue;
        ObjBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjBll.DetainedMarksInsert(ObjBal);
        if (Msg.Contains("successfully"))
        {
            FillData();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        gvDetained.DataSource = "";
        gvDetained.DataBind();
        btnPrint.Visible = true;
    }

    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlBranch.SelectedIndex > 0 && ddlSem.SelectedIndex > 0 && ddlExamination.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDetained, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DetainedPaperCode, ddlBranch.SelectedValue, ddlSem.SelectedValue,ddlExamination.SelectedValue), true, FillFunctions.FirstItem.Select);

        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('PrtDetainedMarksList.aspx?" + ddlDetained.SelectedValue + "&b=" + ddlExamination.SelectedValue + "','_blank','alwaysRaised')", true);
    }
}
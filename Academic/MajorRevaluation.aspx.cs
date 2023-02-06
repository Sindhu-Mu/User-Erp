using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;
using System.Text;
public partial class Academic_MajorRevaluation : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    string msg;
    DataSet ds;
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("OnClick", "return validation()");
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlExam, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Examination), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        }

    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        ds = new DataSet();
    }
    void Clear()
    {
        ddlBranch.Enabled = true;
        txtExaminor.Text = "";
        ddlPaper.SelectedIndex = 0;
        gvDetail.DataSource = "";
        gvDetail.DataBind();
        ddlPaper.Focus();
        DivSave.Visible = false;
        TextBox1.Text = "";
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPrgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPrgm.Focus();
        }
        else
            ddlPrgm.Items.Clear();

    }
    protected void ddlPrgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPrgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPrgm.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlBranch.Focus();
        }
        else
            ddlBranch.Items.Clear();
    }
    protected void ddlSem_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlBranch.SelectedIndex > 0) && (ddlSem.SelectedIndex > 0))
        {
            fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CourseByBrnchSem, ddlBranch.SelectedValue, ddlSem.SelectedValue, ddlExam.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlPaper.Focus();
        }
        else
        {
            ddlPaper.Items.Clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        StringBuilder data = new StringBuilder();
        data.AppendFormat("<Major>");
        foreach (GridViewRow row in gvDetail.Rows)
        {
            TextBox txtMarks = (TextBox)row.FindControl("txtMarks");
            if (txtMarks.Text != "")
                data.AppendFormat("<Revaluate MEM_ID=\"" + gvDetail.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_MAIN_ID= \"" + gvDetail.DataKeys[row.RowIndex].Values[1].ToString() +
                    "\" EVA_SCH_SUB_ID= \"" + gvDetail.DataKeys[row.RowIndex].Values[2].ToString() + "\" REVALUATE_MARKS= \"" + txtMarks.Text + "\" />");
        }
        data.AppendFormat("</Major>");
        if (data.ToString().Contains("Revaluate"))
        {
            ObjBal.XmlValue = data.ToString();
            ObjBal.KeyID = ddlExam.SelectedValue;
            ObjBal.Id = commonFunctions.GetKeyID(txtExaminor);
            ObjBal.SessionUserID = Session["UserId"].ToString();
            msg = ObjBll.MajorMarksRevaluateInsert(ObjBal);
            gvDetail.Visible = false;
            lblMsg.Text = msg;
            Clear();
        }
        else
        {             
            lblMsg.Text = "Add Student Marks";
            return;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        ObjBal.Id = ddlExam.SelectedValue;
        ObjBal.Pap_Code = ddlPaper.SelectedValue;
        dt = ObjBll.GetMajorMarksForRevaluation(ObjBal).Tables[0];
        ViewState["dt"] = dt;
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
        gvDetail.Visible = true;
        DivSave.Visible = (gvDetail.Rows.Count > 0);

    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.IO;

public partial class Academic_SemesterUpgrade : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    Messages Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("OnClick", "return validate();");
        btnAction.Attributes.Add("OnClick", "return validation();");
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        Msg = new Messages();
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);

    }
    void Clear()
    {
        //commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBatch, ddlSemester);
        commonFunctions.Clear(GridStudent);
        DivAction.Visible = false;
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlCourse, ddlBranch2, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }
    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBranch.SelectedIndex > 0)
        {
            ddlBranch2.SelectedValue = ddlBranch.SelectedValue;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        objBal.Brn_Id = ddlBranch.SelectedValue;
        objBal.Id = ddlBatch.SelectedValue;
        objBal.Semid = ddlSemester.SelectedValue;
        GridStudent.DataSource = objBll.GetStudentListForSemesterUpgrade(objBal);
        GridStudent.DataBind();
        lblTotal.Text = GridStudent.Rows.Count.ToString();
        DivAction.Visible = (GridStudent.Rows.Count > 0);
    }
    protected void btnAction_Click(object sender, EventArgs e)
    {
        int z = 0;
        StringBuilder data = new StringBuilder();
        CheckBox ChkBox;
        data.AppendFormat("<UPGRADE>");
        foreach (GridViewRow row in GridStudent.Rows)
        {
            ChkBox = (CheckBox)row.FindControl("ChkBox");
            if (ChkBox.Checked)
            {
                z = 1;
                data.AppendFormat("<STUDENT STU_MAIN_ID=\"" + GridStudent.DataKeys[row.RowIndex].Value.ToString() + "\" PGM_BRN_ID=\"" + ddlBranch2.SelectedValue + "\"/>");
            }
        }
        if (z == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select at least one student from table.')", true);
        }
        data.AppendFormat("</UPGRADE>");
        objBal.XmlValue = data.ToString();
        objBal.KeyID = ddlBranch2.SelectedValue;
        objBal.ChangeStatus = ddlAction.SelectedValue;
        objBal.SessionUserID = Session["UserId"].ToString();
        string Msg = objBll.StudnetUpgradeAction(objBal);
        if (Msg.Contains("successfully"))
        {
            Clear();
            ddlBatch.Focus();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
   
}
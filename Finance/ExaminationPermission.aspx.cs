using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class StudentFinance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();

        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            glb_ff.Fill(ddlIns, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            glb_ff.Fill(ddlPgm, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            glb_ff.Fill(ddlBranch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
            glb_ff.Fill(ddlSem, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);

        }


    }
    void LoadData()
    {
        //  glb_ff.Fill(ddlSem, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        //  glb_ff.Fill(ddlExamSem, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnrollment.Text);
        balObj.balCommonID = txtEnrollment.Text;
        balObj.balType = ddlExamType.SelectedValue;
        gridDue.DataSource = bllObj.StudentFeeDueSelect(balObj);
        gridDue.DataBind();
        divPanelDue.Visible = true;

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        balObj.balEnrollment = gridDue.DataKeys[0].Value.ToString();
        balObj.balRemark = txtRemark.Text;
        balObj.balReason = ddlPermissionType.SelectedValue;
        balObj.balCurUser = Session["UserId"].ToString();
        try
        {
            bllObj.StudentDueSubInsert(balObj);
            cf.showAlert(this, "Inserted Successfully!!");
        }
        catch
        {
            cf.showAlert(this, "Error Encountered!!");
        }

    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 1)
        {
            glb_ff.Fill(ddlIns, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            glb_ff.Fill(ddlPgm, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            glb_ff.Fill(ddlBranch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
            glb_ff.Fill(ddlSem, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);

        }
    }

    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        glb_ff.Fill(ddlPgm, glb_qf.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        glb_ff.Fill(ddlBranch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        balObj.balInsId = ddlIns.SelectedValue;
        balObj.balPgmId = ddlPgm.SelectedValue;
        balObj.balBranchId = ddlBranch.SelectedValue;
        balObj.balSem = ddlSem.SelectedValue;
        balObj.balType = ddlexamtypes.SelectedValue;
        balObj.balStatus = ddlSts.SelectedValue;
        dt = bllObj.GetPermission(balObj).Tables[0];
        gvFeeReport.DataSource = dt;
        gvFeeReport.DataBind();

    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("ExamPermissionDetail.xls", gvFeeReport);
    }
}
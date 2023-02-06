using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Academic_StudentAttendanceCredit : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    string msg;
    string str;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            TabContainer1.ActiveTabIndex = 0;
            txtEnroll.Focus();
            txtApprovedDT.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillData();
        }
    }

    void FillData()
    {
        fillFunctions.Fill(ddlReason, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CreditType), true, FillFunctions.FirstItem.Select);
        AcaBal.InsId = Session["InsID"].ToString();
        fillFunctions.Fill(ddlApproved, AcaBll.GetApprovalAuthority(AcaBal), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlApp, AcaBll.GetApprovalAuthority(AcaBal), true, FillFunctions.FirstItem.All);
        ListItem l1 = new ListItem();
        l1.Text = "REGISTRAR";
        l1.Value = "1517";
        ddlApproved.Items.Add(l1);
        ddlApp.Items.Add(l1);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        AcaBal.TypeId = ddlReason.SelectedValue;
        AcaBal.KeyID = commonFunctions.GetKeyID(txtEnroll);
        AcaBal.EmpId = ddlApproved.SelectedValue;
        AcaBal.Date = commonFunctions.GetDateTime(txtApprovedDT.Text);
        AcaBal.FromDate = commonFunctions.GetDateTime(txtFromDT.Text);
        AcaBal.ToDate = commonFunctions.GetDateTime(txtToDT.Text);
        AcaBal.Description = txtRemark.Text;
        AcaBal.SessionUserID = Session["UserId"].ToString();

        msg = AcaBll.SaveStudentAttendanceCredit(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        BindGridData(AcaBal.KeyID);
    }
    protected void gvDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AcaBal.Id = gvDetail.DataKeys[e.RowIndex].Values[0].ToString();
        AcaBll.DeleteStudentAttendanceCredit(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Record deleted successfully.')", true);
        BindGridData(gvDetail.DataKeys[e.RowIndex].Values[1].ToString());
    }

    void BindGridData(string Enroll)
    {
        AcaBal.KeyID = Enroll;
        fillFunctions.Fill(gvDetail, AcaBll.StudentAttendenceCreditDetail(AcaBal).Tables[0]);
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 1)
        {
            AcaBal.SessionUserID = Session["UserId"].ToString();
            fillFunctions.Fill(ddlBatch2, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlReason2, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CreditType), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlStudent, AcaBll.GetStudentForCreditDetail(AcaBal), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        SqlCommand cmd = new SqlCommand();
        str = "SELECT StuView.ENROLLMENT_NO, StuView.STU_FULL_NAME, CREDIT_TYPE_INF.CREDIT_NAME, CONVERT(VARCHAR,STU_ATT_CREDIT_INF.CR_FROM,103)+' TO '+CONVERT(VARCHAR, STU_ATT_CREDIT_INF.CR_TO, 103) AS 'DURATION', "
           + "EMP_VIEW.DES_VALUE+'('+EMP_VIEW.EMP_NAME+')' AS 'EMP_NAME', STU_ATT_CREDIT_INF.APPROVED_DT FROM STU_ATT_CREDIT_INF INNER JOIN "
           + "StuView ON STU_ATT_CREDIT_INF.STU_MAIN_ID = StuView.STU_MAIN_ID INNER JOIN CREDIT_TYPE_INF ON STU_ATT_CREDIT_INF.CR_TYPE_ID = CREDIT_TYPE_INF.CR_TYPE_ID INNER JOIN "
           + "EMP_VIEW ON STU_ATT_CREDIT_INF.APPROVED_BY = EMP_VIEW.EMP_ID WHERE CR_STATUS=1 AND CR_BY= " + Session["UserId"].ToString();
        if (ddlBatch2.SelectedIndex > 0)
            str += " AND StuView.ACA_BATCH_ID=" + ddlBatch2.SelectedValue;
        if (ddlReason2.SelectedIndex > 0)
            str += " AND STU_ATT_CREDIT_INF.CR_TYPE_ID=" + ddlReason2.SelectedValue;
        if (ddlStudent.SelectedIndex > 0)
            str += " AND StuView.STU_MAIN_ID=" + ddlStudent.SelectedValue;
        if (ddlApp.SelectedIndex > 0)
            str += " AND STU_ATT_CREDIT_INF.APPROVED_BY=" + ddlApp.SelectedValue;
        if ((txtFrom.Text != "") && (txtTo.Text != ""))
            str += " AND CR_FROM BETWEEN '" + txtFrom.Text + "' AND '" + commonFunctions.GetDateTime(txtTo.Text) + "' AND CR_TO BETWEEN '" + txtFrom.Text + "' AND '" + commonFunctions.GetDateTime(txtTo.Text) + "'";            

        str += " ORDER BY STU_ATT_CREDIT_INF.APPROVED_DT DESC";

        cmd.CommandText = str;
        fillFunctions.Fill(gvShow, cmd);
    }
}
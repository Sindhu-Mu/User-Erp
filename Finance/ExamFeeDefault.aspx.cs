using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Finance_ExamFeeDefault : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataTable Dt;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("onClick", "return Validate()");
        if (!IsPostBack)
        {           
            tabcontainer1.ActiveTabIndex = 0;
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        Dt = new DataTable();
    }
    protected void tabcontainer1_ActiveTabChanged(object sender, EventArgs e)
    {

        if (tabcontainer1.ActiveTabIndex == 1)
        {
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
            txtToDt.Text=txtFromDt.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblAmt.Text = "";
        if (txtEnroll.Text != "")
        {
            Student.ShowStudent(txtEnroll.Text);
            ObjAcaBal.Stu_AdmNo = txtEnroll.Text;
            Dt = ObjAcaBll.GetFeeDefaulter(ObjAcaBal).Tables[0];
            if (Dt.Rows.Count > 0)
            {
                lblAmt.Text = "Rs." + Dt.Rows[0][2].ToString();
                trClear.Visible = true;
            }
            else
            {
               
                lblAmt.Text = "No Due Amount";

            }
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        ObjAcaBal.Description = txtRemark.Text;
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        ObjAcaBal.Stu_AdmNo =txtEnroll.Text;
        Msg = ObjAcaBll.UpdateFeeDefaulter(ObjAcaBal);
        lblAmt.Text = Msg;        
        clear();
    }
    void clear()
    {
        Student.ShowStudent("123");
        txtEnroll.Text = txtRemark.Text = "";        
        txtEnroll.Focus();  

    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjAcaBal.InsId = ddlIns.SelectedValue;
        ObjAcaBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjAcaBal.Brn_Id = ddlBranch.SelectedValue;
        ObjAcaBal.Semid = ddlSem.SelectedValue;
        ObjAcaBal.ChangeStatus = ddlSts.SelectedValue;
        ObjAcaBal.Max_Dt = txtFromDt.Text;
        ObjAcaBal.Value = txtToDt.Text;
        Dt = ObjAcaBll.GetDefaulterDetail(ObjAcaBal).Tables[0];
        gvFeeReport.DataSource = Dt;
        gvFeeReport.DataBind();
        if (ddlSts.SelectedValue == "1")
        {
            gvFeeReport.Columns[5].Visible = false;
            gvFeeReport.Columns[6].Visible = false;
            gvFeeReport.Columns[7].Visible = false;
        }
        else
        {
            gvFeeReport.Columns[5].Visible = true;
            gvFeeReport.Columns[6].Visible = true;
            gvFeeReport.Columns[7].Visible = true;
        }
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("FeeDefaulterDetail.xls", gvFeeReport);

    }
}
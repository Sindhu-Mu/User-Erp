using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Finance_reportFeeInfohod : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    SFBAL ObjBal;
    SFBLL ObjBll;
    DataTable dt;
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
        ObjBal = new SFBAL();
        ObjBll = new SFBLL();
        dt = new DataTable();
    }
    protected void tabcontainer1_ActiveTabChanged(object sender, EventArgs e)
    {

        if (tabcontainer1.ActiveTabIndex == 0)
        {
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
         
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblAmt.Text = "";
        if (txtEnroll.Text != "")
        {
            Student.ShowStudent(txtEnroll.Text);
            ObjBal.balEnrollment = txtEnroll.Text;
            dt = ObjBll.GetStudentFeeReport(ObjBal).Tables[0];
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
                for(int i=0; i<dt.Rows.Count;i++)
                lblAmt.Text = "Rs." + dt.Rows[0]["FEE_DEMAND_AMT"].ToString();
                
            }
            else
            {

                lblAmt.Text = "No Due Amount";

            }
        }
    }
   
    void clear()
    {
        Student.ShowStudent("123");
        txtEnroll.Text ="";
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
        ObjBal.balInsId = ddlIns.SelectedValue;
        ObjBal.balPgmId = ddlPgm.SelectedValue;
        ObjBal.balBranch = ddlBranch.SelectedValue;
        ObjBal.balSem = ddlSem.SelectedValue;
        ObjBal.balStatus = ddlSts.SelectedValue;       
        dt = ObjBll.GetFeeInfromationforHOD(ObjBal).Tables[0];
        gvFeeReport.DataSource = dt;
        gvFeeReport.DataBind();
        BtnExport.Visible = (gvFeeReport.Rows.Count > 0);

        if (ddlSts.SelectedValue == "1")
        {
          
            gvFeeReport.Columns[6].Visible = false;
            gvFeeReport.Columns[7].Visible = false;
        }
        else
        {
           
            gvFeeReport.Columns[6].Visible = true;
            gvFeeReport.Columns[7].Visible = true;
        }
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("FeeDefaulterDetail.xls", gvFeeReport);

    }
    
}
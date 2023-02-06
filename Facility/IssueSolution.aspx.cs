using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Facility_IssueSolution : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    FacBAL ObjfacBal;
    FacBLL ObjfacBll;
    DataTable Dt;
    string Msg;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            txtFrmDt.Enabled = false;
            txtEndDt.Enabled = false;
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IssueDeptByUser, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlComplex, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Complex), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSts, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IssueSts), true, FillFunctions.FirstItem.All);
            ddlSts.SelectedIndex = 2;
            fillFunctions.Fill(ddlComplain, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IssueSubHead, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
            FillGrid();
            //GetDetail();
        }
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
        ObjfacBal = new FacBAL();
        ds = new DataSet();
        ObjfacBll = new FacBLL();
        Dt = new DataTable();
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlPostDt":
                if (ddlPostDt.SelectedValue == "0")
                {
                    txtFrmDt.Enabled = false;
                    txtEndDt.Enabled = false;
                }
                if (ddlPostDt.SelectedValue == "4")
                {
                    txtFrmDt.Enabled = true;
                    txtEndDt.Enabled = true;
                }
                else if (ddlPostDt.SelectedValue == "1" || ddlPostDt.SelectedValue == "2" || ddlPostDt.SelectedValue == "3")
                {
                    txtFrmDt.Enabled = true;
                    txtEndDt.Enabled = false;
                }
                else
                {
                    txtFrmDt.Enabled = false;
                    txtEndDt.Enabled = false;
                }
                txtFrmDt.Text = txtEndDt.Text = "";
                break;
            default:
                break;
        }

    }
    void FillGrid()
    {

        ObjfacBal.DeptId = ddlDepartment.SelectedValue;
        ObjfacBal.CommonId = ddlComplex.SelectedValue;
        ObjfacBal.TypeId = (txtPostedBy.Text.Contains(':')) ? txtPostedBy.Text.Split(':').GetValue(1).ToString() : "0";
        ObjfacBal.No = txtToken.Text;
        ObjfacBal.Status = ddlSts.SelectedValue;
        ObjfacBal.Id = ddlComplain.SelectedValue;
        ObjfacBal.Value = ddlPostDt.SelectedValue;
        ObjfacBal.frdt = txtFrmDt.Text;
        ObjfacBal.todt = txtEndDt.Text;
        ObjfacBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjfacBll.IssueSolutionSelect(ObjfacBal).Tables[0];
        Session["dt"] = dt;
        gvIssueDetail.DataSource = dt;
        gvIssueDetail.DataBind();
        //foreach (GridViewRow itm in gvIssueDetail.Rows)
        //{
        //    if (gvIssueDetail.DataKeys[itm.RowIndex].Values[1].ToString() == "2")
        //        itm.Font.Bold = true;
        //    else
        // itm.Font.Bold = false;
        //    if (gvIssueDetail.DataKeys[itm.RowIndex].Values[1].ToString() == "5")
        //        itm.ForeColor = System.Drawing.Color.Green;

        //}

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void gvIssueDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('popIssue.aspx?=" + e.CommandArgument.ToString() + "','_blank','width=650px,height=600px')", true);


    }
    protected void btnExport_Click(object sender, EventArgs e)
    {

        gvIssueDetail.Columns[7].Visible = false;
        GridViewExportUtil.Export("IssueTracking.xls", gvIssueDetail);
        gvIssueDetail.Columns[7].Visible = true;

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtIssueDetail.aspx','_blank','alwaysRaised')", true);
    }
}
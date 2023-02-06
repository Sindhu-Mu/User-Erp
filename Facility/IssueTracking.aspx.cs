using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Facility_IssueTracking : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable dt;
    string Msg;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        TabCont1.ActiveTabIndex = 0;
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlCmplx, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.CmplxName), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlIssueRelated, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpIssueCat), true, FillFunctions.FirstItem.Select);
            FillRepetar();
            ViewState["ID"] = "";
            GetDetail();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
        ds = new DataSet();
    }
    protected void ddlIssueRelated_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlIssueAbout, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpIssueAbut, ddlIssueRelated.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlIssueAbout_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlIssueDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpIssueDept, ddlIssueAbout.SelectedValue), true, FillFunctions.FirstItem.Select);
        ddlIssueDept.SelectedIndex = 1;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        if (ObjFacBal.KeyID == "")
        {
            ObjFacBal.PickUpLocation = txtLocation.Text;
            ObjFacBal.cmpxId = ddlCmplx.SelectedValue;
            ObjFacBal.Description = txtIssueDetail.Text;
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            ObjFacBal.Status = "2";
            ObjFacBal.DeptId = ddlIssueDept.SelectedValue;
            ObjFacBal.Id = ddlIssueAbout.SelectedValue;
        }
        else
        {
            ObjFacBal.PickUpLocation = txtLocation.Text;
            ObjFacBal.cmpxId = ddlCmplx.SelectedValue;
            ObjFacBal.Description = txtIssueDetail.Text;
            ObjFacBal.DeptId = ddlIssueDept.SelectedValue;
            ObjFacBal.Id = ddlIssueAbout.SelectedValue;
        }
        string Token =  ObjFacBll.EmpIssueInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Your Complain lodged successfully.Please keep your token no : #" + Token + " carefully for future reference')", true);
        clear();
        FillRepetar();
    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlCmplx);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlIssueAbout);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlIssueDept);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlIssueRelated);
        txtIssueDetail.Text = "";
        txtLocation.Text = "";
    }
    void FillRepetar()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjFacBll.EmpIssueSelect(ObjFacBal).Tables[0];
        ViewState["dt"] = dt;
        RepIssueDetail.DataSource = ViewState["dt"];
        RepIssueDetail.DataBind();
    }
    protected void RepIssueDetail_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        dt = (DataTable)ViewState["dt"];
        ViewState["ID"] = e.CommandArgument.ToString();
        DataRow[] dr = dt.Select("ISSUE_ID='" + ViewState["ID"] + "'");
        if (e.CommandName == "View")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptIssueDetail.aspx?=" + e.CommandArgument.ToString() + "','_blank','width=700, height=500, top=100, left=200')", true);

        else if (e.CommandName == "Edit")
        {
            if (dr[0]["ISSUE_STS"].ToString() == "2")
            {
                TabCont1.ActiveTabIndex = 0;
                ddlCmplx.SelectedValue = dr[0]["ISSUE_CMPLX"].ToString();
                txtLocation.Text = dr[0]["ISSUE_LOCATION"].ToString();
                ddlIssueRelated.SelectedValue = dr[0]["HEAD_ID"].ToString();
                FillFunction.Fill(ddlIssueAbout, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpIssueAbut, ddlIssueRelated.SelectedValue), true, FillFunctions.FirstItem.Select);
                ddlIssueAbout.SelectedValue = dr[0]["SUB_HEAD_ID"].ToString();
                FillFunction.Fill(ddlIssueDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpIssueDept, ddlIssueAbout.SelectedValue), true, FillFunctions.FirstItem.Select);
                ddlIssueDept.SelectedValue = dr[0]["DEPT_ID"].ToString();
                txtIssueDetail.Text = dr[0]["ISSUE_DETAIL"].ToString();
                clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Unable to Edit the token. The token has been viewed and is considered for providing solution.')", true);
                return;

            }
        }
        else if (e.CommandName == "Delete")
        {
            if (dr[0]["ISSUE_STS"].ToString() != "5")
            {
                TabCont1.ActiveTabIndex = 0;
                ObjFacBal.KeyID = ViewState["ID"].ToString();
                ObjFacBal.SessionUserID = Session["UserId"].ToString();
                Msg = ObjFacBll.IssueDelete(ObjFacBal);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
                FillRepetar();
                clear();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "clientScript", "alert('Unable to delete the ticket. The ticket has been viewed and is considered for providing solution.')", true);
                return;
            }
        }
        else
            return;
        }
    void GetDetail()
    {
        ObjFacBal.DeptId = Session["DeptID"].ToString();
        ds = ObjFacBll.IssueCount(ObjFacBal);
        lblPending.Text = ds.Tables[0].Rows[0][0].ToString();
        lblProces.Text = ds.Tables[1].Rows[0][0].ToString();
        lblSolved.Text = ds.Tables[2].Rows[0][0].ToString();
        lblTotal.Text = ds.Tables[3].Rows[0][0].ToString();
    }
    }
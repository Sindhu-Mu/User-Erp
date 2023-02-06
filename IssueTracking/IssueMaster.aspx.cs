using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class IssueTracking_IssueMaster : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DataTable dt;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAdd.Attributes.Add("OnClick", "return validateDept()");
        btnSolAdd.Attributes.Add("OnClick", "return validateSolution()");
        btnAreaAdd.Attributes.Add("OnClick", "return validateArea()");
        if (!IsPostBack)
        {
            PushData();
            ViewState["ID"] = "";
            FillgvIssueDept();
            FillgvIssueSol();
            FillgvArea();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void PushData()
    {
        FillFunction.Fill(ddlIssueCat, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.IssueCat), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlSolDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlIssueDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.IssueDept), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.SolDept), true, FillFunctions.FirstItem.Select);
    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index,ddlIssueCat);
        txtIssueDept.Text = "";
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.KeyID = ddlIssueCat.SelectedValue;
        ObjFacBal.Value = txtIssueDept.Text;
        ObjFacBal.SessionUserID = "40"; //Session["UserId"].ToString();
        Msg = ObjFacBll.IssueMainInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillgvIssueDept();
        clear();
    }
    void FillgvIssueDept()
    {
        dt = ObjFacBll.IssueMainSelect().Tables[0];
        ViewState["dt"] = dt;
        gvIssueDept.DataSource = dt;
        gvIssueDept.DataBind();
    }
    protected void gvIssueDept_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvIssueDept.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("HEAD_ID=" + ViewState["ID"].ToString() + "");
            if (dr[0][5].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlIssueCat.SelectedValue = dr[0][1].ToString();
            txtIssueDept.Text = dr[0][2].ToString();
        }
            else
            {
                ObjFacBal.ChangeStatus = e.CommandName;
                ObjFacBal.Id = e.CommandArgument.ToString();
                ObjFacBal.SessionUserID = "40"; // Session["UserId"].ToString();
                Msg = ObjFacBll.IssueMainModify(ObjFacBal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
                ViewState["ID"] = "";
                CommonFunction.Clear(this);
                FillgvIssueDept();
                clear();
            }

        }
    protected void btnSolAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.ValueType = txtDept.Text;
        ObjFacBal.DeptId = ddlSolDept.SelectedValue;
        Msg = ObjFacBll.IssueSolutionInsert(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        CommonFunction.Clear(this);
        clear();
        FillgvIssueSol();
    }
    void FillgvIssueSol()
    {
        dt = ObjFacBll.IssueSolSelect().Tables[0];
        ViewState["dt"] = dt;
        gvIssueSol.DataSource = dt;
        gvIssueSol.DataBind();
    }
    protected void btnAreaAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.KeyID = ddlIssueDept.SelectedValue;
        ObjFacBal.Value = txtIssueArea.Text;
        ObjFacBal.TypeId = ddlDept.SelectedValue;
        ObjFacBal.SessionUserID = "40"; //Session["UserId"].ToString();
        Msg = ObjFacBll.IssueSubInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillgvArea();
        clear();
    }
    void FillgvArea()
    {
        dt = ObjFacBll.IssueSubHeadSelect().Tables[0];
        ViewState["dt"] = dt;
        gvArea.DataSource = dt;
        gvArea.DataBind();
    }

    protected void gvArea_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvArea.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SUB_HEAD_ID=" + ViewState["ID"].ToString() + "");
            if (dr[0][6].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlIssueDept.SelectedValue = dr[0][1].ToString();
            txtIssueArea.Text = dr[0][2].ToString();
            ddlDept.SelectedValue = dr[0][3].ToString();
        }
        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.Id = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = "40"; // Session["UserId"].ToString();
            Msg = ObjFacBll.IssueSubHeadModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillgvArea();
            clear();
        }
    }
}
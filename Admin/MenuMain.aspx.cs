using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_MenuMain : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    string Msg;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnPageHead.Attributes.Add("onclick", "return Headvalidation()");
        btnPageSubHead.Attributes.Add("onclick", "return SubHeadvalidation()");
        btnSave.Attributes.Add("onclick", "return Pagevalidation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            TabContainer1.ActiveTabIndex = 2;
            FillGrid();
            FillFunction.Fill(ddlHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuHead), true, FillFunctions.FirstItem.Select);
        }
    }
    private void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {        
        ViewState["ID"] = "";     
        if (TabContainer1.ActiveTabIndex == 0)
            FillHeadGrid();        
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            FillFunction.Fill(ddlPageHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuHead), true, FillFunctions.FirstItem.Select);
            FillSubHeadGrid();
        }
        else
        {
            FillFunction.Fill(ddlHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuHead), true, FillFunctions.FirstItem.Select);     
            FillGrid();           
        }
    }
    #region Menu Head
    private void FillHeadGrid()
    {
        dt = ObjHrBll.PageHeadInfSelect().Tables[0];
        ViewState["dt"] = dt;
        gvPageHead.DataSource = dt;
        gvPageHead.DataBind();
    }
    protected void btnPageHead_Click(object sender, EventArgs e)
    {

        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.KeyValue = txtHeadValue.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.PageHeadInfInsertUpdate(ObjAcaBAL);
        common.Clear(this);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);

    }
    protected void gvPageHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvPageHead.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("HEAD_ID =" + ViewState["ID"].ToString());
            if (dr[0]["HEAD_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtHeadValue.Text = dr[0][1].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.PageHeadInfModify(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillHeadGrid();
        }
    }
    #endregion

    #region Menu Sub-Head
    private void FillSubHeadGrid()
    {
        dt = ObjHrBll.PageSubHeadSelect().Tables[0];
        ViewState["dt"] = dt;
        gvPageSubHead.DataSource = dt;
        gvPageSubHead.DataBind();
    }
    protected void btnPageSubHead_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.KeyValue = txtSubHead.Text;
        ObjAcaBAL.CommonId = ddlPageHead.SelectedValue;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.PageSubHeadInsertUpdate(ObjAcaBAL);
        common.Clear(this);
        FillSubHeadGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);

    }
    protected void gvPageSubHead_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvPageSubHead.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SUB_HEAD_ID =" + ViewState["ID"].ToString());
            if (dr[0]["SUB_HEAD_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlPageHead.SelectedValue = dr[0][1].ToString();
            txtSubHead.Text = dr[0][2].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.PageSubHeadModify(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillSubHeadGrid();
        }
    }
    #endregion

    #region Menu Pages
    private void FillGrid()
    {
        dt = ObjHrBll.PageInfSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHead.SelectedIndex > 0)
            FillFunction.Fill(ddlSubHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuSubHead, ddlHead.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.PageName = txtPageName.Text;
        ObjAcaBAL.KeyValue = txtPageUrl.Text;
        ObjAcaBAL.CommonId = ddlSubHead.SelectedValue;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.PageInfInsertUpdate(ObjAcaBAL);
        common.Clear(this);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);

    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("PAGE_ID =" + ViewState["ID"].ToString());
            if (dr[0]["PAGE_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlHead.SelectedValue = dr[0][5].ToString();
            FillFunction.Fill(ddlSubHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuSubHead, ddlHead.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlSubHead.SelectedValue = dr[0][3].ToString();
            txtPageName.Text = dr[0][1].ToString();
            txtPageUrl.Text = dr[0][2].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.PageInfModify(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["dt"] = "";
            FillGrid();
        }
    }
    #endregion
}
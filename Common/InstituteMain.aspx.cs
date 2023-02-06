using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Common_InstituteMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    string Msg;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        btnHeadSave.Attributes.Add("onclick", "return validateIncharge()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            step1.ActiveTabIndex = 1;
            FillFunction.Fill(ddlUniv, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillHeadGrid();

        }
    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
    }
    public void FillGrid()
    {
        dt = ObjHrBll.UnivInsInfSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    public void FillHeadGrid()
    {
        gvHead.DataSource = ObjHrBll.UnivHeadSelect().Tables[0];
        gvHead.DataBind();
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            
            FillFunction.Fill(ddlUnivCode, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.University), true, FillFunctions.FirstItem.Select);
            FillGrid();
            ViewState["ID"] = "";
            txtIns.Text = txtInsDesc.Text = "";
        }
        else
        {
            FillFunction.Fill(ddlUniv, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillHeadGrid();
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.KeyValue = txtIns.Text;
        ObjHrBal.Description = txtInsDesc.Text;
        ObjHrBal.Code = txtEvl.Text;
        ObjHrBal.TypeId = ddlUnivCode.SelectedValue;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.UnivInsInsertUpdate(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        clear();
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("INS_ID =" + ViewState["ID"].ToString());
            if (dr[0]["INS_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlUnivCode.SelectedValue = dr[0][1].ToString();
            txtIns.Text = dr[0][2].ToString();
            txtInsDesc.Text = dr[0][4].ToString();
            txtEvl.Text = dr[0][3].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.InsId = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.UnivInsInfModify(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
    protected void btnHeadSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ddlUniv.SelectedValue;
        ObjHrBal.EmpId = common.GetKeyID(txtEmp);
        ObjHrBal.Date = common.GetDateTime(txtFromDt.Text);
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.UnivInsHeadInsert(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillHeadGrid();
        clearHead();
    }

    void clearHead()
    {
        ddlUniv.SelectedIndex = 0;
        txtEmp.Text = txtFromDt.Text = "";
    }
    void clear()
    {
        ddlUnivCode.SelectedIndex = 0;
        txtEvl.Text = txtIns.Text = txtInsDesc.Text = "";
    }
}
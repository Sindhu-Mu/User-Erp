using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_CategoryMain : System.Web.UI.Page
{

    FillFunctions fillfunction;
    QueryFunctions queryfunction;
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
                       
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            fillfunction.Fill(ddlJobType, queryfunction.GetCommand(QueryFunctions.QueryBaseType.JobType), true, FillFunctions.FirstItem.Select);
            FillGrid();
        }
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    public void FillGrid()
    {
        dt = ObjHrBll.EmpCatSelect().Tables[0];
        ViewState["dt"] = dt;
        gvCategory.DataSource = dt;
        gvCategory.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.TypeId = ddlJobType.SelectedValue;
        ObjAcaBAL.KeyValue = txtCatName.Text;
        ObjAcaBAL.AliasValue = txtCatAlias.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.EmpCatInsertUpdate(ObjAcaBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        common.Clear(this);
        FillGrid();

    }
    protected void gvCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvCategory.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("CAT_ID =" + ViewState["ID"].ToString());
            if (dr[0]["CAT_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlJobType.SelectedValue = dr[0]["JOB_TYPE_ID"].ToString();
            txtCatName.Text = dr[0]["CAT_VALUE"].ToString();
            txtCatAlias.Text = dr[0]["CAT_ALIAS"].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.EmpCatModify(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class HR_OrganisationMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    string Msg;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initilize();
        btnOrgSave.Attributes.Add("onclick", "return validate()");
        if (!IsPostBack)
        {
            PushData();
            bindGrid();
        }

    }
    void Initilize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }

    void bindGrid()
    {
        ViewState["dt"] = gvOrg.DataSource = ObjHrBll.OrganistionSelect().Tables[0];
        gvOrg.DataBind();
    }

    void PushData()
    {
        fillFunctions.Fill(ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.CITY), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OrgType), true, FillFunctions.FirstItem.Select);
    }
    protected void btnOrgSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.ORGNAME = txtOrgName.Text;
        ObjHrBal.ORGADD = txtAddress.Text;
        ObjHrBal.ORGTYPEID = ddlType.SelectedValue;
        ObjHrBal.CITYID = ddlCity.SelectedValue;
        ObjHrBal.ORGNAME = txtOrgName.Text;
        Msg = ObjHrBll.OrganizationInsert(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        clear();
        bindGrid();
    }

    void clear()
    {
        txtAddress.Text = txtOrgName.Text = "";
        ddlCity.SelectedIndex = ddlState.SelectedIndex = ddlType.SelectedIndex = 0;
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlState, ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlState, CommonFunctions.ClearType.Value, ddlCity);

    }
    protected void gvOrg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvOrg.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("ORG_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ORG_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtOrgName.Text = dr[0]["ORG_NAME"].ToString();
            txtAddress.Text = dr[0]["ORG_ADD"].ToString();
            if (dr[0]["CIT_ID"].ToString() != "0")
                ddlCity.SelectedValue = dr[0]["CIT_ID"].ToString();
            else
                ddlCity.SelectedIndex = 0;
            if (dr[0]["STA_ID"].ToString() != "0")
                ddlState.SelectedValue = dr[0]["STA_ID"].ToString();
            else
                ddlState.SelectedIndex = 0;
            ddlType.SelectedValue = dr[0]["ORG_TYPE_ID"].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            Msg = ObjHrBll.OrganisationModify(ObjHrBal);                                            // Department Status Change In Update Formss
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            bindGrid();
        }
    }
}
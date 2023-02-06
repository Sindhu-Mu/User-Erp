using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_DocumentMapping : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    Messages msg;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
            fill.Fill(ddlProgram, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            fill.Fill(ddlDocument, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DocumentSingle), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlQuota, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Quota), true, FillFunctions.FirstItem.All);

        }
    }

    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    private void FillGrid()
    {
        dt = bll.DocumentMapSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        bal.KeyID = ViewState["ID"].ToString();
        bal.CommonId = ddlDocument.SelectedValue;
        bal.InsId = ddlProgram.SelectedValue;
        bal.TypeId = ddlQuota.SelectedIndex.ToString();
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.DocumentMapInsertUpdate(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        common.Clear(this);
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
          
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("PGM_DOC_MAP_ID=" + ViewState["ID"].ToString());
            if (dr[0]["DOC_MAP_STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlDocument.SelectedValue = dr[0]["DOC_ID"].ToString();
            ddlProgram.SelectedValue = (dr[0]["INS_PGM_ID"].ToString() == "0") ? "." : dr[0]["INS_PGM_ID"].ToString();
            ddlQuota.SelectedValue = (dr[0]["DOC_QUOTA_ID"].ToString() == "0") ? "." : dr[0]["DOC_QUOTA_ID"].ToString(); 

        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.DocumentMapModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }

    }
}

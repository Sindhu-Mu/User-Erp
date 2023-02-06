using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_DocumentMain : System.Web.UI.Page
{
    CommonFunctions common;
    FillFunctions fill;
    QueryFunctions queryfunctions;
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
            fill.Fill(ddlDocFor, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DocFor, "0"), true, FillFunctions.FirstItem.Select); 
            FillGrid();         
        }
    }
    void Initialize()
    {
        common = new CommonFunctions();
        msg = new Messages();
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    void FillGrid()
    {
        bal.KeyID =ddlDocFor.SelectedValue;
        dt = bll.DocumentSelect(bal).Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    void clear()
    {
        txtDocName.Text = "";
        common.Clear(CommonFunctions.ClearType.Index, ddlDocFor);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

            bal.KeyID = ViewState["ID"].ToString();
            bal.FullName = txtDocName.Text;
            bal.ValueType = ddlDocFor.SelectedValue;
            bal.SessionUserID =Session["UserId"].ToString();
             Msg=bll.DocumentInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("DOC_ID=" + ViewState["ID"].ToString());
            if (dr[0]["DOC_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtDocName.Text = dr[0]["DOC_VALUE"].ToString();
            ddlDocFor.SelectedValue = dr[0]["DOC_FOR_ID"].ToString();
        }
        else
        {
            bal.ChangeStatus =e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID =Session["UserId"].ToString();
            Msg=bll.DocumentModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
   }
    protected void ddlDocFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
}
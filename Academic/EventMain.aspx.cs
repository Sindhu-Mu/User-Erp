using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_EventMain : System.Web.UI.Page
{
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
        txtEventName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
        }

    }
    private void Initialize()
    {

        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    private void FillGrid()
    {
        dt = bll.EventSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bal.KeyID = ViewState["ID"].ToString();
        bal.Name = txtEventName.Text;
        bal.Description = txtDesc.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.EventInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("ACA_EVENT_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ACA_EVENT_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtEventName.Text = dr[0]["ACA_EVENT_VALUE"].ToString();
            txtDesc.Text = dr[0]["ACA_EVENT_DESC"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.EventModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillGrid();
        }
    }

}
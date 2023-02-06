using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_QuotaMain : System.Web.UI.Page
{
    CommonFunctions common;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        txtQuotaName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
          
        }
    }

    private void Initialize()
    {
        common = new CommonFunctions();      
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    private void FillGrid()
    {
        dt = bll.QuotaSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bal.KeyID = ViewState["ID"].ToString();
        bal.Name = txtQuotaName.Text;
        bal.Description = txtDesc.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.QuotaInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("QUOTA_ID=" + ViewState["ID"].ToString());
            if (dr[0]["QUOTA_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtQuotaName.Text = dr[0]["QUOTA_NAME"].ToString();
            txtDesc.Text = dr[0]["QUOTA_DESC"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.QuotaModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();

        }
    }



}
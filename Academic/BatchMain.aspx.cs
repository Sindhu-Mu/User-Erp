using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Academic_BatchMain : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    string Msg;
    AcaBLL bll;  
    AcaBAL bal;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();
        }
    }
    void Initialize()
    {
        common = new CommonFunctions();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    void FillGrid()
    {
        dt = bll.AcaBatchSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    void clear()
    {
        txtBatchName.Text = "";
        txtBatchDT.Text = "";
        txtDesc.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        bal.KeyID = ViewState["ID"].ToString();
        bal.KeyValue = txtBatchName.Text;
        bal.Date = common.GetDateTime(txtBatchDT.Text);
        bal.Description = txtDesc.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.AcaBatchInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("ACA_BATCH_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ACA_BATCH_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtBatchName.Text = dr[0]["ACA_BATCH_NAME"].ToString();
            txtBatchDT.Text = Convert.ToDateTime(dr[0]["ACA_BATCH_START_DT"]).ToString("dd/MM/yyyy");
            txtDesc.Text = dr[0]["ACA_BATCH_DESC"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.AcaBatchModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }

}
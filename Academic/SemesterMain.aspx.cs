using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_SemesterMain : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();       
        btnSave.Attributes.Add("OnClick", "return validation()");
        txtSemesterNo.Attributes.Add("OnKeyPress", "return OnlyAlpha()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid();          
                   
        }
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    private void FillGrid()
    {
        dt = bll.SemesterSelect().Tables[0];                                   
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }  
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bal.KeyID = ViewState["ID"].ToString();
        bal.Value = txtSemesterNo.Text;
        bal.KeyValue = ddlSemesterType.SelectedValue;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.SemesterInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("ACA_SEM_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ACA_SEM_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }          
            txtSemesterNo.Text = dr[0]["ACA_SEM_NO"].ToString();
            ddlSemesterType.SelectedValue = dr[0]["SEM_TYPE_ID"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.SemesterModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }

  
   
}
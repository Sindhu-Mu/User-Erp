using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_ProgramTypeMain : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    AcaBLL bll;  
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
        dt = bll.ProgramTypeSelect().Tables[0];                                    
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bal.KeyID = ViewState["ID"].ToString();
        bal.Name = txtProgramType.Text;
        bal.Description = txtDesc.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.ProgramTypeInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("PRG_TYPE_ID=" + ViewState["ID"].ToString());
            if (dr[0]["PRG_TYPE_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtProgramType.Text = dr[0][1].ToString();
            txtDesc.Text = dr[0][2].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.ProgramTypeModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();

        }
    }




}
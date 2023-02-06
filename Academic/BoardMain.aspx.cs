using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_BoardMain : System.Web.UI.Page
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
        //txtBoardName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        txtShortName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
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
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
   void FillGrid()
    {
        dt = bll.BoardSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    void clear()
    {
        txtBoardName.Text = "";
        txtShortName.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        bal.KeyID = ViewState["ID"].ToString();
        bal.FullName = txtBoardName.Text;
        bal.Name = txtShortName.Text;
        bal.SessionUserID =Session["UserId"].ToString();
        Msg = bll.BoardInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("ACA_BRD_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ACA_BRD_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtBoardName.Text = dr[0]["ACA_BRD_FULL_NAME"].ToString();
            txtShortName.Text = dr[0]["ACA_BRD_SHORT_NAME"].ToString();

        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.BoardModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();

        }
    }
}



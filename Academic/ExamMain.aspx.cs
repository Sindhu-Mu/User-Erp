using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Academic_ExamMain : System.Web.UI.Page
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
        txtFullName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
        }
    }

    void Initialize()
    {
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    void FillGrid()
    {
        dt = bll.EntranceExamSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    void clear()
    {
        txtFullName.Text = "";
        txtShortName.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        bal.KeyID = ViewState["ID"].ToString();
        bal.FullName = txtFullName.Text;
        bal.Name = txtShortName.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.EntranceExamInsertUpdate(bal);
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
            DataRow[] dr = dt.Select("ENT_EXAM_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ENT_EXAM_STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtFullName.Text = dr[0]["ENT_EXAM_FULL_NAME"].ToString();
            txtShortName.Text = dr[0]["ENT_EXAM_SHORT_NAME"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.EntranceExamModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            common.Clear(this);
            FillGrid();

        }
    }


}
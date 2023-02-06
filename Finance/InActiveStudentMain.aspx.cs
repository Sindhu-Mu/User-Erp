using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Finance_InActiveStudentMain : System.Web.UI.Page
{
    SFBAL Objbal;
    SFBLL Objbll;
    SFDAL objdal;
    DataTable dt;
    string Msg;
    CommonFunctions commonFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    void initialise()
{
    Objbal = new SFBAL();
    Objbll = new SFBLL();
    objdal = new SFDAL();
    dt = new DataTable();
    commonFunction = new CommonFunctions();
}

    void FillGrid()
    {
        dt = Objbll.StuInactiveSelect().Tables[0];
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Objbal.balStatus = e.CommandName;
        Objbal.balStuAdmNo = e.CommandArgument.ToString();
        Objbal.balSession = Session["UserId"].ToString();
        Msg = Objbll.InactiveStsModify(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Objbal.balEnroll = commonFunction.GetKeyID(txtEnroll);
        Objbal.balSession = Session["UserId"].ToString();
        Objbll.InactiveStuInsert(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Inserted Sucessfully')", true);
        txtEnroll.Text = "";
        FillGrid();

    }
}
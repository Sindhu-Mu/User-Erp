using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class Common_AcademicBaseMain : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
        }
    }
    public void Initialize()
    {
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    public void FillGrid()
    {
        dt = ObjHrBll.AcaBaseInfSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        ObjAcaBAL.ShortName = txtShortName.Text;
        ObjAcaBAL.FullName = txtFullName.Text;
        ObjAcaBAL.BasePrp = txtPriority.Text;
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.AcademicBaseInsertUpdate(ObjAcaBAL);
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
            DataRow[] dr = dt.Select("ACA_BASE_ID =" + ViewState["ID"].ToString());
            if (dr[0]["ACA_BASE_STS"].ToString() == "False")
            {            
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);                
                return;
            }
            txtFullName.Text = dr[0][1].ToString();
            txtShortName.Text = dr[0][2].ToString();
            txtPriority.Text = dr[0][3].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg= ObjHrBll.AcaBaseModify(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
          
        }
        
    }
}
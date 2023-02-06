using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class StudentPortal_AddImpContact : System.Web.UI.Page
{
    FillFunctions FillFUnction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DataTable dt;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FIllGvContact();
            FillFUnction.Fill(ddlMail, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
            ViewState["dt"] = "";
        }
    }
    void Initialize()
    {
        FillFUnction = new FillFunctions();
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        dt = new DataTable();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
    }
    void FIllGvContact()
    {
        dt = ObjFacBll.ImpContactSelect().Tables[0];
        ViewState["dt"] = dt;
        gvContacts.DataSource = dt;
        gvContacts.DataBind();
    }
    void clear()
    {
        txtEmp.Text = "";
        txtDept.Text = "";
        txtMail.Text = "";
        txtPhn.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlMail);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.EmpId = CommonFunction.GetKeyID(txtEmp);
        ObjFacBal.DeptId = txtDept.Text;
        ObjFacBal.Value = txtMail.Text;
        ObjFacBal.Address = ddlMail.SelectedItem.ToString();
        ObjFacBal.PhnNo = txtPhn.Text;
        Msg = ObjFacBll.ImpContactInsert(ObjFacBal);
        FIllGvContact();
        clear();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
}
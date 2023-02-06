using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class login_GuestUserMain : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions QueryFunction;
    CommonFunctions common;
    Messages msg;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlDomain, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
        }
    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.Name = txtName.Text;
        ObjAcaBAL.CommonId = ddlDomain.SelectedValue;
        ObjAcaBAL.PhnNo = txtContact.Text;
        ObjAcaBAL.PageName = txtPurpose.Text;
        ObjAcaBAL.FullName = txtMail.Text;
        ObjAcaBAL.KeyID = ddlDept.SelectedValue;
        ObjHrBll.GuestInsert(ObjAcaBAL);
        common.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Saved')", true);
    }
}
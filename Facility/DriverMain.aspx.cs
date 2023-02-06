using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration; 

public partial class Facility_DriverMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DatabaseFunctions DatabaseFunction;
    string Msg;
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            FillGvDriver();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        DatabaseFunction = new DatabaseFunctions();
        Dt = new DataTable();
    }
    private void FillGvDriver()
    {
        Dt = ObjFacBll.DriverMainSelect().Tables[0];
        ViewState["dt"] = Dt;
        gvDriverFill.DataSource = Dt;
        gvDriverFill.DataBind();
    }
    void clear()
    {
        txtEmp.Text = "";
        txtLicence.Text="";
        txtIssueDt.Text="";
        txtValidUpto.Text="";
        txtRenewDt.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlBloodGrp);
        txtPhone.Text = "";
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.EmpId = CommonFunction.GetKeyID(txtEmp);
        ObjFacBal.No = txtLicence.Text;
        ObjFacBal.Date = CommonFunction.GetDateTime(txtIssueDt.Text);
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.EndDate = CommonFunction.GetDateTime(txtRenewDt.Text);
        ObjFacBal.ToDate = CommonFunction.GetDateTime(txtValidUpto.Text);
        ObjFacBal.AuthFor = rdbAutFor.SelectedValue;
        ObjFacBal.BldGrp = ddlBloodGrp.SelectedValue;
        ObjFacBal.PhnNo = txtPhone.Text;
        Msg = ObjFacBll.DriverMainInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillGvDriver();
        clear();

    }
    protected void gvDriverFill_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvDriverFill.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            ObjFacBal.Id = ViewState["ID"].ToString();
            Dt = (DataTable)ViewState["dt"];
            DataRow[] dr = Dt.Select("DRIVER_ID=" + ViewState["ID"].ToString() + "");
            if (dr[0]["DRIVER_ID"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtEmp.Text = dr[0]["EMP_NAME"].ToString() + ":" + dr[0]["DRIVER_EMP_CODE"].ToString();
            txtEmp.Enabled = false;
            txtLicence.Text = dr[0]["DRIVER_LICENCE_NO"].ToString();
            txtIssueDt.Text = dr[0]["DRIVER_DL_ISSUE_DT"].ToString();
            txtRenewDt.Text = dr[0]["DRIVER_DL_RENEW_DT"].ToString();
            txtValidUpto.Text = dr[0]["DRIVER_DL_VAL_UPTO"].ToString();
            rdbAutFor.SelectedValue = dr[0]["DRIVER_AUTH_FOR"].ToString();
            ddlBloodGrp.SelectedValue = dr[0]["DRIVER_BLOOD_GP"].ToString();
            txtPhone.Text = dr[0]["DRIVER_PHONE"].ToString();
        }
        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.KeyID = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.DriverMasterModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillGvDriver();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Facility_VehcileRequisition : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg;
    DataTable Dt;
    DataTable dtV;
    int i;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSubmit.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillgrdPreReq();
            GetPhnNo();
            TxtTo.Visible = ToDt.Visible = ExcDay.Visible = RetJou.Visible = false;
            ViewState["ID"] = "";
            ViewState["dt"] = "";
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        Dt = new DataTable();
        dtV = new DataTable();
    }
    void GetPhnNo()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        txtMobile.Text = ObjFacBll.GetEmpNo(ObjFacBal);
    }
    private void FillgrdPreReq()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Dt = ObjFacBll.VehPreviousReqSelect(ObjFacBal).Tables[0];
        ViewState["dt"] = Dt;
        grdPreReq.DataSource = Dt;
        grdPreReq.DataBind();
    }
    protected void rdbtnReqFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbtnReqFor.SelectedValue == "2")
        {
            RetJou.Visible = true;
        }
        else
        {
            RetJou.Visible = false;
        }
    }
    protected void rbReqFor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbReqFor.SelectedValue == "2")
        {
            ToDt.Visible = TxtTo.Visible = ExcDay.Visible = true;
        }
        else
        {
            ToDt.Visible = TxtTo.Visible = ExcDay.Visible = false;
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        dtV = ObjFacBll.getRoleId(ObjFacBal).Tables[0];
        for (i = 0; i < dtV.Rows.Count; i++)
        {
          string role =  dtV.Rows[i][0].ToString();
          if (role == "2" || role == "3")
          {
              ObjFacBal.Forward_To = "5";
              break;
          }
          else
          {
              ObjFacBal.Forward_To = "2";
          }
        }
        ObjFacBal.ValueType = rdbtnReqFor.SelectedValue;
        ObjFacBal.Address = txtDesAdd.Text;
        ObjFacBal.PickUpLocation = txtPickLoc.Text;
        ObjFacBal.PhnNo = txtMobile.Text;
        ObjFacBal.NoOfPer = txtNoPer.Text;
        ObjFacBal.TypeId = rbReqType.SelectedValue;
        ObjFacBal.AuthFor = rbReqFor.SelectedValue;
        ObjFacBal.Purpose = txtPurVisit.Text;
        ObjFacBal.ToDate = CommonFunction.GetDateTime(txtDate.Text);
        ObjFacBal.ToTime = txtTime.Text;
        ObjFacBal.FromDate = Convert.ToDateTime("2012-05-05 20:12:23.420");
        ObjFacBal.Date = Convert.ToDateTime("2012-05-05 20:12:23.420");
        ObjFacBal.PerType = "";
        ObjFacBal.No = "";
        ObjFacBal.Reason = "";
        if (rdbtnReqFor.SelectedValue == "2")
        {
            ObjFacBal.PerType = txtPickUp.Text;
            ObjFacBal.FromDate = CommonFunction.GetDateTime(txtRetDt.Text);
            ObjFacBal.Time = txtRetTime.Text;
            ObjFacBal.No = txtNoOfPer.Text; 
        }
        if (rbReqFor.SelectedValue == "2")
        {
            ObjFacBal.FromDate = CommonFunction.GetDateTime(txtToDate.Text);
            if (txtExcDt.Text!="")
            {
            ObjFacBal.Date = CommonFunction.GetDateTime(txtExcDt.Text);
            }
            ObjFacBal.Reason = txtReason.Text;
        }
        Msg = ObjFacBll.VehicleRequisitionInsert(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }
    void clear()
    {
        txtDate.Text = "";
        txtDesAdd.Text = "";
        txtExcDt.Text = "";
        txtMobile.Text = "";
        txtNoOfPer.Text = "";
        txtNoPer.Text = "";
        txtPickLoc.Text = "";
        txtPickUp.Text = "";
        txtPurVisit.Text = "";
        txtReason.Text = "";
        txtRetDt.Text = "";
        txtRetTime.Text = "";
        txtTime.Text = "";
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (TabContainer1.ActiveTabIndex == 1)
        {
            FillgrdPreReq();
        }
    }
}
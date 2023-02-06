using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_OnDutyApplication : System.Web.UI.Page
{

    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    string Msg;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");

        if (!IsPostBack)
        {
            Clear();
        }
    }

    void Clear()
    {
        txtFromDate.Text = txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtReason.Text = "";
        ddlreason.SelectedIndex = ddlApply.SelectedIndex = 0;
        FillGrid();
    }

    void FillGrid()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString(); 
        ObjHrBal.TypeId = "5";
        gvShow.DataSource = ObjHrBll.EmpLvDetailSelect(ObjHrBal);
        gvShow.DataBind();
    }

    protected void ddlreason_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlreason.SelectedIndex == 3)
            tdReason.Visible = true;
        else
            tdReason.Visible = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if ((System.DateTime.Now.Month > commonFunctions.GetDateTime(txtFromDate.Text).Month) && (System.DateTime.Now.Year >= commonFunctions.GetDateTime(txtFromDate.Text).Year))
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        //}
       // else
        //{
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            ObjHrBal.FromDate = commonFunctions.GetDateTime(txtFromDate.Text);
            ObjHrBal.ToDate = commonFunctions.GetDateTime(txtToDate.Text);
            ObjHrBal.TypeId = ddlApply.SelectedValue;
            if (ddlreason.SelectedIndex ==3)
                ObjHrBal.Description = txtReason.Text;
            else
                ObjHrBal.Description = ddlreason.SelectedItem.Text;
            Msg = ObjHrBll.EmpOnDutyInsert(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            Clear();
        //}
    }   
}
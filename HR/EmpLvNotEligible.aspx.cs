using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class HR_EmpLvNotEligible : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    void FillGrid()
    {
        dt = ObjHrBll.EmpLvEligibleSelect().Tables[0];
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
         string[] emp = txtEmp.Text.Split(':');
         if (emp.Length > 1)
         {
             ObjHrBal.EmpId = emp[1];
             ObjHrBal.FromDate = commonFunctions.GetDateTime(txtFrmDate.Text);
             if (txtToDate.Text != "")
                 ObjHrBal.ToDate = commonFunctions.GetDateTime(txtToDate.Text);         
             ObjHrBal.Description = txtRemark.Text;
             ObjHrBal.SessionUserID = Session["UserId"].ToString();
             ObjHrBll.EmpLvNotEligibleInsert(ObjHrBal);
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Employee Leave blocked successfully.')", true);
         }
         else
         {
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter employee name & code.')", true);
         }
         Clear();
    }

    void Clear()
    {
        txtFrmDate.Text = txtToDate.Text = txtEmp.Text = txtRemark.Text = "";
        FillGrid();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBal.ChangeStatus = "0";
        ObjHrBal.KeyID = e.CommandArgument.ToString();
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBll.EmpLvOpen(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Employee Leave opened successfully.')", true);
        Clear();
    }
}
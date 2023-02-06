using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_AprvdCompansatCredit : System.Web.UI.Page
{
   
   
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;
    DataTable dt;
    public void Initialize()
    {
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
        dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validateView()");

        if (!IsPostBack)
        {
            btnSubmit.Visible = false;

        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        ds= ObjHrBll.ZeroCompCredit(ObjHrBAL);
        ViewState["myTable"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            btnSubmit.Visible = true;
            gvComDetail.DataSource = ds.Tables[0];
            gvComDetail.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No record found with 0 compansatory credit')", true);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["myTable"]; 
        foreach (GridViewRow gvrow in gvComDetail.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvrow.FindControl("chkSelect");
            if (chkSelect.Checked == true)
            {
                ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
                TextBox txtCredit = (TextBox)gvrow.FindControl("txtCredit");
                string index = gvrow.Cells[1].Text;
                ObjHrBAL.InBy = Session["UserId"].ToString();
                ObjHrBAL.KeyID = ds.Tables[0].Rows[gvrow.DataItemIndex]["ID"].ToString();
                ObjHrBAL.Value1 = ((TextBox)gvComDetail.Rows[gvrow.DataItemIndex].FindControl("txtCredit")).Text;
                ds = ObjHrBll.UpdateLeaveCompCredit(ObjHrBAL);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Leave Credited Successfully')", true);
                btnSubmit.Visible = true;
                gvComDetail.Visible = true;
            }
        }
        
    }
}
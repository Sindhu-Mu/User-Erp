using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayRoll_SalMonthHold : System.Web.UI.Page
{
    PRBAL prbal;
    PRBLL prbll;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialization();
    }
    public void Initialization()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        cf = new CommonFunctions();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        prbal.balEmpCode = cf.GetKeyID(txtEmp);
        EmpPayrollProfile.ShowEmployeeInfo(prbal.balEmpCode);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
        prbal.balEmpCode = cf.GetKeyID(txtEmp);
        if (!prbal.balEmpCode.Equals(null))
        {
           
                prbal.balMonth = ddlMM.SelectedValue;
                prbal.balYear = ddlYY.SelectedValue;
                prbal.balCurEmpCode = Session["LoginId"].ToString();
                prbal.balRemark = txtRemark.Text;
                prbal.balData = ddlStatus.SelectedValue;
                prbll.INSERT_SAL_HOLD(prbal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Update Successful..!')", true);
               
            
        }

    }
}
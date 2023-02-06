using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PayRoll_AddPf : System.Web.UI.Page
{
    PRBAL prbal;
    PRBLL prbll;
    CommonFunctions cf;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialization();
        btnAddPf.Attributes.Add("onclick", "return validate()");
    }
    public void Initialization()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        cf = new CommonFunctions();
    }
    protected void btnAddPf_Click(object sender, EventArgs e)
    {
        int ins_by = Convert.ToInt32(Session["user_id"]);
        DropDownList ddlMMFor = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYYFor = (DropDownList)MonthYear.FindControl("ddlYear");
        DropDownList ddlMMIN = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYYTIN = (DropDownList)MonthYear1.FindControl("ddlYear");
        string code = cf.GetKeyID(txtEmp);
        string amt = txtPfAmount.Text;
        prbal.balEmpCode = code;
        prbal.balMonth = ddlMMFor.SelectedValue;
        prbal.balYear = ddlYYFor.SelectedValue;
        prbal.balEndMonth = ddlMMIN.SelectedValue;
        prbal.balEndYear=ddlYYTIN.SelectedValue;
        prbal.balAmt = amt;
        prbal.balCurEmpCode = Session["LoginID"].ToString();
        int status=prbll.ADD_ARREAR_PF(prbal);
        prbll.showStatusAlert(status, this, "PF Submitted Successfully", "Error In PF Submission");
        

    }
}
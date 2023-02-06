using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_Pwd_Reset : System.Web.UI.Page
{
    CommonFunctions commonFunction;
    DatabaseFunctions databasefunctn;
    HRBAL objhrbal;
    HRBLL objhrbll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("OnClick", "return validat()");
        if (!IsPostBack)
        {
            txtEmp.Text = "";
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        string id = (commonFunction.GetKeyID(txtEmp));
        Employee.ShowEmployeeInfo(id);
        ViewState["Id"] = id;
    }
    void Initialize()
    {
        commonFunction = new CommonFunctions();
        databasefunctn = new DatabaseFunctions();
        objhrbal = new HRBAL();
        objhrbll = new HRBLL();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        objhrbal.EmpId = ViewState["Id"].ToString();
        objhrbll.EmpPwdReset(objhrbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Password has been reseted successfully')", true);
        txtEmp.Text = "";
        Employee.ShowEmployeeInfo("-15");
    }
}
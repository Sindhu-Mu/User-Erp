using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class login_ChangePassword : System.Web.UI.Page
{
    USRBAL ObjBal;
    USRBLL ObjBll;
    CommonFunctions ComFunction;

    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnChange.Attributes.Add("OnClick", "return Passvalidate()");
    }
    void Initialize()
    {
        ObjBal = new USRBAL();
        ObjBll = new USRBLL();
        ComFunction = new CommonFunctions();
    }


    protected void btnChange_Click(object sender, EventArgs e)
    {
        if (txtNewPassword.Text != txtConPwd.Text)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Password Must Match')", true);
        }
        else
        {
            ObjBal.USRID = Session["UserId"].ToString();
            ObjBal.KEYID = txtOldPassword.Text;
            ObjBal.KEYVALUE = txtConPwd.Text;
            Msg = ObjBll.EmpPassUpdate(ObjBal);

            if (Msg.Contains("successfully"))
            {
                txtOldPassword.Text = txtNewPassword.Text = txtConPwd.Text = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Password changed successfully')", true);

            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
           
        }
            
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        txtOldPassword.Text = txtNewPassword.Text = txtConPwd.Text = "";
    }
}
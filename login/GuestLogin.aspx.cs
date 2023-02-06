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


public partial class login_GuestLogin : System.Web.UI.Page
{
    USRBLL ObjUserBll;
    USRBAL ObjUserBal;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogin.Attributes.Add("onclick", "return validation()");
        try
        {
            if (Session["UserId"].ToString() == "")
            {
                Session.Clear();
                txtLoginId.Text = txtPassword.Text = "";
                txtLoginId.Focus();
            }
        }
        catch
        {
            Session.Clear();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        ObjUserBll = new USRBLL();
        ObjUserBal = new USRBAL();
        ObjUserBal.LOGINID = txtLoginId.Text;
        ObjUserBal.USRPASS = txtPassword.Text;
        ObjUserBal.USRTYPEID = "2";
        if (ObjUserBll.GetUserInformation(ObjUserBal))
        {
            Session["UserId"] = ObjUserBal.USRID;
            Session["LoginId"] = ObjUserBal.LOGINID;
            Session["UserName"] = ObjUserBal.USRNAME;
            Session["UserType"] = ObjUserBal.USRTYPEID;
            Session["InsID"] = ObjUserBal.InsID;
            Response.Redirect("~/Common/Home.aspx");
        }
        else
        {
            txtLoginId.Text = txtPassword.Text = "";
            txtLoginId.Focus();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Login Id or Password.')", true);
        }

    }
}
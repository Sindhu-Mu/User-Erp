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

public partial class Login_Default : System.Web.UI.Page
{

    USRBLL ObjUserBll;
    USRBAL ObjUserBal;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        btnLogin.Attributes.Add("onclick", "return validation();");
        try
        {
            if (Request.QueryString[0].ToString() == "1")
            {
                if (Session["UserId"].ToString() != "")
                {
                    Session.Clear();
                    txtLoginId.Text = txtPassword.Text = "";
                    txtLoginId.Focus();
                }
            }
        }
        catch
        {
            Session.Clear();            
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        TD1.Visible = false;
        ObjUserBll = new USRBLL();
        ObjUserBal = new USRBAL();
        ObjUserBal.LOGINID = txtLoginId.Text;
        ObjUserBal.USRPASS = txtPassword.Text;
        ObjUserBal.USRTYPEID = "1";
        if (ObjUserBll.GetUserInformation(ObjUserBal))
        {
            Session["UserId"] = ObjUserBal.USRID;
            Session["LoginId"] = ObjUserBal.LOGINID;
            Session["UserName"] = ObjUserBal.USRNAME;
            Session["UserType"] = ObjUserBal.USRTYPEID;
            Session["InsID"] = ObjUserBal.InsID;
            Session["HostelId"] = ObjUserBal.HostelId;
            Session["DeptID"] = ObjUserBal.DeptID;
            Response.Redirect("~/Common/Home.aspx");
          
        }
        else
        {
            txtLoginId.Text = txtPassword.Text = "";
            txtLoginId.Focus();
            TD1.Visible = true;
            
        }

    }
   
}

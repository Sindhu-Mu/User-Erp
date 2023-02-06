using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class Common_ForgotPassword : System.Web.UI.Page
{
    
    USRBAL ObjBal;
    USRBLL ObjBll;
    Random RandomNumber;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        btnVerify.Attributes.Add("OnClick", "return Passvalidate()");  
        if (!IsPostBack)
        {

        }
    }
    void Initailize()
    {

        ObjBal = new USRBAL();
        ObjBll = new USRBLL();
        RandomNumber = new Random();
    }


    protected void btnVerify_Click(object sender, EventArgs e)
    {
         
        //ObjBal.KEYID = txtEmployee.Text;
        //ObjBal.KEYVALUE = txtMobileNo.Text;
        //ObjBal.USRNAME = txtEmail.Text;
        //ObjBal.USRPASS = Encrypt.Encryptstr(RandomNumber.Next(0, 100000).ToString());
        //Msg = ObjBll.ForgotPassword(ObjBal);
        //if (Msg.Contains("successfully"))
        //{
        //    txtEmail.Text = txtMobileNo.Text = txtEmployee.Text = "";
        //}
        //else
        //    txtEmployee.Focus();
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);


    }
}
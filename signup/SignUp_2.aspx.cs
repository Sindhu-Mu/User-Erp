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


public partial class signup_SignUp_2 : System.Web.UI.Page
{
    Global global;
    QueryFunctions qf;
    FillFunctions ff;
    DatabaseFunctions df;
    USRBAL usrbal;
    USRBLL usrbll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnNext.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            global.SetCode(lblCaptcha);
            Page.ClientScript.RegisterStartupScript(this.GetType(),
             "onLoad", "SetUrls();", true);
            ff.Fill(ddlQuestion, qf.GetCommand(QueryFunctions.QueryBaseType.SecurityQuestion), true, FillFunctions.FirstItem.Select);

        }
    }
    void Initialize()
    {
        global = new Global();
        qf = new QueryFunctions();
        ff = new FillFunctions();
        df = new DatabaseFunctions();
        usrbal = new USRBAL();
        usrbll = new USRBLL();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        global.SetCode(lblCaptcha);
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        usrbal.LOGINID= txtLoginId.Text;
        usrbal.USRPASS = txtPassword.Text;
        usrbal.KEYTYPEID = txtTocken.Text;
        usrbal.SECQSNID = ddlQuestion.SelectedValue;
        usrbal.USRQSNANS = txtAnswer.Text;
        int a = usrbll.UserRegistration(usrbal);
        if (a <= 0)
        {
            lblRegistrationStatus.Text = "User Already Registration";
        }
        else
        {
            Response.Redirect("SignUp_3.aspx");
        }
        

    }

  
}

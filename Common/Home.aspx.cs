using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
public partial class Common_Home : System.Web.UI.Page
{
    public IEnumerator ie;
    public IEnumerator enNot;
    public NoticePicker objNotice = new NoticePicker();
    public int i;
    public int dwid = 1000;
    public int vwid = 5000;
    public int qs = 0;
    NoticePicker nm = new NoticePicker();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Cache.SetNoStore();
        try
        {
            if (Session["UserId"].ToString() == "") Response.Redirect("../login/Default.aspx");
            if (!IsPostBack)
            {
                if (Session["UserId"].ToString() != "")
                {
                    lblUserCode.Text = "#Code:- " + Session["LoginId"].ToString();
                    lblUserName.Text = Session["UserName"].ToString();
                    ImgEmp.Src = "../images/emp_images/" + Session["LoginId"].ToString() + "_thumb.jpg";
                }

            }
        }
        catch
        {
            Response.Redirect("../login/Default.aspx");
        }
        try
        {

            ie = nm.GetSpecificNotice(qs).GetEnumerator();
        }
        catch { }
        enNot = nm.GetAllUserNotices(Session["UserId"].ToString(),"1").GetEnumerator();


    }
}
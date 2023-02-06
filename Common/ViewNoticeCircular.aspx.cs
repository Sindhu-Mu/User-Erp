using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Common_ViewNoticeCircular : System.Web.UI.Page
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
        try
        {
            qs = Int32.Parse(Request.QueryString["newsid"].ToString());
            if (qs != -1)
            {
                ie = nm.GetSpecificNotice(qs).GetEnumerator();
            }
        }
        catch { }
        

        enNot = nm.GetAllUserNotices(Session["UserId"].ToString(),"2").GetEnumerator();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        CommonFunctions common = new CommonFunctions();
        string filter = null;
        string date = null;
        if (TextBox1.Text != "")
            filter = TextBox1.Text;
        if (TextBox2.Text != "")
            date = common.GetDateTime(TextBox2.Text).ToString("yyyy-MM-dd");
        enNot = nm.GetAllUserNoticesSearch(Session["UserId"].ToString(), filter, date,"2").GetEnumerator();
    }
}
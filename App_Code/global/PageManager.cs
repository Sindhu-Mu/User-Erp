using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
/// <summary>
/// Summary description for PageManager
/// </summary>
public class PageManager
{
    static string _connStr;
    public PageManager()
    {
        _connStr = ConfigurationManager.AppSettings["conStr"].ToString();
    }

    public static void AddVisitInfo(string page_Id,string Usr_Id)
    {

        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlCommand cmd = new SqlCommand("USR_PAGE_VISIT_INF_INSERT", cn);
        cn.Open();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@page_Id", page_Id));
        cmd.Parameters.Add(new SqlParameter("@Usr_Id", Usr_Id));
        cmd.ExecuteNonQuery();
    }
    public static string getNavigateURL(int page_left_id)
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        SqlDataAdapter sda = new SqlDataAdapter("SELECT PAGE_URL FROM MENU_LINKS WHERE PAGE_LEFT_ID=" + page_left_id, cn);
        DataSet ds = new DataSet();
        sda.Fill(ds, "getNavigateURL");
        cn.Close();
        if (ds.Tables[0].Rows.Count > 0)
            return ds.Tables[0].Rows[0][0].ToString();
        else
            return "";

    }
    public static Boolean CheckURL(string page, int Emp)
    {
        if (page == "Home.aspx")
            return true;
        SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
        string str = "SELECT * FROM ROLEMASTER INNER JOIN ROLEDETAIL ON ROLEMASTER.ROLEID=ROLEDETAIL.RoleID"
        + " INNER JOIN USER_RIGHTS ON ROLEMASTER.ROLEID=USER_RIGHTS.ROLEID INNER JOIN MENU_LINKS ON  PAGE_LEFT_ID=PageLeftID"
        + " WHERE PAGE_URL LIKE '%" + page + "' AND EMPLCODE=" + Emp;
        SqlDataAdapter sda = new SqlDataAdapter(str, cn);
        DataSet ds = new DataSet();
        sda.Fill(ds, "getNavigateURL");
        cn.Close();
        if (ds.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;

    }
    public string AddKeepAlive(string page_name)
    {
        //USE OF THE CODE JUST PLACE THE BELOW 2 LINES IN THE PAGE LOAD OF THE PAGE
        //PageManager aPage = new PageManager();
        //System.Uri uri = Request.Url;
        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Reconnect", aPage.AddKeepAlive(uri.Segments[uri.Segments.GetUpperBound(0)].ToString()), true); 

        int int_MilliSecondsTimeOut = (HttpContext.Current.Session.Timeout * 60000) - 30000;
        string str_Script = @"
//Number of Reconnects
var count=0;
//Maximum reconnects setting
var max = 5;
function Reconnect(){

count++;
if (count < max)
{
window.status = 'Link to Server Refreshed ' + count.toString()+' time(s)' ;

var img = new Image(1,1);

img.src = '" + page_name + @"';

}
}

window.setInterval('Reconnect()'," + int_MilliSecondsTimeOut.ToString() + @"); //Set to length required";

        //window.setInterval('Reconnect()',"+ int_MilliSecondsTimeOut.ToString()+ @"); //Set to length required

        return str_Script;

    }
    public string CheckSessionTimeout()
    {
        //USE OF THE CODE PLACE THE BELOW 2 LINES IN THE PAGE LOAD OF THE PAGE
        //PageManager aPage = new PageManager();
        //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "CheckSessionTimeout", aPage.CheckSessionTimeout(), true); 
        int int_MilliSecondsTimeOut = (HttpContext.Current.Session.Timeout * 60000) - 30000;
        string str_Script = @"
            var myTimeOut;             
            clearTimeout(myTimeOut); " +
                "var sessionTimeout = " + int_MilliSecondsTimeOut.ToString() + ";" +
                "function doRedirect(){ window.location.href='../common/login.aspx'; }" + @"            
            myTimeOut=setTimeout('doRedirect()', sessionTimeout); ";
        return str_Script;
    }
}

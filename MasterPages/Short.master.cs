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
using System.Text;
using System.Xml;

public partial class MasterPage_MasterPage : System.Web.UI.MasterPage
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserId"].ToString() == "") Response.Redirect("../login/Default.aspx");       
        if (!IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
            if (Session["UserId"].ToString() != "")
            {

                lblUserCode.Text = "#Code:- " + Session["LoginId"].ToString();
                lblUserName.Text = Session["UserName"].ToString();
                ImgEmp.Src = "../images/emp_images/" + Session["LoginId"].ToString() + "_thumb.jpg";
                if (authorizeUrl() == 0)
                    Response.Redirect("../Common/InvalidAccessException.htm");
            }
        }

        
    }
    int authorizeUrl()
    {
        int status = 0;
        string path = HttpContext.Current.Request.Url.AbsolutePath;
        path = path.Replace("/EmployeePortal", "..");
        path = path.Split('?').GetValue(0).ToString();
        string home_path = "../Common/Home.aspx";
        if (path == home_path)
        {
            status = 1;
        }
        else
        {

            if (Session["MENU"].ToString() != "")
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.InnerXml = Session["MENU"].ToString();
                XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;
                for (int i = 0; i < nodeList.Count; i++)
                {

                    XmlNodeList nodeList_sub = xmlDoc.DocumentElement.ChildNodes[i].ChildNodes;
                    for (int x = 0; x < nodeList_sub.Count; x++)
                    {
                        // String a = nodeList_sub[x].Attributes["PAGE_URL"].Value;
                        XmlNodeList nodeList_menu = xmlDoc.DocumentElement.ChildNodes[i].ChildNodes[x].ChildNodes;
                        for (int y = 0; y < nodeList_menu.Count; y++)
                        {
                            String menu_url = nodeList_menu[y].Attributes["PAGE_URL"].Value;
                            if (menu_url == path)
                            {
                                status = 1;
                                break;
                            }
                        }

                    }

                }
            }
            if ((status == 0) && (Session["QUICKLINK"].ToString() != ""))
            {
                string quicklink;
                DataSet ds = (DataSet)Session["QUICKLINK"];
                for (int j = 0; j < ds.Tables.Count; j++)
                {
                    for (int i = 0; i < ds.Tables[j].Rows.Count; i++)
                    {
                        quicklink = ds.Tables[j].Rows[i]["PAGE_URL"].ToString();
                        if (quicklink == path)
                        {
                            status = 1;
                            break;
                        }
                    }
                }
            }
            if (status == 0)
            {
                USRBLL ObjUsrBll = new USRBLL();
                USRBAL ObjUsrBal = new USRBAL();
                ObjUsrBal.KEYID = path;
                status = ObjUsrBll.GetMissPageRight(ObjUsrBal);
            }
        }
        return status;
    }
   
}

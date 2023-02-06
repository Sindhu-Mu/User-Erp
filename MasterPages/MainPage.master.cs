using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using System.Data;
using ExamFunctions;
public partial class MasterPages_MainPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserId"].ToString() == "") Response.Redirect("../Common/login.aspx");
        if (!IsPostBack)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetNoStore();
            lblUserCode.Text = "Code#:-" + Session["LoginId"].ToString();
            lblUserName.Text = Session["UserName"].ToString();


        }
    }
    int authorizeUrl()
    {
        int status = 0;
        string path = HttpContext.Current.Request.Url.AbsolutePath;
        path = path.Replace("/ExaminationPortal", "..");
        path = path.Split('?').GetValue(0).ToString();
        string home_path = "../Common/Default.aspx";
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

        }
        return status;
    }
}

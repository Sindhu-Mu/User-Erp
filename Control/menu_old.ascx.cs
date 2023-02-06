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
using System.Xml;
using System.Text;
using System.Data.SqlClient;
using System.IO;

public partial class control_menu : System.Web.UI.UserControl
{
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UserId"].ToString() != "")
        {

            XmlDocument xmlData = new XmlDocument();
            SqlCommand command = new SqlCommand("GET_MENU");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@USR_ID", Session["UserId"].ToString());
            string ss= databaseFunctions.GetSingleData(command);
            if (ss.Length > 0)
            {
                xmlData.InnerXml = ss;
                Session["MENU"] = xmlData.OuterXml;
                XmlDataSource1.Data = xmlData.OuterXml;

            }
            else
                Session["MENU"] = "";
        }
        else
        {
            XmlDataSource1.Data = Session["MENU"].ToString();
        }
        makeMenu();

    }
    void makeMenu()
    {
        if (true)
        {
            StringBuilder list = new StringBuilder();
            list.AppendFormat("<ul>");
            list.AppendFormat("<li class='make_border'><a href='../Common/Home.aspx'><span>");
            list.AppendFormat("Home");
            list.AppendFormat("</span></a></li>");
            if (Session["MENU"].ToString() != "")
            {

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.InnerXml = Session["MENU"].ToString();

                XmlNodeList nodeList = xmlDoc.DocumentElement.ChildNodes;
                for (int i = 0; i < nodeList.Count; i++)
                {
                    list.AppendFormat("<li class='make_border'><a href='#'><span >");
                    list.AppendFormat(nodeList[i].Attributes["HEAD_VALUE"].Value);
                    list.AppendFormat("</span></a><ul>");
                    XmlNodeList nodeList_sub = xmlDoc.DocumentElement.ChildNodes[i].ChildNodes;
                    for (int x = 0; x < nodeList_sub.Count; x++)
                    {
                        list.AppendFormat("<li class='float_left'>");
                        list.AppendFormat("<a href='#'><span class='heading'>");
                        list.AppendFormat(nodeList_sub[x].Attributes["SUB_HEAD_VALUE"].Value);
                        list.AppendFormat("</span></a><br/>");
                        XmlNodeList nodeList_menu = xmlDoc.DocumentElement.ChildNodes[i].ChildNodes[x].ChildNodes;
                        for (int y = 0; y < nodeList_menu.Count; y++)
                        {
                            list.AppendFormat("<class='float_down'><a href='" + nodeList_menu[y].Attributes["PAGE_URL"].Value + "'><span class='menu_item'>");
                            list.AppendFormat(nodeList_menu[y].Attributes["PAGE_VALUE"].Value);
                            list.AppendFormat("</span></a><br/>");

                        }
                        //list.AppendFormat("</ul>");
                        list.AppendFormat("</li>");

                    }
                    list.AppendFormat("</ul>");
                    list.AppendFormat("</li>");
                }
            }
            list.AppendFormat("</ul>");
            list.ToString();
            cssmenu.InnerHtml = list.ToString();
        }
    }
    
}


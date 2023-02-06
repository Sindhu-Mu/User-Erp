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
using System.Data.SqlClient;
using System.Xml;
using System.Text;
using System.IO;

public partial class Academic_StudentIcardPrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if (PreviousPage.IsCrossPagePostBack)
            {
                try
                {
                    Save();
                }
                catch
                {
                    Response.Redirect("StudentICard.aspx", true);
                }
            }
        }
        catch
        {
            try
            {
                Save();
            }
            catch
            {
                Response.Redirect("StudentICard.aspx", true);
            }
        }
    }
    void Save()
    {

        DataSet dataCard = new DataSet();
        //dataCard = (DataSet)Session["ds"];
        StringReader reader = new StringReader(PreviousPage.GetXMLInsert);
        dataCard.ReadXml(reader);
        reader.Close();
        StringBuilder query = new StringBuilder();
        XmlDocument xDoc = new XmlDocument();
        xDoc.InnerXml = dataCard.GetXml();
        XmlNodeList nodeList = xDoc.FirstChild.ChildNodes;
        repICard.DataSource = dataCard;
        repICard.DataBind();
        DatabaseFunctions databaseFunctions = new DatabaseFunctions();
        SqlCommand command;
        foreach (XmlNode node in nodeList)
            query.Append("INSERT INTO STU_I_CARD_PRT_DET_INF (STU_ADM_NO,PRT_BY) VALUES ('" + node.FirstChild.InnerText + "'," + Session["UserId"].ToString() + ");");

        command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        databaseFunctions.ExecuteCommand(command);

    }
    protected void repICard_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
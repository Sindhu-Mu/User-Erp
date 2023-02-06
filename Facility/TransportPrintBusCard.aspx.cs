using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_TransportPrintBusCard : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        try
        {
            if (Request.QueryString.HasKeys())
            {
                try
                {
                    Print(Request.QueryString["REG_ROUTE_ID"]);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Invalid Print command')", true);
                }
            }
            else if (PreviousPage.IsCrossPagePostBack)
            {
                try
                {
                    Save();
                }
                catch
                {
                    Response.Redirect("TransportICardPrintView.aspx", true);
                }
            }
        }
        catch
        {
            Response.Redirect("TransportICardPrintView.aspx", true);
        }
    }
    HtmlImage img = new HtmlImage();

    void Save()
    {
        DataSet dataCard = new DataSet();
        System.IO.StringReader reader = new System.IO.StringReader(PreviousPage.GetXMLInsert);
        dataCard.ReadXml(reader);
        reader.Close();


        StringBuilder query = new StringBuilder();
        XmlDocument xDoc = new XmlDocument();
        xDoc.InnerXml = dataCard.GetXml();

        XmlNodeList nodeList = xDoc.FirstChild.ChildNodes;
       
        foreach (XmlNode node in nodeList)
            query.Append("INSERT INTO TPT_STU_CARD_PRT_INF (REG_RTE_ID,PRINT_BY) VALUES ('" + node.FirstChild.InnerText + "','" + Session["LoginId"].ToString() + "');");



        rpt1.DataSource = dataCard;
        rpt1.DataBind();


        DatabaseFunctions databaseFunctions = new DatabaseFunctions();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        databaseFunctions.ExecuteCommand(command);
    }
    void Print(string REG_RTE_ID)
    {
        
        SqlCommand command = new SqlCommand("TPT_BUS_GET_DATA");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@REG_RTE_ID", REG_RTE_ID);
        command.Parameters.AddWithValue("@PRT_BY", Session["LoginId"].ToString());
        FillFunctions fillFunctions = new FillFunctions();
        
        fillFunctions.Fill(rpt1, command);
       
    }
    }
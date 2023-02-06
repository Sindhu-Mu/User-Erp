using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Academic_prtDetainList : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    DataSet ds = new DataSet();
    DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString.Count > 0)
                lblHeading.Text = Request.QueryString[0].ToString().ToUpper();
            DataSet ds = new DataSet();
            string xmlData = (string)Session["ds"];
            StringReader reader = new StringReader(xmlData);
            ds.ReadXml(reader);
            reader.Close();
            gvDetail.DataSource = ds;
            gvDetail.DataBind();
            foreach (GridViewRow itm in gvDetail.Rows)
            {
                itm.Cells[0].Text = (itm.RowIndex + 1).ToString() + ".";

            }
        }
        catch (Exception ee)
        { ee.Message.ToString(); }


    }
}
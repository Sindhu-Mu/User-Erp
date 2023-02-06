using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class Finance_rptFees : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                DataSet ds = new DataSet();
                string xmlData = (string)Session["ds"];
                StringReader reader = new StringReader(xmlData);
                ds.ReadXml(reader);
                reader.Close();
                if (xmlData.ToString() != "<NewDataSet />")
                {
                    gvDetail.DataSource = ds;
                    gvDetail.DataBind();
                }
                else
                {

                    lblError.Visible = true;
                }
            }
            catch (Exception ee)
            {
                ee.Message.ToString();
            }
        }

    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("FeesDetail.xls", gvDetail);
    }

}
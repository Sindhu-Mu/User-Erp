using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class PayRoll_rptBankDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                gvDetail.DataSource = "";
                gvDetail.DataBind();
                DataSet ds = new DataSet();
                string xmlData = (string)Session["ds"];
                StringReader reader = new StringReader(xmlData);
                ds.ReadXml(reader);
                reader.Close();
                gvDetail.DataSource = ds;
                gvDetail.DataBind();

            }
            catch (Exception ee)
            { ee.Message.ToString(); }
        }

    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("BankDetail.xls", gvDetail);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('../PayRoll/prtDetail?id=" + txtHeading.Text + "',alwaysraised='yes')", true);
        txtHeading.Text = "";
    }
}
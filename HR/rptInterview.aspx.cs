using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class HR_rptInterview : System.Web.UI.Page
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

                    tderror.Style.Add("display", "block");
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
        GridViewExportUtil.Export("InterviewDetail.xls", gvDetail);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtLeave.aspx?id=" + txtHeading.Text + "',alwaysraised='yes')", true);
        txtHeading.Text = "";
    }
}
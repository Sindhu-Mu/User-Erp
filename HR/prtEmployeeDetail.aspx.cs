using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

public partial class HR_prtEmployeeDetail : System.Web.UI.Page
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
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvDetail.DataSource = ds;
                    gvDetail.DataBind();
                }
            }
            catch (Exception ee)
            { ee.Message.ToString(); }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("EmployeeDetail.xls", gvDetail);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtLeave.aspx?id=" + txtHeading.Text + "',alwaysraised='yes')", true);
        txtHeading.Text = "";
    }
}
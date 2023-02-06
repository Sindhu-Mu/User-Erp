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
using System.IO;

public partial class Facility_rptHostel : System.Web.UI.Page
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
                ViewState["Status"] = Request.QueryString[0].ToString();
                if (xmlData.ToString()!="<NewDataSet />")
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
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("HostelDetail.xls", gvDetail);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtFacility.aspx?id=" + txtHeading.Text + "',alwaysraised='yes')", true);
        txtHeading.Text = "";
    }
    protected void gvDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(ViewState["Status"].ToString()=="-1")
        {
            e.Row.BackColor = System.Drawing.Color.AliceBlue;
        }
        if (ViewState["Status"].ToString() == "1")
        {
            e.Row.BackColor = System.Drawing.Color.Aquamarine;
        }
        if (ViewState["Status"].ToString() == "2")
        {
            e.Row.BackColor = System.Drawing.Color.Bisque;
        }
        if (ViewState["Status"].ToString() == "0")
        {
            e.Row.BackColor = System.Drawing.Color.BlueViolet;
        }
    }
}
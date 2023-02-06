using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_StuFinalAtt : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();

        if (!IsPostBack)
        {
            fill.Fill(ddlIns, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fill.Fill(ddlSem, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
            fill.Fill(ddlBatch, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
            fill.FillInteger(30, 90, 5, "%", FillFunctions.FirstItem.Select, ddlPercentage);
        }
    }

    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fill.Fill(ddlPgm, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            fill.Fill(ddlBrn, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        bal.InsId = ddlIns.SelectedValue;
        bal.Pgm_Id = ddlPgm.SelectedValue;
        bal.Brn_Id = ddlBrn.SelectedValue;
        bal.Id = ddlBatch.SelectedValue;
        bal.Semid = ddlSem.SelectedValue;
        bal.Date = (txtDate.Text != "") ? common.GetDateTime(txtDate.Text) : common.GetDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
        bal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = bll.CalculateStuAtt(bal);
        GridViewExportUtil.ExportFromDs("Attendance.xls", ds);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        bal.InsId = ddlIns.SelectedValue;
        bal.Pgm_Id = ddlPgm.SelectedValue;
        bal.Brn_Id = ddlBrn.SelectedValue;
        bal.Id = ddlBatch.SelectedValue;
        bal.Semid = ddlSem.SelectedValue;
        bal.KeyID = ddlPercentage.SelectedValue;
        bal.Value = txtCredit.Text;
        bal.TypeId = ddlType.SelectedValue;
        DataSet ds = bll.CalculateStuAttAfterCredit(bal);
        gvDetain.DataSource = ds;
        gvDetain.DataBind();
        trButton.Visible = true;
        Session["ds"] = ds.GetXml();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("DetainList.xls", gvDetain);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtDetainList.aspx','_blank','resizable=1,width=900,height=650')", true);
  
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        bal.InsId = ddlIns.SelectedValue;
        bal.Pgm_Id = ddlPgm.SelectedValue;
        bal.Brn_Id = ddlBrn.SelectedValue;
        bal.Id = ddlBatch.SelectedValue;
        bal.Semid = ddlSem.SelectedValue;
        bal.KeyID = ddlPercentage.SelectedValue;
        bal.Value = txtCredit.Text;
        bal.TypeId = "2";
        try
        {
            bll.CalculateStuAttAfterCredit(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Credited Successfully!!')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error Occured!!')", true);
        }
    }
}
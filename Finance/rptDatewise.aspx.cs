using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Finance_rptDatewise : System.Web.UI.Page
{
    DataSet ds;
    SFBAL ObjBal;
    SFBLL ObjBll;   
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnReport1.Attributes.Add("onClick", "return Validate()");
        if (!IsPostBack)
        {
            txtFromDate.Text = txtToDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
       
        }
    }
    void Initialize()
    {
       
        ObjBal = new SFBAL();
        ObjBll = new SFBLL();
      
    }
   
    protected void btnReport1_Click(object sender, EventArgs e)
    {

        ObjBal.balDateFrom = txtFromDate.Text;
        ObjBal.balDateTo= txtToDate.Text;
        ds = ObjBll.GetFinanceReportDatewise1(ObjBal);
        GridViewExportUtil.ExportFromDs("FeeDefaulterDetail.xls", ds);
    }
    protected void btnReport2_Click(object sender, EventArgs e)
    {

        ObjBal.balDateFrom = txtFromDate.Text;
        ObjBal.balDateTo = txtToDate.Text;
        ds = ObjBll.GetFinanceReportDatewise2(ObjBal);
        GridViewExportUtil.ExportFromDs("FeeDefaulterDetail.xls", ds);
    }
}
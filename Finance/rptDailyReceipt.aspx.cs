using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Finance_rptDailyReceipt : System.Web.UI.Page
{
    DataSet ds;
    DataTable dt;
    SFBAL ObjBal;
    SFBLL ObjBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        btnShow.Attributes.Add("OnClick", "return Validat()");
        if (!IsPostBack)
        {

            txtForm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillData();
        }

    }
    void Initialise()
    {

        ObjBal = new SFBAL();
        ObjBll = new SFBLL();
        ds = new DataSet();
        dt = new DataTable();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillData();
    }
    void FillData()
    {
        double Total = 0;
        ObjBal.balType = ddlReceiptType.SelectedValue;
        ObjBal.balDateFrom = txtForm.Text;
        ObjBal.balDateTo = txtTo.Text;
        ObjBal.balRcptNo = txtReceiptNo.Text;
        ds = ObjBll.GetDailyReceiptReport(ObjBal);
        GridFeeReceipt.Visible = GridDocReceipt.Visible = lnkPrint.Visible = false;
        //if (ddlReceiptType.SelectedValue == "1")
        //{
            GridFeeReceipt.Visible = true; GridDocReceipt.Visible = false;
            GridFeeReceipt.DataSource = ds;
            GridFeeReceipt.DataBind();
            foreach (GridViewRow itm in GridFeeReceipt.Rows)
            {
                Total += Convert.ToDouble(itm.Cells[6].Text);
            }
            if (GridFeeReceipt.Rows.Count > 0)
            {
                lnkPrint.Visible = true;
                GridFeeReceipt.FooterRow.Cells[5].Text = "Total Amount";
                GridFeeReceipt.FooterRow.Cells[6].Text = Total.ToString("N2");

            }
       // }
        //else
        //{
        //    GridDocReceipt.Visible = true; GridFeeReceipt.Visible = lnkPrint.Visible = false;
        //    GridDocReceipt.DataSource = ds;
        //    GridDocReceipt.DataBind();
        //    foreach (GridViewRow itm in GridDocReceipt.Rows)
        //    {
        //        Total += Convert.ToDouble(itm.Cells[6].Text);
        //    }
        //    if (GridDocReceipt.Rows.Count > 0)
        //    {

        //        GridDocReceipt.FooterRow.Cells[6].Text = Total.ToString("N2");
        //        lnkPrint.Visible = true;
        //    }


        //}


    }

   
    protected void btnNewFormat_Click(object sender, EventArgs e)
    {
        ObjBal.balDateFrom = txtForm.Text;
        ObjBal.balDateTo = txtTo.Text;    
        ds = ObjBll.GetDailyNewReceiptReport(ObjBal);       
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridViewExportUtil.ExportFromDs("NewDailyReceiptReport.xls", ds);

        }
    }
}
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

public partial class Report_rptDailyReport : System.Web.UI.Page
{
 
    FillFunctions fillFunctions;
    CommonFunctions common;
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
            lblSession.Text = DateTime.Now.Year.ToString();
            txtForm.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTo.Text = DateTime.Now.ToString("dd/MM/yyyy");
            FillData();
        }
    }
    void Initialise()
    {
        
        fillFunctions = new FillFunctions();
        common = new CommonFunctions();
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
        double TotalCash = 0;
        double TotalOnline = 0;
        double TotalDD = 0;
        double TotalCheque = 0;
        double TotalChallan = 0;
        double Total = 0;
        ObjBal.balDateFrom = txtForm.Text;
        ObjBal.balDateTo =txtTo.Text;
        ds = ObjBll.GetDailyPaymentReport(ObjBal);
        fillFunctions.Fill(gridSummay, ds.Tables[0]);       
        foreach (GridViewRow itm in gridSummay.Rows)
        {
            itm.Cells[1].HorizontalAlign = HorizontalAlign.Left;
            TotalCash += Convert.ToDouble(itm.Cells[2].Text);
            TotalOnline += Convert.ToDouble(itm.Cells[3].Text);
            TotalDD += Convert.ToDouble(itm.Cells[4].Text);
            TotalCheque += Convert.ToDouble(itm.Cells[5].Text);
            TotalChallan += Convert.ToDouble(itm.Cells[6].Text);
            Total += Convert.ToDouble(itm.Cells[7].Text);
        }        
        if (gridSummay.Rows.Count > 0)
        {
            gridSummay.FooterRow.Cells[1].Text = "Total:-";
            gridSummay.FooterRow.Cells[2].Text = TotalCash.ToString("N2");
            gridSummay.FooterRow.Cells[3].Text = TotalOnline.ToString("N2");
            gridSummay.FooterRow.Cells[4].Text = TotalDD.ToString("N2");
            gridSummay.FooterRow.Cells[5].Text = TotalCheque.ToString("N2");
            gridSummay.FooterRow.Cells[6].Text = TotalChallan.ToString("N2");
            gridSummay.FooterRow.Cells[7].Text = Total.ToString("N2");
        }
        TotalCash=TotalOnline =TotalDD =TotalCheque= TotalChallan= Total=0;
        if (ds.Tables.Count > 1)
        {
            fillFunctions.Fill(gridSummay2, ds.Tables[1]);
            foreach (GridViewRow itm in gridSummay2.Rows)
            {
                itm.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                TotalCash += Convert.ToDouble(itm.Cells[2].Text);
                TotalOnline += Convert.ToDouble(itm.Cells[3].Text);
                TotalDD += Convert.ToDouble(itm.Cells[4].Text);
                TotalCheque += Convert.ToDouble(itm.Cells[5].Text);
                TotalChallan += Convert.ToDouble(itm.Cells[6].Text);
                Total += Convert.ToDouble(itm.Cells[7].Text);

            }
            if (gridSummay2.Rows.Count > 0)
            {
                gridSummay2.FooterRow.Cells[1].Text = "Total:-";
                gridSummay2.FooterRow.Cells[2].Text = TotalCash.ToString("N2");
                gridSummay2.FooterRow.Cells[3].Text = TotalOnline.ToString("N2");
                gridSummay2.FooterRow.Cells[4].Text = TotalDD.ToString("N2");
                gridSummay2.FooterRow.Cells[5].Text = TotalCheque.ToString("N2");
                gridSummay2.FooterRow.Cells[6].Text = TotalChallan.ToString("N2");
                gridSummay2.FooterRow.Cells[7].Text = Total.ToString("N2");
            }
        }
        lnkPrint.Visible = true;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_prntSto_GRN : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    DataSet ds;
    double grandTotal;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        if (Request.QueryString[0].ToString() == "Select")
            return;
        if (Request.QueryString[0].ToString() == "NULL")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Select Valid GRN NO.')", true);          
        }
        else
        {
            trOtherCharges.Visible = false;
            objBal.Typ = "1";
            objBal.ID = Request.QueryString[0].ToString();
            ds = objBll.GetStockGRNReport(objBal);
            lblGRN.Text = ds.Tables[0].Rows[0]["GRN_NO"].ToString();
            lblStore.Text = ds.Tables[0].Rows[0]["STO_NAME"].ToString();
            lblGrnDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["GRN_DATE"]).ToString("dd-MMM-yyyy");
            lblPO.Text = ds.Tables[0].Rows[0]["PO_NO"].ToString();
            lblSupp.Text = ds.Tables[0].Rows[0]["VENDOR_ORG_NAME"].ToString();
            lblBill.Text = ds.Tables[0].Rows[0]["BILL_NO"].ToString();
            lblChall.Text = ds.Tables[0].Rows[0]["CLN_NO"].ToString();
            //lblLedger.Text = ds.Tables[0].Rows[0]["LED_FOLIO_NUM"].ToString();
            lblClerkName.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
            GridView1.DataSource = ds;
            GridView1.DataBind();
            foreach (GridViewRow row in GridView1.Rows)
            {
                //slno++;
                //row.Cells[0].Text = slno.ToString();
                double amt = Convert.ToDouble(row.Cells[10].Text);
                grandTotal += amt;
            }
            if (ds.Tables[0].Rows[0]["PO_DISCOUNT"].ToString() != "0")
            {
                double dis=Convert.ToDouble(ds.Tables[0].Rows[0]["PO_DISCOUNT"].ToString());
                grandTotal = grandTotal-(grandTotal * dis) / 100;
            }
            if (ds.Tables[0].Rows[0]["PO_OTHER_CHARGES"].ToString() != "0")
            {
                grandTotal += Convert.ToDouble(ds.Tables[0].Rows[0]["PO_OTHER_CHARGES"].ToString());
            }

            if (ds.Tables[0].Rows[0]["EXT_CGS"].ToString() != "0")
            {
                trOtherCharges.Visible = true;
                lblOtherCharges.Text = Convert.ToDouble(ds.Tables[0].Rows[0]["EXT_CGS"]).ToString("N2");
                grandTotal += Convert.ToDouble(lblOtherCharges.Text);
                lblNetAmount.Text = grandTotal.ToString("N2");
            }
            lblWord.Text = "Rs." + Convert.ToDouble(Math.Round(grandTotal, 0)).ToString("N0") + "/- (" + ((long)Math.Round(grandTotal, 0)).ToString() + " Only)";
            GridViewRow footer = GridView1.FooterRow;
            footer.Cells[0].ColumnSpan = 10;
            footer.Cells.RemoveAt(9);
            footer.Cells.RemoveAt(8); footer.Cells.RemoveAt(7);
            footer.Cells.RemoveAt(6); footer.Cells.RemoveAt(5);
            footer.Cells.RemoveAt(4); footer.Cells.RemoveAt(3);
            footer.Cells.RemoveAt(2); footer.Cells.RemoveAt(1);
            footer.Cells[0].Text = "Grand Total";
            footer.Cells[1].Text = grandTotal.ToString("N2");
        }
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    
    protected void GridView1_DataBound(object sender, EventArgs e)
    {

    }
}
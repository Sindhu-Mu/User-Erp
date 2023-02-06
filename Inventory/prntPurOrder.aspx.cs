using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_prntPurOrder : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        try
        {
            objBal.ID= Request.QueryString[0];
            DataSet ds = objBll.PrintPurOrder(objBal);
            DataRow dr = ds.Tables[0].Rows[0];
            lblPo.Text = dr["PO_NO"].ToString();
            lblDate.Text = dr["DATE"].ToString();
            lblSuppName.Text = dr["ORG_NAME"].ToString();
            lblSuppAddress.Text = dr["ADD_1"].ToString();
            lblContent.Text = (dr["PO_REF_NO"].ToString() == "0") ? "Verbal Discussion" : "Quotation No-" + dr["PO_REF_NO"].ToString();
            lblGSTIN.Text = (dr["DEPT_ID"].ToString() == "82") ? "09AABAM0146M3ZH" : "09AABAM0146M2ZI";
            ImgLogo.Src = (dr["DEPT_ID"].ToString() == "82") ? "../Siteimages/printmuhospital.png" : "../Siteimages/printlogo.png";
            if (Convert.ToDouble(dr["PO_OTHER_CHARGES"]) > 0)
             {
                 //lblOtherCh.Text = Convert.ToDouble(dr["PO_OTHER_CHARGES"]).ToString("N2");
                 //trOther.Visible = true;
             }
            if (Convert.ToDouble(dr["PO_DISCOUNT"]) > 0)
             {
                 //lblTotalDis.Text = Convert.ToDouble(dr["PO_DISCOUNT"]).ToString("N2");
                 //trOther.Visible = true;
             }
            gvTermCond.DataSource = ds.Tables[1];
            gvTermCond.DataBind();
            gvItem.DataSource = ds.Tables[2];
            gvItem.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
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

    protected void gvItem_DataBound(object sender, EventArgs e)
    {
        double totalAmt = 0;
            foreach (GridViewRow row in gvItem.Rows)
            {
                totalAmt += Convert.ToDouble(row.Cells[6].Text);
            }
            GridViewRow footer = gvItem.FooterRow;
           
                footer.Cells[0].ColumnSpan = 6;
                footer.Cells.RemoveAt(4);
                footer.Cells.RemoveAt(3); footer.Cells.RemoveAt(4);
                footer.Cells.RemoveAt(2); footer.Cells.RemoveAt(1);
                footer.Cells[0].Text = "Total Amount:-";
                footer.Cells[1].Text = totalAmt.ToString("N2");
               // totalAmt = totalAmt - Convert.ToDouble(lblTotalDis.Text);
                //totalAmt = totalAmt + Convert.ToDouble(lblOtherCh.Text);
                lblAmountInWords.Text = "Net Amount:-Rs. " + totalAmt.ToString("N0") + "/- (" + commonFunctions.ConvertNumberToWord(Math.Round(totalAmt, 0)) + " Only)";
    }

   
}
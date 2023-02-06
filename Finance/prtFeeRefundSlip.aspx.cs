using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Finance_prtFeeRefundSlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        double Total = 0;
        double Total1 = 0;
        DatabaseFunctions databasefunction = new DatabaseFunctions();
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        if (Request.QueryString.Count > 0)
        {
            databasefunction = new DatabaseFunctions();
            ds = new DataSet();
            cmd = new SqlCommand();
            cmd.CommandText = "STU_FIN_FEE_REFUND_RECEIPT_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RECEIPT_NO", Request.QueryString[0].ToString());
            ds = databasefunction.GetDataSet(cmd);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblAdmNo.Text = lblADMNo1.Text = lblREG2.Text = ds.Tables[0].Rows[0][0].ToString();
                lblAppName.Text = lblName.Text = lblName2.Text = ds.Tables[0].Rows[0][1].ToString();
                lblIns.Text = lblIns1.Text = lblIns3.Text = ds.Tables[0].Rows[0]["INS_VALUE"].ToString();
                lblCourse.Text = lblCourse1.Text = lblCourse2.Text = ds.Tables[0].Rows[0]["PGM_SHORT_NAME"].ToString();
                lblBranch.Text = lblBranch1.Text = lblBranch2.Text = ds.Tables[0].Rows[0]["BRN_SHORT_NAME"].ToString();
                lbldate.Text = lblDate1.Text = lblDate3.Text = ds.Tables[1].Rows[0]["RECEIPT_DT"].ToString();
                lblSem.Text = lblSem1.Text = lblSem2.Text = ds.Tables[0].Rows[0]["FEE_SEM_NO"].ToString();
                lblRemark1.Text = lblRemark2.Text = lblRemark3.Text = ds.Tables[0].Rows[0]["FEE_RFD_REMARK"].ToString();
                lblReceipt3.Text = lblReceiptNo.Text = lblReceiptNo1.Text = Request.QueryString[0].ToString();
                lblBy1.Text = lblBy2.Text = lblBy3.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
                gvReceive1.DataSource = ds.Tables[1];
                gvReceive1.DataBind();
                foreach (GridViewRow itm in gvReceive1.Rows)
                {
                    Total = Total + Convert.ToDouble(itm.Cells[2].Text);
                }
                gvReceive2.DataSource = ds.Tables[1];
                gvReceive2.DataBind();
                gvReceive3.DataSource = ds.Tables[1];
                gvReceive3.DataBind();
                gvPayMode1.DataSource = ds.Tables[2];
                gvPayMode1.DataBind();
                gvPayMode2.DataSource = ds.Tables[2];
                gvPayMode2.DataBind();
                gvPayMode3.DataSource = ds.Tables[2];
                gvPayMode3.DataBind();
                gvReceive1.FooterRow.Cells[2].Text = Total.ToString("N2");
                gvReceive2.FooterRow.Cells[2].Text = Total.ToString("N2");
                gvReceive3.FooterRow.Cells[2].Text = Total.ToString("N2");
                
                lblNet.Text = databasefunction.ConvertNumberToWord(Total);
                lblNet1.Text = lblNet2.Text = lblNet.Text = lblNet.Text + " Only.";

                gvPayMode1.DataSource = ds.Tables[2];
                gvPayMode1.DataBind();

                foreach (GridViewRow itm1 in gvPayMode1.Rows)
                {
                    Total1 = Total1 + Convert.ToDouble(itm1.Cells[5].Text);
                }
                gvPayMode3.FooterRow.Cells[5].Text = Total1.ToString("N2");
                gvPayMode2.FooterRow.Cells[5].Text = Total1.ToString("N2");
                gvPayMode1.FooterRow.Cells[5].Text = Total1.ToString("N2");
            }
        }
    }
}
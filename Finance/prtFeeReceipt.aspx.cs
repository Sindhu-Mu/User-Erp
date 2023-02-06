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
using System.Text;
public partial class Printing_FeeReceipt : System.Web.UI.Page
{

    SFBAL Objbal;
    SFBLL Objbll;
    StringBuilder strBill;
    DataSet ds;
    DataTable dt;
    DataTable dt1;
    CommonFunctions commfun;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString.Count > 0)
            {
                string str = "";
                strBill = new StringBuilder();
                ds = new DataSet();
                Objbal = new SFBAL();
                Objbll = new SFBLL();
                dt = new DataTable();
                dt1 = new DataTable();
                commfun = new CommonFunctions();
                Objbal.balCommonID = Request.QueryString[0].ToString();
                ds = Objbll.GetStudentFeeReceiptDetails(Objbal);
                dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {

                    strBill.Append("<table style='font-family:Tahoma;font-size:16px;width:100%' cellspacing='0' cellpadding='2'><tr align='center'><th style=' border: black 1px solid;width:20px'>SL#</th>"
                    + "<th style=' border: black 1px solid;width:400px;padding-left:10px' align='left'>Particulars</th>"
                    + "<th style=' border: black 1px solid'> Amount</th>");

                    double netAmt = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        netAmt += Convert.ToDouble(dt.Rows[i]["FEE_RCV_TRAN_AMT"]);
                        strBill.Append("<tr ><td style='padding-left: 10px; padding-right: 10px;border:solid 1px black' align='left'>" + (i + 1) + "</td>"
                         + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black'>" + dt.Rows[i]["FEE_MAIN_HEAD_NAME"].ToString() + "</td>"
                         + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black' align='right'>" + Convert.ToDouble(dt.Rows[i]["FEE_RCV_TRAN_AMT"]).ToString("N2") + "</td>");
                    }
                    //netAmt += Convert.ToDouble(dt.Rows[0]["ADM_TOT_DIS"]);
                    strBill.Append("<tr align='right'><td class='lblbig' colspan='2' style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>Total Fee</td>"
                               + "<td style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>" + netAmt.ToString("N2") + "</td></tr>");
                    //if (Convert.ToDouble(dt.Rows[0]["ADM_TOT_DIS"]) > 0)
                    //{
                    //    strBill.Append("<tr align='right'><td class='lblbig' colspan='2' style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>Discount(Rs)</td>"
                    //                + "<td style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>" + Convert.ToDouble(dt.Rows[0]["ADM_TOT_DIS"]).ToString("N2") + "</td></tr>");
                    //    netAmt -= Convert.ToDouble(dt.Rows[0]["ADM_TOT_DIS"]);
                    //    // Total Amount
                    //    strBill.Append("<tr align='right'><td class='lblbig' colspan='2' style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>Net Amount</td>"
                    //    + "<td style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>" + netAmt.ToString("N2") + "</td></tr></table>");
                    //}
                    //else
                    strBill.Append("</table>");
                    DateTime Date = Convert.ToDateTime(dt.Rows[0]["FEE_DEPOSIT_DT"]);
                    lblNote3.Text = dt.Rows[0]["RECEIPT_NO"].ToString();
                    lblBy1.Text = lblBy2.Text = lblBy3.Text = dt.Rows[0]["EMP_NAME"].ToString();
                    lblAdmNo.Text = lblADMNo1.Text = lblREG2.Text = dt.Rows[0]["ENROLLMENT_NO"].ToString();
                    lblFatherName.Text = lblFatherName1.Text = lblFatherName2.Text = dt.Rows[0]["FATHER_NAME"].ToString();
                    lblDue1.Text = lblDue2.Text = lblDue3.Text = Convert.ToDouble(dt.Rows[0]["FEE_DEMAND_AMT"].ToString()).ToString("N2");
                    lblRemark1.Text = lblRemark2.Text = lblRemark3.Text = dt.Rows[0]["FEE_RCV_REMARK"].ToString();
                    lblCourse.Text = lblCourse1.Text = lblCourse2.Text = dt.Rows[0]["PGM_SHORT_NAME"].ToString();
                    lblBranch.Text = lblBranch1.Text = lblBranch2.Text = dt.Rows[0]["BRN_SHORT_NAME"].ToString();
                    lblName.Text = lblAppName.Text = lblName2.Text = dt.Rows[0]["STU_FULL_NAME"].ToString();
                    lblSem.Text = lblSem1.Text = lblSem2.Text = dt.Rows[0]["FEE_SEM_NO"].ToString();
                    // lblAppNo.Text = lblAppNo1.Text= dt.Rows[0]["APP_NO"].ToString();
                    lbldate.Text = lblDate1.Text = lblDate3.Text = Date.ToString("dd/MM/yyyy hh:mm");
                    lblReceiptNo.Text = lblReceiptNo1.Text = lblReceipt3.Text = dt.Rows[0]["RECEIPT_NO"].ToString();
                    //lblemp_name.Text = gen.getEmpName(Convert.ToInt32(dt.Rows[0]["RECEIVE_BY"]));
                    lblNet.Text = lblNet1.Text = lblNet2.Text = commfun.ConvertNumberToWord(netAmt) + " Only.";
                    trPaid.InnerHtml = strBill.ToString();
                    tdMain.InnerHtml = strBill.ToString();
                    tdMain3.InnerHtml = strBill.ToString();
                    double TotFee = 0; int z = 0;
                    dt1 = ds.Tables[1];
                    if (dt1.Rows.Count > 0)
                    {
                        gvPayMode1.DataSource = dt1;
                        gvPayMode1.DataBind();
                        gvPayMode2.DataSource = dt1;
                        gvPayMode2.DataBind();
                        gvPayMode3.DataSource = dt1;
                        gvPayMode3.DataBind();
                        foreach (GridViewRow itm in gvPayMode1.Rows)
                        {
                            if ((dt1.Rows[itm.RowIndex]["PAY_MODE_ID"].ToString() == "2") || (dt1.Rows[itm.RowIndex]["PAY_MODE_ID"].ToString() == "3"))
                                z = 1;
                            TotFee += Convert.ToDouble(dt1.Rows[itm.RowIndex]["RCV_TRAN_MODE_AMT"]);
                        }
                        if (z == 1)
                            lblNote.Text = lblNote2.Text = lblNote3.Text = "Note:-" + lblNote3.Text + " will be confirmed subject to realisation of Cheque/DD.";
                        else
                            lblNote.Text = lblNote2.Text = lblNote3.Text = "";
                        gvPayMode1.FooterRow.Cells[5].Text = TotFee.ToString("N2");
                        gvPayMode2.FooterRow.Cells[5].Text = TotFee.ToString("N2");
                        gvPayMode3.FooterRow.Cells[5].Text = TotFee.ToString("N2");
                    }
                }
            }
        }
    }

}

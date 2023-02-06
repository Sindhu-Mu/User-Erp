using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class PayRoll_prtBankDetail : System.Web.UI.Page
{
    string forMonth = "";
    string mode = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString.Count > 0)
        {
            mode = Request.QueryString["mode"].ToString();
            forMonth = Request.QueryString["month"].ToString() + " " + Request.QueryString["year"].ToString();
            salReport((DataSet)Session["dt"]);
            //gvDetail.DataSource = (DataSet)Session["dt"];
            // gvDetail.DataBind();
            //lblMonth.Text = ((DataSet)Session["dt"]).Tables[0].Rows[0]["MONTH"].ToString();

            lblMonth.Text = Request.QueryString["month"].ToString() + " " + Request.QueryString["year"].ToString();
            lblDate.Text = "Date:-" + DateTime.Now.ToString("dd-MMM-yyyy");
            //decimal total = 0;
            //foreach (GridViewRow itm in gvDetail.Rows)
            //{
            //    itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            //    total = total + Convert.ToDecimal(itm.Cells[4].Text);
            //}
            //if (Request.QueryString[0].ToString() == "0")
            //    gvDetail.Columns[3].Visible = false;
            //else if (Request.QueryString["mode"].ToString() == "1")
            //    gvDetail.Columns[5].Visible = false;
            //gvDetail.FooterRow.Cells[4].Text = total.ToString("N2");
        }

    }
    public void salReport(DataSet ds)
    {
        DataTable dt = new DataTable();
        dt = ds.Tables[0];

        StringBuilder str = new StringBuilder();
        if (mode.Equals("1"))
        {
            str.Append("<table class='salrpt'><tr><th class='sr_no'>Sr No.</th><th class='emp_code'>Emp Code</th><th class='name'>Name</th><th class='acc_no'>Account No.</th><th class='pay'>Amt Pay</th></tr>");
        }
        else
        {
            str.Append("<table class='salrpt'><tr><th class='sr_no'>Sr No.</th><th class='emp_code'>Emp Code</th><th class='name'>Name</th><th class='pay'>Amt Pay</th><th class='acc_no'>Signature</th></tr>");
        }
        String code = "";
        String name = "";
        String acc = "";
        String amt = "";
        decimal allrecords = 0;
        int count = 0;
        decimal total = 0;
        decimal grand_total = 0;
        int row_number = 0;
        foreach (DataRow row in dt.Rows)
        {
            row_number++;
            allrecords++;
            code = row[0].ToString();
            name = row[1].ToString();
            acc = row["Account Number"].ToString();
            //amt=string.Format("{0:0.00}", row[5].ToString());
            amt = row[5].ToString();
            total = total + Convert.ToDecimal(amt);
            if (mode.Equals("1"))
            {
                str.Append("<tr> <td>" + ++count + "</td> <td class='emp_code'>" + code + "</td> <td>" + name + "</td> <td class='acc'>" + acc + "</td> <td class='right'>" + amt + "</td></tr>");
                if (row_number == 20 || dt.Rows.Count == allrecords)
                {
                    //str.Append("<p class='heading'>Salary For the Month of " + forMonth +"<p><hr/>");
                    str.Append("<tr> <td></td> <td></td> <td></td> <td><b>Total</b></td> <td class='right'><b>" + total + "</b></td></tr>");
                    grand_total = grand_total + total;
                    total = 0;
                    if (dt.Rows.Count != allrecords)
                    {
                        str.Append("</table><hr class='pagebreak'/><p class='heading'>Salary For the Month of " + forMonth + "<p><hr/><table class='salrpt'><tr><th class='sr_no'>Sr No.</th><th class='emp_code'>Emp Code</th><th class='name'>Name</th><th class='acc_no'>Account No.</th><th class='pay'>Amt Pay</th></tr>");
                    }
                    row_number = 0;
                }

            }
            else
            {
                str.Append("<tr> <td>" + ++count + "</td> <td class='emp_code'>" + code + "</td> <td>" + name + "</td><td class='right'>" + amt + "</td><td class='acc'></td> </tr>");
                if (count == 20 || dt.Rows.Count == allrecords)
                {
                    //str.Append("<p class='heading'>Salary For the Month of " + forMonth +"<p><hr/>");
                    str.Append("<tr> <td></td> <td></td>  <td><b>Total</b></td> <td class='right'><b>" + total + "</b></td><td></td></tr>");
                    grand_total = grand_total + total;
                    total = 0;
                    if (dt.Rows.Count != allrecords)
                    {
                        str.Append("</table><hr class='pagebreak'/><p class='heading'>Salary For the Month of " + forMonth + "<p><hr/><table class='salrpt'><tr><th class='sr_no'>Sr No.</th><th class='emp_code'>Emp Code</th><th class='name'>Name</th><th class='pay'>Amt Pay</th><th class='acc_no'>Signature</th></tr>");
                    }
                }
            }
            lblGrandTotal.Text = Convert.ToString(grand_total);
            lblTotalEmp.Text = Convert.ToString(allrecords);

        }

        //str.Append("</table>");
        rpt.InnerHtml = str.ToString();
        allrecords = 0;
    }

}
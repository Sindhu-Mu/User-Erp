using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using System.Data;

public partial class Finance_prtExamRegFee : System.Web.UI.Page
{
    DatabaseFunctions databaseFunction;
    CommonFunctions commonFunction;
    StringBuilder strBill;
    DataTable dt;
    DataSet ds;
    SFBLL ObjBll;
    SFBAL ObjBal;

    void intialise()
    {
        databaseFunction = new DatabaseFunctions();
        commonFunction = new CommonFunctions();
        strBill = new StringBuilder();
        ds = new DataSet();
        dt = new DataTable();
        ObjBal = new SFBAL();
        ObjBll = new SFBLL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        intialise();
        strBill.Append("<table style='font-family:Tahoma;font-size:14px;width:100%;border-collapse: collapse'><tr align='center'><th style=' border: black 1px solid;width:20px'>SL#</th>"
        + "<th style=' border: black 1px solid;width:250px;padding-left:10px' align='left'>Course Code</th><th style=' border: black 1px solid;padding-left:10px' align='left'>Reg. Type</th>"
        + "<th style=' border: black 1px solid'> Amount</th>");
        ObjBal.balRcvId = Request.QueryString[0].ToString();
        ds = ObjBll.GetFeeDetail(ObjBal);
        double netAmt = 0;
        lblExam.Text =lblExam1.Text=lblExam2.Text= ds.Tables[0].Rows[0]["EXAM_NAME"].ToString();
        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
        {

            strBill.Append("<tr ><td style='padding-left: 10px; padding-right: 10px;border:solid 1px black' align='left'>" + (i + 1) + "</td>"
                      + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black'>" + ds.Tables[1].Rows[i]["CRS_CODE"].ToString() + "</td>"
                        + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black'>" + ds.Tables[1].Rows[i]["CRS_REG_TYPE"].ToString() + "</td>"
                      + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black' align='right'>" + ds.Tables[1].Rows[i]["CRS_FEE"].ToString() + "</td></tr>");
        }
        strBill.Append("<tr align='right'><td class='lblbig' colspan='3' style='padding-left: 10px; padding-right: 10px;border:solid 1px black'>Demand Amount(Rs)</td>"
         + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black' align='right'>" + ds.Tables[0].Rows[0]["DEMAND_AMT"].ToString() + "</td>");

        if(ds.Tables[0].Rows[0]["FINE_AMT"].ToString()!="0.00")
        strBill.Append("<tr align='right'><td class='lblbig' colspan='3' style='padding-left: 10px; padding-right: 10px;border:solid 1px black'>Fine Amount(Rs)</td>"
             + "<td style='padding-left: 10px; padding-right: 10px;border:solid 1px black' align='right'>" + ds.Tables[0].Rows[0]["FINE_AMT"].ToString() + "</td>");
        if (ds.Tables[0].Rows[0]["DISCOUNT_AMT"].ToString() != "0.00")
        strBill.Append("<tr align='right'><td class='lblbig' colspan='3' style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>Discount Amount(Rs)</td>"
            + "<td style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>" + ds.Tables[0].Rows[0]["DISCOUNT_AMT"].ToString() + "</td></tr>");

        strBill.Append("<tr align='right'><td class='lblbig' colspan='3' style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>Hostel Amount(Rs)</td>"
                    + "<td style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>" + ds.Tables[0].Rows[0]["HOSTEL_AMT"].ToString() + "</td></tr>");
        netAmt = Convert.ToDouble(ds.Tables[0].Rows[0]["HOSTEL_AMT"]);

        strBill.Append("<tr align='right'><td class='lblbig' colspan='3' style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>Receive Amount(Rs)</td>"
                    + "<td style='padding-left: 10px; padding-right: 10px; border: black 1px solid'>" + ds.Tables[0].Rows[0]["RECIEVE_AMT"].ToString() + "</td></tr>");
        netAmt = Convert.ToDouble(ds.Tables[0].Rows[0]["RECIEVE_AMT"]);

        strBill.Append("</table>");
        Tdtab.InnerHtml = tdtab1.InnerHtml = tdtab2.InnerHtml = strBill.ToString();        
        lblBy.Text = lblBy1.Text = lblBy2.Text = ds.Tables[0].Rows[0]["EMP_NAME"].ToString();
        lblEnrol.Text = lblEnrol1.Text = lblEnrol2.Text = ds.Tables[0].Rows[0]["ENROLLMENT_NO"].ToString();
        lblRemark.Text = lblRemark1.Text = lblRemark2.Text = ds.Tables[0].Rows[0]["BACK_FEE_RCV_RMK"].ToString();
        lblCourse.Text = lblCourse1.Text = lblCourse2.Text = ds.Tables[0].Rows[0]["PGM_SHORT_NAME"].ToString();
        lblBranch.Text = lblBranch1.Text = lblBranch2.Text = ds.Tables[0].Rows[0]["BRN_SHORT_NAME"].ToString();
        lblName.Text = lblName1.Text = lblName2.Text = ds.Tables[0].Rows[0]["Stu_Full_Name"].ToString();
        lbldate.Text = lblDate1.Text = lblDate2.Text = ds.Tables[0].Rows[0]["BACK_FEE_RCV_DT"].ToString();
        lblReceiptNo.Text = lblReceiptNo1.Text = lblReceiptNo2.Text = ds.Tables[0].Rows[0]["RECIEPT_NO"].ToString();
    }
}
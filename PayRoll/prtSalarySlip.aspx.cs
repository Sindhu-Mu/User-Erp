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
using System.Data.OleDb;
using System.IO;
using System.Text;

public partial class PayRoll_prtSallarySlip : System.Web.UI.Page
{
    DatabaseFunctions objGen = new DatabaseFunctions();
    //CGenFunctions genfun = new CGenFunctions();
    StringBuilder strBldr = new StringBuilder();
    string mm, yy, strSql,emp;
    DataTable dt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {


        Page.Title = "Welcome to MangalDarpan | SALARY SLIP";
       
        if (Request.QueryString.Count == 0) return;

       emp = Request.QueryString[0].ToString().Split('-').GetValue(2).ToString();
        mm = Request.QueryString[0].ToString().Split('-').GetValue(0).ToString();
        yy = Request.QueryString[0].ToString().Split('-').GetValue(1).ToString();
        DateTime curDate = new DateTime(Convert.ToInt32(yy), Convert.ToInt32(mm), 1);
        if (!IsPostBack)
        {
            tblPay.Visible = false;
            try
            {
                //Set the Month
                strBldr.Remove(0, strBldr.Length);

                strBldr.Append("<span style='font-size: 13pt'> P A Y&nbsp; S L I P </span><br /><i><b><font face='Times New Roman'>for the month ending " + curDate.ToString("MMMM") + ", " + yy + "</font></b></i><br /><br />&nbsp;");
                SlipMonth.InnerHtml = strBldr.ToString();

                //Set the employee Information
                strSql = "SELECT EMP_NAME,DES_VALUE,DEPT_VALUE,ACC_NO,'' AS EMP_TYPE,BANK_VALUE,ACC_NO,PAN_NO,'' AS EPF_NO FROM EMP_VIEW where EMP_ID=" + emp;
                dt = objGen.GetDataSetByQuery(strSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    lblEmplCode.Text = emp;
                    lblEmpName.Text = dt.Rows[0]["EMP_NAME"].ToString();
                    lblDepartment.Text = dt.Rows[0]["DEPT_VALUE"].ToString();
                    lblDesignation.Text = dt.Rows[0]["DES_VALUE"].ToString();
                    lblBanckACNo.Text = dt.Rows[0]["ACC_NO"].ToString();
                    //lblEmpType.Text = dt.Rows[0]["EMP_TYPE"].ToString();
                    lblBank.Text = dt.Rows[0]["BANK_VALUE"].ToString();
                    lblPan.Text = dt.Rows[0]["PAN_NO"].ToString();
                    lblNoOfDays.Text = DateTime.DaysInMonth(Convert.ToInt32(yy), Convert.ToInt32(mm)).ToString();
                    lblEPFNo.Text = dt.Rows[0]["EPF_NO"].ToString();
                }
                else
                    throw new Exception("Employee Information Not found.");
                hfParam.Value = "eCode=" + lblEmplCode.Text + "&dt=" + curDate.ToString();
                mmm.Value = mm.ToString();
                yym.Value = yy.ToString();
                DataSet myDataset = new DataSet();
                string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
                    + Server.MapPath("../Common/SALARY-" + yy + ".xls") + ";"
                    + "Extended Properties=Excel 8.0;";

                strSql = "SELECT * FROM [" + mm + "-" + yy + "$A1:IU] WHERE [EMPL_CODE]=" + emp;

                OleDbDataAdapter myData = new OleDbDataAdapter(strSql, strConn);
                myData.TableMappings.Add("Table", "ExcelTest");
                myData.Fill(myDataset);
                dt = myDataset.Tables[0];
                //dt = objGen.execute_dataset("tr", strSql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    string ss = "";
                    tblPay.Visible = true;
                    lblNoOfDays.Text = dt.Rows[0]["DAYS"].ToString();



                    // Earnings
                    strBldr.Remove(0, strBldr.Length);
                    strBldr.Append("<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; font-family: Tahoma; font-size: 11px'>");
                    int i = 2;
                    for (; i < dt.Columns.Count; i++)
                    {
                        string strBank = lblBank.Text;
                        double amt = 0;
                        if (dt.Columns[i].Caption.ToString() == "Performance Based Incentive")
                        {
                            if ((dt.Rows[0][i] != DBNull.Value) && (dt.Rows[0][i].ToString() != "0"))
                                lblRemark.Text = "<b>Performance Based Incentive: </b>" + dt.Rows[0][i].ToString() + " <br/>transferred to employees A/c with " + strBank + "";
                            if (dt.Rows[0][i] != DBNull.Value)
                            {
                                amt = Convert.ToDouble(dt.Rows[0][i]);
                                if (amt > 0)
                                {
                                    if (dt.Columns[i].Caption.Trim().ToUpper() == "TOTAL EARNING")
                                    {
                                        totear.InnerHtml = amt.ToString("N2");
                                        break;
                                    }
                                    ss += "<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + dt.Columns[i].Caption + "</td><td height='20' width='20%' align='right' style='padding-right:20px'>" + amt.ToString("N2") + "</td></tr>";

                                }
                                if ((dt.Columns[i].Caption.Trim() == "Dearness Pay") && (amt == 0))
                                {
                                    ss = ss.Replace("Basic", "Consolidate");
                                }

                            }
                        }
                        strBldr.Append(ss);
                        strBldr.Append("</table>");

                        ear.InnerHtml = strBldr.ToString();
                    }

                    //DEDUCTIONS
                    strBldr.Remove(0, strBldr.Length);
                    strBldr.Append("<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; font-family: Tahoma; font-size: 11px; '>");

                    for (i++; i < dt.Columns.Count; i++)
                    {
                        double amt = 0;
                        if (dt.Rows[0][i] != DBNull.Value)
                        {
                            amt = Convert.ToDouble(dt.Rows[0][i]);
                            if (amt > 0)
                            {

                                if (dt.Columns[i].Caption.Trim().ToUpper() == "TOTAL DEDUCTION")
                                {
                                    totded.InnerHtml = amt.ToString("N2");
                                    break;
                                }

                                if (dt.Columns[i].Caption.Trim().ToUpper() == "ELECTRICITY")
                                    strBldr.Append("<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + dt.Columns[i].Caption + "</td><td height='20' width='20%' align='right' style='padding-right:20px'><a href='#' onclick='popElectricity()'>" + amt.ToString("N2") + "</a></td></tr>");
                                else if (dt.Columns[i].Caption.Trim().ToUpper() != "NET PAY")
                                    strBldr.Append("<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + dt.Columns[i].Caption + "</td><td height='20' width='20%' align='right' style='padding-right:20px'>" + amt.ToString("N2") + "</td></tr>");

                            }
                        }
                    }
                    strBldr.Append("</table>");
                    ded.InnerHtml = strBldr.ToString();


                    //NET PAY (PAYROLL CLEARANCE)

                    string strBankName = lblBank.Text;

                    double BG = dt.Rows[0]["NET PAY"] != DBNull.Value ? Convert.ToDouble(dt.Rows[0]["NET PAY"]) : 0;
                    if (BG != 0)
                        netSal.InnerHtml = "<b>NET PAY: [A] - [B] = Rs. " + BG.ToString("N2") + "</b><br />transferred to employees A/c with " + strBankName;


                }
                else
                {
                    tblPay.Visible = false;
                    lblMsg.Text = "No record found";
                }
            }
            catch (Exception ex)
            {
                lblMsg.Text = ex.Message;
                tblPay.Visible = false;
            }

        }
    }
}
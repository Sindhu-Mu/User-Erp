using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class PayRoll_SalarySlip : System.Web.UI.Page
{
    DataTable dt;
    PRBLL prbll;
    PRBAL prbal;
    StringBuilder strBldr;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialization();
        btnPrint.Attributes.Add("onClick", "return validat()");
        //((HtmlControl)Master.FindControl("tdEmpCtrl")).Visible = true;
        //TextBox txtEmployee = (TextBox)Master.FindControl("txtEmployee");
        if (!IsPostBack)
        {
            //txtEmp.Text = Session["UserName"].ToString() +":" + Session["LoginId"].ToString();
            //txtEmp.Focus();
          //  ShowSalarySlip(txtEmp.Text.Split(':').GetValue(1).ToString());
           // ViewState["EMPCODE"] = txtEmp.Text.Split(':').GetValue(1).ToString();
        }
        else
        {
            if (txtEmp.Text != "")
            {
                try
                {
                   // ViewState["EMPCODE"] = txtEmp.Text.Split(':').GetValue(1).ToString();
                  //  ShowSalarySlip(txtEmp.Text.Split(':').GetValue(1).ToString());
                  // txtEmp.Text = "";
                }
                catch
                { }
            }

        }
    }
    private void Initialization()
    {
        cf = new CommonFunctions();
        dt = new DataTable();
        prbll = new PRBLL();
        prbal = new PRBAL();
        strBldr = new StringBuilder();
    }
    protected void ShowSalarySlip(string emplCode)
    {

        DropDownList ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
        int mm = Convert.ToInt32(ddlMonth.SelectedValue);
        int yy = Convert.ToInt32(ddlYear.SelectedValue != "" ? ddlYear.SelectedValue : DateTime.Today.Year.ToString());

        DateTime curDate = new DateTime(yy, mm, 1);
        try
        {
           
            //DataShow.Visible = true;
            ////Set the employee Information
            //prbal.balEmpCode = emplCode;
            //dt = prbll.getEmpInfo(prbal);
            //if (dt.Rows.Count > 0)
            //{
             
            //}
            //else
            //    throw new Exception("Employee Information Not found.");
            //DataSet myDataset = new DataSet();
            //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source="
            //    + Server.MapPath("../common/SALARY-" + yy + ".xls") + ";"
            //    + "Extended Properties=Excel 8.0;";
            //strSql = "SELECT * FROM [" + mm + "-" + yy + "$] WHERE [EMPL_CODE]=" + emplCode;
            //OleDbDataAdapter myData = new OleDbDataAdapter(strSql, strConn);
            //myData.TableMappings.Add("Table", "ExcelTest");
            //myData.Fill(myDataset);
            //dt = myDataset.Tables[0];
            ////dt = objGen.execute_dataset("tr", strSql).Tables[0];
            //string m_rmk = "";
            //if (dt.Rows.Count > 1)
            //    m_rmk = "";
            //DataShow.DataSource = dt;
            //DataShow.DataBind();
            //foreach (DataListItem itm in DataShow.Items)
            //{
            //    string ss = "";
            //    if (dt.Rows.Count > 0)
            //    {
            //        HtmlTable tblPay = new HtmlTable();
            //        tblPay = (HtmlTable)DataShow.Items[itm.ItemIndex].FindControl("tblPay");
            //        tblPay.Visible = true;
            //        Label aLabel = new Label();
            //        aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblNoOfDays");
            //        aLabel.Text = dt.Rows[itm.ItemIndex]["DAYS"].ToString();

            //        DataTable dtt = new DataTable();
            //        prbal.balEmpCode = emplCode;
            //        dtt = prbll.getEmpInfo(prbal);
            //        if (dtt.Rows.Count > 0)
            //        {
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblEPFNo");
            //            //aLabel.Text = dtt.Rows[itm.ItemIndex]["EPF_NO"].ToString();
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblEmplCode");
            //            //aLabel.Text = emplCode;
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblEmpName");
            //            //aLabel.Text = dtt.Rows[0]["EMP_NAME"].ToString();
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblDepartment");
            //            //aLabel.Text = dtt.Rows[0]["DEPT_NAME"].ToString();
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblDesignation");
            //            //aLabel.Text = dtt.Rows[0]["DESIG_NAME"].ToString();
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblBanckACNo");
            //            //aLabel.Text = dtt.Rows[0]["BANK_AC_NO"].ToString();
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblBankName");
            //            //aLabel.Text = dtt.Rows[0]["BANK_NAME"].ToString();
            //            //aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblPAN");
            //            //aLabel.Text = dtt.Rows[0]["PAN_NO"].ToString();
            //        }
            //        // Earnings
            //        strBldr.Remove(0, strBldr.Length);
            //        strBldr.Append("<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; font-family: Tahoma; font-size: 11px'>");
            //        int i = 2;
            //        for (; i < dt.Columns.Count; i++)
            //        {
            //            double amt = 0;
            //            if (dt.Columns[i].Caption.ToString() == "Performance Based Incentive")
            //            {
            //                if ((dt.Rows[0][i] != DBNull.Value) && (dt.Rows[0][i].ToString() != "0"))
            //                {
            //                    aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblRemark");
            //                    aLabel.Text = "<b>Performance Based Incentive: </b>" + dt.Rows[0][i].ToString();
            //                }
            //                continue;
            //            }
            //            if (dt.Rows[itm.ItemIndex][i] != DBNull.Value)
            //            {
            //                amt = Convert.ToDouble(dt.Rows[itm.ItemIndex][i]);
            //                if (amt > 0)
            //                {
            //                    if (dt.Columns[i].Caption.Trim().ToUpper() == "TOTAL EARNING")
            //                    {
            //                        HtmlTableCell totear = new HtmlTableCell();
            //                        totear = (HtmlTableCell)DataShow.Items[itm.ItemIndex].FindControl("totear");
            //                        totear.InnerHtml = amt.ToString("N2");
            //                        break;

            //                    }
            //                    ss += "<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + dt.Columns[i].Caption + "</td><td height='20' width='20%' align='right' style='padding-right:20px'>" + amt.ToString("N2") + "</td></tr>";
            //                }
            //                if ((dt.Columns[i].Caption.Trim() == "Dearness Pay") && (amt == 0))
            //                {
            //                    ss = ss.Replace("Basic", "Consolidate");
            //                }
            //            }
            //        }
            //        strBldr.Append(ss);
            //        strBldr.Append("</table>");
            //        HtmlTableCell ear = new HtmlTableCell();
            //        ear = (HtmlTableCell)DataShow.Items[itm.ItemIndex].FindControl("ear");
            //        ear.InnerHtml = strBldr.ToString();


            //        //DEDUCTIONS
            //        strBldr.Remove(0, strBldr.Length);
            //        strBldr.Append("<table border='0' width='100%' cellpadding='0' style='border-collapse: collapse; font-family: Tahoma; font-size: 11px; '>");

            //        for (i++; i < dt.Columns.Count; i++)
            //        {
            //            double amt = 0;
            //            if (dt.Rows[itm.ItemIndex][i] != DBNull.Value)
            //            {
            //                amt = Convert.ToDouble(dt.Rows[itm.ItemIndex][i]);
            //                if (amt > 0)
            //                {
            //                    if (dt.Columns[i].Caption.Trim().ToUpper() == "TOTAL DEDUCTION")
            //                    {
            //                        HtmlTableCell totded = new HtmlTableCell();
            //                        totded = (HtmlTableCell)DataShow.Items[itm.ItemIndex].FindControl("totded");
            //                        totded.InnerHtml = amt.ToString("N2");
            //                        break;

            //                    }
            //                    else if (dt.Columns[i].Caption.Trim().ToUpper() != "NET PAY")
            //                        strBldr.Append("<tr><td height='20' width='30%' align='left' style='padding-left:20px'>" + dt.Columns[i].Caption + "</td><td height='20' width='20%' align='right' style='padding-right:20px'>" + amt.ToString("N2") + "</td></tr>");
            //                }
            //            }
            //        }
            //        strBldr.Append("</table>");
            //        HtmlTableCell ded = new HtmlTableCell();
            //        ded = (HtmlTableCell)DataShow.Items[itm.ItemIndex].FindControl("ded");
            //        ded.InnerHtml = strBldr.ToString();


            //        double BG = dt.Rows[itm.ItemIndex]["NET PAY"] != DBNull.Value ? Convert.ToDouble(dt.Rows[itm.ItemIndex]["NET PAY"]) : 0;
            //        if (BG != 0)
            //        {
            //            HtmlTableCell netSal = new HtmlTableCell();
            //            netSal = (HtmlTableCell)DataShow.Items[itm.ItemIndex].FindControl("netSal");
            //            aLabel = (Label)DataShow.Items[itm.ItemIndex].FindControl("lblBankName");
            //            netSal.InnerHtml = "<b>NET PAY: [A] - [B] = Rs. " + BG.ToString("N2") + "</b><br />" + ((aLabel.Text.Trim() != "") ? "transferred to employees A/c with " + aLabel.Text : "");

            //        }
            //        btnPrint.Visible = true;

            //    }
            //    else
            //    {
            //        HtmlTable tblPay = new HtmlTable();
            //        tblPay = (HtmlTable)DataShow.Items[itm.ItemIndex].FindControl("tblPay");
            //        tblPay.Visible = false;
            //        lblMsg.Text = "No record found";
            //    }
            //}
        }
        catch (Exception ex)
        {
            lblMsg.Text = ex.Message;
            //tblPay.Visible = false;      
            DataShow.Visible = false;
        }

    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
        string mmyy = ddlMonth.SelectedValue + "-" + ddlYear.SelectedValue + "-"+cf.GetKeyID(txtEmp) ;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('../Common/PrintSalarySlip.aspx?" + mmyy + "','_blank','width=575, scrollbars=1, left=100')", true);
    }
}
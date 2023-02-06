using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

public partial class Finance_prtStudnetLeadger : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Welcome to MangalDarpan | Fee Report";

        if (Request.QueryString.Count > 0)
        {
            DatabaseFunctions databaseFunctions = new DatabaseFunctions();
            string table;
            StringBuilder strBldr = new StringBuilder();
            int s = 1;
            double amt, debit, credit;
            amt = debit = credit = 0;

            SqlCommand command = new SqlCommand("STU_REPORT_SELECT1");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@ENROLLMENT_NO", Request.QueryString[0].ToString());
            DataTable datatable = databaseFunctions.GetDataSet(command).Tables[0];

            if (datatable.Rows.Count > 0)
            {
                DataRow datarow = datatable.Rows[0];
                lblEnrollmentNo.Text = Request.QueryString[0].ToString();
                lblSName.Text = datarow[0].ToString();
                lblFName.Text = datarow[1].ToString();
                lblDate.Text = datarow[2].ToString();
                lblIns.Text = datarow[3].ToString();
                lblCourse.Text = datarow[4].ToString();
                lblBranch.Text = datarow[5].ToString();
                lblAdmNo.Text = datarow[8].ToString();
                // lblSec.Text = datarow[7].ToString();               
                lblSem.Text = datarow[12].ToString();
                lblAddress.Text = datarow[9].ToString();
                lblCity.Text = datarow[10].ToString() + "," + datarow[11].ToString();
                // lblSession.Text = datarow[13].ToString();


            }
            SqlCommand cmd = new SqlCommand("STU_FIN_FEE_INF_SELECT2");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ENROLLMENT_NO", Request.QueryString[0].ToString());
            //cmd.Parameters.AddWithValue("@FEE_SEM_NO", Request.QueryString[1].ToString());
            DataTable dt = new DataTable();
            dt = databaseFunctions.GetDataSet(cmd).Tables[0];
            table = "<table cellspacing='0' cellpadding='2' border='0' style='font-family:Arial;font-size:13px;width:100%;'>";
            table += "<tr><th valign='top'>Payment Detail<hr color='black' noshade='noshade' size='1' /></th></tr>";
            table += "<tr><td valign='top'><table rules='cols' cellpadding='2' cellspacing='0' style='width:100%;border: black 1px solid;'><tr>";
            table += "<th  style='border:black 1px solid;width:80px'>S#</th><th  style='border:black 1px solid;'>Date</th><th  style='border:black 1px solid;width:280px'>Transaction  </th><th  style='border:black 1px solid;width:80px'>Ref#</th><th  style='border:black 1px solid;width:100px'>Demand Amount</th><th  style='border:black 1px solid;width:100px'>Received Amount</th><th  style='border:black 1px solid;width:100px'>Balance Amount</th><th  style='border:black 1px solid;'>Sem</th><th  style='border:black 1px solid;'>Entry By</th><th   style='border:black 1px solid;'>Narration</th></tr>";
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                if (dt.Rows[j]["ID"].ToString() == "1")
                {
                    credit += Convert.ToDouble(dt.Rows[j]["AMOUNT"].ToString());
                    amt += Convert.ToDouble(dt.Rows[j]["AMOUNT"].ToString());
                    table += "<tr  style='border:1px solid black;'><td style='width:80px'>" + s + "</td><td style='width:100px;'>" + dt.Rows[j]["ENTRY_DATE"] + " </td><td style='width:280px'>" + dt.Rows[j]["DETAIL"].ToString() + "</td><td style='width:80px'>" + dt.Rows[j]["REF_NO"].ToString() + "</td><td >" + dt.Rows[j]["AMOUNT"].ToString() + " </td><td >0</td>"
                        + "<td >" + amt.ToString("N2") + "</td><td style='width:150px;'>" + dt.Rows[j]["SEM_NO"] + " </td><td style='width:150px;'>" + dt.Rows[j]["IN_BY"] + " </td><td style='width:150px;'>" + dt.Rows[j]["REMARK"] + " </td></tr>";
                    s += 1;
                }

                if (dt.Rows[j]["ID"].ToString() == "2")
                {
                    debit += Convert.ToDouble(dt.Rows[j]["AMOUNT"].ToString());
                    amt -= Convert.ToDouble(dt.Rows[j]["AMOUNT"].ToString());
                    table += "<tr style='border:1px solid black;'><td style='width:80px'>" + s + "</td><td style='width:100px;'>" + dt.Rows[j]["ENTRY_DATE"] + " </td><td style='width:280px'>" + dt.Rows[j]["DETAIL"].ToString() + "</td><td style='width:80px'>" + dt.Rows[j]["REF_NO"].ToString() + "</td><td>0</td><td> " + dt.Rows[j]["AMOUNT"].ToString() + " </td>"
                        + "<td>" + amt.ToString("N2") + "</td><td style='width:150px;'>" + dt.Rows[j]["SEM_NO"] + " </td><td style='width:150px;'>" + dt.Rows[j]["IN_BY"] + " </td><td style='width:150px;'>" + dt.Rows[j]["REMARK"] + " </td></tr>";
                    s += 1;
                }
            }
            table += "<tr><td style='width:80px'>&nbsp;</td><td style='width:280px'>&nbsp;</td><td style='width:80px'>&nbsp;</td><td><hr/><B>Total<B></td><td><hr/>" + credit.ToString("N2") + "</td><td><hr/> " + debit.ToString("N2") + " </td>"
                        + "<td><hr/>" + amt.ToString("N2") + "</td><td style='width:80px'>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";

            table += "</table>";
            table += " </td></tr></table>";
            strBldr.Append(table);
            tdMain.InnerHtml = strBldr.ToString();

        }
   

    }
}
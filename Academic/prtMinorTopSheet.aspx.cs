using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Text;
public partial class Acedamic_prtMinorTopSheet : System.Web.UI.Page
{
    DataTable dt;
    StringBuilder strBldr;
    string strb;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        dt = new DataTable();
        dt = (DataTable)Session["dt"];
        if (dt.Rows.Count > 0)
        {

            lblIns.Text = dt.Rows[0]["INS_DESC"].ToString();
            lblSesstion.Text = dt.Rows[0]["EXAM_NAME"].ToString();
            strb = "<table cellspacing='0' border='0' style='font-size:10pt;width:100%;margin-left:10px'><tr><td>";
            string Branch = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Branch != dt.Rows[i]["PGM_BRN_ID"].ToString())
                {
                    if ((Branch != "") && (Branch != dt.Rows[i]["PGM_BRN_ID"].ToString()))
                        strb += "</table></tr></td></table>";
                    strb += "<table  style='width:690px'><tr><td  Colspan='3'  style='font-weight:bold' >Programme :-" + dt.Rows[i]["PGM_SHORT_NAME"].ToString() + "(" + dt.Rows[i]["BRN_SHORT_NAME"].ToString() + ")</td></tr>";
                    strb += "<tr><td Colspan='3'><table cellspacing='0' border='1' style='width:100%'><tr>";
                    strb += "<th style='width:15px'>S.NO.</th><th style='width:100px'>ENROLLMENT</th><th >STUDENT NAME</th><th style='width:50px'>SEM</th><th style='width:200px'>REMARK</th></tr>";
                    Branch = dt.Rows[i]["PGM_BRN_ID"].ToString();
                }
                strb += "<tr style='height:20px'>";
                strb += "<td >" + (i + 1).ToString() + "</td><td >" + dt.Rows[i]["ENROLLMENT_NO"].ToString() + "</td><td>" + dt.Rows[i]["STU_FULL_NAME"].ToString() + "</td>";
                strb += "<td style='text-align: center;'>" + dt.Rows[i]["ACA_SEM_ID"].ToString() + "</td><td style='width:150px'>&nbsp;</td></tr>";

            }
            strb += "</tr></td></table>";
            strBldr.Append(strb);
            tdMain.InnerHtml = strBldr.ToString();
        }
    }
    void Initialize()
    {
        dt = new DataTable();
        strBldr = new StringBuilder();

    }
}
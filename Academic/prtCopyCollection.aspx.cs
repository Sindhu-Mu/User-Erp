using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;


public partial class Academic_prtCopyCollection : System.Web.UI.Page
{
    DatabaseFunctions databasefuncation;
    DataTable dt;
    StringBuilder strBldr;
    AcaBAL objBal;
    AcaBLL objBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        databasefuncation = new DatabaseFunctions();
        dt = new DataTable();
        SqlDataReader dr;
        strBldr = new StringBuilder();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        int Count;
        if (!IsPostBack)
        {
            dt = (DataTable)Session["dt"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Count = 0;
                strBldr.Append("<table cellspacing='0' border='0' style='font-size:10pt;width:100%;'>" +
                 "<tr><td align='center' style='font-weight:bold' valign='top' colspan='3'><span style='font-size: 12pt'>MANGALAYATAN UNIVERSITY<br />" + dt.Rows[i]["EXAM_NAME"].ToString() + "</span><br /><span style='font-size: 14pt;' >&nbsp;Answer Sheet Collection&nbsp;</span><hr noshade='noshade' size='1' style='color: black' /></td></tr>" +
                "<tr ><td style='font-weight:bold'>DATE :-" + Convert.ToDateTime(dt.Rows[i]["SH_DATE"]).ToString("dd/MM/yyyy") + "</td><td style='font-weight:bold'>SHIFT:-" + dt.Rows[i]["EXAM_SHIFT_VALUE"].ToString() + "</td><td style='font-weight:bold'>ROOM NO:-" + dt.Rows[i]["ROOM_VALUE"].ToString() + "</td></tr>" +
                "<tr><td colspan='3'><table cellspacing='0' border='1px' style='width:100%;'><tr>" +
                 "<th >S.No</th><th >COURSE CODE</th><th >NO OF COPIES</th><th style='Width:100px'>NO OF ABSENT</th><th style='Width:100px'>NO OF UFM</th><th style='Width:100px'>NO OF DETAINED</th><th style='Width:100px'>TOTAL RECEIVED</th></tr>");

                objBal.FromDate = Convert.ToDateTime(dt.Rows[i]["SH_DATE"]);
                objBal.TypeId = dt.Rows[i]["SHIFT_ID"].ToString();
                objBal.KeyID = dt.Rows[i]["ROOM_ID"].ToString();
                objBal.KeyValue = "2";
                dr = objBll.GetMinorAttendanceSheet(objBal);
                while (dr.Read())
                {
                    Count++;
                    strBldr.Append("<tr style='height:20px;font-weight:bold'>" +
                    "<td >" + Count.ToString() + "</td><td>" + dr["SH_CRS_CODE"].ToString() + "</td>" +
                    "<td>" + dr["NOP"].ToString() + "</td><td style='width:100px'>&nbsp;</td><td style='width:100px'>&nbsp;</td><td style='width:100px'>&nbsp;</td><td style='width:100px'>&nbsp;</td></tr>");
                }
                //dr.Close();
                strBldr.Append("<tr style='height:20px'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "<tr style='height:20px'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "<tr style='height:20px'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "<tr style='height:20px'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "<tr style='height:20px'><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>" +
                "</table></td></tr>" +
                "<tr><td colspan='3' valign='top'><table><tr><td colspan='2'><b>Receiver  Name & Signature :-</b></td></tr>" +
                " <tr><td><b>1)</b>___________________________________</td><td>______________________________________</td></tr>" +
                " <tr><td colspan='3'><hr style='visibility: hidden;color:#fff;page-break-after:always;'/></td></tr>" +
                "</table>");
                tdMain.InnerHtml = strBldr.ToString();

            }
        }
    }

}
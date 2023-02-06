using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
public partial class Acedamic_prtMinorAttendance : System.Web.UI.Page
{
    DatabaseFunctions databasefuncation;
    DataTable dt;
    StringBuilder strBldr;
    AcaBAL ObjBal;
    AcaBLL objBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        databasefuncation = new DatabaseFunctions();
        dt = new DataTable();
        SqlDataReader dr;
        strBldr = new StringBuilder();
        ObjBal = new AcaBAL();
        objBll = new AcaBLL();
        int Count;
        if (!IsPostBack)
        {
            dt = (DataTable)Session["dt"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Count = 0;
                string Date = Convert.ToDateTime(dt.Rows[i]["SH_DATE"]).ToString("dd/MM/yyyy");
                strBldr.Append("<table cellspacing='0' border='0' style='font-size:11px;width:100%;'>" +
                "<tr><td align='center' style='font-weight:bold' valign='top' colspan='3'><span style='font-size: 12pt'>MANGALAYATAN UNIVERSITY<br />" + dt.Rows[i]["EXAM_NAME"].ToString() + "</span><br /><span style='font-size: 12pt;' >&nbsp;Attendance Sheet&nbsp;</span><hr noshade='noshade' size='1' style='color: black' /></td></tr>" +
                "<tr ><td style='font-weight:bold'>DATE :-" + Date + "</td><td style='font-weight:bold'>SHIFT:-" + dt.Rows[i]["EXAM_SHIFT_VALUE"].ToString() + "</td><td style='font-weight:bold'>ROOM NO:-" + dt.Rows[i]["ROOM_VALUE"].ToString() + "</td></tr>" +
                "<tr><td colspan='3' valign='top'  style='height:1000px'><table cellspacing='0' border='1px' style='width:100%;'><tr>" +
                "<th >S.No</th><th >Enrollment No</th><th style='Width:130px'>Student Name</th><th >Sheet No</th><th style='Width:60px;'>Course Code</th><th style='Width:110px;'>Ans Book No</th><th style='Width:110px;'>Remarks</th><th style='Width:130px'>Student Signature</th></tr>");

                ObjBal.FromDate = Convert.ToDateTime(dt.Rows[i]["SH_DATE"]);
                ObjBal.TypeId = dt.Rows[i]["SHIFT_ID"].ToString();
                ObjBal.KeyID = dt.Rows[i]["ROOM_ID"].ToString();
                ObjBal.KeyValue = "1";
                dr = objBll.GetMinorAttendanceSheet(ObjBal);
                while (dr.Read())
                {
                    Count++;
                    strBldr.Append("<tr style='height:20px'>" +
                   "<td >" + Count.ToString() + "</td><td >" + dr["ENROLLMENT_NO"].ToString() + "</td><td>" + dr["STU_FULL_NAME"].ToString() + "</td>" +
                   "<td>" + dr["NUM"].ToString() + "</td><td style='width:100px'>" + dr["SH_CRS_CODE"].ToString() + "</td><td style='Width:120px;'>&nbsp;</td><td style='Width:120px;'></td><td style='width:150px'>&nbsp;</td></tr>");
                    if (Count == 25)
                    {
                        strBldr.Append("</table></td></tr>" +
                        //"<tr><td colspan='3' valign='top'><hr style='visibility: hidden;page-break-after:always' /></td></td></tr>" +                      
                        "<tr><td style='font-weight:bold'>DATE :-" + Date + "</td><td style='font-weight:bold'>SHIFT:-" + dt.Rows[i]["EXAM_SHIFT_VALUE"].ToString() + "</td><td style='font-weight:bold'>ROOM NO:-" + dt.Rows[i]["ROOM_VALUE"].ToString() + "</td></tr>" +
                        "<tr><td colspan='3' valign='top' ><table cellspacing='0' border='1px' style='width:100%;'><tr>" +
                        "<tr><th>S.No.</th><th >Enrollment No</th><th style='Width:130px'>Student Name</th><th >Sheet No</th><th style='Width:60px;'>Course Code</th><th style='Width:110px;'>Ans Book No</th><th style='Width:110px;'>Fees Due</th><th style='Width:130px'>Student Signature</th></tr>");
                    }
                }
                strBldr.Append("</table></td></tr>" +
                        "<tr><td colspan='3' valign='top'>&nbsp;</td></tr>" +
                        "<tr><td colspan='3' valign='top'><table><tr><td colspan='2'><b>Invigilators Name & Signature :-</b></td></tr>" +
                        " <tr><td><b>1)</b>___________________________________</td><td>______________________________________</td></tr><tr><td colspan='2'>&nbsp;</td></tr><tr><td colspan='2'>&nbsp;</td></tr>" +
                        "<tr><td><b>2)</b>_____________________________________</td><td>_____________________________________</td></tr><table></td></tr>"+
                        "<tr><td style='font-size:14px'><u><b>NOTE: Student with dues will be allowed to attempt next scheduled exams with the permission of directors on admit card.</b></u><hr style='visibility: hidden; page-break-after:always' /></td></tr></table>");


                tdMain.InnerHtml = strBldr.ToString();
            }


        }
    }
}
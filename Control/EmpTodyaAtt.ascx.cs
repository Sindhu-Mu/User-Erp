using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Control_EmpTodyaAtt : System.Web.UI.UserControl
{



    protected void Page_Load(object sender, EventArgs e)
    {



    }
    public void ShowAttendance(DateTime day, string UserID)
    {
        DatabaseFunctions df = new DatabaseFunctions();
        HRBLL ObjHrbll = new HRBLL();
        HRBAL ObjHrbal = new HRBAL();
        ObjHrbal.Date = day;
        ObjHrbal.SessionUserID = UserID;
        DataSet ds = ObjHrbll.GetEmpAttendance(ObjHrbal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblLogDate.Text = ds.Tables[0].Rows[0]["DUTYDATE"].ToString();
            lblShift.Text = ds.Tables[0].Rows[0]["SHIFTTIMING"].ToString();
            lblStatus.Text = ds.Tables[0].Rows[0]["ATT_TYPE_VALUE"].ToString();
            lblInTime.Text = ds.Tables[1].Rows[0]["ATT_TIMING"].ToString();
            //lblInTimeMarkedon.Text = ds.Tables[1].Rows[0]["ATT_MARK_AT"].ToString();
            lblInTimeMarkedAt.Text = ds.Tables[1].Rows[0]["ATT_MARK_IP"].ToString();
            lblInTimeMarkedBy.Text = ds.Tables[1].Rows[0]["MARK_BY"].ToString();
            if (ds.Tables[1].Rows.Count > 1)
            {
                lblOutTime.Text = ds.Tables[1].Rows[1]["ATT_TIMING"].ToString();
                //lblOutTimeMarkedon.Text = ds.Tables[1].Rows[1]["ATT_MARK_AT"].ToString();
                lblOutTimeMarkedAt.Text = ds.Tables[1].Rows[1]["ATT_MARK_IP"].ToString();
                lblOutTimeMarkedBy.Text = ds.Tables[1].Rows[1]["MARK_BY"].ToString();
            }
        }
        else
        {
            lblLogDate.Text = lblShift.Text = lblStatus.Text = lblInTime.Text = lblOutTimeMarkedBy.Text = "";
            lblInTimeMarkedAt.Text = lblInTimeMarkedBy.Text = lblOutTime.Text = lblOutTimeMarkedAt.Text = "";

        }

    }

}
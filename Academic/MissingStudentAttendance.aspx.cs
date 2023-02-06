using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Academic_MissingStudentAttendance : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    void LoadData()
    {
        AcaBal.SessionUserID = Session["UserId"].ToString();
        fillFunctions.Fill(gridAttClsNamePerSummary, AcaBll.GetMissingStudentAttendanceSummary(AcaBal));
    }
    protected void gridAttClsNamePerSummary_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        AcaBal.KeyID = gridAttClsNamePerSummary.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        AcaBal.Id = gridAttClsNamePerSummary.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[1].ToString();
        AcaBal.SessionUserID = Session["UserId"].ToString();
        DataSet dataSet = AcaBll.GetMissingStudentAttendanceDetails(AcaBal);
        fillFunctions.Fill(gridStudentData, dataSet.Tables[0]);
        tb1.Visible = true;
        dataSet.Dispose();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            StringBuilder data = new StringBuilder();
            data.AppendFormat("<Attendance>");
            foreach (GridViewRow row in gridStudentData.Rows)
            {
                CheckBox chkAttendance = (CheckBox)row.FindControl("chkAttendance");

                data.AppendFormat("<StuData TT_DET_ID=\"" + gridStudentData.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_MAIN_ID= \"" + gridStudentData.DataKeys[row.RowIndex].Values[1].ToString() +
                    "\" TT_DET_ATT_STAT= \"" + Convert.ToInt32(!chkAttendance.Checked) + "\" />");

            }
            data.AppendFormat("</Attendance>");
            AcaBal.XmlValue = data.ToString();
            AcaBal.AliasValue = "1";
            AcaBll.SaveAttendanceLate(AcaBal);
            //commonFunctions.Clear(gridStudentData);
            LoadData();
            tb1.Visible = false;
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('An error occured while marking the attendance. Please retry.')", true);
            return;
        }
    }
}
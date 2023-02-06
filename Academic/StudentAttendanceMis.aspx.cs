using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

public partial class Academic_StudentAttendanceMis : System.Web.UI.Page
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
            if (Request.QueryString.HasKeys())
            {
                try
                {
                    AcaBal.Id = Request.QueryString["id"];
                    DataSet dataSet = AcaBll.GetClassStudent(AcaBal);
                    fillFunctions.Fill(gridViewData, dataSet.Tables[0]);
                    commonFunctions.MergeRows(gridViewData, 0, 1, 2);

                    string marked = dataSet.Tables[1].Rows[0][0].ToString();
                    if (marked == "1")
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance marked for this class')", true);

                    else
                    {
                        if (dataSet.Tables[2].Rows.Count > 0)
                        {
                            fillFunctions.Fill(gridStudentData, dataSet.Tables[2]);
                            //for (int i = 0; i < dataSet.Tables[2].Rows.Count; i++)
                            //{
                            //    //if (dataSet.Tables[2].Rows[i]["REG_STATUS"].ToString() == "False")
                            //    //{
                            //    //    CheckBox chk = (CheckBox)gridStudentData.Rows[i].FindControl("chkAttendance");
                            //    //    chk.Enabled = false;
                            //    //    chk.Checked = true;
                            //    //    gridStudentData.Rows[i].BackColor = System.Drawing.Color.AntiqueWhite;
                            //    //}
                            //}

                            btnSave.Enabled = true;
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No valid student(s) found for this class. Check the class details and try again')", true);
                            return;
                        }
                    }
                    dataSet.Dispose();
                }
                catch
                {
                }
            }
        }
    }


    private void Clear(bool value)
    {
        commonFunctions.Clear(gridStudentData);
        commonFunctions.Clear(gridViewData);
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
                if (chkAttendance.Checked)
                    data.AppendFormat("<StuData TT_DET_ID=\"" + gridStudentData.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_MAIN_ID= \"" + gridStudentData.DataKeys[row.RowIndex].Values[1].ToString() +
                        "\" TT_DET_ATT_STAT= \"" + 0 + "\" />");
                else
                    data.AppendFormat("<StuData TT_DET_ID=\"" + gridStudentData.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_MAIN_ID= \"" + gridStudentData.DataKeys[row.RowIndex].Values[1].ToString() +
                     "\" TT_DET_ATT_STAT= \"" + 1 + "\" />");
            }
            data.AppendFormat("</Attendance>");
            AcaBal.XmlValue = data.ToString();
            AcaBll.SaveAttendance(AcaBal);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('An error occured while marking the attendance. Please retry.')", true);
            return;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance is successfully marked. Please switch to the Report page for more details.')", true);
        Clear(false);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_MissingAttendance : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadGridData();
        }
    }

    void LoadGridData()
    {
        AcaBal.SessionUserID = Session["UserId"].ToString();
        fillFunctions.Fill(gridStudentData, AcaBll.GetMissingAttendance(AcaBal));
    }
    protected void btnView_Click(object sender, EventArgs e)
    {

    }

    protected void gridStudentData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "Block":
                Block(index);
                break;
            case "Mark":
                Mark(index);
                break;
        }
    }

    void Block(int index)
    {
        TextBox txtReason = (TextBox)gridStudentData.Rows[index].FindControl("txtReason");
        if (txtReason.Text == "" || txtReason.Text.Length < 3)
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please enter a valid Reason')", true);
        else
        {
            AcaBal.KeyID = gridStudentData.DataKeys[index].Value.ToString();
            AcaBal.Description = txtReason.Text;
            AcaBll.BlockClassData(AcaBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Class Blocked Successfully')", true);
            Update(index);
        }
    }
    void Mark(int index)
    {
        Update(index);
    }
    void Update(int index)
    {
        gridStudentData.Rows[index].Enabled = false;
        UpdatePanel upBlock = (UpdatePanel)gridStudentData.Rows[index].FindControl("upBlock");
        UpdatePanel UpdatePanel1 = (UpdatePanel)gridStudentData.Rows[index].FindControl("UpdatePanel1");
        UpdatePanel upMark = (UpdatePanel)gridStudentData.Rows[index].FindControl("upMark");
        upBlock.Update();
        upMark.Update();
        UpdatePanel1.Update();
    }
}
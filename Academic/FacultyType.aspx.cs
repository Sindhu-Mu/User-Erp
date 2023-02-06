using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_FacultyType : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    void FillGrid()
    {
        fillFunctions.Fill(gvFaculty, AcaBll.GetFacultyType().Tables[0]);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        AcaBal.Name = txtFaculty.Text;
        AcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = AcaBll.SaveFacultyType(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        FillGrid();
        txtFaculty.Text = "";
    }
}
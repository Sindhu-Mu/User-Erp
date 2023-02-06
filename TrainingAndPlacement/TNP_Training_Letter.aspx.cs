using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class TrainingAndPlacement_TNP_Training_Letter : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunctions;
    TPBAL ObjBal;
    TPBLL ObjBll;
    DataSet ds;
    CommonFunctions commonfunction;
    protected void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjBal = new TPBAL();
        ObjBll = new TPBLL();
        ds = new DataSet();
        commonfunction = new CommonFunctions();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        string enroll = commonfunction.GetKeyID(txtEnrollment);
        Student.ShowStudent(enroll);
        A1.HRef = "../../StudentPortal/UploadedFile/TNP_Resume/" + enroll + ".doc";
        A2.HRef = "../../StudentPortal/UploadedFile/TNP_Resume/" + enroll + ".docx";
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string Eno = ObjBal.Enrollment = commonfunction.GetKeyID(txtEnrollment);
        ObjBal.SessionUserId = Session["UserId"].ToString();
        ds = ObjBll.TNP_TRAINING_LETTER_INSERT(ObjBal);
        string tno = ds.Tables[0].Rows[0]["LETTER_ID"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtTNP_Training_Letter.aspx?tno=" + tno + "&Eno=" + Eno + "',alwaysraised='yes')", true);
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        string ext;
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../../StudentPortal/UploadedFile/TNP_Resume"));
        if (folders.Exists == false)
            folders.Create();
        ext = Path.GetExtension(upd1.PostedFile.FileName);
        if (upd1.PostedFile.FileName != "")
        {
            if ((ext != ".doc") && (ext != ".docx"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Upload Appropriate File like .doc)", true);
                upd1.Focus();
                return;
            }
            else
                ViewState["url"] = "..\\..\\StudentPortal\\UploadedFile\\TNP_Resume\\" + commonfunction.GetKeyID(txtEnrollment) + ext.ToString();
            upd1.PostedFile.SaveAs(Server.MapPath(ViewState["url"].ToString()));

        }
        ObjBal.Enrollment = commonfunction.GetKeyID(txtEnrollment);
        ObjBal.Resume = ViewState["url"].ToString();
        ObjBll.Resume_update(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Resume Successfully Updated.')", true);
        txtEnrollment.Text = "";
    }
}

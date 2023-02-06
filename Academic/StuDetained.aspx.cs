using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StuDetained : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
  
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
   

    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        Initialize();
        if (!IsPostBack)
        {
            txtEnroll.Focus();
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        
        DataBasefunction = new DatabaseFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
     
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            string[] st = new string[2];
            st = txtEnroll.Text.Split(':');
            if (st.Length > 1)
            {
                Student.ShowStudent(st[1]);
                FillGrid();
            }
        }
    }
    void FillGrid()
    {
        ObjAcaBal.KeyID = CommonFunction.GetKeyID(txtEnroll);
        gvCourse.DataSource = ObjAcaBll.GetStudentDetainedList(ObjAcaBal);
        gvCourse.DataBind();
    }
    protected void gvCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjAcaBal.ChangeStatus = e.CommandName;
        ObjAcaBal.KeyID = e.CommandArgument.ToString();
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        string Msg = ObjAcaBll.StudentDetainedModify(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
        txtEnroll.Focus();

    }
}
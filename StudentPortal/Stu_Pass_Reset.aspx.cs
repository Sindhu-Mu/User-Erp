using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class StudentPortal_Stu_Pass_Reset : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        Dt = new DataTable();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            string[] st = new string[2];
            st = txtEnroll.Text.Split(':');
            if (st.Length > 1)
            {
                ViewState["Id"] = st[1];
                Student1.ShowStudent(st[1]);
            }
        }
    }
    protected void Pass_reset_Click(object sender, EventArgs e)
    {
        ObjFacBal.AuthFor = ViewState["Id"].ToString();
        ObjFacBll.UpdatePwd(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Password has been reseted to the Date of Bitrh')", true);
        txtEnroll.Text = "";
        Student1.ShowStudent("");
    }
}
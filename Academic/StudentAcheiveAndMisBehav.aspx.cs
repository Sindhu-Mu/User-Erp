using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Academic_StudentAcheiveAndMisBehav : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    string[] st = new string[2];
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlSession, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.All);
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ObjAcaBal.Stu_AdmNo = ViewState["Id"].ToString();
            ObjAcaBal.TypeId = ddType.SelectedValue;
            ObjAcaBal.Remark = txtRmk.Text;
            ObjAcaBal.SessionUserID = Session["UserId"].ToString();
            ObjAcaBal.KeyID = ddlSession.SelectedValue;
            ObjAcaBll.STUACHVMISBEHAVINSERT(ObjAcaBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Inserted successfully!!')", true);
            txtRmk.Text = "";
            ddType.SelectedIndex = 0; ddlSession.SelectedIndex = 0;
            txtEnroll.Text = "";
            Student.Clear();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Error Occurred!!')", true);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            st = txtEnroll.Text.Split(':');
            if (st.Length > 1)
            {
                Student.ShowStudent(st[1]);
                ViewState["Enroll"] = st[1];
                ObjAcaBal.Stu_AdmNo = CommonFunction.GetKeyID(txtEnroll);
                ViewState["Id"] = ObjAcaBll.GetStudentMainId(ObjAcaBal);
            }
        }
    }
}
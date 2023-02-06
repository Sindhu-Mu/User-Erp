using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StudentSts : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        btnModify.Attributes.Add("onClick", "return Validate()");
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlSts, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Stu_Status), true, FillFunctions.FirstItem.Select);
            clear();
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
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
                Student.ShowStudent(st[1]);
                FillGrid();
            }
        }
    }
    void clear()
    {
        txtDt.Text = "";
        txtRemark.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlSts);
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        string[] st = new string[2];
        st = txtEnroll.Text.Split(':');
        if (st.Length >= 1)
        {
            ObjAcaBal.Id = CommonFunction.GetKeyID(txtEnroll);
            ObjAcaBal.ChangeStatus = ddlSts.SelectedValue;
            ObjAcaBal.FromDate = CommonFunction.GetDateTime(txtDt.Text);
            ObjAcaBal.Value = txtRemark.Text;
            ObjAcaBal.SessionUserID = Session["UserId"].ToString();
            ObjAcaBll.CngStuSts(ObjAcaBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Status is Changed Successfully')", true);
            clear();
        }
    }
    void FillGrid()
    {
        ObjAcaBal.Stu_AdmNo = CommonFunction.GetKeyID(txtEnroll);
        gvSts.DataSource =  ObjAcaBll.GetStuSts(ObjAcaBal);
        gvSts.DataBind();

    }
}
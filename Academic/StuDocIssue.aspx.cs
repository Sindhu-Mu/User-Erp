using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StuDocIssue : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions Queryfunction;
    CommonFunctions CommonFuntion;
    DatabaseFunctions DataBaseFunction;
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {

        btnShow.Attributes.Add("onClick", "return Validate()");
        btnIssue.Attributes.Add("onClick", "return Validat()");
        Initialize();
        if (!IsPostBack)
        {
            ViewState["Id"] = "";
            FillFunction.Fill(ddlDoc, Queryfunction.GetCommand(QueryFunctions.QueryBaseType.Doc_Issue, Session["LoginId"].ToString()), true, FillFunctions.FirstItem.Select);
            btnIssue.Visible = false;
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        Queryfunction = new QueryFunctions();
        DataBaseFunction = new DatabaseFunctions();
        Dt = new DataTable();
        CommonFuntion = new CommonFunctions();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        txtEmp.Text = "";
        ddlDoc.SelectedIndex = 0;
        ObjAcaBal.Stu_AdmNo = CommonFuntion.GetKeyID(txtEnroll);
        Student.ShowStudent(ObjAcaBal.Stu_AdmNo);       
        ViewState["Id"] = ObjAcaBll.GetStudentMainId(ObjAcaBal);
        FillGrid();
        btnIssue.Visible = true;
    }
    void FillGrid()
    {
        ObjAcaBal.Id = ViewState["Id"].ToString();
        Dt = ObjAcaBll.StuDocIssue(ObjAcaBal).Tables[0];
        gvDoc.DataSource = Dt;
        gvDoc.DataBind();
        btnIssue.Text = (Dt.Rows.Count < 1) ? "Issue" : "Re-Issue";
    }
    protected void btnIssue_Click(object sender, EventArgs e)
    {
        ObjAcaBal.Id = ddlDoc.SelectedValue;
        ObjAcaBal.KeyID = ViewState["Id"].ToString();
        ObjAcaBal.EmpId = CommonFuntion.GetKeyID(txtEmp);
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        ObjAcaBal.TypeId = (Dt.Rows.Count < 1) ? "1" : "0";
        ObjAcaBal.Description = txtRemark.Text;
        string RefId = ObjAcaBll.StuDocInsert(ObjAcaBal);
        if (ddlDoc.SelectedValue == "28")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMigration.aspx?=" + RefId+ "','_blank','alwaysRaised')", true);
        if (ddlDoc.SelectedValue == "29")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtCharacterCertificate.aspx?=" + RefId + "','_blank','alwaysRaised')", true);
        txtRemark.Text = "";
        ddlDoc.SelectedIndex = 0;
    }
}
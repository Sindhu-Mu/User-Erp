using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.IO;


public partial class Facility_TransportFinSpecialApproval : System.Web.UI.Page
{
    FillFunctions FillFunction;
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    DatabaseFunctions DatabaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable dt;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
           // FillGridView();
            PushData();
            clear();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlPerType);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAppBy);
        txtAmt.Text = "";
        txtAmtDueDt.Text = "";
        txtAppDt.Text = "";
        txtEnroll.Text = "";
    }
    private void PushData()
    {
        FillFunction.Fill(ddlPerType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.PerType), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlAppBy, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpName), true, FillFunctions.FirstItem.Select);
    }
    void FillGridView()
    {
        dt = ObjFacBll.TptFinAppSelect(ObjFacBal).Tables[0];
        ViewState["dt"] = dt;
        gvView.DataSource = dt;
        gvView.DataBind();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(CommonFunction.GetKeyID(txtEnroll));      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.AuthFor = CommonFunction.GetKeyID(txtEnroll);
        ObjFacBal.StuAdmNo = ObjFacBll.GetStudentMainId(ObjFacBal);
        ObjFacBal.PerType = ddlPerType.SelectedValue;
        ObjFacBal.Amt = txtAmt.Text;
        ObjFacBal.AmtDueDate = CommonFunction.GetDateTime(txtAmtDueDt.Text);
        ObjFacBal.AprBy = ddlAppBy.SelectedValue;
        ObjFacBal.AprDt = CommonFunction.GetDateTime(txtAppDt.Text);
        ObjFacBal.SessionUserID = Session["UserID"].ToString();
        Msg = ObjFacBll.TptFinSplAppInsert(ObjFacBal);

        FillGridView();
        clear();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);

    }
}
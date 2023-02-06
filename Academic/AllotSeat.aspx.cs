using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class Academic_AllotSeat : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAllot.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            btnAllot.Visible = false;
            lblMsg.Text = "";
        }
    }
    private void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        ds = new DataSet();
    }
    protected void btnAllot_Click(object sender, EventArgs e)
    {
        ObjBal.Enroll_No = txtEnroll.Text;
        ObjBal.KeyID = "4";
        ds = ObjBll.AllotSeat(ObjBal);
        Session["dt"] = ds.Tables[0];
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtAdmitCard.aspx')", true);
        btnAllot.Visible = false;
        txtEnroll.Focus();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        lblMsg.Text = "";
        ObjBal.Enroll_No = txtEnroll.Text;
        Student.ShowStudent(txtEnroll.Text);
        btnAllot.Visible = true;
        //string msg = ObjBll.CheckDue(ObjBal);
        //if (msg == "0")
        //    btnAllot.Visible = true;
        //else
        //    lblMsg.Text = msg;
    }
}
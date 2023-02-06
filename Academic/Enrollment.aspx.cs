using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_Enrollment : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    string Msg;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        
        if (!IsPostBack)
        {
            pushData();
        }
    }
    void Initialize()
    {
        common = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
    }
    void pushData()
    {
        fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.All);
        fillFunctions.FillYear(2013, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlYear);
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        else
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
        else
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.All);
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        getData();
        dt=ObjBll.GetEnrollmentData(ObjBal).Tables[0];
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
        gvDetail.Visible = true;
        if (dt.Rows.Count > 0)
            btnEnroll.Visible = true;
    }
    protected void btnEnroll_Click(object sender, EventArgs e)
    {
        getData();
        Msg = ObjBll.EnrollStudent(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }
    void clear()
    {
        ddlBranch.SelectedIndex = ddlIns.SelectedIndex = ddlLateral.SelectedIndex = ddlPgm.SelectedIndex = ddlType.SelectedIndex = 0;
        txtForm.Text = "";
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
        gvDetail.Visible = false;
    }
    void getData()
    {
        ObjBal.Year = ddlYear.SelectedValue;
        ObjBal.Lateral = ddlLateral.SelectedValue;
        ObjBal.TypeId = ddlType.SelectedValue;
        ObjBal.InsId = ddlIns.SelectedItem.ToString();
        ObjBal.Pgm_Id = ddlPgm.SelectedItem.ToString();
        ObjBal.Brn_Id = ddlBranch.SelectedItem.ToString();
        ObjBal.KeyValue = ddlCaste.SelectedValue;
        ObjBal.KeyID = txtForm.Text;
        ObjBal.EmpId = Session["LoginId"].ToString();
    }
}
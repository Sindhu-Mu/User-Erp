using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class StudentFinance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DataSet ds;
    DataView dv;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        btnShow.Attributes.Add("OnClick", "validation()");
        
        if (!IsPostBack)
        {
            fillfunction.Fill(ddlSession, queryfunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
            th2.Visible = false;
            th3.Visible = false;
            th4.Visible = false;
            th1.Visible = false;
        }
       
        
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }


    protected void btnShow_Click(object sender, EventArgs e)
    {
        th1.Visible = true;
        th2.Visible = false;
        th3.Visible = false;
        th4.Visible = false;
        balObj.balSession = ddlSession.SelectedValue;
        balObj.balSemType = ddlSemtype.SelectedValue;
        ds= bllObj.GetDemandedAndNotDemanded(balObj);
        FillDetail(gvInstitute, ds.Tables[0]);
        ViewState["Course"] = ds.Tables[1];
        ViewState["Branch"] = ds.Tables[2];
        ViewState["Semester"] = ds.Tables[3];
        ViewState["Student"] = ds.Tables[4];
    }
    void FillDetail(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }
 
    protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        th2.Visible = true;
        th3.Visible = true;
        th4.Visible = true;
        if (e.CommandName == "INS")
        {
            dv = new DataView();
            dv.Table = (DataTable)ViewState["Course"];
            dv.RowFilter = "INS_ID='" + gvInstitute.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
            gvCourse.DataSource = dv;
            gvCourse.DataBind();
            gvBranch.DataSource = "";
            gvBranch.DataBind();
            gvSemester.DataSource = "";
            gvSemester.DataBind();
            gvStudent.DataSource = "";
            gvStudent.DataBind();
        }
    }
    protected void gvCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        th3.Visible = true;
        th4.Visible = true;
        if (e.CommandName == "COURSE")
        {
            dv = new DataView();
            dv.Table = (DataTable)ViewState["Branch"];
            dv.RowFilter = "INS_PGM_ID='" + gvCourse.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
            gvBranch.DataSource = dv;
            gvBranch.DataBind();
            gvSemester.DataSource = "";
            gvSemester.DataBind();
            gvStudent.DataSource = "";
            gvStudent.DataBind();
        }
    }
    void bindSemster(string Branch)
    {
        dv = new DataView();
        dv.Table = (DataTable)ViewState["Semester"];
        dv.RowFilter = "PGM_BRN_ID='" + Branch + "'";
        gvSemester.DataSource = dv;
        gvSemester.DataBind();
    }
    protected void gvBranch_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        dv = new DataView();
        dv.Table = (DataTable)ViewState["Student"];
        dv.RowFilter = "PGM_BRN_ID='" + gvBranch.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
        gvStudent.DataSource = dv;
        gvStudent.DataBind();
        bindSemster(gvBranch.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
    }
    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}
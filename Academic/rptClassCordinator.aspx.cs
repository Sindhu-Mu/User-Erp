using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_rptClassCordinator : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;


    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {

            if (!IsPostBack)
                FillGrid();
        }
    }

    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    private void FillGrid()
    {
        bal.SessionUserID = Session["LoginId"].ToString();
        bal.TypeId = "1";
        fill.Fill(gvShow, bll.GetCordinatorClassCount(bal));
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        FillGrid();

    }


    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        gvShow.Rows[index].BackColor = System.Drawing.Color.Yellow;
        if (e.CommandName == "Select")
        {

            bal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
            bal.EmpId = gvShow.DataKeys[index].Values[2].ToString();
            bal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
            fill.Fill(gridClass, bll.GetTTStatus(bal));
            gridClass.Visible = true; gridStudent.Visible = false;
            trProfile.Visible = false;
        }
        else if (e.CommandName == "Student")
        {

            bal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
            bal.EmpId = Session["UserId"].ToString();
            bal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
            fill.Fill(gridStudent, bll.GetTTStudent(bal));
            gridClass.Visible = false; gridStudent.Visible = true;
            trProfile.Visible = false;
        }
    }

    protected void gridStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            StuFullProfile.StudentFullProfile(gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString());
            trProfile.Visible = true;
        }
    }
}
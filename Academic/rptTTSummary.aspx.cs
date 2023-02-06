using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_rptTTSummary : System.Web.UI.Page
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
        bal.TypeId = "3";
        bal.EmpId = Session["UserId"].ToString();
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
            ViewState["KeyID"]= bal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
            bal.EmpId = Session["UserId"].ToString();
            bal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
            ViewState["GRPID"] = gvShow.DataKeys[index].Values[1].ToString();
            fill.Fill(gridClass, bll.GetTTStatus(bal));
            gridClass.Visible = true; gridStudent.Visible = false;
        }
        else if (e.CommandName == "Student")
        {
           
            bal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
            bal.EmpId = Session["UserId"].ToString();
            bal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
            fill.Fill(gridStudent, bll.GetTTStudent(bal));
            gridClass.Visible = false; gridStudent.Visible = true;
        }
        else if (e.CommandName == "Faculty")
        {

            bal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
            bal.EmpId = Session["UserId"].ToString();
            bal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
            bal.Id = gvShow.DataKeys[index].Values[2].ToString();
            bal.Sec_Id = gvShow.DataKeys[index].Values[3].ToString();
            bal.Semid = gvShow.Rows[index].Cells[3].Text;
            fill.Fill(gridFaculty, bll.GetTTFaculty(bal));
            gridClass.Visible = false; gridStudent.Visible = false; gridFaculty.Visible = true;
        }
    }
    protected void gridClass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        bal.KeyID = gridClass.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        string msg = bll.DeleteStudentAtt(bal).Tables[0].Rows[0][0].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        bal.KeyID = ViewState["KeyID"].ToString();
        bal.EmpId = Session["UserId"].ToString();
        bal.TypeId = ViewState["GRPID"].ToString();
        fill.Fill(gridClass, bll.GetTTStatus(bal));
        gridClass.Visible = true; gridStudent.Visible = false;

    }
}
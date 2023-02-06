using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryFunction;
    FillFunctions fillFunction;
    SFBAL Objbal;
    SFBLL Objbll;
    DataTable dt;
    DataSet ds;
    CommonFunctions cf;
    DataView dv;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {
            fillFunction.Fill(ddlSession, queryFunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
            tdins.Visible = tdcrs.Visible = tdbrn.Visible = tdsem.Visible = tdstu.Visible = false;
        }      
    }

     protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        tdins.Visible = true;
        //tdcrs.Visible = tdbrn.Visible = tdsem.Visible = tdstu.Visible = false;
        //gvcourse.DataSource = "";
        //gvcourse.DataBind();
        //gvbranch.DataSource = "";
        //gvbranch.DataBind();
        //gvsemester.DataSource = "";
        //gvsemester.DataBind();
        //gvstudent.DataSource = "";
        //gvstudent.DataBind();   
        Objbal.balSession = ddlSession.SelectedValue;
        ds = Objbll.StuFinDailyReceivedSelect(Objbal);
        FillDetail(gvinstitute, ds.Tables[0]);
        ViewState["course"] = ds.Tables[1];
        ViewState["branch"] = ds.Tables[2];
        ViewState["semester"] = ds.Tables[3];
        ViewState["student"] = ds.Tables[4];
    }
   
     

    void FillDetail(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }

    protected void Initialize()
    {
        queryFunction = new QueryFunctions();
        fillFunction = new FillFunctions();
        Objbal = new SFBAL();
        Objbll = new SFBLL();
        dt = new DataTable();
        ds = new DataSet();
        cf = new CommonFunctions();
        dv = new DataView();
    }

    protected void gvinstitute_RowCommand(object sender, GridViewCommandEventArgs e)
    {

       if(e.CommandName=="INS")
        {
            tdcrs.Visible = true;
           dv.Table = (DataTable)ViewState["course"];
           dv.RowFilter = "INS_ID='" + gvinstitute.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
           gvcourse.DataSource = dv;
           gvcourse.DataBind();
           //gvbranch.DataSource="";
           //gvbranch.DataBind();
           //gvsemester.DataSource="";
           //gvsemester.DataBind();
           //gvstudent.DataSource="";
           //gvstudent.DataBind();    
        }

    }
    protected void gvcourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
     if(e.CommandName=="COURSE")
     {
         tdbrn.Visible = true;
         dv.Table = (DataTable)ViewState["branch"];
         dv.RowFilter = "INS_PGM_ID='" + gvcourse.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
         gvbranch.DataSource = dv;
         gvbranch.DataBind();
         //gvsemester.DataSource="";
         //gvsemester.DataBind();
         //gvstudent.DataSource="";
         //gvstudent.DataBind();
     }

    }
    protected void gvbranch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName=="BRANCH")
        {
            tdstu.Visible = true;
            dv.Table = (DataTable)ViewState["student"];
            dv.RowFilter = "PGM_BRN_ID='" + gvbranch.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
            gvstudent.DataSource = dv;
            gvstudent.DataBind();
            bindSemster(gvbranch.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        }
    }

    void bindSemster(string branch)
    {
        tdsem.Visible = true;
        dv.Table = (DataTable)ViewState["semester"];
        dv.RowFilter = "PGM_BRN_ID='" + branch + "'";
        gvsemester.DataSource = dv;
        gvsemester.DataBind();
    }  
}


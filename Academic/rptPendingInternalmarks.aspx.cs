using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_rptPendingInternalmarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        //btnView.Attributes.Add("onClick", "return validateType()");
      
        if (!IsPostBack)
        {
          
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        }

    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
        ds = new DataSet();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        gvPaperCode.DataSource = "";
        gvPaperCode.DataBind();
        AcaBal.InsId = ddlIns.SelectedValue;
        AcaBal.Pgm_Id = ddlPgm.SelectedValue;
        AcaBal.Brn_Id = ddlBranch.SelectedValue;
        AcaBal.Semid = ddlSem.SelectedValue;
        ds = AcaBll.GetPendingInternalMarksDetail(AcaBal);
        gvPaperCode.DataSource = ds.Tables[0];
        gvPaperCode.DataBind();
        btnExport.Visible = (gvPaperCode.Rows.Count > 0);
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("InternalNotSubmitted.xls", gvPaperCode);
    }
}
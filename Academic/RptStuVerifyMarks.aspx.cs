using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;


public partial class Academic_RptStuVerifyMarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlSubType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Paper_type), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlBrn, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlBrn, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        AcaBal.InsId = ddlIns.SelectedValue;
        AcaBal.Pgm_Id = ddlPgm.SelectedValue;
        AcaBal.Brn_Id = ddlBrn.SelectedValue;
        AcaBal.Semid = ddlSem.SelectedValue;
        AcaBal.TypeId = ddlSubType.SelectedValue;
        gvVerify.DataSource = AcaBll.GetStuVerifiedMarks(AcaBal);
        gvVerify.DataBind();
        clear();
    }
    void clear()
    {
        ddlIns.SelectedIndex = ddlPgm.SelectedIndex = ddlBrn.SelectedIndex = ddlSem.SelectedIndex = ddlSubType.SelectedIndex = 0;
    }
}
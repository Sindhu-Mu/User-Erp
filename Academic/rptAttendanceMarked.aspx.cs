using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Academic_rptAttendanceMarked : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
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
        dt = new DataTable();
    }
    void pushData()
    {
        fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSec, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
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
        ObjBal.InsId = ddlIns.SelectedValue;
        ObjBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjBal.Brn_Id = ddlBranch.SelectedValue;
        ObjBal.Id = ddlBatch.SelectedValue;
        ObjBal.Sec_Id = ddlSec.SelectedValue;
        ObjBal.Semid = ddlSem.SelectedValue;
        ObjBal.KeyValue =txtDate.Text;
        gvDetail.DataSource = ObjBll.getStuTempAtt(ObjBal).Tables[0];
        gvDetail.DataBind();
    }
}
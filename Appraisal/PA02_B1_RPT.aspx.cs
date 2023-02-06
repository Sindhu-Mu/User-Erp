using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Appraisal_PA02_B1_RPT : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        if (!IsPostBack)
        {
            pushData();
        }
    }

    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }

    void pushData()
    {
        FillFunction.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (txtFaculty.Text != "")
            ObjBal.Emp_id = commonFunctions.GetKeyID(txtFaculty);
        ObjBal.Institute = ddlInstitution.SelectedValue;
        ObjBal.Dept = ddlDepartment.SelectedValue;
        ObjBal.Batch = ddlBatch.SelectedValue;
        ObjBal.Sem = ddlSemester.SelectedValue;
        gridReportInfo.DataSource = ObjBll.getStuFeedbackRpt(ObjBal);
        gridReportInfo.DataBind();
        ProcessGridHyperLink();
    }
    private void ProcessGridHyperLink()
    {
        foreach (GridViewRow row in gridReportInfo.Rows)
        {
            int index = row.RowIndex;
            string id = gridReportInfo.DataKeys[index].Value.ToString();
            HyperLink link = (HyperLink)row.FindControl("linkReport");
            string url = "PA02_B1_PRT.aspx?id=" + id;
            link.NavigateUrl = url;
        }
    }
}
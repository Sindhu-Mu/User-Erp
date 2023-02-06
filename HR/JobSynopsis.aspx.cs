using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_JobSynopsis : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;


    public void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ds"] = "";
            FillFunction.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjHrBAL.JobId = ddlJob.SelectedValue;
        ViewState["ds"] = ds = ObjHrBll.GetJobSynopsis(ObjHrBAL);
        gvDetails.DataSource = ds.Tables[0];
        gvDetails.DataBind();
        DataRow dr = ds.Tables[1].Rows[0];
        lblTotal.Text = dr[0].ToString();
        lblJoin.Text = dr[1].ToString();
        lblSelected.Text = dr[2].ToString();
        lblNotSelected.Text = dr[3].ToString();
        lblPresent.Text = dr[4].ToString();
        lblAbsent.Text = dr[5].ToString();
        tdCount.Visible = true;
        foreach (GridViewRow row in gvDetails.Rows)
        {
            if ((gvDetails.Rows[row.RowIndex].Cells[7].Text == "SELECTED") || (gvDetails.Rows[row.RowIndex].Cells[7].Text == "JOINED"))
                gvDetails.Rows[row.RowIndex].BackColor = System.Drawing.Color.YellowGreen;
        }
        if (ds.Tables[0].Rows.Count > 0)
            btnPrint.Visible = true;
        else
            btnPrint.Visible = false;
    }
    
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["ds"];
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptInterview.aspx','_blank','resizable=1,width=900,height=650')", true);
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlDept.Items.Clear();
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
            FillFunction.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DeptJob, ddlDept.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlJob.Items.Clear();
    }
}
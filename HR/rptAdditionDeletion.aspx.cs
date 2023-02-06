using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_rptAdditionDeletion : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DataSet ds;
    Messages Msgfun;
    HRBAL HrBal;
    HRBLL HrBll;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        if (!IsPostBack)
        {
            PushData();
            //ViewState["ds"] = ds;
        }

    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
        Msgfun = new Messages();
        HrBal = new HRBAL();
        HrBll = new HRBLL();
    }
    private void PushData()
    {
        fillFunctions.Fill(ddlServiceType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ServiceType), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlDesignation, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlJobType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobTypeWithoutAll), true, FillFunctions.FirstItem.Select);
        fillFunctions.FillYear(DateTime.Now.Year - 3, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlYear);
        trDaily.Visible = true;
        trMonth.Visible = trYear.Visible = trDR.Visible = false;
        txtTo.Text = txtFrm.Text = txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        HrBal.InsId = (ddlInstitute.SelectedIndex > 0) ? ddlInstitute.SelectedValue : "0";
        HrBal.DeptId = (ddlDepartment.SelectedIndex > 0) ? ddlDepartment.SelectedValue : "0";
        HrBal.DesignationId = (ddlDesignation.SelectedIndex > 0) ? ddlDesignation.SelectedValue : "0";
        HrBal.TypeId = ddlSearch.SelectedValue;
        HrBal.ViewType = (ddlServiceType.SelectedIndex > 0) ? ddlServiceType.SelectedValue : "0";
        HrBal.ValueType = (ddlJobType.SelectedIndex > 0) ? ddlJobType.SelectedValue : "-1";
        if (ddlSearch.SelectedValue == "0")
            HrBal.Value1 = txtDate.Text;
        if (ddlSearch.SelectedValue == "1")
        {
            DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
            DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
            HrBal.Value1 = ddlMM.SelectedValue;
            HrBal.Value2 = ddlYY.SelectedValue;
        }
        if (ddlSearch.SelectedValue == "2")
            HrBal.Value1 = ddlYear.SelectedValue;
        if (ddlSearch.SelectedValue == "3")
        {
            HrBal.Value1 = txtFrm.Text;
            HrBal.Value2 = txtTo.Text;
        }
         ds= HrBll.GetAdditionDeletion(HrBal);
         //ViewState["ds"] = ds;
        if (ds.Tables.Count > 0)
        {
            gridAddition.DataSource = ds.Tables[0];
            gridAddition.DataBind();
            gridDeletion.DataSource = ds.Tables[1];
            gridDeletion.DataBind();
            lblJoined.Text ="Total Joined:" + ds.Tables[2].Rows[0][0].ToString();
            lblRelvd.Text = "Total Releived:" + ds.Tables[3].Rows[0][0].ToString();
            lblActive.Text="Active Employee:"+ds.Tables[4].Rows[0][0].ToString();
            lblJoined.Visible = lblRelvd.Visible=lblActive.Visible = true;
        }

    }
 
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("Addition_Deletion.xls",gridAddition,gridDeletion);
        
        
    }
    protected void ddlSearch_SelectedIndexChanged(object sender, EventArgs e)
    {
        trDaily.Visible = trDR.Visible = trMonth.Visible = trYear.Visible = false;
        if (ddlSearch.SelectedValue == "0")
            trDaily.Visible = true;
        if (ddlSearch.SelectedValue == "1")
            trMonth.Visible = true;
        if (ddlSearch.SelectedValue == "2")
            trYear.Visible = true;
        if (ddlSearch.SelectedValue == "3")
            trDR.Visible = true;

    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
}
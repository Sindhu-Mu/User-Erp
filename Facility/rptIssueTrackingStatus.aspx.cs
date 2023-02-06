using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class Facility_rptIssueTrackingStatus : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    FacBAL objBal;
    FacBLL objBll;
    DataSet ds;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadData();
          
        }

    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new FacBAL();
        objBll = new FacBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
        ds = new DataSet();

    }
    void LoadData()
    {
        fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);

    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            txtFromDate.Text = "";
            txtToDate.Text = "";
            ddlDate.SelectedValue = "0";
        }
    }
    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {

            case "ddlDate":
                if (ddlDate.SelectedValue == "3")
                {

                    txtFromDate.Enabled = true;
                    txtToDate.Enabled = true;
                }
                else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
                {
                    txtFromDate.Enabled = true;
                    txtToDate.Enabled = false;
                }
                else
                {
                    txtFromDate.Enabled = false;
                    txtToDate.Enabled = false;
                }
                txtToDate.Text = txtFromDate.Text = "";
                break;
            default:
                break;
        }
    }
    protected void gvIssuDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        ViewState["index"] = index.ToString();
        objBal.KeyID = gvIssuDetail.DataKeys[index].Values[0].ToString();
        if (e.CommandName == "View")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptIssueDetail.aspx?=" + objBal.KeyID.ToString() + "','_blank','width=700, height=500, top=100, left=200')", true);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEmployee.Text == "")
        {
            objBal.EmpId = " ";
        }
        else
        {
            objBal.EmpId = commonFunctions.GetKeyID(txtEmployee);
        }
        objBal.InsId = ddlIns.SelectedValue;
        objBal.DeptId = ddlDept.SelectedValue;
        objBal.KeyValue = ddlDate.SelectedValue;
        objBal.frdt = txtFromDate.Text;
        objBal.todt = txtToDate.Text;
        objBal.Description = ddlConcernDept.SelectedValue;
        gvIssuDetail.DataSource = objBll.GetIssueReport(objBal).Tables[0];
        gvIssuDetail.DataBind();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_rptSivMain : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
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
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
    }
    void pushData()
    {
        fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.All);
    }
    protected void ddlDateRangeFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDateRangeFilter.SelectedIndex == 3)
        {     
            txtDateMax.Visible = true;
        }
        if ((ddlDateRangeFilter.SelectedIndex == 2) || (ddlDateRangeFilter.SelectedIndex == 1))
        {
            txtDateMax.Visible = false;
            txtDateMax.Text = "";
        }
        else
            txtDateMin.Text = "";
    }
    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlIndent, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sto_Indent, ddlStore.SelectedValue), true, FillFunctions.FirstItem.All);

        }
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.Typ = objBal.Date = objBal.ToDate = "";
        objBal.ID = ddlInstitute.SelectedValue;
        objBal.Dept = ddlDepartment.SelectedValue;
        objBal.IndId = ddlIndent.SelectedValue;
        if (ddlDateRangeFilter.SelectedIndex > 0)
        {
            switch (ddlDateRangeFilter.SelectedValue)
            {
                case "1":
                    objBal.Typ = "4";
                    objBal.Date = commonFunctions.GetDateTime(txtDateMin.Text).ToShortDateString();
                    objBal.ToDate = "";
                    break;
                case "2":
                    objBal.Typ = "5";
                    objBal.Date = commonFunctions.GetDateTime(txtDateMin.Text).ToShortDateString();
                    objBal.ToDate = "";
                    break;
                case "3":
                    objBal.Typ = "6";
                    objBal.Date = commonFunctions.GetDateTime(txtDateMin.Text).ToShortDateString();
                    objBal.ToDate = commonFunctions.GetDateTime(txtDateMax.Text).AddDays(1).ToShortDateString();
                    break;
                default:
                    break;
            }
        }
        objBal.StoreName = ddlStore.SelectedValue;
        fillFunctions.Fill(gvData, objBll.GetSIVReport(objBal).Tables[0]);
    }
}
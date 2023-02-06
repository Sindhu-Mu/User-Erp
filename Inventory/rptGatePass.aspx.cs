using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_rptGatePass : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.FillFinancialYear(DateTime.Now.Year-4,DateTime.Now.Year,1,FillFunctions.FirstItem.Select,ddlYear);
            fillFunctions.Fill(ddlGatePass, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GatePass, ddlYear.SelectedValue), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlVendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlCarryPers, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Carry_Person), true, FillFunctions.FirstItem.Select);
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

    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlGatePass, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GatePass, ddlYear.SelectedValue), true, FillFunctions.FirstItem.Select);
       
        
    }
    protected void gvGatePass_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        trDetail.Visible= true;
        objBal.ID = gvGatePass.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
       DataSet ds = objBll.PrintGatePass(objBal);
        gvItemDetail.DataSource = ds.Tables[1];
        gvItemDetail.DataBind();
    }
    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlDate":
                if (ddlDate.SelectedValue == "3")
                {
                    txtFromDT.Enabled = true;
                    txtToDT.Enabled = true;
                }
                else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
                {
                    txtFromDT.Enabled = true;
                    txtToDT.Enabled = false;
                }
                else
                {
                    txtFromDT.Enabled = false;
                    txtToDT.Enabled = false;
                }
                txtToDT.Text = txtFromDT.Text = "";
                break;



            default:
                break;
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ddlYear.SelectedValue;
        objBal.ID = ddlGatePass.SelectedValue;
        objBal.Name = ddlCarryPers.SelectedValue;
        objBal.Typ = ddlPassType.SelectedValue;
        objBal.VenId = ddlVendor.SelectedValue;
        objBal.Identification = ddlDate.SelectedValue;
        if (ddlDate.SelectedValue == "3")
        {
            objBal.ToDate = commonFunctions.GetDateTime(txtToDT.Text).ToString();
            objBal.Date = commonFunctions.GetDateTime(txtFromDT.Text).ToString();

        }
        else
        {
            objBal.ToDate = txtToDT.Text;
            objBal.Date = txtFromDT.Text;
        }
        gvGatePass.DataSource = objBll.GetGatePass(objBal);
        gvGatePass.DataBind();
    }
}
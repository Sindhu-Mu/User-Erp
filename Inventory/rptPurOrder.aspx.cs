using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class Inventory_rptPurOrder : System.Web.UI.Page
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
            fillFunctions.FillFinancialYear(DateTime.Now.Year - 4, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlYear);
            fillFunctions.Fill(ddlPOID, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurOrderRpt,ddlYear.SelectedValue), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlFAN, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANId), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlPurReq, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSupplier, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.Select);
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

    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.KeyId = ddlYear.SelectedValue;
        objBal.PurNo = ddlPOID.SelectedValue;
        objBal.ID = ddlFAN.SelectedValue;
        objBal.ReqNo = ddlPurReq.SelectedValue;
        objBal.VenId = ddlSupplier.SelectedValue;
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
        gvPurchase.DataSource = objBll.GetPurOrder(objBal);
        gvPurchase.DataBind();
    }
    protected void DateType_Change(object sender, EventArgs e)
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
    protected void gvPurchase_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            trDetail.Visible = trPay.Visible = trTerm.Visible = true;
            objBal.ID = gvPurchase.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            DataSet ds = objBll.ModifyPurOrder(objBal);
            gvItemDetail.DataSource = ds.Tables[1];
            gvPayment.DataSource = ds.Tables[2];
            gvTermCondition.DataSource = ds.Tables[3];
            gvItemDetail.DataBind();
            gvPayment.DataBind();
            gvTermCondition.DataBind();
        }
    }
    protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlPOID, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurOrderRpt, ddlYear.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Inventory_rptSIV : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {

            fillFunctions.Fill(ddlSIV, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SIV_Id), true, FillFunctions.FirstItem.Select);            
            fillFunctions.Fill(ddlSTORE, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSIVITEM, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.Select);
            
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
        ds = new DataSet();

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
        objBal.IndId = ddlINDENT.SelectedValue;
        objBal.ItemId = ddlSIV.SelectedValue;
        objBal.ItemName = ddlSIVITEM.SelectedValue;
        objBal.StoreName = ddlSTORE.SelectedValue;
        objBal.Identification = ddlDate.SelectedValue;
        if (txtIndentor.Text != "")
        {
            if (txtIndentor.Text.Contains(":"))
                objBal.ActionBy = commonFunctions.GetKeyID(txtIndentor);
        }
        else
        {
            objBal.ActionBy = "";
        }

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
        ds = objBll.GetSIVDetails(objBal);
        gvSIV.DataSource = ds;
        gvSIV.DataBind();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("IndentDetail.xls", gvSIV);
    }
    protected void ddlSTORE_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlINDENT, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sto_Indent, ddlSTORE.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
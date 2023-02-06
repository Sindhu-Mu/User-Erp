using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_rptSto_Indent : System.Web.UI.Page
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
            trDetail.Visible = trPrevious.Visible = false;
            pushData();
            btnView.Attributes.Add("OnClick", "return validateView()");
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

        fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlIndent, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IND_ID), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Item_Store, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlItems, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Ind_Status), true, FillFunctions.FirstItem.All);
        //bindgvDetail();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        bindgvDetail();
    }
    private void bindgvDetail()
    {
        objBal.Typ = "";
        objBal.Dept = ddlDept.SelectedValue;
        objBal.IndId = ddlIndent.SelectedValue;
        objBal.StoreName = ddlStore.SelectedValue;
        objBal.ItemId = ddlItems.SelectedValue;
        if (txtFromDT.Text != "")
            objBal.Date = commonFunctions.GetDateTime(txtFromDT.Text).ToString();
        if (txtToDT.Text != "")
            objBal.ToDate = commonFunctions.GetDateTime(txtToDT.Text).ToString();
        objBal.Remark = ddlSort.SelectedValue;
        fillFunctions.Fill(gvDetail, objBll.GetIndentReport(objBal).Tables[0]);
        trDetail.Visible = trPrevious.Visible = false;
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gvDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        objBal.IndId = gvDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        fillFunctions.Fill(gvItemDetail, objBll.GetIndentItemReport(objBal).Tables[0]);
        trPrevious.Visible = false;
        trDetail.Visible = true;
    }
    protected void gvItemDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        objBal.Dept = gvItemDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1].ToString();
        objBal.ItemId = gvItemDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString();
        fillFunctions.Fill(gvPrevious, objBll.GetIndentPrevReport(objBal).Tables[0]);
        trDetail.Visible = trPrevious.Visible = true;
    }
    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlItems, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store_Item, ddlStore.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
}
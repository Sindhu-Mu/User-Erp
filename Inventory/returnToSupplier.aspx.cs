using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;

public partial class Inventory_returnToSupplier : System.Web.UI.Page
{

    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DataTable dt;
    DatabaseFunctions databaseFunctions;
    DataSet ds;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        dt = new DataTable();
        databaseFunctions = new DatabaseFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {

            Table1.Visible = false;
            fillFunctions.Fill(ddGrnNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GRN_NO_AVAL), true, FillFunctions.FirstItem.Select);
        }
        else
            lblError.Visible = false;
    }
    protected void ddGrnNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Table1.Visible = true;
        objBal.GrnNO = ddGrnNo.SelectedItem.Text;
        ds = objBll.GetGRNDetail(objBal);
         ViewState["myTable"] = ds;
        lblBill.Text=ds.Tables[0].Rows[0]["BILL_NO"].ToString();
        lblStore.Text = ds.Tables[0].Rows[0]["STO_NAME"].ToString();
        lblChallan.Text = ds.Tables[0].Rows[0]["CLN_NO"].ToString();
        lblPoNo.Text = ds.Tables[0].Rows[0]["PO_ID"].ToString();
        lblReceiveDate.Text = ds.Tables[0].Rows[0]["GRN_DATE"].ToString();
        lblRecieveBy.Text = ds.Tables[0].Rows[0]["RCV_BY"].ToString();
        lblSupp.Text = ds.Tables[0].Rows[0]["ORG_NAME"].ToString();

        dgShow.DataSource = ds.Tables[1];
            dgShow.DataBind();
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        
        ds = (DataSet)ViewState["myTable"]; 
       
        foreach (GridViewRow gvrow in dgShow.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvrow.FindControl("chkSelect");
            if (chkSelect.Checked==true)
                {
                    TextBox txtRtnQty = (TextBox)gvrow.FindControl("txtRtnItem");
                    string index = gvrow.Cells[1].Text;
                    if (Convert.ToInt16(ds.Tables[1].Rows[gvrow.DataItemIndex]["AVLBL_QTY"]) < Convert.ToInt16(txtRtnQty.Text))
                    {
                        lblError.Visible = true;
                        lblError.Text = "Return Quantity Cannot be Greater than Receive Quantity For Item " + index;
                        return;
                    }
                    else
                    { 
                        objBal.GrnNO = ddGrnNo.SelectedItem.Text;
                        objBal.ItemName = ds.Tables[1].Rows[gvrow.DataItemIndex]["ITEM_NAME"].ToString();
                        objBal.Quantity =ds.Tables[1].Rows[gvrow.DataItemIndex]["QTY"].ToString();
                        objBal.BalQTY = ds.Tables[1].Rows[gvrow.DataItemIndex]["AVLBL_QTY"].ToString();
                        objBal.Rate = ds.Tables[1].Rows[gvrow.DataItemIndex]["RATE_PER_ITEM"].ToString();
                        objBal.Tax = ds.Tables[1].Rows[gvrow.DataItemIndex]["TAX"].ToString();
                        objBal.Discount = ds.Tables[1].Rows[gvrow.DataItemIndex]["DISCOUNT"].ToString();
                        objBal.RtnItem = ((TextBox)dgShow.Rows[gvrow.DataItemIndex].FindControl("txtRtnItem")).Text;
                        objBal.ItemId = ds.Tables[1].Rows[gvrow.DataItemIndex]["ITEM_ID"].ToString();
                        objBal.GRNID = ds.Tables[1].Rows[gvrow.DataItemIndex]["GRN_ID"].ToString();
                        ds = objBll.Insert_Return_data(objBal);
                        Table1.Visible = false;
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Item Return Entered Successfully')", true);
                        fillFunctions.Fill(ddGrnNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GRN_NO_AVAL), true, FillFunctions.FirstItem.Select);
                    
                    }
                }
        }
        

    }
}
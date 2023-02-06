using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Data.SqlClient;

public partial class Inventory_Pur_RFQ_Item_Rates : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg, str;
    StringBuilder strBill = new StringBuilder();

    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        trRmrk.Visible = trBtn.Visible = false;
        if (!IsPostBack)
        {
            btnView.Attributes.Add("OnClick", "return validateView()");
            pushData();
        }
    }
    void pushData()
    {
        fillFunctions.Fill(ddlPurRFQID, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.RFQ_No), true, FillFunctions.FirstItem.Select);

        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
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


    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
        {
            //tdItem.Visible = thItem.Visible = true;
            //fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store_Item, ddlStore.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {

        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.Typ = "0";
        objBal.ReqNo = "";
        objBal.VenId = "";
        objBal.ItemId = "";
        objBal.ReqNo = ddlPurRFQID.SelectedValue;
        objBal.VenId = ddlVendor.SelectedValue;
        //if (ddlItem.SelectedIndex > 0)
        //{
        //    objBal.Typ = "1";
        //    objBal.ItemId = ddlItem.SelectedValue;
        //}
        fillFunctions.Fill(gvItemDetail, objBll.getQuotationItem(objBal));


        if (gvItemDetail.Rows.Count == 0)
        {
            trBtn.Visible = trRmrk.Visible = false;
        }
        else
        {
            trBtn.Visible = trRmrk.Visible = true;
        }
        btnCmprtvStmnt.Visible = false;
    }
    protected void ddlPurRFQID_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnCmprtvStmnt.Visible = true;
        trBtn.Visible = true;
        thVendor.Visible = tdVendor.Visible = true;
        fillFunctions.Fill(ddlVendor, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.RFQ_Vendor, ddlPurRFQID.SelectedValue), true, FillFunctions.FirstItem.Select);
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow itm in gvItemDetail.Rows)
        {
            objBal.ItemId = gvItemDetail.DataKeys[itm.RowIndex].Values[0].ToString();
            objBal.VenId = gvItemDetail.DataKeys[itm.RowIndex].Values[1].ToString();
            objBal.ItemName = itm.Cells[1].Text;
            objBal.Quantity = itm.Cells[3].Text;
            objBal.Rate = ((TextBox)itm.FindControl("txtRate")).Text;
            objBal.Tax = ((TextBox)itm.FindControl("txtTax")).Text;
            objBal.Discount = ((TextBox)itm.FindControl("txtDiscount")).Text;
            objBal.SessionUserId = Session["UserId"].ToString(); ;//Session["EMP_CODE"].ToString();
            objBal.Remark = txtRmrk.Text;
            msg = objBll.RFQItemUpdate(objBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        }
        gvItemDetail.DataSource = "";
        gvItemDetail.DataBind();
        txtRmrk.Text = "";
        //ddlItem.SelectedIndex = ddlPurRFQID.SelectedIndex = ddlStore.SelectedIndex = ddlVendor.SelectedIndex = 0;
        //tdMain.Visible = false;
        btnCmprtvStmnt.Visible = true;
        trBtn.Visible = true;
    }
    protected void gvItemDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txtRate = (TextBox)e.Row.FindControl("txtRate");
            txtRate.Attributes.Add("onkeypress", "OnlyDigitWithDecimal()");
            TextBox txtTax = (TextBox)e.Row.FindControl("txtTax");
            txtTax.Attributes.Add("onkeypress", "OnlyDigitWithDecimal()");
            TextBox txtDiscount = (TextBox)e.Row.FindControl("txtDiscount");
            txtDiscount.Attributes.Add("onkeypress", "OnlyDigitWithDecimal()");
        }
    }


    protected void btnCmprtvStmnt_Click(object sender, EventArgs e)
    {
        btnView.Visible = false;
        tdMain.Visible = true;
        objBal.Typ = "1";
        objBal.ReqNo = ddlPurRFQID.SelectedValue;
        dt = databaseFunctions.GetDataSet(objBll.getComparison(objBal)).Tables[0];

        string str1 = ""; string str2 = ""; double AMT; string style = "";
        int jj;
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            strBill.Append("<table style='font-family:Tahoma;font-size:10pt;width:100%' cellspacing='0' cellpadding='2'><tr align='center'><th style='border-top: black 1px solid; border-bottom: black 1px solid;width:20px'>SL#</th>"
            + "<th style='border-top: black 1px solid; border-bottom: black 1px solid;width:200px;padding-left:10px' align='left'>Item Name</th>");
            AMT = 0; jj = 1;
            str1 += "<tr><td style='border-bottom: black 1px solid;' align='left'>" + (i + 1).ToString() + ".</td>";
            str1 += "<td style='border-bottom: black 1px solid;' align='left'>" + dt.Rows[i]["ITEM_NAME"].ToString() + "</td>";
            objBal.Typ = "2";
            objBal.ItemName = dt.Rows[i]["RFQ_ITEM_ID"].ToString();
            DataSet ds1 = databaseFunctions.GetDataSet(objBll.getComparison(objBal));
            DataTable dt1 = ds1.Tables[0];

            for (int x = 0; x < dt1.Rows.Count; x++)
            {
                DataRow dr = dt1.Rows[x];

                str += "<th style='border-top: black 1px solid; border-bottom: black 1px solid;width:200px;' align='left'>" + dr["VENDOR_ORG_NAME"].ToString() + "</th>";
                AMT = Convert.ToDouble(dr["RFQ_ITEM_AMOUNT"]);
                style = "L" + jj.ToString();
                str2 += "<td style='border-bottom: black 1px solid;' align='left'>" + Convert.ToDouble(dr["RFQ_ITEM_AMOUNT"]).ToString("N2") + "(" + style + ")</td>";
                jj++;

            }
            str1 += str2 + "</tr>";
            str2 = "";
            strBill.Append(str + "</tr>");
            strBill.Append(str1);
            strBill.Append("</table>");
            str1 = str = "";

        }

        tdMain.InnerHtml = strBill.ToString();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



public partial class Inventory_Pur_RFQ_Master : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;
    string[] ven;
    SqlDataReader dr;
    DataTable myTable = new DataTable("myTable");
    DataColumn ITEM_ID = new DataColumn("ITEM_ID", Type.GetType("System.String"));
    DataColumn ITEM_NAME = new DataColumn("ITEM_NAME", Type.GetType("System.String"));
    DataColumn QTY = new DataColumn("QTY", Type.GetType("System.String"));
    DataColumn UNIT = new DataColumn("UNIT", Type.GetType("System.String"));
    DataColumn SPECIFICATION = new DataColumn("SPECIFICATION", Type.GetType("System.String"));
    DataRow NewRow;
    int count = 0,count1=0;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        
        if (!IsPostBack)
        {
            step1.ActiveTabIndex = 0;
            pushData();
            ViewState["dt"] = "";
            ViewState["amount"] = "";
            ViewState["pur_id"] = "";
            ViewState["fan_amt"] = "";
            ViewState["myTable"] = "";
            btnSubmit.Attributes.Add("onClick", "return validateAdd()");
            btnAdd.Attributes.Add("onClick", "return validate()");
            btnDrctFinish.Attributes.Add("onClick", "return validateRe()");
        }
    }
    void pushData()
    {
        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.All);

        //fillFunctions.Fill(ddlItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDrctStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        ven = new string[10];
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
        myTable.Columns.Add(ITEM_ID); myTable.Columns.Add(ITEM_NAME);
        myTable.Columns.Add(QTY); myTable.Columns.Add(UNIT); myTable.Columns.Add(SPECIFICATION);
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            ddlPurId.SelectedIndex = ddlStore.SelectedIndex = 0;
            trItemDetails.Visible = trSupplierDetails.Visible = trRemark.Visible = false;
        }
        if (step1.ActiveTabIndex == 1)
        {
            ddlDrctStore.SelectedIndex = ddlDrctItem.SelectedIndex = 0;
            ddlDrctItem.Enabled = ddlDrctStore.Enabled = true;
            trDirectItemDetails.Visible = trDirectSuppDetails.Visible = trDirect.Visible = false;
        }
    }

    protected void btnViewItemDetail_Click(object sender, EventArgs e)
    {
        objBal.Typ = "0";
        objBal.PurNo = "0";
        objBal.StoreName = "0";
        objBal.ItemId = "0";
        objBal.ItemName = "0";
        if (ddlPurId.SelectedIndex > 0)
        {
            objBal.Typ = "1";
            objBal.PurNo = ddlPurId.SelectedValue;
        }
        if (ddlStore.SelectedIndex > 0)
        {
            objBal.Typ = "2";
            objBal.StoreName = ddlStore.SelectedValue;
        }
        
        trItemDetails.Visible = trSupplierDetails.Visible = trRemark.Visible = true;
        fillFunctions.Fill(gvRFQItemDetails, objBll.RFQItemDetails(objBal));
        fillFunctions.Fill(gvSuppDetails, objBll.RFQSupplierDetails(objBal));
    }
    protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStore.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlPurId, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.RFQPurReqNo, ddlStore.SelectedValue), true, FillFunctions.FirstItem.All);
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlPurId);
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow itm1 in gvRFQItemDetails.Rows)
        {
             CheckBox chkBxItem = (CheckBox)itm1.FindControl("CHK_SelectAllItem");
             if (chkBxItem != null && chkBxItem.Checked)
             {
                 count1++;
             }
          }

        foreach (GridViewRow itm in gvSuppDetails.Rows)
        {
            CheckBox chkBx = (CheckBox)itm.FindControl("CHK_SelectAll");
            if (chkBx != null && chkBx.Checked)
            {
                count++;
            }
        }
        if (count1 == 0)
        {
            msg = "-Please Select Item from list!!";
            
        }
        if (count == 0)
        {
            msg =msg+ "-Please Select Supplier from list!!";
            
        }
        if(count1==0 || count==0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
            return;
        }
        else
        {
            objBal.ReqNo = generatePurRFQNo();
            objBal.PurNo = (ddlPurId.SelectedIndex > 0) ? ddlPurId.SelectedItem.ToString() : "";
            objBal.SessionUserId = Session["UserId"].ToString(); ;
            objBal.Remark = txtRFQRmrk.Text;
            objBal.ID = objBll.RFQMasterInsert(objBal);
            foreach (GridViewRow itm in gvSuppDetails.Rows)
            {
                CheckBox chkBx = (CheckBox)itm.FindControl("CHK_SelectAll");
                int i = 0;
                if (chkBx != null && chkBx.Checked)
                {

                    ven[i] = objBal.VenId = gvSuppDetails.DataKeys[itm.RowIndex].Value.ToString();
                    msg = objBll.RFQDetailInsert(objBal);
                    foreach (GridViewRow itm1 in gvRFQItemDetails.Rows)
                    {
                        CheckBox chkBxItem = (CheckBox)itm1.FindControl("CHK_SelectAllItem");
                        
                        if (chkBxItem != null && chkBxItem.Checked)
                        {

                            objBal.ItemId = gvRFQItemDetails.DataKeys[itm1.RowIndex].Value.ToString();
                            objBal.Quantity = itm1.Cells[3].Text;
                            msg = objBll.RFQItemDetailInsert(objBal);
                        }
                    }
                    i++;
                }


            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtRFQforVender.aspx?ID=" + objBal.ID + "&venId=" + ven[0] + "')", true);
            gvRFQItemDetails.DataSource = "";
            gvRFQItemDetails.DataBind();
            gvSuppDetails.DataSource = "";
            gvSuppDetails.DataBind();
            ddlPurId.SelectedIndex = ddlStore.SelectedIndex = 0;
            txtRFQRmrk.Text = "";
        }
    }
    protected void ddlDrctStore_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDrctStore.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDrctItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store_Item, ddlDrctStore.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlDrctItem);
        }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (gvDirectItemDetails.Rows.Count > 0)
        {
            myTable = (DataTable)ViewState["myTable"];
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                NewRow = myTable.Rows[i];
                if (NewRow["ITEM_ID"].ToString() == ddlDrctItem.SelectedValue)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Items is already in list.')", true);
                    ddlDrctStore.SelectedIndex = ddlDrctItem.SelectedIndex = 0;
                    txtDrctRmrk.Text = "";
                    return;
                }
            }
        }
        NewRow = myTable.NewRow();
        NewRow["ITEM_ID"] = ddlDrctItem.SelectedValue;
        NewRow["ITEM_NAME"] = ddlDrctItem.SelectedItem.ToString();
        NewRow["QTY"] = txtQty.Text;
        NewRow["SPECIFICATION"] = txtSpec.Text.Trim(' ');
        myTable.Rows.Add(NewRow);
        ViewState["myTable"] = myTable;
        gvDirectItemDetails.DataSource = myTable;
        gvDirectItemDetails.DataBind();
        ddlDrctStore.Enabled = ddlDrctItem.Enabled = true;
        ddlDrctStore.SelectedIndex = ddlDrctItem.SelectedIndex = 0;
        txtQty.Text = txtSpec.Text = "";
        trDirectItemDetails.Visible = true;
        fillFunctions.Fill(gvDirectSuppDetails, objBll.RFQSupplierDetails(objBal));
        trDirectSuppDetails.Visible=trDirect.Visible = true;
    }
    
    protected void btnDrctFinish_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow itm in gvDirectSuppDetails.Rows)
        {
            CheckBox chkBx = (CheckBox)itm.FindControl("CHK_SelectAll");
            if (chkBx != null && chkBx.Checked)
            {
                count++;
            }
        }
        if (count == 0)
        {
            msg = "Please Select Supplier from list!!";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+msg+"')", true);
            return;
        }
        else
        {
            objBal.ReqNo = generatePurRFQNo();
            objBal.PurNo = (ddlPurId.SelectedIndex > 0) ? ddlPurId.SelectedItem.ToString() : "";
            objBal.SessionUserId = Session["UserId"].ToString(); ;
            objBal.Remark = txtDrctRmrk.Text;
            objBal.ID = objBll.RFQMasterInsert(objBal);
            foreach (GridViewRow itm in gvDirectSuppDetails.Rows)
            {
                CheckBox chkBx = (CheckBox)itm.FindControl("CHK_SelectAll");

                if (chkBx != null && chkBx.Checked)
                {
                    objBal.VenId = gvDirectSuppDetails.DataKeys[itm.RowIndex].Value.ToString();
                    msg = objBll.RFQDetailInsert(objBal);
                    foreach (GridViewRow itm1 in gvDirectItemDetails.Rows)
                    {
                        objBal.ItemId = gvDirectItemDetails.DataKeys[itm1.RowIndex].Value.ToString();
                        objBal.Quantity = itm1.Cells[2].Text;
                        msg = objBll.RFQItemDetailInsert(objBal);
                    }
                }


            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtRFQforVender.aspx?" + objBal.ID + "')", true);
            gvDirectItemDetails.DataSource = "";
            gvDirectItemDetails.DataBind();
            gvDirectSuppDetails.DataSource = "";
            gvDirectSuppDetails.DataBind();
            ddlPurId.SelectedIndex = ddlDrctStore.SelectedIndex = ddlDrctItem.SelectedIndex = 0;
            ddlDrctItem.Enabled = ddlDrctStore.Enabled = true;
            txtDrctRmrk.Text = txtSpec.Text = "";
        }

    }
    string generatePurRFQNo()
    {
        string strPurRFQNo;
        dr = objBll.GetRFQFinancialYear();
        if (dr.Read())
            strPurRFQNo = "RFQ/" + CommonFunctions.getFinancialYear() + "/" + dr[0].ToString();
        else
            strPurRFQNo = "RFQ/" + CommonFunctions.getFinancialYear() + "/01";
        return strPurRFQNo;
    }

   
    protected void gvDirectItemDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        myTable = (DataTable)ViewState["myTable"];
        myTable.Rows.RemoveAt(e.RowIndex);
        gvDirectItemDetails.DataSource = myTable;
        gvDirectItemDetails.DataBind();
        msg = "One Item delete form list";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+msg+"')", true);

    }
}
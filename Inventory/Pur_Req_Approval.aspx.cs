using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Inventory_Pur_Req_Approval : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        trRmrk.Visible = btnApprove.Visible = btnCancel.Visible = btnRcmnd.Visible = false;
        Initialize();
        if (!IsPostBack)
        {
            
            ViewState["dt"] = "";
            ViewState["data"] = "";
            ViewState["ID"] = "";
            ViewState["req_id"] = "";
            ViewState["action_by"] = "";
            Bindgv_requisition();
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
    void Bindgv_requisition()
    {
        

        objBal.SessionUserId = Session["UserId"].ToString();
        gv_requisition.DataSource = ViewState["data"] = objBll.getPurchaseRqsts(objBal);
        gv_requisition.DataBind();
       
    }
    public void Bindgv_ItemDetails()
    {
        objBal.ID = ViewState["req_id"].ToString();
        objBal.SessionUserId = Session["UserId"].ToString();
        gv_ItemDetails.DataSource = ViewState["dt"] =objBll.getPurRqstItem(objBal);
        gv_ItemDetails.DataBind();
        Bindgv_requisition();
    }
    public void Bindgv_SuppDetails()
    {
        objBal.VenId = ViewState["req_id"].ToString();
        fillFunctions.Fill(gv_SupDetails, objBll.getPurRqstSupplier(objBal));
        
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        GetData();
        objBal.ForwardTo = "8";
        objBll.PurReqApproved(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Approved successfully.')", true);
        ViewState["req_id"] = "";
        Bindgv_ItemDetails();
        Bindgv_SuppDetails();
        Bindgv_requisition();
        txtRemark.Text = "";
    }
    protected void btnRcmnd_Click(object sender, EventArgs e)
    {
        GetData();
        objBal.ForwardTo = "3";
        objBll.PurReqReccomend(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request forwarded successfully.')", true);
        ViewState["req_id"] = "";
        Bindgv_ItemDetails();
        Bindgv_SuppDetails();
        Bindgv_requisition();
        txtRemark.Text = "";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ViewState["action_by"].ToString() == "1")
        {
            objBal.Status = "3";
        }
        else if (ViewState["action_by"].ToString() == "2")
        {
            objBal.Status = "4";
        }
        GetData();
        objBll.PurReqCanceled(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Canceled successfully.')", true);
        ViewState["req_id"] = "";
        Bindgv_ItemDetails();
        Bindgv_SuppDetails();
    }
    protected void gv_requisition_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        ViewState["req_id"] = gv_requisition.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        DataSet ds = (DataSet)ViewState["data"];
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("PUR_REQ_ID=" + ViewState["req_id"].ToString() + "");
        ViewState["action_by"] = dr[0]["ACTION"].ToString();
        Bindgv_ItemDetails();
        Bindgv_SuppDetails();
        btnCancel.Visible = true;
        trRmrk.Visible = true;
        if (ViewState["action_by"].ToString() == "1")
        {
            btnRcmnd.Visible = true;
        }
        else if (ViewState["action_by"].ToString() == "2")
        {
            btnApprove.Visible = true;
        }
        
    }
    protected void gv_ItemDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_ItemDetails.EditIndex = -1;
        Bindgv_ItemDetails();
    }
    
    protected void gv_ItemDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_ItemDetails.EditIndex = e.NewEditIndex;
        Bindgv_ItemDetails();
    }

  
    protected void gv_ItemDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox qty = (TextBox)gv_ItemDetails.Rows[e.RowIndex].Cells[2].Controls[0];
        ViewState["ID"] = gv_ItemDetails.DataKeys[e.RowIndex].Value;
        objBal.ID = ViewState["ID"].ToString();
        objBal.Quantity = qty.Text;
        msg = objBll.Update_Qty(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        gv_ItemDetails.EditIndex = -1;
        Bindgv_ItemDetails();
    }
    protected void gv_ItemDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        objBal.ID = gv_ItemDetails.DataKeys[e.RowIndex].Value.ToString();
        objBal.ItemName = gv_ItemDetails.Rows[e.RowIndex].Cells[1].Text;
        objBal.SessionUserId = Session["UserId"].ToString();
        msg = objBll.DeleteItem(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        gv_ItemDetails.EditIndex = -1;
        Bindgv_ItemDetails();
    }
    protected void gv_ItemDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gv_ItemDetails.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        DataSet ds = (DataSet)ViewState["dt"];
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("REQ_SUB_ID=" + ViewState["ID"].ToString() + "");
        ViewState["action_by"] = dr[0]["ACTION"].ToString();
    }

    public void GetData()
    {
        DataSet ds = (DataSet)ViewState["dt"];
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("PUR_REQ_ID=" + ViewState["req_id"].ToString() + "");
        objBal.ID = ViewState["req_id"].ToString();
        objBal.Identification = dr[0]["PUR_REQ_ID"].ToString();
        objBal.Remark = txtRemark.Text;
        objBal.Typ = "8";
        objBal.SessionUserId = Session["UserId"].ToString();
    }
    protected void gv_SupDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        objBal.KeyId = gv_ItemDetails.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        msg = objBll.DeleteSupp(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        gv_SupDetails.EditIndex = -1;
        Bindgv_SuppDetails();
    }
}
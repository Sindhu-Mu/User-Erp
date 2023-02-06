using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_BookRequisitionApproval : System.Web.UI.Page
{
    FillFunctions FillFunction;
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DatabaseFunctions DataBaseFunction;
    DataTable dt;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = "";
            ViewState["Action_by"] = "";
            Bind_gvBookReq();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void clear()
    {
        txtRemark.Text = "";
        DivSubmit.Visible = false;
        gvBookDetail.DataSource = "";
        gvBookDetail.DataBind();
    }
    void Bind_gvBookReq()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = ObjFacBll.BookReqApproval(ObjFacBal);
        ViewState["dt"] = ds;
        gvAppBookReq.DataSource = ds;
        gvAppBookReq.DataBind();
       
    }
    void FillgvBookDetail()
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = ObjFacBll.BookDetail(ObjFacBal);
        ViewState["dt"] = ds;
        gvBookDetail.DataSource = ds;
        gvBookDetail.DataBind();
        DivSubmit.Visible = (gvBookDetail.Rows.Count > 0);
    }
    protected void gvAppBookReq_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvAppBookReq.DataKeys[0].Value;
        DataSet ds = (DataSet)ViewState["dt"];
        dt = ds.Tables[0];
        
        DataRow[] dr = dt.Select("BOOK_REQ_ID=" + ViewState["ID"].ToString() + "");
        ViewState["Action_By"] = dr[0]["ACTION"].ToString();
        FillgvBookDetail();
        btnCancel.Visible = true;
        if (ViewState["Action_By"].ToString() == "1")
        {
            btnRecommend.Visible = true;
        }
        if (ViewState["Action_By"].ToString() == "2")
        {
            btnApprove.Visible = true;
        }
    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString(); 
        ObjFacBal.TypeId = "10";
        ObjFacBal.Forward_To = "15";
        ObjFacBll.FacBookReqApprove(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Approved Sucessfully')", true);
        Bind_gvBookReq();
      
        clear();
    }

    protected void btnRecommend_Click(object sender, EventArgs e)
    {
        ObjFacBal.Forward_To = "3";
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString(); 
        ObjFacBal.TypeId = "10";
        ObjFacBll.FacBookReqRecommend(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request forwarded successfully.')", true);
        Bind_gvBookReq();
       
        clear();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString(); 
        ObjFacBal.TypeId = "10";
        if (ViewState["Action_By"].ToString() == "1")
        {
            ObjFacBal.Status = "3";
        }
        else if (ViewState["Action_By"].ToString() == "2")
        {
            ObjFacBal.Status = "4";
        }

        ObjFacBll.FacBookReqCancel(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Request Canceled successfully.')", true);
        clear();
    }
    protected void gvBookDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvBookDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        DataSet ds = (DataSet)ViewState["dt"];
        dt = ds.Tables[0];
        DataRow[] dr = dt.Select("BOOK_REQ_ID=" + ViewState["ID"].ToString() + "");
     
    }
    protected void gvBookDetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvBookDetail.EditIndex = e.NewEditIndex;
        FillgvBookDetail();
    }
    protected void gvBookDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox Price = (TextBox)gvBookDetail.Rows[e.RowIndex].Cells[4].Controls[0];
        TextBox Noc = (TextBox)gvBookDetail.Rows[e.RowIndex].Cells[5].Controls[0];
        TextBox ISBN = (TextBox)gvBookDetail.Rows[e.RowIndex].Cells[6].Controls[0];
        ViewState["ID"] = gvBookDetail.DataKeys[e.RowIndex].Value;
        ObjFacBal.Id = ViewState["ID"].ToString();
        ObjFacBal.Amt = Price.Text;
        ObjFacBal.Capicity = Noc.Text;
        ObjFacBal.No = ISBN.Text;
        Msg = ObjFacBll.UpdateBook(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        gvBookDetail.EditIndex = -1;
        FillgvBookDetail();
    }
    protected void gvBookDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvBookDetail.EditIndex = -1;
        FillgvBookDetail();
    }
}
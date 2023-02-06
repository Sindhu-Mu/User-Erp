using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Facility_BookRequisition : System.Web.UI.Page
{


    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    string Msg;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSubmit.Attributes.Add("onClick", "return validate()");
        if (!IsPostBack)
        {
            FillDetail();
        }
    }
    void Initialize()
    {
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void FillDetail()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjFacBll.GetBookRequisitionDetail(ObjFacBal).Tables[0];
        grdBookReq.DataSource = dt;
        grdBookReq.DataBind();
    }
    void clear()
    {
        txtTitle.Text = txtEdition.Text = txtAuNme.Text = txtPrice.Text = txtNOPubliser.Text = "";
        txtCopiesRe.Text = txtISBN.Text = txtRemark.Text = txtNOStu.Text = "";
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.Value = txtTitle.Text;
        ObjFacBal.Info = txtEdition.Text;
        ObjFacBal.Name = txtAuNme.Text;
        ObjFacBal.Amt = txtPrice.Text;
        ObjFacBal.AuthFor = txtNOPubliser.Text;
        ObjFacBal.NoOfPer = txtNOStu.Text;
        ObjFacBal.Count = txtCopiesRe.Text;
        ObjFacBal.No = txtISBN.Text;
        ObjFacBal.Remark = txtRemark.Text;
        Msg = ObjFacBll.BookRequisitionInsert(ObjFacBal);
        if (Msg.Contains("Successfully"))
        {
            TabContainer1.ActiveTabIndex = 1;
            FillDetail();
            clear();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Facility_TransportCancellation : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    FacBLL ObjBll;
    FacBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new FacBLL();
        ObjBal = new FacBAL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        btnShow.Attributes.Add("OnClick", "return validateShow()");
        btnCancel.Attributes.Add("OnClick", "return validateView()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            
        }
       
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        show();
    }
    void show()
    {
        
        Student.ShowStudent(txtStudent.Text);
        ObjBal.Id = txtStudent.Text;
        ObjBal.TypeId = "1";
        ObjBal.RateSem = ddlSem.SelectedValue;
      
        ds = ObjBll.getStuDetailForCancelation(ObjBal);

        ViewState["STU_STATUS"] = ds.Tables[1].Rows[0]["STATUS"].ToString();
       
        if (ds.Tables[0].Rows.Count > 0)
        {

            gvDetail.DataSource = ds.Tables[0];
            gvDetail.DataBind();
            ObjBal.StuAdmNo = ds.Tables[0].Rows[0][0].ToString();
            ViewState["STU_MAIN_ID"] = ObjBal.StuAdmNo;

        }
        else
        {
            if (ViewState["STU_STATUS"].ToString() == "4")
            {
                gvDetail.DataSource = ds.Tables[0];
                gvDetail.DataBind();
                
            }
            if (ViewState["STU_STATUS"].ToString() == "11")
            {
                gvDetail.EmptyDataText = "Registration Cancelled";
                gvDetail.DataBind();
                gvAmt.Visible = false;
                txtRemark.Visible = false;
                lblRemark.Visible = false;
            }

            else
            {
                gvDetail.EmptyDataText = "Not Applied For Transport Registration";
                gvDetail.DataBind();

            }
        }
        if (ViewState["STU_STATUS"].ToString() == "4")
        {
           btnCancel.Visible = true;
            btnCancelApprove.Visible = false;
            if (Session["UserId"].ToString() == "209")
            {
                btnDue.Visible = false;
                btnCancel.Visible = false;
                gvAmt.Visible = false;
                txtRemark.Visible = false;
                lblRemark.Visible = false;

            }
            else
            {
                btnDue.Visible = true;
                gvUpdatedDemand.Visible = true;
            }
           
        }
        if ((ViewState["STU_STATUS"].ToString() == "-2") ||(ViewState["STU_STATUS"].ToString() == "10"))
       {
           if (Session["UserId"].ToString() == "281" || Session["UserId"].ToString() == "502" || Session["UserId"].ToString() == "388" )
           {
               btnCancelApprove.Visible = false;
               btnDue.Visible = false;
           }
           else 
           {
               btnCancelApprove.Visible = true;
               btnDue.Visible = false;
           }
            btnCancel.Visible = false;
            gvAmt.Visible = false;
            txtRemark.Visible = false;
            lblRemark.Visible = false;
        }
        gvAmt.DataSource = ds.Tables[2];
        gvAmt.DataBind();
       
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
       
        ObjBal.TranRemark = txtRemark.Text;
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBal.RateSem = ddlSem.SelectedValue;
        ObjBal.StuAdmNo = ViewState["STU_MAIN_ID"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ObjBll.CancelRegistration(ObjBal) + "')", true);
        btnCancel.Visible = false;
        btnCancelApprove.Visible = false;
        gvAmt.Visible = false;
        show();
        btnDue.Visible = false;
        gvUpdatedDemand.Visible = false;
    }
  
   
    protected void btnCancelApprove_Click(object sender, EventArgs e)
    {
        btnCancel.Visible = true;
        btnCancelApprove.Visible = false;

        ObjBal.SessionUserID = Session["UserId"].ToString();

        ObjBal.StuAdmNo = ViewState["STU_MAIN_ID"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ObjBll.CancelApproveRegist(ObjBal) + "')", true);
        show();
       
    }
    protected void btnDue_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gvrow in gvAmt.Rows)
        {
            ObjBal.FeeDemand = ((TextBox)gvAmt.Rows[gvrow.DataItemIndex].FindControl("txtFee")).Text;
        }
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBal.RateSem = ddlSem.SelectedValue;
        ObjBal.StuAdmNo = ViewState["STU_MAIN_ID"].ToString();
       
        ds = ObjBll.UpdateDemamd(ObjBal);
        gvUpdatedDemand.DataSource = ds.Tables[0];
        gvUpdatedDemand.DataBind();
        gvAmt.Visible = false;
        btnDue.Visible = false;
    }
}
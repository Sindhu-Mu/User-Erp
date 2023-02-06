using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class Finance_ExamRegFeeReceive : System.Web.UI.Page
{
    ExamFunctions.FillFunctions FillFunction;
    ExamFunctions.QueryFunctions queryFunctions;
    SFBLL ObjBll;
    SFBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        btnShow.Attributes.Add("onClick", "return valid()");
        btnSave.Attributes.Add("onClick", "return validate()");
        Page.MaintainScrollPositionOnPostBack = true;
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlExamination, queryFunctions.GetCommand(ExamFunctions.QueryFunctions.QueryBaseType.Examination), true, ExamFunctions.FillFunctions.FirstItem.Select);
            ddlExamination.SelectedIndex = 1;
            txtEnrollment.Focus();
            ViewState["waveamt"] = "0";
        }
    }
    void Initialise()
    {
        FillFunction = new ExamFunctions.FillFunctions();
        queryFunctions = new ExamFunctions.QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new SFBLL();
        ObjBal = new SFBAL();
        ds = new DataSet();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnrollment.Text);
        gvCrsDetail.DataSource = "";
        gvCrsDetail.DataBind();
        txtDemand.Text = txtAmount.Text = ""; txtDiscount.Text = "0";
        ViewState["waveamt"] = "0";
        txtAmount.Focus();
        ShowDetail();
    }
    private void ShowDetail()
    {

        double fineamount;
        double TotalFee = 0;
        double detainfeeamt = 0;
        int onepaperamt = 0;
        double hostelamt = 0;
        ObjBal.balEnrollment = txtEnrollment.Text;
        ObjBal.balCommonID = ddlExamination.SelectedValue;
        ds = ObjBll.ExamRegFeeReceiveingSelect(ObjBal);
        if (ds.Tables.Count > 0)
        {
            gvPrevDue.DataSource = ds.Tables[3];
            gvPrevDue.DataBind();

            gvCrsDetail.DataSource = ds.Tables[0];
            gvCrsDetail.DataBind();
            foreach (GridViewRow itm in gvCrsDetail.Rows)
            {
                TotalFee += Convert.ToDouble(itm.Cells[5].Text);
               

            }
            foreach (GridViewRow itm in gvCrsDetail.Rows)
            {
                try
                {
                    string crs_reg_type_id = (itm.Cells[6].Text);
                    string crs_type_id = (itm.Cells[7].Text);

                    if (crs_type_id == "0" && crs_reg_type_id != "1")
                    {
                        onepaperamt = Convert.ToInt16(itm.Cells[5].Text);
                    }
                    if (crs_reg_type_id != "1")
                    {
                        detainfeeamt += Convert.ToDouble(itm.Cells[5].Text);
                    }

                    if (onepaperamt == 5000)
                    {
                        if (detainfeeamt > 20000)
                        {
                            ViewState["waveamt"] = detainfeeamt - 20000;
                        }
                    }
                    if (onepaperamt == 3000)
                    {
                        if (detainfeeamt > 12000)
                        {
                            ViewState["waveamt"] = detainfeeamt - 12000;
                        }
                    }
                    if (onepaperamt == 2000)
                    {
                        if (detainfeeamt > 8000)
                        {
                            ViewState["waveamt"] = detainfeeamt - 8000;
                        }
                    }
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('error.')", true);
                }
                            
            }
           
           
            if (gvCrsDetail.Rows.Count > 0)
            {
                try
                {
                    gvCrsDetail.FooterRow.Cells[5].Text = TotalFee.ToString("N2");
                    TotalFee = TotalFee - Convert.ToDouble(ViewState["waveamt"].ToString());
                    //gvCrsDetail.FooterRow.Cells[5].Text = TotalFee.ToString("N2");
                    gvPrevious.DataSource = ds.Tables[2];
                    gvPrevious.DataBind();
                    txtDemand.Text = gvCrsDetail.FooterRow.Cells[5].Text;
                    //Convert.ToInt32(gvCrsDetail.Rows.Count * 500).ToString("N2");
                    txtDiscount.Text = ViewState["waveamt"].ToString();
                    fineamount = (Convert.ToInt32(ds.Tables[1].Rows[0][0]) > 0) ? Convert.ToInt32(ds.Tables[1].Rows[0][0]) * 50 : 0;
                    txtFine.Text = fineamount.ToString("N2");
                    hostelamt = (Convert.ToInt32(ds.Tables[4].Rows[0][0]));
                    txtHstl.Text = hostelamt.ToString();
                    txtAmount.Text = (hostelamt + fineamount + Convert.ToInt32(TotalFee)).ToString("N2");
                    btnSave.Visible = (gvCrsDetail.Rows.Count > 0);
                }
                catch
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('error.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Student not registered for selected examination.')", true);
                txtEnrollment.Text = "";
                txtEnrollment.Focus();
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Student not registered for selected examination.')", true);
            txtEnrollment.Text = "";
            txtEnrollment.Focus();
        }


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.balDemandId = gvCrsDetail.DataKeys[0].Value.ToString();
        ObjBal.balRemark = txtRemark.Text;
        ObjBal.balAmount = txtDemand.Text;
        ObjBal.balHeadAmt = txtFine.Text;
        ObjBal.balAmt = txtDiscount.Text;
        ObjBal.balAdjAmount = txtAmount.Text;
        ObjBal.balSession = Session["UserId"].ToString();
        ObjBal.balType = ddltype.SelectedValue;
        ObjBal.balData = txtdue.Text;
        ObjBal.balRate = txtHstl.Text;
        string msg = ObjBll.ExamRegFeeReceiveingInsert(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtExamRegFee.aspx?=" + msg + "',alwaysraised='yes')", true);
        gvCrsDetail.DataSource = "";
        gvCrsDetail.DataBind();
        txtDemand.Text = txtAmount.Text = "";
        txtDiscount.Text = "0";
        txtdue.Text = "0";
        txtHstl.Text = "0";
        txtEnrollment.Focus();
        btnSave.Visible = false;
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        if (txtDiscount.Text != "")
        {
            txtAmount.Text = (Convert.ToDouble(txtDemand.Text) + Convert.ToDouble(txtFine.Text) - Convert.ToDouble(txtDiscount.Text)).ToString("N2");
            txtRemark.Focus();
        }
    }
    protected void gvCrsDetail_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[6].Visible = false;
        e.Row.Cells[7].Visible = false;
    }
}
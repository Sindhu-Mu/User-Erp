using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
public partial class Finance_StuFeeModification : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    SFBLL ObjBll;
    SFBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    DataTable dt;
    double TotDemand, TotRcv, TotAdjust, TotBalance, TotWave, TotalConcession, TotalReceived, TotalMode;
    DropDownList ddlHead, ddlPaymode, ddlBank;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new SFBLL();
        ObjBal = new SFBAL();
        ds = new DataSet();
        dt = new DataTable();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        btnAdd.Attributes.Add("onClick", "return validate()");
        btnShow.Attributes.Add("onClick", "return valid()");
        if (!IsPostBack)
        {
            ViewState["dtMode"] = ViewState["dtReceipt"] = ViewState["dt"] = "";
            ViewState["Id"] = "";
            pushData();
        }
    }
    void pushData()
    {
        FillFunction.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        //FillFunction.Fill(ddlProcess, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FeeProcess), true, FillFunctions.FirstItem.Select);
        //FillFunction.Fill(ddlFine, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FeeFineRule), true, FillFunctions.FirstItem.Select);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjBal.balCommonID = txtEnrollment.Text;
        dt = ObjBll.GetStudentDetails(ObjBal).Tables[0];
        if (dt.Rows.Count > 0)
        {
            if (ddlBranch.Items.Count == 0)
            {
                FillFunction.Fill(ddlBranch, dt, true, FillFunctions.FirstItem.Select);
                ddlSemester.SelectedValue = dt.Rows[0][2].ToString();
                ddlBranch.SelectedIndex = 1;
            }
        }
        gvFees.DataSource = "";
        gvFees.DataBind();
        ShowDetail();

    }
    protected void gvFees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvFees.EditIndex = -1;
        ShowDetail();
    }
    protected void gvFees_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvFees.EditIndex = e.NewEditIndex;
        ShowDetail();
    }
    private void ShowDetail()
    {
        TotDemand = TotRcv = TotAdjust = TotBalance = TotWave = 0;
        DivOther.Visible = cFooter.Visible = false;
        GridMode.DataSource = "";
        GridMode.DataBind();
        GridReceipt.DataSource = "";
        GridReceipt.DataBind();
        ObjBal.balEnrollment = txtEnrollment.Text;
        ObjBal.balBranch = ddlBranch.SelectedValue;
        ObjBal.balSem = ddlSemester.SelectedValue;
        ds = ObjBll.StudentDemandFeeSelectII(ObjBal);
        if (ds.Tables.Count > 0)
        {
            lblName.Text = ds.Tables[0].Rows[0][0].ToString();
            lblBatch.Text = ds.Tables[0].Rows[0][1].ToString();
            dt = ds.Tables[1];
            gvFees.DataSource = dt;
            gvFees.DataBind();
            if (dt.Rows.Count > 0)
            {

                DivOther.Visible = true;

                foreach (GridViewRow itm in gvFees.Rows)
                {
                    TotDemand += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_FEE_AMT"]);
                    TotAdjust += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_ADJUST_AMT"]);
                    TotWave += Convert.ToDouble(dt.Rows[itm.RowIndex]["FEE_WAVE_OFF"]);
                    TotRcv += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_RCV_AMT"]);
                    TotalConcession += Convert.ToDouble(dt.Rows[itm.RowIndex]["CONCESSION_AMT"]);
                    TotBalance += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_BALANCE_AMT"]);
                }
                if (gvFees.Rows.Count > 0)
                {
                    gvFees.FooterRow.Cells[2].Text = TotDemand.ToString("N2");
                    gvFees.FooterRow.Cells[3].Text = TotAdjust.ToString("N2");                 
                    gvFees.FooterRow.Cells[4].Text = TotalConcession.ToString("N2");
                    gvFees.FooterRow.Cells[6].Text = TotWave.ToString("N2");
                    gvFees.FooterRow.Cells[7].Text = TotRcv.ToString("N2");
                    gvFees.FooterRow.Cells[8].Text = TotBalance.ToString("N2");
                    ViewState["dt"] = dt;
                    ObjBal.balDemandId = gvFees.DataKeys[0].Value.ToString();
                    FillFunction.Fill(ddlFeesHead, ObjBll.getDemandHead(ObjBal), true, FillFunctions.FirstItem.Select);
                    HD1.Value = gvFees.DataKeys[0].Value.ToString();
                }
            }
            gvPayTransaction.DataSource = ds.Tables[2];
            gvPayTransaction.DataBind();
            cFooter.Visible = (gvPayTransaction.Rows.Count > 0);
        }
    }
    protected void gvFees_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        dt = (DataTable)ViewState["dt"];
        double Amount = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtAmount")).Text);
        double AdjAmount = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtAdjust")).Text);
        double Concession = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtConcession")).Text);
        string ConcessionRemark = ((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtConcessionRemark")).Text;
        double WAVE = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtWAVE")).Text);
        double Received = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtRECEIVE")).Text);
        if ((Convert.ToDouble(dt.Rows[e.RowIndex]["FD_FEE_AMT"].ToString()) != Amount) || (Convert.ToDouble(dt.Rows[e.RowIndex]["FD_ADJUST_AMT"].ToString()) != AdjAmount) || (Convert.ToDouble(dt.Rows[e.RowIndex]["CONCESSION_AMT"].ToString()) != Concession) || (Convert.ToDouble(dt.Rows[e.RowIndex]["FEE_WAVE_OFF"].ToString()) != WAVE) || (Convert.ToDouble(dt.Rows[e.RowIndex]["FD_RCV_AMT"].ToString()) != Received))
        {
            ObjBal.balDemandId = gvFees.DataKeys[0].Value.ToString();
            ObjBal.balMainHeadId = dt.Rows[e.RowIndex]["FEE_MAIN_HEAD_ID"].ToString();
            ObjBal.balAmount = Amount.ToString();
            ObjBal.balAdjAmount = AdjAmount.ToString();
            ObjBal.balConcession = Concession.ToString();
            ObjBal.balRemark = ConcessionRemark;
            ObjBal.balWAVE = WAVE.ToString();
            ObjBal.balReceived = Received.ToString();
            ObjBal.balSession = Session["UserId"].ToString();
            string msg = ObjBll.StudentFeeDemandEntryUpdate(ObjBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        }
        gvFees.EditIndex = -1;
        ShowDetail();
    }
    protected void gvFees_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.balDemandId = gvFees.DataKeys[e.RowIndex].Values[0].ToString();
        ObjBal.balMainHeadId = gvFees.DataKeys[e.RowIndex].Values[1].ToString();
        string msg = ObjBll.StudentFeeDemandDelete(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        ShowDetail();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjBal.balDemandId = gvFees.DataKeys[0].Values[0].ToString();
        ObjBal.balMainHeadId = ddlFeesHead.SelectedValue;
        ObjBal.balAmount = txtAmount.Text;
        ObjBal.balAdjAmount = "0";
        ObjBal.balSession = Session["UserId"].ToString();
        string msg = ObjBll.StudentFeeDemandInsert(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        ShowDetail();
        txtAmount.Text = "";
        ddlFeesHead.SelectedIndex = 0;
    }
    protected void gvPayTransaction_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        gvPayTransaction.CssClass = "gridDynamic";
        gvPayTransaction.Rows[e.RowIndex].BackColor = Color.Yellow;
        TotalReceived = TotalMode = 0;
        ObjBal.balRcptNo = gvPayTransaction.DataKeys[e.RowIndex].Value.ToString();
        ViewState["Id"] = gvPayTransaction.DataKeys[e.RowIndex].Value.ToString();
        ds = ObjBll.GetStudentFeeReceiptInfo(ObjBal);
        if (ds.Tables.Count > 0)
        {
            lblReceiptNo.Text = "Payment details of Receipt S.No.-:" + (e.RowIndex + 1).ToString();
            GridReceipt.DataSource = ds.Tables[0];
            GridReceipt.DataBind();

            foreach (GridViewRow itm in GridReceipt.Rows)
            {
                TotalReceived += Convert.ToDouble(ds.Tables[0].Rows[itm.RowIndex]["FEE_RCV_TRAN_AMT"]);
                ddlHead = (DropDownList)itm.FindControl("ddlHead");
                FillFunction.Fill(ddlHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MainHeadId), true, FillFunctions.FirstItem.Select);
                ddlHead.SelectedValue = ds.Tables[0].Rows[itm.RowIndex]["FEE_MAIN_HEAD_ID"].ToString();
            }
            if (GridReceipt.Rows.Count > 0)
            {
                GridReceipt.FooterRow.Cells[2].Text = TotalReceived.ToString("N2");
                ViewState["dtReceipt"] = ds.Tables[0];

            }
            GridMode.DataSource = ds.Tables[1];
            GridMode.DataBind();
            foreach (GridViewRow itm in GridMode.Rows)
            {
                TotalMode += Convert.ToDouble(ds.Tables[1].Rows[itm.RowIndex]["RCV_TRAN_MODE_AMT"]);
                ddlPaymode = (DropDownList)itm.FindControl("ddlPayMode");
                ddlBank = (DropDownList)itm.FindControl("ddlBank");
                FillFunction.Fill(ddlPaymode, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PayMode), true, FillFunctions.FirstItem.Select);
                FillFunction.Fill(ddlBank, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Bank), true, FillFunctions.FirstItem.Select);
                ddlPaymode.SelectedValue = ds.Tables[1].Rows[itm.RowIndex]["PAY_MODE_ID"].ToString();
                ddlBank.SelectedValue = ds.Tables[1].Rows[itm.RowIndex]["TRAN_DRAWEE_BANK"].ToString();
            }
            if (GridMode.Rows.Count > 0)
            {
                GridMode.FooterRow.Cells[2].Text = TotalMode.ToString("N2");
                ViewState["dtMode"] = ds.Tables[1];
                ObjBal.balRcvId = GridMode.DataKeys[0].Value.ToString();
                //FillFunction.Fill(ddlmo, ObjBll.getDemandHead(ObjBal), true, FillFunctions.FirstItem.Select);
                //HD1.Value = gvFees.DataKeys[0].Value.ToString();
            }

        }

    }

    protected void GridReceipt_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.balCommonID = GridReceipt.DataKeys[e.RowIndex].Value.ToString();
        ObjBal.balSession = Session["UserId"].ToString();
        string msg = ObjBll.StudentFeeReceiptTranDelete(ObjBal);
        if (msg.Contains("successfully"))
        {
            ViewState["Id"] = "";
            DivOther.Visible = cFooter.Visible = false;
            txtEnrollment.Text = "";

        }
    }

    protected void GridMode_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.balCommonID = GridMode.DataKeys[e.RowIndex].Value.ToString();
        ObjBal.balSession = Session["UserId"].ToString();
        string msg = ObjBll.StudentFeeReceiptModeDelete(ObjBal);
        if (msg.Contains("successfully"))
        {
            ViewState["Id"] = "";
            DivOther.Visible = cFooter.Visible = false;
            txtEnrollment.Text = "";

        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int C, M;
        C = M = 0;
        StringBuilder data = new StringBuilder();
        TextBox txtAmount;
        TextBox txtDate;
        TextBox txtNo;
        TextBox txtRemark;
        data.AppendFormat("<RECEIPT>");
        foreach (GridViewRow row in GridReceipt.Rows)
        {

            txtAmount = (TextBox)row.FindControl("txtTranAmount");
            txtDate = (TextBox)row.FindControl("txtDepositDate");
            txtRemark = (TextBox)row.FindControl("txtRemark");
            ddlHead = (DropDownList)row.FindControl("ddlHead");
            C = 1;
            data.AppendFormat("<TRAN FEE_RCV_TRAN_ID=\"" + GridReceipt.DataKeys[row.RowIndex].Value.ToString() + "\" FEE_MAIN_HEAD_ID=\"" + ddlHead.SelectedValue + "\" FEE_RCV_TRAN_AMT=\"" + Convert.ToDouble(txtAmount.Text).ToString() + "\" FEE_DEPOSIT_DT=\"" + txtDate.Text + "\" FEE_RCV_REMARK=\"" + txtRemark.Text + "\"/>");

        }
        data.AppendFormat("</RECEIPT>");
        ObjBal.XmlValue = data.ToString();
        data.Clear();
        data.AppendFormat("<MODE>");
        foreach (GridViewRow row in GridMode.Rows)
        {
            txtAmount = (TextBox)row.FindControl("txtAmount");
            txtDate = (TextBox)row.FindControl("txtModeDate");
            txtNo = (TextBox)row.FindControl("txtModeNo");
            ddlPaymode = (DropDownList)row.FindControl("ddlPayMode");
            ddlBank = (DropDownList)row.FindControl("ddlBank");
            txtRemark = (TextBox)row.FindControl("txtBranch");
            M = 1;
            data.AppendFormat("<TRAN RCV_TRAN_MODE_ID=\"" + GridMode.DataKeys[row.RowIndex].Value.ToString() + "\" PAY_MODE_ID=\"" + ddlPaymode.SelectedValue + "\" RCV_TRAN_MODE_NO=\"" + txtNo.Text + "\" RCV_TRAN_MODE_DT=\"" + txtDate.Text + "\" RCV_TRAN_MODE_AMT=\"" + Convert.ToDouble(txtAmount.Text).ToString() + "\" TRAN_DRAWEE_BANK=\"" + ((ddlBank.SelectedValue!=".")?ddlBank.SelectedValue:"") + "\" TRAN_DRAWEE_BRANCH=\"" + txtRemark.Text + "\" />");

        }
        data.AppendFormat("</MODE>");
        ObjBal.XmlValue2 = data.ToString();
        ObjBal.balCommonID = ViewState["Id"].ToString();
        ObjBal.balSession = Session["UserId"].ToString();
        string msg = ObjBll.StudentFeeReceiptUpdate(ObjBal);
        if (msg.Contains("successfully"))
        {
            ViewState["Id"] = "";
            DivOther.Visible = cFooter.Visible = false;
            txtEnrollment.Text = lblBatch.Text = lblName.Text = lblReceiptNo.Text = "";
            ddlSemester.SelectedIndex = 0;
            ddlBranch.Items.Clear();
            gvFees.DataSource = "";
            gvFees.DataBind();
            GridMode.DataSource = "";
            GridMode.DataBind();
            GridReceipt.DataSource = "";
            GridReceipt.DataBind();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);


    }
}
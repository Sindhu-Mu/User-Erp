using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Finance_StuFeeDemand : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    SFBLL ObjBll;
    SFBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    DataTable dt;
    double TotDemand, TotRcv, TotAdjust, TotBalance, TotWave;
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
            pushData();
        }
    }
    void pushData()
    {
        FillFunction.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlProcess, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FeeProcess), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlFine, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FeeFineRule), true, FillFunctions.FirstItem.Select);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnrollment.Text);
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

    private void ShowDetail()
    {
        TotDemand = TotRcv = TotAdjust = TotBalance =TotWave= 0;
        btnUpdate.Visible = false;
        ObjBal.balEnrollment = txtEnrollment.Text;
        ObjBal.balBranch = ddlBranch.SelectedValue;
        ObjBal.balSem = ddlSemester.SelectedValue;
        DataTable dt = ObjBll.StudentDemandFeeSelect(ObjBal).Tables[0];
        gvFees.DataSource = dt;
        gvFees.DataBind();
        if (dt.Rows.Count > 0)
        {
            btnUpdate.Visible = true;
            ddlFine.SelectedValue = dt.Rows[0]["FINE_RULE_ID"].ToString();
            ddlProcess.SelectedValue = dt.Rows[0]["FEE_PROS_ID"].ToString();
            foreach (GridViewRow itm in gvFees.Rows)
            {
                TotDemand += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_FEE_AMT"]);
                TotAdjust += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_ADJUST_AMT"]);
                TotWave += Convert.ToDouble(dt.Rows[itm.RowIndex]["FEE_WAVE_OFF"]);
                TotRcv += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_RCV_AMT"]);
                TotBalance += Convert.ToDouble(dt.Rows[itm.RowIndex]["FD_BALANCE_AMT"]);
            }
            if (gvFees.Rows.Count > 0)
            {
                gvFees.FooterRow.Cells[2].Text = TotDemand.ToString("N2");
                gvFees.FooterRow.Cells[3].Text = TotAdjust.ToString("N2");
                gvFees.FooterRow.Cells[4].Text = TotWave.ToString("N2");
                gvFees.FooterRow.Cells[5].Text = TotRcv.ToString("N2");
                gvFees.FooterRow.Cells[6].Text = TotBalance.ToString("N2");
                ViewState["dt"] = dt;
                ObjBal.balDemandId = gvFees.DataKeys[0].Value.ToString();
                FillFunction.Fill(ddlFeesHead, ObjBll.getDemandHead(ObjBal), true, FillFunctions.FirstItem.Select);
                HD1.Value = gvFees.DataKeys[0].Value.ToString();
            }
        }
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
    protected void gvFees_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        DataTable dt;
        dt = (DataTable)ViewState["dt"];
        double Amount = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtAmount")).Text);
        double AdjAmount = Convert.ToDouble(((TextBox)gvFees.Rows[e.RowIndex].FindControl("txtAdjust")).Text);
        if ((Convert.ToDouble(dt.Rows[e.RowIndex]["FD_FEE_AMT"].ToString()) != Amount) || (Convert.ToDouble(dt.Rows[e.RowIndex]["FD_ADJUST_AMT"].ToString()) != AdjAmount))
        {
            ObjBal.balDemandId = gvFees.DataKeys[0].Value.ToString();
            ObjBal.balMainHeadId = dt.Rows[e.RowIndex]["FEE_MAIN_HEAD_ID"].ToString();
            ObjBal.balAmount = Amount.ToString();
            ObjBal.balAdjAmount = AdjAmount.ToString();
            ObjBal.balSession = Session["UserId"].ToString();
            string msg = ObjBll.StudentFeeDemandInsert(ObjBal);
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        ObjBal.balProcId = ddlProcess.SelectedValue;
        ObjBal.balRuleId = ddlFine.SelectedValue;
        ObjBal.balDemandId = HD1.Value;
        string msg = ObjBll.StudentFeeDemandUpdate(ObjBal);
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
}
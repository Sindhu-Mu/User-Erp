using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.Text;

public partial class PayRoll_SalIncrement : System.Web.UI.Page
{
    
    PRBAL prbal;
    PRBLL prbll;
    StringBuilder strBldr;
    DataSet ds;
    CommonFunctions commonFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialisetion();
        if (!IsPostBack)
        {
            txtEmp.Focus();
            btnSubmit.Enabled = false;

        }
    }

    private void Initialisetion()
    {
        prbll = new PRBLL();

        commonFunction = new CommonFunctions();
        strBldr = new StringBuilder();
        prbal = new PRBAL();
    }
    
    protected void btnShow_Click(object sender, EventArgs e)
    {
        double Total = 0;
        prbal.balEmpCode = commonFunction.GetKeyID(txtEmp);
        EmpPayrollProfile.ShowEmployeeInfo(prbal.balEmpCode);
        ds=prbll.EmpSalaryActiveProfile(prbal);
        gvEarnings.DataSource = ds.Tables[0];
        gvEarnings.DataBind();
        foreach (GridViewRow itm in gvEarnings.Rows)
        {
            Total += Convert.ToDouble(((TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue")).Text);
        }
        if (gvEarnings.Rows.Count > 0)
            gvEarnings.FooterRow.Cells[4].Text = Total.ToString();
        gvDeductions.DataSource = ds.Tables[1];
        gvDeductions.DataBind();
        Total = 0;
        foreach (GridViewRow itm in gvEarnings.Rows)
        {
            Total += Convert.ToDouble(((TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue")).Text);
        }
        if (gvEarnings.Rows.Count > 0)
            gvEarnings.FooterRow.Cells[4].Text = Total.ToString();
        txtIncAmt.Text = "";
        lblIncrement.Text = "0";
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        double basic = 0; double DP = 0; double GP = 0; double totalEr = 0; double pfSalary = 0; double amt = 0; double value = 0; double TotInc = 0;
        prbal.balEmpCode = commonFunction.GetKeyID(txtEmp);
        int CountPf = Convert.ToInt16(prbll.GetEmpEpf(prbal));
        int GradeAmt = 0;
        TextBox txtValue = (TextBox)gvEarnings.Rows[0].FindControl("txtValue");
        basic = Convert.ToDouble(txtValue.Text);
        if ((Rlist1.SelectedIndex == 0) && (((Label)EmpPayrollProfile.FindControl("lblScale")).Text != ""))
        {
            GradeAmt = Convert.ToInt32(((Label)EmpPayrollProfile.FindControl("lblScale")).Text.Split('-').GetValue(1));
            basic = basic + (GradeAmt * Convert.ToInt32(txtIncAmt.Text));
        }
        else if (Rlist1.SelectedIndex == 1)
            basic = Convert.ToDouble(txtValue.Text) + Convert.ToDouble(txtIncAmt.Text);
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Some conditional error, Re-Enter increment value.!!')", true);
        foreach (GridViewRow itm in gvEarnings.Rows)
        {
            value = Convert.ToDouble(itm.Cells[3].Text);
            if (value > 0)
            {
                if (itm.Cells[1].Text == "GRADE PAY")
                    GP = value;
                if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "1")
                    amt = DP = (basic * value / 100);
                else if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "4")
                    amt = ((basic + System.Math.Round(DP, 0, MidpointRounding.AwayFromZero)) * value / 100);
                else if (gvEarnings.DataKeys[itm.RowIndex].Values[1].ToString() == "5")
                    amt = ((basic + System.Math.Round(GP, 0, MidpointRounding.AwayFromZero)) * value / 100);
                else
                    amt = value;
                amt = System.Math.Round(amt, 0, MidpointRounding.AwayFromZero);
                ((TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue")).Text = amt.ToString();
            }
            else if (itm.RowIndex == 0)
                ((TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue")).Text = basic.ToString();

            totalEr += Convert.ToDouble(((TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue")).Text);
            if (gvEarnings.DataKeys[itm.RowIndex].Values[2].ToString() == "True")
                TotInc += totalEr;
            value = 0;
        }
        if (gvEarnings.Rows.Count > 0)
        {
            gvEarnings.FooterRow.Cells[4].Text = totalEr.ToString();
            lblIncrement.Text = (TotInc - Convert.ToDouble(((Label)EmpPayrollProfile.FindControl("lblGross")).Text)).ToString();
        }
        //DEDUCTIONS
        double totalEDc = 0; amt = 0;
        foreach (GridViewRow itm in gvDeductions.Rows)
        {
            value = Convert.ToDouble(itm.Cells[3].Text);
            if (value > 0)
            {
                if (itm.Cells[1].Text == "PROVIDENT FUND")
                {
                    pfSalary = ((basic > 6500) && (CountPf > 0)) ? 6500 : basic;
                    if (pfSalary > 6500)
                        continue;
                    else
                        amt = ((pfSalary + System.Math.Round(DP, 0, MidpointRounding.AwayFromZero)) * value / 100);
                }
                else if (gvDeductions.DataKeys[itm.RowIndex].Values[1].ToString() == "1")
                    amt = (basic * value / 100);
                else
                    amt = value;
                amt = System.Math.Round(amt, 0, MidpointRounding.AwayFromZero);
                ((TextBox)gvDeductions.Rows[itm.RowIndex].FindControl("txtValue")).Text = amt.ToString();
                totalEDc += amt;
            }
        }
        btnSubmit.Enabled = true;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
       
        TextBox txtValue;
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        int TotalDay = DateTime.DaysInMonth(Convert.ToInt32(ddlYY.SelectedValue), Convert.ToInt32(ddlMM.SelectedValue));
        if (lblIncrement.Text != "")
        {
            foreach (GridViewRow itm in gvEarnings.Rows)
            {
                txtValue = (TextBox)gvEarnings.Rows[itm.RowIndex].FindControl("txtValue");
                txtValue.Text = (txtValue.Text == "") ? "0" : txtValue.Text;
                prbal.balEsId = gvEarnings.DataKeys[itm.RowIndex].Values[3].ToString();
                prbal.balHeadId = gvEarnings.DataKeys[itm.RowIndex].Values[0].ToString();
                prbal.balheadValue =txtValue.Text;
                prbal.balInCal = gvEarnings.DataKeys[itm.RowIndex].Values[2].ToString();
                prbal.balOrderNo = txtOrderNo.Text;
                prbal.balOrderDt=Convert.ToDateTime(txtOrderDate.Text);
                prbal.balCurEmpCode = Session["LoginId"].ToString();
                prbll.SalaryStrucDetailInsert(prbal);
                
            }
            foreach (GridViewRow itm in gvDeductions.Rows)
            {
                txtValue = (TextBox)gvDeductions.Rows[itm.RowIndex].FindControl("txtValue");
                txtValue.Text = (txtValue.Text == "") ? "0" : txtValue.Text;
                prbal.balEsId = gvEarnings.DataKeys[itm.RowIndex].Values[3].ToString();
                prbal.balHeadId = gvDeductions.DataKeys[itm.RowIndex].Values[0].ToString();
                prbal.balheadValue = txtValue.Text;
                prbal.balInCal = gvDeductions.DataKeys[itm.RowIndex].Values[2].ToString();
                prbal.balOrderNo = txtOrderNo.Text;
                prbal.balOrderDt = Convert.ToDateTime(txtOrderDate.Text);
                prbal.balCurEmpCode = Session["LoginId"].ToString();
                prbll.SalaryStrucDetailInsert(prbal);
            }
            prbal.balEsId = gvEarnings.DataKeys[0].Values[3].ToString();
            prbal.balIncType = Rlist1.SelectedValue;
            prbal.balIncValue = lblIncrement.Text;
            prbal.balMonth = ddlMM.SelectedValue;
            prbal.balYear = ddlYY.SelectedValue;
            prbal.balOrderDt = Convert.ToDateTime(txtOrderDate.Text);
            prbal.balRemark = txtRemark.Text;
            prbal.balNod = TotalDay.ToString();
            prbal.balCurEmpCode = Session["LoginId"].ToString();
            prbll.SalaryIncrementInsert(prbal);
            
        }
       
        gvEarnings.DataSource = "";
        gvEarnings.DataBind();
        gvDeductions.DataSource = "";
        gvDeductions.DataBind();
        EmpPayrollProfile.ShowEmployeeInfo("-200");
        txtEmp.Focus();
        btnSubmit.Enabled = false;
        Rlist1.SelectedIndex = 0;
        lblIncrement.Text = "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Employee increment submitted successfully.!!')", true);

    }
   
}
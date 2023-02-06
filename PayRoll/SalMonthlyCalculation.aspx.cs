using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class PayRoll_SalMonthlyCalculation : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryfunctions;
    CommonFunctions commonFunctions;
    PRBLL ObjBll;
    PRBAL ObjBAL;
    private void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new PRBLL();
        ObjBAL = new PRBAL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlTemplate, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.TempType), true, FillFunctions.FirstItem.All);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        int TotalDay = DateTime.DaysInMonth(Convert.ToInt32(ddlYY.SelectedValue), Convert.ToInt32(ddlMM.SelectedValue));
        ObjBAL.balMonth = ddlMM.SelectedValue;
        ObjBAL.balYear = ddlYY.SelectedValue;
        ObjBAL.balDays = TotalDay.ToString();
        ObjBAL.balTempId = ddlTemplate.SelectedValue;
        ObjBAL.balkeyId = ddlType.SelectedValue;
        ObjBAL.balMin = txtMin.Text;
        ObjBAL.balMax = txtMax.Text;
        ObjBAL.balInCal = ddlCalType.Text;
        if (txtEmp.Text != "")
        {
            ObjBAL.balEmpCode = commonFunctions.GetKeyID(txtEmp);
        }
        ObjBAL.balArngBy = ddlSort.SelectedValue;
        gridSAL.DataSource = ObjBll.GetSalMonthlyCalculation(ObjBAL);
        gridSAL.DataBind();
        calculate_NetPay();
        btnSave.Enabled = true;
    }

    public void calculate_NetPay()
    {
        for (int i = 1; i < gridSAL.Rows[0].Cells.Count; i++)
        {
            double net_pay = 0;
            String col_name = gridSAL.HeaderRow.Cells[i].Text;
            if (col_name == "EMPCODE" || col_name == "BANK A/C" || col_name == "EMP NAME" || col_name == "DESIGNATION" || col_name == "INSTITUTE" || col_name == "DEPARTMENT" || col_name == "DAYS" || col_name == "NOD" || col_name == "BANK NAME")
            {
                continue;
            }
            for (int x = 0; x < gridSAL.Rows.Count; ++x)
            {
                try
                {
                    String value = gridSAL.Rows[x].Cells[i].Text.ToString();
                    if (value == "" || value == "&nbsp;")
                    {
                        value = "0";
                    }
                    double amount = Convert.ToDouble(value);
                    net_pay = net_pay + amount;
                }
                catch (Exception e)
                {
                    String excep = "Exception " + e;
                    continue;
                }
            }
            gridSAL.FooterRow.Cells[i].Text = Convert.ToString(net_pay);
        }
    }

    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMin.Text = txtMax.Text = "0";
        if (ddlType.SelectedValue == "0")
        {
            txtMin.Enabled = txtMax.Enabled = false;
        }
        else if (ddlType.SelectedValue == "4")
        {
            txtMin.Enabled = txtMax.Enabled = true;
        }
        else
        {
            txtMin.Enabled = true;
            txtMax.Enabled = false;
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        GridViewExportUtil.Export(ddlMM.SelectedValue + "-" + ddlYY.SelectedValue + "SalaryDetail.xls", gridSAL);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        SqlDataReader dr;
        if (gridSAL.Rows.Count > 0)
        {
            DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
            DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
            int TotalDay = DateTime.DaysInMonth(Convert.ToInt32(ddlYY.SelectedValue), Convert.ToInt32(ddlMM.SelectedValue));
            ObjBAL.balMonth = ddlMM.SelectedValue;
            ObjBAL.balYear = ddlYY.SelectedValue;
            ObjBAL.balDays = TotalDay.ToString();
            ObjBAL.balTempId = ddlTemplate.SelectedValue;
            ObjBAL.balkeyId = ddlType.SelectedValue;
            ObjBAL.balMin = txtMin.Text;
            ObjBAL.balMax = txtMax.Text;
            ObjBAL.balInCal = ddlCalType.Text;
            if (txtEmp.Text != "")
            {
                ObjBAL.balEmpCode = commonFunctions.GetKeyID(txtEmp);
            }
            ObjBAL.balCurEmpCode = Session["LoginId"].ToString();
            dr = ObjBll.SalMonthlyCalculationInsert(ObjBAL);
            if (dr.Read())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Salary of " + dr[0].ToString() + " Employee for selected month submitted successfully.')", true);
                ddlMM.SelectedIndex = ddlYY.SelectedIndex = ddlTemplate.SelectedIndex = 0;
                gridSAL.DataSource = "";
                gridSAL.DataBind();
            }
        }
    }

    protected void ChSalary_CheckedChanged(object sender, EventArgs e)
    {
        DivSalary.Visible = (ChSalary.Checked);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class PayRoll_rprtSalPayble : System.Web.UI.Page
{
   
    private PRBAL prbal;
    private PRBLL prbll;
    private DataTable dt;
    private QueryFunctions qf;
    private CommonFunctions cf;
    private FillFunctions fillFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialisation();
        if (!IsPostBack)
        {
           
            fillFunctions.Fill(ddlInsName, qf.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlDesig, qf.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlDept, qf.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        }

    }
    public void Initialisation()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        fillFunctions = new FillFunctions();
        qf = new QueryFunctions();
        cf = new CommonFunctions();
        
    }
    public void calculate_NetPay()
    {
        for (int i = 1; i < gvPayable.Rows[0].Cells.Count; i++)
        {
            double net_pay = 0;
            String col_name = gvPayable.HeaderRow.Cells[i].Text;
            if (col_name == "EMP CODE" || col_name == "BANK A/C" || col_name == "EMP NAME" || col_name == "DESIGNATION" || col_name == "INSTITUTE" || col_name == "DEPARTMENT" || col_name == "DAYS" || col_name == "NOD" || col_name == "BANK NAME" || col_name == "Job Type" || col_name == "STATUS")
            {
                continue;
            }
            for (int x = 0; x < gvPayable.Rows.Count; ++x)
            {
                try
                {
                    String value = gvPayable.Rows[x].Cells[i].Text.ToString();
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
            gvPayable.FooterRow.Cells[i].Text = Convert.ToString(net_pay);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        prbal.balMonth=ddlMM.SelectedValue;
        prbal.balYear=ddlYY.SelectedValue;
        prbal.balTempId=ddlTemplate.SelectedValue;
        prbal.balIncType=ddlInsName.SelectedValue;
        prbal.balDeptValue=ddlDept.SelectedValue;
        prbal.balDesigValue=ddlDesig.SelectedValue;
        prbal.balHeadType=ddlType.SelectedValue;
        if (txtEmp.Text != "")
        {
            prbal.balEmpCode = cf.GetKeyID(txtEmp);
        }
        else
        {
            prbal.balEmpCode = "0";
        }
        dt = prbll.PayableSalarySelect(prbal);
        if (dt.Rows.Count > 0)
        {
            gvPayable.DataSource = dt;
            gvPayable.DataBind();
            calculate_NetPay();
            btnExport.Visible = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No Records Found..! Try Different Combination.')", true);
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("SalaryPayable.xls", gvPayable);
    }
    protected void ddlInsName_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        fillFunctions.Fill(ddlDept, qf.GetCommand(QueryFunctions.QueryBaseType.Department,
            prbll.checkIndex(ddlInsName.SelectedValue)), true, FillFunctions.FirstItem.Select);
    }
}
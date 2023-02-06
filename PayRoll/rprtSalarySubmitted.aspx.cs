using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PayRoll_rprtSalarySubmitted : System.Web.UI.Page
{
    PRBAL prbal;
    PRBLL prbll;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialization();

        if (!IsPostBack)
        {
             fillFunctions.Fill(ddlInsName, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlTemplate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TempType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDesig, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Designation), true, FillFunctions.FirstItem.All);
        }
    }
   public void Initialization()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        dt = new DataTable();
    }
   protected void btnView_Click(object sender, EventArgs e)
   {
       DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
       DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
       int TotalDay = DateTime.DaysInMonth(Convert.ToInt32(ddlYY.SelectedValue), Convert.ToInt32(ddlMM.SelectedValue));
       
       prbal.balMonth = ddlMM.SelectedValue;
       prbal.balYear = ddlYY.SelectedValue;
       prbal.balNod = TotalDay.ToString();
       prbal.balTempId =prbll.checkIndex(ddlTemplate.SelectedValue,"");
       prbal.balInstituteValue =prbll.checkIndex(ddlInsName.SelectedValue,"");
       prbal.balDeptValue = prbll.checkIndex(ddlDept.SelectedValue,"");
       prbal.balDesigValue = prbll.checkIndex(ddlDesig.SelectedValue,"");
       prbal.balEmpCode = "";
       if (txtEmp.Text != "")
       {
           prbal.balEmpCode = commonFunctions.GetKeyID(txtEmp);
       }
       
       prbal.balData = ddlSaleryBy.SelectedValue;
       dt = prbll.GetSubmittedSalary(prbal);
       if (dt.Rows.Count > 0)
       {
           gvPayable.DataSource = dt;
           gvPayable.DataBind();
           calculate_NetPay();
           btnExport.Visible = true;
       
       }
       else
       {
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(No Record Found..! Try Different Combination.)", true);
       }
   }
   protected void btnExport_Click(object sender, EventArgs e)
   {
       GridViewExportUtil.Export("SalaryPayable.xls", gvPayable);
   }
   protected void ddlInsName_SelectedIndexChanged(object sender, EventArgs e)
   {
       fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department,ddlInsName.SelectedValue), true, FillFunctions.FirstItem.All);
   }
   public void calculate_NetPay()
   {
       for (int i = 1; i < gvPayable.Rows[0].Cells.Count; i++)
       {
           double net_pay = 0;
           String col_name = gvPayable.HeaderRow.Cells[i].Text;
           if (col_name == "EMP.CODE" || col_name == "BANK A/C" || col_name == "EMP NAME" || col_name == "DESIGNATION" || col_name == "INSTITUTE" || col_name == "DEPARTMENT" || col_name == "DAYS" || col_name == "NOD" || col_name == "BANK NAME" || col_name == "Sal Month" || col_name == "Sal Year")
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

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PayRoll_SalHoldReport : System.Web.UI.Page
{
    PRBAL prbal;
    PRBLL prbll;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialization();
        if (!IsPostBack)
        {
        fillFunctions.Fill(ddlInsitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.All);
        }
    }
    public void Initialization()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
    }
    private void BindDetail()
    {
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        DataTable dt = new DataTable();
        string yy = "";
        if (ddlYY.SelectedValue == "")
        {
            ddlMM.SelectedValue = DateTime.Now.Month.ToString();
            yy = DateTime.Now.Year.ToString();
        }
        else
        {
            yy = ddlYY.SelectedValue;
        }
        prbal.balMonth = ddlMM.SelectedValue;
        prbal.balYear = ddlYY.SelectedValue;
        prbal.balInstituteValue = prbll.checkIndex(ddlInsitution.SelectedValue,"");
        prbal.balDeptValue = prbll.checkIndex(ddlDepartment.SelectedValue,"");
        prbal.balJobType = prbll.checkIndex(ddlCategory.SelectedValue,"");
        dt=prbll.GET_SAL_HOLD(prbal);
        if (dt.Rows.Count > 0)
        {
            GridShow.DataSource = prbll.GET_SAL_HOLD(prbal);
            GridShow.DataBind();
            foreach (GridViewRow itm in GridShow.Rows)
            {
                itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
                if (GridShow.DataKeys[itm.RowIndex].Value.ToString() == "2")
                {
                    itm.BackColor = System.Drawing.Color.Red;
                    itm.ForeColor = System.Drawing.Color.White;
                }
            }
            btnExport.Visible = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No one on hold..!')", true);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        BindDetail();
    }
    protected void ddlInsitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department,ddlInsitution.SelectedValue), true, FillFunctions.FirstItem.All);
       
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        GridViewExportUtil.Export("SalaryHold.xls", GridShow);
    }
}
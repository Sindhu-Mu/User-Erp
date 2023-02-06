using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_rptBirthday : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataSet ds;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.All);
            if (System.DateTime.Now.Month < 10)
                ddlMonth.SelectedValue = '0' + System.DateTime.Now.Month.ToString();
            else
                ddlMonth.SelectedValue = System.DateTime.Now.Month.ToString();
            bindGrid();
        }
    }

    void bindGrid()
    {
        int d, a = 0;
        ObjHrBal.InsId = ddlIns.SelectedValue;
        ObjHrBal.DeptId = ddlDept.SelectedValue;
        ObjHrBal.KeyID = ddlMonth.SelectedValue;
        ds = ObjHrBll.getEmpBirthday(ObjHrBal);
        gvBirthDetail.DataSource = ds;
        gvBirthDetail.DataBind();
        foreach (GridViewRow itm in gvBirthDetail.Rows)
        {
            d = itm.RowIndex;
            a++;
            itm.Cells[0].Text = a.ToString()+".";
            if (ds.Tables[0].Rows[d]["DOB"].ToString() != "")
            {
                DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[d]["DOB"].ToString());
                DateTime dtCurrent;
                dtCurrent = commonFunctions.GetDateTime(dt.Day.ToString() + "/" + ddlMonth.SelectedValue + "/" + DateTime.Now.Year);
                itm.Cells[3].Text = dt.Day.ToString() + "-" + dtCurrent.DayOfWeek.ToString();
                if ((dt.Month.ToString() == System.DateTime.Now.Month.ToString()) && (dt.Day.ToString() == System.DateTime.Now.Day.ToString()))
                {
                    itm.BackColor = System.Drawing.Color.YellowGreen;
                    itm.ForeColor = System.Drawing.Color.Maroon;
                }
            }
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        bindGrid();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("BirthdayReport.xls", gvBirthDetail);
    }
}
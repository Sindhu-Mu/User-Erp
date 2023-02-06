using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_rptMonthlyLvBalance : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjAcaBAL;
    HRBLL ObjHrBll;
    DataSet ds;
    DataTable dt;
    DatabaseFunctions databaseFunctions;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjAcaBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
        databaseFunctions = new DatabaseFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
           
            fillFunctions.Fill(ddlJobType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobTypeWithoutAll), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear2.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear2.FindControl("ddlYear");
        ObjAcaBAL.DeptId = ddlDept.SelectedValue;
        ObjAcaBAL.InsId = ddlIns.SelectedValue;
        if (txtEmployee.Text != "")
        {
            ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        }
        ObjAcaBAL.TypeId = ddlJobType.SelectedValue;
        ObjAcaBAL.KeyID = ddlMonth.SelectedValue;
        ObjAcaBAL.KeyValue = ddlYear.SelectedValue;
        gvDetail.DataSource = ObjHrBll.getMonthlyLv(ObjAcaBAL).Tables[0];
        gvDetail.DataBind();
        string leaveCode="";
        int f = 0;
        for (int i = 0; i < chLeaveType.Items.Count; i++)
        {
            if (chLeaveType.Items[i].Selected)
            {
                if (f == 0)
                {
                    leaveCode += " AND( (LV_ID=" + chLeaveType.Items[i].Value + ")";
                    f = 1;
                }
                else
                {
                    leaveCode += " OR (LV_ID=" + chLeaveType.Items[i].Value + ")";
                }
            }
        }
        if (f == 1)
        {
            leaveCode += " )";
        }
        ObjAcaBAL.ValueType = leaveCode;
        foreach (GridViewRow itm in gvDetail.Rows)
        {
            ObjAcaBAL.EmpId = gvDetail.DataKeys[Convert.ToInt32(itm.RowIndex)].Value.ToString();
            ((Repeater)gvDetail.Rows[itm.RowIndex].FindControl("Repeater1")).DataSource = ObjHrBll.getMonthlyLvBalance(ObjAcaBAL);
            ((Repeater)gvDetail.Rows[itm.RowIndex].FindControl("Repeater1")).DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_rptComCredit : System.Web.UI.Page
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

        }
    }
    protected void ddlDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {

            case "ddlDate":
                if (ddlDate.SelectedValue == "3")
                {

                    txtFromDate.Enabled = true;
                    txtToDate.Enabled = true;
                }
                else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
                {
                    txtFromDate.Enabled = true;
                    txtToDate.Enabled = false;
                }
                else
                {
                    txtFromDate.Enabled = false;
                    txtToDate.Enabled = false;
                }
                txtToDate.Text = txtFromDate.Text = "";
                break;
            default:
                break;
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEmployee.Text == "")
        {
            ObjAcaBAL.EmpId= " ";
        }
        else
        {
            ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        }
        ObjAcaBAL.InsId = ddlIns.SelectedValue;
        ObjAcaBAL.DeptId = ddlDept.SelectedValue;
        ObjAcaBAL.KeyID = ddlStatus.SelectedValue;
        ObjAcaBAL.KeyValue = ddlDate.SelectedValue;
        ObjAcaBAL.Min = txtFromDate.Text;
        ObjAcaBAL.Max = txtToDate.Text;
        gvComDetail.DataSource = ObjHrBll.getComReport(ObjAcaBAL).Tables[0];
        gvComDetail.DataBind();
    }
}
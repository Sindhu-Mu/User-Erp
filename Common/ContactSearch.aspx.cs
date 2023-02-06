using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Common_ContactSearch : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBAL;
    HRBLL ObjHrBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();        
        if (!IsPostBack)
        {
            PushData();
            FillGrid();
        }

    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjHrBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }
    private void PushData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);

    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    void FillGrid()
    {
       
        ObjHrBAL.InsId = ddlInstitution.SelectedValue;     
        ObjHrBAL.DeptId = ddlDept.SelectedValue;
        ObjHrBAL.Value1 = txtEmployee.Text;
        dt = ObjHrBll.GetContactSearch(ObjHrBAL).Tables[0];       
        Repeater1.DataSource = dt;
        Repeater1.DataBind();
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        FillGrid();
    }
}
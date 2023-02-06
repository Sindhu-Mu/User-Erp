using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_rptLvCredit : System.Web.UI.Page
{
    FillFunctions FillFunction ;
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;
    DropDownList ddlMonth, ddlYear;

    public void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
        ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlLvType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjHrBAL.KeyID = ddlLvType.SelectedValue;
        ObjHrBAL.TypeId = ddlCreditType.SelectedValue;
        ObjHrBAL.Year = ddlYear.SelectedValue;
        ObjHrBAL.KeyValue = ddlMonth.SelectedValue;
        gvDetail.DataSource = ObjHrBll.GetLvCreditReport(ObjHrBAL);
        gvDetail.DataBind();
        trGrid.Visible = true;
    }
}
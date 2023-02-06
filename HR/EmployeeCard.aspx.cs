using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_EmployeeCard : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryfunction;
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;

    protected void Page_Load(object sender, EventArgs e)
    {
            Initialize();
            printCard();       
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void printCard()
    {

        dt = ObjHrBll.EmpCardPrint(Request.QueryString["user_id"]).Tables[0];
        ViewState["dt"] = dt;
        repICard.DataSource = dt;
        repICard.DataBind();

    }
    
}
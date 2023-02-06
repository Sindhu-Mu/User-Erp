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
    DataSet ds;

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
        ds = new DataSet();
    }
    protected void printCard()
    {

        ds = (DataSet)Session["DataSet"];
        repICard.DataSource = ds;
        repICard.DataBind();

        ds = (DataSet)Session["DataSet"];
        repICard.DataSource = ds;
        repICard.DataBind();
        ObjAcaBAL.EmpId = ds.Tables[0].Rows[0]["EMP_CODE"].ToString();
        //dt =
        //ViewState["dt"] = dt;
        repICard.DataSource = ObjHrBll.SecCardPrint(ObjAcaBAL);
        repICard.DataBind();


    }
    
}
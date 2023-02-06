using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Facility_rptTptCountaspx : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    DatabaseFunctions DatabaseFunction;
    CommonFunctions CommonFunction;
    FacBAL ObjBal;
    FacBLL ObjBll;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(gridRegCity, ObjBll.TptRegCityCounter().Tables[0]);
                RegData();
                AppRteData();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        DatabaseFunction = new DatabaseFunctions();
        CommonFunction = new CommonFunctions();
        ObjBal = new FacBAL();
        ObjBll = new FacBLL();
    }
    void RegData()
    {
        DataSet ds_reg = new DataSet();
        ds_reg = ObjBll.TptRegCounter(ObjBal);
        FillFunction.Fill(gridRegIns, ds_reg.Tables[0]);
        FillFunction.Fill(gridRegInsCourse, ds_reg.Tables[1]);
        FillFunction.Fill(gridRegInsCourseBranch, ds_reg.Tables[2]);
    }
    protected void gridRegIns_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.InsId = e.CommandArgument.ToString();
            RegData();
        }
        else if (e.CommandName == "RESET")
        {
            RegData();
        }
    }
    protected void gridRegInsCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.Id = e.CommandArgument.ToString();
            RegData();
        }
        else if (e.CommandName == "RESET")
        {
            RegData();
        }
    }
    void AppRteData()
    {
        DataSet ds = new DataSet();
        ds = ObjBll.TptAppRteCounter(ObjBal);
        FillFunction.Fill(gridAprCity, ds.Tables[0]);
        FillFunction.Fill(gridAprRoute, ds.Tables[1]);
        FillFunction.Fill(gridAprIns, ds.Tables[2]);
        FillFunction.Fill(gridAprCourse, ds.Tables[3]);
        FillFunction.Fill(gridAprBranch, ds.Tables[4]);
    }
    protected void gridAprCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.CityId = e.CommandArgument.ToString();
            AppRteData();
        }
        else if (e.CommandName == "RESET")
        {
            AppRteData();
        }
    }
    protected void gridAprIns_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.InsId = e.CommandArgument.ToString();
            AppRteData();
        }
        else if (e.CommandName == "RESET")
        {
            AppRteData();
        }
    }
    protected void gridAprCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.Id = e.CommandArgument.ToString();
            AppRteData();
        }
        else if (e.CommandName == "RESET")
        {
            AppRteData();
        }
    }
    void PayDoneData()
    {
        DataSet DsPay = new DataSet();
        DsPay = ObjBll.TptPayCounter(ObjBal);
        FillFunction.Fill(gridBusCity, DsPay.Tables[0]);
        FillFunction.Fill(gridBusRoute, DsPay.Tables[1]);
        FillFunction.Fill(GridView1, DsPay.Tables[2]);
        FillFunction.Fill(gridBusIns, DsPay.Tables[3]);
        FillFunction.Fill(gridBusCourse, DsPay.Tables[4]);
        FillFunction.Fill(gridBusBranch, DsPay.Tables[5]);
    }
    protected void gridBusCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.CityId = e.CommandArgument.ToString();
            PayDoneData();
        }
        else if (e.CommandName == "RESET")
        {
            PayDoneData();
        }
    }
    protected void gridBusRoute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.RteId = e.CommandArgument.ToString();
            PayDoneData();
        }
        else if (e.CommandName == "RESET")
        {
            PayDoneData();
        }
    }
    protected void gridBusIns_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.InsId = e.CommandArgument.ToString();
            PayDoneData();
        }
        else if (e.CommandName == "RESET")
        {
            PayDoneData();
        }
    }
    protected void gridBusCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GET")
        {
            ObjBal.Id = e.CommandArgument.ToString();
            PayDoneData();
        }
        else if (e.CommandName == "RESET")
        {
            PayDoneData();
        }
    }
}
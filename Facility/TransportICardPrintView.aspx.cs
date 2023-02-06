using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Facility_TransportICardPrintView : System.Web.UI.Page
{

    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    FacBAL objFacbal;
    FacBLL objFacbll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
            if(!IsPostBack)
            {
                FillFunction.Fill(ddlCity, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);
                FillFunction.FillInteger(10, 50, 10, FillFunctions.FirstItem.Select, ddlCount);
                ddlCount.SelectedIndex = 1;
            }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        objFacbal = new FacBAL();
        objFacbll = new FacBLL();
        ds = new DataSet();
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
            FillFunction.Fill(ddlRte, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Route_Name, ddlCity.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(ddlRte);
    }

    protected void ddlRte_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRte.SelectedIndex > 0)
            FillFunction.Fill(ddlBusNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Bus_Id, ddlRte.SelectedValue), false, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(ddlBusNo);
    }


    protected void btnView_Click1(object sender, EventArgs e)
    {
        if (txtEnroll.Text.Contains(":"))
        {
            objFacbal.AuthFor = CommonFunction.GetKeyID(txtEnroll);
            objFacbal.StuAdmNo = objFacbll.GetStudentMainId(objFacbal);
        }
        else
        {
            objFacbal.StuAdmNo = null;
        }
        objFacbal.CityId = ddlCity.SelectedValue;
        objFacbal.RteId = ddlRte.SelectedValue;
        objFacbal.BusId = ddlBusNo.SelectedValue;
        objFacbal.PerType = rdlPrintType.SelectedValue;
        objFacbal.Count = ddlCount.SelectedValue;
        ds= objFacbll.GetTptPrintDetail(objFacbal);
        txtData.Text=ds.GetXml();
        gvPrint.DataSource = ds;
        gvPrint.DataBind();
    }
    public string GetXMLInsert
    {
        get
        {
            return txtData.Text;
        }
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        
    }
}

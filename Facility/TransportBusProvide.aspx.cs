using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_TransportBusProvide : System.Web.UI.Page
{
    FillFunctions FillFunctions;
    QueryFunctions QueryFunctions;
    CommonFunctions CommonFunctions;
    DataTable dt;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillGvPending();
            FillFunctions.Fill(ddlCity, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);
            FillFunctions.FillInteger(10, 50, 10, FillFunctions.FirstItem.Select, ddlCount);
        }
    }
    void Initialize()
    {
        FillFunctions = new FillFunctions();
        QueryFunctions = new QueryFunctions();
        CommonFunctions = new CommonFunctions();
        dt = new DataTable();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
    }
    void FillGvPending()
    {
        dt = ObjFacBll.PendingBusSelect().Tables[0];
        ViewState["dt"] = dt;
        gvPendingBusList.DataSource = dt;
        gvPendingBusList.DataBind();
    }
    void FillGvProvideBus()
    {
        if (ddlCity.SelectedIndex > 0)
            ObjFacBal.CityId = ddlCity.SelectedValue;

        if (ddlRte.SelectedIndex > 0)
            ObjFacBal.RteId = ddlRte.SelectedValue;

        if (ddlCount.SelectedIndex > 0)
            ObjFacBal.Count = ddlCount.SelectedValue;

        gvBusProviderList.DataSource = ObjFacBll.ProvideBusSelect(ObjFacBal).Tables[0];
        gvBusProviderList.DataBind();
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
        {
            FillFunctions.Fill(ddlRte, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.Route_Name, ddlCity.SelectedValue), true, FillFunctions.FirstItem.Select);
            FillFunctions.Fill(ddlBusNo, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.BusNO, ddlCity.SelectedValue), false, FillFunctions.FirstItem.Select);
        }
        else
        {
            CommonFunctions.Clear(ddlRte);
            CommonFunctions.Clear(ddlBusNo);
        }

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        FillGvProvideBus();
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        ObjFacBal.RteId = ddlRte.SelectedValue;
        ObjFacBal.Count = ddlCount.SelectedValue;
        ObjFacBal.SessionUserID = Session["UserID"].ToString();
        ObjFacBal.BusId = ddlBusNo.SelectedValue;
        Msg = ObjFacBll.ProvideBusInsert(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_TransportBusInTime : System.Web.UI.Page
{
    FillFunctions FillFunctions;
    QueryFunctions QueryFunctions;
    CommonFunctions CommonFunctions;
    FacBAL objFacbal;
    FacBLL objFacbll;
    DataTable dt;
    String Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        Save.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillFunctions.Fill(ddlCity, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);
            FillGrid();
        }
    }
    void Initialize()
    {
        FillFunctions = new FillFunctions();
        QueryFunctions = new QueryFunctions();
        CommonFunctions = new CommonFunctions();
        objFacbal = new FacBAL();
        objFacbll = new FacBLL();
        dt = new DataTable();
    }
    void FillGrid()
    {
        dt = objFacbll.DailyBusInTimeSelect().Tables[0];
        ViewState["dt"] = dt;
        gvBusIn.DataSource = dt;
        gvBusIn.DataBind();
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
            FillFunctions.Fill(ddlRoute, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.Route_Name, ddlCity.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunctions.Clear(ddlRoute);
    }
    protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoute.SelectedIndex > 0)
            FillFunctions.Fill(ddlBusType, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.Bus_Type, ddlRoute.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunctions.Clear(ddlBusType);
    }
    protected void ddlBusType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlBusType.SelectedIndex > 0)
            FillFunctions.Fill(ddlBusNo, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.Bus_No, ddlBusType.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunctions.Clear(ddlBusNo);
    }
    protected void Save_Click(object sender, EventArgs e)
    {
      
        objFacbal.CityId = ddlCity.SelectedValue;
        objFacbal.RteId = ddlRoute.SelectedValue;
        objFacbal.SessionUserID = Session["UserID"].ToString();
        objFacbal.BusId = ddlBusNo.SelectedValue;
        objFacbal.BusType = ddlBusType.SelectedValue;
        objFacbal.Time = txtInTime.Text;
        objFacbal.InDate = CommonFunctions.GetDateTime( txtDate.Text );
        objFacbal.Remark = txtRemark.Text;
        Msg = objFacbll.DailyBusInTimeInsert(objFacbal);
        FillGrid();
        CommonFunctions.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
}
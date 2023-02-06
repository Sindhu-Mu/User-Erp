using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Facility_TransportBusRteMapp : System.Web.UI.Page
{
    FillFunctions FillFunctions;
    QueryFunctions QueryFunctions;
    CommonFunctions CommonFunctions;
    FacBAL objFacBal;
    FacBLL objFacBll;
    DataTable dt;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillGrid();
            FillFunctions.Fill(ddlCity, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);
            ViewState["ID"] = "";
            //ViewState["dt"] = "";
        }
    }
    void Initialize()
    {
        FillFunctions = new FillFunctions();
        QueryFunctions = new QueryFunctions();
        CommonFunctions = new CommonFunctions();
        dt = new DataTable();
        objFacBal = new FacBAL();
        objFacBll = new FacBLL();
    }

    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCity.SelectedIndex > 0)
        {
            FillFunctions.Fill(ddlRte, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.Route_Name, ddlCity.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlRte.Items.Clear();
    }
    void FillGrid()
    {
        dt = objFacBll.BusRteMapSelect().Tables[0];
        ViewState["dt"] = dt;
        gvSave.DataSource = dt;
        gvSave.DataBind();
    }
    void clear()
    {
        CommonFunctions.Clear(CommonFunctions.ClearType.Index, ddlCity);
        CommonFunctions.Clear(CommonFunctions.ClearType.Index, ddlRte);
        CommonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBusNo);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objFacBal.MappId = ViewState["ID"].ToString();
        objFacBal.CityId = ddlCity.SelectedValue;
        objFacBal.RteId = ddlRte.SelectedValue;
        objFacBal.BusId = ddlBusNo.SelectedValue;
        objFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = objFacBll.BusRteMapInsertUpdate(objFacBal);
        ViewState["ID"] = "";
        FillGrid();
        CommonFunctions.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }

    protected void gvSave_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvSave.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("MAPP_ID=" + ViewState["ID"].ToString());
            if (dr[0][6].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Can not update deactivate data.')", true);
                return;
            }
            ddlCity.SelectedValue = (dr[0][2].ToString() == "0") ? "." : dr[0][2].ToString();
            FillFunctions.Fill(ddlRte, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.Route_Name, ddlCity.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlRte.SelectedValue = (dr[0][3].ToString() == "0") ? "." : dr[0][3].ToString();
            FillFunctions.Fill(ddlBusNo, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.BusNoCity, ddlCity.SelectedValue), false, FillFunctions.FirstItem.Select);
            ddlBusNo.SelectedValue = (dr[0][1].ToString() == "0") ? "." : dr[0][1].ToString();

        }
        else
        {
            objFacBal.ChangeStatus = e.CommandName;
            objFacBal.MappId = e.CommandArgument.ToString();
            objFacBal.SessionUserID = Session["UserID"].ToString();
            Msg = objFacBll.BusRteMapDelete(objFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
            clear();
        }

    }
    protected void ddlRte_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRte.SelectedIndex > 0)
        {
            FillFunctions.Fill(ddlBusNo, QueryFunctions.GetCommand(QueryFunctions.QueryBaseType.BusNoCity, ddlCity.SelectedValue), false, FillFunctions.FirstItem.Select);
        }
        else
            ddlBusNo.Items.Clear();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_TransportBusMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    FacBLL Objfacbll;
    FacBAL objFacBal;
    DataTable dt;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        Save.Attributes.Add("onClick", "return validate()");

        if (!IsPostBack)
        {
            PushData();
            FillGrid();
            ViewState["ID"] = "";
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        Objfacbll = new FacBLL();
        objFacBal = new FacBAL();
        dt = new DataTable();

    }
    private void PushData()
    {
        fillFunctions.Fill(ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBusType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BusType), true, FillFunctions.FirstItem.Select);
    }
    void FillGrid()
    {
        dt = Objfacbll.BusMainSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    void clear()
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlCity);
        txtBusNo.Text = "";
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBusType);
        txtcap.Text = "";
        txtcharg.Text = "";
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        objFacBal.BusId = ViewState["ID"].ToString();
        objFacBal.CityId = ddlCity.SelectedValue;
        objFacBal.SessionUserID = Session["UserID"].ToString();
        objFacBal.BusNo = txtBusNo.Text;
        objFacBal.BusType = ddlBusType.SelectedValue;
        objFacBal.Capicity = txtcap.Text;
        objFacBal.IsCharge = txtcharg.Text;
        Msg = Objfacbll.BusMainInsertUpdate(objFacBal);
        ViewState["ID"] = " ";
        FillGrid();
        commonFunctions.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("BUS_ID=" + ViewState["ID"].ToString());
            if (dr[0][7].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Can not update deactivate data.')", true);
                return;
            }
            ddlCity.SelectedValue = (dr[0][1].ToString() == "0") ? "." : dr[0][1].ToString();
            txtBusNo.Text = dr[0][2].ToString();
            ddlBusType.SelectedValue = (dr[0][3].ToString() == "0") ? "." : dr[0][3].ToString();
            txtcap.Text = dr[0][4].ToString();
            txtcharg.Text = dr[0][5].ToString();
        }
        else
        {
            objFacBal.ChangeStatus = e.CommandName;
            objFacBal.BusId = e.CommandArgument.ToString();
            objFacBal.SessionUserID =Session["UserID"].ToString();
            Msg = Objfacbll.BusMainDelete(objFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
            clear();
        }
    }
}
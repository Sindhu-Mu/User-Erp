using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_TptRouteMaster : System.Web.UI.Page
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
        fillFunctions.Fill(ddlCitySelect, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TptCity), true, FillFunctions.FirstItem.Select);
    }
    void FillGrid()
    {
        dt = Objfacbll.RouteMainSelect().Tables[0];
         ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    void clear()
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlCitySelect);
        RteName.Text = "";
        RteDesc.Text = "";
        ChDay.Text = "";
        ChSem.Text = "";
    }
protected void Save_Click(object sender, EventArgs e)
{
        objFacBal.RteId = ViewState["ID"].ToString();  
        objFacBal.CityId = ddlCitySelect.SelectedValue;
        objFacBal.SessionUserID = Session["UserID"].ToString();
        objFacBal.RteName = RteName.Text;
        objFacBal.RteDesc = RteDesc.Text;
        objFacBal.RateDay = ChDay.Text;
       objFacBal.RateSem = ChSem.Text;
        Msg = Objfacbll.RouteMainInsertUpdate(objFacBal);
        ViewState["ID"] = " ";
        FillGrid();
        commonFunctions.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+Msg+"')", true);
        clear();
}

protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
{
    if (e.CommandName == "Select")
    {
        ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("RTE_ID=" + ViewState["ID"].ToString());
        if (dr[0][8].ToString() == "False")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Can not update deactivate data.')", true);
            return;
        }
        ddlCitySelect.SelectedValue = (dr[0][1].ToString() == "0") ? "." : dr[0][1].ToString();
        RteName.Text = dr[0][2].ToString();
       RteDesc.Text =dr[0][4].ToString();
        ChDay.Text = dr[0][3].ToString();
        ChSem.Text = dr[0][5].ToString();
        }
    else
    {
        objFacBal.ChangeStatus = e.CommandName;
        objFacBal.RteId = e.CommandArgument.ToString();
        objFacBal.SessionUserID = Session["UserID"].ToString();
        Msg = Objfacbll.RouteMainDelete(objFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
    }
}
}
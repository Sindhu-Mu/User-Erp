using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_DesignationMain : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    DataTable dt;
    string Msg;
    PRBLL ObjPrBll;
    PRBAL ObjPrBAL;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("onclick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            ViewState["HEADID"] = 0;
            FillGrid();
          
            
        }

    }

    private void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjPrBll = new PRBLL();
        ObjPrBAL = new PRBAL();
       
        ObjPrBAL.balcurUserId = Session["UserId"].ToString();
        ObjPrBAL.balCurEmpCode = Session["UserId"].ToString();
    }
    private void FillGrid() // fill grid view with select all record from table
    {
        
        dt = ObjPrBll.GetHeadMain(ObjPrBll.checkIndex(ddlHeadType.SelectedValue));
        ViewState["dt"] = dt;
        GridShow.DataSource = dt;
        GridShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)   
    {
        ObjPrBAL.balHeadName = txtHeadName.Text;
        ObjPrBAL.balHeadType = ddlHeadType.SelectedValue;
        ObjPrBAL.balHeadShortName = txtShortName.Text;
        ObjPrBAL.balInCal = RlistCal.Text;
        ObjPrBAL.balHeadId = ViewState["HEADID"].ToString();
        ObjPrBll.HeadInsertUpdate(ObjPrBAL);
        common.Clear(this);
        FillGrid();
        Msg = "Operation Successfull";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }


    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)  // Desigantion Status Change in Update Forms
    {


        if (e.CommandName == "Select")
        {
            ViewState["ID"] = GridShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            ViewState["Edit"] = 0;
            ViewState["HEADID"] = GridShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("HEAD_ID=" + ViewState["HEADID"].ToString());
            txtHeadName.Text = dr[0]["HEAD_NAME"].ToString();
            txtShortName.Text = dr[0]["HEAD_SHORT_NAME"].ToString();
            ddlHeadType.SelectedValue = dr[0]["HEAD_TYPE_ID"].ToString();
            RlistCal.SelectedValue = Convert.ToInt32(dr[0]["HEAD_IN_CALCULATION"]).ToString();
         

        }
        else
        {
            if (e.CommandName == "ACTIVATE")
            {
                ObjPrBll.ChngHeadSts(e.CommandArgument.ToString(), 1);
                Msg = "Head Activated Successfully..!";
            }
            if (e.CommandName == "DEACTIVATE")
            {
                ObjPrBll.ChngHeadSts(e.CommandArgument.ToString(), 0);
                Msg = "Head Deactivated Successfully..!";
            }
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }



    protected void ddlCatId_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void ChangStatus(int action, string TempId)
    {
        ObjPrBll.ChngTempSts(action, TempId);
        FillGrid();
    }
    protected void GridShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            ViewState["Edit"] = 0;
            ViewState["HEADID"] = GridShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("HEAD_ID=" + ViewState["HEADID"].ToString());
            txtHeadName.Text = dr[0]["HEAD_NAME"].ToString();
            txtShortName.Text = dr[0]["HEAD_SHORT_NAME"].ToString();
            ddlHeadType.SelectedValue = dr[0]["HEAD_TYPE_ID"].ToString();
            RlistCal.SelectedValue = Convert.ToInt32(dr[0]["HEAD_IN_CALCULATION"]).ToString();
        }
        else if (e.CommandName == "Activate")
        {
           ChangStatus(1, e.CommandArgument.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected salary head activeted.')", true);
        }
        else if (e.CommandName == "Deactivate")
        {
            ChangStatus(0, e.CommandArgument.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected salary head deactiveted.')", true);
        }
    }
    
}
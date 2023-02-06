using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Common_HolidayMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    string Msg;
    HRBAL ObjAcaBAL;
    HRBLL ObjHrBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["dt"] = "";
            ViewState["ID"] = "";
            PushData();
            FillGrid();
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjAcaBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }
    private void PushData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDayType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DayType), true, FillFunctions.FirstItem.Select);
    }
    void FillGrid()
    {
        dt = ObjHrBll.HolidaySelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.Description = txtDesc.Text;
        ObjAcaBAL.InsId = ddlInstitution.SelectedValue;
        ObjAcaBAL.TypeId = ddlDayType.SelectedValue;
        ObjAcaBAL.Date = commonFunctions.GetDateTime(txtDate.Text);
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ObjAcaBAL.KeyID = ViewState["ID"].ToString();
        Msg=ObjHrBll.HolidayInsertUpdate(ObjAcaBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";              
        commonFunctions.Clear(this);
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("ID=" + ViewState["ID"].ToString());
            if (dr[0][7].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);      
                return;
            }
            txtDate.Text = dr[0][1].ToString();
            txtDesc.Text = dr[0][2].ToString();
            ddlInstitution.SelectedValue = (dr[0][4].ToString() == "0") ? "." : dr[0][4].ToString();              
            ddlDayType.SelectedValue = dr[0][6].ToString();
        }
        else
        {
            ObjAcaBAL.ChangeStatus = e.CommandName;
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
            Msg=ObjHrBll.HolidayDelete(ObjAcaBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_WorkingDayMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;
    string Msg;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjHrBal = new HRBAL();
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
        dt = ObjHrBll.WorkingDaySelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
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
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString(); 
        ObjHrBal.InsId = ddlInstitution.SelectedValue;
        ObjHrBal.TypeId = ddlDayType.SelectedValue;
        ObjHrBal.Date = commonFunctions.GetDateTime(txtDate.Text);
        ObjHrBal.Description = txtRemark.Text;
        ObjHrBal.SessionUserID = Session["UserID"].ToString();
        Msg = ObjHrBll.WorkingDayInsertUpdate(ObjHrBal);
        ViewState["ID"] = "";
        FillGrid();
        commonFunctions.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('"+Msg+"')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Can not update deactivate data.')", true);
                return;
            }
            txtDate.Text = dr[0][1].ToString();
            txtRemark.Text = dr[0][6].ToString();
            ddlInstitution.SelectedValue = (dr[0][3].ToString() == "0") ? "." : dr[0][3].ToString();
            ddlDayType.SelectedValue = dr[0][5].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserID"].ToString();
            Msg=ObjHrBll.WorkingDayDelete(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
}
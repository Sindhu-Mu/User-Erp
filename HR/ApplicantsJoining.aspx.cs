using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_ApplicantsJoining : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;

    public void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            FillFunction.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlJob.SelectedIndex > 0)
        {
            ViewState["ID"] = ddlJob.SelectedValue;
            FillGrid();
        }
        else
            gvApplicants.Visible = false;
        
    }
    protected void gvApplicants_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ObjHrBAL.JobId = ViewState["ID"].ToString();
        ObjHrBAL.KeyID = gvApplicants.DataKeys[e.RowIndex].Value.ToString();
        ObjHrBAL.Date = commonFunctions.GetDateTime(((TextBox)gvApplicants.Rows[e.RowIndex].Cells[2].FindControl("txtDate")).Text+" 09:00");
        ObjHrBAL.ChangeStatus = ((RadioButtonList)gvApplicants.Rows[e.RowIndex].Cells[3].FindControl("rbJoined")).SelectedValue;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBll.UpdateApplicantJoining(ObjHrBAL);
        FillFunction.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
        gvApplicants.Visible = false;
    }
    protected void gvApplicants_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvApplicants.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void gvApplicants_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvApplicants.EditIndex = -1;
        FillGrid();
    }
    void FillGrid()
    {
        ObjHrBAL.JobId = ViewState["ID"].ToString();
        gvApplicants.DataSource = ObjHrBll.GetApplicantsJoining(ObjHrBAL).Tables[0];
        gvApplicants.DataBind();
        gvApplicants.Visible = true;
    }
   
}
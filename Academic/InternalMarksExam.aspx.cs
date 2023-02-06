using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

public partial class Academic_InternalMarksExam : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    Messages Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();

        btnShow.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        Msg = new Messages();
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }
  
    protected void btnShow_Click(object sender, EventArgs e)
    {
        objBal.Brn_Id = ddlBranch.SelectedValue;
        objBal.Semid = ddlSemester.SelectedValue;
        DataTable dt = objBll.GetInternalMarksExam(objBal);
        if (dt.Rows.Count > 0)
        {
            gvShow.DataSource = dt;
            gvShow.DataBind();
            string usr_id = dt.Rows[0]["USR_ID"].ToString();
            ViewState["usr_id"] = usr_id;
        }
        else
        {
           
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No Time table exist.')", true);
            gvShow.Visible = false;
        }
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        ViewState["index"] = index.ToString();
        objBal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
        if (e.CommandName == "Print")
        {
            string fp = objBal.KeyID + ";" + ViewState["usr_id"].ToString();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMultiMarks.aspx?" + fp + "','_blank','alwaysRaised')", true);
        }
       
    }
}
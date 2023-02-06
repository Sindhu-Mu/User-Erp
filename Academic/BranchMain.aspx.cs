using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Academic_BranchMain : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    Messages msg;
    AcaBLL bll;
    DataTable dt;
    AcaBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        txtBranchName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        txtShortName.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        txtRollFormate.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            fill.Fill(ddlInstitute, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlSemester, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.SemesterType), true, FillFunctions.FirstItem.Select);
        }
    }
    

     void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
      void FillGrid()
      {

          dt = bll.AcaBranchSelect().Tables[0];                                      // fill grid view with select all record from table
          ViewState["dt"] = dt;
          gvShow.DataSource = dt;
          gvShow.DataBind();
      }

      void clear()
      {
          txtBranchName.Text = "";
          txtCapacity.Text = "";
          txtRollFormate.Text = "";
          txtShortName.Text = "";
          common.Clear(CommonFunctions.ClearType.Index,ddlCourse);
          common.Clear(CommonFunctions.ClearType.Index, ddlInstitute);
          common.Clear(CommonFunctions.ClearType.Index, ddlSemester);
      }
    protected void btnSave_Click1(object sender, EventArgs e)
    {

            bal.InsId = ViewState["ID"].ToString();
            bal.FullName = txtBranchName.Text;
            bal.Name = txtShortName.Text;
            bal.KeyValue = ddlCourse.SelectedValue;
            bal.CommonId = txtCapacity.Text;
            bal.KeyID = txtRollFormate.Text;
            bal.TypeId = ddlSemester.SelectedValue;
            bal.SessionUserID = Session["UserId"].ToString();
            Msg= bll.AcaBranchInsertUpdate(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            clear();
            FillGrid();
    }


    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
          
            common.Clear(ddlCourse, CommonFunctions.ClearType.Index);
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("PGM_BRN_ID=" + ViewState["ID"].ToString());
            if (dr[0]["PGM_BRN_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtBranchName.Text = dr[0]["BRN_FULL_NAME"].ToString();
            txtShortName.Text = dr[0]["BRN_SHORT_NAME"].ToString();
            ddlInstitute.SelectedValue = dr[0]["INS_ID"].ToString();
            fill.Fill(ddlCourse, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlCourse.SelectedValue = dr[0]["INS_PGM_ID"].ToString();
            ddlSemester.SelectedValue = dr[0]["BRN_SEM_TYPE"].ToString();
            txtCapacity.Text = dr[0]["BRN_CAPACITY"].ToString();
            txtRollFormate.Text = dr[0]["BRN_ROLL_TYPE"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.InsId = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg=bll.AcaBranchModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }


    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill.Fill(ddlCourse, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
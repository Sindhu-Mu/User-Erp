using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class HR_AttendanceIssue : System.Web.UI.Page
{
    HRBLL hrbll = null;
    DataTable dt = null;
    DataSet ds = null;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        hrbll = new HRBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions=new CommonFunctions();
        ScriptManager.GetCurrent(this).AsyncPostBackTimeout =0;
        if (!IsPostBack)
        {
          // AddKeepAlive();
            fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        int DaysInmonth = DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));
        ds = hrbll.GetAttendanceCount(ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlCodeType.SelectedValue, ddlInstitution.SelectedValue, ddlDepartment.SelectedValue, ddlStatus.SelectedValue, DaysInmonth);
        gridView.DataSource = ds;
        gridView.DataBind();
        TextBox txtRemark;
        TextBox txtNod;
        CheckBox cha;
        btnIssue.Enabled = (ds.Tables[0].Rows.Count > 0);
        foreach (GridViewRow itm in gridView.Rows)
        {
            txtNod = (TextBox)gridView.Rows[itm.RowIndex].FindControl("txtNod");
            cha = (CheckBox)gridView.Rows[itm.RowIndex].FindControl("ChIssue");
            txtRemark = (TextBox)gridView.Rows[itm.RowIndex].FindControl("txtRemark");
            if (ds.Tables[0].Rows[itm.RowIndex]["MNTH_STATUS"].ToString() == "True")
            {
                txtRemark.Text = ds.Tables[0].Rows[itm.RowIndex]["ATT_TRAN_REMARK"].ToString();

            }

        }
        btnIssue.Visible = true;
    }

   
       
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        hrbll.MonthAttendanceSubmit(ddlInstitution.SelectedValue, commonFunctions.GetDateTime(txtClosingDate.Text), ddlCodeType.SelectedValue, Session["LoginId"].ToString());
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('For selected month attendance submitted Successfully!!')", true);
        //dgShow.DataSource = "";
        //dgShow.DataBind();
        //trnew.Visible = trresign.Visible = btnSave.Visible = btnExport.Visible = false;
        //ddlUnit.SelectedIndex = ddlType.SelectedIndex = ddlProcessMain.SelectedIndex = 0;
        //txtCloseDT.Text = objGenFn.CurrentDate();
        btnIssue.Visible = true;
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitution.SelectedValue), true,FillFunctions.FirstItem.Select);
    }
    protected void btnIssue_Click(object sender, EventArgs e)
    {
        TextBox txtRemark;
        TextBox txtNod;
        CheckBox cha;
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        int z = 0;
        try
        {
            StringBuilder data = new StringBuilder();
            data.AppendFormat("<Attendance>");
            foreach (GridViewRow itm in gridView.Rows)
            {
                cha = (CheckBox)gridView.Rows[itm.RowIndex].FindControl("ChIssue");
                txtRemark = (TextBox)gridView.Rows[itm.RowIndex].FindControl("txtRemark");
                txtNod = (TextBox)gridView.Rows[itm.RowIndex].FindControl("txtNod");
                if ((cha.Checked == true) && (Convert.ToDouble(txtNod.Text) > 0))
                {
                    z = 1;
                    data.AppendFormat("<ISSUEATT ATT_TRAN_ID=\"" + gridView.DataKeys[itm.RowIndex].Values[0].ToString() + "\" ATTDAYS= \"" + txtNod.Text +
                       "\" ID= \"" + gridView.DataKeys[itm.RowIndex].Values[1].ToString() + "\" ATT_TRAN_REMARK= \"" + txtRemark.Text + "\" />");
                }
            }
            if (z == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select one to submit attendance!!')", true);
                return;
            }
            btnIssue.Enabled = false;
            data.AppendFormat("</Attendance>");
            hrbll.IssueMonthAttendance(data.ToString(),Convert.ToInt16(ddlMonth.SelectedValue),Convert.ToInt16(ddlYear.SelectedValue));
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            ddlMonth.SelectedValue = DateTime.Now.Month.ToString();
            ddlInstitution.SelectedIndex = ddlDepartment.SelectedIndex = ddlStatus.SelectedIndex = 0;
            gridView.DataSource = "";
            gridView.DataBind();
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('An error occured while marking the attendance. Please retry')", true);
            
            return;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance is successfully marked. Please switch to the Report page for more details.')", true);
        

    }
}
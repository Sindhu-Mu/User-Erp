using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_AttendanceProcess : System.Web.UI.Page
{
    HRBLL hrbll = null;
    DataTable dt = null;
    DataSet ds = null;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunction;
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        btnProcess.Attributes.Add("OnClick", "return validat()");
        hrbll = new HRBLL();
        databaseFunction = new DatabaseFunctions();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions=new CommonFunctions();
        ScriptManager.GetCurrent(this).AsyncPostBackTimeout = 0;
        if (!IsPostBack)
        {
                  
                    fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        //DateTime Fdate = new DateTime();
        DateTime Tdate = commonFunctions.GetDateTime(txtClosingDate.Text);
        dt = hrbll.AttendacecCalculatioinDate(ddlMonth.SelectedValue, ddlYear.SelectedValue, ddlInstitution.SelectedItem.Value, ddlProcessType.SelectedValue);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('For selected month attendance submitted Successfully!!')", true);
        gridView.DataSource = "";
        gvlop.DataBind();
        gvlop.DataSource = "";
        
    }
    protected void btnProcess_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
        DateTime Fdate = new DateTime();
        DateTime Tdate =commonFunctions.GetDateTime(txtClosingDate.Text);
        dt = hrbll.AttendacecCalculatioinDate(ddlMonth.SelectedValue, ddlYear.SelectedValue,ddlInstitution.SelectedItem.Value,ddlCodeType.SelectedValue);
        if (dt.Rows.Count>0)
        {
            Fdate = Convert.ToDateTime(dt.Rows[0][0]);
            if ((ddlProcessType.SelectedIndex == 0) && (dt.Rows[0][1].ToString().Length > 0))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('For this month attendance already submitted!!')", true);
                return;
            }
            else if (ddlProcessType.SelectedIndex == 1)
                Tdate = Convert.ToDateTime(dt.Rows[0][1]);

        }
        #region Code for the Attendance
        ds = hrbll.GetAttendance(Fdate, Tdate, ddlCodeType.SelectedValue, ddlInstitution.SelectedValue, Session["LoginId"].ToString(), ddlProcessType.SelectedValue);
        try
        {
            gridView.DataSource = ds.Tables[1];
            gridView.DataBind();
        }
        catch
        {
            gridView.DataSource = ds.Tables[0];
            gridView.DataBind();
        }
        btnSubmit.Visible = true;
        
        //if (ds.Tables[0].Rows.Count > 0)
        //    btnSave.Visible = btnExport.Visible = true;
        //#endregion
        //if (ddlProcessType.SelectedIndex == 0)
        //{
        //    gridView.Columns[6].Visible = false;
        //    trnew.Visible = trresign.Visible = true;
        //    gvNew.DataSource = ds.Tables[1];
        //    gvNew.DataBind();
        //    gvRelive.DataSource = ds.Tables[2];
        //    gvRelive.DataBind();
        //}
        //else
        //{
        //    dgShow.Columns[6].Visible = true;
        //    trnew.Visible = trresign.Visible = false;
        //    gvNew.DataSource = "";
        //    gvNew.DataBind();
        //    gvRelive.DataSource = "";
        //    gvRelive.DataBind();
        //}
    }
        #endregion
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        hrbll.MonthAttendanceSubmit(ddlInstitution.SelectedValue, commonFunctions.GetDateTime(txtClosingDate.Text), ddlCodeType.SelectedValue, Session["LoginId"].ToString());
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('For selected month attendance submitted Successfully!!')", true);
        //dgShow.DataSource = "";
        //dgShow.DataBind();
        //trnew.Visible = trresign.Visible = btnSave.Visible = btnExport.Visible = false;
        //ddlUnit.SelectedIndex = ddlType.SelectedIndex = ddlProcessMain.SelectedIndex = 0;
        //txtCloseDT.Text = objGenFn.CurrentDate();
        btnSubmit.Visible = true;
    }
    protected void dgShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            DropDownList ddlMonth = (DropDownList)MonthYear1.FindControl("ddlMonth");
            DropDownList ddlYear = (DropDownList)MonthYear1.FindControl("ddlYear");
            //ModalPopupExtender1.Show();
            SqlCommand cmd = new SqlCommand("GET_MONTH_LOP");
            cmd.Parameters.AddWithValue("@EMP_ID", gridView.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            cmd.Parameters.AddWithValue("@MONTH", ddlMonth.SelectedValue);
            cmd.Parameters.AddWithValue("@YEAR", ddlYear.SelectedValue);
            cmd.CommandType = CommandType.StoredProcedure;
            gvlop.DataSource = databaseFunction.GetDataSet(cmd).Tables[0];
            gvlop.DataBind();
        }
    }
}
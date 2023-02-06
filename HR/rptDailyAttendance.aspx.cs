using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class HR_rptDailyAttendance : System.Web.UI.Page
{
    HRBLL ObjHrbll;
    HRBAL ObjHrbal;
    DataSet ds;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("OnClick", "return validate();");
        instization();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            ddlDepartment.Items.Add("All");
        }
    }
    void instization()
    {
        ObjHrbll = new HRBLL();
        ObjHrbal = new HRBAL();
        databaseFunction = new DatabaseFunctions();
        ds = new DataSet();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {

        int Ok = 0;
        ObjHrbal.InsId = ddlInstitute.SelectedValue;
        ObjHrbal.DeptId = ddlDepartment.SelectedValue;
        ObjHrbal.TypeId = ddlJobType.SelectedValue;
        ObjHrbal.ViewType = ddlStatus.SelectedValue;
        ObjHrbal.KeyValue = txtDate.Text;
        ds = ObjHrbll.GetDailyAttendance(ObjHrbal);
        if (ds.Tables.Count > 0)
        {
           
            lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
            lblPresent.Text = ds.Tables[1].Rows.Count.ToString();
            int Leave = (ds.Tables[3].Rows[0][0] != DBNull.Value) ? Convert.ToInt32(ds.Tables[3].Rows[0][0]) : 0;
            int AppLeave = (ds.Tables[4].Rows[0][0] != DBNull.Value) ? Convert.ToInt32(ds.Tables[4].Rows[0][0]) : 0;
            lblLeave.Text = Leave.ToString();
            lblAppLeave.Text = AppLeave.ToString();
            lblAbsent.Text = (ds.Tables[0].Rows.Count - (ds.Tables[1].Rows.Count + Leave + AppLeave)).ToString();
            gridAttenanceReg.DataSource = ds.Tables[0];
            gridAttenanceReg.DataBind();
            foreach (GridViewRow row in gridAttenanceReg.Rows)
            {
                
                Ok = 0;
                DataRow[] drAtt = ds.Tables[1].Select("EMP_ID=" + row.Cells[1].Text);
                if (drAtt.Length > 0)
                {
                    Ok = 1;
                    row.Cells[5].Text = (drAtt[0]["1"].ToString());
                    row.Cells[6].Text = (drAtt[0]["3"] != DBNull.Value) ? drAtt[0]["3"].ToString() : drAtt[0]["2"].ToString();
                    row.Cells[7].Text = drAtt[0]["ATT_MARK_REMARK"].ToString();
                }
                DataRow[] drLv = ds.Tables[2].Select("EMP_ID=" + row.Cells[1].Text);
                if (drLv.Length > 0)
                {
                    Ok = 1;
                    row.BackColor = (drLv[0]["STS_ID"].ToString() == "-2") ? Color.Orange : Color.LawnGreen;
                    row.ForeColor = Color.White;
                    row.Cells[7].Text = drLv[0]["LV_VALUE"].ToString();
                }
                if(Ok==0)
                {
                     row.BackColor =Color.Red;
                     row.ForeColor = Color.White;
                }
            }
        }
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
            fillFunctions.Fill(ddlDepartment, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.All);
        else
        {
            ddlDepartment.Items.Clear();
            ddlDepartment.Items.Add("All");
        }

    }

}
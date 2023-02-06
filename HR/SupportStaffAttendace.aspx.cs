using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


public partial class HR_SupportStaffAttendace : System.Web.UI.Page
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
            TableDate.Visible = true;
            TableMonthly.Visible = false;
            btnDate.BackColor = Color.White;
            btnDate.ForeColor = Color.Red;
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
        btnExcelToExport.Visible =false;
        int Att = 0;
        int In = 0;
        int Out = 0;
        int InOut = 0;
     
        ObjHrbal.KeyValue = txtDate.Text;
       
        ds = ObjHrbll.GetSupportStaffAttendance(ObjHrbal);
        if (ds.Tables.Count > 0)
        {
            btnExcelToExport.Visible = true;
            lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
          
            gridAttenanceReg.DataSource = ds.Tables[0];
            gridAttenanceReg.DataBind();
            foreach (GridViewRow row in gridAttenanceReg.Rows)
            {

                Att = 0;
                In++;
                DataRow[] drAtt = ds.Tables[1].Select("EMP_ID=" + row.Cells[1].Text);
                if (drAtt.Length > 0)
                {
                    Att = 1;
                    row.Cells[2].Text = (drAtt[0][1].ToString());                   
                    row.Cells[4].Text = "In";
                }
                if (drAtt.Length > 1)
                {
                    Out++;
                    row.Cells[3].Text = (drAtt[1][1].ToString());
                    row.Cells[4].Text = (Att == 1) ? "In-Out" : "Out";
                    Att = (Att == 1) ? 3 : 2;
                }

                if (Att == 0)
                {
                    row.BackColor = Color.Red;
                    row.ForeColor = Color.White;
                }
                else if (Att == 1)
                {
                    row.BackColor = Color.LightPink;
                    row.ForeColor = Color.White;
                }
                else if (Att == 2)
                {
                    row.BackColor = Color.LightSkyBlue;
                    row.ForeColor = Color.White;
                }
                else if (Att == 3)
                {
                    InOut++;
                    row.BackColor = Color.LightGreen;
                    row.ForeColor = Color.White;
                }
                lblIn.Text = In.ToString();
                lblOut.Text = Out.ToString();
                lblInOut.Text = InOut.ToString();
            }
        }
    }

    protected void btnExcelToExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("SupportStaffAttendance.xls", gridAttenanceReg);
    }
    
    protected void btnMonthlyShow_Click(object sender, EventArgs e)
    {  int Att = 0;
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        ObjHrbal.KeyID = ddlMM.SelectedValue;
        ObjHrbal.KeyValue=(ddlYY.SelectedValue == "") ? DateTime.Now.Year.ToString() : ddlYY.SelectedValue;
        ObjHrbal.EmpId = txtEmployeeCode.Text;
        ds = ObjHrbll.GetSupportStaffMonthlyAttendance(ObjHrbal);
        if (ds.Tables.Count > 0)
        {
            btnMonthlyExportToExcel.Visible = true;
            lblTotal.Text = ds.Tables[0].Rows.Count.ToString();
            gridmonthlyAttenanceReg.DataSource = ds.Tables[0];
            gridmonthlyAttenanceReg.DataBind();
            foreach (GridViewRow row in gridmonthlyAttenanceReg.Rows)
            {

                Att = 0;

                DataRow[] drAtt = ds.Tables[1].Select("DATE='" + row.Cells[1].Text + "' AND EMP_ID=" + row.Cells[2].Text);
                if (drAtt.Length > 0)
                {
                    Att = 1;
                    row.Cells[3].Text = (drAtt[0][2].ToString());
                    row.Cells[5].Text = "In";
                }
                if (drAtt.Length > 1)
                {

                    row.Cells[4].Text = (drAtt[1][2].ToString());
                    row.Cells[5].Text = (Att == 1) ? "In-Out" : "Out";
                    Att = (Att == 1) ? 3 : 2;
                }

                if (Att == 0)
                {
                    row.BackColor = Color.Red;
                    row.ForeColor = Color.White;
                }
                else if (Att == 1)
                {
                    row.BackColor = Color.LightPink;
                    row.ForeColor = Color.White;
                }
                else if (Att == 2)
                {
                    row.BackColor = Color.LightSkyBlue;
                    row.ForeColor = Color.White;
                }
                else if (Att == 3)
                {

                    row.BackColor = Color.LightGreen;
                    row.ForeColor = Color.White;
                }
            }
        }
    }
    protected void btnMonthlyExportToExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("SupportStaffMonthlyAttendance.xls", gridmonthlyAttenanceReg);
    }
    protected void btnDate_Click(object sender, EventArgs e)
    {
        TableDate.Visible=true;
        TableMonthly.Visible = false;
        btnDate.BackColor = Color.White;
        btnDate.ForeColor = Color.Red;
        btnMonthly.BackColor = Color.Green;
        btnMonthly.ForeColor = Color.White;
    }
    protected void btnMonthly_Click(object sender, EventArgs e)
    {
        btnDate.BackColor = Color.Green;
        btnDate.ForeColor = Color.White;
        btnMonthly.BackColor = Color.White;
        btnMonthly.ForeColor = Color.Red;
        TableDate.Visible = false;
        TableMonthly.Visible = true;
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class HR_SecurityDutyRoster : System.Web.UI.Page
{
    HRBLL ObjHrbll;
    HRBAL ObjHrbal;
    DataSet ds;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunction;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnMake.Attributes.Add("OnClick", "return validate();");
        btnRebuild.Attributes.Add("OnClick", "return validate();");
        instization();
       
    }
    void instization()
    {
        ObjHrbll = new HRBLL();
        ObjHrbal = new HRBAL();
        databaseFunction = new DatabaseFunctions();
        ds = new DataSet();
        commonFunctions = new CommonFunctions();
    }
    protected void btnMake_Click(object sender, EventArgs e)
    {
        btnExcelToExport.Visible = false;
        ObjHrbal.KeyValue = txtDate.Text;
        ObjHrbal.SessionUserID=Session["UserId"].ToString();
        ds = ObjHrbll.SecurityDutyRosterInsert(ObjHrbal);
        if (ds.Tables.Count > 0)
        {
            btnExcelToExport.Visible = true;
            gridDutyChart.DataSource = ds.Tables[0];
            gridDutyChart.DataBind();
        }
    }
   
    protected void btnExcelToExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("SecurityDutyRoster.xls", gridDutyChart);
    }
    protected void btnRebuild_Click(object sender, EventArgs e)
    {
        btnExcelToExport.Visible = false;
        ObjHrbal.KeyValue = txtDate.Text;
        ObjHrbal.SessionUserID = Session["UserId"].ToString();
        ObjHrbal.TypeId = "1";
        ds = ObjHrbll.SecurityDutyRosterInsert_II(ObjHrbal);
        if (ds.Tables.Count > 0)
        {
            btnExcelToExport.Visible = true;
            gridDutyChart.DataSource = ds.Tables[0];
            gridDutyChart.DataBind();
        }
    }
}
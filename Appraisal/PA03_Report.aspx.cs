using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Appraisal_PA03_Report : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            
            FillFunction.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PAFacSts), true, FillFunctions.FirstItem.Select);
            FillFunction.FillYear(System.DateTime.Now.Year - 3, System.DateTime.Now.Year + 5, 1, FillFunctions.FirstItem.Select, ddlYear);
            //For Directors Print
            int InsId = 0;
            ObjBal.Id=Session["UserId"].ToString();
            InsId=ObjBll.getInsId(ObjBal);
            if (InsId > 0)
            {
                ddlIns.SelectedValue = InsId.ToString();
                ddlIns.Enabled = false;
                FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            }
        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlStartDt":
                if (ddlStartDt.SelectedValue == "3")
                {
                    txtRStartSD.Enabled = true;
                    txtRStartED.Enabled = true;
                }
                else if (ddlStartDt.SelectedValue == "1" || ddlStartDt.SelectedValue == "2")
                {
                    txtRStartSD.Enabled = true;
                    txtRStartED.Enabled = false;
                }
                else
                {
                    txtRStartSD.Enabled = false;
                    txtRStartED.Enabled = false;
                }
                txtRStartED.Text = txtRStartSD.Text = "";
                break;
            case "ddlEndDate":
                if (ddlEndDate.SelectedValue == "3")
                {
                    txtREndSD.Enabled = true;
                    txtREndED.Enabled = true;
                }
                else if (ddlEndDate.SelectedValue == "1" || ddlEndDate.SelectedValue == "2")
                {
                    txtREndSD.Enabled = true;
                    txtREndED.Enabled = false;
                }
                else
                {
                    txtREndSD.Enabled = false;
                    txtREndED.Enabled = false;
                }
                txtREndED.Text = txtREndSD.Text = "";
                break;


            default:
                break;
        }

    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
        {
            FillFunction.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjBal.Institute = ddlIns.SelectedValue;
        ObjBal.Dept = ddlDept.SelectedValue;
        ObjBal.Status = ddlStatus.SelectedValue;
        ObjBal.Id = ddlStartDt.SelectedValue;
        ObjBal.KeyId = ddlEndDate.SelectedValue;
        ObjBal.StartDate = txtRStartSD.Text;
        ObjBal.EndDate = txtRStartED.Text;
        ObjBal.FromDate = txtREndSD.Text;
        ObjBal.ToDate = txtREndED.Text;
        ObjBal.Year = ddlYear.SelectedValue;
        ObjBal.Sem = ddlSem.SelectedValue;
        ObjBal.Emp_id = (txtEmp.Text == "") ? txtEmp.Text : commonFunctions.GetKeyID(txtEmp);
        ds = ObjBll.getAppraisalRpt(ObjBal);
        gvReportInfo.DataSource = ds.Tables[0];
        gvReportInfo.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
            trPrint.Visible = true;
        Session["ds"] = ds.GetXml();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("Appraisal.xls", gvReportInfo);
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('PA03_PRT.aspx',alwaysraised='yes')", true);
    }
}
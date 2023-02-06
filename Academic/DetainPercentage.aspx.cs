using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Academic_DetainPercentage : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
            LoadData();
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.FillInteger(1, 12, 1, FillFunctions.FirstItem.Select, ddlSemester);
        fillFunctions.FillInteger(30, 90, 5, "%", FillFunctions.FirstItem.Select, ddlPercentage);
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourse, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlBranch, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
        {
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlBranch);
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        AcaBal.Brn_Id = ddlBranch.SelectedValue;
        AcaBal.Semid = ddlSemester.SelectedValue;
        AcaBal.TypeId = ddlPaperType.SelectedValue;
        AcaBal.Value = ddlPercentage.SelectedValue;
        AcaBal.Date = (txtDate.Text != "") ? commonFunctions.GetDateTime(txtDate.Text) : commonFunctions.GetDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
        DataSet dataSet = AcaBll.GetStudentDetainPercentage(AcaBal);
        if (dataSet.Tables[0].Rows.Count > 0)
        {
            BoundField field;
            foreach (DataColumn column in dataSet.Tables[0].Columns)
            {
                if (column.ColumnName != "ENROLLMENT_NO" && column.ColumnName != "SEM_ROLL_NO" && column.ColumnName != "STU_FULL_NAME")
                {
                    field = new BoundField();

                    field.DataField = column.ColumnName;
                    field.HtmlEncode = false;

                    field.HeaderText = column.ColumnName;
                    field.ItemStyle.HorizontalAlign = HorizontalAlign.Center;

                    gridData.Columns.Add(field);
                }

            }

        }
        fillFunctions.Fill(gridData, dataSet.Tables[0]);
        UpdatePanel1.Update();

    }
    protected void btnPrtOriginal_Click(object sender, EventArgs e)
    {
        StringBuilder url = new StringBuilder("prtAttDetainPerDetail.aspx?");
        url.Append("BRANCH_ID=" + ddlBranch.SelectedValue);
        url.Append("&SEM =" + ddlSemester.SelectedValue);
        url.Append("&PAPER_TYPE =" + ddlPaperType.SelectedValue);
        url.Append("&PERCENTAGE =" + ddlPercentage.SelectedValue);
        url.Append("&MAX_DATE =" + commonFunctions.GetDateTime(txtDate.Text).ToShortDateString());
        url.Append("&TYPE = 1");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('" + url + "','_blank','resizable=1')", true);

    }
    protected void btnPrintReport_Click(object sender, EventArgs e)
    {
        StringBuilder url = new StringBuilder("prtAttDetainPerDetail.aspx?");
        url.Append("BRANCH_ID=" + ddlBranch.SelectedValue);
        url.Append("&SEM =" + ddlSemester.SelectedValue);
        url.Append("&PAPER_TYPE =" + ddlPaperType.SelectedValue);
        url.Append("&PERCENTAGE =" + ddlPercentage.SelectedValue);
        url.Append("&MAX_DATE =" + commonFunctions.GetDateTime(txtDate.Text).ToShortDateString());
        url.Append("&TYPE = 2");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('" + url + "','_blank','resizable=1')", true);
    }
    protected void BtnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("DetainPercentageDetail.xls", gridData);
    }
}
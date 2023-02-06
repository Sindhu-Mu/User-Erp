using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
public partial class HR_EmpNxtSnrCng : System.Web.UI.Page
{
    FillFunctions fillFunction;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    private void Initialize()
    {
        fillFunction = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            pushData();
        }
    }
    void pushData()
    {
        fillFunction.Fill(ddlInstitute, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunction.Fill(ddlDepartment, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department), true, FillFunctions.FirstItem.Select);
        fillFunction.Fill(ddlNextSenior, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.NextSenior), true, FillFunctions.FirstItem.Select);
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlDepartment, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDepartment.SelectedIndex > 0)
        {
            fillFunction.Fill(ddlNextSenior, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.NextSenior_ByDepartment, ddlDepartment.SelectedValue), true, FillFunctions.FirstItem.Select);
            bindGrid();
        }
    }
    void bindGrid()
    {
        ObjAcaBAL.InsId = ddlInstitute.SelectedValue;
        ObjAcaBAL.DeptId = ddlDepartment.SelectedValue;
        ObjAcaBAL.KeyID = ddlNextSenior.SelectedValue;
        gvShow.DataSource = ObjHrBll.GetNextSenior(ObjAcaBAL);
        gvShow.DataBind();
    }
    protected void ddlNextSenior_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNextSenior.SelectedIndex > 0)
        {
            bindGrid();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
        data.AppendFormat("<SENIOR>");
        foreach (GridViewRow row in gvShow.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chk1");
            if (chk.Checked)
            {
                data.AppendFormat("<DATA EMP_ID=\"" + row.Cells[1].Text + "\"/>");
            }
        }
        data.AppendFormat("</SENIOR>");
        ObjAcaBAL.Value1 = data.ToString();
        ObjAcaBAL.EmpId = common.GetKeyID(txtNextSenior);
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ObjAcaBAL.FromDate = common.GetDateTime(txtDate.Text);
        ObjAcaBAL.RemValue = txtRemark.Text;
        ObjHrBll.NextSeniorInsert(ObjAcaBAL);
        bindGrid();
        txtNextSenior.Text = txtRemark.Text = txtDate.Text = "";
    }
}
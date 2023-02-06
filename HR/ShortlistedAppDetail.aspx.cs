using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;
public partial class HR_ShortlistedAppDetail : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;


    public void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();

        if (!IsPostBack)
        {
            FillFunction.Fill(ddlMailDomain, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlMOI, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntMode), true, FillFunctions.FirstItem.Select);
            fillGrid();
        }
        if (ddlInt.SelectedValue == "2")
            trInt.Visible = false;
        else if (ddlInt.SelectedValue == "3")
            trInt.Visible = true;
    }
    void fillGrid()
    {
        ObjHrBAL.HeadID = Request.QueryString[0];
        ds = ObjHrBll.ApplicantForIntCall(ObjHrBAL);
        DataRow dr = ds.Tables[1].Rows[0];
        lblFName.Text = txtFirstName.Text = dr["F_NAME"].ToString();
        lblMName.Text = txtMiddleName.Text = dr["M_NAME"].ToString();
        lblLName.Text = txtLastName.Text = dr["L_NAME"].ToString();
        lblMail.Text = txtMail.Text = dr["MAIL"].ToString();
        lblMailDomain.Text = dr["MAIL_DOM_VALUE"].ToString();
        ddlMailDomain.SelectedValue = dr["MAIL_DOMAIN_ID"].ToString();
        lblLocation.Text = txtLocation.Text = dr["LOCATION"].ToString();
        lblAdmin.Text = ddlAdmin.SelectedItem.Text = dr["ADMIN_WORK"].ToString();
        lblCurCTC.Text = txtCrntCTC.Text = dr["CURRENT_CTC"].ToString();
        lblExpCTC.Text = txtExpctCTC.Text = dr["EXPECTED_CTC"].ToString();
        lblNotPer.Text = txtDays.Text = dr["JOINING_DAYS"].ToString();
        lblRemark.Text = txtRemark.Text = dr["REMARK"].ToString();
        ViewState["ds"] = ds;
        ShowAcademic(ds.Tables[2]);
        ShowExperience(ds.Tables[3]);
        ddlInt.SelectedValue = ds.Tables[4].Rows[0][0].ToString();

    }

    #region Basic
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        ddlAdmin.Visible = txtCrntCTC.Visible = txtDays.Visible = txtExpctCTC.Visible = txtFirstName.Visible = txtLastName.Visible = txtLocation.Visible = txtMail.Visible = txtMiddleName.Visible = txtRemark.Visible = ddlMailDomain.Visible = true;
        lblAdmin.Visible = lblCurCTC.Visible = lblExpCTC.Visible = lblFName.Visible = lblLName.Visible = lblLocation.Visible = lblMail.Visible = lblMailDomain.Visible = lblMName.Visible = lblNotPer.Visible = lblRemark.Visible = false;
        btnUpdateBasic.Visible = true;
        btnEdit.Visible = false;
    }
    protected void btnCancelBasic_Click(object sender, EventArgs e)
    {
        ddlAdmin.Visible = txtCrntCTC.Visible = txtDays.Visible = txtExpctCTC.Visible = txtFirstName.Visible = txtLastName.Visible = txtLocation.Visible = txtMail.Visible = txtMiddleName.Visible = txtRemark.Visible = ddlMailDomain.Visible = false;
        lblAdmin.Visible = lblCurCTC.Visible = lblExpCTC.Visible = lblFName.Visible = lblLName.Visible = lblLocation.Visible = lblMail.Visible = lblMailDomain.Visible = lblMName.Visible = lblNotPer.Visible = lblRemark.Visible = true;
        btnUpdateBasic.Visible = false;
        btnEdit.Visible = true;
    }
    protected void btnUpdateBasic_Click(object sender, EventArgs e)
    {
        lblAdmin.Text = ddlAdmin.SelectedItem.ToString();
        lblCurCTC.Text = txtCrntCTC.Text;
        lblExpCTC.Text = txtExpctCTC.Text;
        lblFName.Text = txtFirstName.Text;
        lblLName.Text = txtLastName.Text;
        lblLocation.Text = txtLocation.Text;
        lblMail.Text = txtMail.Text;
        lblMailDomain.Text = ddlMailDomain.SelectedItem.ToString();
        lblMName.Text = txtMiddleName.Text;
        lblNotPer.Text = txtDays.Text;
        lblRemark.Text = txtRemark.Text;
        ddlAdmin.Visible = txtCrntCTC.Visible = txtDays.Visible = txtExpctCTC.Visible = txtFirstName.Visible = txtLastName.Visible = txtLocation.Visible = txtMail.Visible = txtMiddleName.Visible = txtRemark.Visible = ddlMailDomain.Visible = false;
        lblAdmin.Visible = lblCurCTC.Visible = lblExpCTC.Visible = lblFName.Visible = lblLName.Visible = lblLocation.Visible = lblMail.Visible = lblMailDomain.Visible = lblMName.Visible = lblNotPer.Visible = lblRemark.Visible = true;
        btnUpdateBasic.Visible = false;
        btnEdit.Visible = true;
    }
    #endregion

    #region Academic
    protected void gridAcademic_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        FillFunction.Fill(ddlAcademicBase, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Academic), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlBoard, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Board), true, FillFunctions.FirstItem.Select);
        FillFunction.FillYear(DateTime.Now.Year - 40, DateTime.Now.Year, 1, FillFunctions.FirstItem.Select, ddlYear);
        FillFunction.Fill(ddlQual, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.EmpCrs), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlDivision, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Div), true, FillFunctions.FirstItem.Select);
        trAca.Visible = true;
        trAcaGrid.Visible = false;
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(TextBox1.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA");
            ddlAcademicBase.SelectedValue = nodeList[index]["ACA_BASE_ID"].InnerText.ToString();
            ddlYear.SelectedValue = nodeList[index]["YER"].InnerText.ToString();
            ddlQual.SelectedValue = nodeList[index]["ACA_CRS_ID"].InnerText;
            ddlBoard.SelectedValue = nodeList[index]["ACA_BRD_ID"].InnerText;
            txtSchool.Text = nodeList[index]["SCH"].InnerText;
            ddlBaseType.SelectedValue = nodeList[index]["ACA_TYPE_ID"].InnerText;
            txtSpec.Text = nodeList[index]["SPEC"].InnerText;
            ddlYear.SelectedValue = nodeList[index]["YER"].InnerText;
            txtPercentage.Text = nodeList[index]["PRSNT"].InnerText;
            ddlDivision.SelectedValue = (nodeList[index]["DIV_ID"].InnerText != "0") ? nodeList[index]["DIV_ID"].InnerText : ".";
        }
        btnAcaUpdate.Visible = true;
    }
    protected void txtObtMrks_TextChanged(object sender, EventArgs e)
    {
        double total = Convert.ToDouble(txtTotalMks.Text);
        double obtained = Convert.ToDouble(txtObtMrks.Text);
        double percent = (obtained * 100) / total;
        txtPercentage.Text = (obtained == 0 && total == 0) ? "0" : percent.ToString("N2");
    }
    public void ShowAcademic(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<ACA>");
            xmlString = xmlString.Replace("</NewDataSet>", "</ACA>");
            xmlString = xmlString.Replace("<Table2>", "<DATA>");
            xmlString = xmlString.Replace("</Table2>", "</DATA>");
            TextBox1.Text = xmlString;
            LoadData();
        }
        else
        {
            TextBox1.Text = "";
            LoadData();
        }
    }
    void LoadData()
    {
        try
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox1.Text));

            if (TextBox1.Text != "")
            {
                gvAcademic.DataSource = dataSet.Tables[0];
                gvAcademic.DataBind();
                foreach (GridViewRow row in gvAcademic.Rows)
                {
                    if (gvAcademic.DataKeys[row.RowIndex].Value.ToString() == "2")
                    {
                        row.BackColor = System.Drawing.Color.Red;
                    }
                }
            }
            else
            {
                gvAcademic.DataSource = "";
                gvAcademic.DataBind();
            }
            btnAcaUpdate.Visible = false;

        }
        catch
        {
            gvAcademic.Columns[5].Visible = false;
            gvAcademic.DataBind();

        }
    }
    void Clear()
    {
        txtObtMrks.Text = txtPercentage.Text = txtSchool.Text = txtSpec.Text = txtTotalMks.Text = "";
        ddlAcademicBase.SelectedIndex = ddlBoard.SelectedIndex = ddlDivision.SelectedIndex = ddlBaseType.SelectedIndex = ddlQual.SelectedIndex = ddlYear.SelectedIndex = 0;
    }
    protected void btnAcaUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("ACA/DATA");
        nodeList[index]["ACA_BASE_ID"].InnerText = ddlAcademicBase.SelectedValue;
        nodeList[index]["ACA_BASE_FULL_NAME"].InnerText = ddlAcademicBase.SelectedItem.Text;
        nodeList[index]["ACA_BRD_ID"].InnerText = ddlBoard.SelectedValue;
        nodeList[index]["ACA_BRD_FULL_NAME"].InnerText = ddlBoard.SelectedItem.Text;
        nodeList[index]["ACA_CRS_ID"].InnerText = ddlQual.SelectedValue;
        nodeList[index]["SCH"].InnerText = txtSchool.Text;
        nodeList[index]["ACA_TYPE_ID"].InnerText = ddlBaseType.SelectedValue;
        nodeList[index]["ACA_TYPE_VALUE"].InnerText = ddlBaseType.SelectedItem.Text;
        nodeList[index]["SPEC"].InnerText = txtSpec.Text;
        nodeList[index]["YER"].InnerText = ddlYear.SelectedValue;
        nodeList[index]["PRSNT"].InnerText = txtPercentage.Text;
        nodeList[index]["DIV_ID"].InnerText = (ddlDivision.SelectedValue != ".") ? ddlDivision.SelectedValue : "0";
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
        Clear();
        trAca.Visible = false;
        trAcaGrid.Visible = true;
    }
    protected void btnAcaCancel_Click(object sender, EventArgs e)
    {
        trAca.Visible = false;
        trAcaGrid.Visible = true;
    }
    #endregion

    #region Experience
    public void ShowExperience(DataTable dt)
    {
        if (dt.Rows.Count > 0)
        {
            StringWriter writer = new StringWriter();
            dt.WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<EXP>");
            xmlString = xmlString.Replace("</NewDataSet>", "</EXP>");
            xmlString = xmlString.Replace("<Table3>", "<DATA>");
            xmlString = xmlString.Replace("</Table3>", "</DATA>");
            TextBox2.Text = xmlString;
            LoadExpData();
        }
        else
        {
            TextBox2.Text = "";
            LoadExpData();
        }
    }
    protected void gvExperience_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        FillFunction.Fill(ddlState, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlOrg, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Organization), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OrgType), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlExpType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ExpType), true, FillFunctions.FirstItem.Select);
        trExp.Visible = true;
        trExpGrid.Visible = false;
        if (e.CommandName == "Select")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            ViewState["index"] = index;
            XmlDocument xmlData = new XmlDocument();
            xmlData.LoadXml(TextBox2.Text);
            XmlNodeList nodeList = xmlData.SelectNodes("EXP/DATA");

            ddlExpType.SelectedValue = nodeList[index]["EXP_TYPE_ID"].InnerText.ToString();
            ddlOrg.SelectedValue = nodeList[index]["ORG_ID"].InnerText.ToString();
            txtDesignation.Text = nodeList[index]["EXP_DESIG"].InnerText;
            DateTime date = commonFunctions.GetDateTime(nodeList[index]["FRM_DATE"].InnerText);
            txtFromDT.Text = date.ToString("dd/MM/yyyy");
            date = commonFunctions.GetDateTime(nodeList[index]["TO_DATE"].InnerText);
            txtToDT.Text = date.ToString("dd/MM/yyyy");

        }
        btnExpUpdate.Visible = true;
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlState, ddlCity, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlState, CommonFunctions.ClearType.Value, ddlCity);

    }
    protected void btnOrgSave_Click(object sender, EventArgs e)
    {
        ObjHrBAL.ORGNAME = txtOrgName.Text;
        ObjHrBAL.ORGADD = txtAddress.Text;
        ObjHrBAL.ORGTYPEID = ddlType.SelectedValue;
        ObjHrBAL.CITYID = ddlCity.SelectedValue;
        ObjHrBAL.ORGNAME = txtOrgName.Text;
        string Msg = ObjHrBll.OrganizationInsert(ObjHrBAL);
        FillFunction.Fill(ddlOrg, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Organization), true, FillFunctions.FirstItem.Select);
    }
    protected void btnExpUpdate_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox2.Text);
        int index = Convert.ToInt32(ViewState["index"]);
        XmlNodeList nodeList = xmlData.SelectNodes("EXP/DATA");
        nodeList[index]["EXP_TYPE_ID"].InnerText = ddlExpType.SelectedValue;
        nodeList[index]["EXP_TYPE_VALUE"].InnerText = ddlExpType.SelectedItem.Text;
        nodeList[index]["ORG_ID"].InnerText = ddlOrg.SelectedValue;
        nodeList[index]["ORG_NAME"].InnerText = ddlOrg.SelectedItem.Text;
        nodeList[index]["FRM_DATE"].InnerText = commonFunctions.GetDateTime(txtFromDT.Text).ToString();
        nodeList[index]["TO_DATE"].InnerText = commonFunctions.GetDateTime(txtToDT.Text).ToString();
        nodeList[index]["EXP_DESIG"].InnerText = txtDesignation.Text;
        if (xmlData.FirstChild.HasChildNodes)
            TextBox2.Text = xmlData.OuterXml;
        else
            TextBox2.Text = "";
        LoadExpData();
        ClearExp();
        trExp.Visible = false;
        trExpGrid.Visible = true;
    }
    void LoadExpData()
    {
        if (TextBox2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox2.Text));
            gvExperience.DataSource = dataSet.Tables[0];
            gvExperience.DataBind();
            foreach (GridViewRow row in gvExperience.Rows)
            {
                if (gvExperience.DataKeys[row.RowIndex].Value.ToString() == "2")
                {
                    row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
        else
        {
            gvExperience.DataSource = "";
            gvExperience.DataBind();
        }
        btnExpUpdate.Visible = false;
    }
    void ClearExp()
    {
        txtAddress.Text = txtFromDT.Text = txtToDT.Text = txtDesignation.Text = txtJobDesc.Text = "";
        ddlOrg.SelectedIndex = ddlExpType.SelectedIndex = 0;
    }
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {

        ObjHrBAL.JobId = Request.QueryString[1];
        ObjHrBAL.HeadID = Request.QueryString[0];
        ObjHrBAL.FName = lblFName.Text;
        ObjHrBAL.MName = lblMName.Text;
        ObjHrBAL.LName = lblLName.Text;
        ObjHrBAL.PhnNo = "";
        ObjHrBAL.MailId = lblMail.Text;
        ObjHrBAL.MailDomain = lblMailDomain.Text;
        ObjHrBAL.Location = lblLocation.Text;
        ObjHrBAL.Admin = lblAdmin.Text;
        ObjHrBAL.CurCTC = lblCurCTC.Text;
        ObjHrBAL.ExpCTC = lblExpCTC.Text;
        ObjHrBAL.Total = lblNotPer.Text;
        ObjHrBAL.XmlData = TextBox1.Text;
        ObjHrBAL.ExpData = TextBox2.Text;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBAL.ChangeStatus = ddlInt.SelectedValue;
        ObjHrBAL.RemValue = txtRemark.Text;
        if (ddlInt.SelectedValue == "3")
        {
            if (txtIntDate.Text != "" && txtInTime.Text != "")
            {
                ObjHrBAL.ChangeStatus = "4";
                ObjHrBAL.Date = commonFunctions.GetDateTime(txtIntDate.Text + " " + txtInTime.Text);
                ObjHrBAL.KeyValue = ddlMOI.SelectedValue;

            }
        }

        string Msg = ObjHrBll.UpdateApplicant(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "refreshParent();", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "refreshParent();", true);
    }

    protected void ddlInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInt.SelectedValue == "2")
            trInt.Visible = false;
        else if (ddlInt.SelectedValue == "3")
            trInt.Visible = true;
    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

public partial class HR_HrLeaveApp : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    DatabaseFunctions databaseFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dtIn;
    DataTable dtEx;
    string Msg;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        dtIn = new DataTable();
        dtEx = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("OnClick", "return ValidateShow()");
        btnComSave.Attributes.Add("OnClick", "return ComValidation()");
        btnCancelSave.Attributes.Add("OnClick", "return CancelValidation()");
        btnAdd.Attributes.Add("OnClick", "return AddValidation()");
        if (!IsPostBack)
        {
            ViewState["dtIn"] = "";
            ViewState["dtEx"] = "";
            ViewState["UsrID"] = "";
            ViewState["KeyId"] = "";
            
            TabContainer1.ActiveTabIndex = 1;
            //LvEligible();
        }
    }
    private void PushData()
    {
        ObjHrBal.SessionUserID = ViewState["UsrID"].ToString();
        fillFunctions.Fill(ddlLvType,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType),true,FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlComAppBy, ObjHrBll.LvAppAuthSelect(), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSaction, ObjHrBll.LvAppAuthSelect(), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlCanSan, ObjHrBll.LvAppAuthSelect(), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlLvType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLvType.SelectedValue == "11")
        {
            tdSLTime.Visible = tdSL.Visible = true;
            tdToDt.Visible = tdDt.Visible = tdDType.Visible = tdDay.Visible = false;
        }
        else
        {
            tdSLTime.Visible = tdSL.Visible = false;
            tdToDt.Visible = tdDt.Visible = tdDType.Visible = tdDay.Visible = true;
        }
    }
    #region Button Functions
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ViewState["UsrID"] = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Usr_id, commonFunctions.GetKeyID(txtEmp) ));
        PushData();
        tdApp.Visible = true;
        LeaveBalance.show(ViewState["UsrID"].ToString(), DateTime.Now.Year.ToString());
    }

    protected void btnComSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.EmpId = ViewState["UsrID"].ToString();
        ObjHrBal.Date = commonFunctions.GetDateTime(txtComDay.Text);
        ObjHrBal.Name = ddlComAppBy.SelectedValue;
        ObjHrBal.RegDate = commonFunctions.GetDateTime(txtComAppDt.Text);
        ObjHrBal.Max = ddlCredit.SelectedValue;
        ObjHrBal.Description = txtDscrp.Text;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.TypeId = "1";
        DataTable dt = ObjHrBll.EmpComLvCrdCheck(ObjHrBal);
        if (dt.Rows[0][0].ToString() == "1")
        {
            ObjHrBll.EmpComCrdByHR(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Data saved successfully.')", true);
            FillComDetailGrid(ObjHrBal);
            ClearComLv();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + dt.Rows[0][1].ToString() + "')", true);
            txtComDay.Focus();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Permit = "0";
        if (ddlLvType.SelectedValue == "11")
        {
            txtToDt.Text = txtFromDt.Text;
        }
        ObjHrBal = GetData();
        if (ObjHrBal.ViewType == "1")
        {
            Permit = ObjHrBll.EmpLvAllowed(ObjHrBal);
            if (Permit != "1")
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Continuation of application is not as per rule check it!!')", true);
        }

        if ((ObjHrBal.ViewType == "1" && Permit == "1") || ObjHrBal.ViewType == "2")
        {
            string msg = ObjHrBll.EmpLvCheck(ObjHrBal);
            if (msg == "1")
            {
                DataSet ds = ObjHrBll.EmpLvDaySelect(ObjHrBal);
                btnAppSave.Visible = true;
                lblNod.Text = ds.Tables[2].Rows[0][0].ToString();
                disabled();
                if (ddlLvType.SelectedValue == "9")
                {
                    trArr.Visible = false;
                    trSave.Visible = true;
                }
                else
                {
                    if (lblNod.Text != "0")
                    {
                        trArr.Visible = trSave.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('There is no working day to apply leave.!!')", true);
                    }
                }
            }
            else if (msg != "")
            {
                trArr.Visible = trSave.Visible = false;
                Show_Message(msg);
                return;
            }
            else
            {
                TimeSpan t = commonFunctions.GetDateTime(txtToDt.Text) - commonFunctions.GetDateTime(txtFromDt.Text);
                lblNod.Text = ((t.TotalDays) + 1).ToString();
                disabled();
                if (lblNod.Text != "0")
                {
                    trArr.Visible = false;
                    trSave.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('There is no working day to apply leave.!!')", true);
                }
            }
        }
    }
    protected void btnAppSave_Click(object sender, EventArgs e)
    {
        if (Add())
        {
            ObjHrBal = GetData();
            ObjHrBll.EmplvAppInsertForHR(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Leave Application saved successfully.')", true);
            ClearLvApp();
            upd.Update();
            LeaveBalance.show(ViewState["UsrID"].ToString(), DateTime.Now.Year.ToString());
        }
    }
    protected void btnCancelSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.Description = txtRemark.Text;
        ObjHrBal.Code = ddlCanSan.SelectedValue;
        ObjHrBal.Date = commonFunctions.GetDateTime(txtCancelDT.Text);
        ObjHrBal.KeyID = ViewState["KeyId"].ToString();
        Msg = ObjHrBll.EmpLvCancelByHR(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillLvCancelGrid(ObjHrBal);
        trCancelSanction.Visible = false;

    }
    protected void btnDocSave_Click(object sender, EventArgs e)
    {
        string ext, url;
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/Leave_Document"));
        if (folders.Exists == false)
            folders.Create();
        if (upd1.PostedFile.FileName.ToString() != "")
        {
            ext = Path.GetExtension(upd1.PostedFile.FileName);
            if ((ext != ".doc") && (ext != ".pdf") && (ext != ".docx") && (ext != ".xml") && (ext != ".jpg"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Upload Appropriate File like .doc,.docx,.pdf, .xml file')", true);
                upd1.Focus();
                return;
            }
            else
            {
                url = "../UploadedFile/Leave_Document/" + ObjHrBal.KeyID + ext;
                upd1.PostedFile.SaveAs(Server.MapPath(url));
                ObjHrBal.SessionUserID = Session["UserId"].ToString();
                ObjHrBal.PageName = ObjHrBal.KeyID + ext;
                ObjHrBal.Document = txtDoc2.Text;
                ObjHrBll.EmpLvDocInsert(ObjHrBal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('File Uploaded Successfully.')", true);
                FillLvDoc(ObjHrBal);
                txtDoc2.Text = "";
                trDocType.Visible = false;
            }
        }

    }
    #endregion

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        ObjHrBal.SessionUserID = ViewState["UsrID"].ToString();
        ObjHrBal.TypeId = "1";
        ObjHrBal.AliasValue = "1";
        if (TabContainer1.ActiveTabIndex == 0)
        {
            FillLvDetailGrid(ObjHrBal);
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            ClearLvApp();
        }
        else if (TabContainer1.ActiveTabIndex == 2)
        {
            ClearComLv();
            FillComDetailGrid(ObjHrBal);
        }
        else if (TabContainer1.ActiveTabIndex == 3)
        {
            ObjHrBal.TypeId = "7";
            FillLvCancelGrid(ObjHrBal);
        }
        else if (TabContainer1.ActiveTabIndex == 4)
        {
            FillLvDoc(ObjHrBal);
        }
        else
        {
        }
    }

    #region FillGrid
    public void FillLvDetailGrid(HRBAL ObjBal)
    {
        ObjHrBal.SessionUserID = ViewState["UsrID"].ToString();
        DataTable dt = ObjHrBll.EmpLvDetailSelect(ObjBal);
        gvLvDetail.DataSource = dt;
        gvLvDetail.DataBind();
    }
    public void FillComDetailGrid(HRBAL ObjBal)
    {
        ObjHrBal.SessionUserID = ViewState["UsrID"].ToString();
        DataTable dt = ObjHrBll.EmpComLvDetailSelect(ObjBal);
        gvComDetail.DataSource = dt;
        gvComDetail.DataBind();
    }
    public void FillLvCancelGrid(HRBAL ObjBal)
    {
        ObjHrBal.SessionUserID = ViewState["UsrID"].ToString();
        DataTable dt = ObjHrBll.EmpLvCancelSelectForHR(ObjHrBal);
        gvLvCancel.DataSource = dt;
        gvLvCancel.DataBind();
        ObjHrBal.TypeId = "7";
        dt = ObjHrBll.EmpLvDetailSelect(ObjBal);
        trCancelSanction.Visible = false;
    }
    public void FillLvDoc(HRBAL ObjBal)
    {

        ObjHrBal.SessionUserID = ViewState["UsrID"].ToString();
        DataTable dt = ObjHrBll.EmpLvDocToUploadSelect(ObjBal);
        gvDocShow.DataSource = dt;
        gvDocShow.DataBind();
        trDocType.Visible = false;
    }
    #endregion

    
    #region Clear
    void ClearLvApp()
    {
        txtAdd.Text = txtData.Text = txtDscrp.Text = txtFromDt.Text = txtReason.Text = txtToDt.Text = "";
        ddlDayType.SelectedIndex = ddlLvType.SelectedIndex = 0;        
        trArr.Visible = trSave.Visible = tdSL.Visible = tdSLTime.Visible = false;
        txtFromDt.Enabled = txtToDt.Enabled = ddlLvType.Enabled = ddlDayType.Enabled = true;
        tdDt.Visible = tdToDt.Visible = true;
        ddlSaction.SelectedIndex = 0;
        txtSactionDt.Text = "";
        
    }
    void ClearComLv()
    {
        txtComDay.Text = txtComAppDt.Text = txtDscrp.Text = "";
        ddlComAppBy.SelectedIndex = 0;
    }
    public void disabled()
    {
        txtFromDt.Enabled = txtToDt.Enabled = ddlLvType.Enabled = ddlDayType.Enabled = false;
    }
    #endregion

    public HRBAL GetData()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.EmpId = ViewState["UsrID"].ToString();
        if (ddlLvType.SelectedValue == "11")
        {
            ObjHrBal.FromDate = commonFunctions.GetDateTime(txtFromDt.Text + " " + txtFrmTime.Text);
            ObjHrBal.ToDate = ObjHrBal.FromDate.AddHours(2);
        }
        else
        {
            ObjHrBal.FromDate = commonFunctions.GetDateTime(txtFromDt.Text);
            ObjHrBal.ToDate = commonFunctions.GetDateTime(txtToDt.Text);
        }
        ObjHrBal.TypeId = ddlLvType.SelectedValue;
        ObjHrBal.Description = txtReason.Text;
        ObjHrBal.RemValue = txtAdd.Text;
        ObjHrBal.PhnNo = txtAdd.Text;        
        ObjHrBal.ValueType = ddlDayType.SelectedValue;
        ObjHrBal.ChangeStatus = "-2";
        ObjHrBal.KeyValue = txtData.Text;
        ObjHrBal.Max = lblNod.Text;
        if (RDList.SelectedValue == "1")
            ObjHrBal.ViewType = "1";
        else
            ObjHrBal.ViewType = "2";
        ObjHrBal.PostId = ddlSaction.SelectedValue;
        ObjHrBal.Date = commonFunctions.GetDateTime(txtSactionDt.Text);

        return ObjHrBal;
    }
    public void Show_Message(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        TabContainer1.ActiveTabIndex = 0;
    }

    Boolean Add()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("ARR");
            xmlData.AppendChild(ROOT);
        }
        if (trArr.Visible == true)
        {
            
                string[] emp = txtArrWith.Text.Split(':');
                if (emp.Length > 1)
                {
                    if (emp[1].ToString() == ViewState["UsrID"].ToString())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You can not arrange duty with himself.')", true);
                        return false;
                    }

                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);
                    XmlElement element = xmlData.CreateElement("ARR_WITH");
                    element.InnerText = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Usr_id, emp[1].ToString()));
                    dataElement.AppendChild(element);
                    element = xmlData.CreateElement("TT_DET_ID");
                    element.InnerText = "";
                    dataElement.AppendChild(element);
                    element = xmlData.CreateElement("ARR_REMARK");
                    element.InnerText = txtArrDesp.Text;
                    dataElement.AppendChild(element);

                    txtData.Text = xmlData.OuterXml;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter employee name & code.')", true);
                    return false;
                }
        }            
        return true;
    }

    protected void gvLvCancel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["KeyId"] = gvLvCancel.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        trCancelSanction.Visible = true;
    }

    protected void gvDocShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["KeyId"] = gvDocShow.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        trDocType.Visible = true;
        txtRemark.Text = txtCancelDT.Text = "";
        ddlCanSan.SelectedIndex = 0;
    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearLvApp();
    }
}
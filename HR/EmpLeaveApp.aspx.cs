using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class HR_EmpLeaveApplication : System.Web.UI.Page
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

    private void PushData()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        //fillFunctions.Fill(ddlLvType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true,FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlLvType, ObjHrBll.EmpLvTypeSelect(ObjHrBal), true, FillFunctions.FirstItem.Select);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAdd.Attributes.Add("OnClick", "return AddValidation()");
        btnAppSave.Attributes.Add("OnClick", "return AddValidation()");
        //  btnComSave.Attributes.Add("OnClick", "return ComValidation()");
        btnAdd.Enabled = true;
        btnAppSave.Enabled = true;
        if (!IsPostBack)
        {
            //ViewState["dtIn"] = "";
            ViewState["dtEx"] = "";
            PushData();
            TabContainer1.ActiveTabIndex = 1;
            LvEligible();
        }
    }

    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.TypeId = "1";
        if (TabContainer1.ActiveTabIndex == 0)
        {

            FillLvDetailGrid(ObjHrBal);
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            LvEligible();
            ClearLvApp();
        }
        //else if (TabContainer1.ActiveTabIndex == 2)
        //{
        //    ClearComLv();
        //    FillComDetailGrid(ObjHrBal);
        //}
        else if (TabContainer1.ActiveTabIndex == 3)
        {
            ObjHrBal.TypeId = "7";
            FillLvCancelGrid(ObjHrBal);
        }
        else
        {
        }
    }

    #region FillGrid
    public void FillLvDetailGrid(HRBAL ObjBal)
    {
        DataTable dt = ObjHrBll.EmpLvDetailSelect(ObjBal);
        gvLvDetail.DataSource = dt;
        gvLvDetail.DataBind();
    }
    public void FillArrGrid(HRBAL ObjBal)
    {
        DataSet ds = ObjHrBll.EmpLvDaySelect(ObjBal);
        //ViewState["dtIn"] = ds.Tables[0];
        ViewState["dtEx"] = ds.Tables[1];
        ObjBal.TypeId = ddlDayType.SelectedValue;
        dtIn = ObjHrBll.EmpTTSelectForTT(ObjBal);
        if (dtIn.Rows.Count > 0)
            fillFunctions.Fill(gvLvArr, dtIn);
        else
            trArrTxt.Visible = true;
        //fillFunctions.Fill(gvLvArr, (DataTable)ViewState["dtIn"]);
        btnAppSave.Visible = true;
        lblNod.Text = ds.Tables[2].Rows[0][0].ToString();
    }
    //public void FillComDetailGrid(HRBAL ObjBal)
    //{
    //    DataTable dt = ObjHrBll.EmpComLvDetailSelect(ObjBal);
    //    gvComDetail.DataSource = dt;
    //    gvComDetail.DataBind();
    //}
    public void FillLvCancelGrid(HRBAL ObjBal)
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        DataTable dt = ObjHrBll.EmpLvCancelSelect(ObjHrBal);
        gvLvCancel.DataSource = dt;
        gvLvCancel.DataBind();
        dt = ObjHrBll.EmpLvDetailSelect(ObjBal);
        gvLvCancelDetail.DataSource = dt;
        gvLvCancelDetail.DataBind();
    }
    #endregion

    #region Clear
    void ClearLvApp()
    {
        txtAdd.Text = txtData.Text = txtFromDt.Text = txtReason.Text = txtToDt.Text = txtArrWith.Text = txtArrDesp.Text = "";
        ddlDayType.SelectedIndex = ddlLvType.SelectedIndex = 0;
        gvLvArr.DataSource = "";
        gvLvArr.DataBind();
        trArr.Visible = trSave.Visible = tdSL.Visible = tdSLTime.Visible = trArrTxt.Visible = false;
        txtFromDt.Enabled = txtToDt.Enabled = ddlLvType.Enabled = ddlDayType.Enabled = true;
        tdDt.Visible = tdToDt.Visible = true;
    }
    //void ClearComLv()
    //{
    //    txtComDay.Text = txtComFTime.Text = txtComTTime.Text = "";
    //}
    public void disabled()
    {
        txtFromDt.Enabled = txtToDt.Enabled = ddlLvType.Enabled = ddlDayType.Enabled = false;
    }
    #endregion

    public void LvEligible()
    {
        //Employee is eligible for leave or not.
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        DataTable dt = ObjHrBll.EmpLvEligible(ObjHrBal).Tables[0];
        if (dt.Rows[0][0].ToString() != "0")
        {
            Show_Message(dt.Rows[0][1].ToString());
        }
    }
    public void Show_Message(string msg)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        TabContainer1.ActiveTabIndex = 0;
    }


    #region Button Functions
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //commonFunctions.Clear(gvLvArr);
        if (ddlLvType.SelectedValue == "11" || ddlLvType.SelectedValue == "12")
        {
            txtToDt.Text = txtFromDt.Text;
        }
        if (ddlDayType.SelectedValue != "0")
        {
            if (txtFromDt.Text != txtToDt.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Date should be same for half day')", true);
                txtFromDt.Focus();
                return;
            }
        }
        gvLvArr.DataSource = "";
        gvLvArr.DataBind();
        ObjHrBal = GetData();
        string Permit = ObjHrBll.EmpLvAllowed(ObjHrBal);
        if (Permit == "1")
        {
            if (ddlLvType.SelectedValue == "11")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Attendance should be marked for short leave otherwise short leave will not get forwarded.!!')", true);
            }
            string msg = ObjHrBll.EmpLvCheck(ObjHrBal);
            if (msg == "1")
            {
                FillArrGrid(ObjHrBal);
                disabled();

                if (lblNod.Text != "0")
                {
                    trArr.Visible = trSave.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('There is no working day to apply leave.!!')", true);
                }
            }
            else if (msg != "")
            {
                trArr.Visible = trArrTxt.Visible = trSave.Visible = false;
                Show_Message(msg);
                return;
            }
            else
            {
                TimeSpan t = commonFunctions.GetDateTime(txtToDt.Text) - commonFunctions.GetDateTime(txtFromDt.Text);
                lblNod.Text = ((t.TotalDays) + 1).ToString();

                if (lblNod.Text != "0")
                {
                    trArr.Visible = trArrTxt.Visible = false;
                    trSave.Visible = true;
                    disabled();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('There is no working day to apply leave.!!')", true);
                }
            }
        }
        else if (Permit == "2")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Online leave process suspended due to major examination.')", true);
        }
        else
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Continuation of application is not as per rule check it!!')", true);
    }
    //public bool restricted(string date)
    //{
    //    if (date == "07/03/2016" || date == "15/04/2016" || date == "21/05/2016" || date == "12/10/2016" || date == "13/12/2016")
    //    {
    //        txtToDt.Text = date;
    //        return true;
    //    }
    //    else
    //        return false;

    //}

    protected void btnAppSave_Click(object sender, EventArgs e)
    {
        btnAppSave.Enabled = false;
        //if (ddlLvType.SelectedValue == "12")
        //{
        //    if (!restricted(txtFromDt.Text))
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('invalid holiday date..')", true);
        //        txtFromDt.Enabled = txtToDt.Enabled = true;
        //        txtFromDt.Focus();
        //        return;
        //    }
        //}
        if (Add())
        {

            ObjHrBal = GetData();
            string Msg = ObjHrBll.EmplvAppInsert(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ClearLvApp();
            upd.Update();


            //LeaveBalance.show(Session["UserId"].ToString(), DateTime.Now.Year.ToString());
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "loaction.reload()", true);



    }

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearLvApp();
    }

    //protected void btnComSave_Click(object sender, EventArgs e)
    // {
    //     btnComSave.Enabled = false;
    //     ObjHrBal.Date = commonFunctions.GetDateTime(txtComDay.Text);
    //     ObjHrBal.InTime = txtComFTime.Text;
    //     ObjHrBal.OutTime = txtComTTime.Text;
    //     ObjHrBal.Description = txtDscrp.Text;
    //     ObjHrBal.SessionUserID = Session["UserId"].ToString();

    //     string[] action = ObjHrBll.Com_Btn_Select(ObjHrBal);
    //     ObjHrBal.KeyID = action[0].ToString();

    //     ObjHrBal.EmpId = Session["UserId"].ToString();
    //     ObjHrBal.TypeId = "0";
    //     DataTable dt = ObjHrBll.EmpComLvCrdCheck(ObjHrBal);
    //     if (dt.Rows[0][0].ToString() == "1")
    //     {
    //         ObjHrBll.EmpComLvCrdInsert(ObjHrBal);
    //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Data saved successfully.')", true);
    //         ClearComLv();
    //         FillComDetailGrid(ObjHrBal);
    //     }
    //     else
    //     {
    //         ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + dt.Rows[0][1].ToString() + "')", true);
    //         txtComDay.Focus();
    //     }
    //     btnComSave.Enabled = true;
    // }
    #endregion

    public HRBAL GetData()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.EmpId = Session["UserId"].ToString();
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
        ObjHrBal.ViewType = "1";
        ObjHrBal.ValueType = ddlDayType.SelectedValue;
        ObjHrBal.ChangeStatus = "-2";
        ObjHrBal.KeyValue = txtData.Text;
        ObjHrBal.Max = lblNod.Text;
        return ObjHrBal;
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
            if (trArrTxt.Visible == true)
            {
                string[] emp = txtArrWith.Text.Split(':');
                if (emp.Length > 1)
                {
                    if (emp[1].ToString() == Session["LoginId"].ToString())
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You can not arrange duty with yourself.')", true);
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
            else
            {
                foreach (GridViewRow itm in gvLvArr.Rows)
                {
                    TextBox txtarr = (TextBox)itm.FindControl("txtArrEmp");
                    TextBox txtRemark = (TextBox)itm.FindControl("txtArrRemark");
                    string[] emp = txtarr.Text.Split(':');
                    if (emp.Length > 1)
                    {
                        if (emp[1].ToString() == Session["LoginId"].ToString())
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You can not arrange duty with yourself.')", true);
                            return false;
                        }

                        XmlElement dataElement = xmlData.CreateElement("DATA");
                        ROOT.AppendChild(dataElement);
                        XmlElement element = xmlData.CreateElement("ARR_WITH");
                        element.InnerText = databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Usr_id, emp[1].ToString()));
                        dataElement.AppendChild(element);
                        element = xmlData.CreateElement("TT_DET_ID");
                        element.InnerText = gvLvArr.DataKeys[itm.RowIndex].Value.ToString();
                        dataElement.AppendChild(element);
                        element = xmlData.CreateElement("ARR_REMARK");
                        element.InnerText = txtRemark.Text;
                        dataElement.AppendChild(element);

                        txtData.Text = xmlData.OuterXml;
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter employee name & code.')", true);
                        return false;
                    }
                }
            }

        }
        return true;
    }

    protected void ddlLvType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlLvType.SelectedValue == "1")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Kindly Submit academic leave in hard copy.')", true);
        }
        else if (ddlLvType.SelectedValue == "11")
        {
            tdSLTime.Visible = tdSL.Visible = true;
            tdToDt.Visible = tdDt.Visible = tdDType.Visible = tdDay.Visible = false;
        }
        else if (ddlLvType.SelectedValue == "8")
        {
            tdSLTime.Visible = tdSL.Visible = false;
            tdToDt.Visible = tdDt.Visible = tdDType.Visible = tdDay.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Kindly Submit medical certificate to HR department for more than one day leave.')", true);
        }
        else
        {
            tdSLTime.Visible = tdSL.Visible = false;
            tdToDt.Visible = tdDt.Visible = tdDType.Visible = tdDay.Visible = true;
        }
    }

    protected void gvLvCancel_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txt = (TextBox)gvLvCancel.Rows[Convert.ToInt16(e.CommandArgument)].FindControl("txtCanRe");
        if (txt.Text != "")
        {
            ObjHrBal.KeyID = gvLvCancel.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            ObjHrBal.Description = txt.Text;
            Msg = ObjHrBll.EmpLvCancelApply(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter reason.')", true);
        }
        ObjHrBal.TypeId = "7";
        FillLvCancelGrid(ObjHrBal);
    }

    protected void ddlDayType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDayType.SelectedValue != "0")
        {
            if (txtFromDt.Text != txtToDt.Text)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Date should be same for half day')", true);
                txtFromDt.Focus();
            }
        }
    }
}

//Design part
//   function ComValidation() {
//            var flag = true;
//            var msg = "", ctrl = "";
//            if (!CheckDate("<%=txtComDay.ClientID%>")) {
//                if (!CheckControl("<%=txtComDay.ClientID%>")) {
//                    msg += " * Enter Working date. \n";
//                    if (ctrl == "")
//                        ctrl = "<%=txtComDay.ClientID%>";
//                    flag = false;
//                }
//                else {
//                    msg += " * Enter Correct Date.  \n";
//                    if (ctrl == "")
//                        ctrl = "<%=txtComDay.ClientID%>";
//                    flag = false;
//                }
//            }

//            if (!CheckControl("<%=txtComFTime.ClientID%>")) {
//                msg += " * Enter From time. \n";
//                if (ctrl == "")
//                    ctrl = "<%=txtComFTime.ClientID%>";
//                flag = false;
//            }

//            if (!CheckControl("<%=txtComTTime.ClientID%>")) {
//                msg += " * Enter To time. \n";
//                if (ctrl == "")
//                    ctrl = "<%=txtComTTime.ClientID%>";
//                flag = false;
//            }

//            if (!CheckControl("<%=txtDscrp.ClientID%>")) {
//                msg += " * Enter Description. \n";
//                if (ctrl == "")
//                    ctrl = "<%=txtDscrp.ClientID%>";
//                flag = false;
//            }
//            if (msg != "") alert(msg);
//            if (ctrl != "")
//                document.getElementById(ctrl).focus();
//            return flag;
//        }
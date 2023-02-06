using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
public partial class HR_rptEmpProfile : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages Msgfun;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataSet ds;
    DataTable tblAttendance = new DataTable("tblAttendance");
    DataColumn dcDay = new DataColumn("dcDay", Type.GetType("System.Int32"));
    DataColumn dcWeekDay = new DataColumn("dcWeekDay");
    DataColumn dcDutyTime = new DataColumn("dcDutyTime");
    DataColumn dcInTime = new DataColumn("dcInTime");
    DataColumn dcOutTime = new DataColumn("dcOutTime");
    DataColumn dcStatus = new DataColumn("dcStatus");
    DataColumn dcDate = new DataColumn("dcDate");
    DataColumn dcRemark = new DataColumn("dcRemark");
    DataRow newRow;
    DataTable dt;
    DataSet dsTr;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        Msgfun = new Messages();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
        ds = new DataSet();
        dt = new DataTable();
        dsTr = new DataSet();
        tblAttendance.Columns.Add(dcDay);
        tblAttendance.Columns.Add(dcWeekDay);
        tblAttendance.Columns.Add(dcDutyTime);
        tblAttendance.Columns.Add(dcInTime);
        tblAttendance.Columns.Add(dcOutTime);
        tblAttendance.Columns.Add(dcStatus);
        tblAttendance.Columns.Add(dcDate);
        tblAttendance.Columns.Add(dcRemark);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        MaintainScrollPositionOnPostBack = true;
        btnView.Attributes.Add("OnClick", "return Validation()");
        if (!IsPostBack)
        {
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            fillFunctions.Fill(ddlIns, ObjHrBll.GetInsList(ObjHrBal).Tables[0], true, FillFunctions.FirstItem.Select);
            for (int yy = DateTime.Today.Year; yy > DateTime.Today.Year - 5; yy--)
                ddlYear.Items.Add(yy.ToString());
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            fillFunctions.Fill(ddlLeaveType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.All);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            ObjHrBal.InsId = ddlIns.SelectedValue;
            fillFunctions.Fill(ddlDept, ObjHrBll.GetDeptList(ObjHrBal).Tables[0], true, FillFunctions.FirstItem.Select);
            ddlEmp.Items.Clear();
        }
        else
        {
            ddlDept.Items.Clear();
            ddlEmp.Items.Clear();
        }
        step1.Visible = false;
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
        {
            ObjHrBal.DeptId = ddlDept.SelectedValue;
            fillFunctions.Fill(ddlEmp, ObjHrBll.GetDepEmpList(ObjHrBal).Tables[0], true, FillFunctions.FirstItem.Select);
        }
        else
        {
            ddlEmp.Items.Clear();
        }
        step1.Visible = false;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjHrBal.Year = ddlYear.SelectedValue;
        ObjHrBal.EmpId = ddlEmp.SelectedValue;
        ObjHrBal.KeyID = ddlLeaveType.SelectedValue;
        ObjHrBal.ChangeStatus = ddlStatus.SelectedValue;
        ObjHrBal.Min = txtFromDT.Text;
        ObjHrBal.Max = txtToDT.Text;
        gvLvBalance.DataSource = ObjHrBll.GetLeaveBalance(ObjHrBal).Tables[0];
        gvLvBalance.DataBind();
        gvLvHistory.DataSource = ObjHrBll.getLvDetail(ObjHrBal).Tables[0];
        gvLvHistory.DataBind();
    }
    protected void btnView_Click1(object sender, EventArgs e)
    {
        step1.Visible = true;
        step1.ActiveTabIndex = 0;
        bindData(ddlEmp.SelectedValue);

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjHrBal.EmpId = ddlEmp.SelectedValue;
        ObjHrBal.EmpId = ObjHrBll.GetUserId(ObjHrBal);
        ShowMonthlyAttReport(ObjHrBal.EmpId);
    }
    private void ShowMonthlyAttReport(string UserId)
    {
        DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");

        ObjHrBal.KeyID = ddlMM.SelectedValue;
        ObjHrBal.Year = (ddlYY.SelectedValue == "") ? DateTime.Now.Year.ToString() : ddlYY.SelectedValue;
        ObjHrBal.EmpId = UserId;
        ObjHrBal.KeyValue = ddlAttType.SelectedValue;
        ds = ObjHrBll.GetEmpMonthAttendance(ObjHrBal);
        Session["ds"] = ds;
        tblAttendance.Clear();
        try
        {
            int mm = Convert.ToInt32(ObjHrBal.KeyID);
            int yy = Convert.ToInt32(ObjHrBal.Year);

            for (int i = 1; i <= DateTime.DaysInMonth(yy, mm); i++)
            {
                DateTime date = new DateTime(yy, mm, i);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    if ((DateTime.Compare(date, Convert.ToDateTime(ds.Tables[0].Rows[0][0])) == -1))
                        continue;
                    if ((DateTime.Compare(Convert.ToDateTime(ds.Tables[0].Rows[0][1]), date) == -1))
                        continue;
                }
                if (DateTime.Now < commonFunctions.GetDateTime(i.ToString() + "/" + ddlMM.SelectedValue + "/" + ddlYY.SelectedValue))
                    break;
                newRow = tblAttendance.NewRow();
                newRow["dcDay"] = i;
                newRow["dcWeekDay"] = date.DayOfWeek.ToString();
                newRow["dcDate"] = i.ToString() + "/" + ddlMM.SelectedValue + "/" + ddlYY.SelectedValue;
                newRow["dcInTime"] = newRow["dcOutTime"] = "-";
                if (ds.Tables[1].Rows.Count > 0)
                {
                    DataRow[] drAtt = ds.Tables[1].Select("DAYS=" + i.ToString());
                    if (drAtt.Length > 0)
                    {
                        newRow["dcDutyTime"] = drAtt[0]["SHIFT_VALUE"].ToString();
                        newRow["dcInTime"] = drAtt[0]["1"] != DBNull.Value ? drAtt[0]["1"].ToString() : "-";
                        newRow["dcOutTime"] = (drAtt[0]["3"] != DBNull.Value) ? drAtt[0]["3"].ToString() : (drAtt[0]["2"] != DBNull.Value) ? drAtt[0]["2"].ToString() : "-";
                        newRow["dcStatus"] = (drAtt[0]["ATT_TYPE_VALUE"] != DBNull.Value) ? drAtt[0]["ATT_TYPE_VALUE"].ToString() : "-";
                        newRow["dcRemark"] = drAtt[0]["ATT_MARK_REMARK"].ToString();
                    }
                }


                tblAttendance.Rows.Add(newRow);
            }
            DataView dv = tblAttendance.DefaultView;
            dv.Sort = "dcDay desc";
            gridAttendance.DataSource = dv;
            gridAttendance.DataBind();
        }
        catch
        {

        }
    }
    protected void gridAttendance_DataBound(object sender, EventArgs e)
    {
        try
        {
            int Check = 1;
            foreach (GridViewRow row in gridAttendance.Rows)
            {
                ds = (DataSet)Session["ds"];
                DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
                DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
                ObjHrBal.Date = commonFunctions.GetDateTime(gridAttendance.DataKeys[row.RowIndex].Value.ToString());
                ObjHrBal.TypeId = "1";
                dsTr = ObjHrBll.GetEmpDaliyAttTran(ObjHrBal);
                DataView dv1 = ds.Tables[2].DefaultView;
                dv1.RowFilter = "WDATE=" + row.Cells[0].Text;
                dt = dv1.ToTable();
                if (dt.Rows.Count == 0)
                {
                    if (dsTr.Tables[1].Rows.Count > 0)
                    {
                        if ((row.Cells[1].Text.ToLower() == dsTr.Tables[1].Rows[0][0].ToString()) || ((row.Cells[1].Text.ToLower() == dsTr.Tables[1].Rows[0][1].ToString()) && (Convert.ToInt32(row.Cells[0].Text) > 7 && Convert.ToInt32(row.Cells[0].Text) < 15)))
                        {
                            row.BackColor = System.Drawing.Color.LightPink;
                            Check = 0;
                        }
                    }
                    else
                    {
                        if ((row.Cells[1].Text.ToLower() == "sunday") || ((row.Cells[1].Text.ToLower() == "saturday") && (Convert.ToInt32(row.Cells[0].Text) > 7 && Convert.ToInt32(row.Cells[0].Text) < 15)))
                        {
                            row.BackColor = System.Drawing.Color.LightPink;
                            Check = 0;
                        }
                    }

                }
                //if (row.Cells[2].Text == "0")  // if Duty Off (As per Duty_roster)
                //    row.Cells[2].Text = "Off";              
                // Holiday
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataRow[] drHoliday = ds.Tables[3].Select("HDAY=" + row.Cells[0].Text);
                    if (drHoliday.Length > 0)
                    {
                        Check = 0;
                        row.BackColor = System.Drawing.Color.LightSalmon;
                        row.Cells[5].Text = drHoliday[0][2].ToString();
                    }
                }
                //// Compensatory
                if (ds.Tables[4].Rows.Count > 0)
                {
                    DataRow[] drCom = ds.Tables[4].Select("WORKDAY=" + row.Cells[0].Text);
                    if (drCom.Length > 0)
                    {
                        row.BackColor = System.Drawing.Color.Yellow;
                        row.Cells[5].Text = drCom[0][1].ToString();
                    }
                }

                // Leave Status
                if (dsTr.Tables.Count > 0)
                {
                    dt = dsTr.Tables[0];
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0][3].ToString() == "-2")
                        {
                            if (dt.Rows[0][2].ToString() == "Full day")
                            {

                                row.BackColor = System.Drawing.Color.Maroon;
                                row.Cells[5].Text = dt.Rows[0][0].ToString() + "(" + dt.Rows[0][1].ToString() + ")";
                            }
                            else if (dt.Rows[0][2].ToString() == "Second half")
                            {
                                row.Cells[4].BackColor = System.Drawing.Color.Maroon;
                                row.Cells[4].ForeColor = System.Drawing.Color.White;
                                row.Cells[4].Text = dt.Rows[0][0].ToString() + "(" + dt.Rows[0][1].ToString() + ")";

                            }
                            else if (dt.Rows[0][2].ToString() == "First half")
                            {
                                row.Cells[3].BackColor = System.Drawing.Color.Maroon;
                                row.Cells[3].ForeColor = System.Drawing.Color.White;
                                row.Cells[3].Text = dt.Rows[0][0].ToString() + "(" + dt.Rows[0][1].ToString() + ")";
                            }
                        }
                        else
                        {
                            if (dt.Rows[0][2].ToString() == "Full day")
                            {
                                Check = 0;
                                row.BackColor = System.Drawing.Color.LightGreen;
                                row.Cells[5].Text = dt.Rows[0][0].ToString() + "(" + dt.Rows[0][1].ToString() + ")";
                            }
                            else if (dt.Rows[0][2].ToString() == "Second half")
                            {
                                row.Cells[4].Text = dt.Rows[0][0].ToString() + "(" + dt.Rows[0][1].ToString() + ")";
                                row.Cells[4].BackColor = System.Drawing.Color.LightGreen;

                            }
                            else if (dt.Rows[0][2].ToString() == "First half")
                            {
                                row.Cells[3].BackColor = System.Drawing.Color.LightGreen;
                                row.Cells[3].Text = dt.Rows[0][0].ToString() + "(" + dt.Rows[0][1].ToString() + ")";
                            }
                        }
                    }

                }
                if (row.Cells[3].Text == "-" || row.Cells[4].Text == "-")
                {
                    if (Check != 0)
                    {
                        row.ForeColor = System.Drawing.Color.Red;
                        row.Font.Bold = true;
                    }
                    if (dsTr.Tables.Count > 2)
                        row.Cells[3].Text = (dsTr.Tables[2].Rows.Count > 0) ? dsTr.Tables[2].Rows[0][0].ToString() : row.Cells[3].Text;
                    if (dsTr.Tables.Count > 3)
                        row.Cells[4].Text = (dsTr.Tables[3].Rows.Count > 0) ? dsTr.Tables[3].Rows[0][0].ToString() : row.Cells[4].Text;
                }
                Check = 1;
            }

        }
        catch { }
    }

    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            bindData(ddlEmp.SelectedValue);
        }
        else if (step1.ActiveTabIndex == 1)
        {
            for (int yy = DateTime.Today.Year; yy > DateTime.Today.Year - 5; yy--)
                ddlYear.Items.Add(yy.ToString());
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            fillFunctions.Fill(ddlLeaveType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.All);
            gvLvBalance.DataSource = gvLvHistory.DataSource = "";
            gvLvBalance.DataBind();
            gvLvHistory.DataBind();
            txtFromDT.Text = txtToDT.Text = "";
            ddlStatus.SelectedIndex = 0;
        }
        else if (step1.ActiveTabIndex == 2)
        {
            gridAttendance.DataSource = "";
            gridAttendance.DataBind();
            fillFunctions.Fill(ddlAttType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AttType), true, FillFunctions.FirstItem.All);
        }
    }
    void bindData(string emp_id)
    {
        lblBldGroup.Text = lblCaste.Text = lblCode.Text = lblDept.Text = lblDes.Text = lblDob.Text = lblDOJ.Text = lblEmail.Text = lblfName.Text = lblIns.Text = "";
        lblMarSts.Text = lblMob.Text = lblMthrTongue.Text = lblName.Text = lblNationality.Text = lblNxtKin.Text = lblNxtSenior.Text = lblPhn.Text = lblPrmntAdd.Text = "";
        lblPrsntAdd.Text = lblRel.Text = lblSpsName.Text = lblStatus.Text = "";
        gvDocument.DataSource = gvExprience.DataSource = gvQualification.DataSource = "";
        gvDocument.DataBind();
        gvExprience.DataBind();
        gvQualification.DataBind();
        ObjHrBal.EmpId = emp_id;
        ds = ObjHrBll.GetEmpProfile(ObjHrBal);
        ViewState["ds"] = ds;
        string empImage = "../images/emp_images/" + emp_id + "_thumb.jpg";
        if (System.IO.File.Exists(Server.MapPath(empImage)))
            imgPicture.Src = empImage;
        else
            imgPicture.Src = "../images/emp_images/empImage.jpg";
        /*PERSONAL INFO*/
        DataRow dr;
        if (ds.Tables[0].Rows.Count != 0)
        {
            dr = ds.Tables[0].Rows[0];
            lblName.Text = dr["EMP_NAME"].ToString();
            lblfName.Text = dr["EMP_FTH_NAME"].ToString();
            lblMarSts.Text = dr["MAR_STS_VALUE"].ToString();
            lblSpsName.Text = dr["SPOUSE_NAME"].ToString();
            lblRel.Text = dr["REL_VALUE"].ToString();
            lblNxtKin.Text = dr["NEXT_KIN_NAME"].ToString();
            lblDob.Text = dr["DOB"].ToString();
            lblCaste.Text = dr["CAS_VALUE"].ToString();
            lblMthrTongue.Text = dr["MOT_TON_VALUE"].ToString();
            //lblBrthPlace.Text = dr[""].ToString();
            lblBldGroup.Text = dr["BLO_GRP_VALUE"].ToString();
            lblNationality.Text = dr["NAT_VALUE"].ToString();
            lblStatus.Text = dr["STS_VALUE"].ToString();
        }


        /*DEPARTMENTAL INFO*/
        if (ds.Tables[1].Rows.Count != 0)
        {
            dr = ds.Tables[1].Rows[0];
            lblCode.Text = dr["EMP_MUID"].ToString();
            lblDOJ.Text = dr["DOJ"].ToString();
            lblNxtSenior.Text = dr["NEXT_SENIOR"].ToString();
            lblDes.Text = dr["DES_VALUE"].ToString();
            lblDept.Text = dr["DEPT_VALUE"].ToString();
            lblIns.Text = dr["INS_VALUE"].ToString();
        }

        /*ADDRESS INFO*/

        if (ds.Tables[2].Rows.Count != 0)
        {
            dr = ds.Tables[2].Rows[0];
            lblPrsntAdd.Text = dr["Present_Add"].ToString();
            lblPrmntAdd.Text = dr["Permanent_Add"].ToString();
        }

        /*CONTACT INFO*/

        if (ds.Tables[3].Rows.Count != 0)
        {
            dr = ds.Tables[3].Rows[0];
            lblEmail.Text = dr["MAIL_OFFICIAL"].ToString();
            lblPerEmail.Text = dr["MAIL_PERSONAL"].ToString();
            lblMob.Text = dr["MOB"].ToString();
            lblPhn.Text = dr["ext"].ToString();
        }

        /*DOCUMENT INFO*/
        fillFunctions.Fill(gvDocument, ds.Tables[4]);
        foreach (GridViewRow row in gvDocument.Rows)
        {
            if (row.Cells[2].Text == "PENDING")
            {
                row.BackColor = Color.Red;
                row.ForeColor = Color.Black;
            }
        }


        /*QUALIFICATION INFO*/
        fillFunctions.Fill(gvQualification, ds.Tables[5]);

        /*EXPERIENCE INFO*/
        fillFunctions.Fill(gvExprience, ds.Tables[6]);

    }
    protected void TabContainer1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["ds"];
        if (step1.ActiveTabIndex == 0)
        {
            fillFunctions.Fill(gvDocument, ds.Tables[4]);
            foreach (GridViewRow row in gvDocument.Rows)
            {
                if (row.Cells[2].Text == "PENDING")
                {
                    row.BackColor = Color.Red;
                    row.ForeColor = Color.Black;
                }
            }

        }
        else if (step1.ActiveTabIndex == 1)
        {
            fillFunctions.Fill(gvQualification, ds.Tables[5]);
        }
        else if (step1.ActiveTabIndex == 2)
        {
            fillFunctions.Fill(gvExprience, ds.Tables[6]);
        }
    }

}
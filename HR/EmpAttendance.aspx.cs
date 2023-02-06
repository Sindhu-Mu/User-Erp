using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HR_EmpAttendance : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions databasefunction;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    USRBLL ObjUsrBll;
    DataRow newRow;
    DataTable dt;
    DataSet ds;
    DataSet dsTr;
    DataTable tblAttendance = new DataTable("tblAttendance");
    DataColumn dcDay = new DataColumn("dcDay", Type.GetType("System.Int32"));
    DataColumn dcWeekDay = new DataColumn("dcWeekDay");
    DataColumn dcDutyTime = new DataColumn("dcDutyTime");
    DataColumn dcInTime = new DataColumn("dcInTime");
    DataColumn dcOutTime = new DataColumn("dcOutTime");
    DataColumn dcStatus = new DataColumn("dcStatus");
    DataColumn dcDate = new DataColumn("dcDate");
    DataColumn dcRemark = new DataColumn("dcRemark");
    protected void Page_Prerender(object sender, EventArgs e)
    {
        ShowMonthlyAttReport(ViewState["UserId"].ToString());
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnShow.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            ViewState["UserId"] = Session["UserId"].ToString();
            FillFunction.Fill(ddlAttType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AttType), true, FillFunctions.FirstItem.All);
            ShowMonthlyAttReport(Session["UserId"].ToString());

        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        databasefunction = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ObjUsrBll = new USRBLL();
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
                if (DateTime.Now < CommonFunction.GetDateTime(i.ToString() + "/" + ddlMM.SelectedValue + "/" + ddlYY.SelectedValue))
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
           
            foreach (GridViewRow row in gridAttendance.Rows)
            {
             
             
                ds = (DataSet)Session["ds"];
                DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
                DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
                ObjHrBal.Date = CommonFunction.GetDateTime(gridAttendance.DataKeys[row.RowIndex].Value.ToString());
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
                         
                        }
                    }
                    else
                    {
                        if ((row.Cells[1].Text.ToLower() == "sunday") || ((row.Cells[1].Text.ToLower() == "saturday") && (Convert.ToInt32(row.Cells[0].Text) > 7 && Convert.ToInt32(row.Cells[0].Text) < 15)))
                        {
                            row.BackColor = System.Drawing.Color.LightPink;
                          
                        }
                    }

                }
              
                if (ds.Tables[3].Rows.Count > 0)
                {
                    DataRow[] drHoliday = ds.Tables[3].Select("HDAY=" + row.Cells[0].Text);
                    if (drHoliday.Length > 0)
                    {
                     
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
                  
                        row.ForeColor = System.Drawing.Color.Red;
                        row.Font.Bold = true;
                      
                    
                    if (dsTr.Tables.Count > 2)
                        row.Cells[3].Text = (dsTr.Tables[2].Rows.Count > 0) ? dsTr.Tables[2].Rows[0][0].ToString() : row.Cells[3].Text;
                    if (dsTr.Tables.Count > 3)
                        row.Cells[4].Text = (dsTr.Tables[3].Rows.Count > 0) ? dsTr.Tables[3].Rows[0][0].ToString() : row.Cells[4].Text;

                }
          
            }

        }
        catch { }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEmployee.Text != "")
            ViewState["UserId"] = ObjUsrBll.GetUserId(CommonFunction.GetKeyID(txtEmployee));
        else
            ViewState["UserId"] = Session["UserId"].ToString();

        ShowMonthlyAttReport(ViewState["UserId"].ToString());
    }
}
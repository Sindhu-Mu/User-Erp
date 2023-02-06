using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MREDKJ;
using System.Xml;
using System.Text;

public partial class Facility_HallBooking : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg,str2,strname;
    DataTable Dt;
    StringBuilder StrBldr;
    DateTime strdate;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validateType()");
        btnshow.Attributes.Add("OnClick", "return ValidateHall()");
        if (!IsPostBack)
        {
            tab1.ActiveTabIndex = 0;
            PushData();
            ViewState["Date"] = DateTime.Now;
            ViewState["ID"] = "";
            ViewState["dt"] = "";
            txtSdt.Visible = false;
            txtEdt.Visible = false;
            FillCancelBooking();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        Dt = new DataTable();
        StrBldr = new StringBuilder();
    }
    void PushData()
    {
        FillFunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HallCmplx), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(gvStore, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EvntItem));
        FillFunction.Fill(ddlEvnt, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Evnt), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlbComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HallCmplx), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlevent, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Evnt), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlsts, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.VehStatus), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlemp, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpByDept, Session["DeptID"].ToString()), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlBookedHall, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HallCmplx), true, FillFunctions.FirstItem.Select);
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ddlComplex.SelectedValue;
        ObjFacBal.AuthFor = ddlEvnt.SelectedValue;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        DateTime date=System.DateTime.Today;
        ObjFacBal.FromDate = CommonFunction.GetDateTime(txtFrmDt.Text);
        if (ObjFacBal.FromDate < date)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Requisition can’t be forwarded for back date.!!')", true);
            txtFrmDt.Focus();
        }
        else
        {
            ObjFacBal.ToDate = CommonFunction.GetDateTime(txttoDt.Text);
            ObjFacBal.Time = txtFrmTime.Text;
            ObjFacBal.ToTime = txtToTime.Text;
            ObjFacBal.No = txtNo.Text;
            string[] flag = ObjFacBll.BtnSelect(ObjFacBal);
            ObjFacBal.Forward_To = flag[0].ToString();
            ObjFacBal.Description = txtdetail.Text;
            ObjFacBal.Remark = txtRemark.Text;
            ObjFacBal.Name = txtname.Text;
            ObjFacBal.PhnNo = txtContact.Text;
            ObjFacBal.Address = txtAdd.Text;
            NumericTextBox txtCount;
            foreach (GridViewRow row in gvStore.Rows)
            {
                XmlDocument XmlData = new XmlDocument();
                XmlElement Root;
                if (txtData.Text != "")
                {
                    XmlData.LoadXml(txtData.Text);
                    Root = XmlData.DocumentElement;
                }
                else
                {
                    Root = XmlData.CreateElement("ADDTRAN");
                    XmlData.AppendChild(Root);
                }
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);
                XmlElement element = XmlData.CreateElement("ITEM_ID");
                element.InnerText = gvStore.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);

                txtCount = (NumericTextBox)row.FindControl("txtCount");
                string text = txtCount.Text;

                element = XmlData.CreateElement("QTY");
                element.InnerText = text;
                dataElement.AppendChild(element);

                txtData.Text = XmlData.OuterXml;

            }
            ObjFacBal.XmlValue = txtData.Text;
            ObjFacBal.Request = "";
            for (int i = 0; i < chFac.Items.Count; i++)
            {
                if (chFac.Items[i].Selected)
                {
                    if (ObjFacBal.Request == "")
                    {
                        ObjFacBal.Request = chFac.Items[i].Text;
                    }
                    else
                    {
                        ObjFacBal.Request = ObjFacBal.Request + "," + chFac.Items[i].Text;
                    }
                }
            }
            ObjFacBal.AdmReq = "";
            for (int i = 0; i < chSupport.Items.Count; i++)
            {
                if (chSupport.Items[i].Selected)
                {
                    if (ObjFacBal.AdmReq == "")
                    {
                        ObjFacBal.AdmReq = chSupport.Items[i].Text;
                    }
                    else
                    {
                        ObjFacBal.AdmReq = ObjFacBal.AdmReq + "," + chSupport.Items[i].Text;
                    }
                }
            }
        }
            Msg = ObjFacBll.HallBookingRequisition(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Hall Request Forwarded Successfully')", true);
        NewHallclear();
    }
    void NewHallclear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlComplex);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEvnt);
        txtname.Text = "";
        txtemail.Text = "";
        txtContact.Text = "";
        txtAdd.Text = "";
        txtFrmDt.Text = "";
        txttoDt.Text = "";
        txtNo.Text = "";
        txtdetail.Text = "";
        txtRemark.Text = "";
        NumericTextBox txtCount;
        foreach (GridViewRow row in gvStore.Rows)
        {
            txtCount = (NumericTextBox)row.FindControl("txtCount");
            txtCount.Text = "";
        }
    }
    void BookedClear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlbComplex);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddldt);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlevent);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlsts);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlemp);
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddldt":
                if (ddldt.SelectedValue == "3")
                {
                    txtSdt.Visible = true;
                    txtEdt.Visible = true;
                }
                else if (ddldt.SelectedValue == "1" || ddldt.SelectedValue == "2")
                {
                    txtSdt.Visible = true;
                    txtEdt.Visible = false;
                }
                else
                {
                    txtSdt.Visible = false;
                    txtEdt.Visible = false;
                }
                txtSdt.Text = txtEdt.Text = "";
                break;
            default:
                break;
        }
    }
    private void PrepareQuery()
    {
        StringBuilder Query = new StringBuilder("SELECT *, (CONVERT(VARCHAR,FAC_HALL_BOOKING_MASTER.HALL_FROM_DT,103) + '-' + CONVERT(VARCHAR,FAC_HALL_BOOKING_MASTER.HALL_TO_DT,103)) AS BOOKINGON");
        Query.Append(" FROM FAC_HALL_BOOKING_MASTER INNER JOIN "
                         + " EVENT_INF ON FAC_HALL_BOOKING_MASTER.HALL_BOOK_FOR = EVENT_INF.EVENT_ID INNER JOIN "
                         + " PROC_STS_TYPE_INF ON FAC_HALL_BOOKING_MASTER.HALL_BOOK_STATUS = PROC_STS_TYPE_INF.STS_ID INNER JOIN "
                         + " EMP_VIEW ON FAC_HALL_BOOKING_MASTER.HALL_BOOK_BY = EMP_VIEW.USR_ID INNER JOIN "
                         + " FAC_COMPLEX_INF ON FAC_HALL_BOOKING_MASTER.HALL_ID = FAC_COMPLEX_INF.FAC_CMPLX_ID");
        if (ddlbComplex.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_ID= '" + ddlbComplex.SelectedValue + "'");
        if (ddlevent.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_BOOK_FOR= '" + ddlevent.SelectedValue + "'");
        if (ddlsts.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_BOOK_STATUS= '" + ddlsts.SelectedValue + "'");
        if (ddlemp.SelectedIndex > 0)
            Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_BOOK_BY= '" + ddlemp.SelectedValue + "'");
        if (ddldt.SelectedIndex > 0)
        {
            switch (ddldt.SelectedValue)
            {
                case "1":
                    Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_FROM_DT < '" + CommonFunction.GetDateTime(txtSdt.Text) + "'");
                    break;
                case "2":
                    Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_FROM_DT < '" + CommonFunction.GetDateTime(txtSdt.Text) + "'");
                    break;
                case "3":
                    Query.Append(" AND FAC_HALL_BOOKING_MASTER.HALL_FROM_DT '" + CommonFunction.GetDateTime(txtSdt.Text) + "' and " + CommonFunction.GetDateTime(txtEdt.Text) + "'");
                    break;
            }
        }
        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(Query.ToString());
        command.CommandType = CommandType.Text;
        ds = DataBaseFunction.GetDataSet(command);
        gvBookingDetail.DataSource = ds;
        gvBookingDetail.DataBind();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        PrepareQuery();
    }
    void FillCancelBooking()
    {
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Dt = ObjFacBll.HallBokingCancel(ObjFacBal).Tables[0];
        ViewState["dt"] = Dt;
        gvCancelBooking.DataSource = Dt;
        gvCancelBooking.DataBind();
    }
    protected void gvCancelBooking_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txt = (TextBox)gvCancelBooking.Rows[Convert.ToInt16(e.CommandArgument)].FindControl("txtCancelRemark");
        if (txt.Text != "")
        {
            ObjFacBal.Remark = txt.Text;
            ObjFacBal.Id = gvCancelBooking.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.HallCancelApply(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter reason.')", true);
        }
        FillCancelBooking();
    }
    protected void btnshow_Click(object sender, EventArgs e)
    {
        ShowBooking();
    }
    private void ShowBooking()
    {

        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        SqlDataReader dr;
        int year = Convert.ToInt32(ddlYY.SelectedValue);
        int month = Convert.ToInt32(ddlMM.SelectedValue);
        int TotalDay = System.DateTime.DaysInMonth(year, month);


        str2 = "<table cellspacing=1 cellpadding=0 border=1  bordercolor=Black bgcolor='White'  style=font-family:Verdana;font-size:10pt; ><tr class=heading style=background-color:#336666>";
        str2 += "<th style=color:White>DATE</th><th style=color:White>DAY</th><th style=color:White>EVENT DETAIL</th></tr>";
        for (int n = 0; n < TotalDay; )
        {
            strname = "&nbsp;";
            n++;
            strdate = Convert.ToDateTime(n + "-" + ddlMM.SelectedItem + "-" + year);
            ObjFacBal.Date = strdate;
            dr = ObjFacBll.GetHolidays(ObjFacBal);
            if (dr.HasRows)
            {
                dr.Read();
                str2 += "<tr style=background-color:#FF8080 title='" + dr["HOLIDAY_NAME"].ToString() + "'>";
            }
            else if (strdate.DayOfWeek == DayOfWeek.Sunday)
                str2 += "<tr style=background-color:#FFFF80 title='Sunday'>";
            else if (strdate.DayOfWeek == DayOfWeek.Saturday && strdate.Day > 7 && strdate.Day < 15)
                str2 += "<tr style=background-color:#FFFF80 title='Second Saturday'>";
            else
                str2 += "<tr>";
            ObjFacBal.FromDate = strdate;
            ObjFacBal.No = ddlMM.SelectedValue;
            ObjFacBal.RateDay = ddlYY.SelectedValue;
            ObjFacBal.TypeId = ddlBookedHall.SelectedValue;
            DataSet ds = ObjFacBll.GetHallSts(ObjFacBal);
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strname += dt.Rows[i]["DEPT_VALUE"].ToString() + "TIME:-" + dt.Rows[i]["BOOKINGON"].ToString() + "(" + dt.Rows[i]["STS_VALUE"].ToString() + ")<br/>";
            }
            str2 += "<td >" + strdate.ToString("dd-MMM-yyyy") + "</td><td>" + strdate.DayOfWeek.ToString() + "</td><td><b>" + strname + "</b></td></tr>";
        }

        str2 += "</table>";
        StrBldr.Append(str2);
        tdMain.InnerHtml = StrBldr.ToString();
    }
}

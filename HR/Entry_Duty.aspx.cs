using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class HR_Entry_Duty : System.Web.UI.Page
{
    FillFunctions fillfunctions;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    //DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;

    DataTable myTable = new DataTable("myTable");
    DataColumn Sno = new DataColumn("Sno", Type.GetType("System.String"));
    DataColumn Emp_code = new DataColumn("Emp_code", Type.GetType("System.String"));
    DataColumn Emp_NAME = new DataColumn("Emp_NAME", Type.GetType("System.String"));
    DataColumn SHIFT_ID = new DataColumn("SHIFT_ID", Type.GetType("System.String"));
    DataColumn Duty_Date = new DataColumn("Duty_Date", Type.GetType("System.String"));
    DataColumn DEPT_ID = new DataColumn("DEPT_ID", Type.GetType("System.String"));
    DataRow NewRow;
    DateTime dtFrom, dtTo;
    SqlDataReader dr, dr1;
    DataSet ds;
    string str, strdate, strid, strshift;
    int d;
   
    void Initialize()
    {
        fillfunctions = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        myTable.Columns.Add(Sno); myTable.Columns.Add(Emp_NAME);
        myTable.Columns.Add(Emp_code); myTable.Columns.Add(SHIFT_ID);
        myTable.Columns.Add(Duty_Date);
        myTable.Columns.Add(DEPT_ID);
        Initialize();
        if (!IsPostBack)
        {

            ddlOffDay.Items.Add("Select");
            ddlOffDay.Items.Add("Monday");
            ddlOffDay.Items.Add("Tuesday");
            ddlOffDay.Items.Add("Wednesday");
            ddlOffDay.Items.Add("Thursday");
            ddlOffDay.Items.Add("Friday");
            ddlOffDay.Items.Add("Saturday");
            ddlOffDay.Items.Add("Sunday");

            strid = Request.QueryString[0].ToString().Split(';').GetValue(0).ToString();
            strdate = Request.QueryString[0].ToString().Split(';').GetValue(1).ToString();
            strshift = Request.QueryString[0].ToString().Split(';').GetValue(2).ToString();
            ViewState["Dept"] = Request.QueryString[0].ToString().Split(';').GetValue(3).ToString();
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            ObjHrBAL.DeptId = ViewState["Dept"].ToString(); 
            fillfunctions.Fill(ddlShift, ObjHrBll.getDeptShift(ObjHrBAL).Tables[0], true, FillFunctions.FirstItem.Select);
            ddlShift.SelectedValue = strshift;
            if (strshift == "0")
                ddlOffDay.Visible = false;
            if (strid != "0")
            {
                
                fillfunctions.FillList(lstBox1, ObjHrBll.getDeptEmpList(ObjHrBAL).Tables[0]);
                txtToDate.Text = txtFromDate.Text = strdate;
                trmain.Visible = btnSubmit.Visible = true;
                btnEvent_Add.Visible = false;
            }
            else
            {
                btnSubmit.Visible = false;
                trmain.Visible = false;
                txtToDate.Text = txtFromDate.Text = strdate;
            }
            btnSubmit.Enabled = false;
            show();
        }
    }

    void show()
    {
        ObjHrBAL.Date = common.GetDateTime(txtFromDate.Text);
        ObjHrBAL.ToDate = common.GetDateTime(txtToDate.Text);
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBAL.KeyID = Request.QueryString[0].ToString().Split(';').GetValue(2).ToString();
        ObjHrBAL.DeptId = ViewState["Dept"].ToString(); 
        ds = ObjHrBll.getDutyRoster(ObjHrBAL);
        ViewState["myTable"] = (DataTable)ds.Tables[0];
        ViewState["ds"] = ds;
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Bind();
    }

    void Bind()
    {
        myTable = (DataTable)ViewState["myTable"];
        int a = 0;
        foreach (GridViewRow itm in GridView1.Rows)
        {
            a++;
            itm.Cells[0].Text = a.ToString();
            d = itm.RowIndex;
            ObjHrBAL.KeyID = myTable.Rows[d]["SHIFT_ID"].ToString();
            dr = ObjHrBll.getShiftValue(ObjHrBAL);
            if (dr.HasRows)
            {
                dr.Read();
                itm.Cells[3].Text = dr[0].ToString();
            }
            else
                itm.Cells[3].Text = "Duty off";
        }
    }

    protected void Imgadd_Click(object sender, ImageClickEventArgs e)
    {
        DatabaseFunctions databaseFunctions = new DatabaseFunctions();
        int masg = 0;
        if (GridView1.Rows.Count > 0)
            myTable = (DataTable)ViewState["myTable"];
        for (int i = 0; i < lstBox1.Items.Count; i++)
        {
            dtFrom = common.GetDateTime(txtFromDate.Text);
            dtTo = common.GetDateTime(txtToDate.Text);
            if (dtFrom < System.DateTime.Now)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('From Date should be greater than current date')", true);
                return;
            }
            TimeSpan t2 = dtTo - dtFrom;
            int no = t2.Days;
            if (lstBox1.Items[i].Selected)
            {
                for (int c = 0; c < myTable.Rows.Count; c++)
                {
                    NewRow = myTable.Rows[c];
                    if (((Convert.ToDateTime(NewRow["DUTY_DATE"]) >= dtFrom) && (Convert.ToDateTime(NewRow["DUTY_DATE"]) <= dtTo)) && (NewRow["EMP_CODE"].ToString() == lstBox1.Items[i].Value))
                        masg = 1;
                }
                for (int j = 0; j <= no; j++)
                {
                    ObjHrBAL.EmpId = lstBox1.Items[i].Value;
                    str = "SELECT * FROM DEPT_DUTY_ROST_INF WHERE DUTY_DATE='" + dtFrom.ToString("dd/MM/yyyy") + "' AND USR_ID=" + ObjHrBll.GetUserId(ObjHrBAL);
                    dr1 = databaseFunctions.GetReaderByQuery(str);
                    if ((dr1.HasRows) || (masg == 1))
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This employee is already add for this date.')", true);
                        masg = 0;
                        return;
                    }
                    NewRow = myTable.NewRow();
                    NewRow["Emp_code"] = lstBox1.Items[i].Value;
                    NewRow["Emp_NAME"] = lstBox1.Items[i].Text;
                    NewRow["SHIFT_ID"] = ddlShift.SelectedValue;
                    NewRow["Duty_Date"] = dtFrom;
                    myTable.Rows.Add(NewRow);
                    dtFrom = dtFrom.AddDays(1);
                }
            }
            masg = 0;
        }
        ViewState["myTable"] = myTable;
        GridView1.DataSource = myTable;
        GridView1.DataBind();
        Bind();
        btnSubmit.Enabled = true;
    }

    protected void btnEvent_Add_Click(object sender, EventArgs e)
    {
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBAL.Max = (common.GetDateTime(txtFromDate.Text).Month).ToString();
        ObjHrBAL.DeptId = ViewState["Dept"].ToString(); 
        fillfunctions.FillList(lstBox1, ObjHrBll.getDeptEmpList(ObjHrBAL).Tables[0]);
        trmain.Visible = true;
        btnSubmit.Visible = true;
        btnSubmit.Enabled = false;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string m_dutyoff = "";
        if (ddlOffDay.SelectedValue != "Select")
            m_dutyoff = ddlOffDay.SelectedValue;
        myTable = (DataTable)ViewState["myTable"];
        dtFrom = common.GetDateTime(txtFromDate.Text);
        ObjHrBAL.KeyID = ViewState["Dept"].ToString();
        ObjHrBAL.Max = dtFrom.Month.ToString();
        int id = Convert.ToInt32(ObjHrBll.DutyMainInsert(ObjHrBAL).Tables[0].Rows[0]["DUTY_ID"].ToString());
        for (int i = 0; i < myTable.Rows.Count; i++)
        {
            Insert(i, id);
        }
        ViewState.Clear();
        Session["DUTY_ID"] = id.ToString();
        string strScript = "alert(\'Information is successfully submited\');window.opener.location.reload();window.close();";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", strScript, true);
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ViewState.Clear();
        string strScript = "window.opener.location.reload();window.close();";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", strScript, true);
    }

    void Insert(int i, int id)
    {
        string m_dutyoff = "";
        if (ddlOffDay.SelectedValue != "Select")
            m_dutyoff = ddlOffDay.SelectedValue;
        DateTime m_duty_date = Convert.ToDateTime(myTable.Rows[i]["Duty_Date"]);
        string m_shift = "";
        if (m_duty_date.DayOfWeek.ToString().ToUpper() == m_dutyoff.ToUpper())
            m_shift = "0";
        else
            m_shift = myTable.Rows[i]["SHIFT_ID"].ToString();
        myTable = (DataTable)ViewState["myTable"];
        ObjHrBAL.KeyID = id.ToString();
        ObjHrBAL.EmpId = myTable.Rows[i]["Emp_code"].ToString();
        ObjHrBAL.Date = common.GetDateTime(m_duty_date.ToString("dd/MM/yyyy"));
        ObjHrBAL.KeyValue = m_shift;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBll.DutyRosterInsert(ObjHrBAL);
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        myTable = (DataTable)ViewState["myTable"];
        ds = (DataSet)ViewState["ds"];
        d = e.RowIndex;
        DateTime m_duty_date = Convert.ToDateTime(myTable.Rows[d]["Duty_Date"]);
        if ((myTable.Rows.Count > ds.Tables[0].Rows.Count) && (e.RowIndex > (ds.Tables[0].Rows.Count - 1)))
            myTable.Rows.RemoveAt(e.RowIndex);
        else
        {
            ObjHrBAL.EmpId = myTable.Rows[d]["USR_ID"].ToString();
            ObjHrBAL.Date = common.GetDateTime(m_duty_date.ToString("dd/MM/yyyy"));
            ObjHrBAL.KeyValue = myTable.Rows[d]["SHIFT_ID"].ToString();
            ObjHrBll.DutyRosterUpdate(ObjHrBAL);
            //str = "SELECT * FROM DUTY_ROSTER WHERE CONVERT(DATETIME,DUTY_DATE,103)=CONVERT(DATETIME,'" + Convert.ToDateTime(myTable.Rows[d]["Duty_Date"]).ToString("dd/MM/yyyy") + "',103) AND EMP_CODE=" + myTable.Rows[d]["EMP_CODE"].ToString() + " AND SHIFT=" + myTable.Rows[d]["SHIFT"].ToString() + " AND STATUS=1";
            //dr = objGenFun.dtrBindData(str);
            //if (dr.HasRows)
            //    str = "DELETE  FROM DUTY_ROSTER WHERE CONVERT(DATETIME,DUTY_DATE,103)=CONVERT(DATETIME,'" + Convert.ToDateTime(myTable.Rows[d]["Duty_Date"]).ToString("dd/MM/yyyy") + "',103) AND EMP_CODE=" + myTable.Rows[d]["EMP_CODE"].ToString() + " AND SHIFT=" + myTable.Rows[d]["SHIFT"].ToString() + " AND STATUS=1";
            //else
            //    str = "UPDATE  DUTY_ROSTER SET STATUS='0' WHERE CONVERT(DATETIME,DUTY_DATE,103)=CONVERT(DATETIME,'" + Convert.ToDateTime(myTable.Rows[d]["Duty_Date"]).ToString("dd/MM/yyyy") + "',103) AND EMP_CODE=" + myTable.Rows[d]["EMP_CODE"].ToString() + " AND SHIFT=" + myTable.Rows[d]["SHIFT"].ToString() + " AND STATUS =2";
            //objGenFun.execute_non_query(str);
        }
        show();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('One record deleted Successfully')", true);
        if (myTable.Rows.Count == 0)
        {
            string strScript = "window.opener.location.reload();window.close();";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", strScript, true);
        }
    }
    
    protected void ddlShift_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObjHrBAL.Date = common.GetDateTime(txtFromDate.Text);
        ObjHrBAL.ToDate = common.GetDateTime(txtToDate.Text);
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBAL.KeyID = ddlShift.SelectedValue;
        ObjHrBAL.DeptId = ViewState["Dept"].ToString(); 
        ds = ObjHrBll.getDutyRoster(ObjHrBAL);
        ViewState["myTable"] = ds.Tables[0];
        ViewState["ds"] = ds;
        GridView1.DataSource = ds;
        GridView1.DataBind();
        Bind();
    }

    

}

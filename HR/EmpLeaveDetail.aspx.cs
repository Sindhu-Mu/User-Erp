using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_EmpLeaveDetail : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    DatabaseFunctions databaseFunctions;
    HRBAL ObjHrBAL;
    HRBLL ObjHrBll;
    DataSet ds, ds1;
    DataTable dt1;
    DataTable dt;
    string str;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
        dt1 = new DataTable();
        ds = new DataSet();
        ds1 = new DataSet();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validateView()");
        //btnSave.Attributes.Add("OnClick", "return validate()");
        //txtCredit.Attributes.Add("onkeypress", "OnlyDigitWithDecimal()");
        if (!IsPostBack)
        {
            trNew.Visible = btnPrint.Enabled = false;
            for (int yy = (DateTime.Today.Year); yy > DateTime.Today.Year - 7; yy--)
                ddlYear.Items.Add(yy.ToString());
            ViewState["dt"] = "";
            ViewState["Type"] = 0;
            ViewState["dt1"] = "";
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            PushData();
        }
    }
    private void PushData()
    {
        fillFunctions.Fill(ddlLeaveType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlLvType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.Select);
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        trNew.Visible = true;
        ViewState["Type"] = 1;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBAL = GetData();
        str = ObjHrBll.LeaveBalanceInsert(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + str + "')", true);
        Balance(ObjHrBAL);
        Clear();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjHrBAL = GetData();
        trNew.Visible = false;
        GridShow.Columns[10].Visible = (ddlStatus.SelectedIndex > 1) ? false : true;
        btnPrint.Enabled = true;
        GridShow.Columns[12].Visible = GridShow.Columns[11].Visible = btnNew.Visible = (ddlYear.SelectedValue ==DateTime.Now.Year.ToString()) ? true : true;
        Balance(ObjHrBAL);
        Main();
    }

    public HRBAL GetData()
    {
        ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        ObjHrBAL.Year = ddlYear.SelectedValue;
        ObjHrBAL.Code = ddlLvType.SelectedValue;
        ObjHrBAL.Total = txtCredit.Text;
        if (txtDate.Text != "")
            ObjHrBAL.Date = commonFunctions.GetDateTime(txtDate.Text);
        ObjHrBAL.InBy = Session["UserId"].ToString();
        ObjHrBAL.Description = txtRemark.Text;
        ObjHrBAL.TypeId = ViewState["Type"].ToString();
        return ObjHrBAL;
    }
    public void Clear()
    {
        txtCredit.Text = txtRemark.Text = txtDate.Text = "";
        ddlLvType.SelectedIndex = 0;
        trNew.Visible = false;
    }

    private void Balance(HRBAL ObjHrBAL)
    {
        ds = ObjHrBll.GetLeaveBalance(ObjHrBAL);
        ViewState["dt"] = ds.Tables[0];
        gvBalance.DataSource = ds.Tables[0];
        gvBalance.DataBind();
    }

    private void Main()
    {
        ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        ObjHrBAL.Year = ddlYear.SelectedValue;
        ObjHrBAL.ChangeStatus = ddlStatus.SelectedValue;
        ObjHrBAL.KeyID = ddlLeaveType.SelectedValue;
        ObjHrBAL.Min = txtFromDT.Text;
        ObjHrBAL.Max = txtToDT.Text;
        GridShow.DataSource = ObjHrBll.getLvDetail(ObjHrBAL);
        GridShow.DataBind();
        Session["ds"] = ds;

    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        //Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtEmpLvDetail.aspx?name=" + commonFunctions.GetKeyID(txtEmployee) + "&year=" + ddlYear.SelectedItem + "',alwaysraised='yes')", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
        ViewState["Type"] = 0;
    }

    protected void gvBalance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ddlLvType.SelectedValue = gvBalance.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            ViewState["Type"] = 0;
            trNew.Visible = true;
        }
        if (e.CommandName == "Tran")
        {
            ModalPopupExtender1.Show();
            ObjHrBAL = GetData();
            ObjHrBAL.Code = gvBalance.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            gvCredit.DataSource = ObjHrBll.GetLvBalTran(ObjHrBAL);
            gvCredit.DataBind();
            //objfill.FillGridView(gvCredit, "SELECT CH_BL, CH_DT, CH_REMARK FROM LEAVE_BL_TRAN  WHERE CH_IN=" + ViewState["ecode"].ToString() + " AND CH_CODE='" + gvBalance.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "' AND CH_YEAR='" + ddlYear.SelectedValue + "' ORDER BY CH_DT");
        }
    }

    protected void GridShow_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridShow.EditIndex = -1;
        Main();
    }
    protected void GridShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjHrBAL.KeyID = GridShow.DataKeys[Convert.ToInt16(e.RowIndex)].Value.ToString();
        str = ObjHrBll.LeaveBalanceDelete(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + str + "')", true);
        Main();
    }

    protected void GridShow_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridShow.EditIndex = e.NewEditIndex;
        Main();
    }
    protected void GridShow_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ObjHrBAL.KeyID = GridShow.DataKeys[Convert.ToInt16(e.RowIndex)].Value.ToString();
        TextBox txtFrom = (TextBox)GridShow.Rows[e.RowIndex].Cells[4].FindControl("txtFrom");
        TextBox txtTo = (TextBox)GridShow.Rows[e.RowIndex].Cells[4].FindControl("txtTo");
        ObjHrBAL.FromDate = commonFunctions.GetDateTime(txtFrom.Text);
        ObjHrBAL.ToDate = commonFunctions.GetDateTime(txtTo.Text);
        str = ObjHrBll.LeaveAppUpdate(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + str + "')", true);
        Main();
        ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        ObjHrBAL.Year = ddlYear.SelectedItem.ToString();
        GridShow.EditIndex = -1;
        Balance(ObjHrBAL);
    }
    protected void ddlLvType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ViewState["Type"].ToString() == "1")
        {
            dt = (DataTable)ViewState["dt"];
            DataRow[] drLv = dt.Select("LV_ID='" + ddlLvType.SelectedValue + "'");
            if (drLv.Length > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This is already in Leave Balance!!')", true);
                ddlLvType.SelectedIndex = 0;
                ddlLvType.Focus();
                return;
            }
        }
    }

    protected void GridShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[13].ToolTip = "Edit";
            e.Row.Cells[14].ToolTip = "Delete";
            if (e.Row.RowState == DataControlRowState.Edit)
            {
                int i = 0;
                foreach (TableCell cell in e.Row.Cells)
                {
                    if (e.Row.Cells.GetCellIndex(cell) == 13)
                    {
                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[13].Controls[0])).ToolTip = "Update";

                        ((System.Web.UI.WebControls.ImageButton)(e.Row.Cells[13].Controls[2])).ToolTip = "Cancel";
                    }
                    i++;
                }
            }
        }
    }


    protected void gvBalance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[8].ToolTip = "Edit";
            e.Row.Cells[9].ToolTip = "Credit";

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_EmpLvArrAccept : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;
    string Msg;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnSave.Attributes.Add("onclick", "return validate()");
        if (!IsPostBack)
        {
            ViewState["app_id"] = "";
            ViewState["arr_id"] = "";
            FillGrid();
        }

    }

    void FillGrid()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjHrBll.EmpLvArrSelect(ObjHrBal);
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["arr_id"] = gvShow.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[1].ToString();
        if (e.CommandName == "TT")
        {
            ObjHrBal.HeadID = ViewState["arr_id"].ToString();
            gvDetail.DataSource = ObjHrBll.TTatLvDate(ObjHrBal);
            gvDetail.DataBind();
            ModalPopupExtender1.Show();
        }
        else
        {
            tdSave.Visible = true;
            ViewState["app_id"] = gvShow.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnSave.Enabled = false;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.Description = txtRemark.Text;
        ObjHrBal.ChangeStatus = ddlAction.SelectedValue;
        ObjHrBal.KeyID = ViewState["app_id"].ToString();
        ObjHrBal.HeadID = ViewState["arr_id"].ToString();
        Msg = ObjHrBll.EmpLvArrAction(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        FillGrid();
        tdSave.Visible = false;
        txtRemark.Text = "";
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlAction);
        btnSave.Enabled = true;
    }
    protected void btnApp_Click(object sender, EventArgs e)
    {
        btnApp.BackColor = System.Drawing.Color.Transparent;
        btnApp.ForeColor = System.Drawing.Color.Black;
        btnReport.BackColor = System.Drawing.Color.Green;
        btnReport.ForeColor = System.Drawing.Color.White;
        td1.Visible = false;
        tdSave.Visible = false;
        gvShow.Columns[6].Visible = true;
        FillGrid();
    }
    protected void btnReport_Click(object sender, EventArgs e)
    {
        btnReport.BackColor = System.Drawing.Color.Transparent;
        btnReport.ForeColor = System.Drawing.Color.Black;
        btnApp.BackColor = System.Drawing.Color.Green;
        btnApp.ForeColor = System.Drawing.Color.White;
        for (int yy = DateTime.Today.Year; yy > DateTime.Today.Year - 5; yy--)
            ddlYear.Items.Add(yy.ToString());
        fillFunctions.Fill(ddlName, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Emp_ByArr, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_byArr, Session["UserId"].ToString()), true, FillFunctions.FirstItem.All);
        td1.Visible = true;
        tdSave.Visible = false;
        ObjHrBal = GetData();
        if ((txtFromDT.Text == "") || (txtToDT.Text == ""))
        {
            ObjHrBal.KeyID = "0";
        }
        dt= ObjHrBll.EmpLvArrReportSelect(ObjHrBal);
        gvShow.DataSource = dt;
        gvShow.DataBind();
        gvShow.Columns[6].Visible=false;
        gvShow.Columns[9].Visible = false;
    }

    public HRBAL GetData()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.Year = ddlYear.SelectedItem.Text;
        if(ddlName.SelectedIndex>0)
            ObjHrBal.Name = ddlName.SelectedValue;
        if(ddlDept.SelectedIndex>0)
            ObjHrBal.DeptId = ddlDept.SelectedValue;
        if ((txtFromDT.Text != "") && (txtToDT.Text != ""))
        {
            ObjHrBal.FromDate = commonFunctions.GetDateTime(txtFromDT.Text);
            ObjHrBal.ToDate = commonFunctions.GetDateTime(txtToDT.Text);
        }
        
        return ObjHrBal;
    }
   
}
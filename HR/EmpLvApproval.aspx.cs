using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_EmpLvApproval : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    DatabaseFunctions databaseFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataSet ds;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        //btnApproved.Attributes.Add("onclick", "return validate()");
        //btnRecommend.Attributes.Add("onclick", "return validate()");
        btnReject.Attributes.Add("onclick", "return validate()");

        if (!IsPostBack)
        {
            ViewState["lv_app_id"] = "";
            ViewState["req_id"] = "";
            ViewState["action_by"] = "";
            ViewState["forword_to"] = "";
            ViewState["Value_type"] = "";
            if (Request.QueryString.Count > 0)
            {
                FillShowGrid(Request.QueryString[0]);
            }
            //if (gvShow.Rows.Count == 0)
            //    FillShowGrid("5");
            //if (gvShow.Rows.Count == 0)
            //    FillShowGrid("7");
        }
    }

    public void FillShowGrid(string Value_type)
    {
        ViewState["Value_type"] = Value_type;
        ObjHrBal.ValueType = Value_type;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ds = ObjHrBll.EmpLvApprvlSelect(ObjHrBal);
        gvShow.DataSource = ds.Tables[0];
        gvShow.DataBind();
    }

    public HRBAL GetData()
    {
        ObjHrBal.HeadID = ViewState["lv_app_id"].ToString();
        ObjHrBal.KeyID = ViewState["req_id"].ToString();
        ObjHrBal.InBy = ViewState["action_by"].ToString();
        ObjHrBal.EmpId = ViewState["forword_to"].ToString();
        ObjHrBal.TypeId = ViewState["Value_type"].ToString();
        ObjHrBal.Description = txtRemarks.Text;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        return ObjHrBal;
    }

  
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Action(Convert.ToInt16(e.CommandArgument));
    }

    #region Button Click
    protected void btnArrange_Click(object sender, EventArgs e)
    {
        trArrange.Visible = true;
        trPrvLv.Visible = false;
        trDeptLv.Visible = false;
    }
    protected void btnLeaveDetail_Click(object sender, EventArgs e)
    {
        trArrange.Visible = false;
        trPrvLv.Visible = true;
        trDeptLv.Visible = false;
    }
    protected void btnDeptLeave_Click(object sender, EventArgs e)
    {
        trArrange.Visible = false;
        trPrvLv.Visible = false;
        trDeptLv.Visible = true;
    }

    protected void btnApproved_Click(object sender, EventArgs e)
    {
        btnApproved.Enabled = false;
        ObjHrBal = GetData();
        if(ViewState["Value_type"].ToString()=="7")
            ObjHrBal.ChangeStatus = "4";
        else
            ObjHrBal.ChangeStatus = "2";
        ObjHrBll.EmpLvArvCan(ObjHrBal);
        lblApproved.Text = "Leave approved successfully.";
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Leave approved successfully.')", true);
        Clear(ViewState["Value_type"].ToString());
        btnApproved.Enabled = true;
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        btnReject.Enabled = false;
        ObjHrBal = GetData();
        ObjHrBal.ChangeStatus = "0";
        ObjHrBll.EmpLvArvCan(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Leave rejected successfully.')", true);
        Clear(ViewState["Value_type"].ToString());
        btnReject.Enabled = true;
    }
    protected void btnRecommend_Click(object sender, EventArgs e)
    {
        btnRecommend.Enabled = false;
        ObjHrBal = GetData();
        ObjHrBll.EmpLvRecommend(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Leave forwarded successfully.')", true);
        Clear(ViewState["Value_type"].ToString());
        btnRecommend.Enabled = true;
    }
    protected void btnLeave_Click(object sender, EventArgs e)
    {
        FillShowGrid("1");
        tbApp.Visible = false;
        div2.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        FillShowGrid("7");
        tbApp.Visible = false;
        div2.Visible = false;
    }

    protected void btnOnDuty_Click(object sender, EventArgs e)
    {
        FillShowGrid("5");
        tbApp.Visible = false;
        div2.Visible = false;
    }
    #endregion

    void Clear(string Value_type)
    {
        FillShowGrid(Value_type);
        int row_index = (gvShow.Rows.Count > 0) ? 0 : 1;
        if (row_index == 0)
            Action(row_index);
        else
            tbApp.Visible = false;
        trArrange.Visible = false;
        trPrvLv.Visible = false;
        trDeptLv.Visible = false;
    }

    protected void gvArrange_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBal.HeadID = gvShow.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        gvDetail.DataSource = ObjHrBll.TTatLvDate(ObjHrBal);
        gvDetail.DataBind();
        ModalPopupExtender1.Show();
    }

    void Action(int row_index)
    {
        ViewState["lv_app_id"] = gvShow.DataKeys[row_index].Values[0].ToString();
        ViewState["req_id"] = gvShow.DataKeys[row_index].Values[1].ToString();
        ViewState["action_by"] = gvShow.DataKeys[row_index].Values[2].ToString();
        ObjHrBal.HeadID = ViewState["lv_app_id"].ToString();
        ObjHrBal.EmpId = gvShow.Rows[row_index].Cells[1].Text;
        ObjHrBal.TypeId = gvShow.DataKeys[row_index].Values[2].ToString();
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        ObjHrBal.Total = gvShow.DataKeys[row_index].Values[4].ToString();
        lblEmployee.Text = ObjHrBal.EmpId;

        tbApp.Visible = true;

        if (ViewState["Value_type"].ToString() == "7")
        {
            btnApproved.Visible = true;
            btnRecommend.Visible = false;
        }
        else
        {
            if (ViewState["Value_type"].ToString() == "1")
            {
                ds = ObjHrBll.EmpLvApprvlDetailSelect(ObjHrBal);

                gvArrange.DataSource = ds.Tables[0];
                gvArrange.DataBind();
                gvPrvLv.DataSource = ds.Tables[1];
                gvPrvLv.DataBind();
                gvDeptLv.DataSource = ds.Tables[2];
                gvDeptLv.DataBind();

                div2.Visible = true;
                trArrange.Visible = false;
                trPrvLv.Visible = false;
                trDeptLv.Visible = false;
            }

            string[] flag = ObjHrBll.BtnSelect(ObjHrBal);

            if (flag[0] == "1")
            {
                btnApproved.Visible = true;
                btnRecommend.Visible = false;
            }
            else
            {
                btnApproved.Visible = false;
                btnRecommend.Visible = true;
                ViewState["forword_to"] = flag[1];
            }
            lblApproved.Text = "";
        }
    }
}
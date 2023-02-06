using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_LeaveRearrangement : System.Web.UI.Page
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
        btnSubmit.Attributes.Add("OnClick", "return validation()");
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
        gvShow.DataSource = ObjHrBll.EmpLvArrRejected(ObjHrBal);
        gvShow.DataBind();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        tdetail.Visible = true;
        ViewState["app_id"] = gvShow.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        ViewState["arr_id"] = gvShow.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[1].ToString();
        ObjHrBal.KeyID = ViewState["app_id"].ToString();
        ObjHrBal.HeadID = ViewState["arr_id"].ToString();
        gvDetail.DataSource = ObjHrBll.EmpLvReArrSelect(ObjHrBal);
        gvDetail.DataBind();
        gvTT.DataSource = ObjHrBll.TTatLvDate(ObjHrBal);
        gvTT.DataBind();
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        ObjHrBal.HeadID = ViewState["arr_id"].ToString();
        ObjHrBal.EmpId = commonFunctions.GetKeyID(txtEmp);
        ObjHrBal.Description = txtRemark.Text;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.EmpLvReArrInsert(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        Clear();
    }

    void Clear()
    {
        txtEmp.Text = txtRemark.Text = "";
        tdetail.Visible = false;
        ViewState["app_id"] = "";
        ViewState["arr_id"] = "";
        FillGrid();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_ComCreditApproval : System.Web.UI.Page
{

    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataTable dt;
    string Msg;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        btnApproved.Attributes.Add("OnClick", "return validation()");
        btnReject.Attributes.Add("OnClick", "return validation()");
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            FillGrid();
        }
    }

    void FillGrid()
    {
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        dt = ObjHrBll.ComCreditForApprove(ObjHrBal);
        ViewState["dt"] = dt;
        gvCom.DataSource = dt;
        gvCom.DataBind();

    }
    protected void gvCom_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvCom.DataKeys[Convert.ToInt16(e.CommandArgument)].Value.ToString();
        ObjHrBal.EmpId = gvCom.Rows[Convert.ToInt16(e.CommandArgument)].Cells[1].Text;
        ObjHrBal.Date = commonFunctions.GetDateTime(gvCom.Rows[Convert.ToInt32(e.CommandArgument)].Cells[3].Text);
        ViewState["NOD"] = gvCom.Rows[Convert.ToInt16(e.CommandArgument)].Cells[8].Text;
        dt = ObjHrBll.AttForCom(ObjHrBal);
        gvAtt.DataSource = dt;
        gvAtt.DataBind();
        tdAtt.Visible = tdAction.Visible = true;
    }
    HRBAL GetData()
    {
        ObjHrBal.KeyID = ViewState["ID"].ToString();
        ObjHrBal.Description = txtRemark.Text;
        ObjHrBal.TypeId = ViewState["NOD"].ToString();
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        return ObjHrBal;
    }
    protected void btnApproved_Click(object sender, EventArgs e)
    {
        ObjHrBal = GetData();
        ObjHrBal.ChangeStatus = "2";
        Msg = ObjHrBll.ComLvCrdApproved(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        Clear();
    }
       
    protected void btnReject_Click(object sender, EventArgs e)
    {
        ObjHrBal = GetData();
        ObjHrBal.ChangeStatus = "0";
        Msg = ObjHrBll.ComLvCrdApproved(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        Clear();
    }

    void Clear()
    {
        FillGrid();
        txtRemark.Text = "";
        tdAtt.Visible = tdAction.Visible = false;
    }
}
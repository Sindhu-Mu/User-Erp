using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_ComCrApproval : System.Web.UI.Page
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
            ViewState["ACTION_TO"] = "";
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
        Action(Convert.ToInt16(e.CommandArgument));       
    }

    void Action(int RowIndex)
    {
        int index = RowIndex;
        ViewState["ID"] = gvCom.DataKeys[index].Value.ToString();
        ObjHrBal.EmpId = gvCom.Rows[index].Cells[1].Text;
        ObjHrBal.Date = commonFunctions.GetDateTime(gvCom.Rows[index].Cells[3].Text);
        ViewState["NOD"] = gvCom.Rows[index].Cells[8].Text;
        dt = ObjHrBll.AttForCom(ObjHrBal);
        gvAtt.DataSource = dt;
        gvAtt.DataBind();
        tdAtt.Visible = tdAction.Visible = true;
        ObjHrBal.SessionUserID = ObjHrBll.GetUserId(ObjHrBal);
        ObjHrBal.EmpId = Session["UserId"].ToString();
        string[] action = ObjHrBll.Com_Btn_Select(ObjHrBal);
        ObjHrBal.Code = action[1].ToString();

        if (ObjHrBal.Code == "0")
        {
            btnApproved.Visible = false;
            btnReccomend.Visible = true;
            if (action[0].ToString() == "2")
            {
                ViewState["ACTION_TO"] = "2";
            }
            if (action[0].ToString() == "3")
            {
                ViewState["ACTION_TO"] = "3";
            }
        }
        if (ObjHrBal.Code == "1")
        {
            btnApproved.Visible = true;
            btnReccomend.Visible = false;
        }
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
        btnApproved.Enabled = false;
        ObjHrBal = GetData();
        ObjHrBal.ChangeStatus = "2";
        ObjHrBal.Code = "0";
        Msg = ObjHrBll.ComLvCrdApproved(ObjHrBal);
        lblMsg.Text = Msg;
        lblMsg.Visible = true;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        Clear();
        btnApproved.Enabled = true;
        
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        btnReject.Enabled = false;
        ObjHrBal = GetData();
        ObjHrBal.ChangeStatus = "0";
        ObjHrBal.Code = "0";
        Msg = ObjHrBll.ComLvCrdApproved(ObjHrBal);
        lblMsg.Text = Msg;
        lblMsg.Visible = true;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        Clear();
        btnReject.Enabled = true;
    }

    void Clear()
    {
        FillGrid();
        int row_index=(gvCom.Rows.Count > 0) ? 0 : 1;
        if (row_index == 0)
            Action(row_index);
        
        //tdAtt.Visible = tdAction.Visible = false;
    }

    protected void btnReccomend_Click(object sender, EventArgs e)
    {
        btnReccomend.Enabled = false;
        ObjHrBal = GetData();
        ObjHrBal.ChangeStatus = "1";
        ObjHrBal.Code = ViewState["ACTION_TO"].ToString();
        Msg = ObjHrBll.ComLvCrdApproved(ObjHrBal);
        lblMsg.Text = Msg;
        lblMsg.Visible = true;
        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        Clear();
        btnReccomend.Enabled = true;
        
    }
}
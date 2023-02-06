using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class HR_EmpBlockMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataSet ds;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnShow.Attributes.Add("onClick", "return validat()");
        btnSave.Attributes.Add("onClick", "return validation()");
        step1.ActiveTabIndex = 0;
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlBlockType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.BlockType), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ViewState["Id"] = commonFunctions.GetKeyID(txtEmpName);
        Employee1.ShowEmployeeInfo(ViewState["Id"].ToString());
        ObjHrBal.EmpId = ViewState["Id"].ToString();
        gvDetail.DataSource =ObjHrBll.getBlockEmployeeDetail(ObjHrBal).Tables[0];
        gvDetail.DataBind();
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.EmpId = ViewState["Id"].ToString();
        ObjHrBal.TypeId = ddlBlockType.SelectedValue;
        ObjHrBal.FromDate = commonFunctions.GetDateTime(txtFrmDt.Text);
        ObjHrBal.RemValue = txtRemark.Text;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        Msg =  ObjHrBll.EmpBolck(ObjHrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }
    void clear()
    {
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlBlockType);
        txtEmpName.Text = "";
        txtFrmDt.Text = "";
        txtRemark.Text = "";
        Employee1.ShowEmployeeInfo("0");
    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        if (step1.ActiveTabIndex == 0)
        {
            clear();

            gvDetail.DataSource = "";
            gvDetail.DataBind();
        }
        else if (step1.ActiveTabIndex == 1)
        {
            gvBlock.DataSource = ObjHrBll.GetBlockEmployees(ObjHrBal);
            gvBlock.DataBind();
        }
    }
}
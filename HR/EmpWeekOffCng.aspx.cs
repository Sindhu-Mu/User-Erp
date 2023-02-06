using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_EmpWeekOffCng : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjHrBAL;
    HRBLL ObjHrBll;
    DataTable dt;
    string Msg;
    DataSet ds;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjHrBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
        ds = new DataSet();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnView.Attributes.Add("OnClick", "return validation()");
        btnSave.Attributes.Add("OnClick", "return validat()");
        if (!IsPostBack)
        {
            ViewState["dt"] = "";
            FillGrid();
        }
    }

    void FillGrid()
    {
        if (txtEmp.Text != "")
        {
            ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmp);
        }
        else
        {
            ObjHrBAL.EmpId="";
        }
        ViewState["dt"]=ds = ObjHrBll.EmpWeekOffSelect(ObjHrBAL);
        gvReport.DataSource = ds.Tables[1];
        gvReport.DataBind();
        gvShow.DataSource = ds.Tables[0];
        gvShow.DataBind();
        
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Employee.ShowEmployeeInfo(commonFunctions.GetKeyID(txtEmp));
        FillGrid();
        ddlOffType.SelectedIndex = ddlWeekDay.SelectedIndex = 0;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {      

        ObjHrBAL.EmpId = commonFunctions.GetKeyID(txtEmp);
        ObjHrBAL.KeyValue = ddlWeekDay.SelectedValue;
        ObjHrBAL.TypeId = ddlOffType.SelectedValue;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        ObjHrBAL.FromDate = commonFunctions.GetDateTime(txtFromDate.Text);
        Msg = ObjHrBll.EmpWeekOffInsert(ObjHrBAL);
        ViewState["ID"] = "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        commonFunctions.Clear(this);
        FillGrid();
        ddlOffType.SelectedIndex = ddlWeekDay.SelectedIndex = 0;
        txtFromDate.Text = "";

    }
   
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBAL.KeyID = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.EmpWeekOffDisable(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
        commonFunctions.Clear(this);
    }
   
}
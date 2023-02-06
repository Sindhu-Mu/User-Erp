using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_ResignationMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjAcaBAL;
    HRBLL ObjHrBll;
    DataTable dt;
    string Msg;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjAcaBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        btnShow.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            bindGrid();
            fillFunctions.Fill(ddlReason, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Releived_Type), true, FillFunctions.FirstItem.Select);

        }
    }
    void bindGrid()
    {
        if (txtEmployee.Text != "")
        {
            ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        }
        else
            ObjAcaBAL.EmpId = "";
        gvResig.DataSource = ObjHrBll.getRlvdEmp(ObjAcaBAL).Tables[0];
        gvResig.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBAL.ChangeStatus = ddlReason.SelectedValue;
        ObjAcaBAL.ToDate = commonFunctions.GetDateTime(txtResigDate.Text);
        ObjAcaBAL.FromDate = commonFunctions.GetDateTime(txtRelDate.Text);
        ObjAcaBAL.RemValue = txtRemark.Text;
        ObjAcaBAL.EmpId = commonFunctions.GetKeyID(txtEmployee);
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg=ObjHrBll.EmpRlvdInsert(ObjAcaBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
        bindGrid();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
   
        Employee.ShowEmployeeInfo( commonFunctions.GetKeyID(txtEmployee));
        bindGrid();
    }
    protected void gvResig_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvResig.EditIndex = -1;
        bindGrid();
    }
    protected void gvResig_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvResig.EditIndex = e.NewEditIndex;
        bindGrid();
    }
    protected void gvResig_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox txtRdate = new TextBox();

        txtRdate = (TextBox)gvResig.Rows[e.RowIndex].FindControl("txtRDate");
        ObjAcaBAL.KeyID= gvResig.DataKeys[e.RowIndex].Value.ToString();
        ObjAcaBAL.ToDate = commonFunctions.GetDateTime(txtRdate.Text);
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.EmpRlvdUpdate(ObjAcaBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        gvResig.EditIndex = -1;
        bindGrid();
    }

    void clear()
    {
        txtEmployee.Text = txtRelDate.Text = txtRemark.Text = txtResigDate.Text = "";
        ddlReason.SelectedIndex = 0;
        Employee.ShowEmployeeInfo("-1");
    }
}
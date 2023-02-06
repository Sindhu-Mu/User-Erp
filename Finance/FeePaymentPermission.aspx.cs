using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_FeePaymentPermission : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryFunctions;
    SFBLL ObjBll;
    SFDAL ObjDal;
    SFBAL ObjBal;

   
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            btnShow.Attributes.Add("OnClick", "return validation1()");
            btnInsert.Attributes.Add("OnClick", "return validation()");
            fillfunction.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlGroupHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GroupHeadId), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void initialise()
    {
        fillfunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        ObjBll = new SFBLL();
        ObjDal = new SFDAL();
        ObjBal = new SFBAL();
    }
    void clear()
    {
        gvData.DataSource = "";
        gvData.DataBind();
        ddlBranch.SelectedIndex = ddlGroupHead.SelectedIndex = ddlHead.SelectedIndex = ddlSem.SelectedIndex = ddlType.SelectedIndex = 0;
        txtAmount.Text = txtApproveBy.Text = txtDepositDate.Text = txtEnrollment.Text = txtRemark.Text = txtValue.Text = "";
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnrollment.Text);
        ddlBranch.Items.Clear();
        if (ddlBranch.Items.Count == 0)
        {
            fillfunction.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.StuBranch, txtEnrollment.Text), true, FillFunctions.FirstItem.Select);
            ddlBranch.SelectedIndex = 1;
        }
            ObjBal.balEnrollment = txtEnrollment.Text;
            ObjBal.balBranchId = ddlBranch.SelectedValue;
            ObjBal.balSem = ddlSem.SelectedValue;
            DataSet ds = ObjBll.StudentPermissionHeadSelect(ObjBal);
            gvData.DataSource = ds.Tables[0];
            ViewState["Demand_Id"] = ds.Tables[1].Rows[0][0].ToString();
            gvData.DataBind();
            ViewState["ds"] = ds;
            
        }
    
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        ObjBal.balSession = Session["UserId"].ToString();
        ObjBal.balDate = txtDepositDate.Text;
        ObjBal.balReason = txtRemark.Text;
        ObjBal.balEmpName = Session["UserId"].ToString();
        ObjBal.balDemandId = ViewState["Demand_Id"].ToString();
        ObjBal.balAmount = txtAmount.Text;
        ObjBal.balHeadType = ddlHead.SelectedValue;
       string Msg= ObjBll.StudentPermissionHeadInsert(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }
    protected void ddlGroupHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillfunction.Fill(ddlHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FineHeads, ddlGroupHead.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlType.SelectedValue)> 0)
        {
            DataTable temp_dt = new DataTable();
            temp_dt = ((DataSet)ViewState["ds"]).Tables[0];
            DataRow dr = (temp_dt.Select("FEE_MAIN_HEAD_ID=" + ddlHead.SelectedValue))[0];
            txtAmount.Text = ((Convert.ToDecimal(txtValue.Text) / 100) * Convert.ToDecimal(dr["FD_FEE_AMT"].ToString())).ToString();
         }
        else
        {
           
            txtAmount.Text = txtValue.Text;
            
        }

        ddlType.SelectedIndex = 0;
    }
    
   
}
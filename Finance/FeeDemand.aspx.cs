using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    double Total;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        if (!IsPostBack)
        {
            pageload(); 
        }
       
        
    }
    protected void pageload()
    {
        glb_ff.Fill(ddlInstitue, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlBatch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlFeeStruc, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FeeFineRule), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlFineRule, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FeeFineRule), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlProcess, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FeeProcess), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlSemester, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);

    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    void clear()
    {
        ddlInstitue.SelectedIndex = ddlBranch.SelectedIndex = ddlBatch.SelectedIndex = ddlCourse.SelectedIndex = ddlSemester.SelectedIndex = ddlProcess.SelectedIndex = ddlFineRule.SelectedIndex = ddlFeeTemp.SelectedIndex = ddlFeeStruc.SelectedIndex=0;
        txtRemark.Text = "";
        txtEnrol.Text = "";
        gridStruc.DataSource = "";
        gridStruc.DataBind();
    }
    protected void ddlInstitue_SelectedIndexChanged(object sender, EventArgs e)
    {
        glb_ff.Fill(ddlCourse, glb_qf.GetCommand(QueryFunctions.QueryBaseType.CourseName,ddlInstitue.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        glb_ff.Fill(ddlBranch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Branch,ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        if (ddlBatch.SelectedIndex > 0)
        {
            glb_ff.Fill(ddlFeeStruc, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FeeStructure,ddlCourse.SelectedValue,ddlBatch.SelectedValue),false, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlFeeStruc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFeeStruc.SelectedIndex > 0)
        {
            glb_ff.Fill(ddlFeeTemp, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FeeTemplate, ddlFeeStruc.SelectedValue), false, FillFunctions.FirstItem.Select);

            if (ddlSemester.SelectedIndex > 0 && ddlCourse.SelectedIndex > 0 && ddlBatch.SelectedIndex > 0)
                gridStruc.DataSource = bllObj.FeeStrcforSelect(ddlCourse.SelectedValue, ddlBatch.SelectedValue, ddlSemester.SelectedValue, ddladmType.SelectedValue);
            else
                gridStruc.DataSource = "";
            gridStruc.DataBind();
            foreach (GridViewRow itm in gridStruc.Rows)
            {
                Total += Convert.ToDouble(itm.Cells[4].Text);
            }
            if (gridStruc.Rows.Count > 0)
                gridStruc.FooterRow.Cells[4].Text = Total.ToString("N2");
        }
       
    }
    protected void btnDemand_Click(object sender, EventArgs e)
    {
        string Errormsg = "";
        if (txtEnrol.Text != "")
            Errormsg = bllObj.FeeDemandInsert(ddlCourse.SelectedValue, ddlBranch.SelectedValue, ddlBatch.SelectedValue, ddlSemester.SelectedValue, ddladmType.SelectedValue, ddlProcess.SelectedValue, ddlFineRule.SelectedValue, ddlFeeStruc.SelectedValue, ddlFeeTemp.SelectedValue, txtRemark.Text, Session["UserId"].ToString(), Rlist.SelectedValue, txtEnrol.Text);
        else
            Errormsg = bllObj.FeeDemandInsert(ddlCourse.SelectedValue, ddlBranch.SelectedValue, ddlBatch.SelectedValue, ddlSemester.SelectedValue, ddladmType.SelectedValue, ddlProcess.SelectedValue, ddlFineRule.SelectedValue, ddlFeeStruc.SelectedValue, ddlFeeTemp.SelectedValue, txtRemark.Text, Session["UserId"].ToString(), Rlist.SelectedValue);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Errormsg + "')", true);

    }
 
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        clear();
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Academic_MinorAdmitCardPrint : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onclick", "return validation()");
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.Select);
        }
    }
    private void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        ds = new DataSet();
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlProgram, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProgram.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlProgram.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtAdmitCard.aspx')", true);
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        ObjBal.InsId = ddlInstitute.SelectedValue;
        ObjBal.Pgm_Id = ddlProgram.SelectedValue;
        ObjBal.Brn_Id = ddlBranch.SelectedValue;
        ObjBal.Semid = ddlSem.SelectedValue;
        ObjBal.balENROLL_TO = txtEnrollTo.Text;
        ObjBal.balENROLL_FROM = txtEnrollFrom.Text;
        ObjBal.balSTATUS = ddlStatus.SelectedValue;  
        ds = ObjBll.StuAdmitCardInfoSelect(ObjBal);
        Session["dt"] = ds.Tables[0];
        gvAdmitCard.DataSource = ds.Tables[0];
        gvAdmitCard.DataBind();
    }
    protected void btnPrintTopSheet_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMinorTopSheet.aspx')", true);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
public partial class Academic_StuMonthlyActivityLetter : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnView.Attributes.Add("OnClick", "return validation()");
        btnPrint.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            FillFunction.FillInteger(10, 100, 5, FillFunctions.FirstItem.Select, ddlCount);
            FillFunction.Fill(ddlSection, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            FillFunction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlPgm.Items.Clear();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjBal.InsId = ddlIns.SelectedValue;
        ObjBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjBal.KeyID = ddlBatch.SelectedValue;
        ObjBal.Semid = ddlSem.SelectedValue;
        ObjBal.Id = ddlCount.SelectedValue;
        ObjBal.CommonId = ddlPrntType.SelectedValue;
        ObjBal.Brn_Id = ddlBrn.SelectedValue;
        ObjBal.Sec_Id = ddlSection.SelectedValue;
        ObjBal.Enroll_No =txtEnroll.Text!=""? CommonFunction.GetKeyID(txtEnroll):txtEnroll.Text;
        if (ddlDoc.SelectedValue == "0")
        {
            gvDetail.DataSource = ObjBll.getStuMonthlyReport(ObjBal).Tables[0];
            gvDetail.DataBind();
        }
        else if (ddlDoc.SelectedValue == "1")
        {
            DataSet ds = ObjBll.getRegStudent(ObjBal);
            gvDetail.DataSource = ds;
                
            gvDetail.DataBind();
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        StringBuilder url = new StringBuilder("");
        if (ddlDoc.SelectedValue == "0")
        {
            //url.Append("prtStuSemReport.aspx?");
            url.Append("prtStuMonthlyReport.aspx?");
        }
        else if (ddlDoc.SelectedValue == "1")
        {
            url.Append("prtRegSlip.aspx?");
        }
        url.Append("INS_ID=" + ddlIns.SelectedValue);
        url.Append("&COURSE_ID=" + ddlPgm.SelectedValue);
        url.Append("&BATCH_NAME=" + ddlBatch.SelectedValue);
        url.Append("&CURR_SEMISTAR_NO=" + ddlSem.SelectedValue);
        url.Append("&COUNT=" + ddlCount.SelectedValue);
        url.Append("&IS_LAST=" + ddlPrntType.SelectedValue);
        url.Append("&BRN_ID=" + ddlBrn.SelectedValue);
        url.Append("&SEC_ID=" + ddlSection.SelectedValue);
        ObjBal.Enroll_No = txtEnroll.Text != "" ? CommonFunction.GetKeyID(txtEnroll) : txtEnroll.Text;
        url.Append("&ENROLL=" + ObjBal.Enroll_No);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('" + url.ToString() + "','_blank','resizable=1,width=900,height=650')", true);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlBrn, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
            ddlBrn.Focus();
        }
        else
            ddlBrn.Items.Clear();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Appraisal_PA03_Approval : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        DataRow dr = ObjBll.getReviewPeriod(ObjBal).Tables[0].Rows[0];
        lblRFrom.Text = dr[0].ToString();
        lblRTo.Text = dr[1].ToString();

        if (!IsPostBack)
        {
            btnSave.Enabled = false;
            ifram.Visible = false;
            bindData();
        }
    }
    void bindData()
    {
        ObjBal.SessionUserId = Session["UserId"].ToString();
        gvReportInfo.DataSource = ObjBll.GetApprovalList(ObjBal).Tables[0];
        gvReportInfo.DataBind();
    }

    protected void gvReportInfo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        gvReportInfo.SelectedIndex = index;
        ifram.Attributes["src"] = "PA03.aspx?id=" + gvReportInfo.DataKeys[index].Value.ToString();
        ifram.Visible = true;
        btnSave.Enabled = true;
        txtComments.Enabled = true;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //pA03_Dean.SaveComments(Convert.ToInt32(gridReportInfo.DataKeys[gridReportInfo.SelectedIndex].Value.ToString()), txtComments.Text);
        //AlertMessages.DisplayMessage(this, "Your comment on the self appraisal of the faulty submitted successfully");
        ObjBal.Id = gvReportInfo.DataKeys[gvReportInfo.SelectedIndex].Value.ToString();
        ObjBal.SessionUserId = Session["UserId"].ToString();
        ObjBal.Comment = txtComments.Text;
        string msg = ObjBll.ApproveAppraisal(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        txtComments.Text = "";
        btnSave.Enabled = false;
        txtComments.Enabled = ifram.Visible = false;
        bindData();
    }
}
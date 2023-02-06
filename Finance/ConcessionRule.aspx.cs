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
    Messages alertMsg;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        
        if (!IsPostBack)
        {
            getConcRule();
            glb_ff.Fill(ddlQuota, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Quota), true, FillFunctions.FirstItem.Select);
            glb_ff.Fill(ddlRelation, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
            glb_ff.Fill(ddlSession, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
        }
       
        
    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        alertMsg = new Messages();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        balObj.balHeadName = txtRuleName.Text;
        balObj.balData = txtDescription.Text;
        balObj.balSession = ddlSession.SelectedValue;
        balObj.balQuota = ddlQuota.SelectedValue;
        balObj.balRelation = cf.checkIndex(ddlRelation.SelectedValue);
        balObj.balPercentage = txtPercentage.Text;
        balObj.balAmt = txtMaxAmt.Text;
        balObj.balCurUser = Session["UserId"].ToString();
        try
        {
            bllObj.InsertConcRule(balObj);
        }
        catch
        {
            alertMsg.GetMessage(Messages.DataMessType.Insert);
        }

    }
   
    protected void getConcRule()
    {
        DataSet ds = bllObj.getConcRule(balObj);
        gridShow.DataSource = ds.Tables[0];
        gridShow.DataBind();

    }
  
    
    protected void gridShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="ACTIVATE")
        {
            balObj.balStatus = "1";
        }
        else
        {
            balObj.balStatus = "0";
        }
        balObj.balRuleId = e.CommandArgument.ToString();
        bllObj.UpdateConcRuleStatus(balObj);
    }
}
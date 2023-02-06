
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
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        fillGrid();
        if (!IsPostBack)
        {
            fill();
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
    }

    void fill()
    {
        glb_ff.Fill(ddlHead, glb_qf.GetCommand(QueryFunctions.QueryBaseType.HeadId), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlQuota, glb_qf.GetCommand(QueryFunctions.QueryBaseType.QuotaStu), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlSession, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
    }
    void fillGrid()
    {
       // glb_ff.Fill(ddlSession, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
        dt=bllObj.FeeConcessionCriteria(balObj);
        gridShow.DataSource = dt;
        gridShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
           
            balObj.balMainHeadId=ddlHead.SelectedValue;
            balObj.balQuota = ddlQuota.SelectedValue; 
            balObj.balConcPer=nTxtPer.Text;
            balObj.balConcMax=nTxtMax.Text;
            balObj.balSession=ddlSession.SelectedValue;
            balObj.balCurUser = Session["UserId"].ToString();
            bllObj.FeeConcessionCriteriaInsert(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Concession Criteria inserted successfully.')", true);
        }
        catch
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Concession Criteria existed for this head, quota and session.')", true);
        }
        fillGrid();
        Clear();
    }
    void Clear()
    {
        ddlHead.SelectedIndex = ddlQuota.SelectedIndex = ddlSession.SelectedIndex = 0;
        nTxtMax.Text = nTxtPer.Text = "";
    }
    protected void gridShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        balObj.balConcId= gridShow.DataKeys[e.RowIndex].Value.ToString();
        bllObj.FeeConcessionCriteriaDelete(balObj);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Concession Criteria deleted successfully.')", true);
        fillGrid();
        Clear();
    }
    
    
    
       

}
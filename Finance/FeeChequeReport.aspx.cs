using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
        Initialize();
        
        if (!IsPostBack)
        {
         
           fillfunction.Fill(ddlMode,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Mode),true,FillFunctions.FirstItem.Select);
            
        }
       
        
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }







    protected void btnShow_Click(object sender, EventArgs e)
    {

        balObj.balChequeNo = txtChequeNo.Text;
        balObj.balEnrol = txtEnRoll.Text;
        balObj.balStatus = ddlStatus.SelectedValue;
        balObj.balMode = ddlMode.SelectedValue;
        balObj.balDateTo = txtDateTo.Text;
        balObj.balDateFrom = txtDateFrom.Text;
        if (balObj.balEnrol=="")
        {
            balObj.balEnrol = "0";
        }
        if(balObj.balChequeNo=="")
        {
            balObj.balChequeNo = "0";
        
        }
        if (balObj.balStatus == "")
        {
            balObj.balStatus = "0";

        }
        if (balObj.balMode == ".")
        {
            balObj.balMode = "0";

        }
        if (balObj.balDateTo == "")
        {
            balObj.balDateTo = "0";

        }
        if (balObj.balDateFrom == "")
        {
            balObj.balDateFrom = "0";

        }
       dt = bllObj.StuFinGetCheckStatus(balObj);
       gvShow.DataSource = dt;
       gvShow.DataBind();
       

    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        balObj.balChequeNo = gvShow.Rows[Convert.ToInt16(e.CommandArgument)].Cells[4].Text;
        GridViewRow gvRow = gvShow.Rows[Convert.ToInt16(e.CommandArgument)];
        TextBox tb = (TextBox)gvRow.FindControl("txtDate");
        balObj.balDate = tb.Text;
        bllObj.ClearingDateUpdate(balObj);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Clearance Date Added Successfully..!')", true);   
    }
   
}
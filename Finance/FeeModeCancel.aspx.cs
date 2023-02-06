using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DatabaseFunctions df;
   
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        btnShow.Attributes.Add("OnClick", "return validate()");
        btnOk.Attributes.Add("OnClick", "return valid()");
        if (!IsPostBack)
        {
            glb_ff.Fill(ddlReason, glb_qf.GetCommand(QueryFunctions.QueryBaseType.PaymentCancelReason), true, FillFunctions.FirstItem.Select);
            glb_ff.Fill(ddlMode, glb_qf.GetCommand(QueryFunctions.QueryBaseType.PayMode), true, FillFunctions.FirstItem.Select);
            trReason.Visible = false;
        }
       
        
    }
    void bindGrid()
    {
        StringBuilder query = new StringBuilder();
        query.AppendFormat("SELECT DISTINCT rm.RCV_TRAN_MODE_ID,rm.FEE_RCV_RECEIPT_NO, StuView.ENROLLMENT_NO, pm.PAY_MODE_VALUE, rm.RCV_TRAN_MODE_AMT"
                        + " FROM STU_FIN_FEE_DEMAND_MAIN_INF dm INNER JOIN STU_FIN_FEE_RCV_INF r ON dm.FEE_DEMAND_ID = r.FEE_DEMAND_ID INNER JOIN "
                        + "STU_FIN_FEE_RCV_TRAN_INF rt ON r.FEE_RCV_ID = rt.FEE_RCV_ID INNER JOIN STU_FIN_FEE_RCV_MODE_INF rm ON rt.FEE_RCV_RECEIPT_NO = rm.FEE_RCV_RECEIPT_NO INNER JOIN "
                        + "PAY_MODE_INF pm ON rm.PAY_MODE_ID = pm.PAY_MODE_ID INNER JOIN StuView on dm.STU_ADM_NO=StuView.STU_MAIN_ID  WHERE rm.IS_ACTIVE=1 AND rm.PAY_MODE_ID=" + ddlMode.SelectedValue + " AND ");
        try
        {
            if (txtReceipt.Text != "")
            {
                query.AppendFormat("rm.FEE_RCV_RECEIPT_NO=" + txtReceipt.Text);
                SqlCommand cmd = new SqlCommand(query.ToString());
                gridShow.DataSource = df.GetDataSet(cmd);
                gridShow.DataBind();
            }

            else if (txtEnRoll.Text != "")
            {
                query.AppendFormat("StuView.ENROLLMENT_NO='" + txtEnRoll.Text+"'");
                SqlCommand cmd = new SqlCommand(query.ToString());
                gridShow.DataSource = df.GetDataSet(cmd);
                gridShow.DataBind();
            }


            else if (txtDateRcv.Text != "")
            {
                query.AppendFormat("CONVERT(VARCHAR,rm.RCV_TRAN_MODE_DT,103)=CONVERT(VARCHAR,@date,103)");
                SqlCommand cmd = new SqlCommand(query.ToString());
                cmd.Parameters.AddWithValue("@date", cf.GetDateTime(txtDateRcv.Text));
                gridShow.DataSource = df.GetDataSet(cmd);
                gridShow.DataBind();
                
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Receipt# or Enrollment# or Receiving Date')", true);
            }

            //else if (ddlMode.SelectedIndex != 0)
            //{
            //    query.AppendFormat("rm.PAY_MODE_ID=" + ddlMode.SelectedValue);
            //    fillFunctions_N.Fill(gridShow, new SqlCommand(query.ToString()));
            //}

        }
        catch
        {
        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        
       
        trReason.Visible = false;
        bindGrid();
    }
    protected void btnOk_Click(object sender, EventArgs e)
    {
        balObj.balModeId = Label1.Text;
        balObj.balReason = ddlReason.SelectedValue;
        balObj.balDate = cf.GetDateTime(txtDateCnl.Text).ToString();
        balObj.balCurUser = Session["UserId"].ToString();
        balObj.balData = txtRemark.Text;
        bllObj.FeeModeCancelIncesrt(balObj);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Mode Canceled successfully')", true);
        txtDateCnl.Text = txtDateRcv.Text = txtEnRoll.Text = txtReceipt.Text = txtRemark.Text = "";
        ddlMode.SelectedIndex = ddlReason.SelectedIndex = 0;
        trReason.Visible = false;
    }

    protected void gridShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        trReason.Visible = true;
        Label1.Text = gridShow.DataKeys[e.RowIndex].Value.ToString();
        bindGrid();
    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        df = new DatabaseFunctions();
        
    }
    
    
    
    
    
       

}
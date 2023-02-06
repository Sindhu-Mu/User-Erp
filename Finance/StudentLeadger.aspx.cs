using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    DataSet ds;
    CommonFunctions cf;   
    DatabaseFunctions databaseFunction; 
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();         
    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        ds = new DataSet();
        cf = new CommonFunctions();
        databaseFunction = new DatabaseFunctions();
    }
    protected void btnFind_Click(object sender, EventArgs e)
    {
        if (txtEnrollment.Text != "")
        {
            balObj.balCommonID = txtEnrollment.Text;
            Student.ShowStudent(balObj.balCommonID);
            ds = bllObj.GetStudentFeePaymentDetails(balObj);
            dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvDetail.DataSource = dt;
                gvDetail.DataBind();
            }
            dt = ds.Tables[1];
            if (dt.Rows.Count > 0)
            {
                gvPayTransaction.DataSource = dt;
                gvPayTransaction.DataBind();
            }
          
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enrollment No. Can't be blank')", true);
        }
    }




    protected void btnLeadger_Click(object sender, EventArgs e)
    {
        if (txtEnrollment.Text != "")
        {
            String url = "prtStudnetLeadger.aspx?" + txtEnrollment.Text;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('" + url + "','_blank','resizable=1,width=600,height=650')", true);
        }
    }
}
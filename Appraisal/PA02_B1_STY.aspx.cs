using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Appraisal_PA02_B1_STY : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        DivInstruction.Visible = true;
        DivLogin.Visible = false;
        if (Request.QueryString.Count > 0)
        {
            DivInstruction.Visible = false;
            DivLogin.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Your feedback has been submitted successfully.')", true);
        }
    }

    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            ObjBal.Enrollment = txtEnroll.Text;
            ObjBal.Sem = "0";// ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = "2022"; //DateTime.Now.Year.ToString();
            string status = ObjBll.Login(ObjBal);
            if (status == "1")
            {
                Session["Id"] = txtEnroll.Text;
                Session["Date"] = txtDate.Text;
                Response.Redirect("PA02_B1_MKS.aspx");

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Your feedback has already been submitted .')", true);
                txtDate.Text = txtEnroll.Text = "";
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter your enrollment no.and click submit to continue.')", true);
        }
    }
    protected void btnProcess_Click(object sender, EventArgs e)
    {
       
            DivInstruction.Visible = false;
            DivLogin.Visible = true;
        
    }
}
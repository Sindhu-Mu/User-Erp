using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class TrainingAndPlacement_TNP_Comp_Profile_Main : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databaseFunction;
    QueryFunctions queryFunctions;
    TPBAL ObjBal;
    TPBLL ObjBll;

    void initialise()
    {
        fillFunction = new FillFunctions();
        databaseFunction = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        ObjBal = new TPBAL();
        ObjBll = new TPBLL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
            initialise();
            if (!IsPostBack)
            {
                btnSave.Attributes.Add("OnClick", "return validation()");
            
            }
        
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.Profile = txtcompprofile.Text;
        ObjBll.GetCompProfile(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Company Profile Saved Succucessfully.')", true);
        txtcompprofile.Text = "";
    }
}
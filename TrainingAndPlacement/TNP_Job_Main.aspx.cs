using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class TrainingAndPlacement_TNP_Job_Main : System.Web.UI.Page
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
        ObjBal =new TPBAL();
        ObjBll = new TPBLL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            btnSave.Attributes.Add("OnClick", "return validation()");
            fillFunction.Fill(ddlcompname, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.cmpny), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.Profile = txtprofile.Text;
        ObjBal.Id = ddlcompname.SelectedValue;
        ObjBll.GetProfile(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(' Job Profile Saved Succucessfully.')", true);
        txtprofile.Text = "";
        ddlcompname.SelectedIndex = 0;
    }
}
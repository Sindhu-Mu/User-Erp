using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Finance_DeactiveFacility : System.Web.UI.Page
{
    FillFunctions fillFunction;
    DatabaseFunctions databasefunction;
    CommonFunctions commonFunction;
    QueryFunctions queryfunction;
    SFBAL Objbal;
    SFBLL Objbll;
    DataSet ds;

    void initialise()
    {
        databasefunction = new DatabaseFunctions();
        queryfunction = new QueryFunctions();
        commonFunction = new CommonFunctions();
        fillFunction = new FillFunctions();
        Objbal = new SFBAL();
        Objbll = new SFBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        initialise();
        if (!IsPostBack)
        {
            btnShow.Attributes.Add("OnClick", "return validation()");
           fillFunction.Fill(ddlSem,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Semester),true,FillFunctions.FirstItem.Select);
        }
    }
    void fillgrid()
    {
        Objbal.balEnroll = commonFunction.GetKeyID(txtEnroll);
        Objbal.balSem=ddlSem.SelectedValue;
        ds = Objbll.DeactiveFacility(Objbal);
        gvshow.DataSource = ds;
        gvshow.DataBind();
    }
    protected void gvshow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        Objbal.balTempId = gvshow.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FD_SUB_ID"].ToString();
        Objbal.balMainHeadId = gvshow.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["FEE_MAIN_HEAD_ID"].ToString();
        Objbal.balStuAdmNo = gvshow.DataKeys[Convert.ToInt32(e.CommandArgument)].Values["STU_ADM_NO"].ToString();
        Objbal.balInBy = Session["UserId"].ToString();
        Objbll.DeactiveFacUpdate(Objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected Facility Deleted Successfully.')", true);
        //txtEnroll.Text = "";
        //ddlSem.SelectedIndex = 0;

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        
        Student.ShowStudent(commonFunction.GetKeyID(txtEnroll));
        fillgrid();
            
    }
}
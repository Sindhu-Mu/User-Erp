using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Academic_CollectionPrint : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    DataTable dt;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        ds = new DataSet();
        dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialise();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlshift, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Shift), true, FillFunctions.FirstItem.Select);            
            FillFunction.Fill(ddlInstitute, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        }
    }

    protected void btnLoad_Click(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlFromRoom, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SeatingRoom, txtdate.Text, ddlshift.SelectedValue, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlToRoom, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SeatingRoom, txtdate.Text, ddlshift.SelectedValue, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
       
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        ObjBal.FromDate = commonFunctions.GetDateTime(txtdate.Text);
        ObjBal.TypeId = ddlshift.SelectedValue;
        ObjBal.Value1 = ddlFromRoom.SelectedValue;

        ObjBal.Value2 = ddlToRoom.SelectedValue;
        dt = ObjBll.GetMinorAttendancePrint(ObjBal).Tables[0];
        if (dt.Rows.Count > 0)
        {
            Session["dt"] = dt;
            if (ddldocument.SelectedIndex == 0)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMinorAttendance.aspx')", true);
            else if (ddldocument.SelectedIndex == 1)
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtCopyCollection.aspx')", true);
        }


    }
    
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_OpenElecViewAtt : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    CommonFunctions CommonFunction;
    DataSet ds;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        CommonFunction = new CommonFunctions();
        ds = new DataSet();

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            LoadData();
        }

    }
    void LoadData()
    {
        fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OpnElecPap), true, FillFunctions.FirstItem.Select);
       
    }
  
    protected void btnViewAtt_Click(object sender, EventArgs e)
    {
        if (txtFaculty.Text == "")
        {
            objBal.EmpId = "";
        }
        else
        {
            objBal.EmpId = commonFunctions.GetKeyID(txtFaculty);
        }
        objBal.Pap_Code = ddlPaper.SelectedValue;
        ds = objBll.GetOpenELecAttDetails(objBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvPaper.DataSource = ds.Tables[0];
            gvPaper.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No Attendance is marked')", true);
        }
    }
    protected void btnViewMarks_Click(object sender, EventArgs e)
    {
        if (txtFaculty.Text == "")
        {
            objBal.EmpId = "";
        }
        else
        {
            objBal.EmpId = commonFunctions.GetKeyID(txtFaculty);
        }
        objBal.Pap_Code = ddlPaper.SelectedValue;
        ds = objBll.GetOpenELecMarksDetails(objBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvMarks.DataSource = ds.Tables[0];
            gvMarks.DataBind();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('No Marks is inserted')", true);
        }
    }
}
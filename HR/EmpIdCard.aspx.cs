using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
public partial class HR_EmpIdCard : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryfunction;
    DatabaseFunctions df;
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    int duplicate;
    int type;


    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
        df = new DatabaseFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
       
        Employee.ShowEmployeeInfo(txtCode.Text);
        db_getPrintHistry(txtCode.Text);

    }
    protected void db_getPrintHistry(string emp_id)
    {
        dt = ObjHrBll.EmpCardDetail(emp_id).Tables[0];
        ViewState["dt"] = dt;
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
         duplicate=dt.Rows.Count;
        if(duplicate!=0)
        {
            duplicate=1;
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {

        ObjAcaBAL.EmpId = txtCode.Text;
        type = ObjHrBll.GetEmpType(ObjAcaBAL);
        dbInsertCard();
        if (type == 1)
        {
            Response.Redirect("EmployeeCard.aspx?user_id=" + txtCode.Text);
        }
        else
        {
            Response.Redirect("TemporaryEmployeeCard.aspx?user_id=" + txtCode.Text);
        }
        
    }
    protected void dbInsertCard()
    {
       // string query = "Insert INTO EMP_ID_CARD_INF(USR_ID,CARD_STS,IN_BY)values(" + txtCode.Text + "," + duplicate + "," + Session["UserId"].ToString() + ")";
        SqlCommand cmd = new SqlCommand("Insert INTO EMP_ID_CARD_INF(USR_ID,CARD_STS,IN_BY)values(" + txtCode.Text + "," + duplicate + "," + Session["UserId"].ToString() + ")");
        cmd.CommandType = CommandType.Text;
        df.ExecuteCommand(cmd);
    }
}
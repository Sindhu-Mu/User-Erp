using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Appraisal_PA02_Fac_Feedback_report : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    DatabaseFunctions databaseFunctions;
    APPBAL AppBal;
    APPBLL AppBll;
    DataSet ds;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        AppBal = new APPBAL();
        AppBll = new APPBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        tblIns.Visible = false;
        btnPrint.Visible = false;
        Initialize();
        btnView.Attributes.Add("OnClick", "return validateView()");
        tableStatus.Visible = false;
        if (!IsPostBack)
        {

            for (int yy = (DateTime.Today.Year); yy > DateTime.Today.Year - 3; yy--)
                ddlYear.Items.Add(yy.ToString());
            ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            

        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        if (txtEmployee.Text == "")
        {
            lblMsg.Text = "Please enter the Employee Code";
        }
        else
        {
            lblMsg.Text = "";
            AppBal.Usr_id = commonFunctions.GetKeyID(txtEmployee);
       
        AppBal.Year = ddlYear.SelectedValue;
        AppBal.Sem = ddlSemType.SelectedValue;
        ds = AppBll.Get_Fac_Feedback(AppBal);
        gvShow.DataSource = ds.Tables[0];
        gvShow.DataBind();
        tableStatus.Visible = true;
       
        gvStuMarking.DataSource = ds.Tables[1];
        gvStuMarking.DataBind();
       
        tblIns.Visible = true;
        btnPrint.Visible = true;
        lblIns.Text = ds.Tables[2].Rows[0]["INS_VALUE"].ToString();
        lblDept.Text = ds.Tables[2].Rows[0]["DEPT_VALUE"].ToString();
        lblName.Text = ds.Tables[2].Rows[0]["EMP_NAME"].ToString();
        lblCode.Text = ds.Tables[2].Rows[0]["EMP_ID"].ToString();
        lblyear.Text = ddlYear.SelectedValue;
        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        tableStatus.Visible = true;
        tblIns.Visible = true;
        btnPrint.Visible = true;
    }
}
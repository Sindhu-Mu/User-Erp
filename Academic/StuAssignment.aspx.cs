using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Academic_StuAssignment : System.Web.UI.Page
{
    AcaBAL Objbal;
    AcaBLL Objbll;
    AcaDAL Objdal;
    FillFunctions Fillfunction;
    DatabaseFunctions databasefunction;
    CommonFunctions commonfunction;
    DataSet ds, ds1;

    public void Initialize()
    {
        Fillfunction = new FillFunctions();
        databasefunction = new DatabaseFunctions();
        commonfunction = new CommonFunctions();
        Objbal = new AcaBAL();
        Objdal = new AcaDAL();
        Objbll = new AcaBLL();
        ds = ds1 = new DataSet();
    
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            Objbal.EmpId = Session["Userid"].ToString();
            ds = Objbll.GetFacultyForAsn(Objbal);
            gvShow.DataSource = ds;
            gvShow.DataBind();
            ViewState["index"] = 0;
            A1.Visible = false;
        }
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
       
        Objbal.EmpId = Session["UserId"].ToString();
        ds = Objbll.GetAssignmentDetail(Objbal);
        gvAssignment.DataSource = ds;
        gvAssignment.DataBind();
    }
    protected void gvAssignment_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
         int index = Convert.ToInt32(e.CommandArgument);
        ViewState["index"] = index.ToString();
        ViewState["Name"] = gvAssignment.DataKeys[index].Values["DOC_NAME"].ToString();
        Objbal.EmpId = Session["UserId"].ToString();
        Objbal.Name = ViewState["Name"].ToString();
        ds1 = Objbll.GetStuAsnDetail(Objbal);
        ViewState["stu_main_id"] = ds1.Tables[0].Rows[0]["STU_MAIN_ID"].ToString();
        ViewState ["due_dt"]=ds1.Tables[0].Rows[0]["DUE_DATE"].ToString();
        gvstu.DataSource = ds1;
        gvstu.DataBind();
        A1.Visible = true;
    }
    protected void gvstu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string stu_main_id = ViewState["stu_main_id"].ToString();
        string name = ViewState["Name"].ToString();
        string dt = ViewState["due_dt"].ToString();
        A1.HRef = "../../StudentPortal/UploadedFile/Assignment/" + stu_main_id + "_" + name + "_" + commonfunction.GetDateTime(dt).ToString("yyyy-MM-dd") + ".docx";
    }
   
}
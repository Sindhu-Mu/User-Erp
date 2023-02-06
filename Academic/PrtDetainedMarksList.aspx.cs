using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_PrtDetainedMarksList : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataSet ds;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        ObjBal.Id = Request.QueryString[0].ToString();
        ObjBal.EXAMID = Request.QueryString[1].ToString();
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ds = ObjBll.GetDetainMarks(ObjBal);
       
    if(ds.Tables[0].Rows.Count>0)

        {
            lblIns.Text = ds.Tables[0].Rows[0]["INS_VALUE"].ToString();
            lblExamName.Text = ds.Tables[0].Rows[0]["EXAM_NAME"].ToString();
            lblCourseCode.Text = ds.Tables[0].Rows[0]["CRS_CODE"].ToString();
            lblCourseName.Text = ds.Tables[0].Rows[0]["CRS_NAME"].ToString();

        }

    gvDetainMarks.DataSource = ds.Tables[0];
    gvDetainMarks.DataBind();


    }
}
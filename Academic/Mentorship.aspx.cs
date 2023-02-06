using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

public partial class Academic_Mentorship : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    //string Msg;
    DataTable Dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillGrid();
        }
      
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        Dt = new DataTable();
    }
    void FillGrid()
    {
        ObjAcaBal.Id = Session["UserId"].ToString();
        ds = ObjAcaBll.MentorDetail(ObjAcaBal);
        ViewState["ds"] = ds;
        gvStu.DataSource = ds.Tables[0];
        gvStu.DataBind();
    }
    protected void gvStu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Detail")
        {
            //ModalPopupExtender1.Show();
            student.StudentFullProfile(gvStu.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());

        }
    }
}
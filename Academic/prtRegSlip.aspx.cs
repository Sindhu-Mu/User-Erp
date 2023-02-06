using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections.Specialized;
public partial class Academic_prtRegSlip : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    QueryFunctions QueryFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DataBasefunction;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            if (Request.QueryString.Count == 9)
            {
                show(Request.QueryString);
            }
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        QueryFunction = new QueryFunctions();
        FillFunction = new FillFunctions();
        DataBasefunction = new DatabaseFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        ds = new DataSet();
    }
    void show(NameValueCollection parameters)
    {
        ObjBal.InsId = parameters.Get(0);
        ObjBal.Pgm_Id = parameters.Get(1);
        ObjBal.KeyID = parameters.Get(2);
        ObjBal.Semid = parameters.Get(3);
        ObjBal.Id = parameters.Get(4);
        ObjBal.CommonId = parameters.Get(5);
        ObjBal.Brn_Id = parameters.Get(6);
        ObjBal.Sec_Id = parameters.Get(7);
        if (parameters.Get(8) != "")
            ObjBal.Enroll_No = parameters.Get(8);
        ds = ObjBll.getRegSlip(ObjBal);

        RptrStu.DataSource = ds.Tables[0];
        RptrStu.DataBind();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["REMARK"].ToString() == "Clear")
            {
                RptrStu.Items[i].FindControl("trDue").Visible = false;
                RptrStu.Items[i].FindControl("trDuee").Visible = false;
            }
            else
            {
                RptrStu.Items[i].FindControl("trDue").Visible = true;
                RptrStu.Items[i].FindControl("trDuee").Visible = true;
            }
        }



    }
}
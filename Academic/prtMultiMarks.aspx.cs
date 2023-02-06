using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_prtMultiMarks : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    CommonFunctions CommonFunction;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        string[] st = new string[2];
        st = Request.QueryString[0].Split(';');
        ObjAcaBal.KeyID = st[0];
        ObjAcaBal.SessionUserID = st[1];
        ds = ObjAcaBll.GetMultiMarksDetailRpt(ObjAcaBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            FillFunction.Fill(repMarks, ds.Tables[0]);
        }
        for (int i = 1; i < ds.Tables.Count; i++)
        {
            try
            {
                GridView GridView1 = (GridView)repMarks.Items[i - 1].FindControl("GridView1");
                FillFunction.Fill(GridView1, ds.Tables[i]);
            }
            catch { }
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        CommonFunction = new CommonFunctions();
        ds = new DataSet();
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_prtSingleInternalMarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        string[] st = new string[3];
        st = Request.QueryString[0].Split(';');
        ObjAcaBal.KeyID = st[0];
        ObjAcaBal.Id = st[1];
        ObjAcaBal.SessionUserID = st[2];
        ds = ObjAcaBll.GetInternalDetailRpt(ObjAcaBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            fillFunctions.Fill(repMarks, ds.Tables[0]);
        }
        for (int i = 1; i < ds.Tables.Count; i++)
        {
            try
            {
                GridView GridView1 = (GridView)repMarks.Items[i - 1].FindControl("GridView1");
                fillFunctions.Fill(GridView1, ds.Tables[i]);
            }
            catch { }
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        ds = new DataSet();
    }
}
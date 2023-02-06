using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_prtOpenElecMarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataSet ds;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        string[] st = new string[3];
        st = Request.QueryString[0].Split(';');
        ObjAcaBal.Pap_Code = st[0];
        ObjAcaBal.EXAMID = st[1];
        ObjAcaBal.SessionUserID = st[2];
        ds = ObjAcaBll.GetOpenElecMarks(ObjAcaBal);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        lblExam.Text = ds.Tables[0].Rows[0]["EXAM_TYPE_SUB_HEAD"].ToString();
        lblPap.Text = ds.Tables[0].Rows[0]["PAPER_CODE"].ToString();
        lblSUB_NAME.Text = ds.Tables[0].Rows[0]["SUB_NAME"].ToString();
    }
}
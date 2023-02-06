using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Academic_prtMajorMarks : System.Web.UI.Page
{
    CommonFunctions commonFunctions;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DataTable dt;
    QueryFunctions queryFunctions;
    DataSet ds;
    void Initialize()
    {
        commonFunctions = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();

        if (Request.QueryString[0] != "")
        {
            ObjBal.Id = Request.QueryString[0];
            ds = ObjBll.PrntMajorMarks(ObjBal);
            lblSem.Text = ds.Tables[0].Rows[0]["ACA_SEM_NO"].ToString();
            lblSubject.Text = ds.Tables[0].Rows[0]["ACA_SUB_NAME"].ToString();
            lblCode.Text = ds.Tables[0].Rows[0]["EVA_SCH_PAPER_CODE"].ToString();
            lblMaxMarks.Text = ds.Tables[0].Rows[0]["EXAM_MAX_MARKS"].ToString();
            lblWeightage.Text = ds.Tables[0].Rows[0]["MEM_W_MARKS"].ToString();
            lblType.Text = ds.Tables[0].Rows[0]["EXAM_NAME"].ToString();
            lblIns.Text = ds.Tables[0].Rows[0]["INS_VALUE"].ToString();
            lblAward.Text = Request.QueryString[0];
            gvDetail.DataSource = ds.Tables[1];
            gvDetail.DataBind();
            foreach (GridViewRow itm in gvDetail.Rows)
            {
                itm.Cells[0].Text = (itm.RowIndex + 1).ToString() + ".";
                itm.Cells[5].Text = commonFunctions.ConvertNumberToWord(Convert.ToDouble(itm.Cells[4].Text)).ToString();
            }
            lblScrutinizer.Text = ds.Tables[2].Rows[0]["SCRUITINIZER"].ToString();
            lblExaminer.Text = ds.Tables[2].Rows[0]["EXAMINOR"].ToString();
            lblVName.Text = ds.Tables[2].Rows[0]["INSERT_BY"].ToString();
        }
    }

}

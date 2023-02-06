using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class Academic_rptStudentDocument : System.Web.UI.Page
{
    CommonFunctions CommonFUnction;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    DatabaseFunctions databasefunction;
    AcaBAL ObjACaBal;
    AcaBLL ObjACaBll;
    DataTable Dt;
    string str;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            FillCOntrol();
        }
    }
    void Initialize()
    {
        databasefunction = new DatabaseFunctions();
        CommonFUnction = new CommonFunctions();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        ObjACaBal = new AcaBAL();
        ObjACaBll = new AcaBLL();
        Dt = new DataTable();
    }
    void FillCOntrol()
    {
        FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.DirectBranch), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlsts, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Stu_Status), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ChDocument, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.StuDocument), true);
        
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns,ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ChDocument, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.StuDocument, ddlCourse.SelectedValue), true);
    }
    private string ShowDoc(string stumainid, string Course)
    {
        string docCollected = "";
        string docName = "";
        for (int i = 0; i < ChDocument.Items.Count; i++)
        {
            if (ChDocument.Items[i].Selected)
                docCollected += "'" + ChDocument.Items[i].Value + "',";
            docName += "'" + ChDocument.Items[i].Value + "',";
        }
        docCollected = (docCollected == "") ? docName : docCollected;
        docCollected = docCollected.Trim(',');

        return docCollected;
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjACaBal.InsId = ddlIns.SelectedValue;
        ObjACaBal.Pgm_Id = ddlCourse.SelectedValue;
        ObjACaBal.Brn_Id = ddlBranch.SelectedValue;
        ObjACaBal.Id = ddlBatch.SelectedValue;
        ObjACaBal.Semid = ddlSem.SelectedValue;
        ObjACaBal.ChangeStatus = ddlsts.SelectedValue;
        Dt = ObjACaBll.StuDocumentDetail(ObjACaBal).Tables[0];
        gvStuDeatil.DataSource = Dt;
        gvStuDeatil.DataBind();
        foreach (GridViewRow itm in gvStuDeatil.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            string DocId = ShowDoc(Dt.Rows[itm.RowIndex]["STU_MAIN_ID"].ToString(), Dt.Rows[itm.RowIndex]["INS_PGM_ID"].ToString());
            str = "select doc_value,doc_in_sts =(select doc_in_sts from STU_DOC_MAIN_INF where STU_MAIN_ID in('" + Dt.Rows[itm.RowIndex]["STU_MAIN_ID"].ToString() + "') and STU_DOC_MAIN_INF.PGM_DOC_MAP_ID in(PGM_DOC_MAP_INF.PGM_DOC_MAP_ID)) "
             + " from STU_DOC_TYPE_INF inner join PGM_DOC_MAP_INF on STU_DOC_TYPE_INF.DOC_ID = PGM_DOC_MAP_INF.DOC_ID where DOC_STS = 1 and INS_PGM_ID in('" + ddlCourse.SelectedValue + "','0') and PGM_DOC_MAP_INF.DOC_ID in(" + DocId + ")";
            SqlCommand cmd = new SqlCommand(str);
            cmd.CommandType = CommandType.Text;
            DataTable dt = databasefunction.GetDataSet(cmd).Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() == "True")
                {
                    itm.Cells[6].Text += dt.Rows[i][0].ToString() + "</br>";
                }
                else
                {
                    itm.Cells[7].Text += dt.Rows[i][0].ToString() + "</br>";
                }
            }
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("StudentDocumentSts.xls", gvStuDeatil);
    }
}

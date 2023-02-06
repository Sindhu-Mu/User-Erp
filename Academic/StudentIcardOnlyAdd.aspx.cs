using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;

public partial class Academic_StudentIcard : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataSet ds;
    FillFunctions fill;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.Select);
            
        }
        
        }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        commonFunctions = new CommonFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        Msg = new Messages();
        ds = new DataSet();
        fill = new FillFunctions();
    }
    protected void cardGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void show_Click(object sender, EventArgs e)
    {


        StringBuilder query = new StringBuilder("SELECT TOP " + ddlCount.SelectedValue + " ROW_NUMBER() OVER(ORDER BY STU_ADM_NO ASC) AS SrNO, * FROM STU_ICARD_VIEW WHERE STU_STS_ID = 1");
        if (txtStudent.Text!= "")
            query.Append(" AND STU_ADM_NO = '" + commonFunctions.GetKeyID(txtStudent) + "'");
        else
        {
            if (ddlInstitution.SelectedIndex > 0)
                query.Append(" AND INS_ID = '" + ddlInstitution.SelectedValue + "'");

            if (ddlBranch.SelectedIndex > 0)
                query.Append(" AND PGM_BRN_ID = '" + ddlBranch.SelectedValue + "'");
            if (ddlSemester.SelectedIndex > 0 && ddlBatch.SelectedIndex > 0)
            {
                query.Append(" AND ACA_SEM_ID = " + ddlSemester.SelectedValue);
                query.Append(" AND ACA_BATCH_NAME = '" + ddlBatch.SelectedItem.Text + "'");
            }
            query.Append(" AND PRT_TKN = " + ddlPrinted.SelectedValue);
            query.Append(" ORDER BY ACA_BATCH_NAME, ACA_SEM_ID, INS_ID,PGM_BRN_ID  ");
        }

        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        DatabaseFunctions func = new DatabaseFunctions();
        DataSet ds = func.GetDataSet(command);
        Session["ds"] = ds;
        txtData.Text = ds.GetXml();
        cardGrid.DataSource = ds;
        cardGrid.DataBind();
    }
    public string GetXMLInsert
    {
        get
        {
            return txtData.Text;
        }
    }
    protected void print_Click(object sender, EventArgs e)
    {

    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlCourse,queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns,ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch,ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class Academic_rptStudentPhotoStatus : System.Web.UI.Page
{ FillFunctions FillFUnction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions Databasefunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;    
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
      Initialize();
        if (!IsPostBack)
        {
            FillData();
            btnExcel.Visible = false;
        }
    }
    void Initialize()
    {
        FillFUnction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        Databasefunction = new DatabaseFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        dt = new DataTable();
    }
    void FillData()
    {
        FillFUnction.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        FillFUnction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        FillFUnction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
        FillFUnction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        FillFUnction.Fill(ddlSec, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFUnction.Fill(ddlPgm, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFUnction.Fill(ddlBrn, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    void FillGvShow()
    {
      
        ObjAcaBal.InsId = ddlIns.SelectedValue;
        ObjAcaBal.TypeId = ddlBatch.SelectedValue;
        ObjAcaBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjAcaBal.Brn_Id = ddlBrn.SelectedValue;
        ObjAcaBal.Semid = ddlSem.SelectedValue;
        ObjAcaBal.Sec_Id = ddlSec.SelectedValue;
        dt=ObjAcaBll.StuDataForm(ObjAcaBal).Tables[0];
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
        foreach (GridViewRow row in gvDetail.Rows)
        {
            if (File.Exists(Server.MapPath("../Images/Stuimages/" + row.Cells[1].Text + ".jpg")) == true)
                row.Cells[5].Text = "Yes";
            else
                row.Cells[5].Text = "No";           
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillGvShow();
       
        btnExcel.Visible = true;
    }
    
   
    protected void btnExcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("StudntImage.xls", gvDetail);
            
    }
}
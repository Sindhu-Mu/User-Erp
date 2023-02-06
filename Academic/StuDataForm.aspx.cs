using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StuDataForm : System.Web.UI.Page
{
    FillFunctions FillFUnction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions Databasefunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;    
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
       // btnShow.Attributes.Add("onClick", "return Validate()");
       // btnPrint.Attributes.Add("onClick", "return Validate()");
        Initialize();
        if (!IsPostBack)
        {
            FillData();
            btnPrint.Visible = false;
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
        if (txtEnroll.Text.Contains(":"))
            ObjAcaBal.Stu_AdmNo = CommonFunction.GetKeyID(txtEnroll);
        ObjAcaBal.InsId = ddlIns.SelectedValue;
        ObjAcaBal.TypeId = ddlBatch.SelectedValue;
        ObjAcaBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjAcaBal.Brn_Id = ddlBrn.SelectedValue;
        ObjAcaBal.Semid = ddlSem.SelectedValue;
        ObjAcaBal.Sec_Id = ddlSec.SelectedValue;
        dt=ObjAcaBll.StuDataForm(ObjAcaBal).Tables[0];
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
      
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillGvShow();
       
        btnPrint.Visible = true;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string STU_ID = "";
        foreach (GridViewRow itm in gvDetail.Rows)
        {
            CheckBox ck=new CheckBox();
            ck=(CheckBox)itm.FindControl("ChkBox");
            if (ck.Checked)
            {
                STU_ID = STU_ID + "," + gvDetail.DataKeys[itm.RowIndex].Values[0].ToString();
            }
        }
        STU_ID = STU_ID.Trim(',');
        Session["STU_MAIN_ID"] = STU_ID;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "window.open('PrtStuDataForm.aspx')", true);
        clear();
    }
    void clear()
    {
        gvDetail.DataSource = "";
        gvDetail.DataBind();
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlIns);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlPgm);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlBrn);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlSem);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlSec);
    }
}
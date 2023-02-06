using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_Re_Reg_App : System.Web.UI.Page
{
    FillFunctions fillFunction;
    QueryFunctions QueryFuntion;
    DatabaseFunctions DataBasefunction;
    CommonFunctions CommonFunction;
    FacBAL ObjFacBal;
    FacBLL ObjfacBll;
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("OnClick", "return Validate()");
        Initialize();
        if (!IsPostBack)
        {
            fillFunction.Fill(ddlReg, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Reg_Sem), true, FillFunctions.FirstItem.Select);
            ddlReg.SelectedIndex = 1;
            fillFunction.Fill(ddlIns, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
            fillFunction.Fill(ddlSem, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.All);
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        btnPrint.Visible = true;
        FillGvShow();
    }
    void Initialize()
    {
        fillFunction = new FillFunctions();
        CommonFunction = new CommonFunctions();
        DataBasefunction = new DatabaseFunctions();
        QueryFuntion = new QueryFunctions();
        ObjFacBal = new FacBAL();
        ObjfacBll = new FacBLL();
        Dt = new DataTable();
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunction.Fill(ddlProgram, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlProgram_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunction.Fill(ddlBranch, QueryFuntion.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlProgram.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    void FillGvShow()
    {

        if (txtStu.Text.Contains(":"))
        {
            ObjFacBal.AuthFor = CommonFunction.GetKeyID(txtStu);
            ObjFacBal.StuAdmNo = ObjfacBll.GetStudentMainId(ObjFacBal);
        }
        else
            ObjFacBal.StuAdmNo = null;
        ObjFacBal.RegId = ddlReg.SelectedValue;
        ObjFacBal.Value = ddlRegSts.SelectedValue;
        ObjFacBal.InsId = ddlIns.SelectedValue;
        ObjFacBal.Id = ddlProgram.SelectedValue;
        ObjFacBal.DeptId = ddlBranch.SelectedValue;
        ObjFacBal.TypeId = ddlSem.SelectedValue;
        ObjFacBal.Status = ddlSts.SelectedValue;
        gvShow.DataSource = ObjfacBll.ReRegPrint(ObjFacBal).Tables[0];
        gvShow.DataBind();
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string ReG_ID = "";
        foreach (GridViewRow itm in gvShow.Rows)
        {
            CheckBox chk = (CheckBox)itm.FindControl("ChkBox");
            if (chk.Checked)
            {
                ReG_ID = ReG_ID + "," + gvShow.DataKeys[itm.RowIndex].Values[0].ToString();
            }
        }
        ReG_ID = ReG_ID.Trim(',');
        Session["REG_ID"] = ReG_ID;
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "window.open('Prt_Re_reg.aspx')", true);
        clear();
    }
    void clear()
    {
        gvShow.DataSource = "";
        gvShow.DataBind();
    }
}
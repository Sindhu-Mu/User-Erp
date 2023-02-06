using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Academic_BranchChange : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    CommonFunctions commonFunctions;
    DataSet ds;
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        btnShow.Attributes.Add("OnClick", "return validateShow()");
        btnChange.Attributes.Add("OnClick", "return validateChange()");
        Initialise();
        if (!IsPostBack)
        {
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnroll.Text);
        FillFunction.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitution.SelectedIndex > 0)
            FillFunction.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            FillFunction.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
    
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ObjBal.Stu_AdmNo = txtEnroll.Text;
        ObjBal.KeyID = ddlBranch.SelectedValue;
        ObjBal.Semid = ddlSemester.SelectedValue;
        ObjBal.Remark = txtRemark.Text;
        ObjBal.SessionUserID = Session["UserId"].ToString();
        string newEnrol = ObjBll.ChangeBranchInsert(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + newEnrol + "')", true);
        txtEnroll.Text = "";
        txtRemark.Text = "";
        ddlInstitution.SelectedIndex = ddlBranch.SelectedIndex = ddlCourse.SelectedIndex = ddlSemester.SelectedIndex = 0;

    }
}
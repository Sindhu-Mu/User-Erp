using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;

public partial class Academic_OpnElecStuSelct : System.Web.UI.Page
{

    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    DataSet ds;
    string Msg;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSaveGroup.Attributes.Add("OnClick", "return validate()");
        btnSaveGroup.Attributes.Add("OnClick", "return validate2()");
        btnView.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            rowHide.Visible = false;
            LoadData();
        }
    }
    void LoadData() 
    {
        fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OpnElecPap), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        //fillFunctions.Fill(ddlGroup, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Group), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlInstitution.SelectedIndex > 0)
            fillFunctions.Fill(ddlInstitution, ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlInstitution, CommonFunctions.ClearType.Value, ddlCourse, ddlBranch);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCourse.SelectedIndex > 0)
            fillFunctions.Fill(ddlCourse, ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlCourse, CommonFunctions.ClearType.Value, ddlBranch);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.InsId = ddlInstitution.SelectedValue;
        objBal.Pgm_Id = ddlCourse.SelectedValue;
        objBal.Brn_Id = ddlBranch.SelectedValue;
        objBal.Semid = ddlSemester.SelectedValue;
        ds = objBll.GetStudentDataOpnElec(objBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
            rowHide.Visible = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert(' No student found. ')", true);
        }

    }
    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
       
        CheckBox chkStudent;

        data.AppendFormat("<INTERNAL>");
        foreach (GridViewRow row in gvStudent.Rows)
        {
            chkStudent = (CheckBox)row.FindControl("chkStudent");

            if (chkStudent.Checked)
            {
                data.AppendFormat("<MARKS  STU_MAIN_ID= \"" + gvStudent.DataKeys[row.RowIndex].Values[0].ToString() +"\"/>");
            }
        }
        data.AppendFormat("</INTERNAL>");
        objBal.XmlValue = data.ToString();
        objBal.Pap_Code = ddlPaper.SelectedValue;
        objBal.Date = commonFunctions.GetDateTime(txtdateGroupActive.Text);
        objBal.SessionUserID = Session["UserId"].ToString();
        ds = objBll.SaveOpnElecStu(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Records Inserted Successfully')", true);
        gvStudent.Visible = false;
        txtdateGroupActive.Text = "";
        ddlBranch.Items.Clear();
        ddlSemester.Items.Clear();
        ddlCourse.Items.Clear();
        ddlInstitution.Items.Clear();
       
        
    }
}
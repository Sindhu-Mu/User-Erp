using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;


public partial class Academic_SectionChange : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    string Msg;
    DataSet ds;
    SqlCommand command;
    AcaBAL objbal;
    AcaBLL objbll;
    AcaDAL objdal;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        show.Attributes.Add("OnClick", "return validation()");
        btnSave.Attributes.Add("OnClick", "return validation1()");
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlInstitution, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSemester, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
           // fillFunctions.Fill(ddlSection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddltosection, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        databaseFunctions = new DatabaseFunctions();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
        command = new SqlCommand();
        objbal = new AcaBAL();
        objdal =new AcaDAL();
        objbll = new AcaBLL();
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
        CheckBox chkSelect;

         data.AppendFormat("<Section>");
         foreach (GridViewRow row in gvshow.Rows)
         {
             chkSelect = (CheckBox)row.FindControl("chkSelect");
             if (chkSelect.Checked)
             {
                 data.AppendFormat("<CHANGE STU_MAIN_ID=\"" + gvshow.DataKeys[row.RowIndex].Value.ToString() + "\" ACA_SEC_ID= \"" + ddltosection.SelectedValue +
                        "\" IN_BY= \"" + Session["UserId"].ToString() + "\"  REMARK= \"" + txtRemark.Text + "\"/>");
             }
         }
             data.AppendFormat("</Section>");
             objbal.XmlValue = data.ToString();
             Msg = objbll.SectionChngInsert(objbal);
             ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
             gvshow.DataSource = "";
             gvshow.DataBind();
         
    }
    protected void show_Click(object sender, EventArgs e)
    {
        objbal.InsId = ddlInstitution.SelectedValue;
        objbal.Pgm_Id = ddlCourse.SelectedValue;
        objbal.Brn_Id = ddlBranch.SelectedValue;
        objbal.Semid = ddlSemester.SelectedValue;
        objbal.Sec_Id = ddlSection.SelectedValue;
        ds=objbll.SectionChng(objbal);
        gvshow.DataSource = ds;
        gvshow.DataBind();
        txtRemark.Text = "";
        
    }

    protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlCourse, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitution.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;


public partial class Academic_SpecialMinor : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        btnSave.Attributes.Add("onClick", "return Validate()");
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
        dt = new DataTable();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            AcaBal.Stu_AdmNo = commonFunctions.GetKeyID(txtEnroll);
            Student.ShowStudent(AcaBal.Stu_AdmNo);            
            ViewState["ID"] = AcaBll.GetStudentMainId(AcaBal);
            gvMinor.DataSource = "";
            gvMinor.DataBind();   
            fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PaperCode, ViewState["ID"].ToString(), 
            Session["UserId"].ToString()), true, FillFunctions.FirstItem.Select);

        }
    }
    protected void ddlPaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPaper.SelectedIndex > 0)
        {

            AcaBal.Id = ViewState["ID"].ToString();
            AcaBal.Pgm_Id = ddlPaper.SelectedValue;
            dt = AcaBll.GetSpecialMinorDetail(AcaBal).Tables[0];
            if (dt.Rows.Count > 0)
            {
                gvMinor.DataSource = dt;
                gvMinor.DataBind();              
                btnSave.Visible = true;
            }
            else
              ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Present students marks cant be inserted')", true);
         
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        StringBuilder data = new StringBuilder();
        RadioButtonList AttList;
        TextBox txtMarks;
        data.AppendFormat("<INTERNAL>");
        foreach (GridViewRow row in gvMinor.Rows)
        {
            AttList = (RadioButtonList)row.FindControl("AttList");
            txtMarks = (TextBox)row.FindControl("txtMarks");
            data.AppendFormat("<MARKS  EXAM_TYPE_SUB_ID= \"" + gvMinor.DataKeys[row.RowIndex].Value.ToString() +
                    "\" INT_ATT_STS= \"" + AttList.SelectedValue + "\"  INT_MARKS= \"" + txtMarks.Text + "\"/>");           
        }
        data.AppendFormat("</INTERNAL>");
        AcaBal.Id = ddlPaper.SelectedValue;
        AcaBal.Stu_AdmNo = ViewState["ID"].ToString();
        AcaBal.XmlValue = data.ToString();
        AcaBal.SessionUserID = Session["UserId"].ToString();     
        AcaBll.StuSpecialMinorMraks(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected course code student marks inserted.')", true);
        clear();

    }
    void clear()
    {
        txtEnroll.Text = "";
        commonFunctions.Clear(CommonFunctions.ClearType.Index, ddlPaper);
        gvMinor.DataSource = "";
        gvMinor.DataBind();
    }
}
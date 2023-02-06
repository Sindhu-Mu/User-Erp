using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Academic_OpenElecPaperAdd : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    CommonFunctions CommonFunction;
    DataSet ds;
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        CommonFunction = new CommonFunctions();
        ds = new DataSet();
    
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        
        btnAdd.Attributes.Add("OnClick", "return validation()");
      
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlSubjectType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SubjectType), true, FillFunctions.FirstItem.Select);
        ds = objBll.getOpenElecList(objBal);
        gvPaper.DataSource = ds.Tables[0];
        gvPaper.DataBind();
       
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        objBal.TypeId = ddlSubjectType.SelectedValue;
        objBal.Marks = ddlMarksTemplate.SelectedValue;
        objBal.PAPERNAME = txtSubject.Text;
        objBal.Pap_Code = txtPaperCode.Text;
        objBal.EmpId = CommonFunction.GetKeyID(txtFaculty);
        objBal.SessionUserID = Session["UserId"].ToString();
        ds = objBll.AddOpenElective(objBal);
        String str1 = ds.Tables[0].Rows[0]["PAPER_CODE"].ToString();
        String str2 = ds.Tables[0].Rows[0]["SUB_NAME"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + str1+"(" +str2+")"+ " is added successfully')", true);
        txtFaculty.Text = "";
        txtPaperCode.Text = "";
        txtSubject.Text = "";
        ddlSubjectType.Items.Clear();
        ddlMarksTemplate.Items.Clear();
        LoadData();
    }

    protected void ddlSubjectType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubjectType.SelectedIndex > 0)
        {
            objBal.TypeId = ddlSubjectType.SelectedValue;
            fillFunctions.Fill(ddlSubjectType, ddlMarksTemplate, objBll.GetMarksTemplate(objBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(ddlSubjectType, CommonFunctions.ClearType.Value, ddlMarksTemplate);
    }
}
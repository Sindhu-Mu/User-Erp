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
public partial class Academic_OpenElecMinorMarks : System.Web.UI.Page
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
        btnView.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            LoadData();
           
            btnSave.Visible = false;
        }
    }
    void LoadData()
    {
        fillFunctions.Fill(ddlPaper, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OpnElecPap), true, FillFunctions.FirstItem.Select);

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        objBal.Pap_Code = ddlPaper.SelectedValue;
        objBal.SessionUserID = Session["UserId"].ToString();
        ds = objBll.OpenElectiveAttendance(objBal);
        if (ds.Tables[0].Rows.Count > 0)
        {
           
           
            gvStudent.Visible = true;
            gvStudent.DataSource = ds.Tables[0];
            gvStudent.DataBind();
          
            btnSave.Visible = true;
        }
        else
        {
            gvStudent.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Another faculty is assigned for this paper')", true);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        StringBuilder data = new StringBuilder();
        RadioButtonList AttList;
        TextBox txtMarks;
        data.AppendFormat("<INTERNAL>");
        foreach (GridViewRow row in gvStudent.Rows)
        {
            AttList = (RadioButtonList)row.FindControl("AttList");
            txtMarks = (TextBox)row.FindControl("txtMarks");
            data.AppendFormat("<MARKS STU_MAIN_ID= \"" + gvStudent.DataKeys[row.RowIndex].Values[0].ToString() +
                    "\" ATT_STS= \"" + AttList.SelectedValue + "\"  MARKS= \"" + txtMarks.Text + "\"/>");
        }
        data.AppendFormat("</INTERNAL>");
        objBal.XmlValue = data.ToString();
        objBal.Pap_Code = ddlPaper.SelectedValue;
        objBal.KeyID = ddlExamination.SelectedValue;
        objBal.SessionUserID = Session["UserId"].ToString();
        ds = objBll.OpenElecMarksInsert(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Marks Inserted Successfully')", true);
        gvStudent.DataSource = "";
        gvStudent.DataBind();
        btnSave.Visible = false;
      
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string pp = ddlPaper.SelectedValue + ";" + ddlExamination.SelectedValue + ";" + Session["UserId"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtOpenElecMarks.aspx?" + pp + "','_blank','alwaysRaised')", true);
    }
    protected void ddlPaper_SelectedIndexChanged(object sender, EventArgs e)
    {
        objBal.Pap_Code = ddlPaper.SelectedValue;
        fillFunctions.Fill(ddlExamination, objBll.GetOpenElecExamType(objBal).Tables[0], true, FillFunctions.FirstItem.Select);
    }
}
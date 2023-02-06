using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;   

public partial class Academic_StudentGroup : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    string Msg;

    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnCopy.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            timeTableWizard.ActiveStepIndex = 0;
            FillData();
            ViewState["CLS_SEM_ID"] = "";
            ViewState["TT_ID"] = "";
        }
    }

    void FillData()
    {
        fillFunctions.Fill(ddlInst, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlGroup, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Group), true, FillFunctions.FirstItem.Select);
    }

    #region Dropdown SelectedIndexChanged
    protected void ddlSemesterBound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSemesterBound.SelectedIndex > 0)
        {
            AcaBal.InsId = ddlInst.SelectedValue;
            fillFunctions.Fill(ddlChooseClass, AcaBll.GetClasses(AcaBal), true, FillFunctions.FirstItem.Select);
        }
        else
            commonFunctions.Clear(CommonFunctions.ClearType.Value, ddlChooseClass);
    }
    #endregion

    #region Change wizard step
    protected void ActivateWizardStep1(object sender, EventArgs e)
    {
        LoadClassData();
    }
    protected void ActivateWizardStep2(object sender, EventArgs e)
    {
        LoadDataStep2();
    }
    protected void ActivateWizardStep3(object sender, EventArgs e)
    {
        if (gridPaperCombination.SelectedIndex < 0)
        {
            timeTableWizard.ActiveStepIndex = 2;
            LoadDataStep2();
        }
    }
    protected void ActivateWizardStep4(object sender, EventArgs e)
    {
        if (gridPaperCombination.SelectedIndex > 0)
        {
            LoadStudentData(ViewState["TT_ID"].ToString());
        }
    }
    #endregion

    protected void gridPaperCombination_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        timeTableWizard.ActiveStepIndex = 3;
        int index = Convert.ToInt32(e.CommandArgument);
        string TT_ID = gridPaperCombination.DataKeys[index].Value.ToString();
        ViewState["TT_ID"] = TT_ID;
        LoadStudentData(TT_ID);
    }

    

    #region Load function
    void LoadClassData()
    {
        if (ddlChooseClass.SelectedIndex > 0)
        {
            AcaBal.Id = ddlSemesterBound.SelectedValue;
            AcaBal.CommonId = ddlChooseClass.SelectedValue;
            ViewState["CLS_SEM_ID"] = AcaBll.SaveClassSemester(AcaBal).Tables[0].Rows[0][0];

            AcaBal.KeyID = ViewState["CLS_SEM_ID"].ToString();

            DataSet dataSetClass = AcaBll.GetClassData(AcaBal);
            fillFunctions.Fill(gridBranch, dataSetClass.Tables[0]);

            StringWriter writer = new StringWriter();
            dataSetClass.Tables[1].WriteXml(writer);
            txtstep2.Text = writer.GetStringBuilder().ToString();
            writer.Close();
            writer.Dispose();
            if (txtstep2.Text == "<NewDataSet />")
                txtstep2.Text = "";
        }
        else
        {
            timeTableWizard.ActiveStepIndex = 0;
        }
    }
    void   LoadDataStep2()
    {
        if (txtstep2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtstep2.Text));
            gridPaperCombination.DataSource = dataSet.Tables[0];
            gridPaperCombination.DataBind();
            commonFunctions.MergeRows(gridPaperCombination, 0, 1, 3);
        }
        else
        {
            gridPaperCombination.DataSource = null;
            gridPaperCombination.DataBind();
        }
    }
    void LoadStudentData(string TT_ID)
    {
        AcaBal.Id = TT_ID;
        DataSet dataSet = AcaBll.GetStudentData(AcaBal);
        fillFunctions.Fill(gridPaperCombinationSelect, dataSet.Tables[0]);
        commonFunctions.MergeRows(gridPaperCombinationSelect, 0, 1, 3);
        fillFunctions.Fill(gridPaperCombinationSelect1, dataSet.Tables[0]);
        commonFunctions.MergeRows(gridPaperCombinationSelect1, 0, 1);
        fillFunctions.Fill(gridStudent, dataSet.Tables[1]);
        fillFunctions.Fill(gridStudent1, dataSet.Tables[2]);
        dataSet.Dispose();
    }
    #endregion
    protected void btnSaveGroup_Click(object sender, EventArgs e)
    {
        AcaBal.TypeId = ddlGroup.SelectedValue;
        AcaBal.Date = commonFunctions.GetDateTime(txtdateGroupActive.Text);
        AcaBal.SessionUserID = Session["UserId"].ToString();
        Msg= AcaBll.SaveStuGroup(AcaBal, gridStudent);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
       
    }
    

    protected void chkCopy_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCopy.Checked)
        {
            tblcopy.Visible = true;
            tblstu.Visible = false;
            AcaBal.KeyID = ViewState["CLS_SEM_ID"].ToString();
            fillFunctions.Fill(ddlPpr, AcaBll.GetPaperCodeForGrp(AcaBal).Tables[0], true, FillFunctions.FirstItem.Select);
        }
        else
        {
            tblcopy.Visible = false;
            tblstu.Visible = true;
        }
    }

    protected void btnCopy_Click(object sender, EventArgs e)
    {
        AcaBal.TypeId = ViewState["TT_ID"].ToString();
        AcaBal.KeyID = ddlPpr.SelectedValue;
        AcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = AcaBll.CopyStuGroup(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        string TT_ID = gridPaperCombinationSelect.DataKeys[0].Value.ToString();
        LoadStudentData(TT_ID);
        UpdatePanel1.Update();
        txtdateGroupActive.Text = "";
        ddlGroup.SelectedIndex = 0;
        chkCopy.Checked = false;
        tblcopy.Visible = false;
        tblstu.Visible = true;
    }

}
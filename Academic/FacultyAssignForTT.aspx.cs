using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;

public partial class Academic_FacultyAssignForTT : System.Web.UI.Page
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
        btnSave.Attributes.Add("OnClick", "return Validation()");
        if (!IsPostBack)
        {
            timeTableWizard.ActiveStepIndex = 0;
            FillData();
            ddlUsrType.SelectedIndex = 1;
        }
    }

    void FillData()
    {
        fillFunctions.Fill(ddlInst, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlUsrType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UserType), true, FillFunctions.FirstItem.Select);
    }

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
        LoadDataStep3();
    }

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
    void LoadDataStep2()
    {
        if (ddlChooseClass.SelectedIndex > 0)
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
                timeTableWizard.ActiveStepIndex = 1;
            }
        }
        else
            timeTableWizard.ActiveStepIndex = 0;
    }

    void LoadDataStep3()
    {
        int index = gridPaperCombination.SelectedIndex;
        if (index >= 0)
        {
            AcaBal.Id = gridPaperCombination.DataKeys[index].Value.ToString();
            DataSet dataSet = AcaBll.GetFacultyTypeData(AcaBal);
            fillFunctions.Fill(gridDetail, dataSet.Tables[0]);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                fillFunctions.Fill(ddlFaculty, dataSet.Tables[0], true, FillFunctions.FirstItem.Select);
                trAssign.Visible = true;
            }
            else
                trAssign.Visible = false;

        }
        else
        {
            timeTableWizard.ActiveStepIndex = 2;
            //LoadDataStep2();
        }
    }

    protected void gridPaperCombination_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        LoadDataStep2();
        gridPaperCombination.SelectedIndex = index;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int index = gridPaperCombination.SelectedIndex;
        if (index >= 0)
        {
            AcaBal.CommonId = ddlFaculty.SelectedValue;
            AcaBal.Id = gridPaperCombination.DataKeys[index].Value.ToString();
            AcaBal.FromDate = commonFunctions.GetDateTime(txtFrmDt.Text);
            AcaBal.ToDate = commonFunctions.GetDateTime(txtToDt.Text);
            AcaBal.EmpId = commonFunctions.GetKeyID(txtEmp);
            AcaBal.TypeId = ddlUsrType.SelectedValue;
            AcaBal.SessionUserID = Session["UserId"].ToString();
            Msg = AcaBll.AssignFaculty(AcaBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            txtEmp.Text = txtFrmDt.Text = txtToDt.Text = "";
            LoadDataStep3();
            //data.AppendFormat("<DATA EMP_ID=\"" + paramrow.Cells[1].Text + "\"/>");


        }
    }
}
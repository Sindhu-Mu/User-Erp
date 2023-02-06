using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Xml;

public partial class Academic_TimeTable : System.Web.UI.Page
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
        SaveTimeTable.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            timeTableWizard.ActiveStepIndex = 0;
            FillData();
        }
    }

    void FillData()
    {
        fillFunctions.Fill(ddlInst, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlSemesterBound, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Semester_id), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlComplex, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ComplexForTT), true, FillFunctions.FirstItem.Select);
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
    protected void ddlReoccurance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (txtStartDate.Text != "")
        {
            switch (Convert.ToInt32(ddlReoccurance.SelectedValue))
            {
                case 5:
                    fillFunctions.FillWeekdays(chkDays,commonFunctions.GetDateTime(txtStartDate.Text));
                    chkDays.Visible = true;
                    break;
                default:
                    chkDays.Visible = false;
                    break;
            }
        }
    }
    protected void ddlComplex_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlComplex.SelectedIndex > 0)
            fillFunctions.Fill(ddlComplex, ddlRoom, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.RoomNo, ddlComplex.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            commonFunctions.Clear(ddlComplex, CommonFunctions.ClearType.Value, ddlRoom);
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
        int index = gridPaperCombination.SelectedIndex;
        if (index >= 0)
        {
            AcaBal.Id = gridPaperCombination.DataKeys[index].Value.ToString();
            DataSet dataSet = AcaBll.GetPaperData(AcaBal);
            fillFunctions.Fill(gridPaperCombinationSelect, dataSet.Tables[0]);
            fillFunctions.Fill(ddlFaculty, dataSet.Tables[1], true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlClassType, dataSet.Tables[2], true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSlot, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TimeSlot), true, FillFunctions.FirstItem.Select);
            commonFunctions.MergeRows(gridPaperCombinationSelect, 0, 1);
            dataSet.Dispose();
            txtStartDate.Text = "";
            ddlComplex.SelectedIndex = ddlReoccurance.SelectedIndex = 0;
        }
        else
        {
            timeTableWizard.ActiveStepIndex = 2;
            LoadDataStep2();
        }
    }
    #endregion

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
    void LoadDataStep2()
    {
        if (txtstep2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtstep2.Text));
            gridPaperCombination.DataSource = dataSet.Tables[0];
            gridPaperCombination.DataBind();
            commonFunctions.MergeRows(gridPaperCombination, 0, 1, 3, 4);
        }
        else
        {
            gridPaperCombination.DataSource = null;
            gridPaperCombination.DataBind();
        }
    }
    #endregion

    protected void gridPaperCombination_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        commonFunctions.Clear(gridPaperCombinationSelect);
        LoadDataStep2();
        gridPaperCombination.SelectedIndex = index;
    }
    protected void gridPaperCombination_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        AcaBal.Id = gridPaperCombination.DataKeys[e.RowIndex].Value.ToString();
        Msg = AcaBll.DeletePaperData(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        LoadDataStep2();
    }

    protected void SaveTimeTable_Click(object sender, EventArgs e)
    {
        GridView1.DataSource = "";
        GridView1.DataBind();
        AcaBal.FromDate = commonFunctions.GetDateTime(txtStartDate.Text);
        AcaBal.ToDate = commonFunctions.GetDateTime(txtEndDate.Text);
        AcaBal.Value = ddlReoccurance.SelectedValue;
        AcaBal.KeyID = ddlSlot.SelectedValue;
        XmlDocument xmlData = new XmlDocument();
        xmlData = AcaBll.GetXMLForTT(AcaBal, chkDays);
        AcaBal.EmpId = ddlFaculty.SelectedValue;
        AcaBal.Id = gridPaperCombinationSelect.DataKeys[0].Value.ToString();
        AcaBal.TypeId = ddlClassType.SelectedValue;
        AcaBal.KeyID = ddlGroup.SelectedValue;
        AcaBal.CommonId = ddlRoom.SelectedValue;
        AcaBal.XmlValue = xmlData.OuterXml;
        AcaBal.ChangeStatus = radSaveConditions.SelectedValue;
        AcaBal.SessionUserID = Session["UserId"].ToString();
        DataSet ds = AcaBll.SaveTimeTable(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + ds.Tables[1].Rows[0][0].ToString() + "')", true);
        fillFunctions.Fill(GridView1, ds.Tables[0]);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    fillFunctions.Fill(GridView1, ds.Tables[0]);
        //    if (radSaveConditions.SelectedValue == "1")
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Certain errors were encountered.\\nCheck the log for details')", true);
        //    else
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Existing records were modified.\\nCheck the log for details')", true);
        //}
        //else
        //{
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Data inserted successfully.')", true);
        //}

    }
}
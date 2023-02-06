using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class HR_ApplicantFeedback : System.Web.UI.Page
{
    FillFunctions FillFunction = new FillFunctions();
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;

    public void Initialize()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlMOI, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntMode), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRound.SelectedIndex = 0;
        ddlInt.Items.Clear();
        trDetail.Visible = false;
    }
    protected void ddlRound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlJob.SelectedIndex > 0) && (ddlRound.SelectedIndex > 0))
        {
            FillFunction.Fill(ddlInt, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntNo, ddlJob.SelectedValue, ddlRound.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlInt.Items.Clear();
        trDetail.Visible = false;
    }
    protected void ddlInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInt.SelectedIndex > 0)
        {
            fillGrid();
        }
        else
        {
            trDetail.Visible = false;
            ddlStatus.SelectedIndex = 0;
        }
    }

    void fillGrid()
    {
        ObjHrBAL.HeadID = ddlInt.SelectedValue;
        ObjHrBAL.KeyID = ddlRound.SelectedValue;
        ObjHrBAL.TypeId = "1";
        ds = ObjHrBll.getApplicantList(ObjHrBAL);
        FillFunction.Fill(gvApplicants, ds.Tables[0]);
        FillFunction.Fill(ddlStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntStatus, ds.Tables[1].Rows[0][0].ToString()), true, FillFunctions.FirstItem.Select);
        trDetail.Visible = true;
        if (ds.Tables[0].Rows.Count > 0)
            trStatus.Visible = true;
        else
            trStatus.Visible = false;
    }

    protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatus.SelectedIndex > 0)
        {
            if (ddlStatus.SelectedValue == "8")
                trDate.Visible = trTime.Visible = trMode.Visible = false;
            else
            {
                trDate.Visible = trTime.Visible  = true;
                if (ddlStatus.SelectedValue == "7")
                {
                    thDate.InnerText = "Joining Date";
                    trMode.Visible = false;
                }
                else
                {
                    thDate.InnerText = "Next Round Date";
                    trMode.Visible = true;
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (TextBox1.Text != "")
        {
            xmlData.LoadXml(TextBox1.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("JOB");
            xmlData.AppendChild(ROOT);
        }
        int f = 0;
        foreach (GridViewRow row in gvApplicants.Rows)
        {

            CheckBox chk = (CheckBox)row.FindControl("CHK_SelectAll");
            if (chk.Checked == true)
            {
                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("INT_CAN_ID");
                element.InnerText = gvApplicants.DataKeys[row.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);

                f = 1;
            }
        }
        if (f == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('No Applicant Selected!!')", true);
        }
        else
        {
            TextBox1.Text = xmlData.InnerXml;
            ObjHrBAL.XmlData = TextBox1.Text;
            if (ddlStatus.SelectedValue != "8")
            {
                if (txtIntDate.Text != "" && txtInTime.Text != "")
                    ObjHrBAL.Date = commonFunctions.GetDateTime(txtIntDate.Text + " " + txtInTime.Text);
                ObjHrBAL.KeyValue = ddlMOI.SelectedValue;
            }
            ObjHrBAL.JobId = ddlJob.SelectedValue;
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            ObjHrBAL.ChangeStatus = ddlStatus.SelectedValue;
            ObjHrBAL.HeadID = ddlRound.SelectedValue;
            string msg = ObjHrBll.IntApplicantFeedBack(ObjHrBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);
            fillGrid();
            trDate.Visible = trTime.Visible = trMode.Visible = false;
            TextBox1.Text = "";
            txtIntDate.Text = txtInTime.Text = "";
            ddlMOI.SelectedIndex = ddlStatus.SelectedIndex = 0;
        }
    }
}
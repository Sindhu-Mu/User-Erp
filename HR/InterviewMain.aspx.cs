using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class HR_InterviewMain : System.Web.UI.Page
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
        btnSave.Attributes.Add("OnClick", "return validat()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlJob, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.JobNo), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlMOI, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntMode), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRound.SelectedIndex = 0;
        trDetail.Visible = trInt.Visible = false;
    }
    protected void ddlRound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRound.SelectedIndex > 0)
        {
            fillGrid();
        }
        else
            trDetail.Visible = trInt.Visible = false;
    }
    void fillGrid()
    {
        trDetail.Visible = true;
        ObjHrBAL.JobId = ddlJob.SelectedValue;
        ObjHrBAL.KeyID = ddlRound.SelectedValue;
        ds = ObjHrBll.GetIntDetails(ObjHrBAL);

        gvDetail.DataSource = ds.Tables[0];
        gvDetail.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
            trInt.Visible = true;
        else
            trInt.Visible = false;
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
        foreach (GridViewRow row in gvDetail.Rows)
        {

            CheckBox chk = (CheckBox)row.FindControl("CHK_SelectAll");
            if (chk.Checked == true)
            {
                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                XmlElement element = xmlData.CreateElement("INT_CAN_ID");
                element.InnerText = gvDetail.DataKeys[row.RowIndex].Values[0].ToString();
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
            if (txtIntDate.Text != "" && txtInTime.Text != "")
                ObjHrBAL.Date = commonFunctions.GetDateTime(txtIntDate.Text + " " + txtInTime.Text);
            ObjHrBAL.KeyValue = ddlMOI.SelectedValue;
            ObjHrBAL.JobId = ddlJob.SelectedValue;
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            ObjHrBAL.HeadID = ddlRound.SelectedValue;
            string msg = ObjHrBll.IntMainInsert(ObjHrBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);
            fillGrid();
        }
    }
}
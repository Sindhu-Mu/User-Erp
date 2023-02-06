using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class HR_ApplicantAttendance : System.Web.UI.Page
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
            trAtt.Visible = true;
        }
    }
    protected void ddlJob_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlRound.SelectedIndex = 0;
        ddlInt.Items.Clear();
        trAtt.Visible = false;
    }
    protected void ddlInt_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInt.SelectedIndex > 0)
        {
            ObjHrBAL.HeadID = ddlInt.SelectedValue;
            ObjHrBAL.KeyID = ddlRound.SelectedValue;
            ds=ObjHrBll.getApplicantList(ObjHrBAL);
            gvAttendance.DataSource =ds.Tables[0] ;
            gvAttendance.DataBind();
            if (ds.Tables[0].Rows.Count > 0)
                btnSave.Visible = true;
            else
                btnSave.Visible = false;
            foreach (GridViewRow row in gvAttendance.Rows)
            {
                ((RadioButtonList)gvAttendance.Rows[row.RowIndex].Cells[2].FindControl("rbAttendance")).SelectedValue = ds.Tables[0].Rows[0]["STS"].ToString();
            }

            trAtt.Visible = true;
        }
        else
            trAtt.Visible = false;
        
    }
    protected void ddlRound_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlJob.SelectedIndex > 0) && (ddlRound.SelectedIndex > 0))
        {
            FillFunction.Fill(ddlInt, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IntNo, ddlJob.SelectedValue, ddlRound.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
        else
            ddlInt.Items.Clear();
        trAtt.Visible = false;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {

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
            ROOT = xmlData.CreateElement("ATT");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in gvAttendance.Rows)
        {

            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("INT_SUB_ID");
            element.InnerText = gvAttendance.DataKeys[row.RowIndex].Value.ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("STS");
            element.InnerText = ((RadioButtonList)gvAttendance.Rows[row.RowIndex].Cells[2].FindControl("rbAttendance")).SelectedValue;
            dataElement.AppendChild(element);

            TextBox1.Text = xmlData.OuterXml;
        }
        ObjHrBAL.XmlData = TextBox1.Text;
        ObjHrBAL.SessionUserID = Session["UserId"].ToString();
        string msg = ObjHrBll.MarkAppAtt(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);

    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class Academic_StuAttendance : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            pushData();
        }
    }
    void Initialize()
    {
        common = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        dt = new DataTable();
    }
    void pushData()
    {
        fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSec, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlBatch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSlot, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TimeSlot), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
        else
            fillFunctions.Fill(ddlPgm, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Program), true, FillFunctions.FirstItem.All);
    }
    protected void ddlPgm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPgm.SelectedIndex > 0)
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlPgm.SelectedValue), true, FillFunctions.FirstItem.All);
        else
            fillFunctions.Fill(ddlBranch, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.branch), true, FillFunctions.FirstItem.All);
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        ObjBal.InsId = ddlIns.SelectedValue;
        ObjBal.Pgm_Id = ddlPgm.SelectedValue;
        ObjBal.Brn_Id = ddlBranch.SelectedValue;
        ObjBal.Id = ddlBatch.SelectedValue;
        ObjBal.Sec_Id = ddlSec.SelectedValue;
        ObjBal.Semid = ddlSem.SelectedValue;
        dt=ObjBll.getStuListForAtt(ObjBal).Tables[0];
        gvStudentData.DataSource = dt;
        gvStudentData.DataBind();
        trGrid.Visible = true;
        if (dt.Rows.Count > 0)
            trEntry.Visible = true;

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        XmlDocument XmlData = new XmlDocument();
        XmlElement Root;
        if (txtXML.Text != "")
        {
            XmlData.LoadXml(txtXML.Text);
            Root = XmlData.DocumentElement;
        }
        else
        {
            Root = XmlData.CreateElement("ATT");
            XmlData.AppendChild(Root);
        }



        foreach (GridViewRow row in gvStudentData.Rows)
        {
            CheckBox chk = (CheckBox)row.FindControl("chkAttendance");
            if (chk.Checked == true)
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);
                XmlElement element = XmlData.CreateElement("STU_MAIN_ID");
                element.InnerText = gvStudentData.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("ATT_STS");
                element.InnerText = "0";
                dataElement.AppendChild(element);
            }
            else
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);
                XmlElement element = XmlData.CreateElement("STU_MAIN_ID");
                element.InnerText = gvStudentData.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("ATT_STS");
                element.InnerText = "1";
                dataElement.AppendChild(element);
            }
        }
        txtXML.Text = XmlData.OuterXml;
        ObjBal.Date = common.GetDateTime(txtDate.Text);
        ObjBal.KeyID = ddlSlot.SelectedValue;
        ObjBal.Pap_Code = txtPap.Text;
        ObjBal.XmlValue = txtXML.Text;
        ObjBal.SessionUserID = Session["UserId"].ToString();
        string Msg = ObjBll.MarkStuTempAtt(ObjBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }
    void clear()
    {
        txtDate.Text = txtPap.Text = txtXML.Text = "";
        ddlBatch.SelectedIndex = ddlBranch.SelectedIndex = ddlIns.SelectedIndex = ddlPgm.SelectedIndex = ddlSec.SelectedIndex = ddlSem.SelectedIndex = ddlSlot.SelectedIndex = 0;
        trEntry.Visible = trGrid.Visible = false;
    }
}
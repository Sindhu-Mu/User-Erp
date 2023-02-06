using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
public partial class HR_VacationLeave : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions common;
    HRBLL ObjHrBll;
    HRBAL ObjHrBAL;
    CommonFunctions commonFunctions;
    DataSet ds;
    DatabaseFunctions databaseFunctions;

    public void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        common = new CommonFunctions();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();
        commonFunctions = new CommonFunctions();
        ds = new DataSet();
        databaseFunctions = new DatabaseFunctions();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlType, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.VacTyp), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlSaction, ObjHrBll.LvAppAuthSelect(), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            ddlDept.Items.Clear();
        gvDetail.Visible = trDetail.Visible = false;
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
        {
            ObjHrBAL.DeptId = ddlDept.SelectedValue;
            ObjHrBAL.TypeId = ddlType.SelectedValue;
            gvDetail.DataSource = ObjHrBll.GetEmpForVacation(ObjHrBAL).Tables[0];
            gvDetail.DataBind();
            if (ObjHrBll.GetEmpForVacation(ObjHrBAL).Tables[0].Rows.Count > 0)
                trDetail.Visible =gvDetail.Visible= true;
            else
                trDetail.Visible =  false;
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
            ROOT = xmlData.CreateElement("LEAVE");
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

                XmlElement element = xmlData.CreateElement("USR_ID");
                element.InnerText = gvDetail.DataKeys[row.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);

                f = 1;
            }
        }
        TextBox1.Text = xmlData.InnerXml;
        if (f == 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('No Employee Selected!!')", true);
        }
        else
        {
            ObjHrBAL.KeyValue = txtFrom.Text;
            ObjHrBAL.KeyID= txtToDate.Text;
            ObjHrBAL.TypeId = ddlType.SelectedValue;
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            ObjHrBAL.InBy = ddlSaction.SelectedValue;
            ObjHrBAL.XmlData = TextBox1.Text;
            ObjHrBAL.Code = AppDate.Text;
            string msg = ObjHrBll.VacLvInsert(ObjHrBAL);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + msg + "')", true);
            ddlType.SelectedIndex = 0;
            clear();
        }
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        clear();
    }
    void clear()
    {
        ddlIns.SelectedIndex=ddlSaction.SelectedIndex = 0;
        ddlDept.Items.Clear();
        gvDetail.Visible = false;
        trDetail.Visible = false;
        txtFrom.Text = txtToDate.Text = AppDate.Text = "";
        TextBox1.Text = "";
    }
}
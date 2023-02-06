using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Xml;
using System.IO;

public partial class Appraisal_PA032 : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions queryFunctions;
    APPBLL ObjBll;
    APPBAL ObjBal;
    CommonFunctions commonFunctions;
    string msg;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialise();
        PageManager aPage = new PageManager();
        System.Uri uri = Request.Url;
        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "Reconnect", aPage.AddKeepAlive(uri.Segments[uri.Segments.GetUpperBound(0)].ToString()), true);
        btnSave2A.Attributes.Add("OnClick", "return validation2A()");
        btnSave2B.Attributes.Add("OnClick", "return validation2B()");
        btnSave2C.Attributes.Add("OnClick", "return validation2C()");
        btnSave2D.Attributes.Add("OnClick", "return validation2D()");
        btnSave2E.Attributes.Add("OnClick", "return validation2E()");
        btnSave2E.Attributes.Add("OnClick", "return validation2F()");
        btnAdd.Attributes.Add("OnClick", "return ValidateAdd()");
        if (!IsPostBack)
        {
            ObjBal.SessionUserId = Session["UserId"].ToString();
            ObjBal.Sem = ObjBll.GetSemester(DateTime.Now.Month);
            ObjBal.Year = DateTime.Now.Year.ToString();
            ViewState["ID"] = ObjBll.SaveFaculty(ObjBal);
            pushData();
            pushData2A(ViewState["ID"].ToString());
            pushData2B(ViewState["ID"].ToString());
            pushData2C(ViewState["ID"].ToString());
            pushData2D(ViewState["ID"].ToString());
            pushData2E(ViewState["ID"].ToString());
            pushData2F(ViewState["ID"].ToString());
        }
    }
    void Initialise()
    {
        FillFunction = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        ObjBll = new APPBLL();
        ObjBal = new APPBAL();
        ds = new DataSet();
      
    }
    void pushData()
    {
        FillFunction.Fill(ddlLevel2A, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UnivLevel), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlLevel2B, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UnivLevel), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlLevel2C, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UnivLevel), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlLevel2D, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.UnivLevel), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlOPMF2B, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OPMF), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlOPMF2C, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OPMF), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlOPMF2D, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.OPMF), true, FillFunctions.FirstItem.Select);
        ObjBll.BuildGrid(gridData2A, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData2B, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData2C, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData2D, APPBLL.GridBuildMode.Entry);
        ObjBll.BuildGrid(gridData2E, APPBLL.GridBuildMode.Entry);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2A, lblHeader2A, lblDescription2A);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2B, lblHeader2B, lblDescription2B);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2C, lblHeader2C, lblDescription2C);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2D, lblHeader2D, lblDescription2D);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2E, lblHeader2E, lblDescription2E);
        ObjBll.SetHeader(APPBLL.HeaderFeild.PA03_2F, lblHeader2F, lblDescription2F);

    }
    #region 2A
    void pushData2A(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData2A, ObjBll.PA03_2A_GetData(ObjBal));
    }
    protected void btnSave2A_Click(object sender, EventArgs e)
    {

        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Duty = txtDuty2A.Text;
        ObjBal.Level = ddlLevel2A.SelectedValue;
        ObjBal.FromDate = txtFromDate2A.Text;
        ObjBal.ToDate = txtToDate2A.Text;
        ObjBll.PA03_2A_SaveData(ObjBal);
        clear2A();
        pushData2A(ObjBal.Id);

    }
    void clear2A()
    {
        txtDuty2A.Text = txtFromDate2A.Text = txtToDate2A.Text = "";
        ddlLevel2A.SelectedIndex = 0;
    }
    protected void gridData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData2A.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_2A_DeleteData(ObjBal);
        pushData2A(ViewState["ID"].ToString());
    }
    #endregion
    #region 2A
    void pushData2B(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData2B, ObjBll.PA03_2B_GetData(ObjBal));
    }
    protected void btnSave2B_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Duty = txtDuty2B.Text;
        ObjBal.Level = ddlLevel2B.SelectedValue;
        ObjBal.Opmf = ddlOPMF2B.SelectedValue;
        ObjBal.FromDate = txtFromDate2B.Text;
        ObjBal.ToDate = txtToDate2B.Text;
        ObjBll.PA03_2B_SaveData(ObjBal);
        clear2B();
        pushData2B(ObjBal.Id);
    }
    void clear2B()
    {
        txtDuty2B.Text = txtFromDate2B.Text = txtToDate2B.Text = "";
        ddlLevel2B.SelectedIndex = ddlOPMF2B.SelectedIndex = 0;
    }
    protected void gridData2B_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData2B.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_2B_DeleteData(ObjBal);
        pushData2B(ViewState["ID"].ToString());
    }
    #endregion

    #region 2C
    void pushData2C(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData2C, ObjBll.PA03_2C_GetData(ObjBal));
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Duty = txtDuty2C.Text;
        ObjBal.Level = ddlLevel2C.SelectedValue;
        ObjBal.Opmf = ddlOPMF2C.SelectedValue;
        ObjBal.FromDate = txtFromDate2C.Text;
        ObjBal.ToDate = txtToDate2C.Text;
        ObjBll.PA03_2C_SaveData(ObjBal);
        clear2C();
        pushData2C(ObjBal.Id);
    }
    void clear2C()
    {
        txtDuty2C.Text = txtFromDate2C.Text = txtToDate2C.Text = "";
        ddlLevel2C.SelectedIndex = ddlOPMF2C.SelectedIndex = 0;
    }

    protected void gridData2C_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData2C.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_2C_DeleteData(ObjBal);
        pushData2C(ViewState["ID"].ToString());
    }
    # endregion

    #region 2D
    void pushData2D(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData2D, ObjBll.PA03_2D_GetData(ObjBal));
    }
    protected void btnSave2D_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Duty = txtDuty2D.Text;
        ObjBal.Opmf = ddlOPMF2D.SelectedValue;
        ObjBal.Level = ddlLevel2D.SelectedValue;
        ObjBal.FromDate = txtFromDate2D.Text;
        ObjBal.ToDate = txtToDate2D.Text;
        ObjBll.PA03_2D_SaveData(ObjBal);
        clear2D();
        pushData2D(ObjBal.Id);
    }
    void clear2D()
    {
        txtDuty2D.Text = txtFromDate2D.Text = txtToDate2D.Text = "";
        ddlLevel2D.SelectedIndex = ddlOPMF2D.SelectedIndex = 0;
    }

    protected void gridData2D_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData2D.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_2D_DeleteData(ObjBal);
        pushData2D(ViewState["ID"].ToString());
    }
    # endregion

    #region 2E
    void pushData2E(string id)
    {
        ObjBal.Id = id;
        FillFunction.Fill(gridData2E, ObjBll.PA03_2E_GetData(ObjBal));
    }
    protected void btnSave2E_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Duty = txtDuty2E.Text;
        ObjBll.PA03_2E_SaveData(ObjBal);
        txtDuty2E.Text = "";
        pushData2E(ObjBal.Id);
    }
    protected void gridData2E_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjBal.KeyId = gridData2E.DataKeys[e.RowIndex].Value.ToString();
        ObjBll.PA03_2E_DeleteData(ObjBal);
        pushData2E(ViewState["ID"].ToString());
    }
    # endregion
    #region 2F
    void pushData2F(string id)
    {
        ObjBal.Id = id;
        ds = ObjBll.PA03_2F_GetData(ObjBal);
        if (ds.Tables[0].Rows.Count > 0)
        {

            txtCounselling.Text = ds.Tables[0].Rows[0][2].ToString();
            txtTotalTime.Text = ds.Tables[0].Rows[0][3].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAny1.Text = ds.Tables[0].Rows[0][5].ToString();
            txtAny2.Text = ds.Tables[0].Rows[0][6].ToString();
            txtAny3.Text = ds.Tables[0].Rows[0][7].ToString();
            txtAny4.Text = ds.Tables[0].Rows[0][8].ToString();
            txtAny5.Text = ds.Tables[0].Rows[0][9].ToString();
            StringWriter writer = new StringWriter();
            ds.Tables[1].WriteXml(writer);
            string xmlString = writer.GetStringBuilder().ToString();
            xmlString = xmlString.Replace("<NewDataSet>", "<Application>");
            xmlString = xmlString.Replace("</NewDataSet>", "</Application>");
            xmlString = xmlString.Replace("<Table1>", "<Qualification>");
            xmlString = xmlString.Replace("</Table1>", "</Qualification>");
            txtXML.Text = xmlString;
            LoadItemData();
           
        }
    }
    bool CheckData(string Code)
    {
        XmlDocument xmlData = new XmlDocument();
        if (txtXML.Text != "")
        {
            xmlData.LoadXml(txtXML.Text);
        }
        bool add = true;
        foreach (XmlNode node in xmlData.SelectNodes("ADMISSION/STUDENT/STUDENT_NAME"))
        {
            if (node.InnerText == Code)
            {
                msg = "This student information already exists.Check again.";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
                add = false;
                break;
            }
        }
        return add;
    }
    void Add()
    {


        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtXML.Text != "")
        {
            xmlData.LoadXml(txtXML.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("ADMISSION");
            xmlData.AppendChild(ROOT);
        }


        if (CheckData(txtStudent1.Text))
        {

            XmlElement dataElement = xmlData.CreateElement("STUDENT");
            ROOT.AppendChild(dataElement);
            XmlElement element = xmlData.CreateElement("PA03_2F_PROGRAM");
            element.InnerText = txtProgram1.Text;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("PA03_2F_STUDENT");
            element.InnerText = txtStudent1.Text;
            dataElement.AppendChild(element);
           
        }
        txtXML.Text = xmlData.OuterXml;
        LoadItemData();
    }
    void LoadItemData()
    {
        if (txtXML.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtXML.Text));
            gvStudentDetail.DataSource = dataSet.Tables[0];
            gvStudentDetail.DataBind();
        }
        else
        {
            gvStudentDetail.DataSource = "";
            gvStudentDetail.DataBind();
        }
    }
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        Add();
       txtProgram1.Text = txtStudent1.Text = "";
    }
    protected void btnSave2F_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Author = txtCounselling.Text;
        ObjBal.Award = txtTotalTime.Text;
        ObjBal.Count = txtContact.Text;
        ObjBal.Task = txtAny1.Text;
        ObjBal.Volume = txtAny2.Text;
        ObjBal.Comment = txtAny3.Text;
        ObjBal.Conference = txtAny4.Text;
        ObjBal.Enrollment = txtAny5.Text;
        ObjBal.Xml = txtXML.Text;
        ObjBll.PA03_2F_SaveData(ObjBal);       
        
    }
    protected void gvStudentDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ADMISSION/STUDENT");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txtXML.Text = xmlData.OuterXml;
        else
            txtXML.Text = "";
        LoadItemData();
    }
    #endregion
}
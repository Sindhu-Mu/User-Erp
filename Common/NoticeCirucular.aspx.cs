using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;
using System.Xml;

public partial class Common_NoticeCirucular : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    DataTable dt;
    string Extension, Url, Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return Validate()");
        btnAdd.Attributes.Add("OnClick", "return Validat()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillFunction.Fill(ddlNoticeDisplay, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Notice_For), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlUploadType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Upload_Type), true, FillFunctions.FirstItem.Select);
            ddlUploadType.SelectedIndex = 2;
            FillgvNotice();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        dt = new DataTable();
    }
    void clear()
    {
        txtAnnDate.Text = "";
        txtExpire.Text = "";
        txtHeading.Text = "";
        txtDesc.Text = "";
        dt.Clear();
        ViewState["dt"] = dt;
        ddlUploadType.SelectedIndex = 2;
        ddlNotice.SelectedIndex = ddlNoticeDisplay.SelectedIndex = 0;
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlNoticeDisplay);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlNotice);
        gvAdd.DataSource = "";
        gvAdd.DataBind();
    }
    void FillgvNotice()
    {
        dt = ObjAcaBll.GetNotice().Tables[0];
        ViewState["dt"] = dt;
        gvNotice.DataSource = dt;
        gvNotice.DataBind();
    }

    protected void gvNotice_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "Select")
        //{
        //    ViewState["ID"] = gvNotice.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString();
        //    ViewState["UID"] = gvNotice.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[1].ToString();
        //    dt = (DataTable)ViewState["dt"];
        //    DataRow[] dr = dt.Select("FILE_ID=" + ViewState["UID"].ToString());
        //    if (dr[0]["STS"].ToString() == "False")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
        //        return;
        //    }
        //    txtAnnDate.Text = dr[0]["NEWS_DT"].ToString();
        //    txtExpire.Text = dr[0]["EXPIRED_ON"].ToString();
        //    txtHeading.Text = dr[0]["NEWS_HEADING"].ToString();
        //    txtDesc.Text = dr[0]["NEWS_DESC"].ToString();
        //    FillFunction.Fill(ddlNoticeDisplay, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Notice_For), true, FillFunctions.FirstItem.Select);
        //    ddlNoticeDisplay.SelectedValue = dr[0]["DISPLAY"].ToString();
        //    FillFunction.Fill(ddlNotice, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Notice_Type, ddlNoticeDisplay.SelectedValue), true, FillFunctions.FirstItem.Select);
        //    ddlNotice.SelectedValue = dr[0]["NOTICE_FOR"].ToString();
        //    ShowNoticeData(dt);

        //}
        //else
        //{
        ObjAcaBal.ChangeStatus = e.CommandName;
        ObjAcaBal.Id = e.CommandArgument.ToString();
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjAcaBll.NoticeModify(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillgvNotice();
        //}
    }
    protected void ddlNoticeDisplay_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlNotice, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Notice_Type, ddlNoticeDisplay.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
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
            ROOT = xmlData.CreateElement("FILE");
            xmlData.AppendChild(ROOT);
        }

        bool add = true;
        XmlNodeList nodeList = xmlData.SelectNodes("FILE/UPLOAD/TYPE_ID");
        foreach (XmlNode node in nodeList)
        {
            if (node.InnerText == ddlUploadType.SelectedValue)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Selected Upload type already inserted')", true);
                add = false;
                break;
            }
        }
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("UPLOAD");
            ROOT.AppendChild(dataElement);
            XmlElement element = xmlData.CreateElement("TYPE_ID");
            element.InnerText = ddlUploadType.SelectedValue;
            dataElement.AppendChild(element);
            element = xmlData.CreateElement("TYPE_VALUE");
            element.InnerText = ddlUploadType.SelectedItem.Text;
            dataElement.AppendChild(element);
            Random ss=new Random();            
            if (txtView.PostedFile.FileName != null)
            {
                Extension = Path.GetExtension(txtView.PostedFile.FileName);
                Url = txtHeading.Text.Split(' ').GetValue(0).ToString() + "_" + ddlUploadType.SelectedValue + "_" +  ss.Next().ToString() + Extension;
                txtView.PostedFile.SaveAs(Server.MapPath("../UploadedFile/File/" + Url));
               
            }            
            element = xmlData.CreateElement("FILE_PATH");
            element.InnerText = Url.ToString();
            dataElement.AppendChild(element);
            TextBox1.Text = xmlData.OuterXml;
        }
        LoadData();
    }
    void LoadData()
    {
        if (TextBox1.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(TextBox1.Text));
            gvAdd.DataSource = dataSet.Tables[0];
            gvAdd.DataBind();
        }
        else
        {
            gvAdd.DataSource = "";
            gvAdd.DataBind();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjAcaBal.Id = ViewState["ID"].ToString();
        ObjAcaBal.File = TextBox1.Text;
        ObjAcaBal.Date = CommonFunction.GetDateTime(txtAnnDate.Text);
        ObjAcaBal.ToDate = CommonFunction.GetDateTime(txtExpire.Text);
        ObjAcaBal.Name = txtHeading.Text;
        ObjAcaBal.UseFor = ddlNoticeDisplay.SelectedValue;
        ObjAcaBal.Display = ddlNotice.SelectedValue;
        ObjAcaBal.Description = txtDesc.Text;
        ObjAcaBal.TypeId = ddlUploadType.SelectedValue;
        ObjAcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjAcaBll.NoticeInsertUpdate(ObjAcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillgvNotice();
        clear();
    }

    protected void gvAdd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(TextBox1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("FILE/UPLOAD");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            TextBox1.Text = xmlData.OuterXml;
        else
            TextBox1.Text = "";
        LoadData();
    }
    //public void ShowNoticeData(DataTable dt)
    //{

    //    StringWriter writer = new StringWriter();
    //    dt.WriteXml(writer);
    //    string xmlString = writer.GetStringBuilder().ToString();
    //    xmlString = xmlString.Replace("<NewDataSet>", "<FILE>");
    //    xmlString = xmlString.Replace("</NewDataSet>", "</FILE>");
    //    xmlString = xmlString.Replace("<Table2>", "<UPLOAD>");
    //    xmlString = xmlString.Replace("</Table2>", "</UPLOAD>");
    //    TextBox1.Text = xmlString;
    //    LoadData();

    //}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using System.IO;


public partial class Academic_ProgramMain : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    AcaBLL bll;
    AcaBAL bal;
    DataTable dt;
    static int count = 0;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        btnAddDegree.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            FillGrid(); count = 0;
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            trDegree.Visible = false;
            fill.Fill(ddlInstitute, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlProgramType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramType), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlDegreeType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DegreeType), true, FillFunctions.FirstItem.Select);
            fill.Fill(ddlDegreeType, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.DegreeType), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        bll = new AcaBLL();
        bal = new AcaBAL();
    }
    void FillGrid()
    {
        bal.InsId = ddlInstitute.SelectedValue;
        bal.ValueType = ddlProgramType.SelectedValue;
        bal.KeyID = ddlDegreeType.SelectedValue;
        dt = bll.ProgramSelect(bal).Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        bal.KeyID = ViewState["ID"].ToString();
        bal.FullName = txtFulltName.Text;
        bal.Name = txtShortName.Text;
        bal.ValueType = ddlInstitute.SelectedValue;
        bal.KeyValue = txtDuration.Text;
        bal.TypeId = ddlProgramType.SelectedValue;
        bal.CommonId = ddlDegreeType.SelectedValue;
        if (ddlDegreeType.SelectedValue == "1")
        {
            double endSem = Convert.ToInt32(txtDuration.Text) / 6;
            endSem = (endSem < 1) ? 1 : endSem;
            AddSingleDegree(1, Convert.ToInt32(endSem));
        }
        bal.Value = txt2.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.ProgramInsertUpdate(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        ViewState["dt"] = dt;
        trDegree.Visible = false;
        common.Clear(this);
        count = 0;
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("INS_PGM_ID=" + ViewState["ID"].ToString());
            if (dr[0]["PGM_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlInstitute.SelectedValue = dr[0]["INS_ID"].ToString();
            ddlProgramType.SelectedValue = dr[0]["PGM_TYPE_ID"].ToString();
            ddlDegreeType.SelectedValue = dr[0]["DGR_ID"].ToString();
            txtFulltName.Text = dr[0]["PGM_FULL_NAME"].ToString();
            txtShortName.Text = dr[0]["PGM_SHORT_NAME"].ToString();
            txtDuration.Text = dr[0]["PGM_DURATION"].ToString();
        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.ProgramModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }

    protected void ddlDegree_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDegreeType.SelectedValue == "2")
        {
            fill.Fill(ddlAttIns, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            trDegree.Visible = true;
            btnSave.Enabled = false;
        }
        else
        {
            btnSave.Enabled = true;
            trDegree.Visible = false;
        }
        FillGrid();
    }
    protected void btnAddDegree_Click(object sender, EventArgs e)
    {
        count++;
        if (count <= 2)
        {
            AddSingleDegree(Convert.ToInt32(txtSemesterFrom.Text), Convert.ToInt32(txtSemesterTo.Text));
            if (count == 2)
                btnSave.Enabled = true;
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Can not Inserted More Than 2 Program!')", true);
            ddlSingleDegree.SelectedIndex = 0;
            txtSemesterFrom.Text = txtSemesterTo.Text = "";
            return;
        }
    }
    void AddSingleDegree(int StartSem, int EndSem)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txt2.Text != "")
        {
            xmlData.LoadXml(txt2.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("PROGRAM");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;
        if (add)
        {

            for (int i = StartSem; i <= EndSem; i++)
            {
                XmlElement dataElement = xmlData.CreateElement("ATTACHEDDEGREE");
                ROOT.AppendChild(dataElement);
                XmlElement element = xmlData.CreateElement("INS_ID");
                element.InnerText = ddlInstitute.SelectedValue;
                dataElement.AppendChild(element);
                if (ddlDegreeType.SelectedValue == "2")
                {
                    element = xmlData.CreateElement("ATT_PRG_ID");
                    element.InnerText = ddlSingleDegree.SelectedValue;
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("ATT_PRG_VALUE");
                    element.InnerText = ddlSingleDegree.SelectedItem.Text;
                    dataElement.AppendChild(element);
                }
                else
                {
                    element = xmlData.CreateElement("ATT_PRG_ID");
                    element.InnerText = ddlDegreeType.SelectedValue;
                    dataElement.AppendChild(element);
                }
                element = xmlData.CreateElement("ACA_SEM_ID");
                element.InnerText = i.ToString();
                dataElement.AppendChild(element);
            }
            txt2.Text = xmlData.OuterXml;
            if (ddlDegreeType.SelectedValue == "2")
            {
                AddXmlData();
                ddlSingleDegree.SelectedIndex = 0;
            }
            common.Clear(CommonFunctions.ClearType.Value, ddlAttIns);
            txtSemesterFrom.Text = txtSemesterTo.Text = "";
        }
    }

    void AddXmlData()
    {
        if (txt2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txt2.Text));
            grdSemShow.DataSource = dataSet.Tables[0];
            grdSemShow.DataBind();
        }
        else
        {
            grdSemShow.DataSource = null;
            grdSemShow.DataBind();
        }
    }



    protected void grdSemShow_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txt2.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("PROGRAM/ATTACHEDDEGREE");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
            txt2.Text = xmlData.OuterXml;
        else
            txt2.Text = "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        AddXmlData();
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void ddlProgramType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void ddlAttIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill.Fill(ddlSingleDegree, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.ProgramByDegree, "1", ddlAttIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
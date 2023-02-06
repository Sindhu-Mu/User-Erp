using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Text;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    DataSet ds;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {
            fillfunction.Fill(ddlSession,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Session),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlInstitute, queryfunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            ViewState["DataKey"] = "0";

        }
       
        
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        ds = new DataSet();
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
       FillGrid();
      
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillfunction.Fill(ddlCourse, queryfunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns,ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlCourse.SelectedIndex > 0)
        {
            fillfunction.Fill(ddlBranch,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Branch,ddlCourse.SelectedValue),true,FillFunctions.FirstItem.Select);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        txtData.Text = "";
        foreach (GridViewRow itm in gvStudent.Rows)
        {
            CheckBox chk = (CheckBox)itm.FindControl("chk1");
            if (chk.Checked)
            {
                ADD(gvStudent.DataKeys[itm.RowIndex].Values[0].ToString(), itm.Cells[6].Text, itm.Cells[7].Text);
                ViewState["Datakey"] = gvStudent.DataKeys[itm.RowIndex].Values[0].ToString();
            }
            if (txtData.Text != "")
            {
                bllObj.Scho_Detail_Insert(txtData.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Scholarship Detail inserted successfully.')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select student from the grid.')", true);
            ddlSession.SelectedIndex = ddlInstitute.SelectedIndex = ddlCourse.SelectedIndex = ddlBranch.SelectedIndex = 0;
             FillGrid();
             txtRemark.Text = txtData.Text = "";
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["ds"];
        GridViewExportUtil.ExportFromDs("Scholarship.xls", ds);      
    }

  public void ADD(string STU_ADM_NO, string FEE_SCHO_PER, string FEE_SCHO_AMT)  
   //string FEE_SCHO_PER, string FEE_SCHO_AMT
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("SCHO");
            xmlData.AppendChild(ROOT);
        }
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("STU_ADM_NO");
        element.InnerText = STU_ADM_NO;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("SCHO_CRI_ID");
        element.InnerText = "4";
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("SESSION_ID");
        element.InnerText = ddlSession.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_SCHO_PER");
        element.InnerText = FEE_SCHO_PER;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_SCHO_AMT");
        element.InnerText = FEE_SCHO_AMT;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_SCHO_REMARK");
        element.InnerText = txtRemark.Text; ;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_SCHO_IN_BY");
        element.InnerText = Session["UserId"].ToString();
        dataElement.AppendChild(element);
        txtData.Text = xmlData.OuterXml;
    }

    public void FillGrid()
    {
        balObj.balSession = ddlSession.SelectedValue;
        balObj.balInsId = ddlInstitute.SelectedValue;
        balObj.balCourseId = ddlCourse.SelectedValue;
        balObj.balBranch = ddlBranch.SelectedValue;
        balObj.balPercentage = ddlPercentage.SelectedValue;
        ds = bllObj.GetSchoDetail(balObj);
        ViewState["ds"] = ds;
        gvStudent.DataSource = ds;
        gvStudent.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
            trSave.Visible = true;
        else
            trSave.Visible = false;
    }
}
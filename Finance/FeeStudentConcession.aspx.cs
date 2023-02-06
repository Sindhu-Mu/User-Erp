using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        btnShow.Attributes.Add("OnClick", "return valid()");
        
        if (!IsPostBack)
        {
        fillfunction.Fill(ddlInstitute,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Institution),true,FillFunctions.FirstItem.Select);
        fillfunction.Fill(ddlBatch,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Batch),true,FillFunctions.FirstItem.Select);
        fillfunction.Fill(ddlSession,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Session),true,FillFunctions.FirstItem.Select);
        trSave.Visible = false;
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
    }

    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlInstitute.SelectedIndex>0)
        {
        fillfunction.Fill(ddlCourse,queryfunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns,ddlInstitute.SelectedValue),true,FillFunctions.FirstItem.Select);
        }

    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlCourse.SelectedIndex>0)
        {
        fillfunction.Fill(ddlBranch,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Branch,ddlCourse.SelectedValue),true,FillFunctions.FirstItem.Select);
        }

    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
       
        FillGrid();
      
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        txtData.Text = "";
        foreach (GridViewRow itm in gvDetail.Rows)
        {
            CheckBox chk = (CheckBox)itm.FindControl("chk1");
            if (chk.Checked)
            {
                Add(gvDetail.DataKeys[itm.RowIndex].Values[0].ToString(), itm.Cells[8].Text);
            }
            if (txtData.Text != "")
            {
                
                bllObj.FeeConcessionInfoInsert(txtData.Text);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Concession Detail inserted successfully.')", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Select student from the grid.')", true);
            txtRemark.Text = txtData.Text = "";
          
        }
        FillGrid();

    }
    void Add(string STU_CONC_ID, string FEE_CONC_AMT)
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
            ROOT = xmlData.CreateElement("CONC");
            xmlData.AppendChild(ROOT);
        }
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("STU_CONC_ID");
        element.InnerText = STU_CONC_ID;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_CONC_AMT");
        element.InnerText = FEE_CONC_AMT;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_CONC_REMARK");
        element.InnerText = txtRemark.Text; ;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("FEE_CONC_IN_BY");
        element.InnerText = Session["UserId"].ToString();
        dataElement.AppendChild(element);
        txtData.Text = xmlData.OuterXml;
    
    }
    public void FillGrid()
    {
        balObj.balInsId = ddlInstitute.SelectedValue;
        balObj.balCourseId = ddlCourse.SelectedValue;
        balObj.balBranch = ddlBranch.SelectedValue;
        balObj.balBatchId = ddlBatch.SelectedValue;
        balObj.balSession = ddlSession.SelectedValue;
        if (balObj.balInsId == "." || balObj.balInsId == "")
        {
            balObj.balInsId = "0";

        }
        if (balObj.balCourseId == "." || balObj.balCourseId == "")
        {
            balObj.balCourseId = "0";
        }
        if (balObj.balBranch == "." || balObj.balBranch == "")
        {
            balObj.balBranch = "0";
        }
        if (balObj.balBatchId == "." || balObj.balBatchId == "")
        {
            balObj.balBatchId = "0";
        }
 
        dt = bllObj.GetFeeConcessionDetail(balObj);
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
        if (dt.Rows.Count > 0)
            trSave.Visible = true;
        else
            trSave.Visible = false;
    
    }
}
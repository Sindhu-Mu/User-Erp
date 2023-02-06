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
        
        if (!IsPostBack)
        {
            fillfunction.Fill(ddlInstitute,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Institution),true,FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlMainHead, queryfunction.GetCommand(QueryFunctions.QueryBaseType.MainHeadId), true, FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlSession,queryfunction.GetCommand(QueryFunctions.QueryBaseType.Session),true,FillFunctions.FirstItem.Select);
          
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
        if (ddlInstitute.SelectedIndex > 0)
        {
            fillfunction.Fill(ddlCourse, queryfunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
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
        btnAdjust.Visible = true;
        balObj.balInsId = ddlInstitute.SelectedValue;
        balObj.balCourseId = ddlCourse.SelectedValue;
        balObj.balBranch = ddlBranch.SelectedValue;
        balObj.balSession = ddlSession.SelectedValue;
        balObj.balMainHeadId = ddlMainHead.SelectedValue;
        balObj.balSemType = ddlSemType.SelectedValue;

        if (balObj.balInsId == ".")
        {
            balObj.balInsId = "0";

        }
        if (balObj.balCourseId == ".")
        {
            balObj.balCourseId = "0";

        }
        if (balObj.balBranch == ".")
        {
            balObj.balBranch= "0";

        }
        if (balObj.balSem == ".")
        {
            balObj.balSem = "0";

        }
        if (balObj.balMainHeadId == ".")
        {
            balObj.balMainHeadId = "0";

        }
        if(balObj.balSemType== ".")
        {
            balObj.balSemType = "0";
        }
        dt = bllObj.StuFinCreditAdjust(balObj);
        gvDetail.DataSource = dt;
        gvDetail.DataBind();
    }


    protected void btnAdjust_Click(object sender, EventArgs e)
    {
        add();
        balObj.balData = txtXML.Text;
        txtXML.Text = "";
        balObj.balSession = Session["UserId"].ToString();
        balObj.balMainHeadId = ddlMainHead.SelectedValue;
        bllObj.CreditAmountAdjustInsert(balObj);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Amount Adjusted.')", true);
    }
    public void add()
    {
        CheckBox chbk;
        TextBox txtAmount;
        XmlDocument XmlData = new XmlDocument();
        XmlElement Root;
        if (txtXML.Text != "")
        {
            XmlData.LoadXml(txtXML.Text);
            Root = XmlData.DocumentElement;
        }
        else
        {
            Root = XmlData.CreateElement("ORG");
            XmlData.AppendChild(Root);
        }
        foreach(GridViewRow row in gvDetail.Rows)
        {
             chbk =  (CheckBox)row.FindControl("chk");
             txtAmount = ((TextBox)row.FindControl("txtAdjustAmt"));
             String Enroll= row.Cells[1].Text;
             String Institute = row.Cells[3].Text;
             String Course= row.Cells[4].Text;
             String Sem = row.Cells[5].Text;
             String Branch = row.Cells[6].Text;
             String BalanceAmount = row.Cells[7].Text;
             String CreditBalAmt = row.Cells[8].Text;
             if (chbk.Checked)
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);
                XmlElement element = XmlData.CreateElement("FEE_DEMAND_ID");
                element.InnerText = gvDetail.DataKeys[row.RowIndex].Value.ToString();
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("ADJUST_AMT");
                element.InnerText = txtAmount.Text;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("ENROLLMENT");
                element.InnerText = Enroll;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("INSTITUTE");
                element.InnerText = Institute;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("COURSE");
                element.InnerText = Course;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("SEM");
                element.InnerText = Sem;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("BRANCH");
                element.InnerText = Branch;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("BALANCE_AMOUNT");
                element.InnerText = BalanceAmount;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("CREDIT_BALANCE_AMOUNT");
                element.InnerText = CreditBalAmt;
                dataElement.AppendChild(element);
                txtXML.Text = XmlData.OuterXml;
            }
        }
    }
}
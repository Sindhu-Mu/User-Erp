using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.IO;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    Messages msg;
   
    protected void Page_Load(object sender, EventArgs e)
    {
       
        Initialize();
        
        if (!IsPostBack)
        {
            LoadData();
        }
       
        
    }
    void LoadData()
    {
        glb_ff.Fill(ddlSem, glb_qf.GetCommand(QueryFunctions.QueryBaseType.Semester), true, FillFunctions.FirstItem.Select);
        glb_ff.Fill(ddlGroupHead, glb_qf.GetCommand(QueryFunctions.QueryBaseType.GroupHeadId),true,FillFunctions.FirstItem.Select);
      

    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        msg = new Messages();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnrollment.Text);
        ddlBranch.Items.Clear();
        if (ddlBranch.Items.Count == 0)
        {
            glb_ff.Fill(ddlBranch, glb_qf.GetCommand(QueryFunctions.QueryBaseType.StuBranch, txtEnrollment.Text), true, FillFunctions.FirstItem.Select);
            ddlBranch.SelectedIndex = 1;
        }
        balObj.balEnrollment=txtEnrollment.Text;
        balObj.balBranchId=ddlBranch.SelectedValue;
        balObj.balSem=ddlSem.SelectedValue;
        DataSet ds = bllObj.StudentWaveHeadSelect(balObj);
        gvData.DataSource = ds.Tables[0];
        ViewState["demand_id"] = ds.Tables[1].Rows[0][0].ToString();
        gvData.DataBind();
        ViewState["ds"] = ds;

      
    }
    protected void gvData_SelectedIndexChanged(object sender, EventArgs e)
    {
        //String a=e.Row.Cells[0].Text.ToString();
        //String b=a;
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
            ROOT = xmlData.CreateElement("ORG");
            xmlData.AppendChild(ROOT);
        }
        
        XmlElement dataElement = xmlData.CreateElement("DATA");
        ROOT.AppendChild(dataElement);
        XmlElement element = xmlData.CreateElement("HEAD_ID");
        element.InnerText = ddlHead.SelectedValue;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("AMOUNT");
        element.InnerText = txtAmount.Text;
        dataElement.AppendChild(element);
        element = xmlData.CreateElement("HEAD_MAIN_VALUE");
        element.InnerText = ddlHead.SelectedItem.Text;
        dataElement.AppendChild(element); 
        txtXML.Text = xmlData.OuterXml;        
        AddXmlData();
    }
    void AddXmlData()
    {
        if (txtXML.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txtXML.Text));
            if (dataSet.Tables.Count > 0)
            {
                gv_Data.DataSource = dataSet.Tables[0];
            }
            else
            {
                gv_Data.DataSource = null;
                txtXML.Text = "";
            }
            gv_Data.DataBind();
           

        }
        else
        {
            gv_Data.DataSource = null;
            gv_Data.DataBind();
        }
    }

    protected void add_Click(object sender, EventArgs e)
    {
        Add();
    }
    protected void ddlHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt16(ddlType.SelectedValue)> 0)
        {
            DataTable temp_dt = new DataTable();
            temp_dt = ((DataSet)ViewState["ds"]).Tables[0];
            DataRow dr = (temp_dt.Select("FEE_MAIN_HEAD_ID=" + ddlHead.SelectedValue))[0];
            txtAmount.Text = ((Convert.ToDecimal(txtValue.Text) / 100) * Convert.ToDecimal(dr["FD_FEE_AMT"].ToString())).ToString();
         }
        else
        {
           
            txtAmount.Text = txtValue.Text;
            
        }

        ddlType.SelectedIndex = 0;
    }

    protected void gv_Data_SelectedIndexChanged(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ORG/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        txtXML.Text = xmlData.OuterXml;
        AddXmlData();

    }


    protected void gv_Data_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txtXML.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("ORG/DATA");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        txtXML.Text = xmlData.OuterXml;
        AddXmlData();

    }
    protected void btnInsert_Click(object sender, EventArgs e)
    {
        balObj.balData = txtXML.Text;
        balObj.balSession = Session["UserId"].ToString();
        balObj.balDate = txtDepositDate.Text;
        balObj.balReason = txtRemark.Text;
        balObj.balEmpName = txtApproveBy.Text;
        balObj.balDemandId = ViewState["demand_id"].ToString();
        try
        {
            bllObj.StudentFeeWave(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Fee Waive Inserted Successfully')", true);
            clear();
        }
        catch(Exception abc)
        {
        }       
    }

    void clear()
    {
        gvData.DataSource = "";
        gvData.DataBind();
        gv_Data.DataSource = "";
        gv_Data.DataBind();
        ddlBranch.SelectedIndex = ddlGroupHead.SelectedIndex = ddlHead.SelectedIndex = ddlSem.SelectedIndex = ddlType.SelectedIndex = 0;
        txtAmount.Text = txtApproveBy.Text = txtDepositDate.Text = txtEnrollment.Text = txtRemark.Text = txtValue.Text = "";
    }

    protected void ddlGroupHead_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlGroupHead.SelectedIndex > 0)
        {
            glb_ff.Fill(ddlHead, glb_qf.GetCommand(QueryFunctions.QueryBaseType.FineHeads,ddlGroupHead.SelectedValue), true, FillFunctions.FirstItem.Select);
  
        }

    }
}
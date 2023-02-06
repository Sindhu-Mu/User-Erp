using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;

public partial class PayRoll_MonthlyCugBill : System.Web.UI.Page
{
    
    PRBAL prbal;
    PRBLL prbll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {    
        Initialisation();
        if (!IsPostBack)
        {
        }

    }
    private void Initialisation()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        dt = new DataTable();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
       // trDetail.Visible = true; trInsert.Visible = false;
        btnSave.Visible = false;
       gvAllowance.Visible = false; gvBill.Visible = true; 
        DropDownList ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
        prbal.balMonth=ddlMonth.SelectedValue;
        prbal.balYear=ddlYear.SelectedValue;
        dt = prbll.GetBillDetail(prbal); 
        gvBill.DataSource = dt;
        gvBill.DataBind();
    }
    protected void btnEntry_Click(object sender, EventArgs e)
    {
        //trDetail.Visible = false; trInsert.Visible = true;
        btnSave.Visible = true;
        gvAllowance.Visible = true; gvBill.Visible = false; 
        DropDownList ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
        prbal.balMonth = ddlMonth.SelectedValue;
        prbal.balYear = ddlYear.SelectedValue;
        dt = prbll.GetBillEntry(prbal); 
        gvAllowance.DataSource = dt;
        gvAllowance.DataBind();
    }
    void Add()
    {
        TextBox txtBillAmount;

        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("MONTH");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in gvAllowance.Rows)
        {
            txtBillAmount = (TextBox)row.FindControl("txtBillAmount");
            if (txtBillAmount.Text != "")
            {
                XmlElement dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);
                XmlElement element = xmlData.CreateElement("EMP_CODE");
                element.InnerText = row.Cells[1].Text;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("HEAD_VALUE");
                element.InnerText = txtBillAmount.Text;
                dataElement.AppendChild(element);
                element = xmlData.CreateElement("TRAN_REMARKS");
                element.InnerText = "Cug Bill";
                dataElement.AppendChild(element);
                txtData.Text = xmlData.OuterXml;
            }
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
        Add();
        if (txtData.Text.Length > 1)
        {
            prbal.balHeadId ="20";
            prbal.balMonth=ddlMonth.SelectedValue;
            prbal.balYear=ddlYear.SelectedValue;
            prbal.balData = txtData.Text;
            prbal.balCurEmpCode=Session["LoginId"].ToString();
            int status=prbll.BillInsert(prbal);
            if (status > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Monthly Telephone bill submitted Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Error In Update')", true);
            }
            txtEmpCode.Text = "";
           // gvBill.DataSource = "";
          //  gvBill.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;

public partial class PayRoll_Arrear : System.Web.UI.Page
{
    PRBAL prbal;
    PRBLL prbll;
    CommonFunctions cf;
    string arrear_type = "";
    double amount = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialization();

    }
    public void Initialization()
    {
        prbal = new PRBAL();
        prbll = new PRBLL();
        cf = new CommonFunctions();
    }
    protected void btnDetail_Click(object sender, EventArgs e)
    {
        String empcode = cf.GetKeyID(txtEmp);
        DropDownList ddlMM = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear.FindControl("ddlYear");
        string yy = "";
        string mm = "";
        string dd = "30";
        String date = "";
        arrear_type = ddlArrearType.Text;

        yy = ddlYY.SelectedValue;
        mm = ddlMM.SelectedValue;
        date = mm + "/" + dd + "/" + yy;
        prbal.balEmpCode = empcode;
        prbal.balMonth = date;
        prbal.balArrearType = arrear_type;
        makeDataSet();

    }
    protected void makeDataSet()
    {
        DataTable dt = new DataTable();
        dt = prbll.GetArrear(prbal);
        gvTranDetail.DataSource = dt;
        gvTranDetail.DataBind();
    }
    public void add()
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
            Root = XmlData.CreateElement("ORG");
            XmlData.AppendChild(Root);
        }

        foreach (GridViewRow row in gvTranDetail.Rows)
        {
            CheckBox chkBx = (CheckBox)row.FindControl("chkBox");
            TextBox txtAmount = (TextBox)row.FindControl("txtAmount");
            TextBox txtRemark = (TextBox)row.FindControl("txtRemark");


            if (chkBx != null && chkBx.Checked)
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);

                XmlElement element = XmlData.CreateElement("EMP_CODE");
                element.InnerText = row.Cells[1].Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("EMP_NAME");
                element.InnerText = row.Cells[2].Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("MONTH");
                element.InnerText = row.Cells[3].Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("YEAR");
                element.InnerText = row.Cells[4].Text;
                dataElement.AppendChild(element);

                element = XmlData.CreateElement("AMOUNT");
                element.InnerText = txtAmount.Text;
                dataElement.AppendChild(element);
                amount = amount + Convert.ToDouble(txtAmount.Text);

                element = XmlData.CreateElement("REMARK");
                element.InnerText = txtRemark.Text;
                dataElement.AppendChild(element);


                txtXML.Text = XmlData.OuterXml;

            }
        }

        arrear_type = ddlArrearType.SelectedValue;

    }

    public void addDataToDb()
    {
        //  String query = "exec ADD_ARREAR '" + xml + "','" + emp_cod_in + "','" + arrear_type+"'";
        prbal.balData = txtXML.Text;
        prbal.balCurEmpCode = Session["Login_id"].ToString();
        prbal.balArrearType = arrear_type;
        prbal.balAmt = Convert.ToString(amount);
        prbal.balEmpCode = cf.GetKeyID(txtEmp);
        prbll.AddArrear(prbal);
        txtXML.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        add();
        addDataToDb();
        txtXML.Text = "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Inserted Successfully')", true);
    }
}
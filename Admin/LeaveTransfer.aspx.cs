using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
public partial class Admin_LeaveTransfer : System.Web.UI.Page
{
    USRBAL ObjUsrBal;
    USRBLL ObjUsrBll;
    CommonFunctions CommonFunction;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        
        btnTransfer.Attributes.Add("Onclick", "return validationSave()");
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlIns, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlPending, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PendingWith), true, FillFunctions.FirstItem.Select);

        }
    }
    void Initialize()
    {
        ObjUsrBal = new USRBAL();
        ObjUsrBll = new USRBLL();
        CommonFunction = new CommonFunctions();
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
    }

    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlIns.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
            trTransfer.Visible = trGrid.Visible = false;

        }
        else
            ddlDept.Items.Clear();
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        DropDownList ddlMM = (DropDownList)MonthYear1.FindControl("ddlMonth");
        DropDownList ddlYY = (DropDownList)MonthYear1.FindControl("ddlYear");
        ObjUsrBal.InsID = ddlIns.SelectedValue;
        ObjUsrBal.KEYID = ddlDept.SelectedValue;
        ObjUsrBal.KEYVALUE = ddlPending.SelectedItem.ToString();
        ObjUsrBal.Value1 = ddlMM.SelectedValue;
        ObjUsrBal.Value2 = ddlYY.SelectedValue;
        gvDetail.DataSource = ObjUsrBll.GetPendingLeave(ObjUsrBal).Tables[0];
        gvDetail.DataBind();
        trGrid.Visible = true;
        if (gvDetail.Rows.Count > 0)
            trTransfer.Visible = true;
    }
    void ADD()
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
            ROOT = xmlData.CreateElement("ROLE");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow row in gvDetail.Rows)
        {
            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("TRANSFER_TO");
            element.InnerText = ddlTransfer.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("PENDING_WITH");
            element.InnerText = ddlPending.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("KEY_ID");
            element.InnerText = gvDetail.DataKeys[row.RowIndex].Value.ToString();
            dataElement.AppendChild(element);
        }
        TextBox1.Text = xmlData.OuterXml;
    }


    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        ADD();
        ObjUsrBal.XmlValue = TextBox1.Text;
        ObjUsrBal.USRID = Session["UserId"].ToString();
        ObjUsrBll.LeaveTransfer(ObjUsrBal);
        ddlPending.SelectedIndex = ddlTransfer.SelectedIndex = ddlIns.SelectedIndex = ddlDept.SelectedIndex = 0;
        trTransfer.Visible = trGrid.Visible = false;
        TextBox1.Text = "";
    }
    protected void ddlPending_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlPending.SelectedIndex > 0)
        {
            fillFunctions.Fill(ddlTransfer, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Transfer, ddlPending.SelectedValue), true, FillFunctions.FirstItem.Select);
            trTransfer.Visible = trGrid.Visible = false;
        }
        else
            ddlTransfer.Items.Clear();
    }
    protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDept.SelectedIndex > 0)
            trTransfer.Visible = trGrid.Visible = false;
    }
}
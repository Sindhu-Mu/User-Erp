using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

public partial class HR_EmpDocMain : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjHrBAL;
    string Msg;
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBAL = new HRBAL();

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.MaintainScrollPositionOnPostBack = true;
        Initialize();
        btnShow.Attributes.Add("OnClick", "return validat()");
        if (!IsPostBack)
        {
            if (txtEmp.Text != "")
            {
                ViewState["Emp"] = commonFunctions.GetKeyID(txtEmp);
            }
            ViewState["Type"] = "0";
            fillfunction.Fill(ddlDocument, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.DocumentType), true, FillFunctions.FirstItem.Select);
            btnSave.Enabled = trAdd.Visible = false;
        }
    }

    void FillGrid()
    {
        RadioButtonList RB;
        ViewState["Emp"] = commonFunctions.GetKeyID(txtEmp);
        ObjHrBAL.EmpId = ViewState["Emp"].ToString();
        Employee1.ShowEmployeeInfo(ObjHrBAL.EmpId);
        dt = ObjHrBll.EmpDocSelect(ObjHrBAL);
        int flag = 1;
        if (dt.Rows.Count > 0)
        {
            gvDocument.DataSource = dt;
            gvDocument.DataBind();
            foreach (GridViewRow itm in gvDocument.Rows)
            {
                RB = (RadioButtonList)gvDocument.Rows[itm.RowIndex].FindControl("Rlist1");
                RB.SelectedValue = dt.Rows[itm.RowIndex]["DOC_STS"].ToString();
                if (RB.SelectedValue == "False")
                {
                    flag = 0;
                }
            }
            if ( (dt.Rows[0]["STS"].ToString()=="3"))
            {
                if (((dt.Rows[0]["DOC_DTL_ID"].ToString() == "0") && (flag == 0)))
                {
                    ViewState["Type"] = "1";
                }
                trAdd.Visible = btnLeave.Visible = true;
            }
            else
            {
                ViewState["Type"] = "0";
                trAdd.Visible = btnLeave.Visible = false;
            }
            gvDocument.Columns[6].Visible = true; gvDocument.Columns[7].Visible = true;
        }
        btnSave.Enabled = (gvDocument.Rows.Count > 0) ? true : false;
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {

        FillGrid();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjHrBAL.EmpId = ViewState["Emp"].ToString();
        ObjHrBAL.TypeId = ddlDocument.SelectedValue;
        if (ObjHrBll.EmpDocCheck(ObjHrBAL) == "0")
        {
            ObjHrBAL.Description = txtDocRemark.Text;
            ObjHrBAL.ChangeStatus = ddlStatus.SelectedValue;
            ObjHrBAL.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.EmpDocDetailAdd(ObjHrBAL);
            FillGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Document already in Employee Document list.')", true);
            return;
        }
        ddlDocument.SelectedIndex = ddlStatus.SelectedIndex = 0;
        txtDocRemark.Text = "";
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        
        Add(ViewState["Type"].ToString());
        ObjHrBAL.TypeId = ViewState["Type"].ToString();
        ObjHrBAL.Value1 = txtData.Text;
        ObjHrBAL.EmpId = ViewState["Emp"].ToString();
        Msg = ObjHrBll.EmpDocDetailFirstInsert(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
        btnSave.Enabled = trAdd.Visible = true;
    }

    protected void gvDocument_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjHrBAL.ChangeStatus = e.CommandName;
        ObjHrBAL.KeyID = e.CommandArgument.ToString();
        Msg = ObjHrBll.EmpDocChangeStatus(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
    }
    void Add(string flag)
    {
        txtData.Text = "";
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txtData.Text != "")
        {
            xmlData.LoadXml(txtData.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("DOC");
            xmlData.AppendChild(ROOT);
        }
        RadioButtonList RB;
        TextBox txtRemark;
        CheckBox ChSelect;
        foreach (GridViewRow itm in gvDocument.Rows)
        {
            ChSelect = (CheckBox)gvDocument.Rows[itm.RowIndex].FindControl("ChSelect");
            if (flag == "1" && (ChSelect.Checked == false))
                continue;
            RB = (RadioButtonList)gvDocument.Rows[itm.RowIndex].FindControl("Rlist1");
            txtRemark = (TextBox)gvDocument.Rows[itm.RowIndex].FindControl("txtRemark");

            XmlElement dataElement = xmlData.CreateElement("DATA");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("EMP");
            element.InnerText = ViewState["Emp"].ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("DOC");
            element.InnerText = gvDocument.DataKeys[itm.RowIndex].Values[0].ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("REMARK");
            element.InnerText = txtRemark.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("STS");
            element.InnerText = RB.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("IN_B");
            element.InnerText = Session["UserId"].ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("DOC_DTL");
            element.InnerText = gvDocument.DataKeys[itm.RowIndex].Values[1].ToString();
            dataElement.AppendChild(element);
            txtData.Text = xmlData.OuterXml;

        }
    }
    protected void btnLeave_Click(object sender, EventArgs e)
    {
        ObjHrBAL.EmpId = ViewState["Emp"].ToString();
        Msg = ObjHrBll.EmpLeaveOpenForDoc(ObjHrBAL);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        btnLeave.Visible = false;
    }
}
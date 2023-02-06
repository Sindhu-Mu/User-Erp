using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;
public partial class Admin_RoleMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    string Msg;
    DataTable dt;
    USRBLL ObjUsrBll;
    USRBAL ObjUsrBal;
    private void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjUsrBll = new USRBLL();
        ObjUsrBal = new USRBAL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAssign.Attributes.Add("onclick", "return Menuvalidation()");
        btnUserRole.Attributes.Add("onclick", "return Uservalidation()");
        btnSave.Attributes.Add("onclick", "return Rolevalidation()");
        btnShow.Attributes.Add("onclick", "return Viewvalidation()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            TabContainer1.ActiveTabIndex = 1;
            FillFunction.Fill(ddlRole, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Role), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlMenu, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuHead), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
    {
        ViewState["ID"] = "";
        if (TabContainer1.ActiveTabIndex == 0)
        {
            FillFunction.Fill(ddlRightType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Authority), true, FillFunctions.FirstItem.Select);
            FillRoleGrid();
        }
        else if (TabContainer1.ActiveTabIndex == 1)
        {
            FillFunction.Fill(ddlRole, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Role), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlMenu, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MenuHead), true, FillFunctions.FirstItem.Select);
            gvMenuPage.DataSource = "";
            gvMenuPage.DataBind();
        }
        else
        {
            FillFunction.Fill(ddlUserType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.UserType), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlUserRole, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Role), true, FillFunctions.FirstItem.Select);
        }
    }
    private void FillRoleGrid()
    {
        dt = ObjUsrBll.RoleSelect().Tables[0];
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjUsrBal.KEYID = ViewState["ID"].ToString();
        ObjUsrBal.KEYVALUE = txtRoleName.Text;
        ObjUsrBal.KEYTYPEID = ddlRightType.SelectedValue;
        ObjUsrBal.USRID = Session["UserId"].ToString();
        Msg = ObjUsrBll.RoleInsertUpdate(ObjUsrBal);
        common.Clear(this);
        FillRoleGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("ROLE_ID =" + ViewState["ID"].ToString());
            if (dr[0]["ROLE_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtRoleName.Text = dr[0]["ROLE_VALUE"].ToString();
            ddlRightType.SelectedValue = dr[0]["AUTHORITY_ID"].ToString();
        }
        else
        {
            ObjUsrBal.CHTYPE = e.CommandName;
            ObjUsrBal.KEYID = e.CommandArgument.ToString();
            ObjUsrBal.USRID = Session["UserId"].ToString();
            Msg = ObjUsrBll.RoleModify(ObjUsrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillRoleGrid();
        }
    }

    void FillPageGrid()
    {
        ObjUsrBal.KEYID = ddlMenu.SelectedValue;
        ObjUsrBal.KEYTYPEID = ddlRole.SelectedValue;
        gvMenuPage.DataSource = ObjUsrBll.GETMENUPAGES(ObjUsrBal).Tables[0];
        gvMenuPage.DataBind();
        CheckBox ch;
        foreach (GridViewRow itm in gvMenuPage.Rows)
        {
            ch = (CheckBox)itm.FindControl("chk");
            ch.Checked = Convert.ToBoolean(gvMenuPage.DataKeys[itm.RowIndex].Values[1].ToString());

        }
    }
    protected void ddlMenu_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMenu.SelectedIndex > 0)
            FillPageGrid();
        else
        {
            gvMenuPage.DataSource = "";
            gvMenuPage.DataBind();
        }
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        Add();
        ObjUsrBal.KEYID = ddlRole.SelectedValue;
        ObjUsrBal.KEYTYPEID = ddlMenu.SelectedValue;
        ObjUsrBal.KEYVALUE = txtXML.Text;
        Msg = ObjUsrBll.RoleMenuInsert(ObjUsrBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
        common.Clear(this);
        txtXML.Text = "";
        gvMenuPage.DataSource = "";
        gvMenuPage.DataBind();
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
            ROOT = xmlData.CreateElement("MENU");
            xmlData.AppendChild(ROOT);
        }
        foreach (GridViewRow itm in gvMenuPage.Rows)
        {
            CheckBox chkSelect = (CheckBox)gvMenuPage.Rows[itm.RowIndex].FindControl("chk");
            if (chkSelect.Checked)
            {
                XmlElement dataElement = xmlData.CreateElement("PAGE");
                ROOT.AppendChild(dataElement);
                XmlElement element = xmlData.CreateElement("PAGE_ID");
                element.InnerText = gvMenuPage.DataKeys[itm.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);
            }
        }
        txtXML.Text = xmlData.OuterXml;
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        FillUserRoleGrid();
    }
    void FillUserRoleGrid()
    {
        ObjUsrBal.USRID = common.GetKeyID(txtUser);
        ObjUsrBal.KEYTYPEID = ddlUserType.SelectedValue;
        gvUserRole.DataSource = ObjUsrBll.GETUSERROLES(ObjUsrBal).Tables[0];
        gvUserRole.DataBind();
    }
    protected void btnUserRole_Click(object sender, EventArgs e)
    {
        ObjUsrBal.USRID = common.GetKeyID(txtUser);
        ObjUsrBal.KEYTYPEID = ddlUserType.SelectedValue;
        ObjUsrBal.KEYID = ddlUserRole.SelectedValue;
        ObjUsrBal.LOGINID = Session["UserId"].ToString();
        Msg = ObjUsrBll.UserRoleInsert(ObjUsrBal);
        common.Clear(this);
        FillUserRoleGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }
    protected void gvUserRole_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ObjUsrBal.KEYID = gvUserRole.DataKeys[e.RowIndex].Value.ToString();
        ObjUsrBal.USRID = Session["UserId"].ToString();     
        Msg = ObjUsrBll.UserRoleDelete(ObjUsrBal);
        common.Clear(this);
        FillUserRoleGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }
}

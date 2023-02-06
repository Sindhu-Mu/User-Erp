using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class Inventory_VendorReg : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DataTable dt;
    DatabaseFunctions databaseFunctions;
    void Initialize()
    {
        databaseFunctions = new DatabaseFunctions();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        dt = new DataTable();
    }
    protected void Page_Load(Object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlOrgMainDomain, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objBal.StoreName = ddlStore.SelectedValue;
        objBal.OrgName = txtOrgName.Text;
        objBal.Address = address.GetXML;
        objBal.OrgMobNo = txtOrgMobileNo.Text;
        objBal.OrgTelNo = txtOrgPhone.Text;
        objBal.EmailId = txtOrgMail.Text + ddlOrgMainDomain.SelectedItem;
        string msg = objBll.InsertVendorShort(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
    }
}
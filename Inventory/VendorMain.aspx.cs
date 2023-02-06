using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
public partial class Inventory_VendorMain : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            newVendorWizard.ActiveStepIndex = 0;
            ViewState["ID"] = "";
            PushData();            
        }
    }
    private void PushData()
    {
        fillFunctions.Fill(ddlStore, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlBank, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Bank), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlItemCat, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.INV_CATEGORY), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddlOrgMainDomain, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
        fillFunctions.Fill(ddl_CPMailDomain, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
        
    }
   
   

   /* public string UploadedDocument()
    {
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/VendorDocument/" + ViewState["VID"].ToString()));
        if (folders.Exists == false)
            folders.Create();
        ext = System.IO.Path.GetExtension(upload_Doc.PostedFile.FileName);
        if ((ext != ".doc") && (ext != ".pdf") && (ext != ".docx"))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Upload Appropriate File like .doc,.docx,.pdf file')", true);
            upload_Doc.Focus();
        }
        string url = "../UploadedFile/Office/" + ViewState["VID"].ToString() + "/" + txtDocName.Text + "." + ext;
        upload_Doc.PostedFile.SaveAs(Server.MapPath("../UploadedFile/VendorDocument/" + ViewState["VID"].ToString() + "/" + txtDocName.Text + "." + ext));
        txtDocName.Text = upload_Doc.Value = "";
        return url;
    }*/


    protected void newVendorWizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        txtXML.Text = "";
        XmlDocument XmlData = new XmlDocument();
        XmlElement Root= XmlData.CreateElement("ORG");        
        XmlData.AppendChild(Root);        
        for (int i = 0; i < ChListOrgType.Items.Count; i++)
        {
            if (ChListOrgType.Items[i].Selected)
            {
                XmlElement dataElement = XmlData.CreateElement("DATA");
                Root.AppendChild(dataElement);

                XmlElement element = XmlData.CreateElement("ORG_TYPE_ID");
                element.InnerText = ChListOrgType.Items[i].Value;
                dataElement.AppendChild(element);
                element = XmlData.CreateElement("ORG_TYPE_DESC");
                element.InnerText = ChListOrgType.Items[i].Text;
                dataElement.AppendChild(element);
                txtXML.Text = XmlData.OuterXml;
            }
        }
        objBal.VenId = ViewState["ID"].ToString();
        objBal.ID = ddlStore.SelectedValue;
        objBal.OrgName = txtOrgName.Text;
        objBal.TypeDescription=txtXML.Text;
        objBal.Address = ctrlAddress.GetXML;        
        objBal.PanNo = txtPanNo.Text;
        objBal.VatNo = txtVAT.Text;
        objBal.TinNo = txtTIN.Text;
        objBal.Excise_Reg_No = txtEXT.Text;
        objBal.Service_Tax_No = txtTax.Text;
        objBal.TurnOver = txtTurnover.Text;
        objBal.FinYear = txtFinYear.Text;     
        objBal.KeyId= ddlBank.SelectedValue;
        objBal.AcNo = txtAccountNo.Text;
        objBal.Branch = txtBankAddress.Text;
        objBal.Typ = ddlType.SelectedItem.Text;
        objBal.IfscCode = txtIFSC.Text;
        objBal.RtgsCode = txtRTGS.Text;
        objBal.OrgMobNo = txtOrgMobileNo.Text;
        objBal.OrgTelNo = txtOrgPhone.Text;
        objBal.OrgMailId = txtOrgMail.Text+ddlOrgMainDomain.SelectedItem.Text;
        objBal.Name = txtName.Text;       
        objBal.MobNo = txt_CPMobileNo.Text;     
        objBal.MobNo = txt_CPMobileNo.Text;
        objBal.EmailId = txt_CPMailId.Text + ddl_CPMailDomain.SelectedItem.Text;
        objBal.Designation = txtDesig.Text;
        objBal.Description = txtItemDesc.Text;
        objBal.ItemName = ddlItemCat.SelectedValue;
        objBal.Description = txtItemDesc.Text;
        objBal.DocName = txtDocName.Text;
        objBal.Path ="path";   
        objBal.SessionUserId = Session["UserId"].ToString();
        string msg = objBll.VendorInsertUpdate(objBal);
        ViewState["ID"] = "";
        txtXML.Text = "";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        clear();
        
     }
    private void clear()
    {
        txt_CPMailId.Text = txt_CPMobileNo.Text = txtAccountNo.Text = txtBankAddress.Text = txtDesig.Text = txtDocName.Text = txtEXT.Text = txtFinYear.Text = txtIFSC.Text = "";
        txtItemDesc.Text = txtName.Text = txtOrgMail.Text = txtOrgMobileNo.Text = txtOrgName.Text = txtOrgPhone.Text = txtPanNo.Text = txtRTGS.Text = txtTax.Text = txtTIN.Text = txtTurnover.Text = txtVAT.Text = txtVendor.Text = txtXML.Text = "";
        ddl_CPMailDomain.SelectedIndex = ddlBank.SelectedIndex = ddlItemCat.SelectedIndex = ddlOrgMainDomain.SelectedIndex = ddlStore.SelectedIndex = ddlType.SelectedIndex = 0;
        ChListOrgType.SelectedIndex = 0;
    }
 
}

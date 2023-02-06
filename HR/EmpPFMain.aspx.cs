using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Xml;
using System.IO;

public partial class HR_EmpPFMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    DatabaseFunctions databaseFunctions;
    Messages msg;
    HRBLL bll;
    DataTable dt;
    HRBAL bal;
    int sum = 0;
    int value = 0;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnsave.Attributes.Add("onclick", "return Employee()");
        btnAddFmly.Attributes.Add("onclick", "return Family()");
        btnAddNomi.Attributes.Add("onclick", "return Nominee()");
        btnAddFamily2.Attributes.Add("onclick", "return Family2()");
        btnAddNomi2.Attributes.Add("onclick", "return Nominee2()");
        btnEnd.Attributes.Add("onclick", "return EmployeeEnd()");
        btnView.Attributes.Add("onclick", "return EmployeeID()");
        btn.Attributes.Add("onclick", "return EmployeeNew()");
        if (!IsPostBack)
        {
            FillDropDown();
        }
        NewEmployee.Visible = false;
        Update.Visible = false;
        txt1.Visible = txt2.Visible = btnActiveAcc.Visible = txtUpdateLeft.Visible = false;
    }
    public void FillDropDown()
    {
        FillFunction.Fill(ddlFmlyRelation2, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlNomiRelation2, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlFmlyRelation, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlNomiRelation, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlEmpID, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlEmpIDEnd, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
    }
    public void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new HRBLL();
        bal = new HRBAL();
        databaseFunctions = new DatabaseFunctions();
    }
    private void AddFamily()
    {
        XmlDocument xml = new XmlDocument();
        XmlElement root;
        if (txt1.Text != "")
        {
            xml.LoadXml(txt1.Text);
            root = xml.DocumentElement;
        }
        else
        {
            root = xml.CreateElement("EPF");
            xml.AppendChild(root);
        }
        bool add = true;
        if (add)
        {
            XmlElement dataElement = xml.CreateElement("FAMILY");
            root.AppendChild(dataElement);

            XmlElement element = xml.CreateElement("FMLY_ID");
            element.InnerText = gvFamily.DataSourceID.ToString();
            dataElement.AppendChild(element);

            element = xml.CreateElement("FMLY_MEM_NAME");
            element.InnerText = txtFmlyName.Text;
            dataElement.AppendChild(element);

            element = xml.CreateElement("FMLY_MEM_ADRS");
            element.InnerText = txtFmlyAdrs.Text;
            dataElement.AppendChild(element);

            element = xml.CreateElement("FMLY_MEM_DOB");
            element.InnerText = txtFmlyDOB.Text;
            dataElement.AppendChild(element);

            element = xml.CreateElement("RELATION_ID");
            element.InnerText = ddlFmlyRelation.SelectedValue;
            dataElement.AppendChild(element);

            element = xml.CreateElement("RELATION_NAME");
            element.InnerText = ddlFmlyRelation.SelectedItem.ToString();
            dataElement.AppendChild(element);

            txt1.Text = xml.OuterXml;

            AddXml();
            txtFmlyName.Text = txtFmlyAdrs.Text = txtFmlyDOB.Text = "";
            ddlFmlyRelation.SelectedIndex = 0;
            txtFmlyName.Focus();
        }
    }
    void AddXml()
    {
        if (txt1.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txt1.Text));
            gvFamily.DataSource = dataSet.Tables[0];
            gvFamily.DataBind();
        }
        else
        {
            gvFamily.DataSource = "";
            gvFamily.DataBind();
        }
    }
    protected void btnAddFmly_Click(object sender, EventArgs e)
    {
        AddFamily();
    }
    void AddXmlData()
    {
        if (txt2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txt2.Text));
            gvNominee.DataSource = dataSet.Tables[0];
            gvNominee.DataBind();
        }
        else
        {
            gvNominee.DataSource = null;
            gvNominee.DataBind();
        }
    }
    void AddNominee()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txt2.Text != "")
        {
            xmlData.LoadXml(txt2.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("EPF");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("NOMINEE");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("NOMI_ID");
            element.InnerText = gvNominee.DataSourceID.ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_NAME");
            element.InnerText = txtNomiName.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_ADRS");
            element.InnerText = txtNomiAdrs.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_DOB");
            element.InnerText = txtNomiDOB.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("RELATION_ID");
            element.InnerText = ddlNomiRelation.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("RELATION_NAME");
            element.InnerText = ddlNomiRelation.SelectedItem.ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_BENIFIT");
            element.InnerText = txtNomiBenifit.Text;
            dataElement.AppendChild(element);

            txt2.Text = xmlData.OuterXml;
            AddXmlData();

            txtNomiName.Text = txtNomiAdrs.Text = txtNomiDOB.Text = txtNomiBenifit.Text = "";
            ddlNomiRelation.SelectedIndex = 0;
        }
    }
    protected void gvFamily_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txt1.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("EPF/FAMILY");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
        {
            txt1.Text = xmlData.OuterXml;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        }
        else
        {
            txt1.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        }
        AddXml();
    }
    protected void gvNominee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        XmlDocument xmlData = new XmlDocument();
        xmlData.LoadXml(txt2.Text);
        XmlNodeList nodeList = xmlData.SelectNodes("EPF/NOMINEE");
        xmlData.FirstChild.RemoveChild(nodeList[e.RowIndex]);
        if (xmlData.FirstChild.HasChildNodes)
        {
            txt2.Text = xmlData.OuterXml;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        }
        else
        {
            txt2.Text = "";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        }

        AddXmlData();
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        bal.Document = txt2.Text;
        bal.FullName = txt1.Text;
        bal.EmpId = txtEmpID.Text;
        bal.AccountNo = txtAcc2.Text;
        bal.AliasValue = txtPermAdrs.Text;
        bal.ValueType = txtTempAdrs.Text;
        bal.FromDate = Convert.ToDateTime(txtJoinDt.Text);
        bal.Description = txtFather.Text;
        bal.Name = txtSpouse.Text;
        bal.RemValue = txtRemark.Text;
        bal.InBy = ddlScheme.SelectedValue;
        bal.DesignationId = ddlDedu.SelectedValue;
        string msg = bll.EmpPFMain(bal);
        if (msg == "no")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('This Epf No Already Alloted')", true);
            txtAcc2.Text = ""; txtAcc2.Focus();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Inserted')", true);
            common.Clear(this);
            txt1.Text = txt2.Text = lblEmpMartial.Text = lblEmpGender.Text = lblEmpDOB.Text = "";
            gvFamily.DataSource = gvNominee.DataSource = "";
            gvFamily.DataBind(); gvNominee.DataBind();
            FillFunction.Fill(ddlEmpID, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlEmpIDEnd, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void btnAddNomi_Click(object sender, EventArgs e)
    {
        int Benifit = Convert.ToInt32(txtNomiBenifit.Text);
        sum = sum + Benifit + value;
        if (Benifit <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert ('Benifit Can Not be 0')", true);
            txtNomiBenifit.Text = ""; txtNomiBenifit.Focus();
        }
        else if (Benifit > 100)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert ('Benifit Should Be Less Than Aur Equal To 100')", true);
            txtNomiBenifit.Text = ""; txtNomiBenifit.Focus();
        }
        else
        {
            AddNominee();
            //value = Convert.ToInt32(gridNominee.Rows[0].Cells[5].Text.ToString());
            //sum = sum + value;
            //Benifit = sum;
        }
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        Update.Visible = true;
        txtAccUpdate2.ReadOnly = true;
        bal.EmpId = ddlEmpID.SelectedValue;
        DataSet ds = bll.EmpPFInfShow(bal);
        txtRemark2.Text = ds.Tables[0].Rows[0][0].ToString();
        txtFather2.Text = ds.Tables[0].Rows[0][1].ToString();
        txtSpouse2.Text = ds.Tables[0].Rows[0][2].ToString();
        txtAccUpdate2.Text = ds.Tables[0].Rows[0][3].ToString();
        txtJoinDt2.Text = ds.Tables[0].Rows[0][4].ToString();
        ddlScheme2.SelectedValue = ds.Tables[0].Rows[0][5].ToString();
        ddlDedu2.SelectedValue = ds.Tables[0].Rows[0][6].ToString();
        txtPermAdrs2.Text = ds.Tables[0].Rows[0][7].ToString();
        txtTempAdrs2.Text = ds.Tables[0].Rows[0][8].ToString();
        gridFamily.DataSource = ds.Tables[1];
        gridFamily.DataBind();
        gridNominee.DataSource = ds.Tables[2];
        gridNominee.DataBind();
       // FillFunction.Fill(RelationID, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
    }
    protected void btn_Click1(object sender, EventArgs e)
    {
        txtAcc2.Text = "";
        bal.EmpId = txtEmpID.Text;
        DataSet ds = bll.EmpPFOlD(bal);
        if (ds.Tables[0].Rows[0][0].ToString() == "EXIST")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('This Employee Already Have An PF No.')", true);
            NewEmployee.Visible = true;
            txtAcc2.Text = ds.Tables[1].Rows[0][0].ToString();
        }
        else if (ds.Tables[0].Rows[0][0].ToString() == "DEACTIVE")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Activate This Employee PF No...')", true);
            btnActiveAcc.Visible = txtUpdateLeft.Visible = true;
            txtUpdateLeft.Text = ds.Tables[1].Rows[0][0].ToString();
        }
        else if (ds.Tables[0].Rows[0][0].ToString() == "RIGHT")
        {
            NewEmployee.Visible = true;
            lblEmpDOB.Text = ds.Tables[1].Rows[0][0].ToString();
            lblEmpGender.Text = ds.Tables[1].Rows[0][1].ToString();
            lblEmpMartial.Text = ds.Tables[1].Rows[0][2].ToString();
        }
    }
    protected void btnActiveAcc_Click(object sender, EventArgs e)
    {
        bal.EmpId = txtEmpID.Text;
        bll.EmpPFAccActivate(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Account Activated Successfully')", true);
        FillFunction.Fill(ddlEmpID, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlEmpIDEnd, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
    }
    protected void btnEnd_Click(object sender, EventArgs e)
    {
        bal.EmpId = ddlEmpIDEnd.SelectedValue;
        bll.EmpPFCloseAcc(bal);
        common.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Account Deactivated Successfully')", true);
        FillFunction.Fill(ddlEmpID, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlEmpIDEnd, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
    }
    protected void gridFamily_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Update.Visible = true;
        gridFamily.EditIndex = -1;
        ShowFamily();
    }
    public void ShowFamily()
    {
        Update.Visible = true;
        DataSet DS = bll.SelectFamilyDetails(bal);
        dt = bll.SelectFamilyDetails(bal).Tables[0];
        gridFamily.DataSource = dt;
        gridFamily.DataBind();
    }
    public void ShowNominee()
    {
        Update.Visible = true;
        DataSet DS = bll.SelectNomineeDetails(bal);
        dt = bll.SelectNomineeDetails(bal).Tables[0];
        gridNominee.DataSource = dt;
        gridNominee.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (sum > 100)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Banifit Total Can Not Be Greater Then 100')", true);
        }
        try
        {
            bal.EmpId = ddlEmpID.SelectedValue;
            bal.AccountNo = txtAccUpdate2.Text;
            bal.AliasValue = txtPermAdrs2.Text;
            bal.ValueType = txtTempAdrs2.Text;
            bal.FromDate = Convert.ToDateTime(txtJoinDt2.Text);
            bal.Description = txtFather2.Text;
            bal.Name = txtSpouse2.Text;
            bal.RemValue = txtRemark2.Text;
            bal.InBy = ddlScheme2.SelectedValue;
            bal.DesignationId = ddlDedu2.SelectedValue;
            bll.EmpPFUpdate(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Updated')", true);
            common.Clear(this);
            txt1.Text = txt2.Text = "";
            gvFamily.DataSource = gvNominee.DataSource = "";
            gvFamily.DataBind(); gvNominee.DataBind();
            FillFunction.Fill(ddlEmpID, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlEmpIDEnd, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpID), true, FillFunctions.FirstItem.Select);
        }
        catch (Exception ex)
        { throw ex; }
    }

    private void AddFamily2()
    {
        XmlDocument xml = new XmlDocument();
        XmlElement root;
        if (txt1.Text != "")
        {
            xml.LoadXml(txt1.Text);
            root = xml.DocumentElement;
        }
        else
        {
            root = xml.CreateElement("EPF");
            xml.AppendChild(root);
        }
        bool add = true;
        if (add)
        {
            XmlElement dataElement = xml.CreateElement("FAMILY");
            root.AppendChild(dataElement);

            XmlElement element = xml.CreateElement("FMLY_ID");
            element.InnerText = gridFamily.DataSourceID.ToString();
            dataElement.AppendChild(element);

            element = xml.CreateElement("FMLY_MEM_NAME");
            element.InnerText = txtFmlyName2.Text;
            dataElement.AppendChild(element);

            element = xml.CreateElement("FMLY_MEM_ADRS");
            element.InnerText = txtFmlyAdrs2.Text;
            dataElement.AppendChild(element);

            element = xml.CreateElement("FMLY_MEM_DOB");
            element.InnerText = txtFmlyDOB2.Text;
            dataElement.AppendChild(element);

            element = xml.CreateElement("RELATION_ID");
            element.InnerText = ddlFmlyRelation2.SelectedValue;
            dataElement.AppendChild(element);

            element = xml.CreateElement("RELATION_NAME");
            element.InnerText = ddlFmlyRelation2.SelectedItem.ToString();
            dataElement.AppendChild(element);

            txt1.Text = xml.OuterXml;

            AddXml2();
            txtFmlyName.Text = txtFmlyAdrs.Text = txtFmlyDOB.Text = "";
            ddlFmlyRelation.SelectedIndex = 0;
            txtFmlyName.Focus();
        }
    }
    void AddXml2()
    {
        if (txt1.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txt1.Text));
            gridFamily.DataSource = dataSet.Tables[0];
            gridFamily.DataBind();
        }
        else
        {
            gridFamily.DataSource = "";
            gridFamily.DataBind();
        }
    }
    void AddXmlData2()
    {
        if (txt2.Text != "")
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(new StringReader(txt2.Text));
            gridNominee.DataSource = dataSet.Tables[0];
            gridNominee.DataBind();
        }
        else
        {
            gridNominee.DataSource = null;
            gridNominee.DataBind();
        }
    }
    void AddNominee2()
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT;
        if (txt2.Text != "")
        {
            xmlData.LoadXml(txt2.Text);
            ROOT = xmlData.DocumentElement;
        }
        else
        {
            ROOT = xmlData.CreateElement("EPF");
            xmlData.AppendChild(ROOT);
        }
        bool add = true;
        if (add)
        {
            XmlElement dataElement = xmlData.CreateElement("NOMINEE");
            ROOT.AppendChild(dataElement);

            XmlElement element = xmlData.CreateElement("NOMI_ID");
            element.InnerText = gridNominee.DataSourceID.ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_NAME");
            element.InnerText = txtNomiName2.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_ADRS");
            element.InnerText = txtNomiAdrs2.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_DOB");
            element.InnerText = txtNomiDOB2.Text;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("RELATION_ID");
            element.InnerText = ddlNomiRelation2.SelectedValue;
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("RELATION_NAME");
            element.InnerText = ddlNomiRelation2.SelectedItem.ToString();
            dataElement.AppendChild(element);

            element = xmlData.CreateElement("NOMI_BENIFIT");
            element.InnerText = txtNomiBenifit2.Text;
            dataElement.AppendChild(element);

            txt2.Text = xmlData.OuterXml;
            AddXmlData2();

            txtNomiName.Text = txtNomiAdrs.Text = txtNomiDOB.Text = txtNomiBenifit.Text = "";
            ddlNomiRelation.SelectedIndex = 0;
        }
    }
    protected void btnAddFamily2_Click(object sender, EventArgs e)
    {
        AddFamily2();
        Update.Visible = true;
    }
    protected void gridFamily_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Update.Visible = true;
        bal.CommonId = gridFamily.DataKeys[e.RowIndex].Values[0].ToString();
        bll.DeleteFamilyDetails(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        DataSet DS = bll.SelectFamilyDetails(bal);
        dt = bll.SelectFamilyDetails(bal).Tables[0];
        gridFamily.DataSource = dt;
        gridFamily.DataBind();

    }
    protected void gridNominee_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Update.Visible = true;
        bal.KeyID = gridNominee.DataKeys[e.RowIndex].Value.ToString();
        bll.DeleteNomineeDetails(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Deleted')", true);
        ShowNominee();
    }
    protected void btnAddNomi2_Click(object sender, EventArgs e)
    {
        bal.EmpId = ddlEmpID.SelectedItem.ToString();
        DataSet ds = bll.EmpPFBenifit(bal);
        if (ds.Tables[0].Rows[0][0].ToString() == "NO")
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('You Can Not Enter This Ammount')", true);
        else
        {
            int Data = Convert.ToInt32(ds.Tables[1].Rows[0][0].ToString());
            AddNominee2();
            //int gridValue = Convert.ToInt32(gridNominee.Rows[(Convert.ToInt32(gridNominee.Rows.Count) - 1)].Cells[5].Text.ToString());
            //sum = sum + Data + gridValue;
        }
    }

    protected void gridFamily_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Update.Visible = true;
        gridFamily.EditIndex = e.NewEditIndex;       
        ShowFamily();
    }
    protected void gridFamily_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Update.Visible = true;
        GridViewRow row = (GridViewRow)gridFamily.Rows[e.RowIndex];    
        TextBox Name = (TextBox)gridFamily.Rows[e.RowIndex].Cells[1].FindControl("txtFmlyName");
        TextBox Address = (TextBox)gridFamily.Rows[e.RowIndex].Cells[1].FindControl("txtFmlyAdrs");
        TextBox DOB = (TextBox)gridFamily.Rows[e.RowIndex].Cells[1].FindControl("txtGridFmlyDOB");
        DropDownList RelationName = (DropDownList)gridFamily.Rows[e.RowIndex].Cells[1].FindControl("ddlGridFmlyRelation");
        
        gridFamily.EditIndex = -1;
        bal.Name = Name.Text;
        bal.FullName = Address.Text;
        bal.Date = Convert.ToDateTime(DOB.Text);
        bal.CommonId = RelationName.SelectedValue;
        bal.KeyID = gridFamily.DataKeys[e.RowIndex].Values[0].ToString();
        bll.UpdateFamilyDetails(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Updated')", true);
        ShowFamily();
    }
    protected void gridNominee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        Update.Visible = true;
        gridNominee.EditIndex = -1;
        ShowNominee();
    }
    protected void gridNominee_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Update.Visible = true;
        GridViewRow row = (GridViewRow)gridNominee.Rows[e.RowIndex]; 
        TextBox Name = (TextBox)gridNominee.Rows[e.RowIndex].Cells[1].FindControl("txtGridNomiName");
        TextBox Address = (TextBox)gridNominee.Rows[e.RowIndex].Cells[1].FindControl("txtGridNomiAdrs");
        TextBox DOB = (TextBox)gridNominee.Rows[e.RowIndex].Cells[1].FindControl("txtGridNomiDOB");
        TextBox Benifit = (TextBox)gridNominee.Rows[e.RowIndex].Cells[1].FindControl("txtGridNomiBenifit");
        DropDownList RelationName = (DropDownList)gridNominee.Rows[e.RowIndex].Cells[1].FindControl("ddlGridNomiRelation");

        gridNominee.EditIndex = -1;
        bal.Name = Name.Text;
        bal.FullName = Address.Text;
        bal.Date = Convert.ToDateTime(DOB.Text);
        bal.KeyValue = Benifit.Text;
        bal.CommonId = RelationName.SelectedValue;
        bal.KeyID = gridNominee.DataKeys[e.RowIndex].Value.ToString();
        bll.UpdateNomineeDetails(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Updated')", true);
        ShowNominee();
    }
    protected void gridNominee_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Update.Visible = true;
        gridNominee.EditIndex = e.NewEditIndex;
        ShowNominee();
    }
    protected void gridFamily_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList ddlRelation = (DropDownList)e.Row.FindControl("ddlGridFmlyRelation");
        Label Benifit = (Label)e.Row.FindControl("lblRelation");

        if (ddlRelation != null)
        {
            FillFunction.Fill(ddlRelation, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
            ddlRelation.SelectedValue = Benifit.Text;
        }
    }
    protected void gridNominee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DropDownList ddlRelation = (DropDownList)e.Row.FindControl("ddlGridNomiRelation");
        Label Benifit = (Label)e.Row.FindControl("lblRelationNom");

        if (ddlRelation != null)
        {
            FillFunction.Fill(ddlRelation, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Relation), true, FillFunctions.FirstItem.Select);
            ddlRelation.SelectedValue = Benifit.Text;
        }
    }
}
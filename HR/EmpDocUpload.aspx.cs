using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class HR_EmpDocUpload : System.Web.UI.Page
{
    FillFunctions fill;
    QueryFunctions queryfunctions;
    CommonFunctions common;
    Messages msg;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjAcaBAL;
         string ext, url;
    protected void Page_Load(object sender, EventArgs e)
    {
         Initialize();
         if (!IsPostBack)
         {
             FillGrid();
             ViewState["ID"] = "";
             fill.Fill(ddlInstitute, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);

         }
        btnSave.Attributes.Add("OnClick", "return validate()");
    }
    private void Initialize()
    {
        fill = new FillFunctions();
        queryfunctions = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }
    private void FillGrid()
    {
        dt = ObjHrBll.EmpDocUploadSelect().Tables[0];                                   // fill grid view with select all record from table
        ViewState["dt"] = dt;
        GridShow.DataSource = dt;
        GridShow.DataBind();
        common.Clear(this);

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/Emp_Document" + ddlEmployee.SelectedValue));
        if (folders.Exists == false)
            folders.Create();
        if (upd1.PostedFile.FileName.ToString() != "")
        {
            ext = Path.GetExtension(upd1.PostedFile.FileName);
            if ((ext != ".doc") && (ext != ".pdf") && (ext != ".docx") && (ext != ".xml"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Upload Appropriate File like .doc,.docx,.pdf, .xml file')", true);
                upd1.Focus();
                return;
            }
            else
            {
                url = "../UploadedFile/Emp_Document/" + ddlEmployee.SelectedValue + "/" + ddlDocument.SelectedValue + ext;
                //upd1.PostedFile.SaveAs(Server.MapPath(url));
                ObjAcaBAL.KeyID = ddlEmployee.SelectedValue;
                ObjAcaBAL.CommonId = ddlDocument.SelectedValue;
                ObjAcaBAL.Document = url;
                ObjHrBll.DocumentUploadInsert(ObjAcaBAL);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('File Uploaded Successfully.')", true);
                FillGrid();
                ddlEmployee.SelectedIndex = ddlDocument.SelectedIndex = 0;
                common.Clear(this);
            }
        }

    }
    protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill.Fill(ddlEmployee, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.EmpByDept,ddlDepartment.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill.Fill(ddlDocument, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.EmpDocument,ddlEmployee.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlInstitute_SelectedIndexChanged(object sender, EventArgs e)
    {
        fill.Fill(ddlDepartment, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Department, ddlInstitute.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
}
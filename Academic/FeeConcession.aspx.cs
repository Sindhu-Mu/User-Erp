using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;


public partial class Academic_FeeConcession : System.Web.UI.Page
{
    AcaBAL balObj;
    AcaBLL bllObj;
    CommonFunctions cf;
    FillFunctions FillFunctin;
    QueryFunctions QueryFunction;
    
    protected void Page_Load(object sender, EventArgs e)
    {

        Initailize();
        
        if (!IsPostBack)
        {

            FillFunctin.Fill(ddlRule, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ConcessionRule), true, FillFunctions.FirstItem.Select);
            FillFunctin.Fill(ddlSession, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
            
        }
    }
    public void BindGrid()
    {
        balObj.Stu_AdmNo = cf.GetKeyID(txtEnrol);
        DataTable dt=bllObj.SelectFeeConcession(balObj);
        grdView.DataSource = dt;
        grdView.DataBind();

    }
    protected string AddFile()
    {
        try
        {
            string Extension, Url="";
            DateTime date = new DateTime(2010, 1, 1);
            TimeSpan diff = DateTime.Now - date;
            double seconds = diff.TotalSeconds;

            DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/Concession_Documents/" + seconds));
            if (folders.Exists == false)
                folders.Create();
            if (fileUpload.PostedFile.FileName.ToString() != "")
            {
                Extension = Path.GetExtension(fileUpload.PostedFile.FileName);
                Url = "../UploadedFile/Concession_Documents/" + seconds + Extension;
                fileUpload.PostedFile.SaveAs(Server.MapPath(Url));
              
            }
            return Url.ToString();
        }
        catch(Exception e)
        {
       return "";
        }
    }
    private void Initailize()
    {
        balObj = new AcaBAL();
        bllObj = new AcaBLL();
        cf = new CommonFunctions();
        FillFunctin = new FillFunctions();
        QueryFunction = new QueryFunctions();
    }
    bool CheckFileType(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".gif":
                return true;
            case ".png":
                return true;
            case ".jpg":
                return true;
            case ".jpeg":
                return true;
            default:
                return false;
        }
    }
    protected void Show_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(cf.GetKeyID(txtEnrol));
        BindGrid();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        balObj.Stu_AdmNo = cf.GetKeyID(txtEnrol);
        balObj.BAL_RULE_ID = ddlRule.SelectedValue;
        balObj.BAL_SESSION_ID = ddlSession.SelectedValue;
        balObj.Date = cf.GetDateTime(txtDate.Text);
        balObj.Value = AddFile();
        balObj.SessionUserID = Session["UserID"].ToString();
        if (balObj.Value != "")
        {
            try
            {
                bllObj.InsertFeeConcession(balObj);

            }
            catch
            {
                cf.showAlert(this, "Error Encountered..!");
            }

        }
        else
        {
            cf.showAlert(this, "Kindly Upload Document..!");
        }
        BindGrid();
    }
}
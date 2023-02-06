using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class PayRoll_UploadSalarySlip : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        
        }

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        DropDownList ddlMonth = (DropDownList)MonthYear.FindControl("ddlMonth");
        DropDownList ddlYear = (DropDownList)MonthYear.FindControl("ddlYear");
        string mm =ddlMonth.SelectedValue;
        string yy = ddlYear.SelectedValue != "" ? ddlYear.SelectedValue : DateTime.Today.Year.ToString();

        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../common/SALARYFILE/"));
        if (folders.Exists == false)
            folders.Create();
        string ext = Path.GetExtension(upd1.PostedFile.FileName);
        if (ext == ".xls")
        {
            string url = "../common/SALARYFILE/" + mm + "-" + yy + ext;
            upd1.PostedFile.SaveAs(Server.MapPath(url));
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Salary Slip File Uploaded Successfully')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Upload Appropriate only .xls file.')", true);
            upd1.Focus();
            return;
        }
       
        ddlYear.SelectedIndex = 0;
        upd1.Attributes.Clear();
    }
}
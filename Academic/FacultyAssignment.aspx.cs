using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;

public partial class Academic_FacultyAssignment : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    string ext;
    DataSet ds;
    DataTable dt;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
        ds = new DataSet();
        dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnupload.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
           
            //gvAssignment.Visible = false;
            AcaBal.EmpId = Session["UserId"].ToString();
            fillFunctions.Fill(gvShow, AcaBll.GetFacultyForAsn(AcaBal).Tables[0]);
            ViewState["index"] = "";
           
        }
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        ViewState["index"] = index.ToString();
        ViewState["TT_ID"] = AcaBal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
          ViewState["PAP_ID"]=AcaBal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
          AcaBal.EmpId = Session["UserId"].ToString();
          ds = AcaBll.GetAssignmentDetail(AcaBal);
          gvAssignment.DataSource = ds.Tables[0];
          gvAssignment.DataBind();
    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        AcaBal.KeyID = ViewState["TT_ID"].ToString();
        AcaBal.TypeId = ViewState["PAP_ID"].ToString();
        AcaBal.EmpId = Session["UserId"].ToString();
        int counter = 0;
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/Assignment"));
        if (folders.Exists == false)
            folders.Create();
        ext = Path.GetExtension(upd1.PostedFile.FileName);
        if (upd1.PostedFile.FileName != "")
        {
            if ((ext != ".doc") && (ext != ".docx"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Upload Appropriate File like .doc and .docx)", true);
                upd1.Focus();
                return;
            }
            else
            {
                counter += 1;
                ViewState["url"] = "../UploadedFile/Assignment/" + Session["UserId"].ToString() + "_" + commonFunctions.GetDateTime(txtdate.Text).ToString("yyyy-MM-dd") + ext.ToString();
                upd1.PostedFile.SaveAs(Server.MapPath(ViewState["url"].ToString()));
            }
        }
        AcaBal.Name = txtTitle.Text.ToString();
        AcaBal.Value = ViewState["url"].ToString();
        AcaBal.Date = commonFunctions.GetDateTime(txtdate.Text);
        ds = AcaBll.Assignment_Insert(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('You Assignment Submitted Successfully.')", true);
        ViewState["ASN"]=ds.Tables[0];
        gvAssignment.DataSource = ViewState["ASN"];
        gvAssignment.DataBind();
        txtdate.Text = "";
        txtTitle.Text = "";
      
    }
}
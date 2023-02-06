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
using System.IO;

public partial class HR_I_Card_Application : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryfunction;
    CommonFunctions common;
    DataTable dt;
    HRBLL ObjHrBll;
    HRBAL ObjAcaBAL;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
       
        if (!IsPostBack)
        {
            tr1.Visible = false;
            show();
            
            
        }
        
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }

    public void show()
    {

         ObjAcaBAL.EmpId = Session["LoginId"].ToString();
        DataSet ds = ObjHrBll.EmpCardPrint(ObjAcaBAL.EmpId);
        string empImage = "../images/emp_images/" + Session["LoginId"].ToString() + "_thumb.jpg";
        if (System.IO.File.Exists(Server.MapPath(empImage)))
            imgEmp.Src = empImage;
        else
        {
            imgEmp.Src = "../images/emp_images/empImage.jpg";
            tr1.Visible = true;
        }
        DataRow dr;
        if (ds.Tables[0].Rows.Count != 0)
        {
            dr = ds.Tables[0].Rows[0];
            lblAddress.Text = dr["PRESENT_ADD"].ToString();
            lblname.Text = dr["EMP_NAME"].ToString();
            lblfather.Text = dr["FATHER_NAME"].ToString();
            lbldesig.Text = dr["DESIG_NAME"].ToString();
            lbldepart.Text = dr["DEPT_VALUE"].ToString();
            lblDOB.Text = dr["DOB"].ToString();
            lblContact.Text = dr["PHONE"].ToString();
            lblDOJ.Text = dr["DOJ"].ToString();
            lblCode.Text = dr["EMP_ID"].ToString();
            lblBlood.Text = dr["Blood_Group"].ToString();
            


        }
    }

    private bool UploadImage(string empid)
    {
        try
        {
            if (empid == "0")
                return true;
            string ext = Path.GetExtension(ImgUpload.PostedFile.FileName);
            if (Path.GetExtension(ImgUpload.PostedFile.FileName) != ".jpg")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Uploaded Pic in .jpg format')", true);
                ImgUpload.Focus();
                return false;
            }
            else
            {
                ImgUpload.PostedFile.SaveAs(Server.MapPath("../images/emp_images/" + empid + "_thumb.jpg"));
                
                return true;
               
            }
        }
        catch
        {
            return true;
        }

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string empImage = "../images/emp_images/" + Session["LoginId"].ToString() + "_thumb.jpg";
        if (((System.IO.File.Exists(Server.MapPath(empImage))==false)&ImgUpload.HasFile==true)||((System.IO.File.Exists(Server.MapPath(empImage))==true)))
        {
            ObjAcaBAL.EmpId = Session["LoginId"].ToString();
            DataSet ds = ObjHrBll.EmpICardSts(ObjAcaBAL.EmpId);
            UploadImage(Session["LoginId"].ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Your request has been sent to HR-Department')", true);
            btnSave.Visible = false;
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Uploaded Pic in .jpg format')", true);
        ImgUpload.Focus();
       
    }
}
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
using System.IO;

public partial class Academic_StuPicChange : System.Web.UI.Page
{
    AcaBAL ObjAcaBal;
    AcaBLL ObjAcaBll;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        btnShow.Attributes.Add("onClick", "return Validate()");
        btnUpload.Attributes.Add("onClick", "return Validation()");
        Initialize();
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlPhnType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.PhoneType), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlDomain, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MailDomain), true, FillFunctions.FirstItem.Select);
        }
    }
    void Initialize()
    {
        ObjAcaBal = new AcaBAL();
        ObjAcaBll = new AcaBLL();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
       
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (txtEnroll.Text != "")
        {
            string[] st = new string[2];
            st = txtEnroll.Text.Split(':');
            if (st.Length > 1)
            {
                Student.ShowStudent(st[1]);
                ViewState["Enroll"] = st[1];
                ObjAcaBal.Stu_AdmNo = CommonFunction.GetKeyID(txtEnroll);
                ViewState["Id"] = ObjAcaBll.GetStudentMainId(ObjAcaBal);
            }
        }
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (ddlPhnType.SelectedValue != "0" && txtStuMobile.Text != "")
        {
            ObjAcaBal.Stu_AdmNo = ViewState["Id"].ToString();
            ObjAcaBal.TypeId = ddlPhnType.SelectedValue;
            ObjAcaBal.Phn_No = txtStuMobile.Text;
            ObjAcaBal.Value1 = txtFatherName.Text;
            ObjAcaBal.Value2 = txtMotherName.Text;
            ObjAcaBll.StuPhnChange(ObjAcaBal);
            
        }
        if (txtEmail.Text != "" && ddlDomain.SelectedValue != "0")
        {
            ObjAcaBal.Stu_AdmNo = ViewState["Id"].ToString();
            ObjAcaBal.Value = txtEmail.Text;
            ObjAcaBal.Id = ddlDomain.SelectedValue;
            ObjAcaBll.StuMailChange(ObjAcaBal);
        
        }
        txtFatherName.Text = txtMotherName.Text = txtStuMobile.Text = txtEmail.Text = "";
        Student.ShowStudent(ViewState["Enroll"].ToString());







     

        // If file field isn’t empty
        if (flPhoto.PostedFile != null)
        {
            string sSavePath = "../images/Stuimages/";
            // Check file size (mustn’t be 0)
            HttpPostedFile myFile = flPhoto.PostedFile;
            int nFileLen = myFile.ContentLength;
            if (nFileLen == 0)
            {
                //lblOutput.Text = "There wasn't any file uploaded.";
                return;
            }

            // Check file extension (must be JPG)
            if (System.IO.Path.GetExtension(myFile.FileName).ToLower() != ".jpg")
            {
                //lblOutput.Text = "The file must have an extension of JPG";
                return;
            }

            // Read file into a data stream
            byte[] myData = new Byte[nFileLen];
            myFile.InputStream.Read(myData, 0, nFileLen);

            // Make sure a duplicate file doesn’t exist.  If it does, keep on appending an incremental numeric until it is unique
            string sFilename = ViewState["Enroll"].ToString() + ".jpg";//System.IO.Path.GetFileName(myFile.FileName);

            // Save the stream to disk
            System.IO.FileStream newFile = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename), System.IO.FileMode.Create);
            newFile.Write(myData, 0, myData.Length);
            newFile.Close();

            // Check whether the file is really a JPEG by opening it
            //Bitmap myBitmap;
            try
            {
                flPhoto.PostedFile.SaveAs(Server.MapPath(sSavePath + sFilename));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Uploaded successfully!!')", true);
            }
            catch (ArgumentException errArgument)
            {
                System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Error Occurred!!')", true);
            }
            Student.ShowStudent(ViewState["Enroll"].ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Changes Done Successfully')", true);
        }

    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Text;
using System.IO;
public partial class Academic_StuSemReReg : System.Web.UI.Page
{
    CommonFunctions common;
    DataTable dt;
    string ext;
    AcaBLL ObjBll;
    AcaBAL ObjBal;
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnTempReg.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            btnRegister.Visible = btnTempReg.Visible = false;
        }
    }
    void Initialize()
    {
        common = new CommonFunctions();
        ObjBll = new AcaBLL();
        ObjBal = new AcaBAL();
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        Student.ShowStudent(txtEnroll.Text);
        ObjBal.Stu_AdmNo = txtEnroll.Text;
        dt = ObjBll.getDueAmt(ObjBal).Tables[0];
        if (dt.Rows.Count > 0)
        {
            btnRegister.Visible = true;
            trDue.Visible = btnTempReg.Visible = false;
            if (dt.Rows[0][0].ToString().Contains("already"))
            {
                btnRegister.Visible = btnTempReg.Visible = trDue.Visible = false;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + dt.Rows[0][0].ToString() + "')", true);
                btnRegister.Visible = btnTempReg.Visible = false;
                txtEnroll.Text = lblDue.Text = lblRemark.Text = txtDate.Text = "";
                ddlAuth.SelectedIndex = 0;
                txtEnroll.Focus();
            }
            else
            {
                lblDue.Text = dt.Rows[0][0].ToString();
                lblRemark.Text = dt.Rows[0][1].ToString();
                if (dt.Rows[0][0].ToString() != "0.00")
                {
                    btnRegister.Visible = false;
                    trDue.Visible = btnTempReg.Visible = true;
                }

            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Student not in proper list.instract him to contact account section.')", true);
            btnRegister.Visible = btnTempReg.Visible = false;
            txtEnroll.Text = lblDue.Text = lblRemark.Text = txtDate.Text = "";
            ddlAuth.SelectedIndex = 0;
            txtEnroll.Focus();
        }


    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        ObjBal.Enroll_No = txtEnroll.Text;
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBal.KeyValue = txtRemark.Text;
        ObjBal.KeyID = lblDue.Text;
        ObjBal.Value = (txtDate.Text != "") ? common.GetDateTime(txtDate.Text).ToString() : txtDate.Text;
        ObjBal.EmpId = ddlAuth.SelectedItem.ToString();
        uploadApplication();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + ObjBll.StuSemReg(ObjBal) + "')", true);
        btnRegister.Visible = btnTempReg.Visible = false;
        txtEnroll.Text = lblDue.Text = lblRemark.Text = txtDate.Text = "";
        ddlAuth.SelectedIndex = 0;
        txtEnroll.Focus();
    }

    void uploadApplication()
    {
        try
        {
            int count = 0;
            DirectoryInfo folder = new DirectoryInfo(Server.MapPath("../UploadedFile/Application"));
            if (folder.Exists == false)
                folder.Create();
            ext = Path.GetExtension(flApp.PostedFile.FileName);
            if (flApp.PostedFile.FileName != "")
            {
                if ((ext != ".doc") && (ext != ".docx"))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Please upload .doc or .docx file')", true);
                    flApp.Focus();
                    return;
                }
                else
                {
                    string url;
                    count += 1;
                    url = "../UploadedFile/Application" + txtEnroll.Text + ext.ToString();
                    flApp.PostedFile.SaveAs(Server.MapPath(url));
                }
            }
        }
        catch
        {
        }

    }

    protected void btnTempReg_Click(object sender, EventArgs e)
    {
        ObjBal.Enroll_No = txtEnroll.Text;
        ObjBal.SessionUserID = Session["UserId"].ToString();
        ObjBal.KeyValue = txtRemark.Text;
        ObjBal.KeyID = lblDue.Text;
        ObjBal.Value = (txtDate.Text != "") ? common.GetDateTime(txtDate.Text).ToString() : txtDate.Text;
        ObjBal.EmpId = ddlAuth.SelectedItem.ToString();
        uploadApplication();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + ObjBll.StuSemReg(ObjBal) + "')", true);
        btnRegister.Visible = btnTempReg.Visible = false;
        txtEnroll.Text = lblDue.Text = lblRemark.Text = txtDate.Text = "";
        ddlAuth.SelectedIndex = 0;
        txtEnroll.Focus();
    }
}
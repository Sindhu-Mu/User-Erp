using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class HR_EmpProfile : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    DatabaseFunctions databaseFunctions;
    Messages Msgfun;
    HRBAL ObjHrBal;
    HRBLL ObjHrBll;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        MaintainScrollPositionOnPostBack = true;
        Initialize();
        if (!IsPostBack)
        {
            ViewState["ds"] = ds;
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        queryFunctions = new QueryFunctions();
        commonFunctions = new CommonFunctions();
        databaseFunctions = new DatabaseFunctions();
        Msgfun = new Messages();
        ObjHrBal = new HRBAL();
        ObjHrBll = new HRBLL();
        ds = new DataSet();
    }

    void Clear()
    {
        lblBldGroup.Text = lblCaste.Text = lblCode.Text = lblDob.Text = lblDOJ.Text = lblEmail.Text = lblfName.Text = lblIns.Text = "";
        lblMarSts.Text = lblMob.Text = lblMthrTongue.Text = lblName.Text = lblNationality.Text = lblNxtKin.Text = lblNxtSenior.Text = lblPhn.Text = lblPrmntAdd.Text = "";
        lblPrsntAdd.Text = lblRel.Text = lblSpsName.Text = lblStatus.Text = lblRlvd.Text = "";
        lblEmpType.Text = lblJob.Text = lblServType.Text = lblShift.Text = lblWeekOff.Text = "";
        gvDocument.DataSource = gvExprience.DataSource = gvQualification.DataSource = gvAtt.DataSource = gvDept.DataSource = gvDes.DataSource = gvEOL.DataSource = gvExpCount.DataSource = "";
        gvDocument.DataBind();
        gvExprience.DataBind();
        gvQualification.DataBind();
        gvAtt.DataBind();
        gvDept.DataBind();
        gvDes.DataBind();
        gvEOL.DataBind();
        gvExpCount.DataBind();
        step1.ActiveTabIndex = 0;
    }

    void bindData(string emp_id)
    {
        Clear();
        ObjHrBal.EmpId = emp_id;
        ds = ObjHrBll.GetHREmpProfile(ObjHrBal);
        ViewState["ds"] = ds;
        string empImage = "../images/emp_images/" + emp_id + "_thumb.jpg";
        if (System.IO.File.Exists(Server.MapPath(empImage)))
            imgPicture.Src = empImage;
        else
            imgPicture.Src = "../images/emp_images/empImage.jpg";
        /*PERSONAL INFO*/
        DataRow dr;
        if (ds.Tables[0].Rows.Count != 0)
        {
            dr = ds.Tables[0].Rows[0];
            lblName.Text = dr["EMP_NAME"].ToString();
            lblfName.Text = dr["EMP_FTH_NAME"].ToString();
            lblMarSts.Text = dr["MAR_STS_VALUE"].ToString();
            lblSpsName.Text = dr["SPOUSE_NAME"].ToString();
            lblRel.Text = dr["REL_VALUE"].ToString();
            lblNxtKin.Text = dr["NEXT_KIN_NAME"].ToString();
            lblDob.Text = dr["DOB"].ToString();
            lblCaste.Text = dr["CAS_VALUE"].ToString();
            lblMthrTongue.Text = dr["MOT_TON_VALUE"].ToString();
            //lblBrthPlace.Text = dr[""].ToString();
            lblBldGroup.Text = dr["BLO_GRP_VALUE"].ToString();
            lblNationality.Text = dr["NAT_VALUE"].ToString();
            lblStatus.Text = dr["STS_VALUE"].ToString();
            if (dr["STS_VALUE"].ToString() == "DEACTIVE")
            {
                trRelvd.Visible = true;
                lblRlvd.Text = dr["RELVNG_DATE"].ToString();
            }
            else if (dr["STS_VALUE"].ToString() == "EOL")
            {
                trRelvd.Visible = true;
                lblRlvd.Text = (Convert.ToDateTime(ds.Tables[10].Rows[0]["TO_DT"].ToString())).AddDays(1).ToString("dd/MM/yyyy");

            }
            else
                trRelvd.Visible = false;
        }


        /*OFFICIAL INFO*/
        if (ds.Tables[1].Rows.Count != 0)
        {
            dr = ds.Tables[1].Rows[0];
            lblCode.Text = dr["EMP_MUID"].ToString();
            lblDOJ.Text = dr["DOJ"].ToString();
            lblNxtSenior.Text = dr["NEXT_SENIOR"].ToString();
            lblJob.Text = dr["JOB_TYPE_VALUE"].ToString();
            lblEmpType.Text = dr["EMP_CODE_TYPE_VALUE"].ToString();
            lblIns.Text = dr["INS_VALUE"].ToString();
            lblServType.Text = dr["SERV_TYPE_VALUE"].ToString();
            lblShift.Text = dr["SHIFT_VALUE"].ToString();
            lblWeekOff.Text = dr["WEEK_OFF"].ToString();
        }

        /*ADDRESS INFO*/

        if (ds.Tables[2].Rows.Count != 0)
        {
            dr = ds.Tables[2].Rows[0];
            lblPrsntAdd.Text = dr["Present_Add"].ToString();
            lblPrmntAdd.Text = dr["Permanent_Add"].ToString();
        }

        /*CONTACT INFO*/

        if (ds.Tables[3].Rows.Count != 0)
        {
            dr = ds.Tables[3].Rows[0];
            lblEmail.Text = dr["MAIL_OFFICIAL"].ToString();
            lblPerEmail.Text = dr["MAIL_PERSONAL"].ToString();
            lblMob.Text = dr["MOB"].ToString();
            lblPhn.Text = dr["ext"].ToString();
        }

        /*DOCUMENT INFO*/
        fillFunctions.Fill(gvDocument, ds.Tables[4]);
        foreach (GridViewRow row in gvDocument.Rows)
        {
            if (row.Cells[2].Text == "PENDING")
            {
                row.BackColor = Color.Red;
                row.ForeColor = Color.Black;
            }
        }


        /*QUALIFICATION INFO*/
        fillFunctions.Fill(gvQualification, ds.Tables[5]);

        /*EXPERIENCE INFO*/
        fillFunctions.Fill(gvExprience, ds.Tables[6]);
        if (ds.Tables[7].Rows.Count > 0)
        {
            dr = ds.Tables[7].Rows[0];
            lblBank.Text = dr["BANK_VALUE"].ToString();
            lblPAN.Text = dr["PAN_NO"].ToString();
            lblAccNo.Text = dr["ACC_NO"].ToString();
            lblAdhar.Text = dr["ADHAR_NO"].ToString();
        }
        fillFunctions.Fill(gvDept, ds.Tables[8]);
        fillFunctions.Fill(gvDes, ds.Tables[9]);
        fillFunctions.Fill(gvEOL, ds.Tables[10]);

        fillFunctions.Fill(gvAtt, ds.Tables[12]);

    }
    protected void step1_ActiveTabChanged(object sender, EventArgs e)
    {
        ds = (DataSet)ViewState["ds"];
        if (step1.ActiveTabIndex == 0)
        {
            fillFunctions.Fill(gvDocument, ds.Tables[4]);
            foreach (GridViewRow row in gvDocument.Rows)
            {
                if (row.Cells[2].Text == "PENDING")
                {
                    row.BackColor = Color.Red;
                    row.ForeColor = Color.Black;
                }
            }

        }
        else if (step1.ActiveTabIndex == 1)
        {
            fillFunctions.Fill(gvQualification, ds.Tables[5]);
        }
        else if (step1.ActiveTabIndex == 2)
        {
            fillFunctions.Fill(gvExprience, ds.Tables[6]);
            fillFunctions.Fill(gvExpCount, ds.Tables[11]);
        }

    }


    protected void btnView_Click(object sender, EventArgs e)
    {

        bindData(commonFunctions.GetKeyID(txtCode));
    }

    public bool ThumbnailCallback()
    {
        return false;
    }

    protected void UpdateImage(int empId)
    {
        string sSavePath = "../images/emp_images/";

        // If file field isn’t empty
        if (flPhoto.PostedFile != null)
        {
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
            string sFilename = empId.ToString() + ".jpg";//System.IO.Path.GetFileName(myFile.FileName);

            int file_append = 0;

            // Save the stream to disk
            System.IO.FileStream newFile = new System.IO.FileStream(Server.MapPath(sSavePath + sFilename), System.IO.FileMode.Create);
            newFile.Write(myData, 0, myData.Length);
            newFile.Close();

            // Check whether the file is really a JPEG by opening it
            System.Drawing.Image.GetThumbnailImageAbort myCallBack = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            Bitmap myBitmap;
            try
            {
                myBitmap = new Bitmap(Server.MapPath(sSavePath + sFilename));

                // If jpg file is a jpeg, create a thumbnail filename that is unique.
                bool flag = false;
                file_append = 0;
                string sThumbFile = empId.ToString() + "_thumb.jpg";
                while (System.IO.File.Exists(Server.MapPath(sSavePath + sThumbFile)))
                {
                    flag = true;
                    file_append++;
                    sThumbFile = empId.ToString() + "-" + file_append.ToString() + "_thumb.jpg";
                }
                if (flag)
                    System.IO.File.Move(Server.MapPath(sSavePath + empId.ToString() + "_thumb.jpg"), Server.MapPath(sSavePath + sThumbFile));

                // Save thumbnail and output it onto the webpage
                System.Drawing.Image myThumbnail = myBitmap.GetThumbnailImage(100, 120, myCallBack, IntPtr.Zero);
                myThumbnail.Save(Server.MapPath(sSavePath + empId.ToString() + "_thumb.jpg"));

                // Destroy objects
                myThumbnail.Dispose();
                myBitmap.Dispose();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Uploaded successfully!!')", true);
            }
            catch (ArgumentException errArgument)
            {

                System.IO.File.Delete(Server.MapPath(sSavePath + sFilename));
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Error Occurred!!')", true);
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        UpdateImage(Convert.ToInt32(commonFunctions.GetKeyID(txtCode)));
    }
}
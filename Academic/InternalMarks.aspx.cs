using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using Ionic.Zip;
public partial class Academic_InternalMarks : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    AcaBAL AcaBal;
    AcaBLL AcaBll;
    string Msg;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        AcaBal = new AcaBAL();
        AcaBll = new AcaBLL();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnVerify.Attributes.Add("onclick", "return validat()");
        btnSave.Attributes.Add("onclick", "return validat()");
        if (!IsPostBack)
        {
            step1.ActiveTabIndex = 0;
            AcaBal.EmpId = Session["UserId"].ToString();
            fillFunctions.Fill(gvShow, AcaBll.GetFacultyPaperCombination(AcaBal).Tables[0]);
            ViewState["index"] = "";
            btnVerify.Visible = btnSave.Visible = false;
        }
    }
    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        ViewState["index"] = index.ToString();
        AcaBal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
        if (e.CommandName == "Print")
        {
            string fp = AcaBal.KeyID + ";" + Session["UserId"].ToString();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtMultiMarks.aspx?" + fp + "','_blank','alwaysRaised')", true);
        }
        else
        {
            StringBuilder strB = new StringBuilder();
            DivDownload.Visible = false;
            fillFunctions.Fill(ddlExamination, AcaBll.GetCourseExamType(AcaBal).Tables[0], true, FillFunctions.FirstItem.Select);
            lblCourseCode1.Text = gvShow.Rows[index].Cells[1].Text;
            lblCourseCode2.Text = gvShow.Rows[index].Cells[1].Text;
            if (lblCourseCode1.Text.Contains(','))
            {
                strB.Append("<h3>Download Minro-2 answer sheet.</h3> <br />");
                string[] st = lblCourseCode1.Text.Split(',');
                string str="";
                for (int i = 0; i < st.Length; i++)
                {
                    DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/MINOR/ANSWERSHEET/" + st[i].ToString().Trim() + "/"));
                    if (folders.Exists == true)
                    {
                        string pathname = Server.MapPath("../UploadedFile/MINOR/ANSWERSHEET/" + st[i].ToString().Trim() + "/");

                        using (ZipFile zip = new ZipFile())
                        {
                            zip.AddDirectory(pathname, "file");
                            //zip.AddFile(pathname, "Files");
                            zip.Save(Server.MapPath("../UploadedFile/MINOR/ANSWERSHEETZIP/" + st[i].ToString().Trim() + ".zip"));
                        }
                        str += "<a  href='../UploadedFile/MINOR/ANSWERSHEETZIP/" + st[i].ToString().Trim() + ".zip' target='_blank'>" + st[i].ToString().Trim() + " &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;Download File</a></br>";                      
                    }
                }

                strB.Append(str);
                DivDownload.Visible = true;
                DivDownload.InnerHtml = strB.ToString();


            }
            else
            {
                DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/MINOR/ANSWERSHEET/" + lblCourseCode1.Text + "/"));
                if (folders.Exists == true)
                {
                    string pathname = Server.MapPath("../UploadedFile/MINOR/ANSWERSHEET/" + lblCourseCode1.Text + "/");

                    using (ZipFile zip = new ZipFile())
                    {
                        zip.AddDirectory(pathname, "file");
                        //zip.AddFile(pathname, "Files");
                        zip.Save(Server.MapPath("../UploadedFile/MINOR/ANSWERSHEETZIP/" + lblCourseCode1.Text + ".zip"));
                    }
                    strB.Append("<h3>Download Minro-2 answer sheet.</h3> <br />");
                    strB.Append("<a id='DownloadLink' runat='server' href='../UploadedFile/MINOR/ANSWERSHEETZIP/" + lblCourseCode1.Text + ".zip' target='_blank'>Download File</a>");
                    DivDownload.Visible = true;
                    DivDownload.InnerHtml = strB.ToString();
                }
            }
            gridStudent.DataSource = "";
            gridStudent.DataBind();
            lblMaxMark.Text = "";

        }

    }
    protected void ddlExamination_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlExamination.SelectedIndex > 0)
        {
            int index = Convert.ToInt32(ViewState["index"].ToString());
            AcaBal.KeyID = gvShow.DataKeys[index].Values[0].ToString();
            ViewState["ID"] = AcaBal.KeyID;
            AcaBal.TypeId = gvShow.DataKeys[index].Values[1].ToString();
            AcaBal.Id = ddlExamination.SelectedValue;
            DataTable dt = AcaBll.GetInternalMarksStudent(AcaBal);
            if (dt.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = "INT_EXAM_ID IS NULL";
                gridStudent.DataSource = dt.DefaultView.ToTable();
                gridStudent.DataBind();
                if (gridStudent.Rows.Count > 0)
                {
                    btnVerify.Visible = true; btnSave.Visible = false;
                    lblMaxMark.Text = "Selected examination maximum Marks(" + dt.Rows[0]["EXAM_MAX_MARKS"].ToString() + ")";
                }
                else
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected course code student marks inserted.')", true);
                lblExam.Text = ddlExamination.SelectedItem.Text;
                dt.DefaultView.RowFilter = "INT_EXAM_ID IS NOT NULL";
                gridStudent1.DataSource = dt.DefaultView.ToTable();
                gridStudent1.DataBind();
            }
        }
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        TextBox txtMarks;
        btnSave.Visible = false; Boolean Valid = true;
        foreach (GridViewRow itm in gridStudent.Rows)
        {
            if (!((RangeValidator)itm.FindControl("rgvDob")).IsValid)
                Valid = false;
            txtMarks = (TextBox)itm.FindControl("txtMarks");
            txtMarks.Text = (txtMarks.Text != "") ? txtMarks.Text : "0";
        }
        if (Valid)
        {
            btnSave.Visible = true;
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "doPrint();", true);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        StringBuilder data = new StringBuilder();
        RadioButtonList AttList;
        TextBox txtMarks;
        data.AppendFormat("<INTERNAL>");
        foreach (GridViewRow row in gridStudent.Rows)
        {
            AttList = (RadioButtonList)row.FindControl("AttList");
            txtMarks = (TextBox)row.FindControl("txtMarks");
            data.AppendFormat("<MARKS TT_PAP_ID=\"" + gridStudent.DataKeys[row.RowIndex].Values[0].ToString() + "\" STU_MAIN_ID= \"" + gridStudent.DataKeys[row.RowIndex].Values[1].ToString() +
                    "\" INT_ATT_STS= \"" + AttList.SelectedValue + "\"  INT_MARKS= \"" + txtMarks.Text + "\"/>");
        }
        data.AppendFormat("</INTERNAL>");
        AcaBal.XmlValue = data.ToString();
        AcaBal.KeyID = ddlExamination.SelectedValue;
        AcaBal.SessionUserID = Session["UserId"].ToString();
        Msg = AcaBll.InternalMarksInsert(AcaBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        gridStudent.DataSource = "";
        gridStudent.DataBind();
        lblMaxMark.Text = lblCourseCode1.Text = lblCourseCode2.Text = "";
        ddlExamination.SelectedIndex = 0;
        btnVerify.Visible = btnSave.Visible = false;


    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string pp = ViewState["ID"].ToString() + ";" + ddlExamination.SelectedValue + ";" + Session["UserId"].ToString();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtSingleInternalMarks.aspx?" + pp + "','_blank','alwaysRaised')", true);
    }
    protected void AttList_SelectedIndexChanged(object sender, EventArgs e)
    {
        RadioButtonList AttList = sender as RadioButtonList;
        GridViewRow row = AttList.NamingContainer as GridViewRow;
        TextBox txt = row.FindControl("txtMarks") as TextBox;
        if (AttList.SelectedItem.Value == "0")
        {
            txt.Enabled = false;
        }
        else
        {
            txt.Enabled = true;
        }
    }
}
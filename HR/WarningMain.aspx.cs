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
using System.Data.SqlClient;

public partial class HR_WarningMain : System.Web.UI.Page
{
    FillFunctions fillfunction;
    QueryFunctions queryfunction;
    CommonFunctions common;
    Messages msg;
    HRBLL ObjHrBll;
    DataTable dt ;
    HRBAL ObjAcaBAL;
     string ext;
    protected void Page_Load(object sender, EventArgs e)
     {
         Initialize();
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;           
            fillfunction.Fill(ddlWarningType, queryfunction.GetCommand(QueryFunctions.QueryBaseType.WarningType), true, FillFunctions.FirstItem.Select);
        }
        btnSave.Attributes.Add("onclick", "return validate()");
    }
    private void Initialize()
    {
        fillfunction = new FillFunctions();
        queryfunction = new QueryFunctions();
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjAcaBAL = new HRBAL();
    }


    private void FillGrid()
    {

        dt = ObjHrBll.WarningSelect().Tables[0];                                   // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();
        //foreach (GridViewRow itm in gvShow.Rows)
        //{
        //    ImageButton img = (ImageButton)itm.FindControl("imgAct");
        //    if (dt.Rows[itm.RowIndex]["WARN_STS"].ToString() == "True")
        //    {
        //        img.ImageUrl = "../Siteimages/activate.gif";
        //        img.ToolTip = "You Want To Deactivate";
        //        img.CommandName = "Deactivate";
        //    }
        //    else
        //    {
        //        img.ImageUrl = "../Siteimages/deactivate.gif";
        //        img.ToolTip = "You Want To Activate";
        //        img.CommandName = "Activate";
        //        itm.ForeColor = System.Drawing.Color.Red;
        //    }
        //} 
    }




    protected void btnSave_Click(object sender, EventArgs e)
    {

         string[] emp = new string[2];
         emp = txtEmployeeID.Text.Split(':');
        string[] warnBy = new string[2];
        warnBy = txtWarningGivenBy.Text.Split(':');
        if ((emp.Length > 0) && (warnBy.Length > 0))
        {
            //DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/WarningLetter"));
            //if (folders.Exists == false)
            //    folders.Create();
            //ext = Path.GetExtension(FileUpload.PostedFile.FileName);
            //if ((ext != ".doc") && (ext != ".pdf") && (ext != ".docx"))
            //{ 
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Please Uploaded Appropriate File like .doc, .pdf, .docx file.')", true);
            //    FileUpload.Focus();
            //    return;
            //}
            string refNo = ObjHrBll.WarnignIsNull(ObjAcaBAL); 
            //string url = "../UploadedFile/WarningLetter/" + emp[0] + " -" + refNo + ext;
            if (ViewState["ID"].ToString() == "")
            {
                ObjAcaBAL.EmpId = common.GetKeyID(txtEmployeeID);
                ObjAcaBAL.ValueType = txtWarningSubject.Text;
                ObjAcaBAL.TypeId = ddlWarningType.SelectedValue;
                ObjAcaBAL.Date = Convert.ToDateTime(txtWarningDate.Text);
                ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
                ObjAcaBAL.InBy = common.GetKeyID(txtWarningGivenBy);
               // ObjAcaBAL.Document = url;
                ObjHrBll.WarningInsert(ObjAcaBAL);                                   //Employee Insert Information
                common.Clear(this);
                FillGrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Value Inserted')", true);
            }
            else
            {
                ObjAcaBAL.KeyID = ViewState["ID"].ToString();
                ObjAcaBAL.EmpId = common.GetKeyID(txtEmployeeID);
                ObjAcaBAL.ValueType = txtWarningSubject.Text;
                ObjAcaBAL.TypeId = ddlWarningType.SelectedValue;
                ObjAcaBAL.Date = Convert.ToDateTime(txtWarningDate.Text);
                ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
                ObjAcaBAL.InBy = common.GetKeyID(txtWarningGivenBy);
               // ObjAcaBAL.Document = url;
                ObjHrBll.WarningUpdate(ObjAcaBAL);                                       // Employee Update Information(Modify)
                common.Clear(this);
                FillGrid();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Information Updated')", true);
            }

        }
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("WARN_ID=" + ViewState["ID"].ToString());
            txtEmployeeID.Text = dr[0][15].ToString();
            txtWarningSubject.Text = dr[0][2].ToString();
           ddlWarningType.SelectedValue=dr[0][3].ToString();
            txtWarningDate.Text = dr[0][4].ToString();
           // txtWarningGivenBy.Text = dr[0][11].ToString();
           

        }
        else 
        {
            ObjAcaBAL.ChangeStatus = (e.CommandName == "Deactivate") ? "0" : "1";
            ObjAcaBAL.KeyID = e.CommandArgument.ToString();
            ObjHrBll.WarningModify(ObjAcaBAL);                                               // Employee Status Change In Update Formss
            string Msg = (e.CommandName == "Deactivate") ? "Selected Sercive Category deactivate." : "Selected Sercive Category activate.";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }

    }

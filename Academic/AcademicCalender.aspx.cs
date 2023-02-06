using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Drawing;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.IO;

public partial class Academic_AcademicCalender : System.Web.UI.Page
{
    FillFunctions FillFunctin;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    AcaBAL ObjBal;
    AcaBLL ObjBll;
    DatabaseFunctions DataBasefunction;
    DataTable Dt;
    string Msg, Extension;
    string Url;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        if (!IsPostBack)
        {
            ViewState["dt"] = "";
            ViewState["ID"] = "";
            ViewState["SCH_ID"] = "";
            FillFunctin.Fill(ddlEvent, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AcademicEvent), true, FillFunctions.FirstItem.Select);
            FillgvEvent();
            FillGvEvntSch();
        }
    }
    void Initailize()
    {
        FillFunctin = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ObjBal = new AcaBAL();
        ObjBll = new AcaBLL();
        DataBasefunction = new DatabaseFunctions();
        Dt = new DataTable();
    }
    void FillgvEvent()
    {
        Dt = ObjBll.GetEventList().Tables[0];
        ViewState["dt"] = Dt;
        gvEvent.DataSource = Dt;
        gvEvent.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjBal.Id = ViewState["ID"].ToString();
        ObjBal.Name = txtEvnt.Text;
        ObjBal.Description = txtEvntDesc.Text;
        ObjBal.SessionUserID = "851";//Session["UserId"].ToString();
       Msg =  ObjBll.EventInsertUpdate(ObjBal);
       ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
       ViewState["ID"] = "";
       clear();
       FillgvEvent(); 
    }
    void clear()
    {
        txtEvnt.Text = "";
        txtEvntDesc.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEvent);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEventFor);
        txtStartDt.Text = "";
        txtEndDt.Text = "";
    }
    protected void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvEvent.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        if (e.CommandName == "Select")
        {
            
            Dt = (DataTable)ViewState["dt"];
            DataRow[] dr = Dt.Select("ACA_EVENT_ID=" + ViewState["ID"].ToString());
            if (dr[0]["ACA_EVENT_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtEvnt.Text = dr[0]["ACA_EVENT_VALUE"].ToString();
            txtEvntDesc.Text = dr[0]["ACA_EVENT_DESC"].ToString();
        }
        else
        {
            ObjBal.ChangeStatus = e.CommandName;
            ObjBal.Id = ViewState["ID"].ToString();
             ObjBal.SessionUserID = "851";//  Session["UserId"].ToString();
           Msg=ObjBll.EventModify(ObjBal);
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
           FillgvEvent();
        }
    }

    protected void btnSaveEvnt_Click(object sender, EventArgs e)
    {
        ObjBal.KeyID = ViewState["SCH_ID"].ToString();
        ObjBal.Id = ddlEvent.SelectedValue;
        ObjBal.FromDate = CommonFunction.GetDateTime(txtStartDt.Text);
        ObjBal.ToDate = CommonFunction.GetDateTime(txtEndDt.Text);
        ObjBal.UseFor = ddlEventFor.SelectedValue;
        Msg = ObjBll.EventSchInsertUpdate(ObjBal);

        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/Academic_Calender/" + ddlEvent.SelectedItem));
        if (folders.Exists == false)
            folders.Create();
        if (FileUplod.PostedFile.FileName.ToString() != "")
        {
            Extension = Path.GetExtension(FileUplod.PostedFile.FileName);
            if ((Extension != ".doc") && (Extension != ".jpg") && (Extension != ".pdf") && (Extension != ".docx") && (Extension != ".gif"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Upload Appropriate File like .doc,.docx,.pdf,.jpg,.gif file')", true);
                FileUplod.Focus();
                return;
            }
            else
            {
                Url = "../UploadedFile/Academic_Calender/" + ddlEvent.SelectedItem + Extension;
                FileUplod.PostedFile.SaveAs(Server.MapPath(Url));
                ObjBal.Value = ddlEvent.SelectedValue;
                ObjBal.FullName = Url.ToString();
                ObjBal.SessionUserID = "851"; //Session["UserId"].ToString();
                Msg = ObjBll.UploadEvntDoc(ObjBal);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('File Uploaded Successfully ')", true);
            }
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["SCH_ID"] = "";
        clear();
        FillGvEvntSch();
    }
    void FillGvEvntSch()
    {
        Dt = ObjBll.SelectSch().Tables[0];
        ViewState["dt"] = Dt;
        GvEvntSch.DataSource = Dt;
        GvEvntSch.DataBind();
    }

    protected void GvEvntSch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["SCH_ID"] = gvEvent.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            Dt = (DataTable)ViewState["dt"];
            DataRow[] dr = Dt.Select("EVENT_SCH_ID=" + ViewState["SCH_ID"].ToString());
            if (dr[0]["STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            FillFunctin.Fill(ddlEvent, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AcademicEvent), true, FillFunctions.FirstItem.Select);
            ddlEvent.SelectedValue = dr[0]["EVENT_ID"].ToString();
            txtStartDt.Text = dr[0]["START_DT"].ToString();
            txtEndDt.Text = dr[0]["END_DT"].ToString();
            ddlEventFor.SelectedValue = dr[0]["USE_BY"].ToString();
        }
        else
        {
            ObjBal.ChangeStatus = e.CommandName;
            ObjBal.KeyID = e.CommandArgument.ToString();
            Msg = ObjBll.EventSchModify(ObjBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGvEvntSch();
        }
    }
}
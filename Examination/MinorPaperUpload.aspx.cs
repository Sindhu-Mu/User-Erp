using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
public partial class Examination_MinorPaperUpload : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions common;
    DataTable dt;
    string Msg;    
    ExaminationBal Objbal;
    ExaminationBll Objbll;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation();");
        if (!IsPostBack)
        {
            ViewState["Id"] = "";
            ViewState["dt"] = dt;
            FillFunction.Fill(ddlMinorExam, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.MinorExam), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlCourse,QueryFunction.GetCommand(QueryFunctions.QueryBaseType.FacultyCourse, Session["UserId"].ToString()), false, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlTimeSlot, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ExamTimeSlot), true, FillFunctions.FirstItem.Select);
            FillGrid();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();        
        QueryFunction = new QueryFunctions();
        common = new CommonFunctions();       
        Objbal = new ExaminationBal();
        Objbll = new ExaminationBll();
    }
    void FillGrid()
    {
        Objbal.SessionUserID = Session["UserId"].ToString();
        dt = Objbll.GetMinorOnlineMainInfo(Objbal).Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        GridPaperDetail.DataSource = dt;
        GridPaperDetail.DataBind();
    }
    void clear()
    {
       txtDate.Text = "";
        ddlCourse.SelectedIndex=ddlTimeSlot.SelectedIndex=0;
        
    }
   
    protected void GridPaperDetail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["Id"] = GridPaperDetail.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("MAIN_ID=" + ViewState["Id"].ToString());
            //if (dr[0]["ACA_BATCH_STS"].ToString() == "False")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
            //    return;
            //}
            ddlMinorExam.SelectedValue = dr[0]["MINOR_SCH_ID"].ToString();
            ddlCourse.SelectedValue = dr[0]["CRS_CODE"].ToString();
            ddlTimeSlot.SelectedValue = dr[0]["TT_SLOT_ID"].ToString();
            txtDate.Text = Convert.ToDateTime(dr[0]["EXAM_DATE"]).ToString("dd/MM/yyyy");
            
        }
        //else
        //{
        //    bal.ChangeStatus = e.CommandName;
        //    bal.KeyID = e.CommandArgument.ToString();
        //    bal.SessionUserID = Session["UserId"].ToString();
        //    Msg = bll.AcaBatchModify(bal);
        //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        //    FillGrid();
        //}
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        DirectoryInfo folders = new DirectoryInfo(Server.MapPath("../UploadedFile/MINOR/QUESTION/"+DateTime.Now.Year.ToString()+"/"));
        if (folders.Exists == false)
            folders.Create();
        if (fileupload1.PostedFile.FileName != "")
        {
            if (Path.GetExtension(fileupload1.PostedFile.FileName) == ".pdf")
            {
                Objbal.View_File = "../UploadedFile/MINOR/QUESTION/" + DateTime.Now.Year.ToString() + "/" + ddlCourse.SelectedValue + ".pdf";
                fileupload1.PostedFile.SaveAs(Server.MapPath(Objbal.View_File));
               
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Upload only pdf file.')", true);

        }       

        Objbal.Id = ViewState["Id"].ToString();
        Objbal.KeyID = ddlMinorExam.SelectedValue;
        Objbal.KeyValue = ddlCourse.SelectedValue;
        Objbal.Date = common.GetDateTime(txtDate.Text);
        Objbal.Value = ddlTimeSlot.SelectedValue;
        Objbal.SessionUserID = Session["UserId"].ToString();
        Msg = Objbll.MinorOnlineMainInsertUpdate(Objbal);
        if (Msg.Contains("successfully"))
        {     
            ViewState["Id"] = "";
            clear();
            FillGrid();
        }
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
    }
}
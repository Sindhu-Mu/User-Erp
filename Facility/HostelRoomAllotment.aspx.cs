using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class Facility_HostelRoomAllotment : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DatabaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    string Msg;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        btnAssign.Attributes.Add("OnClick", "return Allotvalidate()");
        btnVacant.Attributes.Add("OnClick", "return VacantValidate()");
        btnChange.Attributes.Add("OnClick", "return ChangeValidate()");
        //txtDate.Text = "01/07/2014";
        txtRemark.Text = "As On Demand";
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlVFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlCFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlNewRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlRoom, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
            ViewState["ID"] = "";
            ViewState["dt"] = "";
        }
    }
    void Initailize()
    {
        FillFunction=new FillFunctions();
        QueryFunction=new QueryFunctions();
        CommonFunction=new CommonFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        ds=new DataSet();
    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlFloor);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlRoomNo);
        txtStuName.Text = "";
        txtDate.Text = "";
        txtRemark.Text = "";
        
    }
    void Vacant_clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlVFloor);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlVRoomNo);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlStudent);
        txtLeavingDt.Text = "";
    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlRoomNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, Session["HostelId"].ToString(), ddlFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(ddlRoomNo);
    }
    void FillgvRoomAllot()
    {
        ObjFacBal.RoomId = ddlRoomNo.SelectedValue;
        ds = ObjFacBll.HstlRumAlmtSelect(ObjFacBal);
        ViewState["dt"] =ds.Tables[0];
        gvRoomAllot.DataSource = ds.Tables[0];
        gvRoomAllot.DataBind();
        lblBedLeft.Text = ds.Tables[1].Rows[0][0].ToString();
    }
    protected void ddlRoomNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvRoomAllot();        
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Id = ddlFloor.SelectedValue;
        ObjFacBal.RoomId = ddlRoomNo.SelectedValue;
        ObjFacBal.AuthFor = CommonFunction.GetKeyID(txtStuName);
        ObjFacBal.StuAdmNo =  ObjFacBll.GetStudentMainId(ObjFacBal);
        ObjFacBal.OccDt = CommonFunction.GetDateTime(txtDate.Text);
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.OccId = "2";
        int f = 0;
        if (ObjFacBal.KeyID == "")
        {
            DataSet ds = DatabaseFunction.GetDataSet(QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AllotedRoom));
            DataTable dt = ds.Tables[0];
            DataRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                if (txtStuName.Text == row[0].ToString())
                {
                    f = 1;
                }
            }
        }

        if (f == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('already room assigned to this Employee')", true);
            clear();
        }
        else
        {
            string Id = ObjFacBll.HstlRoomAllotInsertUpdate(ObjFacBal);
            FillgvRoomAllot();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Room Assigned Succesfully.')", true);
            clear();
           
        }
    }
    protected void ddlVFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlVRoomNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, Session["HostelId"].ToString(), ddlVFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlVRoomNo);
    }
    protected void ddlVRoomNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvRoomVcnt();
    }
    void FillgvRoomVcnt()
    {
        ObjFacBal.RoomId = ddlVRoomNo.SelectedValue;
        ds = ObjFacBll.HstlRumVctSelect(ObjFacBal);
        FillFunction.Fill(ddlStudent, ds.Tables[0], true, FillFunctions.FirstItem.Select);
        ViewState["dt"] = ds.Tables[0];
        gvRoomVcnt.DataSource = ds.Tables[0];
        gvRoomVcnt.DataBind();     
        lblBLft.Text =ds.Tables[1].Rows[0][0].ToString();
    }
    protected void btnVacant_Click(object sender, EventArgs e)
    {
        ObjFacBal.StuAdmNo = ddlStudent.SelectedValue;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.LeavDt = CommonFunction.GetDateTime(txtLeavingDt.Text);
        Msg = ObjFacBll.HstlVcntInsert(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillgvRoomVcnt();
        Vacant_clear();

    }
    protected void ddlCFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlCRoomNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, Session["HostelId"].ToString(), ddlCFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(ddlCRoomNo);
    }
    void FillgvRoomCng()
    {
        ObjFacBal.RoomId = ddlCRoomNo.SelectedValue;
        ds = ObjFacBll.HstlRumAlmtSelect(ObjFacBal);
        FillFunction.Fill(ddlCstudent, ds.Tables[0], true, FillFunctions.FirstItem.Select);
        ViewState["dt"] = ds.Tables[0];
        gvRoomCng.DataSource = ds.Tables[0];
        gvRoomCng.DataBind();
        lblBed.Text = ds.Tables[1].Rows[0][0].ToString();
    }
    protected void ddlCRoomNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgvRoomCng();
    }
    void Change_Clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlCFloor);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlCRoomNo);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlCstudent);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlNewRoom);
        txtChangeDate.Text = "";
        txtChRemark.Text = "";
    }
    protected void btnChange_Click(object sender, EventArgs e)
    {
        ObjFacBal.Id = ddlCFloor.SelectedValue;
        ObjFacBal.RoomId = ddlNewRoom.SelectedValue;
        ObjFacBal.StuAdmNo = ddlCstudent.SelectedValue;
        ObjFacBal.OccDt = CommonFunction.GetDateTime(txtChangeDate.Text);
        ObjFacBal.Remark = txtChRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.OccId = "2";
        Msg = ObjFacBll.HstlRoomChngeInsert(ObjFacBal);
        FillgvRoomCng();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        Change_Clear();
    }
    protected void gvRoomAllot_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ViewState["ID"] = gvRoomAllot.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        DataTable dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("ROOM_ID=" + ViewState["ID"].ToString() + "");
        int i = Convert.ToInt32(dr[0]["DIFF_HOUR"].ToString());
        if (i <= 24)
        {
            ddlFloor.SelectedValue = dr[0]["ROOM_FLOOR"].ToString();
            ddlRoomNo.SelectedValue = dr[0]["ROOM_ID"].ToString();
            txtDate.Text = dr[0]["OCCUPIED_DATE"].ToString();
            txtRemark.Text = dr[0]["ALLOTE_REMARK"].ToString();
            txtStuName.Text = dr[0]["STU_NAME"].ToString();
            FillgvRoomAllot();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Data can't be modified after 24 hours')", true);
        }
    }
}
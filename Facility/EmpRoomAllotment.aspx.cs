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

public partial class Facility_EmpRoomAllotment : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DatabaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataSet ds;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initailize();
        btnAllotRum.Attributes.Add("OnClick", "return Validation()");
        btnVacant.Attributes.Add("OnClick", "return Validate()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlAllotCmplx, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ResCmplxName), true, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlVCmplxName, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ResCmplxName), true, FillFunctions.FirstItem.Select);
            ViewState["ID"] = "";
            ViewState["dt"] = "";
        }
    }

    void Initailize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        ds = new DataSet();
    }
    protected void ddlAllotCmplx_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAllotCmplx.SelectedIndex > 0)
            FillFunction.Fill(ddlAllotFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, ddlAllotCmplx.SelectedValue), false, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAllotFloor);
    }
    protected void ddlAllotFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAllotFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlAllotRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, ddlAllotCmplx.SelectedValue,ddlAllotFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAllotRoom);
    }
    void FillgrRoomAllot()
    {
        ObjFacBal.RoomId = ddlAllotRoom.SelectedValue;
        ds = ObjFacBll.HstlRumAlmtSelect(ObjFacBal);
        ViewState["dt"] = ds.Tables[2];
        grRoomAllot.DataSource = ds.Tables[2];
        grRoomAllot.DataBind();
        lblBedLeft.Text = ds.Tables[1].Rows[0][0].ToString();
    }
    protected void ddlAllotRoom_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillgrRoomAllot();
    }
    void clear()
    {
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAllotFloor);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAllotRoom);
        txtAllotEmp.Text = "";
        txtAllotDt.Text = "";
        txtRemark.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEmp);
        txtVacntDt.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlAllotCmplx);
        
    }
    protected void btnAllotRum_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Id = ddlAllotFloor.SelectedValue;
        ObjFacBal.RoomId = ddlAllotRoom.SelectedValue;
        ObjFacBal.EmpId = CommonFunction.GetKeyID(txtAllotEmp);
        ObjFacBal.StuAdmNo = ObjFacBll.GetUserId(ObjFacBal);
        ObjFacBal.OccDt = CommonFunction.GetDateTime(txtAllotDt.Text);
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.OccId = "1";
        int f = 0;
        if (ObjFacBal.KeyID == "")
        {
            DataSet ds = DatabaseFunction.GetDataSet(QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AllotedRoom));
            DataTable dt = ds.Tables[0];
            DataRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                if (txtAllotEmp.Text == row[0].ToString())
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
            string ID = ObjFacBll.HstlRegAllotInsertUpdate(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prtEmpRoomAlmt.aspx?=" + ID + "','_blank','alwaysRaised')", true);
            FillgrRoomAllot();
            clear();
        }
        
      
    }
    protected void ddlVCmplxName_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVCmplxName.SelectedIndex > 0)
            FillFunction.Fill(ddlVFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, ddlVCmplxName.SelectedValue), false, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(CommonFunctions.ClearType.Index,  ddlVFloor);
    }
    protected void ddlVFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVFloor.SelectedIndex > 0)
            FillFunction.Fill(ddlVRumNo, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, ddlVCmplxName.SelectedValue, ddlVFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlVRumNo);
    }
    protected void ddlVRumNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlVRumNo.SelectedIndex > 0)
            FillFunction.Fill(ddlEmp, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.EmpResName, ddlVRumNo.SelectedValue), true, FillFunctions.FirstItem.Select);
        else
            CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlEmp);
    }
    protected void btnVacant_Click(object sender, EventArgs e)
    {
            ObjFacBal.StuAdmNo = ddlEmp.SelectedValue;
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            ObjFacBal.LeavDt = CommonFunction.GetDateTime(txtVacntDt.Text);
            Msg = ObjFacBll.HstlVcntInsert(ObjFacBal);
            CommonFunction.Clear(this);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            clear();
    }
    protected void grRoomAllot_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        ViewState["ID"] = grRoomAllot.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        DataTable dt = (DataTable)ViewState["dt"];
        DataRow[] dr = dt.Select("ROOM_ID=" + ViewState["ID"].ToString() + "");
        int i = Convert.ToInt32(dr[0]["DIFF_HOUR"].ToString());
        if (i <= 24)
        {
        ddlAllotFloor.SelectedValue = dr[0]["ROOM_FLOOR"].ToString();
        ddlAllotRoom.SelectedValue = dr[0]["ROOM_ID"].ToString();
        txtAllotDt.Text = dr[0]["OCCUPIED_DATE"].ToString();
        txtRemark.Text = dr[0]["ALLOTE_REMARK"].ToString();
        txtAllotEmp.Text = dr[0]["EMP_NAME"].ToString();
        FillgrRoomAllot();
        }
        else
        {
           ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Data can't be modified after 24 hours')", true);
        }
    }
}
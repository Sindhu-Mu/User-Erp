using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class Facility_BookRequisition : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DatabaseFunctions DataBaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg;
    DataTable Dt;
    DataSet ds;
    int Fee;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.MaintainScrollPositionOnPostBack = true;
        Initialize();
        FillGrid();
        rbtn1.Enabled = true;
        btnAssign.Attributes.Add("OnClick", "return validate()");
        // txtDate1.Text = "01/07/2015";

        if (!IsPostBack)
        {
            FillFunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, Session["HostelId"].ToString()), false, FillFunctions.FirstItem.Select);
            FillFunction.Fill(ddlRoomCat, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomCategoryTypeByHstl, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
            ViewState["ID"] = "";
            ViewState["AuthFor"] = "";
            ViewState["StuAdmNo"] = "";
            ViewState["name"] = "";
            ViewState["Iden"] = "";
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        Dt = new DataTable();
        ds = new DataSet();
    }
    public void FillGrid()
    {
        ObjFacBal.balSession = Session["UserId"].ToString();
        Dt = ObjFacBll.SelectComplexId(ObjFacBal);
        gvRoom.DataSource = Dt;
        gvRoom.DataBind();
        if (Dt.Rows.Count > 0)
        {
            div1.Visible = true;
            div2.Visible = false;
        }
        else
        {
            div2.Visible = true;
            div1.Visible = false;

        }
    }


    public void FillGvRoomAllot()
    {

        ObjFacBal.RoomId = ddlRoomByFloor.SelectedValue;
        ds = ObjFacBll.HstlRumAlmtSelect(ObjFacBal);
        ViewState["dt"] = ds.Tables[0];
        gvRoomAllot.DataSource = ds.Tables[0];
        gvRoomAllot.DataBind();
        lblBedLeft.Text = ds.Tables[1].Rows[0][0].ToString();
    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        if (lblBedLeft.Text=="0")
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('No more bed vacant in room.')", true);
        }

        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.RoomId = ddlRoomByFloor.SelectedValue;
        ObjFacBal.RoomFloor = ddlFloor.SelectedValue;
        ObjFacBal.AuthFor = ViewState["AuthFor"].ToString();
        ObjFacBal.StuAdmNo = ViewState["StuAdmNo"].ToString();
        ObjFacBal.OccDt = CommonFunction.GetDateTime(txtDate1.Text);
        ObjFacBal.Remark = txtRemark.Text;
        ObjFacBal.TypeId = rbtn1.SelectedValue;  //for new/old student
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.OccId = "2";
        int f = 0;
        if (ObjFacBal.KeyID == "")
        {
            DataSet ds = DataBaseFunction.GetDataSet(QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AllotedRoom));
            DataTable dt = ds.Tables[0];
            DataRow row;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                row = dt.Rows[i];
                if ((ViewState["name"].ToString() + ':' + ViewState["AuthFor"].ToString()) == row[0].ToString())
                {
                    f = 1;
                }
            }
        }

        if (f == 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('already room assigned to this Employee..')", true);
            clear();
        }
        else
        {
            ObjFacBal.StuAdmNo = ViewState["StuAdmNo"].ToString();
            //Fee = ObjFacBll.GetFeeRcvAmount(ObjFacBal);
            //if (Fee >= 5000)
            //{
            string Id = ObjFacBll.HstlRegAllotInsertUpdate(ObjFacBal);
            FillGvRoomAllot();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Room Assigned Succesfully.')", true);
            //ChangeHeadStatus();
            clear();
            //}
            //else
            //{
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('Fees is not Submitted...')", true);
            //}
        }
        FillGrid();
        clear();
    }
    public void clear()
    {
        //txtStudntName.Text = "";
        txtDate1.Text = "";
        txtRemark.Text = "";
        ddlFloor.SelectedIndex = 0;
        ddlRoomByFloor.SelectedIndex = 0;
        ddlRoomCat.SelectedIndex = 0;
        ddlRoomByFloor.SelectedIndex = 0;
        lblBedLeft.Text = "";
    }

    public void ChangeHeadStatus()
    {
        //ObjFacBal.balsts = "0";
        ObjFacBal.StuAdmNo = ViewState["StuAdmNo"].ToString();
        //int i = ObjFacBll.ChangeHeadStatus(ObjFacBal);
        FillGrid();
    }

    protected void ddlFloor_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlFloor.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlRoomByFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoombyFloorAndCategory, ddlRoomCat.SelectedValue, ddlFloor.SelectedValue, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
        }
    }
    protected void gvRoom_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        ObjFacBal.KeyID = gvRoom.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString();
        string allot = ObjFacBll.GetStuAllotCheck(ObjFacBal);
        if (allot == "1")
        {
            rbtn1.SelectedValue = allot;
            rbtn1.Enabled = false;
        }
        ViewState["name"] = gvRoom.Rows[Convert.ToInt16(e.CommandArgument)].Cells[2].Text;
        ViewState["StuAdmNo"] = gvRoom.DataKeys[Convert.ToInt32(e.CommandArgument)].Values[0].ToString();
        ViewState["AuthFor"] = gvRoom.Rows[Convert.ToInt16(e.CommandArgument)].Cells[1].Text;
        txtEnroll.Text = ViewState["AuthFor"].ToString();
    }

    protected void ddlRoomByFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRoomByFloor.SelectedIndex > 0)
        {
            FillGvRoomAllot();

        }
    }

}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Facility_RoomMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DataTable dt;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    String Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAdd.Attributes.Add("OnClick", "return validateType()");
        btnSave.Attributes.Add("OnClick", "return validateMain()");
        if (!IsPostBack)
        {
            PushData();
            ViewState["ID"] = "";
            FillgvRoomType();
            FillgvRoomMain();
        }
    }
    void Initialize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        dt = new DataTable();
    }
    void PushData()
    {
        FillFunction.Fill(ddlComName, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.CmplxName), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlRoomType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomType), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlRoomCat, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomCategoryType), true, FillFunctions.FirstItem.Select);
        FillFunction.FillInteger(1, 8, 1, FillFunctions.FirstItem.Select, ddlRoomFloor);
    }
    void clear()
    {
        txtRoomType.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlComName);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlRoomType);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlRoomCat);
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlRoomFloor);
        txtRoomNo.Text = "";
        txtMaxPer.Text = "";
    }
    private void FillgvRoomType()
    {
        dt = ObjFacBll.RoomTypeSelect().Tables[0];
        ViewState["dt"] = dt;
        gvRoomType.DataSource = dt;
        gvRoomType.DataBind();
    }
    private void FillgvRoomMain()
    {
        dt = ObjFacBll.RoomMainSelect().Tables[0];
        ViewState["dt"] = dt;
        gvRoomMain.DataSource = dt;
        gvRoomMain.DataBind();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Value = txtRoomType.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjFacBll.RoomTypeInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillgvRoomType();
        clear();
    }

    protected void gvRoomType_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvRoomType.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FAC_ROOM_TYP_ID=" + ViewState["ID"].ToString()+"");
            if (dr[0][2].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtRoomType.Text = dr[0][1].ToString();

        }
        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.KeyID = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.RoomTypeModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillgvRoomType();
            clear();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Name = txtRoomNo.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.Id = ddlRoomType.SelectedValue;
        ObjFacBal.CommonId = ddlRoomCat.SelectedValue;
        ObjFacBal.Value = txtMaxPer.Text;
        ObjFacBal.cmpxId = ddlComName.SelectedValue;
        ObjFacBal.RoomFloor = ddlRoomFloor.SelectedValue;
        Msg = ObjFacBll.RoomMainInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        CommonFunction.Clear(this);
        FillgvRoomMain();
        clear();
    }

    protected void gvRoomMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvRoomType.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("ROOM_ID=" + ViewState["ID"].ToString() + "");
            if (dr[0][3].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            ddlComName.SelectedValue = dr[0][5].ToString();
            ddlRoomType.SelectedValue = dr[0][6].ToString();
            ddlRoomCat.SelectedValue = dr[0][7].ToString();
            ddlRoomFloor.SelectedValue = dr[0][4].ToString();
            txtRoomNo.Text = dr[0][1].ToString();
            txtMaxPer.Text = dr[0][2].ToString();

        }
        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.KeyID = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.RoomMainModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillgvRoomMain();
            clear();
        }
    }
}
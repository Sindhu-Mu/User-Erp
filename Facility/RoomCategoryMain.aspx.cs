using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_RoomCategoryMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    DataTable dt;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnAdd.Attributes.Add("OnClick", "return Roomvalidate()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
            FillGrid(); 
            FillFunction.FillInteger(1, 10, 1, FillFunctions.FirstItem.Select, ddlNoOfBed);
          
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
    private void FillGrid()
    {
        dt = ObjFacBll.RoomCategorySelect().Tables[0];                                    
        ViewState["dt"] = dt;
        gvAdd.DataSource = dt;
        gvAdd.DataBind();

    }
    void clear()
    {
        txtRoomCatNm.Text = "";
        txtCharges.Text = "";
        CommonFunction.Clear(CommonFunctions.ClearType.Index, ddlNoOfBed);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ObjFacBal.KeyID = ViewState["ID"].ToString();
        ObjFacBal.Name = txtRoomCatNm.Text;
        ObjFacBal.Value = txtCharges.Text;
        ObjFacBal.SessionUserID = Session["UserId"].ToString();
        ObjFacBal.BedCount = ddlNoOfBed.SelectedValue;
        ObjFacBal.GenId = rdGen.SelectedValue;
        Msg = ObjFacBll.RoomCategoryInsertUpdate(ObjFacBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        FillGrid();
        clear();
    }
    protected void gvAdd_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvAdd.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FAC_ROOM_CATEGORY_ID=" + ViewState["ID"].ToString());
            if (dr[0][3].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtRoomCatNm.Text = dr[0][1].ToString();
            txtCharges.Text = dr[0][2].ToString();
            ddlNoOfBed.SelectedValue = (dr[0][4].ToString() == "0") ? "." : dr[0][4].ToString();
            rdGen.SelectedValue = (dr[0][7].ToString() == "0") ? "." : dr[0][7].ToString();
        }
        else
        {
            ObjFacBal.ChangeStatus = e.CommandName;
            ObjFacBal.KeyID = e.CommandArgument.ToString();
            ObjFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjFacBll.RoomCategoryModify(ObjFacBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            CommonFunction.Clear(this);
            FillGrid();
            clear();
        }
    }
}
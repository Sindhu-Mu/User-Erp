using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_RoomTypeMain : System.Web.UI.Page
{
    CommonFunctions common;
    Messages msg;
    FacBLL bll;
    DataTable dt;
    FacBAL bal;
    string Msg;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick","return validation()");
        txtRoomType.Attributes.Add("OnKeyPress", "return OnlySpaceAlpha()");
        if (!IsPostBack)
        {
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = dt;
        }
    }
    private void Initialize()
    {
        common = new CommonFunctions();
        msg = new Messages();
        dt = new DataTable();
        bll = new FacBLL();
        bal = new FacBAL();
    }
    private void FillGrid()
    {

        dt = bll.RoomTypeSelect().Tables[0];                                      // fill grid view with select all record from table
        ViewState["dt"] = dt;
        gvShow.DataSource = dt;
        gvShow.DataBind();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

        bal.KeyID = ViewState["ID"].ToString();
        bal.Value = txtRoomType.Text;
        bal.SessionUserID = Session["UserId"].ToString();
        Msg = bll.RoomTypeInsertUpdate(bal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        ViewState["ID"] = "";
        common.Clear(this);
        FillGrid();
    }

    protected void gvShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FAC_ROOM_TYP_ID=" + ViewState["ID"].ToString());
            if (dr[0]["FAC_ROOM_STS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtRoomType.Text = dr[0]["FAC_ROOM_VALUE"].ToString();

        }
        else
        {
            bal.ChangeStatus = e.CommandName;
            bal.KeyID = e.CommandArgument.ToString();
            bal.SessionUserID = Session["UserId"].ToString();
            Msg = bll.RoomTypeModify(bal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            ViewState["ID"] = "";
            common.Clear(this);
            FillGrid();

        }
    }
}
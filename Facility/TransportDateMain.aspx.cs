using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Facility_TransportDateMain : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    QueryFunctions queryFunctions;
    CommonFunctions commonFunctions;
    FacBAL objFacBal;
    FacBLL objfacbll;
    DataTable dt;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        SaveSlot.Attributes.Add("OnClick", "return validate()");
        if (!IsPostBack)
        {
            ViewState["ID"] = "";
            ViewState["dt"] = "";
            FillGridSlot();
        }
    }
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        objfacbll = new FacBLL();
        objFacBal = new FacBAL();
        dt = new DataTable();

    }
    void FillGridSlot()
    {
        dt = objfacbll.DateSlotSelect().Tables[0];
        ViewState["dt"] = dt;
        gvDate.DataSource = dt;
        gvDate.DataBind();
    }
    void clear()
    {
        srtslotdate.Text = "";
        endslotdate.Text = "";
    }
    protected void SaveSlot_Click(object sender, EventArgs e)
    {
        objFacBal.SlotId = ViewState["ID"].ToString();
        objFacBal.SrtDate = commonFunctions.GetDateTime(srtslotdate.Text);
        objFacBal.SessionUserID = Session["UserID"].ToString();
        objFacBal.EndDate = commonFunctions.GetDateTime(endslotdate.Text);

        Msg = objfacbll.DateSlotInsertUpdate(objFacBal);
        ViewState["ID"] = " ";
        FillGridSlot();
        commonFunctions.Clear(this);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        clear();
    }

    protected void gvDate_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvDate.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("SLOT_ID=" + ViewState["ID"].ToString());
            if (dr[0]["STATUS"].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            srtslotdate.Text = dr[0][7].ToString();
            endslotdate.Text = dr[0][8].ToString();
        }
        else
        {

            objFacBal.ChangeStatus = e.CommandName;
            objFacBal.SlotId = e.CommandArgument.ToString();
            objFacBal.SessionUserID = Session["UserId"].ToString();
            Msg = objfacbll.DateSlotDelete(objFacBal);                                        
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGridSlot();
            clear();
        }
    }
}

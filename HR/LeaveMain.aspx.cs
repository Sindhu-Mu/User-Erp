using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HR_LeaveMain : System.Web.UI.Page
{

    CommonFunctions commonFunctions;
    HRBLL ObjHrBll;
    DataTable dt;
    HRBAL ObjHrBal;
    string Msg;
    private void Initialize()
    {

        commonFunctions = new CommonFunctions();
        dt = new DataTable();
        ObjHrBll = new HRBLL();
        ObjHrBal = new HRBAL();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            ViewState["dt"] = "";
            ViewState["ID"] = "";
            FillGrid();
        }
    }
    void FillGrid()
    {
        dt = ObjHrBll.LeaveMainSelect().Tables[0];
        ViewState["dt"] = dt;
        gvLv.DataSource = dt;
        gvLv.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ObjHrBal.KeyValue = txtLvType.Text;
        ObjHrBal.Min = txtMinLv.Text;
        ObjHrBal.Max = txtMaxLv.Text;
        ObjHrBal.Total = txtAnnual.Text;
        ObjHrBal.Value1 = txtUnuse.Text;
        ObjHrBal.TypeId = ddlCrType.SelectedValue;
        ObjHrBal.RemValue = RbCF.SelectedValue;
        ObjHrBal.ValueType = RbEncash.SelectedValue;
        ObjHrBal.Pattern = RbArrng.SelectedValue;
        ObjHrBal.Value2 = RbClub.SelectedValue;
        ObjHrBal.SessionUserID = Session["UserId"].ToString();
        Msg = ObjHrBll.LeaveMainInsertUpdate(ObjHrBal);
        ViewState["ID"] = "";
        commonFunctions.Clear(this);
        FillGrid();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientscript", "alert('" + Msg + "')", true);
    }
    protected void gvLv_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvLv.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("LV_ID=" + ViewState["ID"].ToString());
            if (dr[0][10].ToString() == "False")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Can not update deactivate data.')", true);
                return;
            }
            txtLvType.Text = dr[0][1].ToString();
            txtMinLv.Text = dr[0][2].ToString();
            txtMaxLv.Text = dr[0][3].ToString();
            txtAnnual.Text = dr[0][4].ToString();
            txtUnuse.Text = dr[0][5].ToString();
            RbCF.SelectedValue = dr[0][6].ToString();
            RbEncash.SelectedValue = dr[0][8].ToString();
            ddlCrType.SelectedValue = dr[0][11].ToString();
        }
        else
        {
            ObjHrBal.ChangeStatus = e.CommandName;
            ObjHrBal.KeyID = e.CommandArgument.ToString();
            ObjHrBal.SessionUserID = Session["UserId"].ToString();
            Msg = ObjHrBll.LeaveMainDelete(ObjHrBal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        commonFunctions.Clear(this);
        FillGrid();
    }

}
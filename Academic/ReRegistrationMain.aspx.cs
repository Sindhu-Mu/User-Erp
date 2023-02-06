using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_ReRegistrationMain : System.Web.UI.Page
{
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    CommonFunctions CommonFunction;
    FacBAL objbal;
    FacBLL Objbll;
    DataTable Dt;
    string Msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initilize();
        btnSave.Attributes.Add("OnClick", "return validation()");
        if (!IsPostBack)
        {
            FillFunction.Fill(ddlSemType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.SemType), true, FillFunctions.FirstItem.Select);
            FillGrid();
            ViewState["ID"] = "";
            ViewState["dt"] = Dt;
        }
    }
    void Initilize()
    {
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        CommonFunction = new CommonFunctions();
        objbal = new FacBAL();
        Objbll = new FacBLL();
        Dt = new DataTable();
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        objbal.KeyID = ViewState["ID"].ToString();
        objbal.frdt = txtSrtDt.Text;
        objbal.Id = txtEndDt.Text;
        objbal.SlotId = txtSession.Text;
        objbal.TypeId = ddlSemType.SelectedValue;
        objbal.SessionUserID = Session["UserId"].ToString();
        Msg = Objbll.ReRegInsertUpdate(objbal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
        FillGrid();
        clear();
    }
    void FillGrid()
    {
        Dt = Objbll.ReRegMainSelect().Tables[0];
        ViewState["dt"] = Dt;
        gvReg.DataSource = Dt;
        gvReg.DataBind();
    }
    protected void gvReg_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            ViewState["ID"] = gvReg.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            Dt = (DataTable)ViewState["dt"];
            DataRow[] dr = Dt.Select("CON_REG_ID=" + ViewState["ID"].ToString());
            if (dr[0]["CON_REG_STS"].ToString() == "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Deactivated record cant be updated.')", true);
                return;
            }
            txtSrtDt.Text = dr[0]["CON_REG_START_DT"].ToString();
            txtEndDt.Text = dr[0]["CON_REG_END_DT"].ToString();
            txtSession.Text = dr[0]["CON_REG_SESSION"].ToString();
            ddlSemType.SelectedValue = dr[0]["CON_REG_SEM_TYPE"].ToString();
        }
        else
        {
            objbal.ChangeStatus = e.CommandName;
            objbal.KeyID = e.CommandArgument.ToString();
            objbal.SessionUserID = Session["UserId"].ToString();
            Msg = Objbll.ReRegModify(objbal);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + Msg + "')", true);
            FillGrid();
            clear();
        }
    }
    void clear()
    {
        txtSrtDt.Text = "";
        txtEndDt.Text = "";
        txtSession.Text = "";
        ddlSemType.SelectedIndex = 0;
    }
}
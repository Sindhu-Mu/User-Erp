using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Academic_StuInfCngRequest : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    AcaBAL objBal;
    AcaBLL objBll;
    String msg;
    DataSet dt;
    DatabaseFunctions databaseFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        tblAction.Visible = false;
        if (!IsPostBack)
        {
            
           
            fillFunctions.Fill(ddlAction, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.StuInfSts), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlsts, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.sts), true, FillFunctions.FirstItem.Select);
            ddlsts.SelectedValue = "-2";
            FillGrid();
        }
    }
    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new AcaBAL();
        objBll = new AcaBLL();
        dt = new DataSet();
        databaseFunctions = new DatabaseFunctions();
    }
    protected void gvStu_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Details")
        {
            tblAction.Visible = true;
            ViewState["Id"] = gvStu.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        }
    }
    void FillGrid()
    {
        objBal.ChangeStatus = ddlsts.SelectedValue;
        dt = objBll.GetStuCngInf(objBal);
        gvStu.DataSource = dt.Tables[0];
        gvStu.DataBind();
        lblSolved.Text = dt.Tables[2].Rows[0][0].ToString();
        lblPending.Text = dt.Tables[1].Rows[0][0].ToString();
        lblReject.Text = dt.Tables[4].Rows[0][0].ToString();
        lblTotal.Text = dt.Tables[3].Rows[0][0].ToString();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        objBal.Id = ViewState["Id"].ToString();
        objBal.Description = txtRemark.Text;
        objBal.SessionUserID = Session["UserId"].ToString();
        objBal.TypeId = "13";
        objBal.ChangeStatus = ddlAction.SelectedValue;
        msg = objBll.StuInfCngApp(objBal);
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        FillGrid();
    }
    protected void ddlsts_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
}
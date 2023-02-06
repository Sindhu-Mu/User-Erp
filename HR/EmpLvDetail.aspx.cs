using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HR_EmpLvDetail : System.Web.UI.Page
{
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    QueryFunctions queryFunctions;
    HRBAL ObjAcaBAL;
    HRBLL ObjHrBll;
    DataTable dt;
    void Initialize()
    {
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        queryFunctions = new QueryFunctions();
        ObjAcaBAL = new HRBAL();
        ObjHrBll = new HRBLL();
        dt = new DataTable();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        
        if (!IsPostBack)
        {
            for (int yy = DateTime.Today.Year; yy > DateTime.Today.Year - 5; yy--)
                ddlYear.Items.Add(yy.ToString());
            ddlYear.SelectedValue = DateTime.Today.Year.ToString();
            fillFunctions.Fill(ddlLv, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.LeaveType), true, FillFunctions.FirstItem.Select);
            bindGrid();
            ViewState["ID"] = "";
                      
        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        if (ddlDate.SelectedValue == "3")
        {
            txtSD.Enabled = true;
            txtED.Enabled = true;
        }
        else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
        {
            txtSD.Enabled = true;
            txtED.Enabled = false;
        }
        else
        {
            txtSD.Enabled = false;
            txtED.Enabled = false;
        }
        txtED.Text = txtSD.Text = "";
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        bindGrid();
    }
    void bindGrid()
    {
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ObjAcaBAL.Year = ddlYear.SelectedValue;
        ObjAcaBAL.KeyID = ddlLv.SelectedValue;
        ObjAcaBAL.ChangeStatus = ddlStatus.SelectedValue;
        ObjAcaBAL.KeyValue = ddlDate.SelectedValue;
        ObjAcaBAL.Max = txtSD.Text;
        ObjAcaBAL.Min = txtED.Text;
        ObjAcaBAL.CommonId = "0";
        DataSet ds = ObjHrBll.GetEmpLvDetail(ObjAcaBAL);

        gvLvBlnc.DataSource = ds.Tables[0];
        gvLvBlnc.DataBind();
        gvAvailed.DataSource = ds.Tables[1];
        gvAvailed.DataBind();
    }
    protected void gvAvailed_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjAcaBAL.SessionUserID = Session["UserId"].ToString();
        ObjAcaBAL.Year = ddlYear.SelectedValue;
        ObjAcaBAL.KeyID = ddlLv.SelectedValue;
        ObjAcaBAL.ChangeStatus = ddlStatus.SelectedValue;
        ObjAcaBAL.KeyValue = ddlDate.SelectedValue;
        ObjAcaBAL.Max = txtSD.Text;
        ObjAcaBAL.Min = txtED.Text;
        ObjAcaBAL.CommonId = gvAvailed.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
        DataSet ds = ObjHrBll.GetEmpLvDetail(ObjAcaBAL);
        
        gvTransaction.DataSource = ds.Tables[0];
        gvTransaction.DataBind();

        gvArrange.DataSource = ds.Tables[1];
        gvArrange.DataBind();
        trArrange.Visible=trTransaction.Visible = true;

    }
    protected void gvArrange_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        ObjAcaBAL.HeadID = gvArrange.DataKeys[Convert.ToInt16(e.CommandArgument)].Values[0].ToString();
        gvDetail.DataSource = ObjHrBll.TTatLvDate(ObjAcaBAL);
        gvDetail.DataBind();
        ModalPopupExtender1.Show();
    }
    
}
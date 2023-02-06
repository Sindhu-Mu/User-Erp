using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_FeeFullDetail : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL ObjBal;
    SFBLL ObjBll;
    DataTable dt;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnExport.Visible = false;
        btnExport2018.Visible = false;
        btnPhd.Visible = false;
        tr1.Visible = false;
        trold.Visible = false;
        tr2018.Visible = false;
        trPhd.Visible = false;
        Initialize();
        if (!IsPostBack)
        {
            pageload();

        }
       
    }
    protected void pageload()
    {
        fillfunction.Fill(ddlProcess, queryfunction.GetCommand(QueryFunctions.QueryBaseType.FeeProcess), true, FillFunctions.FirstItem.Select);
    }

    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        ObjBal = new SFBAL();
        ObjBll = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        tr1.Visible = true;
        trold.Visible = true;
        tr2018.Visible = false;
        trPhd.Visible = false;
        ObjBal.balProcessId = ddlProcess.SelectedValue;
        DataSet DS=ObjBll.FullFinanceDetails(ObjBal);
        gvDetail.DataSource = DS;
        gvDetail.DataBind();
        btnExport.Visible = true;
        btnExport2018.Visible = false;
        btnPhd.Visible = false;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("FeeDetail.xls", gvDetail);
        gvDetail.DataSource = "";
    }
    protected void btnExport2018_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("FeeDetail.xls", gvDetail2018);
        gvDetail2018.DataSource = "";
    }
    protected void btnView2018_Click(object sender, EventArgs e)
    {
        tr1.Visible = true;
        trold.Visible = false;
        tr2018.Visible = true;
        trPhd.Visible = false;
        ObjBal.balProcessId = ddlProcess.SelectedValue;
        DataSet DS = ObjBll.FullFinanceDetails2018(ObjBal);
        gvDetail2018.DataSource = DS;
        gvDetail2018.DataBind();
        btnExport.Visible = false;
        btnExport2018.Visible = true;
        btnPhd.Visible = false;
    }

    protected void btn2018Phd_Click(object sender, EventArgs e)
    {
        tr1.Visible = true;
        trold.Visible = false;
        tr2018.Visible = false;
        trPhd.Visible = true;
        ObjBal.balProcessId = ddlProcess.SelectedValue;
        DataSet DS = ObjBll.FullFinancePhd(ObjBal);
        gv2018Phd.DataSource = DS;
        gv2018Phd.DataBind();
        btnExport.Visible = false;
        btnExport2018.Visible = false;
        btnPhd.Visible = true;
    }
    protected void btnPhd_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("FeeDetail.xls", gv2018Phd);
        gv2018Phd.DataSource = "";
    }
}
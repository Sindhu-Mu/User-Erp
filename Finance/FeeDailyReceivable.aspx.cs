using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class StudentFinance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DataSet ds;
    DataView dv;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();    
        if (!IsPostBack)
        {

           
            fillfunction.Fill(ddlSession, queryfunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
            th2.Visible = false;
            th3.Visible = false;
            th4.Visible = false;
            th5.Visible = false;
            th1.Visible = false;

        }       
    }
    void FillDetail(GridView gv, DataTable dt)
    {
        gv.DataSource = dt;
        gv.DataBind();
    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        ds = new DataSet();
    }
    protected void ddlSession_SelectedIndexChanged(object sender, EventArgs e)
    {
        th1.Visible = true;
        th2.Visible = false;
        th3.Visible = false;
        th4.Visible = false;
        th5.Visible = false;
        balObj.balSession = ddlSession.SelectedValue;
        ds = bllObj.StuFinFeeReceivableSelect(balObj);
        FillDetail(gvInstitute, ds.Tables[0]);
        ViewState["Course"] = ds.Tables[1];
        ViewState["Branch"] = ds.Tables[2];
        ViewState["Semester"] = ds.Tables[3];
        ViewState["Student"] = ds.Tables[4];

    }
    protected void gvInstitute_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        th2.Visible = true;
        th3.Visible = true;
        th4.Visible = true;
        th5.Visible = true;
     
        if (e.CommandName == "INS")
        {
            dv = new DataView();
            dv.Table = (DataTable)ViewState["Course"];
            dv.RowFilter = "INS_ID='" + gvInstitute.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
            gvCourse.DataSource = dv;
            gvCourse.DataBind();
            gvBranch.DataSource = "";
            gvBranch.DataBind();
            gvSemester.DataSource = "";
            gvSemester.DataBind();
            gvStudent.DataSource = "";
            gvStudent.DataBind();
        }

    }
    protected void gvCourse_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        th3.Visible = true;
        th4.Visible = true;
        th5.Visible = true;
        if (e.CommandName == "COURSE")
        {
            dv = new DataView();
            dv.Table = (DataTable)ViewState["Branch"];
            dv.RowFilter = "INS_PGM_ID='" + gvCourse.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
            gvBranch.DataSource = dv;
            gvBranch.DataBind();
            gvSemester.DataSource = "";
            gvSemester.DataBind();
            gvStudent.DataSource = "";
            gvStudent.DataBind();
        }

    }
    void bindSemster(string Branch)
    {
        dv = new DataView();
        dv.Table = (DataTable)ViewState["Semester"];
        dv.RowFilter = "PGM_BRN_ID='" + Branch + "'";
        gvSemester.DataSource = dv;
        gvSemester.DataBind();
    }
    protected void gvBranch_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "BRANCH")
        {
            dv = new DataView();
            dv.Table = (DataTable)ViewState["Student"];
            dv.RowFilter = "PGM_BRN_ID='" + gvBranch.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "'";
            gvStudent.DataSource = dv;
            gvStudent.DataBind();
            bindSemster(gvBranch.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        }

    }
    void BindReceive(double TotDemand)
    {
        double TotReceive = 0;
        double Balance = 0;
        foreach (GridViewRow itm in gvFeeReceive.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            Balance = TotDemand;
            TotReceive = TotReceive + Convert.ToDouble(itm.Cells[4].Text);
            Balance = TotDemand - TotReceive;
            itm.Cells[5].Text = Balance.ToString("N2");
        }
        if (gvFeeReceive.Rows.Count > 0)
        {
            gvFeeReceive.FooterRow.Cells[4].Text = TotReceive.ToString("N2");
            gvFeeReceive.FooterRow.Cells[5].Text = Balance.ToString("N2");
        }
    }
    protected void gvStudent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ENROLL")
        {
            int row = Convert.ToInt32(e.CommandArgument);
            balObj.balEnrol = gvStudent.DataKeys[row].Values[0].ToString();
            balObj.balBranchId = gvStudent.DataKeys[row].Values[1].ToString();
            balObj.balSem = gvStudent.DataKeys[row].Values[2].ToString();
            ds = bllObj.StuFinFeeTransactionSelect(balObj);      
            gvFeeDemand.DataSource = ds.Tables[0];
            gvFeeDemand.DataBind();
            gvFeeReceive.DataSource = ds.Tables[1];
            gvFeeReceive.DataBind();
            ViewState["dt"] = ds.Tables[1];
            double TotDemand = 0;
            foreach (GridViewRow itm in gvFeeDemand.Rows)
            {
                itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
                TotDemand = TotDemand + Convert.ToDouble(itm.Cells[3].Text);
                BindReceive(TotDemand);
            }
            if (gvFeeDemand.Rows.Count > 0)
                gvFeeDemand.FooterRow.Cells[3].Text = TotDemand.ToString("N2");
        }

    }
    protected void gvFeeDemand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        DataView dv = new DataView();
        if (e.CommandName == "Show")
        {
            dt = (DataTable)ViewState["dt"];
            dv.Table = dt;
            dv.RowFilter = "FEE_MAIN_HEAD_ID=" + gvFeeDemand.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString() + "";
            gvFeeReceive.DataSource = dv;
            gvFeeReceive.DataBind();
            BindReceive(Convert.ToDouble(gvFeeDemand.FooterRow.Cells[3].Text));
        }

    }
  
}
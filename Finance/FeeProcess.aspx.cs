using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunctions;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    DataSet ds;
    DataRow[] dr;

    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();


        if (!IsPostBack)
        {
            fillfunction.Fill(ddlSession, queryfunctions.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.Select);
            //ddlSession.SelectedIndex = 1;
            ViewState["Edit"] = "1";
            FillGrid();
            ViewState["dt"] = dt;


        }


    }
    protected void Initialize()
    {
        queryfunctions = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
        ds = new DataSet();

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {

        balObj.balSession = ddlSession.SelectedValue;
        balObj.balSemType = RLSemType.SelectedValue;
        balObj.balProcessName = txtProcessName.Text;
        balObj.balStrtDate = cf.GetDateTime(txtStartDt.Text).ToString();
        balObj.balEndDate = cf.GetDateTime(txtLastDt.Text).ToString();
        balObj.balInBy = Session["UserId"].ToString();
        

        if ((gvFeeProcess.Rows.Count == 0) && (ViewState["Edit"].ToString() == "1"))
        {
            bllObj.FeeProcessInsert(balObj);
            Clear();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('One new fee main head inserted successfully')", true);
        }
        else
        {
            dt = (DataTable)ViewState["dt"];
            dr = dt.Select("   SESSION_ID='" + ddlSession.SelectedValue + "' AND SEM_TYPE_ID='" + RLSemType.SelectedValue + "'");
            if ((dr.Length > 0) && (ViewState["Edit"].ToString() == "1"))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Combination of selected session and semester type is already exist.!')", true);
                txtProcessName.Focus();
                return;
            }
            else if (ViewState["Edit"].ToString() == "0")
            {

                bllObj.FeeProcessUpdate(balObj);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected setting for fee receiving process modifyed.')", true);
                ViewState["Edit"] = "1";
                FillGrid();

            }
            else
            {
                bllObj.FeeProcessInsert(balObj);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('On new setting for fee receiving process inserted successfully')", true);

            }


        }

    }
    protected void gvFeeProcess_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FEE_PROS_ID=" + gvFeeProcess.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
            ViewState["Edit"] = "0";
            ViewState["ProcessId"] = e.CommandArgument.ToString();
            txtProcessName.Text = dr[0][2].ToString();
            ddlSession.SelectedValue = dr[0][3].ToString();
            RLSemType.SelectedIndex = Convert.ToInt32(dr[0][3]);
            txtStartDt.Text = Convert.ToDateTime(dr[0][7]).ToString("dd/MM/yyyy");
            txtLastDt.Text = Convert.ToDateTime(dr[0][8]).ToString("dd/MM/yyyy");

        }
        else if (e.CommandName == "Activate")
        {
            balObj.balStatus = "1";
            balObj.balProcessId = e.CommandArgument.ToString();
            bllObj.ChangHeadStatus(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected setting for fee receiving process activate.')", true);
        }
        else if (e.CommandName == "Deactivate")
        {
            balObj.balStatus = "0";
            balObj.balProcessId = e.CommandArgument.ToString();
            bllObj.ChangHeadStatus(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected setting for fee receiving process activate.')", true);
        }
    }


    public void Clear()
    {

        txtProcessName.Text = "";
        txtStartDt.Text = "";
        txtLastDt.Text = "";

    }
    public void FillGrid()
    {
        balObj.balSession = ddlSession.SelectedValue;
        dt = bllObj.FeeProcessSelect(balObj);
        ViewState["dt"] = dt;
        gvFeeProcess.DataSource = dt;
        gvFeeProcess.DataBind();

        foreach (GridViewRow itm in gvFeeProcess.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            ImageButton img = (ImageButton)itm.FindControl("imgAct");
            if (dt.Rows[itm.RowIndex]["FEE_PROS_STS"].ToString() == "True")
            {
                img.ImageUrl = "~/images/activate.gif";
                img.ToolTip = "Deactivate";
                img.CommandName = "Deactivate";
            }
            else
            {
                img.ImageUrl = "~/images/deactivate.gif";
                img.ToolTip = "Activate";
                img.CommandName = "Activate";
                itm.ForeColor = System.Drawing.Color.Red;
                itm.Font.Strikeout = true;
            }
        }


    }
}
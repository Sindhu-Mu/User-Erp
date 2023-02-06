using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions queryfunction;
    FillFunctions fillfunction;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;

    protected void Page_Load(object sender, EventArgs e)
    {
        btnSave.Attributes.Add("OnClick", "return validation()");
        Initialize();


        if (!IsPostBack)
        {
            if (Convert.ToString(Session["UserName"]) == "") Response.Redirect("../common/login.aspx");
            fillfunction.Fill(ddlHeadType, queryfunction.GetCommand(QueryFunctions.QueryBaseType.FeesHeadType), true, FillFunctions.FirstItem.Select);
            fillfunction.Fill(ddlTopHeadName, queryfunction.GetCommand(QueryFunctions.QueryBaseType.TopHeadId), true, FillFunctions.FirstItem.Select);
            FillGrid();
            ViewState["dt"] = dt;
            ViewState["HEAD_ID"] = "0";

        }


    }
    protected void Initialize()
    {
        queryfunction = new QueryFunctions();
        fillfunction = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["HEAD_ID"].ToString() == "0")
        {
            balObj.balHeadType = ddlHeadType.SelectedValue;
            balObj.balHeadName = txtHeadName.Text;
            balObj.balTopHeadId = ddlTopHeadName.SelectedValue;

            bllObj.FeeGroupHeadInsert(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('One new fee group head inserted successfully')", true);
        }
        else
        {
            balObj.balFeeGroupHeadId = ViewState["HEAD_ID"].ToString();
            balObj.balHeadType = ddlHeadType.SelectedValue;
            balObj.balHeadName = txtHeadName.Text;
            balObj.balTopHeadId = ddlTopHeadName.SelectedValue;
            bllObj.FeeGroupHeadUpdate(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected fee group head modifyed.')", true);

        }
        Clear();
        FillGrid();
        txtHeadName.Focus();
    }
    public void Clear()
    {
        txtHeadName.Text = ""; ddlHeadType.SelectedIndex = 0;
        ddlTopHeadName.SelectedIndex = 0;
        ViewState["HEAD_ID"] = "0";
    }
    public void FillGrid()
    {
        balObj.balHeadType = ddlHeadType.SelectedValue;
        dt = bllObj.FeeGroupHeadSelect(balObj);
        ViewState["dt"] = dt;
        gvGroupHeads.DataSource = dt;
        gvGroupHeads.DataBind();
        foreach (GridViewRow itm in gvGroupHeads.Rows)
        {
            itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
            ImageButton img = (ImageButton)itm.FindControl("imgAct");
            if (dt.Rows[itm.RowIndex]["FEE_GROUP_HEAD_STS"].ToString() == "True")
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
    protected void gvGroupHeads_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            dt = (DataTable)ViewState["dt"];
            ViewState["HEAD_ID"] = gvGroupHeads.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            DataRow[] dr = dt.Select("FEE_GROUP_HEAD_ID=" + ViewState["HEAD_ID"].ToString());
            ddlHeadType.SelectedValue = dr[0][2].ToString();
            ddlTopHeadName.SelectedValue = dr[0][4].ToString();
            txtHeadName.Text = dr[0][1].ToString();


            //txtDescription.Text = dr[0][4].ToString();

        }
        else if (e.CommandName == "Activate")
        {
            balObj.balStatus = "1";
            balObj.balFeeGroupHeadId = e.CommandArgument.ToString();
            bllObj.ChangeHeadStatus(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected fee group head activate.')", true);
            FillGrid();

        }
        else if (e.CommandName == "Deactivate")
        {
            balObj.balStatus = "0";
            balObj.balFeeGroupHeadId = e.CommandArgument.ToString();
            bllObj.ChangeHeadStatus(balObj);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected fee group head deactivate.')", true);
            FillGrid();
        }


    }
    protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
    {

        txtHeadName.Focus();
    }
    protected void ddlTopHeadName_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
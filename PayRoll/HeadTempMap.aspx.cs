using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class PayRoll_Sal_Template_Master : System.Web.UI.Page
{
    PRBLL prbll;
    PRBAL prbal;
    DataTable dt;   
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialisation();
       // btnAddTemplate.Attributes.Add("onclick", "return validation()");
       // BindGridData();
        if (!IsPostBack)
        {
            BindGridData();
            ViewState["Edit"] = 1;
            ViewState["dt"] = dt;
            ViewState["TEMID"] = "";
            fillFunctions.Fill(ddlTemplate, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.TempType), true, FillFunctions.FirstItem.Select);
            fillFunctions.Fill(ddlHead, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.HeadType), true, FillFunctions.FirstItem.Select);
           
        }
        
    }
    void Initialisation()
    {
        prbll = new PRBLL();
        dt = new DataTable();
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        prbal = new PRBAL();
    }
    private void BindGridData()
    {

        //dt = prbll.GetSalTemplates();
        //GridShow.DataSource = dt;
        //GridShow.DataBind();
        //ViewState["dt"] = dt;
        //foreach (GridViewRow itm in GridShow.Rows)
        //{
        //    itm.Cells[0].Text = (itm.RowIndex + 1).ToString();
        //    ImageButton img = (ImageButton)itm.FindControl("imgAct");
        //    if (dt.Rows[itm.RowIndex]["SAL_TEMP_STATUS"].ToString() == "True")
        //    {
        //        img.ImageUrl = "~/Siteimages/activate.gif";
        //        img.ToolTip = "Deactivate";
        //        img.CommandName = "Deactivate";
        //    }
        //    else
        //    {
        //        img.ImageUrl = "~/Siteimages/deactivate.gif";
        //        img.ToolTip = "Activate";
        //        img.CommandName = "Activate";
        //        itm.ForeColor = System.Drawing.Color.Red;
        //        itm.Font.Strikeout = true;
        //    }
        //}
    }
    private void ChangStatus(int action, string TempId)
    {
        prbll.ChngTempSts(action,TempId);
        BindGridData();
    }
    protected void GridShow_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            DataTable dt;
            ViewState["Edit"] = 0;
            GridView gv = (GridView)sender;
            String id = gv.ID;
            if (id.Equals("gvDeductions"))
            {
                ViewState["HEADID"] = gvDeductions.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            }
            else
            {
                ViewState["HEADID"] = gvEarnings.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            }
            prbal.balHeadId = ViewState["HEADID"].ToString();
            dt = prbll.GetHeadDetail(prbal);
            if (dt.Rows.Count>0)
            {
             
                ddlTemplate.SelectedValue = dt.Rows[0]["HEAD_TEMP_ID"].ToString();
                ddlHead.SelectedValue = dt.Rows[0]["HEAD_ID"].ToString();
                ddlValueType.SelectedValue = dt.Rows[0]["HEAD_ENTRY_TYPE"].ToString();
                txtValue.Text = dt.Rows[0]["HEAD_ENTRY_VALUE"].ToString();

            }

        }
        else if (e.CommandName == "Activate")
        {
            ChangStatus(1, e.CommandArgument.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected salary template activeted.')", true);
            
        }
        else if (e.CommandName == "Deactivate")
        {
            ChangStatus(0, e.CommandArgument.ToString());
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Selected salary template deactiveted.')", true);

        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
    //    int Count = prbll.ChkTempPresent(txtTempName.Text);
    //    if ((Count > 0) && (ViewState["Edit"].ToString() == "1"))
    //    {
    //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('This Template is already Created!')", true);
    //        txtTempName.Text = txtTempName.Text = "";
    //        return;
    //    }
    //    int TEMPID = (ViewState["Edit"].ToString() == "1") ? 0 : Convert.ToInt32(ViewState["TEMID"]);
    //    prbll.SalaryTemplateMasterInsert(TEMPID, txtTempName.Text.ToUpper(), txtTempDescription.Text, Convert.ToInt32(Session["UserId"]), 1, Convert.ToInt32(ViewState["Edit"]));
    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('One new Salary template inserted or Modifyed Successfully')", true);
    //    txtTempName.Text = txtTempDescription.Text = "";
    //    BindGridData();
    //    ViewState["Edit"] = 1;

    }
        protected void ddlTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTemplate.SelectedIndex > 0)
            {
                prbal.balTempId = ddlTemplate.SelectedValue;
                showDetail();
            }
    }
    private void showDetail()
    {

        DataSet ds= prbll.GetTempHead(prbal);
        ViewState["myTableEarn"] = ds.Tables[0];
        gvEarnings.DataSource = ds.Tables[0];
        gvEarnings.DataBind();
        ViewState["myTableDeduct"] = ds.Tables[1];
        gvDeductions.DataSource = ds.Tables[1];
        gvDeductions.DataBind();
            
    }
}
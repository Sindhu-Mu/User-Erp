using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Finance_BankAccount : System.Web.UI.Page
{
    QueryFunctions glb_qf;
    FillFunctions glb_ff;
    SFBAL balObj;
    SFBLL bllObj;
    DataTable dt;
    CommonFunctions cf;
    int status=0;
    string msg="";
    protected void Page_Load(object sender, EventArgs e)
    {
        btnAdd.Attributes.Add("OnClick", "return validation()");
        txtPriority.Attributes.Add("OnkeyPress", "return OnlyDigit()");
        Initialize();
        
        if (!IsPostBack)
        {
            glb_ff.Fill(ddlGroupHead, glb_qf.GetCommand(QueryFunctions.QueryBaseType.GroupHeadId), true, FillFunctions.FirstItem.Select);
            bindHeadData(); ViewState["Edit"] = "1"; ViewState["dt"] = dt; ViewState["HEAD_ID"] = "";
            ddlGroupHead.Focus();
        }
       
        
    }
    protected void Initialize()
    {
        glb_qf = new QueryFunctions();
        glb_ff = new FillFunctions();
        balObj = new SFBAL();
        bllObj = new SFBLL();
        dt = new DataTable();
        cf = new CommonFunctions();
    }
    protected void bindHeadData()
    {

        balObj.balFeeGroupHeadId = bllObj.checkIndex(ddlGroupHead.SelectedValue);
        dt = bllObj.GetFeesHEad(balObj);
        gvShow.DataSource = dt;
        gvShow.DataBind();
        ViewState["dt"] = dt;
        CheckActivate();
        
        
    }
    protected void gvMainHeads_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {
            dt = (DataTable)ViewState["dt"];
            ViewState["HEAD_ID"] = gvShow.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString();
            DataRow[] dr = dt.Select("FEE_MAIN_HEAD_ID=" + ViewState["HEAD_ID"].ToString());
            ViewState["Edit"] = "0";
            txtMainHeadName.Text = dr[0][2].ToString();
            ddlGroupHead.SelectedValue = dr[0][3].ToString();
            RListType.SelectedIndex = Convert.ToInt32(dr[0][5]);
            RlistInScho.SelectedIndex = Convert.ToInt32(dr[0][6]);
            RlistStrc.SelectedIndex = Convert.ToInt32(dr[0][8]);
            txtPriority.Text = dr[0][7].ToString();
        }
        else if (e.CommandName == "Activate")
        {
            if (ChangHeadStatus(1, e.CommandArgument.ToString()) == 1)
            {
                msg = "Head Activated Successfully..!";
            }
            else
            {
                msg = "Head Activation Failed..!";
            }
            cf.showAlert(this, msg);
            bindHeadData();
          }
        else if (e.CommandName == "Deactivate")
        {
            if (ChangHeadStatus(0, e.CommandArgument.ToString()) == 1)
            {
                msg = "Head Deactivated Successfully..!";
            }
            else
            {
                msg = "Head Deactivation Failed..!";
            }
            cf.showAlert(this, msg);
            bindHeadData();
        }

    }
    protected void Add_Click(object sender, EventArgs e)
    {
        if ((gvShow.Rows.Count == 0) && (ViewState["Edit"].ToString() == "1"))
        {
            balObj.balHeadName = txtMainHeadName.Text;
            balObj.balFeeGroupHeadId = ddlGroupHead.SelectedValue;
            balObj.balHeadInScho=RlistInScho.SelectedValue;
            balObj.balHeadInStruc=RlistStrc.SelectedValue;
            balObj.balHeadPriority=txtPriority.Text;
            balObj.balHeadOneTime=RListType.SelectedValue;
            bllObj.FeeMainHeadInsert(balObj);
            msg = "One new fee main head inserted successfully";
            cf.showAlert(this, msg);
             }
        else
        {
            dt = (DataTable)ViewState["dt"];
            DataRow[] dr = dt.Select("FEE_MAIN_HEAD_NAME LIKE '" + txtMainHeadName.Text + "%'");
            if ((dr.Length > 0) && (ViewState["Edit"].ToString() == "1"))
            {
                msg = "This Fees main head is already exist.!";
                cf.showAlert(this, msg);
                 txtMainHeadName.Focus();
                return;
            }
            else if (ViewState["Edit"].ToString() == "0")
            {
                balObj.balHeadName = txtMainHeadName.Text;
                balObj.balFeeGroupHeadId = ddlGroupHead.SelectedValue;
                balObj.balMainHeadId = ddlGroupHead.SelectedValue;
                balObj.balHeadInScho = RlistInScho.SelectedValue;
                balObj.balHeadInStruc = RlistStrc.SelectedValue;
                balObj.balHeadPriority = txtPriority.Text;
                balObj.balHeadOneTime = RListType.SelectedValue;
                balObj.balMainHeadId = ViewState["HEAD_ID"].ToString();
                bllObj.FeeMainHeadUpdate(balObj);
                msg = "Selected fee main head modified";
                cf.showAlert(this, msg);
              }
            else
            {
                balObj.balHeadName = txtMainHeadName.Text;
                balObj.balFeeGroupHeadId = ddlGroupHead.SelectedValue;
                balObj.balHeadInScho = RlistInScho.SelectedValue;
                balObj.balHeadInStruc = RlistStrc.SelectedValue;
                balObj.balHeadPriority = txtPriority.Text;
                balObj.balHeadOneTime = RListType.SelectedValue;
                bllObj.FeeMainHeadInsert(balObj);
                msg = "One new fee main head inserted successfully";
                cf.showAlert(this, msg);
                
            }
        }
    }
    protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvShow.DataSource = (DataTable)ViewState["dt"];
        gvShow.PageIndex = e.NewPageIndex;
        //bindHeadData();
        gvShow.DataBind();
        CheckActivate();
    }
    protected void CheckActivate()
    {
        foreach (GridViewRow itm in gvShow.Rows)
        {
        
            dt = (DataTable)ViewState["dt"];
            ImageButton img = (ImageButton)itm.FindControl("imgAct");
                if (dt.Rows[itm.RowIndex]["FEE_MAIN_HEAD_STS"].ToString() == "True")
                {
                    img.ImageUrl = "~/Siteimages/activate.gif";
                    img.ToolTip = "Deactivate";
                    img.CommandName = "Deactivate";
                }
                else
                {
                    img.ImageUrl = "~/Siteimages/deactivate.gif";
                    img.ToolTip = "Activate";
                    img.CommandName = "Activate";
                    itm.ForeColor = System.Drawing.Color.Red;
                    itm.Font.Strikeout = true;
                }
            }
           
        }
       private int ChangHeadStatus(int Status, string MainHeadId)
            {
                balObj.balMainHeadId = MainHeadId;
                balObj.balStatus = Status.ToString();
                status= bllObj.ChangeHeadSts(balObj);
                return status;
                
            }

}
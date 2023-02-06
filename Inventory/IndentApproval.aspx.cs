using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Xml;
using System.Drawing;

public partial class Inventory_IndentApproval : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {

        Initialize();
        if (!IsPostBack)
        {
            ViewState["IND_ID"] = "";
            gvInd();


        }
    }
    void gvInd()
    {
        objBal.SessionUserId = Session["UserId"].ToString();
        ds = objBll.GetIndentApprovalList(objBal);
        gvIndent.DataSource = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
        {
            gvIndent.DataBind();
            string Dept_id = ds.Tables[0].Rows[0]["DEPT_ID"].ToString();
            ViewState["Dept_id"] = Dept_id;
        }
        else
        {
            tblDtl.Visible = false;
        }

    }

    void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
        ds = new DataSet();
    }
    protected void gvIndent_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        foreach (GridViewRow row in gvIndent.Rows)
        {
            row.BackColor = Color.Transparent;
            row.Enabled = true;
        }
        gvIndent.Rows[index].BackColor = Color.White;
        gvIndent.Rows[index].Enabled = false;
        ViewState["IND_ID"] = objBal.IndId = gvIndent.DataKeys[index].Value.ToString();
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.Typ = "1";
        DataSet dataSet = objBll.GetIndentDetails(objBal);
        fillFunctions.Fill(gvApproval, dataSet.Tables[0]);
        if (gvApproval.DataKeys[0].Values["IND_STEP_ID"].ToString() == "7")
        {
            gvIndentDetails.Columns[2].Visible = true;
        }
        fillFunctions.Fill(gvIndentDetails, dataSet.Tables[1]);
        fillFunctions.Fill(gvTransactionDetails, dataSet.Tables[2]);
    }

    protected void gvApproval_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string IS_CNG_ALWD = gvIndentDetails.DataKeys[0].Values["IS_CNG_ALWD"].ToString();
        string IND_STEP_ID = gvApproval.DataKeys[0].Values["IND_STEP_ID"].ToString();
        string IS_RJT_ALWD = gvIndentDetails.DataKeys[0].Values["IS_RJT_ALWD"].ToString();
        string dept_id = ViewState["Dept_id"].ToString();
        if (e.CommandName == "1")
        {
            XmlDocument xmlData = new XmlDocument();
            if (IND_STEP_ID == "2")
            {
                if (dept_id == "1")
                {
                    objBal.Typ = "2";
                }
                else
                {
                    objBal.Typ = "1";
                }
            }

            else if (IND_STEP_ID == "3")
                objBal.Typ = "2";
            else if (IND_STEP_ID == "7")
                objBal.Typ = "3";

            if (IS_CNG_ALWD == true.ToString())
            {
                //gvApproval.Rows[0].Cells[4].Enabled = true;
                xmlData = new XmlDocument();
                XmlElement ROOT = xmlData.CreateElement("ITEM");
                xmlData.AppendChild(ROOT);
                foreach (GridViewRow row in gvIndentDetails.Rows)
                {
                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    XmlElement element = xmlData.CreateElement("ITEM_ID");
                    element.InnerText = gvIndentDetails.DataKeys[row.RowIndex].Values["ITEM_ID"].ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("APR_QTY");
                    element.InnerText = ((TextBox)row.FindControl("txtQuantity")).Text;
                    dataElement.AppendChild(element);
                }
            }

            objBal.IndId = e.CommandArgument.ToString();
            objBal.Remark = txtRemark.Text;
            objBal.Status = e.CommandName;
            objBal.OrderData = xmlData.OuterXml;
            objBal.SessionUserId = Session["UserId"].ToString();
            msg = objBll.IndentApprove(objBal);
        }
        if (e.CommandName == "2")
        {
            if (IS_RJT_ALWD == true.ToString())
            {
                objBal.IndId = e.CommandArgument.ToString();
                objBal.SessionUserId = Session["UserId"].ToString();
                objBal.Remark = txtRemark.Text;
                msg = objBll.IndentCancel(objBal);
            }
        }
        txtRemark.Text = "";
        commonFunctions.Clear(gvIndent);
        gvIndentDetails.DataSource = gvPrevious.DataSource = gvTransactionDetails.DataSource = "";
        gvIndentDetails.DataBind();
        gvTransactionDetails.DataBind();
        gvPrevious.DataBind();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        gvInd();

    }
    protected void gvIndentDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        foreach (GridViewRow row in gvIndentDetails.Rows)
        {
            row.BackColor = Color.Transparent;
            row.Enabled = true;
        }
        gvIndentDetails.Rows[index].BackColor = Color.Yellow;
        gvIndentDetails.Rows[index].Enabled = true;
        objBal.IndId = ViewState["IND_ID"].ToString();
        objBal.ItemId = gvIndentDetails.DataKeys[index].Values[1].ToString();
        dt = objBll.GetPreviousDetails(objBal).Tables[0];
        fillFunctions.Fill(gvPrevious, dt);
    }
}
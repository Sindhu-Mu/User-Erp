using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Drawing;
public partial class Inventory_IssueVoucher : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    string msg;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            ViewState["dt"] = dt;
            pushData();
        }
    }
    public void pushData()
    {
        objBal.SessionUserId = Session["UserId"].ToString();
        objBal.IndId = txtIndentNo.Text;
        if (txtIndentor.Text != "")
        {
            if (txtIndentor.Text.Contains(":"))
                objBal.KeyId = commonFunctions.GetKeyID(txtIndentor);
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('Enter Employee Name And Code')", true);
                return;
            }
        }
        else
            objBal.KeyId = "";
        fillFunctions.Fill(gvIndent, objBll.GetUnfinishedIndent(objBal));
    }
    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        dt = new DataTable();
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
        if (index != gvIndent.SelectedIndex)
        {
            gvIndent.SelectedIndex = index;

            btnIssue.Enabled = true;
            objBal.IndId = gvIndent.DataKeys[index].Value.ToString();
            DataSet dataSet = objBll.GetUnfinishedIndentDetails(objBal);

            fillFunctions.Fill(gvIndentDetails, dataSet.Tables[0]);
            fillFunctions.Fill(gvReceiving, dataSet.Tables[1]);
        }
        else
        {
            msg = "Data already available";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
        }
    }

    void Clear()
    {
        pushData();
        commonFunctions.Clear(gvIndentDetails);
        commonFunctions.Clear(gvReceiving);
        btnIssue.Enabled = false;
    }
    protected void btnIssue_Click(object sender, EventArgs e)
    {
        if (gvIndent.SelectedIndex >= 0)
        {
            XmlDocument xmlData = new XmlDocument();
            xmlData = new XmlDocument();
            XmlElement ROOT = xmlData.CreateElement("ITEM");
            xmlData.AppendChild(ROOT);
            int count = 0, f = 0;
            foreach (GridViewRow row in gvIndentDetails.Rows)
            {
                count++;
                if (((Convert.ToInt32(row.Cells[2].Text)) < (Convert.ToInt32(row.Cells[3].Text)) && (((Convert.ToInt32(row.Cells[2].Text)) < (Convert.ToInt32(((TextBox)row.FindControl("txtQuantity")).Text))) || (Convert.ToInt32(row.Cells[2].Text) == 0))))
                {
                    msg = msg + " Cant issue Item No." + count + " Quantity Not Available \n";
                    f++;
                    continue;
                }
                else
                {
                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    XmlElement element = xmlData.CreateElement("ITEM_ID");
                    element.InnerText = gvIndentDetails.DataKeys[row.RowIndex].Values["ITEM_ID"].ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("QTY");
                    element.InnerText = ((TextBox)row.FindControl("txtQuantity")).Text;
                    dataElement.AppendChild(element);
                }
            }

            objBal.IndId = gvIndent.DataKeys[gvIndent.SelectedIndex].Value.ToString();
            objBal.SessionUserId = Session["UserId"].ToString();
            objBal.OrderData = xmlData.OuterXml;
            //DataRow dr = objBll.SaveNewStoreIssueVoucher(objBal).Tables[0].Rows[0][0];
            if (gvIndentDetails.Rows.Count == f)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
                return;
            }
            else
            {
                string SIV_ID = objBll.SaveNewStoreIssueVoucher(objBal).Tables[0].Rows[0][0].ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prntSto_SIV.aspx?SIV_ID=" + SIV_ID + "')", true);
            }
        }

    }
    protected void gvIndent_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        pushData();
    }
}
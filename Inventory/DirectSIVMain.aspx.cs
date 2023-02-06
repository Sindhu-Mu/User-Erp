using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
public partial class Inventory_DirectSIVMain : System.Web.UI.Page
{
    DatabaseFunctions databaseFunctions;
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;  
    DataSet ds;

    public void Initialize()
    {
        queryFunctions = new QueryFunctions();
        fillFunctions = new FillFunctions();
        commonFunctions = new CommonFunctions();
        objBal = new INVBAL();
        objBll = new INVBLL();
        databaseFunctions = new DatabaseFunctions();
        ds = new DataSet();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
     
        Initialize();
        btnSubmit.Enabled = true;
        if (!IsPostBack)
        {
            objBal.IndId = Request.QueryString[0].ToString();          
            ds = objBll.GetSIVDetail(objBal);
            lblIndentNo.Text = ds.Tables[0].Rows[0]["IND_NO"].ToString();
            lblDateTime.Text = ds.Tables[0].Rows[0]["Date"].ToString();
            lblDept.Text = ds.Tables[0].Rows[0]["Dept_Name"].ToString();
            lblIndenter.Text = ds.Tables[0].Rows[0]["Name"].ToString();
            fillFunctions.Fill(gvItem, ds.Tables[1]);
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (gvItem.Rows.Count > 0)
        {
            XmlDocument xmlData = new XmlDocument();
            xmlData = new XmlDocument();
            XmlElement ROOT = xmlData.CreateElement("ITEM");
            xmlData.AppendChild(ROOT);
            string msg = "";
            int count = 0;
            foreach (GridViewRow row in gvItem.Rows)
            {
                
                if (Convert.ToInt32(((TextBox)row.FindControl("txtIssdQty")).Text) == 0)
                {
                    count++;
                    msg =  " Cant issue Items";
                    continue;
                }
                else
                {
                    XmlElement dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    XmlElement element = xmlData.CreateElement("ITEM_ID");
                    element.InnerText = gvItem.DataKeys[row.RowIndex].Values["ITEM_ID"].ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("QTY");
                    element.InnerText = ((TextBox)row.FindControl("txtIssdQty")).Text;
                    dataElement.AppendChild(element);
                }
            }
            if (gvItem.Rows.Count == count)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "alert('" + msg + "')", true);
                return;
            }
            else
            {
                objBal.IndId = Request.QueryString[0].ToString();
                objBal.SessionUserId = Session["UserId"].ToString();
                objBal.OrderData = xmlData.OuterXml;
                string SIV_ID = objBll.SaveNewStoreIssueVoucher(objBal).Tables[0].Rows[0][0].ToString();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('prntSto_SIV.aspx?SIV_ID=" + SIV_ID + "')", true);
            }
        }
    }
    
}
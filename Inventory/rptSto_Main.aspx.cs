using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Data.SqlClient;
public partial class Inventory_rptSto_Main : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            pushData();
        }
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

    public void pushData()
    {
        fillFunctions.Fill(ddlGRN_PO, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Sto_PO), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlGRN, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GRN_NO), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlGRN_RcvBy, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.GRN_RcvBy), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlGRN_Item, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlInd, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IND_ID), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlInd_Store, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Store), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlInd_Item, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSIVInd, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.IND_ID), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSIV, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.SIV_Id), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlSIVItem, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.ITEM), true, FillFunctions.FirstItem.All);
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlGRN_Date":
                if (ddlGRN_Date.SelectedValue == "3")
                {
                    txtGRNSD.Enabled = true;
                    txtGRNED.Enabled = true;
                }
                else if (ddlGRN_Date.SelectedValue == "1" || ddlGRN_Date.SelectedValue == "2")
                {
                    txtGRNSD.Enabled = true;
                    txtGRNED.Enabled = false;
                }
                else
                {
                    txtGRNSD.Enabled = false;
                    txtGRNED.Enabled = false;
                }
                txtGRNED.Text = txtGRNSD.Text = "";
                break;
            case "ddlInd_Date":
                if (ddlInd_Date.SelectedValue == "3")
                {
                    txtIndSD.Enabled = true;
                    txtIndED.Enabled = true;
                }
                else if (ddlInd_Date.SelectedValue == "1" || ddlInd_Date.SelectedValue == "2")
                {
                    txtIndSD.Enabled = true;
                    txtIndED.Enabled = false;
                }
                else
                {
                    txtIndSD.Enabled = false;
                    txtIndED.Enabled = false;
                }
                txtIndED.Text = txtIndSD.Text = "";
                break;

            case "ddlSIVDate":
                if (ddlSIVDate.SelectedValue == "3")
                {
                    txtSIVSD.Enabled = true;
                    txtSIVED.Enabled = true;
                }
                else if (ddlSIVDate.SelectedValue == "1" || ddlSIVDate.SelectedValue == "2")
                {
                    txtSIVSD.Enabled = true;
                    txtSIVED.Enabled = false;
                }
                else
                {
                    txtSIVSD.Enabled = false;
                    txtSIVED.Enabled = false;
                }
                txtSIVED.Text = txtSIVSD.Text = "";
                break;

            default:
                break;
        }

    }

    private void PrepareQuery()
    {
        StringBuilder query = new StringBuilder("SELECT DISTINCT 'PO_NO.'=POM.PO_NO");
       

        foreach (ListItem item in chkGRN.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in chkInd.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in chkSIV.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        query.Append(" FROM INV_STO_GRN_ITEM_INF AS GRNI INNER JOIN" +
                     " INV_STO_GRN_INF AS GRN ON GRNI.GRN_ID = GRN.GRN_ID INNER JOIN" +
                     " INV_STO_GRN_BILL_INF AS GRNB ON GRN.GRN_ID = GRNB.GRN_ID RIGHT OUTER JOIN" +
                     " INV_ITEM_MASTER AS IT ON GRNI.ITEM_ID = IT.ITEM_ID INNER JOIN" +
                     " INV_STORE_MASTER ON IT.STO_ID = INV_STORE_MASTER.STO_ID RIGHT OUTER JOIN" +
                     " INV_PUR_ORDER_MASTER POM ON GRN.PO_ID = POM.PO_ID LEFT OUTER JOIN" +
                     " INV_STO_IND_INF AS IND ON INV_STORE_MASTER.STO_ID = IND.STO_ID INNER JOIN" +
                     " INV_STO_IND_ITEM_INF AS IND_IT ON IND.IND_ID = IND_IT.IND_ID INNER JOIN" +
                     " INV_STO_IND_TRN_INF AS IND_TRAN ON IND.IND_ID = IND_TRAN.IND_ID LEFT OUTER JOIN" +
                     " INV_STO_SIV_INF SIV ON IND.IND_ID = SIV.IND_ID INNER JOIN" +
                     " INV_STO_SIV_ITEM_INF SIV_ITEM ON IT.ITEM_ID = SIV_ITEM.ITEM_ID AND SIV.SIV_ID = SIV_ITEM.SIV_ID");

        foreach (ListItem item in chkGRN.Items)
        {

            if (item.Selected)
            {
                switch (item.Value)
                {
                    case "EV.EMP_NAME":

                        query.Append(" INNER JOIN USR_INF ON GRN.RCV_BY = USR_INF.USR_ID INNER JOIN"
                     +" EMP_VIEW EV ON USR_INF.USR_LOGIN_ID = EV.EMP_ID AND GRN.RCV_BY = EV.EMP_ID");

                        break;

                    default:
                        break;
                }
            }
        }

        foreach (ListItem item in chkSIV.Items)
        {

            if (item.Selected)
            {
                switch (item.Value)
                {
                    case "EV.EMP_NAME":

                        query.Append(" INNER JOIN USR_INF ON SIV.INS_BY = USR_INF.USR_ID INNER JOIN"+
                      " EMP_VIEW AS EV ON USR_INF.USR_LOGIN_ID = EV.EMP_ID");

                        break;

                    default:
                        break;
                }
            }
        }
        query.Append(" WHERE(IT.STATUS = 1)");
        if (ddlGRN_PO.SelectedIndex > 0)
        {
            query.Append(" AND (GRN.PO_ID =" + ddlGRN_PO.SelectedValue + ")");
        }

        if (ddlGRN.SelectedIndex > 0)
        {
            query.Append(" AND (GRN.GRN_ID =" + ddlGRN.SelectedValue + ")");
        }

        if (ddlGRN_RcvBy.SelectedIndex > 0)
        {
            query.Append("AND (GRN.RCV_BY =" + ddlGRN_RcvBy.SelectedValue + ")");
        }

        if (ddlGRN_Item.SelectedIndex > 0)
        {
            query.Append(" AND (GRNI.ITEM_ID =" + ddlGRN_Item.SelectedValue + ")");
        }

        if (ddlGRN_Date.SelectedIndex > 0)
        {
            switch (ddlGRN_Date.SelectedValue)
            {
                case "1":
                    query.Append(" AND GRN.GRN_DATE < '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND GRN.GRN_DATE > '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND GRN.GRN_DATE between '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "' and " + commonFunctions.GetDateTime(txtGRNED.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlInd.SelectedIndex > 0)
        {
            query.Append(" AND (IND.IND_ID=" + ddlInd.SelectedValue + ")");
        }

        if (ddlInd_Store.SelectedIndex > 0)
        {
            query.Append(" AND (IND.STO_ID=" + ddlInd_Store.SelectedValue + ")");
        }

        if (ddlInd_Item.SelectedIndex > 0)
        {
            query.Append(" AND (IND_IT.ITEM_ID=" + ddlInd_Item.SelectedValue + ")");
        }
        if (ddlInd_Date.SelectedIndex > 0)
        {
            switch (ddlInd_Date.SelectedValue)
            {
                case "1":
                    query.Append(" AND IND.INS_DATE < '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND IND.INS_DATE > '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND IND.INS_DATE between '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "' and " + commonFunctions.GetDateTime(txtGRNED.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlSIVInd.SelectedIndex > 0)
        {
            query.Append(" AND (SIV.IND_ID =" + ddlSIVInd.SelectedValue + ")");
        }
        if (ddlSIV.SelectedIndex > 0)
        {
            query.Append(" AND (SIV.SIV_ID=" + ddlSIV.SelectedValue + ")");
        }
        if (ddlSIVItem.SelectedIndex > 0)
        {
            query.Append(" AND (SIV_ITEM.ITEM_ID =" + ddlSIVItem.SelectedValue + ")");
        }
        if (ddlSIVDate.SelectedIndex > 0)
        {
            switch (ddlSIVDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND SIV.INS_DATE < '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND SIV.INS_DATE > '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND SIV.INS_DATE between '" + commonFunctions.GetDateTime(txtGRNSD.Text) + "' and " + commonFunctions.GetDateTime(txtGRNED.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        query.Append("Order by POM.PO_NO ");
        foreach (ListItem item in chkGRN.Items)
        {
            if (item.Selected)
                query.Append(", " + item.Value);
        }
        foreach (ListItem item in chkInd.Items)
        {
            if (item.Selected)
                query.Append(", " + item.Value);
        }
        foreach (ListItem item in chkSIV.Items)
        {
            if (item.Selected)
                query.Append(", " + item.Value);
        }
        DataSet ds = new DataSet();

        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = databaseFunctions.GetDataSet(command);

        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptPur.aspx','_blank','resizable=1,width=900,height=650')", true);

    }
    
    protected void btnExecute_Click(object sender, EventArgs e)
    {
        PrepareQuery();
    }

}
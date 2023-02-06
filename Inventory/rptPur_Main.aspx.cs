using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
public partial class Inventory_rptPur_Main : System.Web.UI.Page
{
    QueryFunctions queryFunctions;
    FillFunctions fillFunctions;
    CommonFunctions commonFunctions;
    INVBAL objBal;
    INVBLL objBll;
    DatabaseFunctions databaseFunctions;
    DataTable dt;
    int f = 0,e=0,count=0;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            pushData();
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

    }
    void pushData()
    {
        fillFunctions.Fill(ddlReqNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlReqStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Req_Status), true, FillFunctions.FirstItem.All);

        fillFunctions.Fill(ddlFanNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANId), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlFANDept, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Dept_Name), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlFANStatus, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANStatus), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlFANReqNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.All);        
        //fillFunctions.Fill(ddlFANAssign, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.AssignBy), true, FillFunctions.FirstItem.All);
        
        fillFunctions.Fill(ddlPONo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurOrderRpt), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPOFAN, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.FANId), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPOReqNo, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.PurReqNo), true, FillFunctions.FirstItem.All);
        fillFunctions.Fill(ddlPOSup, queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Vendor), true, FillFunctions.FirstItem.All);
       
    }

    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlFANDate":
                if (ddlFANDate.SelectedValue == "3")
                {
                    txtFANSD.Enabled = true;
                    txtFANED.Enabled = true;
                }
                else if (ddlFANDate.SelectedValue == "1" || ddlFANDate.SelectedValue == "2")
                {
                    txtFANSD.Enabled = true;
                    txtFANED.Enabled = false;
                }
                else
                {
                    txtFANSD.Enabled = false;
                    txtFANED.Enabled = false;
                }
                txtFANED.Text = txtFANSD.Text = "";
                break;
            case "ddlPODate":
                if (ddlPODate.SelectedValue == "3")
                {
                    txtPOSD.Enabled = true;
                    txtPOED.Enabled = true;
                }
                else if (ddlPODate.SelectedValue == "1" || ddlPODate.SelectedValue == "2")
                {
                    txtPOSD.Enabled = true;
                    txtPOED.Enabled = false;
                }
                else
                {
                    txtPOSD.Enabled = false;
                    txtPOED.Enabled = false;
                }
                txtPOED.Text = txtPOSD.Text = "";
                break;
           

            default:
                break;
        }
       
    }
    private void PrepareQuery()
    {
        StringBuilder query=new StringBuilder("SELECT DISTINCT ");
            


        foreach (ListItem item in chkPurReq.Items)
        {
            if (item.Selected)
            {
                if (count == 0)
                {
                    query.Append("'"+item.Text + "' =" + item.Value);
                    count++;
                }
                else
                {
                    query.Append(", '" + item.Text + "' =" + item.Value);
                }
            }
        }
        foreach (ListItem item in chkFAN.Items)
        {
            if (item.Selected)
            {
                if (count == 0)
                {
                    query.Append("'"+item.Text + "' =" + item.Value);
                    count++;
                }
                else
                {
                    query.Append(", '" + item.Text + "' =" + item.Value);
                }
            }
        }
        foreach (ListItem item in chkPO.Items)
        {
            if (item.Selected)
            {
                if (count == 0)
                {
                    query.Append("'" + item.Text + "' =" + item.Value);
                    count++;
                }
                else
                {
                    query.Append(", '" + item.Text + "' =" + item.Value);
                }
            }
               
        }
        if (count == 0)
        {
            query = new StringBuilder("SELECT DISTINCT 'Req No.' = PURM.PUR_REQ_NO");
            count++;
        }
        query.Append(" FROM INV_PUR_REQ_MASTER AS PURM FULL OUTER JOIN"+
                      " INV_PUR_REQ_DETAIL AS PURD ON PURM.PUR_REQ_ID = PURD.PUR_REQ_ID FULL OUTER JOIN"+
                      " INV_PUR_FAN_MASTER AS FANM ON PURD.PUR_REQ_ID = FANM.FAN_PUR_ID FULL OUTER JOIN"+
                      " INV_PUR_FAN_DETAIL AS FAND FULL OUTER JOIN"+
                      " INV_PUR_ORDER_MASTER AS POM ON FAND.PO_ID = POM.PO_ID FULL OUTER JOIN"+
                      " INV_PUR_ORDER_DETAIL AS POD ON POM.PO_ID = POD.PO_ID ON FANM.FAN_ID = FAND.FAN_ID");
        foreach (ListItem item in chkPurReq.Items)
        {
            
            if (item.Selected)
            {
                switch (item.Value)
                {
                    case "IT.ITEM_NAME":
                        
                        query.Append(" LEFT OUTER JOIN INV_ITEM_MASTER IT ON PURD.REQ_ITEM_ID=IT.ITEM_ID");
                        f = 1;
                        break;
                    case "STO.STO_NAME":
                        if (f == 0)
                        {
                            query.Append(" LEFT OUTER JOIN INV_ITEM_MASTER IT ON PURD.REQ_ITEM_ID=IT.ITEM_ID "
                            + " LEFT OUTER JOIN INV_STORE_MASTER STO ON IT.STO_ID = STO.STO_ID");
                        }
                        else
                        {
                            query.Append(" LEFT OUTER JOIN INV_STORE_MASTER STO ON IT.STO_ID = STO.STO_ID");
                        }
                        break;
                    case "VEN.ORG_NAME":
                        query.Append(" LEFT OUTER JOIN INV_VENDOR_INF VEN ON VEN.VENDOR_ID = PURD.REQ_SUPP_ID");
                        break;
                    case "EV.EMP_NAME":
                        e = 1;
                        query.Append(" LEFT OUTER JOIN PROC_TRAN ON PROC_TRAN.KEY_ID = PURD.PUR_REQ_ID "+ 
                        " LEFT OUTER JOIN EMP_VIEW AS EV ON PROC_TRAN.IN_BY = EV.USR_ID");
                        break;
                    default:
                        break;
                }
            }
        }

        foreach (ListItem item in chkFAN.Items)
        {

            if (item.Selected)
            {
                switch (item.Value)
                {
                        case "EV1.EMP_NAME":
                        query.Append(" LEFT OUTER JOIN EMP_VIEW EV1 ON EV1.USR_ID = FANM.FAN_ASSIGN_BY");
                        break;
                    default:
                        break;
                }
            }
        }
        query.Append(" LEFT OUTER JOIN INV_VENDOR_INF AS VEN2 ON VEN2.VENDOR_ID = POM.PO_SUPP_CODE");
        foreach (ListItem item in chkPO.Items)
        {

            if (item.Selected)
            {
                
                switch (item.Value)
                {
                    case "IT2.Item_Name":

                        query.Append(" LEFT OUTER JOIN INV_ITEM_MASTER IT2 ON IT2.ITEM_ID = POD.ITEM_CODE");
                        f = 1;
                        break;
                    case "STO2.Sto_Name":
                        if (f == 0)
                        {
                            query.Append(" LEFT OUTER JOIN INV_ITEM_MASTER IT2 ON POD.ITEM_CODE=IT2.ITEM_ID "
                            + " LEFT OUTER JOIN INV_STORE_MASTER STO2 ON IT2.STO_ID = STO2.STO_ID");
                        }
                        else
                        {
                            query.Append(" LEFT OUTER JOIN INV_STORE_MASTER STO2 ON IT2.STO_ID = STO2.STO_ID");
                        }
                        break;
                    
                    case "EV2.EMP_NAME":
                        query.Append(" LEFT OUTER JOIN EMP_VIEW EV2 ON EV2.USR_ID = POM.CREATED_BY");
                        break;
                    default:
                        break;
                }
            }
        }
        query.Append(" WHERE(ISNULL(PURM.PUR_REQ_ID,0) >=0) ");
        if(e==1)
            query.Append(" AND (PROC_TRAN.STS_TYPE_ID = - 2) ");
        if (ddlFANDate.SelectedIndex > 0)
        {
            switch (ddlFANDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND FANM.FAN_ASSIGN_DT < '" + commonFunctions.GetDateTime(txtFANSD.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND FANM.FAN_ASSIGN_DT > '" + commonFunctions.GetDateTime(txtFANSD.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND FANM.FAN_ASSIGN_DT between '" + commonFunctions.GetDateTime(txtFANSD.Text) + "' and " + commonFunctions.GetDateTime(txtFANED.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlPODate.SelectedIndex > 0)
        {
            switch (ddlPODate.SelectedValue)
            {
                case "1":
                    query.Append(" AND POM.CREATED_DT < '" + commonFunctions.GetDateTime(txtPOSD.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND POM.CREATED_DT > '" + commonFunctions.GetDateTime(txtPOSD.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND POM.CREATED_DT between '" + commonFunctions.GetDateTime(txtPOSD.Text) + "' and " + commonFunctions.GetDateTime(txtPOED.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlReqYear.SelectedIndex > 0)
        {
            switch (ddlReqYear.SelectedValue)
            {
                case "2014-15":
                    query.Append(" AND PROC_TRAN.IN_DT between '4/1/2014 12:00:00 AM' and '3/31/2015 12:00:00 AM'");
                    break;
                
                case "2013-14":
                    query.Append(" AND PROC_TRAN.IN_DT between '4/1/2013 12:00:00 AM' and '3/31/2014 12:00:00 AM'");
                    break;
                case "2012-13":
                    query.Append(" AND PROC_TRAN.IN_DT between '4/1/2012 12:00:00 AM' and '3/31/2013 12:00:00 AM'");
                    break;
                default:
                    break;
            }
        }
        if (ddlPOYear.SelectedIndex > 0)
        {
            switch (ddlPOYear.SelectedValue)
            {
                case "2014-15":
                    query.Append(" AND POM.PO_DATE between '4/1/2014 12:00:00 AM' and '3/31/2015 12:00:00 AM'");
                    break;
                
                case "2013-14":
                    query.Append(" AND POM.PO_DATE between '4/1/2013 12:00:00 AM' and '3/31/2014 12:00:00 AM'");
                    break;
                case "2012-13":
                    query.Append(" AND POM.PO_DATE between '4/1/2012 12:00:00 AM' and '3/31/2013 12:00:00 AM'");
                    break;
                default:
                    break;
            }
        }

        if (ddlReqNo.SelectedIndex > 0)
        {
            query.Append(" AND PURM.PUR_REQ_NO =" + ddlReqNo.SelectedItem);

        }

        if (ddlReqStatus.SelectedIndex > 0)
        {
            query.Append(" AND PURM.PUR_REQ_STS ="+ddlReqStatus.SelectedValue);
            
        }


        if (ddlFanNo.SelectedIndex > 0)
        {
            query.Append(" AND PURM.FANM.FAN_NO =" + ddlFanNo.SelectedItem);

        }
        //if (ddlFANDept.SelectedIndex > 0)
        //{
        //    query.Append(" AND PURM.PUR_REQ_STS =" + ddlReqStatus.SelectedValue);

        //}

        if (ddlFANStatus.SelectedIndex > 0)
        {
            query.Append(" AND FANM.FAN_STATUS =" + ddlFANStatus.SelectedValue);

        }
        if (ddlFANReqNo.SelectedIndex > 0)
        {
            query.Append(" AND FANM.FAN_PUR_ID =" + ddlFANReqNo.SelectedValue);

        }
        if (ddlPONo.SelectedIndex > 0)
        {
            query.Append(" AND POM.PO_ID =" + ddlPONo.SelectedValue);

        }
        if (ddlPOFAN.SelectedIndex > 0)
        {
            query.Append(" AND FANM.FAN_NO =" + ddlPOFAN.SelectedItem);

        }
        if (ddlPOReqNo.SelectedIndex > 0)
        {
            query.Append(" AND PURM.PUR_REQ_STS =" + ddlPOReqNo.SelectedItem);

        }
        if (ddlPOSup.SelectedIndex > 0)
        {
            query.Append(" AND VEN2.VENDOR_ID =" + ddlPOSup.SelectedValue);

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
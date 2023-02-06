using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Facility_VehicleReport : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    FillFunctions FillFunction;
    DatabaseFunctions DatabaseFunction;
    QueryFunctions QueryFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacbll;
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            PushData();
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        DatabaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacbll = new FacBLL();
        dt = new DataTable();
    }
    void PushData()
    {
        FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlDriver, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Driver), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlPlace, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.CITY), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlVeh, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Vehicle), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlStatus, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.VehStatus), true, FillFunctions.FirstItem.All);
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlDept, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Department, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlReqDt":
                if (ddlReqDt.SelectedValue == "3")
                {
                    txtStartDt.Enabled = true;
                    txtEndDt.Enabled = true;
                }
                else if (ddlReqDt.SelectedValue == "1" || ddlReqDt.SelectedValue == "2")
                {
                    txtStartDt.Enabled = true;
                    txtEndDt.Enabled = false;
                }
                else
                {
                    txtStartDt.Enabled = false;
                    txtEndDt.Enabled = false;
                }
                txtStartDt.Text = txtEndDt.Text = "";
                break;

            case "ddlJouDate":
                if (ddlJouDate.SelectedValue == "3")
                {
                    txtSrtDt.Enabled = true;
                    txtedDt.Enabled = true;
                }
                else if (ddlJouDate.SelectedValue == "1" || ddlJouDate.SelectedValue == "2")
                {
                    txtSrtDt.Enabled = true;
                    txtedDt.Enabled = false;
                }
                else
                {
                    txtSrtDt.Enabled = false;
                    txtedDt.Enabled = false;
                }
                txtSrtDt.Text = txtedDt.Text = "";
                break;
            default:
                break;
        }
    }
    private void PrepareQuery()
    {
        StringBuilder query = new StringBuilder("Select 'Vehicle_No' = VM.VEH_REG_NO");
        foreach (ListItem item in ChVehicle.Items)
        {
            if(item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        query.Append(" FROM FAC_VEHICLE_REQ_MAIN VRM INNER JOIN "
                         + "EMP_VIEW EV ON VRM.VR_REQ_BY = EV.EMP_ID INNER JOIN "
                         + "FAC_VEHICLE_REQ_DETAIL VRD ON VRM.VR_REQ_ID = VRD.VR_REQ_ID INNER JOIN "
                         + "FAC_VEHICLE_REQ_TRAN VRT ON VRM.VR_REQ_ID = VRT.VR_REQ_ID INNER JOIN "
                         + "FAC_VEHICLE_ASSIGNMENT VA ON VRM.VR_REQ_ID = VA.REQ_ID INNER JOIN "
                         + "FAC_DRIVER_MAIN DM ON VA.DRIVER_ID = DM.DRIVER_ID INNER JOIN "
                         + "EMP_MAIN_INF EM ON DM.DRIVER_EMP_CODE = EM.EMP_ID INNER JOIN "
                         + "FAC_VEHICLE_MAIN VM ON VA.VEHICLE_ID = VM.VEH_ID INNER JOIN "
                         + "CIT_INF CT ON VRM.VR_DESTI_ADD = CT.CIT_VALUE INNER JOIN "
                         + "PROC_STS_TYPE_INF STS ON VRM.VR_STATUS = STS.STS_ID");

        if(ddlIns.SelectedIndex > 0)
            query.Append(" AND  EV.INS_ID= '" + ddlIns.SelectedValue + "'");
        if (ddlDept.SelectedIndex > 0)
            query.Append(" AND EV.DEPT_ID= '" + ddlDept.SelectedValue + "'");
        if(ddlDriver.SelectedIndex > 0)
            query.Append(" AND DM.DRIVER_EMP_CODE= '" + ddlDriver.SelectedValue + "'");
        if(ddlPlace.SelectedIndex > 0)
            query.Append(" AND CT.CIT_ID= '" + ddlPlace.SelectedValue + "'");
        if (ddlReqDt.SelectedIndex > 0)
        {
            switch (ddlReqDt.SelectedValue)
            {
                case "1":
                    query.Append(" AND VRT.VRT_DT < '" + CommonFunction.GetDateTime(txtStartDt.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND VRT.VRT_DT < '" + CommonFunction.GetDateTime(txtStartDt.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND VRT.VRT_DT '" + CommonFunction.GetDateTime(txtStartDt.Text) + "' and " + CommonFunction.GetDateTime(txtEndDt.Text) + "'");
                    break;
            }
        }
        if (ddlVeh.SelectedIndex > 0)
            query.Append(" AND VM.VEH_ID= '" + ddlVeh.SelectedValue + "'");
        if (ddlStatus.SelectedIndex > 0)
            query.Append(" AND STS.STS_ID= '" + ddlStatus.SelectedValue + "'");
        if (ddlJouDate.SelectedIndex > 0)
        {
            switch (ddlJouDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND VRD.VRD_JRNY_DT_TIME < '" + CommonFunction.GetDateTime(txtSrtDt.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND VRD.VRD_JRNY_DT_TIME < '" + CommonFunction.GetDateTime(txtSrtDt.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND VRD.VRD_JRNY_DT_TIME '" + CommonFunction.GetDateTime(txtSrtDt.Text) + "' and " + CommonFunction.GetDateTime(txtedDt.Text) + "'");
                    break;
            }
        }
        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = DatabaseFunction.GetDataSet(command);
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptVehicle.aspx','_blank','resizable=1,width=900,height=650')", true);
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        PrepareQuery();
    }
}
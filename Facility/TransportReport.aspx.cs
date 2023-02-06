using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Facility_TransportReport : System.Web.UI.Page
{
    CommonFunctions CommonFunction;
    FillFunctions FillFunction;
    QueryFunctions QueryFunction;
    DatabaseFunctions DataBaseFunction;
    FacBAL ObjFacBal;
    FacBLL ObjFacBll;
    DataTable Dt;

    protected void Page_Load(object sender, EventArgs e)
    {
        Initialize();
        if (!IsPostBack)
        {
            PushData();
            ddlSlot.SelectedIndex = 1;
        }
    }
    void Initialize()
    {
        CommonFunction = new CommonFunctions();
        FillFunction = new FillFunctions();
        QueryFunction = new QueryFunctions();
        DataBaseFunction = new DatabaseFunctions();
        ObjFacBal = new FacBAL();
        ObjFacBll = new FacBLL();
        Dt = new DataTable();
    }
    void PushData()
    {
        FillFunction.Fill(ddlGender, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Gender), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlSlot, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.SlotPrd), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlCity, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.CityName), true, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlRouteApp, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.AppBy), false, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlBus, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.BusNo), false, FillFunctions.FirstItem.Select);
        FillFunction.Fill(ddlsession, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSemType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.SemType), true, FillFunctions.FirstItem.All);
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.ProgramByIns, ddlIns.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlRoute, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Route_Name, ddlCity.SelectedValue), true, FillFunctions.FirstItem.Select);
    }
    protected void ddlRoute_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlBus, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Bus_Id, ddlRoute.SelectedValue), false, FillFunctions.FirstItem.Select);
    }
    //protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlHeadType.SelectedIndex > 0)
    //    {
    //        FillFunction.Fill(ddlFeeHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.FacilityMainHeadId), true, FillFunctions.FirstItem.All);
    //    }
    //}
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        if (ddlDate.SelectedValue == "3")
        {
            txtSD.Enabled = true;
            txtED.Enabled = true;
        }
        else if (ddlDate.SelectedValue == "1" || ddlDate.SelectedValue == "2")
        {
            txtSD.Enabled = true;
            txtED.Enabled = false;
        }
        else
        {
            txtSD.Enabled = false;
            txtED.Enabled = false;
        }
        txtSD.Text = txtED.Text = "";
    }
    private void PrepareQuery()
    {
        int i = 0;
        StringBuilder query = new StringBuilder("SELECT DISTINCT 'Enrollment_no' = StuFullView.ENROLLMENT_NO, 'Name' = StuFullView.STU_FULL_NAME");
        foreach (ListItem item in ChPersonal.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChReg.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChRouteApproval.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChFeeMain.Items)
        {
            if (item.Selected)
            {
                i = 1;
                query.Append(", '" + item.Text + "' =" + item.Value);

            }
        }
        //query.Append(" FROM TPT_STU_REG_MAIN_INF INNER JOIN "
        //             + "  TPT_STU_REG_ROUTE_INF ON TPT_STU_REG_MAIN_INF.REG_ID = TPT_STU_REG_ROUTE_INF.REG_ID INNER JOIN "
        //             + " StuFullView ON TPT_STU_REG_MAIN_INF.STU_MAIN_ID = StuFullView.STU_MAIN_ID INNER JOIN "
        //             + " TPT_DATE_SLOT_MAPP_INF ON TPT_STU_REG_MAIN_INF.SLOT_ID = TPT_DATE_SLOT_MAPP_INF.SLOT_ID INNER JOIN "
        //             + " PROC_STS_TYPE_INF ON TPT_STU_REG_MAIN_INF.STATUS = PROC_STS_TYPE_INF.STS_ID");

        query.Append(" FROM  TPT_STU_REG_MAIN_INF INNER JOIN " +
                     " TPT_STU_REG_ROUTE_INF ON TPT_STU_REG_MAIN_INF.REG_ID = TPT_STU_REG_ROUTE_INF.REG_ID INNER JOIN " +
                     " StuFullView ON TPT_STU_REG_MAIN_INF.STU_MAIN_ID = StuFullView.STU_MAIN_ID INNER JOIN " +
                     " TPT_DATE_SLOT_MAPP_INF ON TPT_STU_REG_MAIN_INF.SLOT_ID = TPT_DATE_SLOT_MAPP_INF.SLOT_ID INNER JOIN " +
                     " TPT_RTE_INF ON TPT_STU_REG_ROUTE_INF.RTE_ID = TPT_RTE_INF.RTE_ID INNER JOIN " +
                     " TPT_CITY_INF ON TPT_RTE_INF.CITY_ID = TPT_CITY_INF.CITY_ID INNER JOIN " +
                     " PROC_STS_TYPE_INF ON TPT_STU_REG_MAIN_INF.STATUS = PROC_STS_TYPE_INF.STS_ID LEFT OUTER JOIN " +
                     " TPT_STU_REG_TRAN_INF ON TPT_STU_REG_ROUTE_INF.REG_ROUTE_ID = TPT_STU_REG_TRAN_INF.REG_ROUTE_ID AND PROC_STS_TYPE_INF.STS_ID=TPT_STU_REG_TRAN_INF.STS_ID LEFT OUTER JOIN " +
                     " EMP_VIEW on TPT_STU_REG_TRAN_INF.IN_BY=EMP_VIEW.USR_ID  ");

        int f = 0;
        foreach (ListItem item in ChRouteApproval.Items)
        {
            if (item.Selected)
                f = 1;
        }

        if (i == 1)
        {
            query.Append(" LEFT OUTER JOIN Stu_Fin_View AS SF ON StuFullView.STU_MAIN_ID =SF.STU_ADM_NO ");
            #region Fees Fillter
            if (ddlsession.SelectedIndex > 0)
            {
                query.Append(" AND (SF.SESSION_ID IS NULL OR SF.SESSION_ID = " + ddlsession.SelectedValue + ")");
            }
            if (ddlSemType.SelectedIndex > 0)
            {
                query.Append(" AND (SF.SEM_TYPE_ID IS NULL OR SF.SEM_TYPE_ID = " + ddlSemType.SelectedValue + ")");
            }
            if (ddlFeeHead.SelectedIndex > 0)
            {
                query.Append(" AND (SF.FEE_MAIN_HEAD_ID= " + ddlFeeHead.SelectedValue + ")");
            }
            #endregion

        }
        //if (f == 1)
        //{
        //    query.Append(" INNER JOIN TPT_STU_REG_TRAN_INF ON TPT_STU_REG_ROUTE_INF.REG_ROUTE_ID = TPT_STU_REG_TRAN_INF.REG_ROUTE_ID  " +
        //                " AND TPT_STU_REG_TRAN_INF.IN_DT = (SELECT MAX(IN_DT) FROM TPT_STU_REG_TRAN_INF WHERE (REG_ROUTE_ID = TPT_STU_REG_ROUTE_INF.REG_ROUTE_ID)) " +
        //                " INNER JOIN EMP_VIEW ON TPT_STU_REG_TRAN_INF.IN_BY = EMP_VIEW.USR_ID " +
        //                " INNER JOIN TPT_RTE_INF ON TPT_STU_REG_ROUTE_INF.RTE_ID = TPT_RTE_INF.RTE_ID " +
        //                " INNER JOIN TPT_CITY_INF ON TPT_RTE_INF.CITY_ID = TPT_CITY_INF.CITY_ID");
        //    //query.Append(" INNER JOIN TPT_STU_APR_INF ON TPT_STU_REG_ROUTE_INF.REG_ROUTE_ID = TPT_STU_APR_INF.REG_ROUTE_ID AND TPT_STU_APR_INF.APR_DATE=(SELECT MAX(APR_DATE) FROM TPT_STU_APR_INF where REG_ROUTE_ID=TPT_STU_REG_ROUTE_INF.REG_ROUTE_ID) INNER JOIN "
        //    //              + " EMP_VIEW ON TPT_STU_APR_INF.APR_BY = EMP_VIEW.USR_ID INNER JOIN TPT_RTE_INF ON TPT_STU_APR_INF.RTE_ID = TPT_RTE_INF.RTE_ID  INNER JOIN "
        //    //            + " TPT_CITY_INF ON TPT_RTE_INF.CITY_ID = TPT_CITY_INF.CITY_ID");
        //}

        if (i == 1)
        {
            query.Append(" WHERE (StuFullView.STU_STS_ID = 1)  and (SF.FD_SUB_IS_ACTIVE=1) ");

        }
        else
        {
            query.Append(" WHERE (StuFullView.STU_STS_ID = 1)");
        }
        if (ddlGender.SelectedIndex > 0)
            query.Append(" AND  StuFullView.GEN_ID= '" + ddlGender.SelectedValue + "'");
        if (ddlIns.SelectedIndex > 0)
            query.Append(" AND  StuFullView.INS_ID= '" + ddlIns.SelectedValue + "'");
        if (ddlCourse.SelectedIndex > 0)
            query.Append(" AND StuFullView.INS_PGM_ID= '" + ddlCourse.SelectedValue + "'");
        if (ddlBranch.SelectedIndex > 0)
            query.Append(" AND StuFullView.PGM_BRN_ID= '" + ddlBranch.SelectedValue + "'");
        if (ddlDate.SelectedIndex > 0)
        {
            switch (ddlDate.SelectedValue)
            {
                case "1":
                    query.Append(" AND TPT_STU_REG_MAIN_INF.APP_DATE < '" + CommonFunction.GetDateTime(txtSD.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND TPT_STU_REG_MAIN_INF.APP_DATE < '" + CommonFunction.GetDateTime(txtSD.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND TPT_STU_REG_MAIN_INF.APP_DATE BETWEEN '" + CommonFunction.GetDateTime(txtSD.Text) + "' and '" + CommonFunction.GetDateTime(txtED.Text) + "'");
                    break;
            }
        }
        if (ddlSlot.SelectedIndex > 0)
            query.Append(" AND TPT_STU_REG_MAIN_INF.SLOT_ID= '" + ddlSlot.SelectedValue + "'");
        if (ddlCity.SelectedIndex > 0)
            query.Append(" AND TPT_STU_REG_ROUTE_INF.CITY_ID= '" + ddlCity.SelectedValue + "'");
        if (ddlRoute.SelectedIndex > 0)
            query.Append(" AND TPT_STU_REG_ROUTE_INF.RTE_ID= '" + ddlRoute.SelectedValue + "'");
        if (ddlBus.SelectedIndex > 0)
            query.Append(" AND TPT_STU_REG_ROUTE_INF.BUS_ID= '" + ddlBus.SelectedValue + "'");
        if (ddlRouteApp.SelectedIndex > 0)
            query.Append(" AND EMP_VIEW.EMP_NAME= '" + ddlRouteApp.SelectedValue + "'");
        if (ddlStatus.SelectedIndex > 0)
            query.Append("AND PROC_STS_TYPE_INF.STS_ID=" + ddlStatus.SelectedValue + "");
        foreach (ListItem item in ChRouteApproval.Items)
        {
            if (item.Text == "Approved By")
            {

                if (item.Selected == true)
                {
                    query.Append(" AND TPT_STU_REG_TRAN_INF.STS_ID!= (-2) ");
                }
            }
        }

        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = DataBaseFunction.GetDataSet(command);
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptTransport.aspx','_blank','resizable=1,width=900,height=650')", true);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        PrepareQuery();
    }
}
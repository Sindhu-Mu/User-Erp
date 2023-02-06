using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class Facility_HostelReport : System.Web.UI.Page
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
        btnView.Attributes.Add("OnClick", "return Allotvalidate()");
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
        if (Session["HostelId"].ToString() != "")
        {
            FillFunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HostelComplex, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomType,Session["HostelId"].ToString()),true, FillFunctions.FirstItem.All);
        }
        else
        {
            FillFunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlCmplx), true, FillFunctions.FirstItem.All);
            FillFunction.Fill(ddlType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlRomType),true, FillFunctions.FirstItem.All);
        }
        FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSec, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlState, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlGender, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Gender), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlReligion, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlCast, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.All);
    }
    protected void ddlComplex_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, ddlComplex.SelectedValue), false, FillFunctions.FirstItem.All);
    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomNO, ddlComplex.SelectedValue, ddlFloor.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlIns_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlCourse, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.CourseName, ddlIns.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlCourse_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlBranch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Branch, ddlCourse.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlCity, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.City, ddlState.SelectedValue), true, FillFunctions.FirstItem.All);
    }
    protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomByType, ddlType.SelectedValue,Session["HostelId"].ToString()), true, FillFunctions.FirstItem.All);
        if (ddlFloor.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomByFlrType, ddlType.SelectedValue, ddlFloor.SelectedValue,Session["HostelId"].ToString()), true, FillFunctions.FirstItem.All);
        }
    }
    protected void DateType_Change(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        switch (ddl.ID)
        {
            case "ddlAlloted":
                if(ddlAlloted.SelectedValue == "3")
                {
                    txtDOA1.Enabled = true;
                    txtDOA2.Enabled = true;
                }
                else if (ddlAlloted.SelectedValue == "1" || ddlAlloted.SelectedValue == "2")
                {
                    txtDOA1.Enabled = true;
                    txtDOA2.Enabled = false;
                }
                else
                {
                    txtDOA1.Enabled = false;
                    txtDOA2.Enabled = false;
                }
                txtDOA1.Text = txtDOA2.Text = "";
                break;

            case "ddlVacant":
                if (ddlVacant.SelectedValue == "3")
                {
                    txtDOV1.Enabled = true;
                    txtDOV2.Enabled = true;
                }
                else if (ddlVacant.SelectedValue == "1" || ddlVacant.SelectedValue == "2")
                {
                    txtDOV1.Enabled = true;
                    txtDOV2.Enabled = false;
                }
                else
                {
                    txtDOV1.Enabled = false;
                    txtDOV2.Enabled = false;
                }
                txtDOV1.Text = txtDOV2.Text = "";
                break;
            default:
                break;
        }
    }
    private void PrepareQuery()
    {
        StringBuilder query = new StringBuilder("SELECT DISTINCT [Enrollment No] = SV.ENROLLMENT_NO, 'Name' = SV.STU_FULL_NAME, 'Room' = FR.ROOM_NO ");
        foreach (ListItem item in ChPersonal.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChAcademic.Items)
        {
            if(item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChCommunication.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        foreach (ListItem item in ChHostel.Items)
        {
            if (item.Selected)
                query.Append(", '" + item.Text + "' =" + item.Value);
        }
        if (ddlYear.SelectedIndex > 0)
        {
            query.Append(" ,case when (ACA_SEM_ID%2)=0 then case when (ACA_SEM_ID*6)=sv.PGM_DURATION then 'Final Year' else 'All' end " +
                          " else case when (ACA_SEM_ID*6)=(sv.PGM_DURATION-6) then 'Final Year' else 'All' end end as year");
        }
        query.Append (" FROM FAC_ROOM_INF FR INNER JOIN FAC_HOST_ROOM_BED_INF FHRB ON FR.ROOM_ID = FHRB.ROOM_ID INNER JOIN " +
                         "StuFullView SV INNER JOIN " +
                         "FAC_HSTL_ROOM_ALLOTMENT FHRA ON SV.STU_MAIN_ID = FHRA.ALLOTED_TO ON " +
                         "FHRB.ROOM_BED_AUTO_ID = FHRA.BED_ID INNER JOIN " +
                         "FAC_COMPLEX_INF FC ON FR.CMPLX_ID = FC.FAC_CMPLX_ID LEFT OUTER JOIN " +
                         "FAC_HSTL_STU_ATT_CODE_MAP FSACM ON SV.STU_MAIN_ID = FSACM.HSACM_MAIN_ID  LEFT OUTER JOIN " +
                         "FAC_HOST_ROOM_TRAN_INF FHRT ON FHRA.ALLOTMENT_ID = FHRT.ALLOTMENT_ID  LEFT OUTER JOIN " +
                         "EMP_MAIN_INF EM ON FHRT.ALLOT_BY = EM.EMP_ID ");

        query.Append(" WHERE (FHRA.OCCUPIED_ID = 2)");

        if (ddlComplex.SelectedIndex > 0)
            query.Append(" AND  FC.FAC_CMPLX_ID= '" + ddlComplex.SelectedValue + "'");
        if (ddlFloor.SelectedIndex > 0)
            query.Append(" AND FR.ROOM_FLOOR= '" + ddlFloor.SelectedValue + "'");
        if (ddlType.SelectedIndex > 0)
            query.Append(" AND FR.MAXIMUM_PRSN= '" + ddlType.SelectedValue + "'");
        if (ddlRoom.SelectedIndex > 0)
            query.Append(" AND FR.ROOM_ID= '" + ddlRoom.SelectedValue + "'");
        if (ddlIns.SelectedIndex > 0)
            query.Append(" AND SV.INS_ID= '" + ddlIns.SelectedValue + "'");
        if (ddlBatch.SelectedIndex > 0)
            query.Append(" AND SV.ACA_BATCH_ID= '" + ddlBatch.SelectedValue + "'");
        if (ddlCourse.SelectedIndex > 0)
            query.Append(" AND SV.INS_PGM_ID= '" + ddlCourse.SelectedValue + "'");
        if (ddlBranch.SelectedIndex > 0)
            query.Append(" AND SV.PGM_BRN_ID= '" + ddlBranch.SelectedValue + "'");
        if (ddlSem.SelectedIndex > 0)
            query.Append(" AND SV.ACA_SEM_ID= '" + ddlSem.SelectedValue + "'");
        if (ddlSec.SelectedIndex > 0)
            query.Append(" AND SV.ACA_SEC_ID= '" + ddlSec.SelectedValue + "'");
        if (ddlGender.SelectedIndex > 0)
            query.Append(" AND SV.GEN_ID= '" + ddlGender.SelectedValue + "'");
        if (ddlReligion.SelectedIndex > 0)
            query.Append(" AND SV.REL_ID= '" + ddlReligion.SelectedValue + "'");
        if (ddlCast.SelectedIndex > 0)
            query.Append(" AND SV.CAS_ID= '" + ddlCast.SelectedValue + "'");
        if (ddlState.SelectedIndex > 0)
            query.Append(" AND SV.STA_ID= '" + ddlState.SelectedValue + "'");
        if (ddlCity.SelectedIndex > 0)
            query.Append(" AND SV.CIT_ID= '" + ddlCity.SelectedValue + "'");
        if (ddlStatus.SelectedIndex >=0)
            query.Append(" AND FHRA.LEAVING_DATE " + ddlStatus.SelectedValue);
        if (ddlAlloted.SelectedIndex > 0)
        {
            switch (ddlAlloted.SelectedValue)
            {
                case "1":
                    query.Append(" AND FHRA.OCCUPIED_DATE < '" + CommonFunction.GetDateTime(txtDOA1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND FHRA.OCCUPIED_DATE > '" + CommonFunction.GetDateTime(txtDOA1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND FHRA.OCCUPIED_DATE '" + CommonFunction.GetDateTime(txtDOA1.Text) + "' and " + CommonFunction.GetDateTime(txtDOA2.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlVacant.SelectedIndex > 0)
        {
            switch (ddlVacant.SelectedValue)
            {
                case "1":
                    query.Append(" AND FHRA.LEAVING_DATE < '" + CommonFunction.GetDateTime(txtDOV1.Text) + "'");
                    break;
                case "2":
                    query.Append(" AND FHRA.LEAVING_DATE > '" + CommonFunction.GetDateTime(txtDOV1.Text) + "'");
                    break;
                case "3":
                    query.Append(" AND FHRA.LEAVING_DATE BETWEEN '" + CommonFunction.GetDateTime(txtDOV1.Text) + "' and " + CommonFunction.GetDateTime(txtDOV2.Text) + "'");
                    break;
                default:
                    break;
            }
        }
        if (ddlYear.SelectedIndex > 0)
        {
            query.Append(" AND  (CASE WHEN (ACA_SEM_ID % 2) = 0 THEN CASE WHEN (ACA_SEM_ID * 6) "
                         + " = sv.PGM_DURATION THEN 'Final Year' ELSE 'All' END ELSE CASE WHEN (ACA_SEM_ID * 6) = (sv.PGM_DURATION - 6) THEN 'Final Year' ELSE 'All' END END) = '" + ddlYear.SelectedItem + " ' " );
        }
        query.Append(" ORDER BY FR.ROOM_NO");
        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = DatabaseFunction.GetDataSet(command);
        Session["ds"] = ds.GetXml();
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptHostel.aspx?id="+3+"','_blank','resizable=1,width=900,height=650')", true);
    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        PrepareQuery();
    }
}
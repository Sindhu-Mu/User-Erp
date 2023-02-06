using System;
using System.Collections.Generic;
using System.Linq;
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
    DataSet ds;
    string s= "";
   

    protected void Page_Load(object sender, EventArgs e)
    {
        btnView.Attributes.Add("OnClick", "return Allotvalidate()");
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
        ds = new DataSet();
    }
    public void PushData()
    {
        if (Session["HostelId"].ToString() != "")
        {
          FillFunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HostelComplex, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.All);
          
           
        }
        else
        {
            FillFunction.Fill(ddlComplex, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlCmplx), true, FillFunctions.FirstItem.All);
        }
       // FillFunction.Fill(ddlSession, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.CurrentSession), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlRoomCategory, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomCategoryType), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlIns, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Institution), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlBatch, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Batch), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSem, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Sem), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSec, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Section), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlState, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.State), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlGender, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Gender), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlReligion, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Religion), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlCast, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Caste), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSession, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.Session), true, FillFunctions.FirstItem.All);
        FillFunction.Fill(ddlSemType, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.SemType), true, FillFunctions.FirstItem.All);

    }

    protected void ddlComplex_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillFunction.Fill(ddlFloor, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.HstlFloor, ddlComplex.SelectedValue), false, FillFunctions.FirstItem.All);

    }
    protected void ddlFloor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFloor.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoomByFlrCmplx, ddlComplex.SelectedValue, ddlFloor.SelectedValue), true, FillFunctions.FirstItem.Select);
        }

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
    protected void ddlAlloted_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnView_Click(object sender, EventArgs e)
    {
        PrepareQuery();
        Clear();
    }
    protected void ddlRoomCategory_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlRoomCategory.SelectedIndex > 0 && ddlFloor.SelectedIndex > 0)
        {
            FillFunction.Fill(ddlRoom, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.RoombyFloorAndCategory, ddlRoomCategory.SelectedValue, ddlFloor.SelectedValue, Session["HostelId"].ToString()), true, FillFunctions.FirstItem.Select);
        }
    }
    //protected void ddlHeadType_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlHeadType.SelectedIndex > 0)
    //    {
    //        //FillFunction.Fill(ddlFeeHead, QueryFunction.GetCommand(QueryFunctions.QueryBaseType.FacilityMainHeadId), true, FillFunctions.FirstItem.All);
    //    }
    //}
    public void PrepareQuery()
    {
        int i = 0;
        StringBuilder query = new StringBuilder("SELECT DISTINCT 'Enrollment' = SV.ENROLLMENT_NO, 'Name' = SV.STU_FULL_NAME,'Room' = FR.ROOM_NO");
        //string Groupquery = "SV.ENROLLMENT_NO,SV.STU_FULL_NAME,FR.ROOM_NO";
        //foreach (ListItem item in ChPersonal.Items)
        //{
        //    if (item.Selected)
        //        query.Append(", '" + item.Text + "' =" + item.Value);
        //}
        //foreach (ListItem item in ChAcademic.Items)
        //{
        //    if (item.Selected)
        //        query.Append(", '" + item.Text + "' =" + item.Value);
        //}
        foreach (ListItem item in ChCommunication.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
               // Groupquery = Groupquery + "," + item.Value;
            }
        }
        foreach (ListItem item in ChHostel.Items)
        {
            if (item.Selected)
            {
                query.Append(", '" + item.Text + "' =" + item.Value);
              //  Groupquery = Groupquery + "," + item.Value;
            }
           
        }
        foreach (ListItem item in ChFeeMain.Items)
        {
            if (item.Selected)
            {
                i = 1;
                query.Append(", '" + item.Text + "' =" + item.Value);

            }
        }
        if (ddlYear.SelectedIndex > 0)
        {
            query.Append(" ,case when (ACA_SEM_ID%2)=0 then case when (ACA_SEM_ID*6)=sv.PGM_DURATION then 'Final Year' else 'All' end " +
                          " else case when (ACA_SEM_ID*6)=(sv.PGM_DURATION-6) then 'Final Year' else 'All' end end as year");
        }

       
        query.Append("  FROM HSTL_REG_SLOT_MAPP_INF INNER JOIN " +
                     "  StuFullView AS SV INNER JOIN  " +
                     "  STU_HSTL_DETAIL_INF AS SHD INNER JOIN HSTL_REG_SLOT_MAPP_INF AS HC ON SHD.SLOT_ID=HC.SLOT_ID INNER JOIN " +
                     "  FAC_COMPLEX_INF AS FC ON SHD.COMPLEX_ID = FC.FAC_CMPLX_ID ON SV.STU_MAIN_ID = SHD.STU_MAIN_ID ON " +
                     "  HSTL_REG_SLOT_MAPP_INF.SLOT_ID = SHD.SLOT_ID LEFT OUTER JOIN " +
                     "  FAC_HSTL_ROOM_ALLOTMENT AS FHRA ON SHD.ID = FHRA.REG_SUB_ID AND SHD.STU_MAIN_ID = FHRA.ALLOTED_TO LEFT OUTER JOIN " +
                     "  FAC_HOST_ROOM_BED_INF AS FHRB  ON FHRA.BED_ID = FHRB.ROOM_BED_AUTO_ID LEFT OUTER JOIN " +
                     "  FAC_ROOM_INF AS FR ON FHRB.ROOM_ID = FR.ROOM_ID  LEFT OUTER JOIN " +
                     "  FAC_HOST_ROOM_TRAN_INF AS FHRT  ON FHRA.ALLOTMENT_ID = FHRT.ALLOTMENT_ID "+
                     "  LEFT OUTER JOIN UserView AS EM ON  FHRT.ALLOT_BY=EM.USR_ID ");
        if (i == 1)
        {
            query.Append(" LEFT OUTER JOIN Stu_Fin_View AS SF ON SV.STU_MAIN_ID =SF.STU_ADM_NO ");
            #region Fees Fillter
            if (ddlSession.SelectedIndex > 0)
            {
                query.Append(" AND (SF.SESSION_ID IS NULL OR SF.SESSION_ID = " + ddlSession.SelectedValue + ")");
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
        query.Append(" WHERE SHD.STS NOT IN(11,0) AND (FHRA.LEAVING_DATE IS NULL) ");
     
        if (ddlComplex.SelectedIndex > 0)
            query.Append(" AND  FC.FAC_CMPLX_ID= '" + ddlComplex.SelectedValue + "'");
        if (ddlFloor.SelectedIndex > 0)
            query.Append(" AND FR.ROOM_FLOOR= '" + ddlFloor.SelectedValue + "'");
        if( ddlRoomCategory.SelectedIndex >0 )
            query.Append(" AND SHD.CAT_ID= '" + ddlRoomCategory.SelectedValue + "'");
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
        if (ddlStatus.SelectedIndex > 0)
        {
            query.Append(" AND SHD.STS= '" + ddlStatus.SelectedValue + "'");
            //if (ddlStatus.SelectedValue == "1" || ddlStatus.SelectedValue=="2")
            //{
            //    query.Append(" AND (FHRA.LEAVING_DATE IS NULL) ");
            //}
        }
        if (ddlSession.SelectedIndex > 0)
            query.Append(" AND HC.SESSION_ID= '" + ddlSession.SelectedValue + "'");
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

       
       
        if (ddlYear.SelectedIndex > 0)
        {
            query.Append(" AND (CASE WHEN (ACA_SEM_ID % 2) = 0 THEN CASE WHEN (ACA_SEM_ID * 6) "
                         + " = sv.PGM_DURATION THEN 'Final Year' ELSE 'All' END ELSE CASE WHEN (ACA_SEM_ID * 6) = (sv.PGM_DURATION - 6) THEN 'Final Year' ELSE 'All' END END) = '" + ddlYear.SelectedItem + " ' ");
        }
        //query.Append(" GROUP BY " + Groupquery AND FD_SUB_IS_ACTIVE=1);
        query.Append("  ORDER BY FR.ROOM_NO");
    
        DataSet ds = new DataSet();
        SqlCommand command = new SqlCommand(query.ToString());
        command.CommandType = CommandType.Text;
        ds = DatabaseFunction.GetDataSet(command);
        Session["ds"] = ds.GetXml();

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "clientScript", "window.open('rptHostel.aspx?id="+ddlStatus.SelectedValue+"','_blank','resizable=1,width=900,height=650')", true);
    }
    public void Clear()
    {
        ddlStatus.SelectedIndex = 0;
        ddlComplex.SelectedIndex = 0;
    }
}
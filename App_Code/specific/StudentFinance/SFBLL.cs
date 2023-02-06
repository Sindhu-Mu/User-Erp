using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for SFBLL
/// </summary>
public class SFBLL
{
    DatabaseFunctions databaseFunctins;
    ExamFunctions.DatabaseFunctions ExamdatabaseFunctins;
    SqlCommand cmd;
    Messages Msg;
    SFDAL ObjDal;
    public SFBLL()
    {
        databaseFunctins = new DatabaseFunctions();
        ExamdatabaseFunctins = new ExamFunctions.DatabaseFunctions();
        Msg = new Messages();
        ObjDal = new SFDAL();
        // TODO: Add constructor logic here
        //
    }
    public string checkIndex(String sts)
    {
        string index;
        if (sts == ".")
        {
            index = "0";
        }
        else
        {
            index = sts;
        }
        return index;
    }
    public DataTable GetFeesHEad(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_MAIN_HEAD_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_GROUP_HEAD_ID", obj.balFeeGroupHeadId);
        return databaseFunctins.GetDataSet(cmd).Tables[0];

    }
    public int ChangeHeadSts(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_FIN_CHANGE_HEAD_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", obj.balMainHeadId);
        cmd.Parameters.AddWithValue("@STATUS", obj.balStatus);
        return databaseFunctins.execute_non_query(cmd);

    }
    public int FeeMainHeadInsert(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_MAIN_HEAD_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_NAME", obj.balHeadName));
        cmd.Parameters.Add(new SqlParameter("@FEE_GROUP_HEAD_ID", obj.balFeeGroupHeadId));
        cmd.Parameters.Add(new SqlParameter("@FEE_HEAD_IS_ONETIME", obj.balHeadOneTime));
        cmd.Parameters.Add(new SqlParameter("@FEE_IN_SCHOLARSHIP", obj.balHeadInScho));
        cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_PRIORITY", obj.balHeadPriority));
        cmd.Parameters.Add(new SqlParameter("@FEE_HEAD_IN_STRAC", obj.balHeadInStruc));
        return databaseFunctins.execute_non_query(cmd);
    }
    public int FeeMainHeadUpdate(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_MAIN_HEAD_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_ID", obj.balMainHeadId));
        cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_NAME", obj.balHeadName));
        cmd.Parameters.Add(new SqlParameter("@FEE_GROUP_HEAD_ID", obj.balFeeGroupHeadId));
        cmd.Parameters.Add(new SqlParameter("@FEE_HEAD_IS_ONETIME", obj.balHeadOneTime));
        cmd.Parameters.Add(new SqlParameter("@FEE_IN_SCHOLARSHIP", obj.balHeadInScho));
        cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_PRIORITY", obj.balHeadPriority));
        cmd.Parameters.Add(new SqlParameter("@FEE_HEAD_IN_STRAC", obj.balHeadInStruc));
        return databaseFunctins.execute_non_query(cmd);
    }
    public DataSet FeeStrcforHead(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_HEAD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@COURSE_ID", obj.balCourseId));
        return databaseFunctins.GetDataSet(cmd);
    }
    public void FeeStrcInsert(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_STRC_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_COURSE_ID", obj.balCourseId));
        cmd.Parameters.Add(new SqlParameter("@FEE_BATCH_ID", obj.balBatchId));
        cmd.Parameters.Add(new SqlParameter("@FEE_STRC_SUB_IN_BY", obj.balCurUser));
        cmd.Parameters.Add(new SqlParameter("@FEE_LATERAL", obj.balCommonID));
        cmd.Parameters.Add(new SqlParameter("@FEE_STRC_DATA", obj.balData));
        databaseFunctins.execute_non_query(cmd);
    }
    public DataTable FeeConcessionCriteria(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_GET_CONCESSION_CRITERIA";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public void FeeConcessionCriteriaInsert(SFBAL obj)
    {
        cmd = new SqlCommand("STU_FIN_FEE_CONC_CRI_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MAIN_HEAD_ID", obj.balMainHeadId);
        cmd.Parameters.AddWithValue("@QUOTA_CAT_ID", obj.balQuota);
        cmd.Parameters.AddWithValue("@CONC_PER", obj.balConcPer);
        cmd.Parameters.AddWithValue("@CONC_MAX", obj.balConcMax);
        cmd.Parameters.AddWithValue("@SESSION_ID", obj.balSession);
        cmd.Parameters.AddWithValue("@INSERT_BY", obj.balCurUser);
        databaseFunctins.execute_non_query(cmd);
    }
    public void FeeConcessionCriteriaDelete(SFBAL obj)
    {
        cmd = new SqlCommand("STU_FIN_DELETE_CRITERIA");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CRITERIA_ID", obj.balConcId);
        databaseFunctins.execute_non_query(cmd);
    }
    public string FeeDemandInsert(string FD_COURSE_ID, string FD_BRANCH_ID, string ACA_BATCH_ID, string FEE_SEM_NO, string ADM_TYP, string FEE_PROS_ID, string FINE_RULE_ID, string FEE_STRC_MAIN_ID, string FEE_TEMP_ID
        , string FD_REMARK, string FD_MAIN_IN_BY, string FD_FEE_FOR)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_DEMAND_MAIN_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FD_COURSE_ID", FD_COURSE_ID));
        cmd.Parameters.Add(new SqlParameter("@FD_BRANCH_ID", FD_BRANCH_ID));
        cmd.Parameters.Add(new SqlParameter("@ACA_BATCH_ID", ACA_BATCH_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_SEM_NO", FEE_SEM_NO));
        cmd.Parameters.Add(new SqlParameter("@ADM_TYP", ADM_TYP));
        cmd.Parameters.Add(new SqlParameter("@FEE_PROS_ID", FEE_PROS_ID));
        cmd.Parameters.Add(new SqlParameter("@FINE_RULE_ID", FINE_RULE_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_STRC_MAIN_ID", FEE_STRC_MAIN_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_TEMP_ID", FEE_TEMP_ID));
        cmd.Parameters.Add(new SqlParameter("@FD_REMARK", FD_REMARK));
        cmd.Parameters.Add(new SqlParameter("@FD_MAIN_IN_BY", FD_MAIN_IN_BY));
        cmd.Parameters.Add(new SqlParameter("@FD_FEE_FOR", FD_FEE_FOR));

        return databaseFunctins.GetSingleData(cmd);
    }
    public DataSet FeeStrcforSelect(string COURSE_ID, string FEE_BATCH_ID, string SEMESTER, string adm_type)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_STRC_FOR_DMD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@COURSE_ID", COURSE_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_BATCH_ID", FEE_BATCH_ID));
        cmd.Parameters.Add(new SqlParameter("@SEMESTER", SEMESTER));
        cmd.Parameters.Add(new SqlParameter("@adm_type", adm_type));
        return databaseFunctins.GetDataSet(cmd);
    }


    public string FeeDemandInsert(string FD_COURSE_ID, string FD_BRANCH_ID, string ACA_BATCH_ID, string FEE_SEM_NO, string ADM_TYP, string FEE_PROS_ID, string FINE_RULE_ID, string FEE_STRC_MAIN_ID, string FEE_TEMP_ID
        , string FD_REMARK, string FD_MAIN_IN_BY, string FD_FEE_FOR, string STU_ADM_NO)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_DEMAND_MAIN_INF_INSERT_FOR_SINGAL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FD_COURSE_ID", FD_COURSE_ID));
        cmd.Parameters.Add(new SqlParameter("@FD_BRANCH_ID", FD_BRANCH_ID));
        cmd.Parameters.Add(new SqlParameter("@ACA_BATCH_ID", ACA_BATCH_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_SEM_NO", FEE_SEM_NO));
        cmd.Parameters.Add(new SqlParameter("@ADM_TYP", ADM_TYP));
        cmd.Parameters.Add(new SqlParameter("@FEE_PROS_ID", FEE_PROS_ID));
        cmd.Parameters.Add(new SqlParameter("@FINE_RULE_ID", FINE_RULE_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_STRC_MAIN_ID", FEE_STRC_MAIN_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_TEMP_ID", FEE_TEMP_ID));
        cmd.Parameters.Add(new SqlParameter("@FD_REMARK", FD_REMARK));
        cmd.Parameters.Add(new SqlParameter("@FD_MAIN_IN_BY", FD_MAIN_IN_BY));
        cmd.Parameters.Add(new SqlParameter("@FD_FEE_FOR", FD_FEE_FOR));
        cmd.Parameters.Add(new SqlParameter("@STU_ADM_NO", STU_ADM_NO));
        return databaseFunctins.GetSingleData(cmd);
    }

    public DataSet StudentDueFeeSelect(string STU_ADM_NO, string BRANCH_ID, string SEM_NO)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_DETAIL_SELECT_NEW";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@STU_ADM_NO", STU_ADM_NO));
        cmd.Parameters.Add(new SqlParameter("@BRANCH_ID", BRANCH_ID));
        cmd.Parameters.Add(new SqlParameter("@SEM_NO", SEM_NO));
        return databaseFunctins.GetDataSet(cmd);
    }
    public void FeeReceiveModeInsert(string FEE_RCV_RECEIPT_NO, string TOTAL_AMT, string DIS_STS, string demand_id, string insert_by, string MODE_DATA)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RCV_MODE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_RCV_RECEIPT_NO", FEE_RCV_RECEIPT_NO));
        cmd.Parameters.Add(new SqlParameter("@TOTAL_AMT", TOTAL_AMT));
        cmd.Parameters.Add(new SqlParameter("@DIS_STS", DIS_STS));
        cmd.Parameters.Add(new SqlParameter("@DEMAND_ID", demand_id));
        cmd.Parameters.Add(new SqlParameter("@INSERT_BY", insert_by));
        cmd.Parameters.Add(new SqlParameter("@MODE_DATA", MODE_DATA));
        databaseFunctins.ExecuteCommand(cmd);
    }
    //public string AdvanceFeeInsert(string STU_ADM_NO, string SEM, string FEE_ADV_AMT, string FEE_HEAD_ID, string FEE_IN_BY, string MODE_DATA)
    //{
    //    SqlCommand cmd = new SqlCommand("STU_FIN_FEE_ADVANCE_INF_INSERT");
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@STU_ADM_NO", STU_ADM_NO);
    //    cmd.Parameters.AddWithValue("@SEM", SEM);
    //    cmd.Parameters.AddWithValue("@FEE_ADV_AMT", FEE_ADV_AMT);
    //    cmd.Parameters.AddWithValue("@FEE_HEAD_ID", FEE_HEAD_ID);
    //    cmd.Parameters.AddWithValue("@FEE_IN_BY", FEE_IN_BY);
    //    cmd.Parameters.AddWithValue("@MODE_DATA", MODE_DATA);
    //    return databaseFunctins.GetSingleData(cmd);
    //}

    public string AdvanceFeeInsert(string STU_ADM_NO, string SEM, string FEE_ADV_AMT, string FEE_HEAD_ID, string FEE_IN_BY, string MODE_DATA, DateTime FEE_DEPOSIT_DT)
    {
        cmd = new SqlCommand("STU_FIN_FEE_ADVANCE_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", STU_ADM_NO);
        cmd.Parameters.AddWithValue("@SEM", SEM);
        cmd.Parameters.AddWithValue("@FEE_ADV_AMT", FEE_ADV_AMT);
        cmd.Parameters.AddWithValue("@FEE_HEAD_ID", FEE_HEAD_ID);
        cmd.Parameters.AddWithValue("@FEE_DEPOSIT_DT", FEE_DEPOSIT_DT);
        cmd.Parameters.AddWithValue("@FEE_IN_BY", FEE_IN_BY);
        cmd.Parameters.AddWithValue("@MODE_DATA", MODE_DATA);
        return databaseFunctins.GetSingleData(cmd);
    }


    public string FeeReceiveInsert(string FEE_DEMAND_ID, string FEE_RCV_IN_BY)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RCV_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_DEMAND_ID", FEE_DEMAND_ID));
        cmd.Parameters.Add(new SqlParameter("@FEE_RCV_IN_BY", FEE_RCV_IN_BY));
        return databaseFunctins.GetSingleData(cmd);
    }


    public string FeeReceiveTranInsert(SFBAL ObjBal)
    {
        try
        {
            return ObjDal.FeeReceiveTranInsert(ObjBal);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjDal = null;
        }
    }

    public DataSet FeeModeCancelIncesrt(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_MODE_CNL_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MODE_ID", obj.balModeId);
        cmd.Parameters.AddWithValue("@REASON", obj.balReason);
        cmd.Parameters.AddWithValue("@DATE", obj.balDate);
        cmd.Parameters.AddWithValue("@IN_BY", obj.balCurUser);
        cmd.Parameters.AddWithValue("@REMARK", obj.balData);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet StudentFeeToRefund(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_REFUND_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@STU_ADM_NO", obj.balEnrol));
        cmd.Parameters.Add(new SqlParameter("@BRANCH_ID", obj.balBatchId));
        cmd.Parameters.Add(new SqlParameter("@SEM_NO", obj.balSem));
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet StudentFeeRefundRpt(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RPT_REFUND_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctins.GetDataSet(cmd);
    }
    public string FeeRefundInsert(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_REFUND_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_DEMAND_ID", obj.balDemandId));
        cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_ID", obj.balMainHeadId));
        cmd.Parameters.Add(new SqlParameter("@FEE_RFD_AMT", obj.balAmt));
        cmd.Parameters.Add(new SqlParameter("@FEE_RFD_REMARK", obj.balReason));
        cmd.Parameters.Add(new SqlParameter("@FEE_RFD_BY", obj.balCurUser));
        return databaseFunctins.GetSingleData(cmd);
    }
    public void FeeRefundModeInsert(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_REFUND_MODE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@FEE_RFD_RECEIPT_NO", obj.balCommonID));
        cmd.Parameters.Add(new SqlParameter("@MODE_DATA", obj.balData));
        databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetStudentDemand(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "STU_FIN_DEMAND_REPORT";
        cmd.Parameters.AddWithValue("@INS", obj.balInsId);
        cmd.Parameters.AddWithValue("@COURSE", obj.balCourseId);
        cmd.Parameters.AddWithValue("@BRANCH", obj.balBranchId);
        cmd.Parameters.AddWithValue("@BATCH", obj.balBatchId);
        cmd.Parameters.AddWithValue("@SEM", obj.balSem);
        cmd.Parameters.AddWithValue("@SESSION", obj.balSession);
        cmd.Parameters.AddWithValue("@SEM_TYPE_ID", obj.balSemType);
        //command.Parameters.AddWithValue("@SECTION", ddlSection.SelectedValue);
        //command.Parameters.AddWithValue("@CASTE", ddlCaste.SelectedValue);
        //command.Parameters.AddWithValue("@RELIGION", ddlReligion.SelectedValue);
        //command.Parameters.AddWithValue("@QUOTA", ddlQuota.SelectedValue);       
        //command.Parameters.AddWithValue("@STATE", ddlState.SelectedValue);
        //command.Parameters.AddWithValue("@CITY", ddlCity.SelectedValue);
        //command.Parameters.AddWithValue("@STATUS", ddlStatus.SelectedValue);
        //command.Parameters.AddWithValue("@SEX", ddlSex.SelectedValue);
        cmd.Parameters.AddWithValue("@P", obj.balCommonID);
        return databaseFunctins.GetDataSet(cmd);
    }
    #region StudentFinance_Nisha
    public void FeeProcessInsert(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_PROCESS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_PROS_NAME", ObjBal.balProcessName);
        cmd.Parameters.AddWithValue("@SESSION_ID", ObjBal.balSession);
        cmd.Parameters.AddWithValue("@SEM_TYPE_ID", ObjBal.balSemType);
        cmd.Parameters.AddWithValue("@FEE_PROS_ST_DT", Convert.ToDateTime(ObjBal.balStrtDate));
        cmd.Parameters.AddWithValue("@FEE_PROS_ED_DT", Convert.ToDateTime(ObjBal.balEndDate));
        cmd.Parameters.AddWithValue("@FEE_PROS_IN_BY", ObjBal.balInBy);
        databaseFunctins.ExecuteCommand(cmd);
    }
    public DataTable FeeProcessSelect(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_PROCESS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SESSION_ID", ObjBal.balSession);
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public void FeeProcessUpdate(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_PROCESS_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_PROS_ID", ObjBal.balProcessId);
        cmd.Parameters.AddWithValue("@FEE_PROS_NAME", ObjBal.balProcessName);
        cmd.Parameters.AddWithValue("@SESSION_ID", ObjBal.balSession);
        cmd.Parameters.AddWithValue("@SEM_TYPE_ID", ObjBal.balSemType);
        cmd.Parameters.AddWithValue("@FEE_PROS_ST_DT", ObjBal.balStrtDate);
        cmd.Parameters.AddWithValue("@FEE_PROS_ED_DT", ObjBal.balEndDate);
        cmd.Parameters.AddWithValue("@FEE_PROS_IN_BY", ObjBal.balInBy);
        databaseFunctins.execute_non_query(cmd);

    }

    public int ChangHeadStatus(SFBAL ObjBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_CHANGE_HEAD_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PROCESS_ID", ObjBal.balProcessId);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.balStatus);
        return databaseFunctins.execute_non_query(cmd);

    }
    public void FeeFineConditionInsert(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FINE_CONDITION_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FINE_RULE_ID", ObjBal.balRule);
        cmd.Parameters.AddWithValue("@FINE_CND_IN_BY", ObjBal.balSession);
        cmd.Parameters.AddWithValue("@FEE_FINE_DATA", ObjBal.balData);
        databaseFunctins.execute_non_query(cmd);

    }

    public string GetEmpName(int EmpID)
    {
        //string empName = string.Empty;
        //string strSql = "SELECT EMP_NAME FROM EMP_MAIN_INF WHERE EMP_ID=" + EmpID;
        //dr = databaseFunctins.dtrBindData(strSql);
        //if (dr.HasRows)
        //{
        //    dr.Read();
        //    empName = dr[0].ToString();
        //    dr.Close();
        //}
        return "";
    }
    public void FeeFineInsert(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FINE_RULE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FINE_RULE_NAME", ObjBal.balRule);

        cmd.Parameters.AddWithValue("@FEE_MAIN_HEAD_ID", ObjBal.balFeeGroupHeadId);
        cmd.Parameters.AddWithValue("@FINE_CAL_TYPE_ID", ObjBal.balType);
        databaseFunctins.execute_non_query(cmd);


    }
    public DataSet SelectStudentForDemand(SFBAL Objbal)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_SELECT_STUDENT_NEW";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", Objbal.balInsId);
        cmd.Parameters.AddWithValue("@PGM_ID", Objbal.balProgram);
        cmd.Parameters.AddWithValue("@BRANCH", Objbal.balBranch);
        cmd.Parameters.AddWithValue("@BATCH_ID", Objbal.balBatchId);
        cmd.Parameters.AddWithValue("@SEM", Objbal.balSem);
        //cmd.Parameters.AddWithValue("@SESSION", Objbal.balSession);
        return databaseFunctins.GetDataSet(cmd);

    }
    #endregion
    #region Harshita
    public DataSet StudentDemandFeeSelect(SFBAL ObjBal)
    {
        cmd = new SqlCommand("STU_FIN_STU_DEMAND_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.balEnrollment);
        cmd.Parameters.AddWithValue("@BRANCH_ID", ObjBal.balBranch);
        cmd.Parameters.AddWithValue("@SEM_NO", ObjBal.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }

    public SqlCommand getDemandHead(SFBAL ObjBal)
    {
        cmd = new SqlCommand("STU_FIN_FEE_DEMAND_HEAD_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_DEMAND_ID", ObjBal.balDemandId);
        return cmd;
    }

    public string StudentFeeDemandInsert(SFBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("STU_FIN_FEE_DEMAND_SUB_INF_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FEE_DEMAND_ID", ObjBal.balDemandId));
            cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_ID", ObjBal.balMainHeadId));
            cmd.Parameters.Add(new SqlParameter("@FD_FEE_AMT", ObjBal.balAmount));
            cmd.Parameters.Add(new SqlParameter("@FD_ADJUST_AMT", ObjBal.balAdjAmount));
            cmd.Parameters.Add(new SqlParameter("@FD_SUB_IN_BY", ObjBal.balSession));
            databaseFunctins.ExecuteCommand(cmd);
            return "Selected student Fee added in demand detail successfully.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public string StudentFeeDemandDelete(SFBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("STU_FIN_FEE_DEMAND_SUB_INF_DELETE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FEE_DEMAND_ID", ObjBal.balDemandId);
            cmd.Parameters.AddWithValue("@FEE_MAIN_HEAD_ID", ObjBal.balMainHeadId);
            databaseFunctins.ExecuteCommand(cmd);
            return "Selected fee head deleted from student fee demand detail.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string StudentFeeDemandUpdate(SFBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("STU_FIN_FEE_DEMAND_MAIN_INF_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FEE_PROS_ID", ObjBal.balProcId);
            cmd.Parameters.AddWithValue("@FINE_RULE_ID", ObjBal.balRuleId);
            cmd.Parameters.AddWithValue("@FEE_DEMAND_ID", ObjBal.balDemandId);
            databaseFunctins.ExecuteCommand(cmd);
            return "Selected record updated successfully!!";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion

    #region Riju
    public void SaveData(SFBAL ObjBal)
    {
        cmd = new SqlCommand("Stu_Credit_Tran");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.balEnroll);
        //cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.balMainId);
        cmd.Parameters.AddWithValue("@AMT", ObjBal.balAmt);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.balType);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.balSession);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.balDateTime);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.balRemark);
        cmd.Parameters.AddWithValue("@ADJ_ID", ObjBal.balAdjType);
        databaseFunctins.ExecuteCommand(cmd);
    }
    public string ShowCredit(SFBAL ObjBal)
    {
        cmd = new SqlCommand("stu_credit_tran_select");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.balEnroll);
        return databaseFunctins.GetSingleData(cmd);
    }
    public DataSet StufinLastTran(SFBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_LAST_TRAN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@head", objbal.balMainHeadId);
        cmd.Parameters.AddWithValue("@count", objbal.balCount);
        cmd.Parameters.AddWithValue("@todate", Convert.ToDateTime(objbal.balStrtDate));
        cmd.Parameters.AddWithValue("@fromdate", Convert.ToDateTime(objbal.balEndDate));
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet StuInactiveSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_INACTIVE_STU_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctins.GetDataSet(cmd);
    }

    public void FineAppDateCaseInsert(SFBAL Objbal)
    {
        try
        {
            ObjDal.FineAppDateCase(Objbal);
        }
        catch
        {
            Msg.GetMessage(Messages.DataMessType.Error);
        }


    }

    public string InactiveStsModify(SFBAL Objbal)
    {

        try
        {
            Objbal.balStatus = (Objbal.balStatus == "Deactivate") ? "0" : "1";
            ObjDal.InactiveModify(Objbal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }

    public void InactiveStuInsert(SFBAL Objbal)
    {
        try
        {
            ObjDal.InactiveInsert(Objbal);
        }
        catch
        {
            Msg.GetMessage(Messages.DataMessType.Error);
        }

    }


    #endregion
    #region ExamPermission
    public DataSet GetPermission(SFBAL ObjBal)
    {
        ObjBal.balInsId = (ObjBal.balInsId == ".") ? "0" : ObjBal.balInsId;
        ObjBal.balPgmId = (ObjBal.balPgmId == ".") ? "0" : ObjBal.balPgmId;
        ObjBal.balBranchId = (ObjBal.balBranchId == ".") ? "0" : ObjBal.balBranchId;
        ObjBal.balSem = (ObjBal.balSem == ".") ? "0" : ObjBal.balSem;
        ObjBal.balStatus = (ObjBal.balStatus == ".") ? "0" : ObjBal.balStatus;
        SqlCommand cmd = new SqlCommand("Stu_Exam_Permission_Select_NEW");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.balInsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.balPgmId);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.balBranchId);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.balSem);
        cmd.Parameters.AddWithValue("@EXAM_TYP", ObjBal.balType);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.balStatus);
        //cmd.Parameters.AddWithValue("@FROMDT", ObjBal.Max_Dt);
        //cmd.Parameters.AddWithValue("@TODT", ObjBal.Value);
        return databaseFunctins.GetDataSet(cmd);
    }

    #endregion


    #region Nisha
    public DataTable FeeStatusSelect(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_DEMAND_INFO_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", Objbal.balEnrol);
        cmd.Parameters.AddWithValue("@sem", Objbal.balSem);
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }

    public void FeeInfoInsert(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_DEMAND_INFO_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", Objbal.balEnrol);
        cmd.Parameters.AddWithValue("@sem", Objbal.balSem);
        cmd.Parameters.AddWithValue("@CRNCY_RATE", Objbal.balRate);
        cmd.Parameters.AddWithValue("@CRNCY_TO", Objbal.balCrncyTo);
        cmd.Parameters.AddWithValue("@CRNCY_FROM", Objbal.balCrncyFrom);
        cmd.Parameters.AddWithValue("@INBY", Objbal.balInBy);

        databaseFunctins.ExecuteCommand(cmd);
    }
    public int GetAmount(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_PAY_INSTALL_AMT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", Objbal.balEnrol);
        cmd.Parameters.AddWithValue("@GROUP_HEAD_ID", Objbal.balFeeGroupHeadId);
        return databaseFunctins.ExecuteScalar(cmd);
    }

    public void InstallmentPaymentInsert(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_INSTALL_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INSTALL_DATA", Objbal.balData);
        cmd.Parameters.AddWithValue("@ENROLLMENT", Objbal.balEnrol);
        cmd.Parameters.AddWithValue("@SEM", Objbal.balSem);
        cmd.Parameters.AddWithValue("@IN_BY", Objbal.balSession);
        databaseFunctins.execute_non_query(cmd);

    }
    #endregion
    public void FeeGroupHeadInsert(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_GROUP_HEAD_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_GROUP_HEAD_NAME", ObjBal.balHeadName);
        cmd.Parameters.AddWithValue("@HEAD_TYPE_ID", ObjBal.balHeadType);
        cmd.Parameters.AddWithValue("@FEE_TOP_HEAD_ID", ObjBal.balTopHeadId);
        databaseFunctins.execute_non_query(cmd);

    }
    public void FeeGroupHeadUpdate(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_GROUP_HEAD_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_GROUP_HEAD_NAME", ObjBal.balHeadName);
        cmd.Parameters.AddWithValue("@HEAD_TYPE_ID", ObjBal.balHeadType);
        cmd.Parameters.AddWithValue("@FEE_GROUP_HEAD_ID", ObjBal.balFeeGroupHeadId);
        cmd.Parameters.AddWithValue("@FEE_TOP_HEAD_ID", ObjBal.balTopHeadId);
        databaseFunctins.execute_non_query(cmd);
    }
    public DataTable FeeGroupHeadSelect(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_GROUP_HEAD_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_TYPE_ID", ObjBal.balHeadType);
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public int ChangeHeadStatus(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_CHANGE_GROUP_HEAD_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_GROUP_HEAD_ID", Objbal.balFeeGroupHeadId);
        cmd.Parameters.AddWithValue("@STATUS", Objbal.balStatus);
        return databaseFunctins.execute_non_query(cmd);
    }
    public DataTable StuFinGetCheckStatus(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_GET_CHK_STATUS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MODE", Objbal.balMode);
        cmd.Parameters.AddWithValue("@CHECK_NO", Objbal.balChequeNo);
        cmd.Parameters.AddWithValue("@STATUS", Objbal.balStatus);
        cmd.Parameters.AddWithValue("@ENROL", Objbal.balEnrol);
        cmd.Parameters.AddWithValue("@FROM_DATE", Objbal.balDateFrom);
        cmd.Parameters.AddWithValue("@TO_DATE", Objbal.balDateTo);

        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public void ClearingDateUpdate(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_UPDATE_CLEARING_DATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NUMBER", Objbal.balChequeNo);
        cmd.Parameters.AddWithValue("@DATE", Objbal.balDate);
        databaseFunctins.execute_non_query(cmd);

    }
    public DataSet StuFinFeeReceivableSelect(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RECEIVABLE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SESSION_ID", Objbal.balSession);
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet StuFinFeeTransactionSelect(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_TRANSACTION_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", Objbal.balEnrol);
        cmd.Parameters.AddWithValue("@BRANCH_ID", Objbal.balBranchId);
        cmd.Parameters.AddWithValue("@SEM_NO", Objbal.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }
    public void FineTranInsert(string DATA)
    {
        SqlCommand cmd = new SqlCommand("STU_FIN_FINE_TRAN_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATA", DATA);
        databaseFunctins.ExecuteCommand(cmd);
    }
    public void FineInsert(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("STU_FIN_FINE_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLL", ObjBal.balEnrollment);
        cmd.Parameters.AddWithValue("@FINE_AMT", ObjBal.balAmount);
        cmd.Parameters.AddWithValue("@FINE_REMARK", ObjBal.balRemark);
        cmd.Parameters.AddWithValue("@FINE_CASE_ID", ObjBal.balCase);
        cmd.Parameters.AddWithValue("@FINE_INSERT_BY", ObjBal.balSession);
        cmd.Parameters.AddWithValue("@FINE_STATUS_ID", ObjBal.balStatus);
        databaseFunctins.execute_non_query(cmd);
    }
    public DataTable FineProcessSelect(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FINE_PROCESS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public DataSet StuFinDailyReceivedSelect(SFBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_DAILY_RECEIVED_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Session", objbal.balSession);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetDemandedAndNotDemanded(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_DEMANDED_NOTDEMANDED";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SESSION", Objbal.balSession);
        cmd.Parameters.AddWithValue("@SEM_TYPE", Objbal.balSemType);
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet FeeDemRcvSelect(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RECEIPT_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", Objbal.balStuAdmNo);
        cmd.Parameters.AddWithValue("@BRANCH_ID", Objbal.balBranchId);
        cmd.Parameters.AddWithValue("@SEM_NO", Objbal.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet RcvReceiptDetail(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_RECEIPT_HEAD_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RECEIPT_NO", Objbal.balRcptNo);
        return databaseFunctins.GetDataSet(cmd);

    }

    public void FeeReceiveTranModify(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RECEIVE_TRAN_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RECEIPT_NO", Objbal.balRcptNo);
        cmd.Parameters.AddWithValue("@XML_DATA", Objbal.balData);
        cmd.Parameters.AddWithValue("@TRAN_BY", Objbal.balInBy);
        databaseFunctins.ExecuteCommand(cmd);

    }



    #region Exam Permission
    public DataTable StudentFeeDueSelect(SFBAL ObjBal)
    {
        cmd = new SqlCommand("STU_FIN_GET_DUE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.balCommonID);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_ID", ObjBal.balType);
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public void StudentDueSubInsert(SFBAL ObjBal)
    {
        cmd = new SqlCommand("STU_FIN_DUE_SUB_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_DUE_ID", ObjBal.balEnrollment);
        cmd.Parameters.AddWithValue("@PERMISSION_TYPE", ObjBal.balReason);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.balRemark);
        cmd.Parameters.AddWithValue("@INSERT_BY", ObjBal.balCurUser);
        databaseFunctins.GetDataSet(cmd);
    }

    #endregion


    #region CreditAdjust
    public DataTable StuFinCreditAdjust(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_CREDIT_ADJST_AMT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", Objbal.balInsId);
        cmd.Parameters.AddWithValue("@BRANCH_ID", Objbal.balBranch);
        cmd.Parameters.AddWithValue("@PGM_ID", Objbal.balCourseId);
        cmd.Parameters.AddWithValue("@MAIN_HEAD_ID", Objbal.balMainHeadId);
        cmd.Parameters.AddWithValue("@SESSION_ID", Objbal.balSession);
        cmd.Parameters.AddWithValue("@SEM_TYPE_ID", Objbal.balSemType);
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public void CreditAmountAdjustInsert(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_ADJST_AMT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_ADJST_DATA", Objbal.balData);
        cmd.Parameters.AddWithValue("@IN_BY", Objbal.balSession);
        cmd.Parameters.AddWithValue("@MAIN_HEAD_ID", Objbal.balMainHeadId);
        databaseFunctins.execute_non_query(cmd);
    }
    #endregion
    #region FeeConcession
    public DataTable GetFeeConcessionDetail(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_CONCESSION_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", Objbal.balInsId);
        cmd.Parameters.AddWithValue("@PGM_ID ", Objbal.balCourseId);
        cmd.Parameters.AddWithValue("@BATCH_ID", Objbal.balBatchId);
        cmd.Parameters.AddWithValue("@BRANCH_ID", Objbal.balBranch);
        cmd.Parameters.AddWithValue("@SESSION_ID", Objbal.balSession);
        return databaseFunctins.GetDataSet(cmd).Tables[0];
    }
    public void FeeConcessionInfoInsert(string DATA)
    {
        SqlCommand cmd = new SqlCommand("STU_FIN_FEE_CONCESSION_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATA", DATA);
        databaseFunctins.ExecuteCommand(cmd);
    }

    #endregion
    #region Scholarship

    public DataSet GetSchoDetail(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_SCHOLARSHIP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EXAM_FORM_SESSION", Objbal.balSession);
        cmd.Parameters.AddWithValue("@INS_ID", Objbal.balInsId);
        cmd.Parameters.AddWithValue("@COURSE_ID", Objbal.balCourseId);
        cmd.Parameters.AddWithValue("@BRANCH_ID", Objbal.balBranch);
        cmd.Parameters.AddWithValue("@scho", Objbal.balPercentage);
        return databaseFunctins.GetDataSet(cmd);
    }

    public void Scho_Detail_Insert(string DATA)
    {
        SqlCommand cmd = new SqlCommand("STU_FIN_FEE_SCHOLARSHIP_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATA", DATA);
        databaseFunctins.ExecuteCommand(cmd);
    }

    #endregion
    #region Abhinav
    #region Fee Concession Rule
    public DataSet InsertConcRule(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_CONC_RULE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CONC_RULE_NAME", obj.balHeadName);
        cmd.Parameters.AddWithValue("@CONC_RULE_DESC", obj.balData);
        cmd.Parameters.AddWithValue("@SESSION_ID", obj.balSession);
        cmd.Parameters.AddWithValue("@QUOTA_ID", obj.balQuota);
        cmd.Parameters.AddWithValue("@RELATION_ID", obj.balRelation);
        cmd.Parameters.AddWithValue("@INS_BY", obj.balCurUser);
        cmd.Parameters.AddWithValue("@CONC_MAX_AMT", obj.balAmt);
        cmd.Parameters.AddWithValue("@CONC_PERCENTAGE", obj.balPercentage);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet getConcRule(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_GET_CONC_RULE";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet UpdateConcRuleStatus(SFBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_UPDATE_CON_RULE_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STS", obj.balStatus);
        cmd.Parameters.AddWithValue("@RULE_ID", obj.balRuleId);
        return databaseFunctins.GetDataSet(cmd);
    }
    #region Fee Wave
    public DataSet StudentWaveHeadSelect(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_GET_FEE_WAVE_HEAD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ENROL", obj.balEnrollment);
        cmd.Parameters.AddWithValue("@BRANCH_ID", obj.balBranchId);
        cmd.Parameters.AddWithValue("@SEM", obj.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet StudentFeeWave(SFBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_WAVE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XML_DATA", obj.balData);
        cmd.Parameters.AddWithValue("@INS_BY", obj.balSession);
        cmd.Parameters.AddWithValue("@APP_BY", obj.balEmpName);
        cmd.Parameters.AddWithValue("@APP_DATE", obj.balDate);
        cmd.Parameters.AddWithValue("@REMARK", obj.balReason);
        cmd.Parameters.AddWithValue("@DEMAND_ID", obj.balDemandId);
        return databaseFunctins.GetDataSet(cmd);
    }

    #endregion
    #endregion
    #endregion

    #region Examination
    public DataSet ExamRegFeeReceiveingSelect(SFBAL ObjBal)
    {
        cmd = new SqlCommand("GET_REG_COURSE_FOR_FEE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.balEnrollment);
        cmd.Parameters.AddWithValue("@EXAM_ID", ObjBal.balCommonID);
        return ExamdatabaseFunctins.GetDataSet(cmd);
    }
    public string ExamRegFeeReceiveingInsert(SFBAL ObjBal)
    {
        try
        {
            return ObjDal.ExamRegFeeReceiveingInsert(ObjBal);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }


    }
    public DataSet GetFeeDetail(SFBAL ObjBal)
    {
        cmd = new SqlCommand("GET_FEE_RECIEPT_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BACK_FEE_RCV_ID", ObjBal.balRcvId);
        return ExamdatabaseFunctins.GetDataSet(cmd);
    }

    #endregion

    #region Fee Permission
    public DataSet StudentPermissionHeadSelect(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_GET_PERMISSION_HEAD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ENROL", ObjBal.balEnrollment);
        cmd.Parameters.AddWithValue("@BRANCH_ID", ObjBal.balBranchId);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }

    public string StudentPermissionHeadInsert(SFBAL ObjBal)
    {
        try
        {
            ObjDal.StuPermissionHeadInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

    #endregion

    #region Riju

    public DataSet StudentOpeningFeeSelect(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_OPENING_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", Objbal.balEnrollment);
        return databaseFunctins.GetDataSet(cmd);
    }

    public string StudentOpeningFeeUpdate(SFBAL ObjBal)
    {
        try
        {
            ObjDal.StuOpeningFeeUpdate(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

    public DataSet FullFinanceDetails(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FULL_FINANCE_DETAILS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@PROS_ID", ObjBal.balProcessId));
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet FullFinanceDetails2018(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FULL_FINANCE_DETAILS_2018";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@PROS_ID", ObjBal.balProcessId));
        return databaseFunctins.GetDataSet(cmd);
    }

    public DataSet FullFinancePhd(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FULL_FINANCE_DETAILS_Phd";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@PROS_ID", ObjBal.balProcessId));
        return databaseFunctins.GetDataSet(cmd);
    }
    #endregion
    #region De-activateFacility
    public DataSet DeactiveFacility(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_DEACTIVE_FACILITY_INF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLL", Objbal.balEnroll);
        cmd.Parameters.AddWithValue("@sem", Objbal.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }

    public void DeactiveFacUpdate(SFBAL objbal)
    {
        try
        {
            ObjDal.DeactiveFacilityUpdate(objbal);
        }
        catch
        {
            Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    #endregion
    public DataSet GetStudentFeePaymentDetails(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand("GET_STUDENT_FEE_PAYMENT_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", Objbal.balCommonID);
        return databaseFunctins.GetDataSet(cmd);

    }
    public DataSet GetStudentFeeReceiptDetails(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand("GET_STUDENT_FEE_RECEIPT_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FEE_RCV_RECEIPT_NO", Objbal.balCommonID);
        return databaseFunctins.GetDataSet(cmd);

    }
    public DataSet GetStudentDetails(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand("SELECT DISTINCT BRN_SHORT_NAME,INS_PGM_BRN_INF.PGM_BRN_ID,ISNULL(FEE_SEM_NO,ACA_SEM_ID) AS ACA_SEM_ID "
 + " FROM STU_MAIN_INF  INNER JOIN STU_BRN_SEM_INF  ON  STU_MAIN_INF.STU_MAIN_ID=STU_BRN_SEM_INF.STU_MAIN_ID "
 + " INNER JOIN INS_PGM_BRN_INF ON  STU_BRN_SEM_INF.PGM_BRN_ID=INS_PGM_BRN_INF.PGM_BRN_ID "
 + " LEFT OUTER JOIN STU_FIN_FEE_DEMAND_MAIN_INF ON STU_MAIN_INF.STU_MAIN_ID=STU_FIN_FEE_DEMAND_MAIN_INF.STU_ADM_NO  AND FD_STATUS=1 "
 + " AND STU_FIN_FEE_DEMAND_MAIN_INF.FEE_SEM_NO=STU_BRN_SEM_INF.ACA_SEM_ID WHERE ENROLLMENT_NO=@ENROLLMENT_NO ORDER BY ACA_SEM_ID DESC");
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", Objbal.balCommonID);
        return databaseFunctins.GetDataSet(cmd);

    }
    public DataSet GetFeeInfromationforHOD(SFBAL ObjBal)
    {
        ObjBal.balInsId = (ObjBal.balInsId == ".") ? "0" : ObjBal.balInsId;
        ObjBal.balPgmId = (ObjBal.balPgmId == ".") ? "0" : ObjBal.balPgmId;
        ObjBal.balBranch = (ObjBal.balBranch == ".") ? "0" : ObjBal.balBranch;
        ObjBal.balSem = (ObjBal.balSem == ".") ? "0" : ObjBal.balSem;
        ObjBal.balStatus = (ObjBal.balStatus == ".") ? "0" : ObjBal.balStatus;
        cmd = new SqlCommand("GET_FEE_INFO_FOR_HOD");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.balInsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.balPgmId);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.balBranch);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.balSem);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.balStatus);
        //cmd.Parameters.AddWithValue("@FROMDT", ObjBal.Max_Dt);
        //cmd.Parameters.AddWithValue("@TODT", ObjBal.Value);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetStudentFeeReport(SFBAL ObjBal)
    {
        ObjBal.balEnrollment = (ObjBal.balEnrollment == ".") ? "0" : ObjBal.balEnrollment;
        cmd = new SqlCommand("GET_STUDENT_FEE_INFO_FOR_HOD");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.balEnrollment);

        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetDailyReceiptReport(SFBAL ObjBal)
    {
        ObjBal.balType = (ObjBal.balType == "" || ObjBal.balType == ".") ? "0" : ObjBal.balType;
        ObjBal.balRcptNo = (ObjBal.balRcptNo == "." || ObjBal.balRcptNo == "") ? "0" : ObjBal.balRcptNo;
        cmd = new SqlCommand("GetDailyReceiptReport");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ObjBal.balType);
        cmd.Parameters.AddWithValue("@FROMDATE", ObjBal.balDateFrom);
        cmd.Parameters.AddWithValue("@TODATE", ObjBal.balDateTo);
        cmd.Parameters.AddWithValue("@RECEIPT_NO", ObjBal.balRcptNo);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetDailyNewReceiptReport(SFBAL ObjBal)
    {
        cmd = new SqlCommand("GetDailyNewReceiptReport");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FROMDATE", ObjBal.balDateFrom);
        cmd.Parameters.AddWithValue("@TODATE", ObjBal.balDateTo); 
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetDailyPaymentReport(SFBAL ObjBal)
    {
        cmd = new SqlCommand("GetDailyPaymentReport");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FROMDATE", ObjBal.balDateFrom);
        cmd.Parameters.AddWithValue("@TODATE", ObjBal.balDateTo);
        return databaseFunctins.GetDataSet(cmd);
    }


    public DataSet StudentDemandFeeSelectII(SFBAL ObjBal)
    {
        cmd = new SqlCommand("STU_FIN_STU_DEMAND_SELECT_II");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.balEnrollment);
        cmd.Parameters.AddWithValue("@BRANCH_ID", ObjBal.balBranch);
        cmd.Parameters.AddWithValue("@SEM_NO", ObjBal.balSem);
        return databaseFunctins.GetDataSet(cmd);
    }
    public string StudentFeeDemandEntryUpdate(SFBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("STU_FIN_FEE_DEMAND_SUB_INF_ENTRY_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@FEE_DEMAND_ID", ObjBal.balDemandId));
            cmd.Parameters.Add(new SqlParameter("@FEE_MAIN_HEAD_ID", ObjBal.balMainHeadId));
            cmd.Parameters.Add(new SqlParameter("@FD_FEE_AMT", ObjBal.balAmount));
            cmd.Parameters.Add(new SqlParameter("@FD_ADJUST_AMT", ObjBal.balAdjAmount));
            cmd.Parameters.Add(new SqlParameter("@CONCESSION_AMT", ObjBal.balConcession));
            cmd.Parameters.Add(new SqlParameter("@CONC_REMARK", ObjBal.balRemark));
            cmd.Parameters.Add(new SqlParameter("@FEE_WAVE_OFF", ObjBal.balWAVE));
            cmd.Parameters.Add(new SqlParameter("@FD_RCV_AMT", ObjBal.balReceived));
            cmd.Parameters.Add(new SqlParameter("@FD_SUB_IN_BY", ObjBal.balSession));
            databaseFunctins.ExecuteCommand(cmd);
            return "Selected student Fee head entry update successfully.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public DataSet GetStudentFeeReceiptInfo(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_STU_FIN_RECEIPT_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RECEIPT_NO", Objbal.balRcptNo);
        return databaseFunctins.GetDataSet(cmd);

    }
    public string StudentFeeReceiptTranDelete(SFBAL Objbal)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "STU_FIN_FEE_RCV_TRAN_DELETE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FEE_RCV_TRAN_ID", Objbal.balCommonID);
            cmd.Parameters.AddWithValue("@IN_BY", Objbal.balSession);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public DataSet GetFinanceReportDatewise1(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_FINANCE_DATEWISE_REPORT_1";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FROMDATE", ObjBal.balDateFrom);
        cmd.Parameters.AddWithValue("@TODATE", ObjBal.balDateTo);
        return databaseFunctins.GetDataSet(cmd);
    }
    public DataSet GetFinanceReportDatewise2(SFBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_FINANCE_DATEWISE_REPORT_2";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FROMDATE", ObjBal.balDateFrom);
        cmd.Parameters.AddWithValue("@TODATE", ObjBal.balDateTo);
        return databaseFunctins.GetDataSet(cmd);
    }
    public string StudentFeeReceiptModeDelete(SFBAL Objbal)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "STU_FIN_FEE_RCV_MODE_INF_DELETE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@RCV_TRAN_MODE_ID", Objbal.balCommonID);
            cmd.Parameters.AddWithValue("@IN_BY", Objbal.balSession);
            databaseFunctins.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Deleted);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    public string StudentFeeReceiptUpdate(SFBAL ObjBal)
    {
        try
        {
            return ObjDal.StudentFeeReceiptUpdate(ObjBal);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

}
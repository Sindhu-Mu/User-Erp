using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;

/// <summary>
/// Summary description for PRBLL
/// </summary>
public class PRBLL
{
    HRDAL ObjPrDal;
    PRBAL ObjPrBal;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    QueryFunctions queryFunctions;
    public PRBLL()
    {
        //
        // TODO: Add constructor logic here
        ObjPrDal = new HRDAL();
        databaseFunctions = new DatabaseFunctions();
        Msg = new Messages();
        queryFunctions = new QueryFunctions();
        //
        ObjPrBal = new PRBAL();
    }
    public void showStatusAlert(int status,System.Web.UI.Page pageObj,string successMsg,string errorMsg)
    {
        if (status > 0)
        {
            ScriptManager.RegisterClientScriptBlock(pageObj, pageObj.GetType(), "clientScript", "alert('"+successMsg+"')", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(pageObj, pageObj.GetType(), "clientScript", "alert('" + errorMsg + "')", true);
        }
    }
    public string checkIndex(String sts)
    {
        string index;
        if (sts == ".")
        {
            index = "-1";
        }
        else
        {
            index = sts;
        }
        return index;
    }
    public string checkIndex(String sts,String newSts)
    {
        string index;
        if (sts == ".")
        {
            index = newSts;
        }
        else
        {
            index = sts;
        }
        return index;
    }
    public DataSet execQuery(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = obj.balData;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataTable GetPayrollProf(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_PAYROLL_PROF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_CODE", obj.balEmpCode);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    //For Template Master Start
    public DataTable GetSalTemplates()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_SAL_TEMPLATE";
        return databaseFunctions.GetDataSet(cmd).Tables[0];

    }
    public void ChngTempSts(int status, string temp_id)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_CHANGE_TEMP_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STATUS", status);
        cmd.Parameters.AddWithValue("@TEMP_ID", temp_id);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public int ChkTempPresent(String name)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_CHECK_TEMPLATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TEMPLATE_NAME", name);
        return databaseFunctions.ExecuteScalar(cmd);

    }
    public void SalaryTemplateMasterInsert(int SAL_TEMPLATE_ID, string SAL_TEMPLATE_NAME, string SAL_TEMPLATE_DESC, int SAL_TEMPLATE_BY, int SAL_TEMP_STATUS, int TYPE)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "sp_Sal_Template_Master";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@SAL_TEMPLATE_ID", SAL_TEMPLATE_ID));
        cmd.Parameters.Add(new SqlParameter("@SAL_TEMPLATE_NAME", SAL_TEMPLATE_NAME));
        cmd.Parameters.Add(new SqlParameter("@SAL_TEMPLATE_DESC", SAL_TEMPLATE_DESC));
        cmd.Parameters.Add(new SqlParameter("@SAL_TEMPLATE_BY", SAL_TEMPLATE_BY));
        cmd.Parameters.Add(new SqlParameter("@SAL_TEMP_STATUS", SAL_TEMP_STATUS));
        cmd.Parameters.Add(new SqlParameter("@TYPE", TYPE));
        databaseFunctions.ExecuteCommand(cmd);

    }
    //For Template Master END

    //For Head Main Start

    public DataTable GetHeadMain(string head_type)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_HEAD_MASTER_SELECT";
        cmd.Parameters.AddWithValue("@HEAD_TYPE_ID", head_type);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public int HeadInsertUpdate(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_HEAD_MASTER_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_TYPE_ID", obj.balHeadType);
        cmd.Parameters.AddWithValue("@HEAD_NAME", obj.balHeadName);
        cmd.Parameters.AddWithValue("@HEAD_SHORT_NAME", obj.balHeadShortName);
        cmd.Parameters.AddWithValue("@HEAD_IN_CALCULATION", obj.balInCal);
        cmd.Parameters.AddWithValue("@HEAD_INSERT_BY", obj.balcurUserId);
        cmd.Parameters.AddWithValue("@HEAD_ID", obj.balHeadId);
        databaseFunctions.GetDataSet(cmd);
        return 1;

    }
    public void ChngHeadSts(string head_id, int status)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SAL_CHANGE_HEAD_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STATUS", status);
        cmd.Parameters.AddWithValue("@TEMP_ID", head_id);
        databaseFunctions.ExecuteCommand(cmd);

    }

    //For Head Main End

    #region Teamp Head Map Start
    public DataSet GetTempHead(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_GET_TEMP_HEAD";
        cmd.Parameters.AddWithValue("@TEMP_ID", obj.balTempId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataTable GetHeadDetail(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_GET_HEAD_DETAIL";
        cmd.Parameters.AddWithValue("@HEAD_ID", obj.balHeadId);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable CheckHeadStatus(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_CHECK_HEAD_TEMP_MAP";
        cmd.Parameters.AddWithValue("@HEAD_ID", obj.balHeadId);
        cmd.Parameters.AddWithValue("@TEMP_ID", obj.balTempId);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public void HeadTempHeadMapp(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_HEAD_TEMP_MAP_INSERT";
        cmd.Parameters.Add(new SqlParameter("@HEAD_MAPP_ID", obj.balkeyId));
        cmd.Parameters.Add(new SqlParameter("@HEAD_TEMP_ID", obj.balTempId));
        cmd.Parameters.Add(new SqlParameter("@HEAD_ID", obj.balHeadId));
        cmd.Parameters.Add(new SqlParameter("@HEAD_ENTRY_TYPE", obj.balHeadType));
        cmd.Parameters.Add(new SqlParameter("@HEAD_ENTRY_VALUE", obj.balheadValue));
        cmd.Parameters.Add(new SqlParameter("@HEAD_BY", obj.balcurUserId));
        cmd.Parameters.Add(new SqlParameter("@HEAD_MAPP_STATUS", 1));

        /////
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region Employee Profile
    public string CheckEmpStruc(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_CHECK_EMP_STRUC";
        cmd.Parameters.AddWithValue("@EMP_CODE", obj.balEmpCode);
        return databaseFunctions.GetSingleData(cmd);
    }
    public DataSet GetEmpProf(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_PROFILE_SELECT";
        cmd.Parameters.AddWithValue("@EMP_CODE", obj.balEmpCode);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet updateStructure(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_UPDATE_STRUCTURE";
        cmd.Parameters.AddWithValue("@ES_ID", obj.balEsId);
        cmd.Parameters.AddWithValue("@ES_PAY_SCALE", obj.balPayScl);
        cmd.Parameters.AddWithValue("@ES_WITH_INC", obj.balIncrement);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet updateHeadValue(PRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_UPDATE_HEAD_VALUE";
        cmd.Parameters.AddWithValue("@HEAD_VALUE", obj.balheadValue);
        cmd.Parameters.AddWithValue("@ED_ID", obj.balEdId);

        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet SalaryStrucDetail(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_STRUCT_DETAIL_INSERT2";
        cmd.Parameters.Add(new SqlParameter("@ES_ID", obj.balEsId));
        cmd.Parameters.Add(new SqlParameter("@ED_HEAD_ID", obj.balHeadId));
        cmd.Parameters.Add(new SqlParameter("@ED_HEAD_VALUE", obj.balheadValue));
        cmd.Parameters.Add(new SqlParameter("@ED_CALCULATION", obj.balInCal));
        cmd.Parameters.Add(new SqlParameter("@ED_INSERT_BY", obj.balCurEmpCode));
        /////
        return databaseFunctions.GetDataSet(cmd);


    }
    public DataSet SalaryProfileSelect(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_SALARY_PROFILE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@TEMPLATE_ID", obj.balTempId));
        /////
        return databaseFunctions.GetDataSet(cmd);

    }
    public String GetEmpEpf(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_GET_EMP_EPF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@EMP_CODE", obj.balEmpCode));
        /////
        return databaseFunctions.GetSingleData(cmd);

    }
    public string SalaryStrucMasterInsert(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_EMP_STRUCT_MASTER_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@ES_EMP_CODE", obj.balEmpCode));
        cmd.Parameters.Add(new SqlParameter("@ES_TEMPLATE_ID", obj.balTempId));
        cmd.Parameters.Add(new SqlParameter("@ES_PAY_SCALE", obj.balPayScl));
        cmd.Parameters.Add(new SqlParameter("@ES_WITH_INCREMENT", obj.balIncrement));
        cmd.Parameters.Add(new SqlParameter("@ES_REMARK", obj.balRemark));
        cmd.Parameters.Add(new SqlParameter("@ES_INSERT_BY", obj.balCurEmpCode));
        /////
        return databaseFunctions.GetSingleData(cmd);



    }
    public void InsertSalaryStrucDetail(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_STRUCT_DETAIL_INSERT_1";
        cmd.Parameters.Add(new SqlParameter("@ES_ID", obj.balEsId));
        cmd.Parameters.Add(new SqlParameter("@DETAILDATA", obj.balData));
        cmd.Parameters.Add(new SqlParameter("@ED_INSERT_BY", obj.balCurEmpCode));
        cmd.Parameters.Add(new SqlParameter("@ED_ORDER_NO", obj.balOrderNo));
        cmd.Parameters.Add(new SqlParameter("@ED_ORDER_DATE", obj.balOrderDt));

        /////
        databaseFunctions.GetDataSet(cmd);

    }
    #endregion
    #region Salary Calculation

    public DataSet getNewTranEntry(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = obj.balData;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string SalaryMonthTranInsert(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_MONTHLY_TRAN_INSERT_1";
        cmd.Parameters.Add(new SqlParameter("@HEAD_ID", obj.balHeadId));
        cmd.Parameters.Add(new SqlParameter("@TRANDATA", obj.balData));
        cmd.Parameters.Add(new SqlParameter("@TRAN_MONTH", obj.balMonth));
        cmd.Parameters.Add(new SqlParameter("@TRAN_YEAR", obj.balYear));
        cmd.Parameters.Add(new SqlParameter("@TRAN_IN_BY", obj.balCurEmpCode));
      return  databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #region Bank Transfer

    public int BankTransferInsert(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ORG_DATA",obj.balData);
        cmd.Parameters.AddWithValue("@ref_no",obj.balkeyId);
        cmd.CommandText = "SAL_BANK_TRANSFER_INSERT";
        int status=databaseFunctions.ExecuteScalar(cmd);
        return status;
       
        
    }

    #endregion
    #region Salary Monthly Calculation
    public DataSet GetSalMonthlyCalculation(PRBAL ObjBal)
    {
        ObjBal.balTempId = (ObjBal.balTempId == ".") ? "Select" : ObjBal.balTempId;
        ObjBal.balkeyId = (ObjBal.balkeyId == ".") ? "0" : ObjBal.balkeyId;
        ObjBal.balEmpCode = (ObjBal.balEmpCode == null) ? "0" : ObjBal.balEmpCode;
        cmd = new SqlCommand("SAL_MONTHLY_CALCULATION_R_2_ABHINAV");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.balMonth);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.balYear);
        cmd.Parameters.AddWithValue("@NOOFDAYS", ObjBal.balDays);
        cmd.Parameters.AddWithValue("@TEMPID", ObjBal.balTempId);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.balkeyId);
        cmd.Parameters.AddWithValue("@FROM", ObjBal.balMin);
        cmd.Parameters.AddWithValue("@TO", ObjBal.balMax);
        cmd.Parameters.AddWithValue("@EMPCODE", ObjBal.balEmpCode);
        cmd.Parameters.AddWithValue("@ARANGEBY", ObjBal.balArngBy);
        cmd.Parameters.AddWithValue("@CAL_TYPE", ObjBal.balInCal);

        return databaseFunctions.GetDataSet(cmd);
    }

    public SqlDataReader SalMonthlyCalculationInsert(PRBAL ObjBal)
    {
        ObjBal.balTempId = (ObjBal.balTempId == ".") ? "Select" : ObjBal.balTempId;
        ObjBal.balkeyId = (ObjBal.balkeyId == ".") ? "0" : ObjBal.balkeyId;
        ObjBal.balEmpCode = (ObjBal.balEmpCode == null) ? "0" : ObjBal.balEmpCode;
        cmd = new SqlCommand("SAL_MONTHLY_INSERT_NEW_ABHINAV_TEST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.balMonth);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.balYear);
        cmd.Parameters.AddWithValue("@NOOFDAYS", ObjBal.balDays);
        cmd.Parameters.AddWithValue("@TEMPID", ObjBal.balTempId);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.balkeyId);
        cmd.Parameters.AddWithValue("@FROM", ObjBal.balMin);
        cmd.Parameters.AddWithValue("@TO", ObjBal.balMax);
        cmd.Parameters.AddWithValue("@EMPCODE", ObjBal.balEmpCode);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.balCurEmpCode);
        cmd.Parameters.AddWithValue("@CAL_TYPE", ObjBal.balInCal);
        return databaseFunctions.GetReader(cmd);
    }

    #endregion
    # region Emp Incerement
    public DataSet EmpSalaryActiveProfile(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_SALARY_ACTIVE_PROFILE";
        cmd.Parameters.Add(new SqlParameter("@EMP_CODE", obj.balEmpCode));
        return databaseFunctions.GetDataSet(cmd);

    }

    public void SalaryStrucDetailInsert(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_EMP_STRUCT_DETAIL_INSERT";
        cmd.Parameters.Add(new SqlParameter("@ES_ID", obj.balEsId));
        cmd.Parameters.Add(new SqlParameter("@ED_HEAD_ID", obj.balHeadId));
        cmd.Parameters.Add(new SqlParameter("@ED_HEAD_VALUE", obj.balheadValue));
        cmd.Parameters.Add(new SqlParameter("@ED_CALCULATION", obj.balInCal));
        cmd.Parameters.Add(new SqlParameter("@ED_ORDER_NO", obj.balOrderNo));
        cmd.Parameters.Add(new SqlParameter("@ED_ORDER_DATE", obj.balOrderDt));
        cmd.Parameters.Add(new SqlParameter("@ED_INSERT_BY", obj.balCurEmpCode));
        databaseFunctions.GetDataSet(cmd);

    }
    public void SalaryIncrementInsert(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_INCREMENT_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ES_ID", obj.balEsId);
        cmd.Parameters.AddWithValue("@INC_TYPE_ID", obj.balIncType);
        cmd.Parameters.AddWithValue("@INC_AMOUNT", obj.balIncValue);
        cmd.Parameters.AddWithValue("@INC_MONTH", obj.balMonth);
        cmd.Parameters.AddWithValue("@INC_YEAR", obj.balYear);
        cmd.Parameters.AddWithValue("@ORDER_DT", obj.balYear);
        cmd.Parameters.AddWithValue("@INC_REMARK", obj.balRemark);
        cmd.Parameters.AddWithValue("@INC_BY", obj.balCurEmpCode);
        cmd.Parameters.AddWithValue("@NOD", obj.balNod);
        databaseFunctions.GetDataSet(cmd);

    }
    #endregion
    #region SAL HOLD
    public void INSERT_SAL_HOLD(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SAL_MONTH_HOLD_SAL";
        cmd.Parameters.Add(new SqlParameter("@EMP_CODE", obj.balEmpCode));
        cmd.Parameters.Add(new SqlParameter("@MONTH", obj.balMonth));
        cmd.Parameters.Add(new SqlParameter("@YEAR", obj.balYear));
        cmd.Parameters.Add(new SqlParameter("@INSERT_BY", obj.balCurEmpCode));
        cmd.Parameters.Add(new SqlParameter("@REMARK", obj.balRemark));
        cmd.Parameters.Add(new SqlParameter("@STATUS", obj.balData));
         databaseFunctions.GetDataSet(cmd);
       

    }
    #endregion
    #region Payable Salary
    public DataTable PayableSalarySelect(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_MONTHLY_PAYABLE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH",obj.balMonth);
        cmd.Parameters.AddWithValue("@YEAR",obj.balYear);
        cmd.Parameters.AddWithValue("@TEMPID",obj.balTempId);
        cmd.Parameters.AddWithValue("@INS_NAME",obj.balIncType);
        cmd.Parameters.AddWithValue("@DEPT",obj.balDeptValue);
        cmd.Parameters.AddWithValue("@DESIG",obj.balDesigValue);
        cmd.Parameters.AddWithValue("@TYPE",obj.balHeadType);
        cmd.Parameters.AddWithValue("@EMP_ID",obj.balEmpCode);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion
    #region Add PF Arrear
    public int ADD_ARREAR_PF(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_PF_ARREAR_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emp_code",obj.balEmpCode);
        cmd.Parameters.AddWithValue("@for_month",obj.balMonth);
        cmd.Parameters.AddWithValue("@for_year",obj.balYear);
        cmd.Parameters.AddWithValue("@in_month",obj.balEndMonth);
        cmd.Parameters.AddWithValue("@in_year",obj.balEndYear);
        cmd.Parameters.AddWithValue("@AMT",obj.balAmt);
        cmd.Parameters.AddWithValue("@ins_by",obj.balCurEmpCode);
       return databaseFunctions.execute_non_query(cmd);

    }
    #endregion
    #region SALARY SLIP
    public DataTable getEmpInfo(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_EMP_INFO";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emp_code", obj.balEmpCode);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion
    #region Hold Report
    public DataTable GET_SAL_HOLD(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_MONTHLY_HOLD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@month", obj.balMonth);
        cmd.Parameters.AddWithValue("@year", obj.balYear);
        cmd.Parameters.AddWithValue("@job_type", obj.balJobType);
        cmd.Parameters.AddWithValue("@dept", obj.balDeptValue);
        cmd.Parameters.AddWithValue("@institute", obj.balInstituteValue);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion
    #region Report Salary Submitted
    public DataTable GetSubmittedSalary(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_MONTHLY_SUBMITTED_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", obj.balMonth);
        cmd.Parameters.AddWithValue("@YEAR", obj.balYear);
        cmd.Parameters.AddWithValue("@NOOFDAYS", obj.balNod);
        cmd.Parameters.AddWithValue("@TEMPID", obj.balTempId);
        cmd.Parameters.AddWithValue("@INS_NAME", obj.balInstituteValue);
        cmd.Parameters.AddWithValue("@DEPT", obj.balDeptValue);
        cmd.Parameters.AddWithValue("@DESIG", obj.balDesigValue);
        cmd.Parameters.AddWithValue("@EMP_ID", obj.balEmpCode);
        cmd.Parameters.AddWithValue("@recType", obj.balData);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    #endregion
    #region Monthly Cug Bill
    public DataTable GetBillDetail(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_CUG_BILL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", obj.balMonth);
        cmd.Parameters.AddWithValue("@YEAR", obj.balYear);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetBillEntry(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_BILL_ENTRY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", obj.balMonth);
        cmd.Parameters.AddWithValue("@YEAR", obj.balYear);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public int BillInsert(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_EMP_MONTHLY_BILL_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", obj.balHeadId);
        cmd.Parameters.AddWithValue("@TRANDATA", obj.balData);
        cmd.Parameters.AddWithValue("@TRAN_MONTH",obj.balMonth);
        cmd.Parameters.AddWithValue("@TRAN_YEAR", obj.balYear);
        cmd.Parameters.AddWithValue("@TRAN_IN_BY", obj.balCurEmpCode);
        return databaseFunctions.execute_non_query(cmd);

    }
    #endregion
    #region  Arrear
    public DataTable GetArrear(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "GET_ARREAR_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emp_code", obj.balEmpCode);
        cmd.Parameters.AddWithValue("@dateTo",obj.balMonth);
        cmd.Parameters.AddWithValue("@arrearType", obj.balArrearType);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable AddArrear(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "ADD_ARREAR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_VALUE", obj.balAmt);
        cmd.Parameters.AddWithValue("@EMP_CODE", obj.balEmpCode);
        cmd.Parameters.AddWithValue("@ORG_DATA", obj.balData);
        cmd.Parameters.AddWithValue("@EMP_CODE_BY", obj.balCurEmpCode);
        cmd.Parameters.AddWithValue("@ARREAR_TYPE", obj.balArrearType);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion
    #region printBankSheet
    public DataSet PrintBankSheet(PRBAL obj)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "SAL_GET_BANK_PRINT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REF_ID", obj.balData);
        cmd.Parameters.AddWithValue("@REC_MONTH", obj.balMonth);
        cmd.Parameters.AddWithValue("@REC_YEAR", obj.balYear);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

}
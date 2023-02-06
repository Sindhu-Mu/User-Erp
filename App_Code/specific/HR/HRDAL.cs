using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for HRDAL
/// </summary>
public class HRDAL
{
    DatabaseFunctions databaseFunctions;
    SqlCommand cmd;

    public HRDAL()
    {
        databaseFunctions = new DatabaseFunctions();
        
    }
    #region other
    #region EMPPLOYEE
    #region MULTIPLE ALL INSERT
    public void EmployeeMultiAllCurrent(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_INF_MULTI_ALL_CURRENT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VIEW_TYPE", objBal.ViewType);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region MULTIPLE INSERT
    public void EmployeeMultiInsert(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_INF_MULTI_EMP_CURRENT";

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@VIEW_TYPE", objBal.ViewType);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region SINGLE INSERT
    public void EmployeeSingleAll(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_INF_SINGLE_ALL_CURRENT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VIEW_TYPE", objBal.ViewType);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region SINGLE ALL INSERT
    public void EmployeeSingleInsert(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_INF_SINGLE_EMP_CURRENT";

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@VIEW_TYPE", objBal.ViewType);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #endregion
    #region ADDRESS TYPE
    public void AddressTypeFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADD_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ADD_TYPE_VALUE", objBal.FullName);
        databaseFunctions.ExecuteCommand(cmd);


    }

    #endregion

    #region BANK INSERT
    public void BankValueFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "BANK_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BANK_VALUE", objBal.KeyValue);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region CITY INSERT
    public void CityValueFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "CIT_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STA_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@CIT_VALUE", objBal.CommonId);
        cmd.Parameters.AddWithValue("@CIT_STD_CODE", objBal.Code);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region BANK ACCOUNT CHANGE
    public void EmployeeChangeAccount(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_BANK_ACC_CNG_INF_INSERT_PROC";

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@BANK_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@CIT_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@ACC_NO", objBal.AccountNo);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region EXPERIENCE INSERT
    public void EmployeeExpFunction(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_EXP_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@DES_ID", objBal.DesignationId);
        cmd.Parameters.AddWithValue("@OFF_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region INITIAL CHANGE
    public void EmployeeChangeInstituteFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_INI_CNG_INF_INSERT_PROC";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@INI_ID", objBal.InsId);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region MARTIAL STATUS CHANGE
    public void EmployeeMarksSectionFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_MAR_STS_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@MRS_STS_ID", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region NOT COUNT
    public void EmployeeNotCountFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_NOT_CNT_INF_PRC_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NOT_TYPE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PASSWORD CHANGE
    public void EmployeePasswordFunction(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PASS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@PASS", objBal.Password);
        cmd.Parameters.AddWithValue("@ACS_CODE", objBal.AccountNo);
        cmd.Parameters.AddWithValue("@LAST_CNG", objBal.LastChange);
        cmd.Parameters.AddWithValue("@QSN_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@QSN_ANS", objBal.QuestionAnswer);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region PHONE CHANGE INSERT
    public void EmployeePhoneChangeInfo(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PHN_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@PHN_TYPE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@PHN_NO", objBal.PhnNo);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region POST INSERT
    public void EmployeePostInfo(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "POST_INF_INSERT";

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@POST_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@POST_DESC", objBal.Description);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region RELIEVING INSERT
    public void EmployeeRelievingInfoInsert(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_RELV_INF_INSERT";

        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@RELV_TYPE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@REM", objBal.RemValue);
        cmd.Parameters.AddWithValue("@REG_DATE", objBal.RegDate);
        cmd.Parameters.AddWithValue("@REL_DATE", objBal.Date);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region RELIEVING TYPE
    public void EmployeeRelievingTypeInfoInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_RELV_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RELV_TYPE_VAL", objBal.KeyValue);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region ROLE INSERT
    public void EmployeeRoleInfo(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ROLE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@ROLE_ID", objBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region STATUS INSERT
    public void EmployeeStatusValue(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_STS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STS_VALUE", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #endregion
    #region Organisation
    public void OrganizationInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EXP_ORG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ORG_NAME", objBal.ORGNAME);
        cmd.Parameters.AddWithValue("@ORG_ADD", objBal.ORGADD);
        cmd.Parameters.AddWithValue("@CIT_ID", objBal.CITYID);
        cmd.Parameters.AddWithValue("@ORG_TYPE_ID", objBal.ORGTYPEID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void OrginizationModify(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EXP_ORG_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ORG_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@ORG_NAME", objBal.ORGNAME);
        cmd.Parameters.AddWithValue("@ORG_ADD", objBal.ORGADD);
        cmd.Parameters.AddWithValue("@CIT_ID", objBal.CITYID);
        cmd.Parameters.AddWithValue("@ORG_TYPE_ID", objBal.ORGTYPEID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region EMPLOYEE SHIFT CHANGE INSERT
    public void EmployeeShiftChangeInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_SHIFT_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@FROM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", objBal.RemValue);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region UNIVERSITY INSTITUTE INSERT
    public void UniversityInsInsert(HRBAL objBal)
    {
        cmd = new SqlCommand("UNIV_INS_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UNIV_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@INS_EVL_CODE", objBal.Code);
        cmd.Parameters.AddWithValue("@INS_DESC", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region UNIVESITY INSTITUTE INFORMATION UPDATE
    public void UnivInsInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UNIV_INS_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@UNIV_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@INS_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@INS_EVL_CODE", objBal.Code);
        cmd.Parameters.AddWithValue("@INS_DESC", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region UNIVESITY INSTITUTE INFORMATION MODIFY
    public void UnivInsInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UNIV_INS_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", objBal.InsId);
        cmd.Parameters.AddWithValue("@INS_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region INSTITUTE HEAD INSERT
    public void UnivInsHeadInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UNIV_INS_HEAD_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.Date);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ACADIMIC
    #region ACADAMIC BASE INFORMATION INSERT
    public void AcademicBaseInsert(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BASE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BASE_SHORT_NAME", objBal.ShortName);
        cmd.Parameters.AddWithValue("@ACA_BASE_FULL_NAME", objBal.FullName);
        cmd.Parameters.AddWithValue("@ACA_BASE_PRP", objBal.BasePrp);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region ACADIMIC BASE INFORMATION UPDATE
    public void AcaBaseUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BASE_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BASE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_BASE_FULL_NAME", objBal.FullName);
        cmd.Parameters.AddWithValue("@ACA_BASE_SHORT_NAME", objBal.ShortName);
        cmd.Parameters.AddWithValue("@ACA_BASE_PRP", objBal.BasePrp);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region ACADIMIC BASE INFORMATION MODIFY
    public void AcaBaseModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BASE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BASE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_BASE_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #region ACADMIC SECTION INSERT

    public void AcaSecInfInsert(HRBAL objBal)
    {
        SqlCommand cmd = new SqlCommand("ACA_SEC_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ACA_SEC_NAME", objBal.Name);
            cmd.Parameters.AddWithValue("@ACA_SEC_DESC", objBal.Description);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region ACADMIC SECTION UPDATE
    public void AcaSecInfUpdate(HRBAL objBal)
    {
        SqlCommand cmd = new SqlCommand("ACA_SEC_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ACA_SEC_ID", objBal.KeyID);
            cmd.Parameters.AddWithValue("@ACA_SEC_NAME", objBal.KeyValue);
            cmd.Parameters.AddWithValue("@ACA_SEC_DESC", objBal.Description);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region ACADMIC SECTION MODIFY
    public void AcaSecInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SEC_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEC_STATUS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion
    #region PAGE INFORMATION
    #region  PAGE INSERT
    public void PageInfInsert(HRBAL objBal)
    {
        cmd = new SqlCommand("PAGE_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_HEAD_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@PAGE_VALUE", objBal.PageName);
        cmd.Parameters.AddWithValue("@PAGE_URL", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region PAGE UPDATE
    public void PageInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("PAGE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAGE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SUB_HEAD_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@PAGE_VALUE", objBal.PageName);
        cmd.Parameters.AddWithValue("@PAGE_URL", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region  PAGE MODIFY
    public void PageInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PAGE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAGE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@PAGE_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PAGE HEAD INSERT
    public void PageHeadInfInsert(HRBAL objBal)
    {
        cmd = new SqlCommand("PAGE_HEAD_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region PAGE HEAD UPDATE
    public void PageHeadInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("PAGE_HEAD_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@HEAD_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PAGE HEAD MODIFY
    public void PageHeadInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PAGE_HEAD_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@HEAD_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PAGE SUB HEAD INSERT

    public void PageSubHeadInsert(HRBAL objBal)
    {
        cmd = new SqlCommand("PAGE_SUB_HEAD_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@SUB_HEAD_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region PAGE SUB HEAD UPDATE
    public void PageSubHeadUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("PAGE_SUB_HEAD_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_HEAD_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@HEAD_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@SUB_HEAD_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region PAGE SUB HEAD MODIFY
    public void PageSubHeadModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PAGE_SUB_HEAD_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_HEAD_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SUB_HEAD_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #endregion
    #region GUEST INSERT
    public void GuestInsert(HRBAL objBal)
    {
        cmd = new SqlCommand("GUEST_USR_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@GST_USR_NAME", objBal.Name);
            cmd.Parameters.AddWithValue("@GST_USR_MAIL", objBal.FullName);
            cmd.Parameters.AddWithValue("@MAIL_DOM_ID", objBal.CommonId);
            cmd.Parameters.AddWithValue("@GST_CON_NO", objBal.PhnNo);
            cmd.Parameters.AddWithValue("@GST_PURPOSE", objBal.PageName);
            cmd.Parameters.AddWithValue("@GST_DEPT_ID", objBal.KeyID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region DEPARTMENT SHIFT MAPPING
    #region UPDATE
    public void DeptShiftMapUpdate(HRBAL objBal)
    {
        SqlCommand cmd = new SqlCommand("DEPT_SHIFT_MAP_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@MAP_ID", objBal.KeyID);
            cmd.Parameters.AddWithValue("@DEPT_ID", objBal.DeptId);
            cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.CommonId);
            cmd.Parameters.AddWithValue("IN_BY", objBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region INSERT
    public void DeptShiftMapInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEPT_SHIFT_MAP_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region MODIFY
    public void DeptShiftMapModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEPT_SHIFT_MAP_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MAP_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@MAP_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion
    #region EMPLOYEE ID CARD
    #region Insert
    public void EmpIDCardInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ID_CARD_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@SESSION", 2013 - 2014);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #endregion

    #region EMP PF INFORMATION
    #region PF INSERT
    public string EmpPFMainInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NDATA", objBal.Document);
        cmd.Parameters.AddWithValue("@FDATA", objBal.FullName);
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@PF_ACC_NO", objBal.AccountNo);
        cmd.Parameters.AddWithValue("@PERM_ADRS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@TEMP_ADRS", objBal.ValueType);
        cmd.Parameters.AddWithValue("@JOIN_DT", objBal.FromDate);
        cmd.Parameters.AddWithValue("@FTHR_NAME", objBal.Description);
        cmd.Parameters.AddWithValue("@SPOUSE_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@REMARK", objBal.RemValue);
        cmd.Parameters.AddWithValue("@SCHM_ID", objBal.InBy);
        cmd.Parameters.AddWithValue("@DEDC_ID", objBal.DesignationId);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #region PF ACTVATE ACCOUNT
    public void EmpPFActiveAcc(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_ACC_CLOSE_INF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region PF CLOSE ACCOUNT
    public void EmpPFCloseAcc(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_END_ACC_INF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PF UPDATE
    public void EmpPFInfUpdate(HRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", obj.EmpId);
        cmd.Parameters.AddWithValue("@PF_ACC_NO", obj.AccountNo);
        cmd.Parameters.AddWithValue("@PERM_ADRS", obj.AliasValue);
        cmd.Parameters.AddWithValue("@TEMP_ADRS", obj.ValueType);
        cmd.Parameters.AddWithValue("@JOIN_DT", obj.FromDate);
        cmd.Parameters.AddWithValue("@FTHR_NAME", obj.Description);
        cmd.Parameters.AddWithValue("@SPOUSE_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@REMARK", obj.RemValue);
        cmd.Parameters.AddWithValue("@SCHM_ID", obj.InBy);
        cmd.Parameters.AddWithValue("@DEDC_ID", obj.DesignationId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    //#region PF BENIFIT INFORMATION
    ////public string EmpPFBenifit(BAL obj)
    ////{
    ////    cmd = new SqlCommand();
    ////    cmd.CommandText = "EMP_PF_BENIFIT_INF";
    //    cmd.CommandType = CommandType.StoredProcedure;       
    //    cmd.Parameters.AddWithValue("@EMP_ID", obj.EmpId);
    //    return databaseFunctions.GetSingleData(cmd);
    //}   
    //#endregion

    #region PF SCHEME INFORMATION
    public string SchemeMainInf(HRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SCHEME_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SCHM_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@SCHM_NAME", obj.FullName);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #endregion

    #region  NEW REGION
    #region SCHEME
    #region SCHEME INFORMATION INSERT
    public void SchemeInfInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SCHEME_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SCHM_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region SCHEME INFORMATION UPDATE
    public void SchemeInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SCHEME_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SCHM_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SCHM_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region SCHEME INFORMATION MODIFY
    public void SchemeInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SCHEME_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SCHM_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@STATUS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region RELATION
    #region RELATION INFORMATION INSERT
    public void RelationInfInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "RELATION_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RELATION_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region RELATION INFORMATION UPDATE
    public void RelationInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "RELATION_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RELATION_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@RELATION_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region RELATION INFORMATION MODIFY
    public void RelationInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "RELATION_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RELATION_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@RELATION_STATUS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region DEDUCTION
    #region DEDUCTION INFORMATION INSERT
    public void DeductionInfInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEDUCTION_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEDC_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@DEDC_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DEDUCTION INFORMATION UPDATE
    public void DeductionInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEDUCTION_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEDC_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DEDC_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@DEDC_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DEDUCTION INFORMATION MODIFY
    public void DeductionInfModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEDUCTION_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEDC_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@STATUS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion


    #region GET EMPLOYEE INFORMTION KEY VALUES
    public DataSet GetEmpKeyInf(HRBAL objBal)
    {
        SqlCommand command = new SqlCommand("GET_EMP_INF_SINGLE_EMP_CURRENT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        command.Parameters.AddWithValue("@VIEW_TYPE", 1);
        return databaseFunctions.GetDataSet(command);
    }

    #endregion


    #region Employee Update
    #region MAIN INFORMATION
    public void EmpMainInfUpdate(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_MAIN_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@F_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@M_NAME", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@L_NAME", objBal.BasePrp);
        cmd.Parameters.AddWithValue("@GEN_ID", objBal.CITYID);
        cmd.Parameters.AddWithValue("@DOB", objBal.Date);
        cmd.Parameters.AddWithValue("@CAS_ID", objBal.InsId);
        cmd.Parameters.AddWithValue("@REL_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@NAT_ID", objBal.HeadID);
        cmd.Parameters.AddWithValue("@MOT_TON_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@BLO_GRP_ID", objBal.Code);
        cmd.Parameters.AddWithValue("@EMP_FTH_NAME", objBal.Description);
        cmd.Parameters.AddWithValue("@EMP_MTH_NAME", objBal.Document);
        cmd.Parameters.AddWithValue("@NEXT_KIN_ID", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@NEXT_KIN_NAME", objBal.Max);
        cmd.Parameters.AddWithValue("@IS_HAND_ID", objBal.Min);
        cmd.Parameters.AddWithValue("@PAN_NO", objBal.ValueType);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region BANK INFORMATION
    public void EmployeeBankInfUpdate(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_BANK_ACC_CNG_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@BANK_ID", objBal.Name);
        cmd.Parameters.AddWithValue("@BRANCH_NAME", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@BANK_ADD", objBal.BasePrp);
        cmd.Parameters.AddWithValue("@CIT_ID", objBal.CITYID);
        cmd.Parameters.AddWithValue("@ACC_NO", objBal.AccountNo);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.Date);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region OFFICIAL INFORMATION
    public void EmployeeOffInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_OFFICIAL_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", objBal.CITYID);
        cmd.Parameters.AddWithValue("@SERV_TYPE_ID", objBal.Code);
        cmd.Parameters.AddWithValue("@CAT_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@DES_ID", objBal.DesignationId);
        cmd.Parameters.AddWithValue("@DEPT_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@EMP_NEXT_SNR_ID", objBal.HeadID);
        cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region ADDRESS INFORMATION
    public void EmployeeAdrsInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("EMP_ADD_CNG_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@ADD_TYPE_ID", 1);
        cmd.Parameters.AddWithValue("@ADD_1", objBal.Description);
        cmd.Parameters.AddWithValue("@ADD_2", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@CIT_ID", objBal.CITYID);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PHONE INFORMATION
    public void EmployeePhneInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("EMP_PHN_CNG_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@PHN_TYPE_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@PHN_NO", objBal.Description);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region MAIL INFORMATION
    public void EmployeeMailInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_MAIL_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@MAIL_TYPE_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@MAIL_VALUE", objBal.Description);
        cmd.Parameters.AddWithValue("@MAIL_DOM_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region QUALIFICATION INFORMATION
    public void EmployeeACAInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ACA_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@ACA_BASE_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@ACA_BRD_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@SCH", objBal.Description);
        cmd.Parameters.AddWithValue("@PTRN_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@YER", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@PRSNT", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region EXPERIENCE INFORMATION
    public void EmployeeEXPInfUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_EXP_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@EXP_ID", objBal.CommonId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmployeeInfDelete(HRBAL objBal, string Commnad)
    {
        cmd = new SqlCommand();
        cmd.CommandText = Commnad;
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@KEY_ID", objBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion
    #endregion

    #region Ravi
    #region EMPLOYEE WARNING
    #region Warning Insert
    public void WarningInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WARNING_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@WARN_SUB", objBal.ValueType);
        cmd.Parameters.AddWithValue("@WARN_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@WARN_DATE", objBal.Date);
        cmd.Parameters.AddWithValue("@WARN_BY", 851);
        cmd.Parameters.AddWithValue("@WARN_DOC", objBal.Document);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Warning Update
    public void WarningUpdate(HRBAL objBal)
    {
        SqlCommand cmd = new SqlCommand("EMP_WARNING_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@WARN_ID", objBal.KeyID);
            cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
            cmd.Parameters.AddWithValue("@WARN_SUB", objBal.ValueType);
            cmd.Parameters.AddWithValue("@WARN_TYPE_ID", objBal.TypeId);
            cmd.Parameters.AddWithValue("@WARN_DATE", objBal.Date);
            cmd.Parameters.AddWithValue("@WARN_BY", 11);
            cmd.Parameters.AddWithValue("@WARN_DOC", objBal.Document);
            cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion



    #region WARNINGMODIFY
    public void WarningModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WARNING_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@WARN_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@WARN_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion
    #region CASTE
    #region CASTE INSERT
    public void CasteInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "CAS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAS_VALUE", objBal.FullName);
        cmd.Parameters.AddWithValue("@CAS_ALIAS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region CASTE MODIFY
    public void CasteModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "CAS_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAS_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@CAS_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region CASTE UPDATE
    public void CasteUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("CAS_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAS_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@CAS_VALUE", objBal.ValueType);
        cmd.Parameters.AddWithValue("@CAS_ALIAS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #endregion
    #region SHIFT
    #region SHIFT INSERT
    public void ShiftInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SHIFT_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SHIFT_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_TIME", objBal.InTime);
        cmd.Parameters.AddWithValue("@OUT_TIME", objBal.OutTime);
        cmd.Parameters.AddWithValue("@SHORT_NAME", objBal.ShortName);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion


    #region SHIFT UPDATE
    public void ShiftUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("SHIFT_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SHIFT_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_TIME", objBal.InTime);
        cmd.Parameters.AddWithValue("@OUT_TIME", objBal.OutTime);
        cmd.Parameters.AddWithValue("@SHORT_NAME", objBal.ShortName);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region SHIFT MODIFY
    public void ShiftModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SHIFT_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SHIFT_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #region SHIFT TIME INSERT MODIFY
    public void ShiftTimeInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SHIFT_TIME_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SHIFT_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BFR_TIME", objBal.ShiftMinBefore);
        cmd.Parameters.AddWithValue("@IN_AFT_TIME", objBal.ShiftMinAfter);
        cmd.Parameters.AddWithValue("@OUT_BFR_TIME", objBal.ShiftMaxBefore);
        cmd.Parameters.AddWithValue("@OUT_AFT_TIME", objBal.ShiftMaxAfter);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public void ShiftTimeModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SHIFT_TIME_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TIME_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@TIME_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion
    #region DESIGNATION CHANGE
    #region Designation Change Insert

    public void EmpDesChangeInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DES_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@DES_ID", objBal.ValueType);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.Date);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    
    #endregion
    #endregion
    #region DESIGNATION
    #region DESIGNATION INSERT
    public void DesignationInsert(HRBAL objBal)
    {

        cmd = new SqlCommand("DES_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@DES_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region DESIGNATION UPDATE
    public void DesignationUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("DES_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DES_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@CAT_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@DES_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region DESIGNATION MODIFY
    public void DesignationModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DES_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DES_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DES_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region EMPLOYEE DESIGNATION CHANGE
    public void EmployeeDesignationChangeFunction(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DES_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@DES_ID", objBal.DesignationId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #endregion

    #region DOCUMENT UPLOAD
    #region Document Upload Insert

    public void DocumentUploadInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_UPLD_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DOC_DTL_ID", objBal.CommonId);
        cmd.Parameters.AddWithValue("@UPLD_FILE", objBal.Document);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region CATEGORY

    public void EmpCatInsert(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_CAT_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@CAT_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@CAT_ALIAS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public void EmpCatUpadte(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_CAT_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@CAT_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@CAT_ALIAS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public void EmpCatModify(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_CAT_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@CAT_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region SERVICE TYPE
    #region SERVICE TYPE INSERT
    public void ServiceTypeInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SERV_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SERV_TYPE_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@SERV_TYPE_DESC", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region SERVICE UPDATE
    public void ServiceTypeUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("SERV_TYPE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SERV_TYPE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SERV_TYPE_VALUE", objBal.ValueType);
        cmd.Parameters.AddWithValue("@SERV_TYPE_DESC", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region SERVICE TYPE MODIFY
    public void ServiceTypeModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SERV_TYPE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SERV_TYPE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SERV_TYPE_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region SERVICE TYPE CHANGE
    public void EmployeeServiceChange(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_SERV_TYPE_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@SERV_TYPE_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion
    #region DOCUMENT MASTER
    #region Document Master Insert
    public void EmpDocTypeInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", objBal.ValueType);
        cmd.Parameters.AddWithValue("@DOC_FOR_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region DOCUMENT Update
    public void EmpDocTypeUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("EMP_DOC_TYPE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DOC_NAME", objBal.Name);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", objBal.ValueType);
        cmd.Parameters.AddWithValue("@DOC_FOR_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region DOCUMENTMODIFY
    public void EmpDocTypeModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_TYPE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DOC_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DOCUMENT MASTER STATUS INSERT
    public void DocumentMasterStatusInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_STS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.Name);
        cmd.Parameters.AddWithValue("@SUBMITTING_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region DOCUMENT MASTER STATUS UPDATE
    public void DocumentMasterStatusUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("EMP_DOC_STS_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_STS_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@SUBMITTING_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@REMARK", objBal.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region DOCUMENT MASTER STATUS MODIFY
    public void DocumentMasterStatusModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_STS_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_STS_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DOC_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion


    #region EMPLOYEE STATUS CHANGE INSERT
    #region Employee Status Change Insert
    public void EmpStatusCngInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_STS_CNG_INF_INSERTPROC";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@STS_ID", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.Date);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #region Employee Status Change Update



    #region Employee Change Status Update
    public void EmpStatusCngUpdate(HRBAL objBal)
    {
        SqlCommand cmd = new SqlCommand("EMP_STS_CNG_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
            cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
            cmd.Parameters.AddWithValue("@STS_ID", objBal.KeyValue);
            cmd.Parameters.AddWithValue("@FRM_DATE", objBal.Date);
            cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);

            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    #endregion
    #endregion


    #region Employee Status Modify
    #region Status Modify
    public void StatusModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_STS_CNG_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@STATUS_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion
    #endregion

    #region DEPARTMENT
    #region DEPARTMENT INSERT
    public void DepartmentInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_DEPT_INF_INSERT ";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", objBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@DEPT_ALIAS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@DEPT_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IS_ESSENTIAL", objBal.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region DEPARTMENT CHANGE
    public void ChangeEmployeeInfo(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DEPT_CNG_INF_INSERT_PROC";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@DEPT_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region DEPARTMENT UPDATE
    public void DepartmentUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand("INS_DEPT_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", objBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DEPT_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@DEPT_ALIAS", objBal.AliasValue);
        cmd.Parameters.AddWithValue("@DEPT_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IS_ESSENTIAL", objBal.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region DEPARTMENT MODIFY
    public void DepartmentModify(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_DEPT_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DEPT_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion
    #region DEPARTMENT CHANGE
    #region Department Change Insert

    public void EmpDeptCngInsert(HRBAL objBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DEPT_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@DEPT_ID", objBal.DeptId);
        cmd.Parameters.AddWithValue("@DEPT_FRM_DATE", objBal.Date);
        cmd.Parameters.AddWithValue("@DEPT_CNG_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@DEPT_CNG_RMK", objBal.Description);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion
    #endregion
    #endregion

    #region PRIYA
    #region WORKING DAY
    #region WORKING DAY Insert
    public void WorkingDayInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "WORKING_DAY_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@WORKING_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@INS", objBal.InsId);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region WORKING DAY Update
    public void WorkingDayUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "WORKING_DAY_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@WORKING_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@INS_ID", objBal.InsId);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region WORKING DAY Delete
    public void WorkingDayDelete(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "WORKING_DAY_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region HOLIDAY
    #region Holiday Insert
    public void HolidayInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "HOLIDAYS_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HOLIDAY_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@HOLIDAY_NAME", objBal.Description);
        cmd.Parameters.AddWithValue("@INSTITUTE", objBal.InsId);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Holiday Delete
    public void HolidayDelete(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "HOLIDAYS_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Holiday Update
    public void HolidayUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "HOLIDAYS_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@HOLIDAY_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@HOLIDAY_NAME", objBal.Description);
        cmd.Parameters.AddWithValue("@INSTITUTE", objBal.InsId);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #endregion

    #region Week Off
    #region Week Off Insert
    public void EmpWeekOffInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WEEK_OFF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@WEEK_OFF_DAY", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@OFF_TYPE", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FROM_DATE",objBal.FromDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Week Off Deactivate
    public void EmpWeekOffDisable(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WEEK_OFF_DEACTIVATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", "0");
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    //#region LEAVE
    //#region Leave Application
    //public string EmpLvCheck(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_CHECK";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@LV_TYPE_ID", objBal.TypeId);
    //    cmd.Parameters.AddWithValue("@FRM_DT", objBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TO_DT", objBal.ToDate);
    //    cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.ValueType);
    //    cmd.Parameters.AddWithValue("@LV_CASE", objBal.ViewType);
    //    return databaseFunctions.GetSingleData(cmd);
    //}

    //public void EmpLvAppInsert(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_APP_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@LV_ID", objBal.TypeId);
    //    cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
    //    cmd.Parameters.AddWithValue("@REASON", objBal.Description);
    //    cmd.Parameters.AddWithValue("@CON_ADD", objBal.RemValue);
    //    cmd.Parameters.AddWithValue("@DAY_TYPE_ID ", objBal.ValueType);
    //    cmd.Parameters.AddWithValue("@STS_ID", objBal.ChangeStatus);
    //    cmd.Parameters.AddWithValue("@LV_CASE_ID", objBal.ViewType);
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@NOD", objBal.Max);
    //    if (objBal.KeyValue != "")
    //        cmd.Parameters.AddWithValue("@ARR_DATA", objBal.KeyValue);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    //public DataSet EmpLvDaySelect(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_EXCLUDE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@FDATE", objBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TDATE", objBal.ToDate);
    //    cmd.Parameters.AddWithValue("@LV_TYPE", objBal.TypeId);
    //    return databaseFunctions.GetDataSet(cmd);
    //}
    //public DataTable EmpTTSelectForTT(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_TT_FOR_LV_ARR";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@FRM_DT", objBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TO_DT", objBal.ToDate);
    //    //cmd.Parameters.AddWithValue("@LV_TYPE", objBal.TypeId);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public DataTable EmpLvDetailSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_DETAIL_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@PROC_TYPE_ID", ObjBal.TypeId);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}
    //#endregion

    //#region Employee Leave eligibility
    //public void EmpLvNotEligibleInsert(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_NOT_ELIGIBLE_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@FROM_DT", objBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TO_DT", objBal.ToDate);
    //    cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //public void EmpLvOpen(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_LEAVE_OPEN";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion

    //#region Compensatory Leave
    //public void EmpComLvCrdInsert(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_COM_LV_CRD_INF_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@WORK_DT", objBal.Date);
    //    cmd.Parameters.AddWithValue("@FROM_TIME", objBal.InTime);
    //    cmd.Parameters.AddWithValue("@TO_TIME", objBal.OutTime);
    //    cmd.Parameters.AddWithValue("@DESCRP", objBal.Description);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    //public DataTable EmpComLvCrdCheck(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_COM_LV_CRD_CHECK";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@WORK_DT", objBal.Date);
    //    cmd.Parameters.AddWithValue("@TYPE", objBal.TypeId);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public void ComLvCrdRecommanded(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "COM_CREDIT_RECOMMANDED";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
    //    cmd.Parameters.AddWithValue("@DATA", objBal.KeyValue);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //public DataTable AttForCom(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "ATTEN_FOR_COM";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@WORKING_DT", objBal.Date);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}
    //public void ComLvCrdApproved(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "COM_CREDIT_ACTION";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
    //    cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
    //    cmd.Parameters.AddWithValue("@DAY", objBal.TypeId);
    //    cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion

    //#region Leave Approval
    //public void EmpLvArvCan(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_ARV_CAN";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.HeadID);
    //    cmd.Parameters.AddWithValue("@ACT_REQ_ID", objBal.KeyID);
    //    cmd.Parameters.AddWithValue("@APPRVD_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
    //    cmd.Parameters.AddWithValue("@STS_ID", objBal.ChangeStatus);
    //    cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //public DataSet EmpLvApprvlDetailSelect(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_APPRVL_DETAIL_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.HeadID);
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public void EmpLvRecommend(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_APP_RECOMMEND";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.HeadID);
    //    cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
    //    cmd.Parameters.AddWithValue("@IN_FROM", objBal.InBy);
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@FORWORD_TO", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    //public DataTable BtnSelect(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_APP_BUTTON_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@EMP_LV", objBal.EmpId);
    //    cmd.Parameters.AddWithValue("@ACTION_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@LV_TYPE_ID", objBal.TypeId);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}
    //#endregion

    //#region OnDuty
    //public string EmpOnDutyInsert(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_ONDUTY_APP_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
    //    cmd.Parameters.AddWithValue("@REASON", objBal.Description);
    //    cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0].Rows[0][0].ToString();
    //}
    //#endregion

    //#region Leave Main
    //public void LeaveMainInsert(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "LEAVE_TYPE_INF_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_VALUE", objBal.KeyValue);
    //    cmd.Parameters.AddWithValue("@MIN_AVL", objBal.Min);
    //    cmd.Parameters.AddWithValue("@MAX_AVL", objBal.Max);
    //    cmd.Parameters.AddWithValue("@ANNUAL_QUOTA", objBal.Total);
    //    cmd.Parameters.AddWithValue("@MAX_ACCUMALATION", objBal.Value1);
    //    cmd.Parameters.AddWithValue("@CREDIT_TYPE", objBal.TypeId);
    //    cmd.Parameters.AddWithValue("@LV_CF", objBal.RemValue);
    //    cmd.Parameters.AddWithValue("@LEAVE_INCASH", objBal.ValueType);
    //    cmd.Parameters.AddWithValue("@LV_IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@LV_ARR", objBal.Pattern);
    //    cmd.Parameters.AddWithValue("@IS_CLUB", objBal.Value2);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //public void LeaveMainUpdate(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "LV_TYPE_INF_UPDATE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_ID", objBal.KeyID);
    //    cmd.Parameters.AddWithValue("@LV_VALUE", objBal.KeyValue);
    //    cmd.Parameters.AddWithValue("@MIN_AVL", objBal.Min);
    //    cmd.Parameters.AddWithValue("@MAX_AVL", objBal.Max);
    //    cmd.Parameters.AddWithValue("@ANNUAL_QUOTA", objBal.Total);
    //    cmd.Parameters.AddWithValue("@MAX_ACCUMALATION", objBal.Value1);
    //    cmd.Parameters.AddWithValue("@CREDIT_TYPE", objBal.TypeId);
    //    cmd.Parameters.AddWithValue("@LV_CF", objBal.RemValue);
    //    cmd.Parameters.AddWithValue("@LEAVE_INCASH", objBal.ValueType);
    //    cmd.Parameters.AddWithValue("@LV_IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@LV_ARR", objBal.Pattern);
    //    cmd.Parameters.AddWithValue("@IS_CLUB", objBal.Value2);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //public void LeaveMainDelete(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "LV_TYPE_INF_DELETE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion

    //#region Leave Arrangement
    //public DataTable EmpLvArrReportSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_ARR_REPORT_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public DataTable EmpLvArrSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_FOR_ARR_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public DataTable TTatLvDate(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "TT_AT_LV_DATE_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_ARR_ID", ObjBal.HeadID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public DataTable EmpLvArrRejected(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_ARR_REJECTED";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}
    //public void EmpLvArrAction(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_ARR_ACTION";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
    //    cmd.Parameters.AddWithValue("@LV_ARR_ID", ObjBal.HeadID);
    //    cmd.Parameters.AddWithValue("@STS_ID", ObjBal.ChangeStatus);
    //    cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //public DataTable EmpLvReArrSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "SELECT LV_TYPE_INF.LV_VALUE, EMP_LV_APP_INF.FROM_DT, EMP_LV_APP_INF.TO_DT, EMP_LV_APP_INF.TOT_DAYS, PROC_STS_TYPE_INF.STS_VALUE "
    //        + "FROM EMP_LV_APP_INF INNER JOIN LV_TYPE_INF ON EMP_LV_APP_INF.LV_ID = LV_TYPE_INF.LV_ID INNER JOIN PROC_STS_TYPE_INF ON EMP_LV_APP_INF.STS_ID = PROC_STS_TYPE_INF.STS_ID WHERE LV_APP_ID=" + ObjBal.KeyID;
    //    cmd.CommandType = CommandType.Text;
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public void EmpLvReArrInsert(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_RE_ARR";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_ARR_ID", ObjBal.HeadID);
    //    cmd.Parameters.AddWithValue("@ARR_WITH", ObjBal.EmpId);
    //    cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
    //    cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion

    //#region Leave Cancelllation
    //public DataTable EmpLvCancelSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_CANCEL_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}
    //public void EmpLvCancelApply(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_CANCEL_APPLY";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion

    //#region Leave Report
    //public void LeaveBalanceInsert(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_BAL_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.Add(new SqlParameter("@EMP_ID", ObjBal.EmpId));
    //    cmd.Parameters.Add(new SqlParameter("@LV_ID", ObjBal.Code));
    //    cmd.Parameters.Add(new SqlParameter("@CR_BL", ObjBal.Total));
    //    cmd.Parameters.Add(new SqlParameter("@CR_YEAR", ObjBal.Year));
    //    cmd.Parameters.Add(new SqlParameter("@CR_DATE", ObjBal.Date));
    //    cmd.Parameters.Add(new SqlParameter("@CR_USR_ID", ObjBal.InBy));
    //    cmd.Parameters.Add(new SqlParameter("@CR_REM", ObjBal.Description));
    //    cmd.Parameters.Add(new SqlParameter("@TYPE_ID", ObjBal.TypeId));
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    //public DataSet GetLeaveBalance(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "SELECT EMP_LV_BAL_INF.LV_ID, EMP_LV_BAL_INF.OPENING_BAL, LV_TYPE_INF.LV_VALUE, EMP_LV_BAL_INF.CREDIT_BAL, EMP_LV_BAL_INF.CURRENT_BAL, " +
    //        " EMP_LV_BAL_INF.AVAILED_BAL, EMP_LV_BAL_INF.APPLIED_BAL, EMP_LV_BAL_INF.LAPSED_BAL FROM  EMP_LV_BAL_INF INNER JOIN " +
    //        " LV_TYPE_INF ON EMP_LV_BAL_INF.LV_ID = LV_TYPE_INF.LV_ID INNER JOIN USR_INF ON EMP_LV_BAL_INF.USR_ID = USR_INF.USR_ID " +
    //        " WHERE (EMP_LV_BAL_INF.CUR_YEAR = @YEAR) AND (USR_INF.USR_LOGIN_ID = @EMP_ID)";
    //    cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
    //    cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public void LeaveBalanceDelete(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_APP_DELETE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    //public void LeaveAppUpdate(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_UPDATE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
    //    cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.FromDate);
    //    cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion
    //#endregion

    #region LEAVE
    #region Leave Application
    public string EmpLvCheck(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_CHECK";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@LV_TYPE_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@FRM_DT", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DT", objBal.ToDate);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.ValueType);
        cmd.Parameters.AddWithValue("@LV_CASE", objBal.ViewType);
        return databaseFunctions.GetSingleData(cmd);
    }

    public string EmpLvAppInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_APP_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@LV_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        cmd.Parameters.AddWithValue("@REASON", objBal.Description);
        cmd.Parameters.AddWithValue("@CON_ADD", objBal.RemValue);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID ", objBal.ValueType);
        cmd.Parameters.AddWithValue("@STS_ID", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@LV_CASE_ID", objBal.ViewType);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@NOD", objBal.Max);
        if (objBal.KeyValue != "")
            cmd.Parameters.AddWithValue("@ARR_DATA", objBal.KeyValue);
       return databaseFunctions.GetSingleData(cmd);
    }

    public void EmpLvAppInsertForHR(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_APP_INSERT_FOR_HR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@LV_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        cmd.Parameters.AddWithValue("@REASON", objBal.Description);
        cmd.Parameters.AddWithValue("@CON_ADD", objBal.RemValue);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID ", objBal.ValueType);
        cmd.Parameters.AddWithValue("@APRV_BY", objBal.PostId);
        cmd.Parameters.AddWithValue("@APRV_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@LV_CASE_ID", objBal.ViewType);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@NOD", objBal.Max);
        if (objBal.KeyValue != "")
            cmd.Parameters.AddWithValue("@ARR_DATA", objBal.KeyValue);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataSet EmpLvDaySelect(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_EXCLUDE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FDATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TDATE", objBal.ToDate);
        cmd.Parameters.AddWithValue("@LV_TYPE", objBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataTable EmpTTSelectForTT(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_TT_FOR_LV_ARR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FRM_DT", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DT", objBal.ToDate);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
        //cmd.Parameters.AddWithValue("@LV_TYPE", objBal.TypeId);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable EmpLvDetailSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@PROC_TYPE_ID", ObjBal.TypeId);
        if (ObjBal.AliasValue != "")
            cmd.Parameters.AddWithValue("@TYPE", ObjBal.AliasValue);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public void EmpLvDocInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_DOC_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@PATH", objBal.PageName);
        cmd.Parameters.AddWithValue("@DOC_NAME", objBal.Document);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region Employee Leave eligibility
    public void EmpLvNotEligibleInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_NOT_ELIGIBLE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@FROM_DT", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DT", objBal.ToDate);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmpLvOpen(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_LEAVE_OPEN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Compensatory Leave
    //public void EmpComLvCrdInsert(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_COM_LV_CRD_INF_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@WORK_DT", objBal.Date);
    //    cmd.Parameters.AddWithValue("@FROM_TIME", objBal.InTime);
    //    cmd.Parameters.AddWithValue("@TO_TIME", objBal.OutTime);
    //    cmd.Parameters.AddWithValue("@DESCRP", objBal.Description);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    public void EmpComLvCrdInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_COM_LV_CRD_INF_INS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@WORK_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@FROM_TIME", objBal.InTime);
        cmd.Parameters.AddWithValue("@TO_TIME", objBal.OutTime);
        cmd.Parameters.AddWithValue("@DESCRP", objBal.Description);
        cmd.Parameters.AddWithValue("@ACTION", objBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataTable EmpComLvCrdCheck(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_COM_LV_CRD_CHECK";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@WORK_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@TYPE", objBal.TypeId);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public void ComLvCrdRecommanded(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "COM_CREDIT_RECOMMANDED";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@DATA", objBal.KeyValue);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataTable AttForCom(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ATTEN_FOR_COM";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@WORKING_DT", objBal.Date);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    //public void ComLvCrdApproved(HRBAL objBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "COM_CREDIT_ACTION";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
    //    cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
    //    cmd.Parameters.AddWithValue("@DAY", objBal.TypeId);
    //    cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}

    public void ComLvCrdApproved(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "COM_CREDIT_ACT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@DAY", objBal.TypeId);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@ACTION_TO", objBal.Code);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void EmpComCrdByHR(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_COM_LV_CRD_BY_HR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@WORK_DT", objBal.Date);
        cmd.Parameters.AddWithValue("@ROLE_ID", objBal.Name);
        cmd.Parameters.AddWithValue("@APRV_DT", objBal.RegDate);
        cmd.Parameters.AddWithValue("@NOD", objBal.Max);
        cmd.Parameters.AddWithValue("@DESCRP", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Leave Approval
    public void EmpLvArvCan(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_ARV_CAN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.HeadID);
        cmd.Parameters.AddWithValue("@ACT_REQ_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@APPRVD_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@STS_ID", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet EmpLvApprvlDetailSelect(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_APPRVL_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.HeadID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void EmpLvRecommend(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_APP_RECOMMEND";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_APP_ID", objBal.HeadID);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@IN_FROM", objBal.InBy);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FORWORD_TO", objBal.EmpId);
        cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataTable BtnSelect(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_APP_BUTTON_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_LV", objBal.EmpId);
        cmd.Parameters.AddWithValue("@ACTION_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@LV_TYPE_ID", objBal.TypeId);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion

    #region OnDuty
    public string EmpOnDutyInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ONDUTY_APP_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FRM_DATE", objBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DATE", objBal.ToDate);
        cmd.Parameters.AddWithValue("@REASON", objBal.Description);
        cmd.Parameters.AddWithValue("@DAY_TYPE_ID", objBal.TypeId);
        return databaseFunctions.GetDataSet(cmd).Tables[0].Rows[0][0].ToString();
    }
    #endregion

    #region Leave Main
    public void LeaveMainInsert(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "LEAVE_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@MIN_AVL", objBal.Min);
        cmd.Parameters.AddWithValue("@MAX_AVL", objBal.Max);
        cmd.Parameters.AddWithValue("@ANNUAL_QUOTA", objBal.Total);
        cmd.Parameters.AddWithValue("@MAX_ACCUMALATION", objBal.Value1);
        cmd.Parameters.AddWithValue("@CREDIT_TYPE", objBal.TypeId);
        cmd.Parameters.AddWithValue("@LV_CF", objBal.RemValue);
        cmd.Parameters.AddWithValue("@LEAVE_INCASH", objBal.ValueType);
        cmd.Parameters.AddWithValue("@LV_IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@LV_ARR", objBal.Pattern);
        cmd.Parameters.AddWithValue("@IS_CLUB", objBal.Value2);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void LeaveMainUpdate(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "LV_TYPE_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@LV_VALUE", objBal.KeyValue);
        cmd.Parameters.AddWithValue("@MIN_AVL", objBal.Min);
        cmd.Parameters.AddWithValue("@MAX_AVL", objBal.Max);
        cmd.Parameters.AddWithValue("@ANNUAL_QUOTA", objBal.Total);
        cmd.Parameters.AddWithValue("@MAX_ACCUMALATION", objBal.Value1);
        cmd.Parameters.AddWithValue("@CREDIT_TYPE", objBal.TypeId);
        cmd.Parameters.AddWithValue("@LV_CF", objBal.RemValue);
        cmd.Parameters.AddWithValue("@LEAVE_INCASH", objBal.ValueType);
        cmd.Parameters.AddWithValue("@LV_IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@LV_ARR", objBal.Pattern);
        cmd.Parameters.AddWithValue("@IS_CLUB", objBal.Value2);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void LeaveMainDelete(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "LV_TYPE_INF_DELETE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Leave Arrangement
    public DataTable EmpLvArrReportSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_ARR_REPORT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable EmpLvArrSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_FOR_ARR_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable TTatLvDate(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TT_AT_LV_DATE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_ARR_ID", ObjBal.HeadID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable EmpLvArrRejected(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_ARR_REJECTED";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public void EmpLvArrAction(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_ARR_ACTION";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@LV_ARR_ID", ObjBal.HeadID);
        cmd.Parameters.AddWithValue("@STS_ID", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataTable EmpLvReArrSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT LV_TYPE_INF.LV_VALUE, EMP_LV_APP_INF.FROM_DT, EMP_LV_APP_INF.TO_DT, EMP_LV_APP_INF.TOT_DAYS, PROC_STS_TYPE_INF.STS_VALUE "
            + "FROM EMP_LV_APP_INF INNER JOIN LV_TYPE_INF ON EMP_LV_APP_INF.LV_ID = LV_TYPE_INF.LV_ID INNER JOIN PROC_STS_TYPE_INF ON EMP_LV_APP_INF.STS_ID = PROC_STS_TYPE_INF.STS_ID WHERE LV_APP_ID=" + ObjBal.KeyID;
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public void EmpLvReArrInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_RE_ARR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_ARR_ID", ObjBal.HeadID);
        cmd.Parameters.AddWithValue("@ARR_WITH", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    public void EmpLeaveBalanceUpdate(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_BAL_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_BL_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@CREDIT_BAL", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@LAPSED_BAL", ObjBal.Value2);        
        cmd.Parameters.AddWithValue("@AVAILED_BAL", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@APPLIED_BAL", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.InBy);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #region Leave Cancelllation
    public DataTable EmpLvCancelSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_CANCEL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable EmpLvCancelSelectForHR(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_CANCEL_SELECT_FOR_HR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public void EmpLvCancelApply(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_CANCEL_APPLY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmpLvCancelByHR(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_CANCEL_BY_HR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@APRV_BY", ObjBal.Code);
        cmd.Parameters.AddWithValue("@APRV_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Leave Report
    public void LeaveBalanceInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_BAL_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@EMP_ID", ObjBal.EmpId));
        cmd.Parameters.Add(new SqlParameter("@LV_ID", ObjBal.Code));
        cmd.Parameters.Add(new SqlParameter("@CR_BL", ObjBal.Total));
        cmd.Parameters.Add(new SqlParameter("@CR_YEAR", ObjBal.Year));
        cmd.Parameters.Add(new SqlParameter("@CR_DATE", ObjBal.Date));
        cmd.Parameters.Add(new SqlParameter("@CR_USR_ID", ObjBal.InBy));
        cmd.Parameters.Add(new SqlParameter("@CR_REM", ObjBal.Description));
        cmd.Parameters.Add(new SqlParameter("@TYPE_ID", ObjBal.TypeId));
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataSet GetLeaveBalance(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT EMP_LV_BAL_INF.LV_ID,EMP_LV_BAL_INF.LV_BL_ID, EMP_LV_BAL_INF.OPENING_BAL, LV_TYPE_INF.LV_VALUE, EMP_LV_BAL_INF.CREDIT_BAL, EMP_LV_BAL_INF.CURRENT_BAL, " +
            " EMP_LV_BAL_INF.AVAILED_BAL, EMP_LV_BAL_INF.APPLIED_BAL, EMP_LV_BAL_INF.LAPSED_BAL FROM  EMP_LV_BAL_INF INNER JOIN " +
            " LV_TYPE_INF ON EMP_LV_BAL_INF.LV_ID = LV_TYPE_INF.LV_ID INNER JOIN USR_INF ON EMP_LV_BAL_INF.USR_ID = USR_INF.USR_ID " +
            " WHERE (EMP_LV_BAL_INF.CUR_YEAR = @YEAR) AND (USR_INF.USR_LOGIN_ID = @EMP_ID)";
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void LeaveBalanceDelete(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_APP_DELETE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void LeaveAppUpdate(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region Employee Document Collection
    public DataTable EmpDocumentSelect(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_MAIN_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public string Teaching(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT JOB_TYPE_ID FROM EMP_JOB_TYPE_CNG_INF WHERE TO_DATE IS NULL AND EMP_ID=" + objBal.EmpId;
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetSingleData(cmd);
    }
    public void EmpDocDetailAdd(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_DETAIL_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        cmd.Parameters.AddWithValue("@DOC_ID", objBal.TypeId);
        cmd.Parameters.AddWithValue("@DOC_REMARK", objBal.Description);
        cmd.Parameters.AddWithValue("@DOC_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmpDocDetailFirstInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_DETAIL_FIRST_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XMLDATA", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmpBlockInsert(HRBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_BLOCK_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objbal.EmpId);
        cmd.Parameters.AddWithValue("@BLOCK_TYPE_ID", objbal.TypeId);
        cmd.Parameters.AddWithValue("@FROM_DT", objbal.FromDate);
        cmd.Parameters.AddWithValue("@REMARK", objbal.RemValue);
        cmd.Parameters.AddWithValue("@INS_BY", objbal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
#endregion
#endregion


    #region Qualification
    public void EmpAttUpdateByHR(HRBAL ObjHrBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ATT_UPDATE_BY_HR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("XML_DATA", ObjHrBal.Value1);
        cmd.Parameters.AddWithValue("USR_ID", ObjHrBal.EmpId);
        cmd.Parameters.AddWithValue("IN_BY", ObjHrBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void QualificationInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand("QUALIFICATION_INSERT");
        cmd.Parameters.AddWithValue("@ACA_CRS_VALUE", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void QualificationUpdate(HRBAL ObjBal)
    {
        cmd = new SqlCommand("QUALIFICATION_UPDATE");
        cmd.Parameters.AddWithValue("@ACA_CRS_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_CRS_VALUE", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        //cmd.Parameters.AddWithValue("", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    # endregion


}




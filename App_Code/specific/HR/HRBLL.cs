using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
/// <summary>
/// Summary description for HRBLL
/// </summary>
public class HRBLL
{
    HRDAL ObjHrDal;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    QueryFunctions queryFunctions;
    public HRBLL()
    {
        ObjHrDal = new HRDAL();
        databaseFunctions = new DatabaseFunctions();
        Msg = new Messages();
        queryFunctions = new QueryFunctions();
    }
    public DataSet IssueMonthAttendance(string XmlData, int month, int year)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_MONTH_ATTENDANCE_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XMLDATA", XmlData);
        cmd.Parameters.AddWithValue("@ATT_MONTH", month);
        cmd.Parameters.AddWithValue("@ATT_YEAR", year);
        ////
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetAttendanceCount(string Month, string Year, string Teaching, string institute, string Dept_ID, string type, int Days)
    {

        Dept_ID = (Dept_ID == "") ? "." : Dept_ID;
        cmd = new SqlCommand();
        cmd.CommandText = "GET_MONTH_ATTENDANCE_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", Month);
        cmd.Parameters.AddWithValue("@YEAR", Year);
        cmd.Parameters.AddWithValue("@INS", institute);
        cmd.Parameters.AddWithValue("@DEPT_ID", Dept_ID);
        cmd.Parameters.AddWithValue("@TEACHING", Teaching);
        cmd.Parameters.AddWithValue("@TYPE", type);
        cmd.Parameters.AddWithValue("@LASTDAY", Days);
        ////
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetTodaysBirthDay()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_BIRHTDAY";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetEmpAttendance(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_ATTENDANCE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetEmpMonthAttendance(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_MONTH_ATTENDANCE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        ObjBal.KeyValue = (ObjBal.KeyValue == ".") ? "0" : ObjBal.KeyValue;
        cmd.Parameters.AddWithValue("@ATT_TYPE_ID", ObjBal.KeyValue);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetEmpDaliyAttTran(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_DALIY_ATT_TRAN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpCardDetail(string emp_id)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ID_CARD_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("usr_id", emp_id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetEmpProfileDetail(string EMP_ID)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_PROFILE_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("EMP_ID", EMP_ID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public int GetEmpType(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GetEmployeeType";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.ExecuteScalar(cmd);

    }
    public DataSet EmpCardPrint(string emp_id)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GetPrintCard ";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("emp_code", emp_id);
        return databaseFunctions.GetDataSet(cmd);
    }

    #region Riju
    public DataSet SecCardPrint(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GetSecPrintCard ";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emp_code", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    public DataSet GetAdditionDeletion(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EMP_ADDITION_DELETION";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SEARCH_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@DES_ID", ObjBal.DesignationId);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@SRV_TYPE_ID", ObjBal.ViewType);
        cmd.Parameters.AddWithValue("@SEARCH_VALUE1", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@SEARCH_VALUE2", ObjBal.Value2);

        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetDailyAttendance(HRBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") || (ObjBal.DeptId == "All") ? "0" : ObjBal.DeptId;
        cmd = new SqlCommand();
        cmd.CommandText = "GET_DALIY_ATTENDANCE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.ViewType);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.KeyValue);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetSupportStaffAttendance(HRBAL ObjBal)
    {
     
        cmd = new SqlCommand();
        cmd.CommandText = "GET_SUPPORT_STAFF_ATTENDANCE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATE", ObjBal.KeyValue);
        
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetSupportStaffMonthlyAttendance(HRBAL ObjBal)
    {
        ObjBal.EmpId = (ObjBal.EmpId == "") ? "0" : ObjBal.EmpId;
        cmd = new SqlCommand();
        cmd.CommandText = "GET_SUPPORT_STAFF_MONTHLY_ATTENDANCE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region Employee
    #region Insert
    public string SaveNewUser(string emp_id, string F_NAME, string M_NAME, string L_NAME, string GEN_ID, string DOB, string DOJ, string DOC, string CAS_ID, string REL_ID, string NAT_ID, string MOT_TON_ID,
       string BLO_GRP_ID, string EMP_FTH_NAME, string EMP_MTH_NAME, string NEXT_KIN_ID, string NEXT_KIN_NAME, string IS_HAND_ID, string PAN_NO, string ADHAR_NO, string MAR_STS_ID, string INI_ID, string JOB_TYPE_ID, string SERV_TYPE_ID,
       string CAT_ID, string DES_ID, string DEPT_ID, string EMP_NEXT_SNR_ID, string Shift_Id, string ADD_DATA, string PHN_DATA, string MAIL_DATA, string ACA_DATA, string EXP_DATA, string BANK_ID, string BRANCH_NAME, string BANK_ADD, string CIT_ID, string ACC_NO,
        string spouse_name, string emp_type, string CONTRACT_PRD, string PROB_PRD, string SALARY_DATA)
    {
        try
        {
            CommonFunctions commonFunctions;
            commonFunctions = new CommonFunctions();
            CAT_ID = (CAT_ID == ".") ? DBNull.Value.ToString() : CAT_ID;
            MOT_TON_ID = (MOT_TON_ID == ".") ? DBNull.Value.ToString() : MOT_TON_ID;
            BLO_GRP_ID = (BLO_GRP_ID == ".") ? DBNull.Value.ToString() : BLO_GRP_ID;
            NEXT_KIN_ID = (NEXT_KIN_ID == ".") ? DBNull.Value.ToString() : NEXT_KIN_ID;

            if (emp_id == "0")
                cmd = new SqlCommand("SET_USER_NEW_INFORMATION");
            else
            {
                cmd = new SqlCommand("EMP_INFORMATION_UPDATE");
                cmd.Parameters.AddWithValue("@EMP_ID", emp_id);
            }
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@F_NAME", F_NAME);
            cmd.Parameters.AddWithValue("@M_NAME", commonFunctions.ValidateParameter(M_NAME));
            cmd.Parameters.AddWithValue("@L_NAME", commonFunctions.ValidateParameter(L_NAME));
            cmd.Parameters.AddWithValue("@GEN_ID", GEN_ID);
            cmd.Parameters.AddWithValue("@DOB", commonFunctions.GetDateTime(DOB));
            cmd.Parameters.AddWithValue("@DOJ", commonFunctions.GetDateTime(DOJ));
            if (DOC.Length > 1)
                cmd.Parameters.AddWithValue("@DOC", commonFunctions.GetDateTime(DOC));
            else
                cmd.Parameters.AddWithValue("@DOC", DOC);
            cmd.Parameters.AddWithValue("@CAS_ID", commonFunctions.ValidateParameter(CAS_ID));
            cmd.Parameters.AddWithValue("@REL_ID", commonFunctions.ValidateParameter(REL_ID));
            cmd.Parameters.AddWithValue("@NAT_ID", NAT_ID);
            cmd.Parameters.AddWithValue("@MOT_TON_ID", commonFunctions.ValidateParameter(MOT_TON_ID));
            cmd.Parameters.AddWithValue("@BLO_GRP_ID", commonFunctions.ValidateParameter(BLO_GRP_ID));
            cmd.Parameters.AddWithValue("@EMP_FTH_NAME", EMP_FTH_NAME);
            cmd.Parameters.AddWithValue("@EMP_MTH_NAME", commonFunctions.ValidateParameter(EMP_MTH_NAME));
            cmd.Parameters.AddWithValue("@NEXT_KIN_ID", NEXT_KIN_ID);
            cmd.Parameters.AddWithValue("@NEXT_KIN_NAME", NEXT_KIN_NAME);
            cmd.Parameters.AddWithValue("@SPOUSE_NAME", spouse_name);
            cmd.Parameters.AddWithValue("@IS_HAND_ID", commonFunctions.ValidateParameter(IS_HAND_ID));
            cmd.Parameters.AddWithValue("@PAN_NO", commonFunctions.ValidateParameter(PAN_NO));
            cmd.Parameters.AddWithValue("@ADHAR_NO", commonFunctions.ValidateParameter(ADHAR_NO));
            cmd.Parameters.AddWithValue("@MAR_STS_ID", commonFunctions.ValidateParameter(MAR_STS_ID));
            cmd.Parameters.AddWithValue("@INI_ID", INI_ID);
            cmd.Parameters.AddWithValue("@JOB_TYPE_ID", JOB_TYPE_ID);
            cmd.Parameters.AddWithValue("@SERV_TYPE_ID", SERV_TYPE_ID);
            cmd.Parameters.AddWithValue("@CAT_ID", CAT_ID);
            cmd.Parameters.AddWithValue("@DES_ID", DES_ID);
            cmd.Parameters.AddWithValue("@DEPT_ID", DEPT_ID);
            cmd.Parameters.AddWithValue("@EMP_NEXT_SNR_ID", commonFunctions.ValidateParameter(EMP_NEXT_SNR_ID));
            cmd.Parameters.AddWithValue("@TIME_ID", commonFunctions.ValidateParameter(Shift_Id));
            cmd.Parameters.AddWithValue("@ADD_DATA", commonFunctions.ValidateParameter(ADD_DATA));
            cmd.Parameters.AddWithValue("@PHN_DATA", commonFunctions.ValidateParameter(PHN_DATA));
            cmd.Parameters.AddWithValue("@MAIL_DATA", commonFunctions.ValidateParameter(MAIL_DATA));
            cmd.Parameters.AddWithValue("@ACA_DATA", commonFunctions.ValidateParameter(ACA_DATA));
            cmd.Parameters.AddWithValue("@SALARY_DATA", commonFunctions.ValidateParameter(SALARY_DATA));
            cmd.Parameters.AddWithValue("@EXP_DATA", commonFunctions.ValidateParameter(EXP_DATA));
            if (commonFunctions.ValidateParameter(BANK_ID, CIT_ID, ACC_NO))
            {
                cmd.Parameters.AddWithValue("@BANK_ID", BANK_ID);
                cmd.Parameters.AddWithValue("@CIT_ID", CIT_ID);
                cmd.Parameters.AddWithValue("@ACC_NO", ACC_NO);
                cmd.Parameters.AddWithValue("@BRANCH_NAME", BRANCH_NAME);
                cmd.Parameters.AddWithValue("@BANK_ADD", BANK_ADD);
            }
            cmd.Parameters.AddWithValue("@EMP_CODE_TYPE_ID", emp_type);
            cmd.Parameters.AddWithValue("@CONTRACT_PRD", CONTRACT_PRD);
            cmd.Parameters.AddWithValue("@PROB_PRD", PROB_PRD);
            DataSet ds = databaseFunctions.GetDataSet(cmd);
            if (emp_id == "0")
            {
                return "Employee " + ds.Tables[0].Rows[0][0].ToString() + " inserted successfully";
            }
            else
                return "Employee " + ds.Tables[0].Rows[0][0].ToString() + " updated successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            cmd.Dispose();
        }
    }
    #endregion
    #region GET EMPLOYEE INFORMTION KEY VALUES
    public DataSet GetEmpKeyInformation(HRBAL ObjBal)
    {
        try
        {
            return ObjHrDal.GetEmpKeyInf(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region Update
    #region MAIN INFORMATION
    public string EmpMainInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmpMainInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region BANK INFORMATION
    public string EmpBankInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeeBankInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region OFFICIAL INFORMATION
    public string EmpOffInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeeOffInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region ADDRESS INFORMATION
    public string EmpAdrsInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeeAdrsInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region PHONE INFORMATION
    public string EmpPhneInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeePhneInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region MAIL INFORMATION
    public string EmpMailInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeeMailInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region QULIFICATION INFORMATION
    public string EmpACAInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeeACAInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region EXPERIENCE INFORMATION
    public string EmpEXPInfUpdate(HRBAL objBal)
    {
        try
        {
            ObjHrDal.EmployeeEXPInfUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion
    #endregion


    #region Employee Information Delete
    public string EmployeeInfoDelete(HRBAL objBal, int type)
    {
        string str = "";
        try
        {
            if (type == 7)
            {
                str = "UPDATE EMP_EXP_INF SET EXP_STS=0 WHERE EXP_ID=@KEY_ID";
            }
            ObjHrDal.EmployeeInfDelete(objBal, str);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }

    #endregion

    #region Organisation
    public DataSet OrganistionSelect()
    {
        SqlCommand cmd = new SqlCommand("EXP_ORG_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public string OrganisationModify(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "EXP_ORG_INF_MODIFY";
            cmd.CommandType = CommandType.StoredProcedure;
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            cmd.Parameters.AddWithValue("@ORG_ID", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@ORG_STS", ObjBal.ChangeStatus);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

    public string OrganizationInsert(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == null)
            {
                ObjHrDal.OrganizationInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.OrginizationModify(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }


        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

    #endregion
    #endregion
    #region other
    #region EMPLOYEE
    #region SINGLE EMPLOYEE SINGLE INF INSERT
    public void EmpSingleInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeSingleInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region SINGLE ALL INF INSERT
    public void EmpSingleAllInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeSingleAll(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region MULTIPLE INSERT
    public void EmpeMultiInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeMultiInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region MULTIPLE ALL INSERT
    public void EmpeMultiAllCurrentInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeMultiAllCurrent(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region STATUS CHANGE
    public void EmployeeStatusValueInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeStatusValue(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region ACCOUNT CHANGE
    public void EmpAccountChangeInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeChangeAccount(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion


    #region ROLE INSERT
    public void EmployeeRoleInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeRoleInfo(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region RELIEVING INSERT
    public void EmployeeRelievingInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeRelievingInfoInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region NOT COUNT
    public void EmployeeNotCountInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeNotCountFunction(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region MARTIAL STATUS CHANGE
    public void EmployeeMarksSectionInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeMarksSectionFunction(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region EXPERIENCE INSERT
    public void EmployeeExperienceInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeExpFunction(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region INSTITUTE CHANGE
    public void EmployeeChangeInstituteInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeChangeInstituteFunction(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region DESIGNATION CHANGE
    public void EmployeeDEsgChangeInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeDesignationChangeFunction(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    # region DEPARTMENT CHANGE
    public void ChangeEmplDepartmentInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.ChangeEmployeeInfo(ObjBal);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    # endregion
    #region PASSWORD
    #region INSERT
    public void EmployeePasswordInfoInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeePasswordFunction(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion
    #region PHONE
    public void EmployeePhoneChangeInfo(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeePhoneChangeInfo(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #endregion

    #region ADDRESS TYPE INSERT
    public void AddressTypeInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.AddressTypeFunction(ObjBal);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region BANK INSERT
    public void BankValueInsert(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.BankValueFunction(ObjBal);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ObjHrDal = null;
        }

    }
    #endregion



    #region CITY INSERT
    public void CityValueInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.CityValueFunction(ObjBal);
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion
    #endregion
    #region BP
    #region UNIVESITY INSTITUTE INFORMATION
    #region  INSERT & UPDATE
    public string UnivInsInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.UniversityInsInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.UnivInsInfUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region SELECT
    public DataSet UnivInsInfSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UNIV_INS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region MODIFY
    public string UnivInsInfModify(HRBAL ObjBal)
    {
        try
        {

            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.UnivInsInfModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region Institution Head
    public DataSet UnivHeadSelect()
    {

        cmd = new SqlCommand();
        cmd.CommandText = "UNIV_INS_HEAD_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string UnivInsHeadInsert(HRBAL ObjBal)
    {
        try
        {

            ObjHrDal.UnivInsHeadInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion

    #region ACADAMIC INFORMATION
    #region INSERT & UPDATE
    public string AcademicBaseInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.AcademicBaseInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.AcaBaseUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }
    #endregion
    #region SELECT
    public DataSet AcaBaseInfSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BASE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region MODIFY
    public string AcaBaseModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.AcaBaseModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion
    #region ACADAMIC SECTION INFORMATION
    #region ACADMIC SECTION INFORMATION SELECT
    public DataSet AcaSecInfSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SEC_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region ACADMIC SECTION INFORMATION INSERT
    public void AcaSecInfInsert(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.AcaSecInfInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region ACADMIC SECTION INFORMATION UPDATE
    public void AcaSecInfUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.AcaSecInfUpdate(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region ACADMIC SECTION INFORMATION MODIFY
    public void AcaSecInfModify(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.AcaSecInfModify(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion



    #region PAGE
    #region PAGE SELECT
    public DataSet PageInfSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PAGE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region PAGE MODIFY
    public string PageInfModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.PageInfModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }
    #endregion

    #region  PAGE INSERT & UPDATE
    public string PageInfInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.PageInfInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.PageInfUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }
    #endregion

    #region PAGE HEAD SELECT
    public DataSet PageHeadInfSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PAGE_HEAD_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region PAGE HEAD MODIFY
    public string PageHeadInfModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.PageHeadInfModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }

    #endregion

    #region PAGE HEAD INSERT & UPDATE
    public string PageHeadInfInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.PageHeadInfInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.PageHeadInfUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }
    #endregion

    #region PAGE SUBHEAD SELECT
    public DataSet PageSubHeadSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PAGE_SUB_HEAD_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region PAGE SUBHEAD INSERT & UPDATE
    public string PageSubHeadInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.PageSubHeadInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.PageSubHeadUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }
    #endregion

    #region PAGE SUBHEAD MODIFY
    public string PageSubHeadModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.PageSubHeadModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }

    #endregion


    #endregion

    #region GUEST
    #region GUEST SELECT
    public DataSet GuestSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GUEST_USR_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region GUEST INSERT
    public void GuestInsert(HRBAL objGuest)
    {
        try
        {
            ObjHrDal.GuestInsert(objGuest);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion

    #region DEPARTMENT SHIFT MAPPING
    #region SELECT
    public DataSet DeptShiftMapSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEPT_SHIFT_MAP_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region UPDATE
    public void DeptShiftMapUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.DeptShiftMapUpdate(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #region MODIFY
    public string DeptShiftMapModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.DeptShiftMapModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #region INSERT
    public string DepatShiftMapInsert(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.DeptShiftMapInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.DeptShiftMapUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion
    #endregion

    #region EMPLOYEE ID CARD
    #region SELECT
    public DataTable IDCardSelect()
    {
        cmd = new SqlCommand("SELECT ACA_BASE_ID,ACA_BASE_SHORT_NAME,ACA_BASE_FULL_NAME,ACA_BASE_DESC,ACA_BASE_STATUS,ACA_BASE_PRP FROM ACA_BASE_INF");
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion
    #endregion

    #region EMPLPOYEE EPF

    #region INSERT INTO EPF MAIN
    public string EmpPFMain(HRBAL obj)
    {
        try
        {
            return ObjHrDal.EmpPFMainInsert(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region PF INFORMATION SHOW FOR UPDATE
    public DataSet EmpPFInfShow(HRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_INF_DISPLAY";
        cmd.Parameters.AddWithValue("@EMP_ID", obj.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region PF SHOW OLD INFORMATION
    public DataSet EmpPFOlD(HRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_OLD_INF";
        cmd.Parameters.AddWithValue("@EMP_ID", obj.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region PF ACTIVATE ACCOUNT
    public void EmpPFAccActivate(HRBAL obj)
    {
        try
        {
            ObjHrDal.EmpPFActiveAcc(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region PF CLOSE ACCOUNT
    public void EmpPFCloseAcc(HRBAL obj)
    {
        try
        {
            ObjHrDal.EmpPFCloseAcc(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region PF BASIC INFORMATION UPDATE
    public void EmpPFUpdate(HRBAL obj)
    {
        try
        {
            ObjHrDal.EmpPFInfUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region PF BENIFIT INFORMATION
    public DataSet EmpPFBenifit(HRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_BENIFIT_INF";
        cmd.Parameters.AddWithValue("@EMP_ID", obj.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DELETE FAMILY INFORMATION
    public DataSet DeleteFamilyDetails(HRBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_PF_FAMILY_INF_DELETE";
        cmd.Parameters.AddWithValue("@FMLY_ID", obj.CommonId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region SELECT FAMILY DETAILS
    public DataSet SelectFamilyDetails(HRBAL obj)
    {
        cmd = new SqlCommand("SELECT EMP_PF_FAMILY_INF.*,RELATION_INF.RELATION_NAME FROM EMP_PF_FAMILY_INF JOIN RELATION_INF ON EMP_PF_FAMILY_INF.RELATION_ID=RELATION_INF.RELATION_ID WHERE MEM_STS=1");
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region UPDTAE FAMILY DETAILS
    public DataSet UpdateFamilyDetails(HRBAL obj)
    {
        cmd = new SqlCommand("UPDATE EMP_PF_FAMILY_INF SET FMLY_MEM_NAME= '" + obj.Name + "', FMLY_MEM_ADRS= '" + obj.FullName + "', FMLY_MEM_DOB= '" + obj.Date + "',RELATION_ID = " + obj.CommonId + " WHERE FMLY_ID = " + obj.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DELETE NOMINEE DETAILS
    public DataSet DeleteNomineeDetails(HRBAL obj)
    {
        cmd = new SqlCommand("UPDATE EMP_PF_NOMINEE_INF SET NOMI_STS=0 WHERE NOMI_ID= " + obj.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region SELECT NOMINEE DETAILS
    public DataSet SelectNomineeDetails(HRBAL obj)
    {
        cmd = new SqlCommand("SELECT EMP_PF_NOMINEE_INF.*,RELATION_INF.RELATION_NAME FROM EMP_PF_NOMINEE_INF JOIN RELATION_INF ON EMP_PF_NOMINEE_INF.RELATION_ID=RELATION_INF.RELATION_ID WHERE NOMI_STS=1");
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region UPDTAE NOMINEE DETAILS
    public DataSet UpdateNomineeDetails(HRBAL obj)
    {
        cmd = new SqlCommand("UPDATE EMP_PF_NOMINEE_INF SET NOMI_NAME= '" + obj.Name + "', NOMI_ADRS= '" + obj.FullName + "', NOMI_DOB= '" + obj.Date + "', NOMI_BENIFIT = " + obj.KeyValue + ",RELATION_ID = " + obj.CommonId + " WHERE NOMI_ID = " + obj.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion


    #region SHIFT CHANGE SELECT
    public DataSet EmployeeShiftChangeSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_SHIFT_CNG_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        ObjBal.EmpId = (ObjBal.EmpId == "") ? "0" : ObjBal.EmpId;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetEmployeeShiftChange(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_EMP_SHIFT");
        cmd.CommandType = CommandType.StoredProcedure;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        ObjBal.Max = (ObjBal.Max == null) ? "" : ObjBal.Max;
        ObjBal.Min = (ObjBal.Min == null) ? "" : ObjBal.Min;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@TIME_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Min);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.Max);
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion
    #region SHIFT CHANGE INSERT
    public void EmployeeShiftChangeInsertUpdate(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeShiftChangeInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }

    }
    #endregion

    #region NEW REGION

    #region SCHEME
    #region SCHEME INFORMATION INSERT
    public string SchemeInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.SchemeInfInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.SchemeInfUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region SCHEME INFORMATION SELECT
    public DataSet SchemeInfSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SCHEME_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region SCHEME INFORMATION MODIFY
    public string SchemeInfModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.SchemeInfModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion

    #region RELATION
    #region RELATION INFORMATION INSERT
    public string RelationInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.RelationInfInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.RelationInfUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region RELATION INFORMATION SELECT
    public DataSet RelationInfSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "RELATION_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region RELATION INFORMATION MODIFY
    public string RelationInfModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.RelationInfModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion

    #region DEDUCTION
    #region DEDUCTION INFORMATION INSERT
    public string DeductionInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.DeductionInfInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.DeductionInfUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion

    #region DEDUCTION INFORMATION SELECT
    public DataSet DeductionInfSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEDUCTION_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region DEDUCTION INFORMATION MODIFY
    public string DeductionInfModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.DeductionInfModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion



    #endregion
    #endregion
    #region RAVI
    #region WARNING MASTER
    #region Warning Master Select

    public DataSet WarningSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WARNING_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Warning Insert
    public void WarningInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.WarningInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }

    #endregion

    #region Warning Update
    public void WarningUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.WarningUpdate(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #region Warning Modify
    public void WarningModify(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.WarningModify(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    public string WarnignIsNull(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WARNING_NULL_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetSingleData(cmd);
    }

    #endregion

    #region SERVICE
    #region SERVICE TYPE INSERT & UPDATE
    public string ServiceTypeInsert(HRBAL ObjBal)
    {

        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.ServiceTypeInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.ServiceTypeUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion
    #region SERVICE TYPE CHANGE
    public void EmployeeServiceChangeTypeInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmployeeServiceChange(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region SERVICE SELECT
    public DataSet ServiceTypeSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SERV_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion
    #region SERVICE MODIFY
    public string ServiceTypeModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.ServiceTypeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }

    #endregion
    #endregion
    #region CASTE
    #region SELECT
    public DataSet CasteSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "CAS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region CASTE INSERT & UPDATE
    public string CasteInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.CasteInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.CasteUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }


    #endregion
    #region MODIFY
    public string CasteModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.CasteModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion
    #region SHIFT MASTER
    #region Shift Insert & Update
    public string ShiftInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.ShiftInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.ShiftUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion
    #region Shift Select
    public DataSet ShiftSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SHIFT_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion

    #region Shift MODIFY
    public string ShiftModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.ShiftModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region Shift Time Select
    public DataSet ShiftTimeSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SHIFT_TIME_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SHIFT_ID", ObjBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Shift TIME INSERT
    public string ShiftTimeInsert(HRBAL ObjBal)
    {
        try
        {

            ObjHrDal.ShiftTimeInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);


        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }

    }
    #endregion
    #region Shift Time Modify
    public string ShiftTimeModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.ShiftTimeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion





    #endregion
    #region CATEGORY
    public DataSet EmpCatSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_CAT_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #region INSERT
    public string EmpCatModify(HRBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.EmpCatModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    public string EmpCatInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.EmpCatInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.EmpCatUpadte(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion
    #region DOCUMENT MASTER
    #region Document Master Select
    public DataSet EmpDocTypeSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region  Document Insert
    public string EmpDocTypeInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.EmpDocTypeInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.EmpDocTypeUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion



    #region Document Modify
    public string EmpDocTypeModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.EmpDocTypeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #region Document Master Status Select
    public DataSet DocumentMasterStatus()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_STS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion

    #region  Document Master Status Insert
    public string DocumentMasterStatusInsert(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.DocumentMasterStatusInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.DocumentMasterStatusUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion


    #region DOcument MAster STatus MOdify
    public string DocumentMasterStatusModify(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.DocumentMasterStatusModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion


    #region Document MASTER DETAIL INSERT

    public DataSet DocumentMasterDetail()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_DETAIL_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion
    #region Designation Change
    #region Designation Change Select
    public DataSet EmpDesChangeSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DES_CNG_INF_SELECT";
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion


    #region Designation Change INSERT
    public string EmpDesChangeInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmpDesChangeInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion



    #endregion
    #region DOCUMENT UPLOAD
    #region Document Upload Insert
    public void DocumentUploadInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.DocumentUploadInsert(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region Document Upload Select
    public DataSet EmpDocUploadSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DOC_UPLD_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #endregion

    #region Report
    public DataSet EmployeeCount()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMPLOYEE_COUNT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DESIGNATION
    #region SELECT
    public DataSet DesignationSelect(HRBAL ObjBal)
    {
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        cmd = new SqlCommand();
        cmd.CommandText = "DES_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region INSERT & UPDATE
    public string DesignationInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.DesignationInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.DesignationUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }

    }
    #endregion
    #region MODIFY
    public string DesignationModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.DesignationModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #endregion
    #region DEPARTMENT
    #region SELECT
    public DataSet DepartmentSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        cmd.CommandText = "INS_DEPT_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region INSERT & UPDATE
    public string DepartmentInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.DepartmentInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.DepartmentUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region MODIFY
    public string DepartmentModify(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.DepartmentModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region HEAD CHANGE
    //public DataSet DepartmentSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
    //    cmd.CommandText = "INS_DEPT_INF_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
    //    return databaseFunctions.GetDataSet(cmd);
    //}
    #endregion
    #endregion
    #region Employee Status Change


    #region Deaprtment Change Select

    public DataSet EmpDeptCngSelect(HRBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_DEPT_CNG_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Employee Status Change Insert
    public string EmpStatusCngInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmpStatusCngInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); ; }
        finally
        { ObjHrDal = null; }
    }
    #endregion


    #region Status Change Update
    public void EmpStatusCngUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpStatusCngUpdate(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion



    #region Status Modify
    public void StatusModify(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.StatusModify(ObjBal);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #endregion
    #region DEPARTMENT CHANGE
    #region Department Change Insert

    public string EmpDeptCngInsert(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmpDeptCngInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }
    }

    #endregion


    #region Deaprtment Change Select

    public DataSet EmpStatusCngSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_STS_CNG_ING_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion
    public DataSet GetContactSearch(HRBAL ObjBal)
    {
        ObjBal.DeptId = (ObjBal.DeptId == "") ? "." : ObjBal.DeptId;
        cmd = new SqlCommand();
        cmd.CommandText = "GET_CONTACT_SEARCH";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SEARCH_VALUE", ObjBal.Value1);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region PRIYA
    #region HOLIDAY
    #region HOLIDAY INSERT & UPDATE
    public string HolidayInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.HolidayInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.HolidayUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        { ObjHrDal = null; }
    }
    #endregion
    #region HOLIDAY SELECT
    public DataSet HolidaySelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "HOLIDAYS_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region HOLIDAY DELETE
    public string HolidayDelete(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.HolidayDelete(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        { ObjHrDal = null; }
    }
    #endregion

    #endregion

    #region WORKING DAY
    #region WORKING DAY select
    public DataSet WorkingDaySelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "WORKING_DAY_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region WORKING DAY INSERT
    public string WorkingDayInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.WorkingDayInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.WorkingDayUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjHrDal = null;
        }
    }
    #endregion
    public string EmpLeaveOpenForDoc(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "UPDATE EMP_LV_NOT_ELIGIBLE SET STS=0,TO_DT=GETDATE()"
                + " FROM EMP_LV_NOT_ELIGIBLE INNER JOIN USR_INF ON USR_INF.USR_ID=EMP_LV_NOT_ELIGIBLE.USR_ID"
                + " WHERE USR_LOGIN_ID=" + ObjBal.EmpId + " AND STS=3";
            cmd.CommandType = CommandType.Text;
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    #region WORKING DAY DELETE
    public string WorkingDayDelete(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.WorkingDayDelete(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjHrDal = null; }

    }
    #endregion
    #endregion

    #region Week Off
    #region Week Off Insert
    public string EmpWeekOffInsert(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpWeekOffInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    #endregion

    #region Week Off Select
    public DataSet EmpWeekOffSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WEEK_OFF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpWeekOffSelect(HRBAL ObjBal)
    {
        ObjBal.EmpId = (ObjBal.EmpId == "") ? "-1" : ObjBal.EmpId;
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_WEEK_OFF_SELECT";
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Week Off
    public string EmpWeekOffDisable(HRBAL ObjBal)
    {

        try
        {
            ObjHrDal.EmpWeekOffDisable(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Disable);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    #endregion
    #endregion



    public DataSet getRlvdEmp(HRBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.EmpId == "") ? "0" : ObjBal.EmpId;
        cmd = new SqlCommand("GET_EMP_RLVD");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string EmpRlvdInsert(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("EMP_RESIG_MAIN_INF_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
            cmd.Parameters.AddWithValue("@RLV_TYPE_ID", ObjBal.ChangeStatus);
            cmd.Parameters.AddWithValue("@REMARK", ObjBal.RemValue);
            cmd.Parameters.AddWithValue("@RESIG_DATE", ObjBal.ToDate);
            cmd.Parameters.AddWithValue("@RELVNG_DATE", ObjBal.FromDate);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string EmpRlvdUpdate(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("EMP_RLVD_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_RESIG_ID", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@RELVNG_DATE", ObjBal.ToDate);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return "Reliving Date of this employee successfully Modified.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    //#region LEAVE
    //#region Leave Application
    //public DataSet EmpLvEligible(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_ELIGIBLE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd);
    //}



    //public string EmpLvCheck(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvCheck(ObjBal);

    //}

    //public DataSet EmpLvDaySelect(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvDaySelect(ObjBal);
    //}
    //public DataTable EmpTTSelectForTT(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpTTSelectForTT(ObjBal);
    //}
    //public void EmplvAppInsert(HRBAL ObjBal)
    //{
    //    ObjHrDal.EmpLvAppInsert(ObjBal);
    //}

    //public string EmpLvAllowed(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "SELECT DBO.IS_LV_ALLOWED('" + ObjBal.FromDate.ToString("MM/dd/yyyy") + "','" + ObjBal.ToDate.ToString("MM/dd/yyyy") + "'," + ObjBal.EmpId + "," + ObjBal.TypeId + "," + ObjBal.ValueType + ")";
    //    return databaseFunctions.GetSingleData(cmd);

    //}

    //public SqlCommand EmpLvTypeSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_TYPE_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return cmd;
    //}

    //public DataTable EmpLvDetailSelect(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvDetailSelect(ObjBal);
    //}
    //#endregion

    //#region OnDuty
    //public string EmpOnDutyInsert(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        return ObjHrDal.EmpOnDutyInsert(ObjBal);
    //        //return Msg.GetMessage(Messages.DataMessType.Insert);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    //#endregion

    //#region Employee Leave Eligible
    //public void EmpLvNotEligibleInsert(HRBAL ObjBal)
    //{
    //    ObjHrDal.EmpLvNotEligibleInsert(ObjBal);
    //}

    //public DataSet EmpLvEligibleSelect()
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_NOT_ELIGIBLE_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public void EmpLvOpen(HRBAL obj)
    //{
    //    ObjHrDal.EmpLvOpen(obj);
    //}
    //#endregion

    //#region Compensatory Leave
    //public void EmpComLvCrdInsert(HRBAL ObjBal)
    //{
    //    ObjHrDal.EmpComLvCrdInsert(ObjBal);
    //}
    //public DataTable EmpComLvCrdCheck(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpComLvCrdCheck(ObjBal);
    //}
    //public DataTable EmpComLvDetailSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_COM_LV_CRD_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}
    //public DataTable ComCreditForRecommand()
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "COM_CREDIT_FOR_RECOMMAND";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public DataTable ComCreditForApprove(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "COM_CREDIT_FOR_APPROVE";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    //public string ComLvCrdRecommanded(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.ComLvCrdRecommanded(ObjBal);
    //        if (ObjBal.ChangeStatus == "0")
    //            return Msg.GetMessage(Messages.DataMessType.Reject);
    //        else
    //            return Msg.GetMessage(Messages.DataMessType.Recommand);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }

    //}
    //public DataTable AttForCom(HRBAL ObjBal)
    //{
    //    return ObjHrDal.AttForCom(ObjBal);
    //}

    //public string ComLvCrdApproved(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.ComLvCrdApproved(ObjBal);
    //        if (ObjBal.ChangeStatus == "0")
    //            return Msg.GetMessage(Messages.DataMessType.Reject);
    //        else
    //            return Msg.GetMessage(Messages.DataMessType.Approve);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }

    //}
    //public SqlCommand LvAppAuthSelect()
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "GET_LEAVE_APP_AUTHORITY";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    return cmd;
    //}
    //#endregion

    //#region Short Leave
    //public string EmpSLCheck(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_SL_CHECK";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
    //    return databaseFunctions.GetSingleData(cmd);
    //}
    //#endregion

    //#region Leave Approval
    //public DataSet EmpLvApprvlSelect(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "EMP_LV_FOR_APPRVL_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@PROC_TYPE_ID", ObjBal.ValueType);
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public void EmpLvArvCan(HRBAL obj)
    //{
    //    ObjHrDal.EmpLvArvCan(obj);
    //}

    //public DataSet EmpLvApprvlDetailSelect(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvApprvlDetailSelect(ObjBal);
    //}

    //public void EmpLvRecommend(HRBAL obj)
    //{
    //    ObjHrDal.EmpLvRecommend(obj);
    //}

    //public string[] BtnSelect(HRBAL ObjBal)
    //{
    //    //emp-apply, leaveCode- lvtype
    //    string[] data = new string[2];
    //    DataTable dt = ObjHrDal.BtnSelect(ObjBal);

    //    string Teach = dt.Rows[0][0].ToString();
    //    string APRVL = dt.Rows[0][1].ToString();
    //    string HOI = dt.Rows[0][2].ToString();
    //    string HOD = dt.Rows[0][3].ToString();
    //    string VC = dt.Rows[0][4].ToString();
    //    string AUTH = dt.Rows[0][5].ToString();

    //    //data[0]- button select (approve or recommand)
    //    //data[1]- forword to role id
    //    if (APRVL == "1")
    //    {
    //        data[1] = "0";
    //        data[0] = "1";
    //    }

    //    else if (APRVL == "0")
    //    {
    //        if (HOI == ObjBal.SessionUserID)
    //            data[1] = AUTH;

    //        else if (HOD == ObjBal.SessionUserID)
    //        {
    //            if (Teach == "1")
    //                data[1] = "3";
    //            else
    //                data[1] = AUTH;
    //        }
    //        else
    //            data[1] = "2";
    //        data[0] = "0";
    //    }

    //    else
    //    {
    //        if (VC == ObjBal.SessionUserID || HOI == ObjBal.SessionUserID)
    //        {
    //            data[0] = "1";
    //            data[1] = "0";
    //        }

    //        else if (HOD == ObjBal.SessionUserID)
    //        {
    //            if (Teach == "1")
    //            {
    //                data[0] = "0";
    //                data[1] = "3";
    //            }
    //            else
    //            {
    //                data[0] = "1";
    //                data[1] = "0";
    //            }
    //        }
    //        else
    //        {
    //            data[0] = "0";
    //            data[1] = "2";
    //        }
    //    }
    //    return data;
    //}
    //#endregion

    //#region Leave Master
    //public DataSet LeaveMainSelect()
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "LV_TYPE_INF_SELECT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public string LeaveMainInsertUpdate(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        if (ObjBal.KeyID == "")
    //        {
    //            ObjHrDal.LeaveMainInsert(ObjBal);
    //            return Msg.GetMessage(Messages.DataMessType.Insert);
    //        }
    //        else
    //        {
    //            ObjHrDal.LeaveMainUpdate(ObjBal);
    //            return Msg.GetMessage(Messages.DataMessType.Update);
    //        }

    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    //public string LeaveMainDelete(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
    //        ObjHrDal.LeaveMainDelete(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Status);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    //#endregion

    //#region Leave Arrangment
    //public DataTable EmpLvArrSelect(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvArrSelect(ObjBal);
    //}

    //public DataTable EmpLvArrReportSelect(HRBAL ObjBal)
    //{
    //    string str = "SELECT EMP_MAIN_INF.EMP_NAME, INS_DEPT_INF.DEPT_VALUE, DES_INF.DES_VALUE, EMP_LV_APP_INF.FROM_DT, EMP_LV_APP_INF.TO_DT, EMP_LV_APP_INF.IN_DT, EMP_LV_ARR_INF.ARR_REMARK, "
    //        + " EMP_LV_APP_INF.LV_APP_ID, EMP_PHN_CNG_INF.PHN_NO, EMP_LV_ARR_INF.LV_ARR_ID FROM  EMP_DEPT_CNG_INF INNER JOIN EMP_MAIN_INF ON "
    //        + " EMP_DEPT_CNG_INF.EMP_ID = EMP_MAIN_INF.EMP_ID INNER JOIN EMP_LV_ARR_INF INNER JOIN EMP_LV_APP_INF ON EMP_LV_ARR_INF.LV_APP_ID = EMP_LV_APP_INF.LV_APP_ID "
    //        + " ON EMP_DEPT_CNG_INF.TO_DATE IS NULL INNER JOIN EMP_DES_CNG_INF ON EMP_MAIN_INF.EMP_ID = EMP_DES_CNG_INF.EMP_ID AND EMP_DES_CNG_INF.TO_DATE IS NULL INNER JOIN "
    //        + " INS_DEPT_INF ON EMP_DEPT_CNG_INF.DEPT_ID = INS_DEPT_INF.DEPT_ID INNER JOIN DES_INF ON EMP_DES_CNG_INF.DES_ID = DES_INF.DES_ID INNER JOIN "
    //        + " EMP_PHN_CNG_INF ON EMP_MAIN_INF.EMP_ID = EMP_PHN_CNG_INF.EMP_ID AND EMP_PHN_CNG_INF.TO_DATE IS NULL INNER JOIN USR_INF ON "
    //        + " EMP_LV_APP_INF.USR_ID = USR_INF.USR_ID AND EMP_MAIN_INF.EMP_ID = USR_INF.USR_LOGIN_ID WHERE (EMP_LV_ARR_INF.STS_ID = - 1) AND ARR_WITH=" + ObjBal.SessionUserID;
    //    str += " AND YEAR(EMP_LV_APP_INF.FROM_DT)=" + ObjBal.Year;
    //    if (ObjBal.Name != null)
    //        str += " AND EMP_MAIN_INF.EMP_NAME=" + ObjBal.Name;
    //    if (ObjBal.DeptId != null)
    //        str += " AND EMP_DEPT_CNG_INF.DEPT_ID=" + ObjBal.DeptId;
    //    if ((ObjBal.FromDate.ToString() != "01/01/0001 00:00:00" && ObjBal.FromDate.ToString() != null) && (ObjBal.ToDate.ToString() != "01/01/0001 00:00:00" && ObjBal.ToDate.ToString() != null))
    //        str += " AND EMP_LV_APP_INF.FROM_DT BETWEEN '" + ObjBal.FromDate + "' AND '" + ObjBal.ToDate + "'";
    //    str += " ORDER BY ACTION_DT DESC";
    //    cmd = new SqlCommand(str);
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //    //return ObjHrDal.EmpLvArrReportSelect(ObjBal);
    //}

    //public DataTable TTatLvDate(HRBAL ObjBal)
    //{
    //    return ObjHrDal.TTatLvDate(ObjBal);
    //}

    //public string EmpLvArrAction(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.EmpLvArrAction(ObjBal);
    //        if (ObjBal.ChangeStatus == "0")
    //            return Msg.GetMessage(Messages.DataMessType.Reject);
    //        else
    //            return Msg.GetMessage(Messages.DataMessType.Accept);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}

    //public DataTable EmpLvArrRejected(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvArrRejected(ObjBal);
    //}

    //public DataTable EmpLvReArrSelect(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvReArrSelect(ObjBal);
    //}

    //public string EmpLvReArrInsert(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.EmpLvReArrInsert(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Insert);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    ////public DataSet EmpLvArrReportDetail(HRBAL ObjBal)
    ////{

    ////    return databaseFunctions.GetDataSet(cmd);
    ////}
    //#endregion

    //#region Leave Cancellation
    //public DataTable EmpLvCancelSelect(HRBAL ObjBal)
    //{
    //    return ObjHrDal.EmpLvCancelSelect(ObjBal);
    //}
    //public string EmpLvCancelApply(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.EmpLvCancelApply(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Forward);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    //#endregion

    //#region Leave Report
    //public string LeaveBalanceInsert(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.LeaveBalanceInsert(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Insert);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}

    //public DataSet GetLeaveBalance(HRBAL ObjBal)
    //{
    //    return ObjHrDal.GetLeaveBalance(ObjBal);
    //}

    //public DataSet GetLvBalTran(HRBAL ObjBal)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandText = "SELECT EMP_LV_BAL_TRN_INF.CR_BAL, EMP_LV_BAL_TRN_INF.CR_DATE, EMP_LV_BAL_TRN_INF.CR_REM "
    //        + "FROM  EMP_LV_BAL_TRN_INF INNER JOIN USR_INF ON EMP_LV_BAL_TRN_INF.USR_ID = USR_INF.USR_ID "
    //        + "WHERE USR_LOGIN_ID=" + ObjBal.EmpId + " AND LV_ID='" + ObjBal.Code + "' AND CR_YEAR='" + ObjBal.Year + "' ORDER BY CR_DATE";
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public string LeaveBalanceDelete(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.LeaveBalanceDelete(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Deleted);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    //public string LeaveAppUpdate(HRBAL ObjBal)
    //{
    //    try
    //    {
    //        ObjHrDal.LeaveAppUpdate(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Update);
    //    }
    //    catch
    //    { return Msg.GetMessage(Messages.DataMessType.Error); }
    //}
    //#endregion
    //#endregion

    #region LEAVE
    #region Leave Application
    public DataSet EmpLvEligible(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_ELIGIBLE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }

    //public DataTable MonthAttCheck(HRBAL obj)
    //{
    //    cmd = new SqlCommand("SELECT * FROM EMP_ATT_CNT_INF C JOIN MONTH_ATT_MAIN_INF M ON C.ATT_MAIN_ID=M.ATT_MAIN_ID WHERE EMP_ID=" + 1105 + " AND ATT_MONTH=MONTH('" + obj.FromDate + "') AND ATT_YEAR=YEAR('" + obj.FromDate + "')");
    //    return databaseFunctions.GetDataSet(cmd).Tables[0];
    //}

    public string EmpLvCheck(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvCheck(ObjBal);
        //return "1";
    }

    public DataSet EmpLvDaySelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvDaySelect(ObjBal);
    }
    public DataTable EmpTTSelectForTT(HRBAL ObjBal)
    {
        return ObjHrDal.EmpTTSelectForTT(ObjBal);
    }
    public string EmplvAppInsert(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvAppInsert(ObjBal);
    }
    public void EmplvAppInsertForHR(HRBAL ObjBal)
    {
        ObjHrDal.EmpLvAppInsertForHR(ObjBal);
    }

    public string EmpLvAllowed(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT DBO.IS_LV_ALLOWED('" + ObjBal.FromDate.ToString("MM/dd/yyyy") + "','" + ObjBal.ToDate.ToString("MM/dd/yyyy") + "'," + ObjBal.EmpId + "," + ObjBal.TypeId + "," + ObjBal.ValueType + ")";
        return databaseFunctions.GetSingleData(cmd);
        //return "1";
    }

    public SqlCommand EmpLvTypeSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_TYPE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return cmd;
    }

    public DataTable EmpLvDetailSelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvDetailSelect(ObjBal);
    }

    public void EmpLvDocInsert(HRBAL ObjBal)
    {
        ObjHrDal.EmpLvDocInsert(ObjBal);
    }
    #endregion

    #region OnDuty
    public string EmpOnDutyInsert(HRBAL ObjBal)
    {
        try
        {
            return ObjHrDal.EmpOnDutyInsert(ObjBal);
            //return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    #endregion

    #region Employee Leave Eligible
    public void EmpLvNotEligibleInsert(HRBAL ObjBal)
    {
        ObjHrDal.EmpLvNotEligibleInsert(ObjBal);
    }

    public DataSet EmpLvEligibleSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_NOT_ELIGIBLE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public void EmpLvOpen(HRBAL obj)
    {
        ObjHrDal.EmpLvOpen(obj);
    }
    #endregion

    #region Compensatory Leave
    public void EmpComLvCrdInsert(HRBAL ObjBal)
    {
        ObjHrDal.EmpComLvCrdInsert(ObjBal);
    }
    public DataTable EmpComLvCrdCheck(HRBAL ObjBal)
    {
        return ObjHrDal.EmpComLvCrdCheck(ObjBal);
    }

    public string[] Com_Btn_Select(HRBAL ObjBal)
    {
        string[] data = new string[2];
        cmd = new SqlCommand("COM_LV_CR_ACTION_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        DataTable dt = databaseFunctions.GetDataSet(cmd).Tables[0];
        string JOB_TYP = dt.Rows[0][4].ToString();
        string NS = dt.Rows[0][3].ToString();
        string HOI = dt.Rows[0][0].ToString();
        string HOD = dt.Rows[0][1].ToString();
        if (ObjBal.EmpId != null)
        {
            ObjBal.SessionUserID = ObjBal.EmpId;
        }
        if (JOB_TYP == "0")
        {
            data[0] = "1";
            data[1] = "0";
            if (ObjBal.SessionUserID == NS)
            {
                data[0] = "2";//action to
                data[1] = "1";//button 1 for approval and 0 for reccomend
            }
            if (ObjBal.SessionUserID == HOD)
            {
                data[0] = "1";
                data[1] = "1";
            }
            if ((ObjBal.SessionUserID != NS) && (NS == HOD))
            {
                data[0] = "2";//action to
                data[1] = "1";//button 1 for approval and 0 for reccomend
            }


        }
        else if (JOB_TYP == "1")
        {
            data[0] = "1";
            data[1] = "0";
            if (ObjBal.SessionUserID == NS)
            {
                data[0] = "2";
                data[1] = "0";
            }
            if (ObjBal.SessionUserID == HOD)
            {
                data[0] = "3";
                data[1] = "1";
            }
            if ((ObjBal.SessionUserID != NS) && (NS == HOD))
            {
                data[0] = "2";
                data[1] = "0";
            }
            if ((ObjBal.SessionUserID != HOD) && (HOD == HOI))
            {
                data[0] = "3";
                data[1] = "1";
            }

        }
        return data;
    }

    public DataTable EmpComLvDetailSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_COM_LV_CRD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable ComCreditForRecommand()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "COM_CREDIT_FOR_RECOMMAND";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable ComCreditForApprove(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "COM_CREDIT_FOR_APPROVE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public string ComLvCrdRecommanded(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.ComLvCrdRecommanded(ObjBal);
            if (ObjBal.ChangeStatus == "0")
                return Msg.GetMessage(Messages.DataMessType.Reject);
            else
                return Msg.GetMessage(Messages.DataMessType.Recommand);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }

    }

    public DataTable AttForCom(HRBAL ObjBal)
    {
        return ObjHrDal.AttForCom(ObjBal);
    }

    public string ComLvCrdApproved(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.ComLvCrdApproved(ObjBal);
            if (ObjBal.ChangeStatus == "0")
                return Msg.GetMessage(Messages.DataMessType.Reject);
            else if (ObjBal.ChangeStatus == "1")
                return Msg.GetMessage(Messages.DataMessType.Recommand);
            else
                return Msg.GetMessage(Messages.DataMessType.Approve);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }

    }
    public SqlCommand LvAppAuthSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_LEAVE_APP_AUTHORITY";
        cmd.CommandType = CommandType.StoredProcedure;
        return cmd;
    }
    public void EmpComCrdByHR(HRBAL ObjBal)
    {
        ObjHrDal.EmpComCrdByHR(ObjBal);
    }
    public DataTable EmpLvDocToUploadSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_DOC_TO_UPLOAD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion

    #region Short Leave
    public string EmpSLCheck(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_SL_CHECK";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion

    #region Leave Approval
    public DataSet EmpLvApprvlSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_LV_FOR_APPRVL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@PROC_TYPE_ID", ObjBal.ValueType);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void EmpLvArvCan(HRBAL obj)
    {
        ObjHrDal.EmpLvArvCan(obj);
    }

    public DataSet EmpLvApprvlDetailSelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvApprvlDetailSelect(ObjBal);
    }

    public void EmpLvRecommend(HRBAL obj)
    {
        ObjHrDal.EmpLvRecommend(obj);
    }

    public string[] BtnSelect(HRBAL ObjBal)
    {
        //emp-apply, leaveCode- lvtype
        string[] data = new string[2];
        DataTable dt = ObjHrDal.BtnSelect(ObjBal);
        string Teach = dt.Rows[0][0].ToString();
        string APRVL = dt.Rows[0][1].ToString();
        string HOI = dt.Rows[0][2].ToString();
        string HOD = dt.Rows[0][3].ToString();
        string VC = dt.Rows[0][4].ToString();
        string AUTH = dt.Rows[0][5].ToString();
        string INS = dt.Rows[0][6].ToString();
        string HR = dt.Rows[0][7].ToString();
        string Registrar = dt.Rows[0][8].ToString();
        string ProVC = dt.Rows[0][9].ToString();
        decimal total = Convert.ToDecimal(ObjBal.Total);
        if ((APRVL == "1") || (VC == ObjBal.SessionUserID) || (ProVC == ObjBal.SessionUserID))
        {
            data[0] = "1";
            data[1] = "0";
        }
        else if ((APRVL == "1") || (Registrar == ObjBal.SessionUserID))
        {
            data[0] = "1";
            data[1] = "0";
        }
        else if (APRVL == "0")
        {
            //Academic Leave
            if (ObjBal.TypeId == "1")
            {
                if (HR == ObjBal.SessionUserID)
                {
                    data[1] = AUTH;
                }
                else if (HOI == ObjBal.SessionUserID)
                {
                    data[1] = AUTH;
                    if (ObjBal.TypeId == "1")
                        data[1] = "62";
                }
                else if (HOD == ObjBal.SessionUserID)
                {
                    /*changed by harshita(if days <=3)*/
                    //if (Teach == "1")
                    //    data[1] = "3";
                    if (Teach == "1")
                    {
                        if (total > 3)
                            data[1] = "3";
                        else
                            data[1] = AUTH;
                    }
                    else
                    {
                        data[1] = AUTH;
                        if (ObjBal.TypeId == "1")
                            data[1] = "62";
                    }
                    ////Harshita(FOR IBMER)
                    if (INS == "1")
                    {
                        data[1] = AUTH;
                        if (ObjBal.TypeId == "1")
                            data[1] = "62";
                    }
                    //Harshita

                }
                else
                    data[1] = "2";
                data[0] = "0";
            }
            //Academic Leave
            else
            {
                if (HOI == ObjBal.SessionUserID)
                {
                    data[1] = AUTH;
                    if (ObjBal.TypeId == "1")
                        data[1] = "62";
                }
                else if (HOD == ObjBal.SessionUserID)
                {
                    /*changed by harshita(if days <=3)*/
                    //if (Teach == "1")
                    //    data[1] = "3";
                    if (Teach == "1")
                    {
                        if (total > 3)
                            data[1] = "3";
                        else
                            data[1] = AUTH;
                    }
                    else
                    {
                        data[1] = AUTH;
                        if (ObjBal.TypeId == "1")
                            data[1] = "62";
                    }
                    //Harshita(FOR IBMER)
                    if (INS == "1")
                    {
                        data[1] = AUTH;
                        if (ObjBal.TypeId == "1")
                            data[1] = "62";
                    }
                    //Harshita

                }
                else
                    data[1] = "2";
                data[0] = "0";
            }
        }
        else
        {
            if (VC == ObjBal.SessionUserID || HOI == ObjBal.SessionUserID)
            {
                data[0] = "1";
                data[1] = "0";
            }

            else if (HOD == ObjBal.SessionUserID)
            {

                if (Teach == "1")
                {
                    /*changed by harshita(if days <=3)*/
                    //data[0] = "0";
                    //data[1] = "3";
                    if (total > 3)
                    {
                        data[0] = "0";
                        data[1] = "3";
                    }
                    else
                    {
                        data[0] = "1";
                        data[1] = "0";
                    }
                }

                else
                {
                    data[0] = "1";
                    data[1] = "0";
                }

                //Harshita(FOR IBMER)
                if (INS == "1")
                {
                    data[0] = "1";
                    data[1] = "0";
                }
                //Harshita
            }
            else
            {
                data[0] = "0";
                data[1] = "2";
            }
        }
        return data;
    }
    #endregion

    #region Leave Master
    public DataSet LeaveMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "LV_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public string LeaveMainInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.LeaveMainInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.LeaveMainUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    public string LeaveMainDelete(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ObjHrDal.LeaveMainDelete(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    #endregion

    #region Leave Arrangment
    public DataTable EmpLvArrSelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvArrSelect(ObjBal);
    }

    public DataTable EmpLvArrReportSelect(HRBAL ObjBal)
    {
        string str = "SELECT EMP_MAIN_INF.EMP_NAME, INS_DEPT_INF.DEPT_VALUE, DES_INF.DES_VALUE, EMP_LV_APP_INF.FROM_DT, EMP_LV_APP_INF.TO_DT, EMP_LV_APP_INF.IN_DT, EMP_LV_ARR_INF.ARR_REMARK, "
            + " EMP_LV_APP_INF.LV_APP_ID, EMP_PHN_CNG_INF.PHN_NO, EMP_LV_ARR_INF.LV_ARR_ID FROM  EMP_DEPT_CNG_INF INNER JOIN EMP_MAIN_INF ON "
            + " EMP_DEPT_CNG_INF.EMP_ID = EMP_MAIN_INF.EMP_ID INNER JOIN EMP_LV_ARR_INF INNER JOIN EMP_LV_APP_INF ON EMP_LV_ARR_INF.LV_APP_ID = EMP_LV_APP_INF.LV_APP_ID "
            + " ON EMP_DEPT_CNG_INF.TO_DATE IS NULL INNER JOIN EMP_DES_CNG_INF ON EMP_MAIN_INF.EMP_ID = EMP_DES_CNG_INF.EMP_ID AND EMP_DES_CNG_INF.TO_DATE IS NULL INNER JOIN "
            + " INS_DEPT_INF ON EMP_DEPT_CNG_INF.DEPT_ID = INS_DEPT_INF.DEPT_ID INNER JOIN DES_INF ON EMP_DES_CNG_INF.DES_ID = DES_INF.DES_ID INNER JOIN "
            + " EMP_PHN_CNG_INF ON EMP_MAIN_INF.EMP_ID = EMP_PHN_CNG_INF.EMP_ID AND EMP_PHN_CNG_INF.TO_DATE IS NULL INNER JOIN USR_INF ON "
            + " EMP_LV_APP_INF.USR_ID = USR_INF.USR_ID AND EMP_MAIN_INF.EMP_ID = USR_INF.USR_LOGIN_ID WHERE (EMP_LV_ARR_INF.STS_ID = - 1) AND ARR_WITH=" + ObjBal.SessionUserID;
        str += " AND YEAR(EMP_LV_APP_INF.FROM_DT)=" + ObjBal.Year;
        if (ObjBal.Name != null)
            str += " AND EMP_MAIN_INF.EMP_NAME=" + ObjBal.Name;
        if (ObjBal.DeptId != null)
            str += " AND EMP_DEPT_CNG_INF.DEPT_ID=" + ObjBal.DeptId;
        //if ((ObjBal.FromDate.ToString() != "01/01/0001 00:00:00" || ObjBal.FromDate.ToString() != null) && (ObjBal.ToDate.ToString() != "01/01/0001 00:00:00" || ObjBal.ToDate.ToString() != null))
        //   
        if (ObjBal.KeyID != "0")
            str += " AND EMP_LV_APP_INF.FROM_DT BETWEEN CONVERT(VARCHAR,'" + ObjBal.FromDate + "',101) AND CONVERT(VARCHAR,'" + ObjBal.ToDate + "',101)";
        str += " ORDER BY ACTION_DT DESC";
        cmd = new SqlCommand(str);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
        //return ObjHrDal.EmpLvArrReportSelect(ObjBal);
    }

    public DataTable TTatLvDate(HRBAL ObjBal)
    {
        return ObjHrDal.TTatLvDate(ObjBal);
    }

    public string EmpLvArrAction(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpLvArrAction(ObjBal);
            if (ObjBal.ChangeStatus == "0")
                return Msg.GetMessage(Messages.DataMessType.Reject);
            else
                return Msg.GetMessage(Messages.DataMessType.Accept);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }

    public DataTable EmpLvArrRejected(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvArrRejected(ObjBal);
    }

    public DataTable EmpLvReArrSelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvReArrSelect(ObjBal);
    }

    public string EmpLvReArrInsert(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpLvReArrInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    //public DataSet EmpLvArrReportDetail(HRBAL ObjBal)
    //{

    //    return databaseFunctions.GetDataSet(cmd);
    //}
    #endregion

    #region Leave Cancellation
    public DataTable EmpLvCancelSelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvCancelSelect(ObjBal);
    }
    public DataTable EmpLvCancelSelectForHR(HRBAL ObjBal)
    {
        return ObjHrDal.EmpLvCancelSelectForHR(ObjBal);
    }
    public string EmpLvCancelApply(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpLvCancelApply(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Forward);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }

    public string EmpLvCancelByHR(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpLvCancelByHR(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Forward);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    #endregion

    #region Leave Report
    public string LeaveBalanceInsert(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.LeaveBalanceInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }

    public DataSet GetLeaveBalance(HRBAL ObjBal)
    {
        return ObjHrDal.GetLeaveBalance(ObjBal);
    }

    public DataSet GetLvBalTran(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_LV_BAL_TRAN");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@LV_ID", ObjBal.Code);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getLvDetail(HRBAL ObjBal)
    {
        ObjBal.EmpId = (ObjBal.EmpId == null) ? "" : ObjBal.EmpId;
        ObjBal.Year = (ObjBal.Year == ".") ? "0" : ObjBal.Year;
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == ".") ? "-3" : ObjBal.ChangeStatus;
        ObjBal.Min = (ObjBal.Min == null) ? "" : ObjBal.Min;
        ObjBal.Max = (ObjBal.Max == null) ? "" : ObjBal.Max;
        cmd = new SqlCommand("GET_LEAVE_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@LV_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@STS_ID", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Min);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.Max);
        return databaseFunctions.GetDataSet(cmd);
    }


    public string LeaveBalanceDelete(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.LeaveBalanceDelete(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    public string LeaveAppUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.LeaveAppUpdate(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    #endregion
    #endregion

    #region Employee Document Collection
    public DataTable EmpDocSelect(HRBAL ObjBal)
    {
        return ObjHrDal.EmpDocumentSelect(ObjBal);
    }

    public string EmpDocCheck(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM EMP_DOC_DETAIL_INF WHERE EMP_ID=" + ObjBal.EmpId + " AND DOC_ID=" + ObjBal.TypeId;
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetSingleData(cmd);
    }

    public string EmpDocDetailAdd(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpDocDetailAdd(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        { ObjHrDal = null; }

    }


    public string EmpDocChangeStatus(HRBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            string str = "UPDATE EMP_DOC_DETAIL_INF SET DOC_VISIBLE=" + ObjBal.ChangeStatus + " WHERE DOC_DTL_ID='" + ObjBal.KeyID + "'";
            databaseFunctions.GetDataSetByQuery(str);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }

    }

    public string EmpDocDetailFirstInsert(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpDocDetailFirstInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }


    }
    #endregion
    #endregion
    # region harshita
    public DataSet GetDeptHead(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DEPT_HEAD");
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetEmpList(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_EMP_LIST");
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@GEN_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string Dept_Head_Insert(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INS_DEPT_HEAD_INF_INSERT_PROC");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
            cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@FRM_DATE", ObjBal.FromDate);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet GetNextSenior(HRBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        cmd = new SqlCommand("EMP_NXT_SNR_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@NXT_SNR_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void NextSeniorInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand("EMP_NEXT_SENIOR_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATA", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@NEWNEXT_CODE", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@INSERT_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@ACTIVE_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.RemValue);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataSet GetEmpProfile(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_EMP_PROFILE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region Block
    public string EmpBolck(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpBlockInsert(ObjBal);
            return "Employee Blocked Succcessfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    public DataSet GetBlockEmployees(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_BLOCK_EMPLOYEES");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getBlockEmployeeDetail(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_BLOCK_EMP_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public DataSet GetEmpLvDetail(HRBAL ObjBal)
    {
        CommonFunctions commonFunction = new CommonFunctions();
        ObjBal.Year = (ObjBal.Year == ".") ? "0" : ObjBal.Year;
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == ".") ? "0" : ObjBal.ChangeStatus;
        ObjBal.KeyValue = (ObjBal.KeyValue == ".") ? "0" : ObjBal.KeyValue;
        ObjBal.CommonId = (ObjBal.CommonId == "") ? "0" : ObjBal.CommonId;
        cmd = new SqlCommand("GET_EMP_LEAVE_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@LV_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@STS_ID", ObjBal.ChangeStatus);
        if (ObjBal.Min != "")
        {
            cmd.Parameters.AddWithValue("@TO_DT", commonFunction.GetDateTime(ObjBal.Min));
        }
        else
            cmd.Parameters.AddWithValue("@TO_DT", ObjBal.Min);
        if (ObjBal.Max != "")
        {
            cmd.Parameters.AddWithValue("@FROM_DT", commonFunction.GetDateTime(ObjBal.Max));
        }
        else
            cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.Max);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@LV_APP_ID", ObjBal.CommonId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    public string EmpLeaveBalanceUpdate(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpLeaveBalanceUpdate(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    public string EmpAttUpdateByHR(HRBAL ObjBal)
    {
        try
        {
            ObjHrDal.EmpAttUpdateByHR(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
    }
    #region UPDATE PWD
    public DataSet EmpPwdReset(HRBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_EMP_PASSWORD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", objbal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public string GetUserId(HRBAL ObjBal)
    {
        return databaseFunctions.GetSingleData(queryFunctions.GetCommand(QueryFunctions.QueryBaseType.Usr_id, ObjBal.EmpId));
    }

    public void MonthAttendanceSubmit(string institute, DateTime For_Month, string type, string InsertBy)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "HRD_ATTENDANCE_SUBMIT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INSTITUTION", institute);
        cmd.Parameters.AddWithValue("@FOR_MONTH", For_Month);
        cmd.Parameters.AddWithValue("@TYPE", type);
        cmd.Parameters.AddWithValue("@INSERTED_BY", InsertBy);
        databaseFunctions.ExecuteCommand(cmd);


    }
    public DataTable AttendacecCalculatioinDate(String month, String year, String ins, String type)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GetAttendanceDate";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ATTMONTH", month);
        cmd.Parameters.AddWithValue("@ATTYEAR", year);
        cmd.Parameters.AddWithValue("@ATTINSTITUTE", ins);
        cmd.Parameters.AddWithValue("@ATTTYPE", type);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataSet GetAttendance(DateTime FromDate, DateTime Todate, string Teaching, string institute, string InsertBy, string type)
    {
        cmd = new SqlCommand();


        if (type == "0")
            cmd.CommandText = "GET_MONTHLY_EMP_FOR_ATT";
        else
            cmd.CommandText = "EMP_MONTHLY_ATT_CHECK_BAL";

        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FDATE", FromDate);
        cmd.Parameters.AddWithValue("@TDATE", Todate);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", Teaching);
        cmd.Parameters.AddWithValue("@INS_ID", institute);
        cmd.Parameters.AddWithValue("@INSERT_BY", InsertBy);
        ////
        return databaseFunctions.GetDataSet(cmd);




    }

    #region Qualification
    public DataSet getQualificationList()
    {
        cmd = new SqlCommand("QUALIFICATION_SELECT");
        return databaseFunctions.GetDataSet(cmd);
    }
    public string QualificationInsertUpdate(HRBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ObjHrDal.QualificationInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjHrDal.QualificationUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public string QualificationModify(HRBAL ObjBal)
    {
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
        cmd = new SqlCommand("QUALIFICATION_MODIFY");
        cmd.Parameters.AddWithValue("ACA_CRS_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("ACA_CRS_STS", ObjBal.ChangeStatus);
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions.ExecuteCommand(cmd);
        return "Selected record updated successfully";
    }
    #endregion

    #region DutyRoster
    public DataSet getDeptEmpList(HRBAL ObjBal)
    {
        ObjBal.TypeId = (ObjBal.TypeId == null) ? "0" : ObjBal.TypeId;
        cmd = new SqlCommand("GET_DUTY_ROSTER_EMP_LIST");
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.Max);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getDeptShift(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DUTY_ROSTER_DEPT_SHIFT");
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public SqlDataReader getHolidays(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_HOLIDAYS");
        cmd.Parameters.AddWithValue("@HOLIDAY_DT", ObjBal.Date);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetReader(cmd);
    }

    public DataSet getDutyRosterDetails(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DUTY_ROSTER_DETAILS");
        cmd.Parameters.AddWithValue("@DUTY_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SHIFT_ID", ObjBal.KeyID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);

    }
    //public SqlDataReader getShiftTime(HRBAL ObjBal)
    //{
    //    cmd = new SqlCommand("GET_DUTY_ROSTER_SHIFT_TIME");
    //    cmd.Parameters.AddWithValue("@MONTH",ObjBal.Max);
    //    cmd.Parameters.AddWithValue("@USR_ID",ObjBal.SessionUserID);
    //    cmd.CommandType=CommandType.StoredProcedure;
    //    return databaseFunctions.GetReader(cmd);
    //}

    public DataSet getDutyRoster(HRBAL ObjBal)
    {
        ObjBal.TypeId = (ObjBal.TypeId == null) ? "0" : ObjBal.TypeId;
        cmd = new SqlCommand("GET_DUTY_ROSTER");
        cmd.Parameters.AddWithValue("@DUTY_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TO_DATE", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SHIFT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public SqlDataReader getShiftValue(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_SHIFT_VALUE");
        cmd.Parameters.AddWithValue("@SHIFT_ID", ObjBal.KeyID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetReader(cmd);
    }

    public string DutyRosterInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand("DEPT_DUTY_ROST_INF_INSERT");
        cmd.Parameters.AddWithValue("@DUTY_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@USR_ID", GetUserId(ObjBal));
        cmd.Parameters.AddWithValue("@DUTY_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TIME_ID", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions.GetReader(cmd);
        return Msg.GetMessage(Messages.DataMessType.Insert);
    }

    public DataSet DutyMainInsert(HRBAL ObjBal)
    {
        cmd = new SqlCommand("DEPT_DUTY_MAIN_INSERT");
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.Max);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public string DutyRosterApply(HRBAL ObjBal)
    {
        cmd = new SqlCommand("DUTY_ROSTER_APPLY");
        cmd.Parameters.AddWithValue("@DUTY_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetSingleData(cmd);
    }

    public string DutyRosterApprove(HRBAL ObjBal)
    {
        cmd = new SqlCommand("DUTY_ROSTER_APPROVE");
        cmd.Parameters.AddWithValue("@DUTY_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions.ExecuteCommand(cmd);
        return "Roster Approved Successfully";
    }

    public DataTable getDept(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DUTY_ROSTER_DEPT");
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public SqlDataReader DutyRosterSelect(HRBAL ObjBal)
    {
        cmd = new SqlCommand("DUTY_ROSTER_SELECT");
        cmd.Parameters.AddWithValue("@DUTY_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetReader(cmd);
    }
    public void DutyRosterUpdate(HRBAL ObjBal)
    {
        cmd = new SqlCommand("DUTY_ROSTER_UPDATE");
        cmd.Parameters.AddWithValue("@DUTY_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@TIME_ID", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet getLvCnt(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DUTY_ROSTER_LV_CNT");
        cmd.Parameters.AddWithValue("@DUTY_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getShift()
    {
        cmd = new SqlCommand("GET_SHIFT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Reports
    public DataSet getComReport(HRBAL ObjBal)
    {
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "-3" : ObjBal.KeyID;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.EmpId = (ObjBal.EmpId == " ") ? "0" : ObjBal.EmpId;

        cmd = new SqlCommand("GET_COM_CREDIT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STS_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@DATE_TYPE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@FROM_DATE", ObjBal.Min);
        cmd.Parameters.AddWithValue("@TO_DATE", ObjBal.Max);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getMonthlyLv(HRBAL ObjBal)
    {
        ObjBal.EmpId = (ObjBal.EmpId == null) ? "" : ObjBal.EmpId;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        cmd = new SqlCommand("GET_MONTHLY_LV_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@JOB_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.KeyValue);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getMonthlyLvBalance(HRBAL ObjBal)
    {
        ObjBal.ValueType = (ObjBal.ValueType == null) ? "" : ObjBal.ValueType;
        ObjBal.SessionUserID = GetUserId(ObjBal);
        cmd = new SqlCommand("GET_MONTHLY_LV_BALANVE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@LV_ID", ObjBal.ValueType);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getHrDashBoard()
    {
        cmd = new SqlCommand("GET_HR_DASH_BOARD");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getEmpBirthday(HRBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        cmd = new SqlCommand("GET_EMP_BIRTHDAY");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetNewJoining()
    {
        cmd = new SqlCommand("GET_NEW_JOINING");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetLvCreditReport(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_LEAVE_CREDIT_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@MONTH", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@LV_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@TYP_ID", ObjBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);

    }
    #endregion

    #region Interview
    public DataSet getJobOpening(HRBAL ObjBal)
    {
        cmd = new SqlCommand("INT_JOB_MAIN_INF_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public string JobOpeningInsert(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_JOB_MAIN_INF_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DESIG_ID", ObjBal.DesignationId);
            cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
            cmd.Parameters.AddWithValue("@NO_OF_VACANCY", ObjBal.Total);
            cmd.Parameters.AddWithValue("@MIN_SALARY", ObjBal.Min);
            cmd.Parameters.AddWithValue("@MAX_SALARY", ObjBal.Max);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@ACA_BASE_ID", ObjBal.KeyID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string InterviewCandidateInsert(HRBAL ObjBal, string Aca, string Exp)
    {
        try
        {
            ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
            cmd = new SqlCommand("INT_CAN_INF_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@F_NAME", ObjBal.FName);
            cmd.Parameters.AddWithValue("@M_NAME", ObjBal.MName);
            cmd.Parameters.AddWithValue("@L_NAME", ObjBal.LName);
            cmd.Parameters.AddWithValue("@CONTACT_NO", ObjBal.PhnNo);
            cmd.Parameters.AddWithValue("@MAIL", ObjBal.MailId);
            cmd.Parameters.AddWithValue("@MAIL_DOMAIN_ID", ObjBal.MailDomain);
            cmd.Parameters.AddWithValue("@LOCATION", ObjBal.Location);
            cmd.Parameters.AddWithValue("@ADMIN_WORK", ObjBal.Admin);
            cmd.Parameters.AddWithValue("@CURRENT_CTC", ObjBal.CurCTC);
            cmd.Parameters.AddWithValue("@EXPECTED_CTC", ObjBal.ExpCTC);
            cmd.Parameters.AddWithValue("@JOINING_DAYS", ObjBal.Total);
            cmd.Parameters.AddWithValue("@REMARK", ObjBal.RemValue);
            if (Aca != "")
                cmd.Parameters.AddWithValue("@ACA_DATA", Aca);
            if (Exp != "")
                cmd.Parameters.AddWithValue("@EXP_DATA", Exp);
            cmd.Parameters.AddWithValue("@JOB_ID", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet getJobAppDetails(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_APPLICANT_DETAILS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@INT_CAN_ID", ObjBal.HeadID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string ShortlistApplicant(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_SHORTLIST_APPLICANT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlData);
            cmd.Parameters.AddWithValue("@REMARK", ObjBal.RemValue);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet ApplicantForIntCall(HRBAL ObjBal)
    {
        ObjBal.JobId = (ObjBal.JobId == null) ? "0" : ObjBal.JobId;
        ObjBal.HeadID = (ObjBal.HeadID == null) ? "0" : ObjBal.HeadID;
        cmd = new SqlCommand("INT_APPLICANT_FOR_CALL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@JOB_ID", ObjBal.JobId);
        cmd.Parameters.AddWithValue("@INT_CAN_ID", ObjBal.HeadID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string UpdateApplicant(HRBAL ObjBal)
    {
        CommonFunctions commonFunctions = new CommonFunctions();
        try
        {
            cmd = new SqlCommand("INT_CAN_INF_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
            cmd.Parameters.AddWithValue("@INT_CAN_ID", ObjBal.HeadID);
            cmd.Parameters.AddWithValue("@F_NAME", ObjBal.FName);
            cmd.Parameters.AddWithValue("@M_NAME", ObjBal.MName);
            cmd.Parameters.AddWithValue("@L_NAME", ObjBal.LName);
            cmd.Parameters.AddWithValue("@CONTACT_NO", ObjBal.PhnNo);
            cmd.Parameters.AddWithValue("@MAIL", ObjBal.MailId);
            cmd.Parameters.AddWithValue("@MAIL_DOMAIN_ID", ObjBal.MailDomain);
            cmd.Parameters.AddWithValue("@LOCATION", ObjBal.Location);
            cmd.Parameters.AddWithValue("@ADMIN_WORK", ObjBal.Admin);
            cmd.Parameters.AddWithValue("@CURRENT_CTC", ObjBal.CurCTC);
            cmd.Parameters.AddWithValue("@EXPECTED_CTC", ObjBal.ExpCTC);
            cmd.Parameters.AddWithValue("@JOINING_DAYS", ObjBal.Total);
            cmd.Parameters.AddWithValue("@REMARK", ObjBal.RemValue);
            if (ObjBal.XmlData != "")
                cmd.Parameters.AddWithValue("@ACA_DATA", ObjBal.XmlData);
            if (ObjBal.ExpData != "")
                cmd.Parameters.AddWithValue("@EXP_DATA", ObjBal.ExpData);

            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
            if (ObjBal.Date.ToString() != "1/1/0001 12:00:00 AM")
                cmd.Parameters.AddWithValue("@INT_DATE", ObjBal.Date);
            cmd.Parameters.AddWithValue("@INT_MODE_ID", ObjBal.KeyValue);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.UpdateError);
        }
    }

    public DataSet getOldAppDetails(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_INT_APPLICANT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@INT_CAN_ID", ObjBal.HeadID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string getMapId(HRBAL ObjBal)
    {
        cmd = new SqlCommand("INT_JOB_CAN_MAP_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@JOB_ID", ObjBal.JobId);
        cmd.Parameters.AddWithValue("@CAN_ID", ObjBal.HeadID);
        return databaseFunctions.GetSingleData(cmd);
    }

    public DataSet getJobInterviewDetail(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_JOB_INTERVIEWER_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INT_MAIN_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string IntPanelInsert(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_PANEL_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INT_MAIN_ID", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
            cmd.Parameters.AddWithValue("@PANEL_XML", ObjBal.XmlData);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet getApplicantList(HRBAL ObjBal)
    {
        ObjBal.TypeId = (ObjBal.TypeId == null) ? "0" : ObjBal.TypeId;
        cmd = new SqlCommand("GET_APPLICANTS_FOR_ATT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INT_MAIN_ID", ObjBal.HeadID);
        cmd.Parameters.AddWithValue("@STS", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string MarkAppAtt(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_MARK_APP_ATT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ATT_DATA", ObjBal.XmlData);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return "Attendance Marked Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string IntApplicantFeedBack(HRBAL ObjBal)
    {
        try
        {

            cmd = new SqlCommand("INT_CAN_FEEDBACK_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
            if (ObjBal.Date.ToString() != "1/1/0001 12:00:00 AM")
                cmd.Parameters.AddWithValue("@INT_DATE", ObjBal.Date);
            cmd.Parameters.AddWithValue("@JOB_DATA", ObjBal.XmlData);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
            cmd.Parameters.AddWithValue("@INT_ROUND", ObjBal.HeadID);
            if (ObjBal.KeyValue != ".")
                cmd.Parameters.AddWithValue("@INT_MODE_ID", ObjBal.KeyValue);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet GetIntDetails(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_INT_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
        cmd.Parameters.AddWithValue("@INT_ROUND", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string IntMainInsert(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_MAIN_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
            if (ObjBal.Date.ToString() != "1/1/0001 12:00:00 AM")
                cmd.Parameters.AddWithValue("@INT_DATE", ObjBal.Date);
            cmd.Parameters.AddWithValue("@JOB_DATA", ObjBal.XmlData);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@INT_ROUND", ObjBal.HeadID);
            cmd.Parameters.AddWithValue("@INT_MODE_ID", ObjBal.KeyValue);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet GetJobSynopsis(HRBAL ObjBal)
    {
        cmd = new SqlCommand("INT_JOB_SYNOPSIS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
        //cmd.Parameters.AddWithValue("@INT_ROUND", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string UpdateJobSts(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_JOB_STS_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@JOB_ID", ObjBal.JobId);
            cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
            databaseFunctions.ExecuteCommand(cmd);
            return "Status Updated Successfully ";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.UpdateError);
        }
    }
    public DataSet GetApplicantsJoining(HRBAL ObjBal)
    {
        cmd = new SqlCommand("INT_APPLICANT_JOINING_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@JOB_ID", ObjBal.JobId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string UpdateApplicantJoining(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("INT_APPLICANT_JOINING_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@INT_JOB_ID", ObjBal.JobId);
            cmd.Parameters.AddWithValue("@INT_DATE", ObjBal.Date);
            cmd.Parameters.AddWithValue("@INT_CAN_ID", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet GetEmpForVacation(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_EMP_FOR_VAC_LV");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string VacLvInsert(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("VAC_LV_INSERT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FRM_DATE", ObjBal.KeyValue);
            cmd.Parameters.AddWithValue("@TO_DATE", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@APP_BY", ObjBal.InBy);
            cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlData);
            cmd.Parameters.AddWithValue("@APP_DATE", ObjBal.Code);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion

    public DataSet GetHREmpProfile(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_HR_EMP_PROFILE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetInsList(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_INS_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetDeptList(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DEPT_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetDepEmpList(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DEPT_EMP_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string MarkAbsent(HRBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("EMP_MARK_ABSENT_HR");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("XML_DATA", ObjBal.Value1);
            cmd.Parameters.AddWithValue("USR_ID", ObjBal.EmpId);
            cmd.Parameters.AddWithValue("IN_BY", ObjBal.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
            return "Absent Marked successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }



    public string GetDaliyAttendanceUpload(HRBAL Objbal)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "DAILY_ATTENDANCE_UPLOAD_BY_DATE_NEW";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GETDATE", Objbal.KeyValue);
            databaseFunctions.ExecuteCommand(cmd);
            return "Attendance Uploaded Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);

        }
    }
    public DataSet ZeroCompCredit(HRBAL ObjBal)
    {
        cmd = new SqlCommand("GET_ZERO_COMP_CREDIT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet UpdateLeaveCompCredit(HRBAL ObjBal)
    {
        cmd = new SqlCommand("UPDATE_ZERO_COMP_CREDIT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.InBy);
        cmd.Parameters.AddWithValue("@COMP_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@CREDIT_DAY", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);

        return databaseFunctions.GetDataSet(cmd);
    }


    public DataSet ApprovICard(string EmpId)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ICard_APPROVAL_HR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet EmpICardSts(string EmpId)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ICARD_STS_INSERT ";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("emp_code", EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetICardAppr(HRBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "Get_ICard_APPROVAL";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet RejctICard(String EmpId)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ICARD_REJECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region Security Duty
    public DataSet SecurityDutyRosterInsert(HRBAL ObjHrBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SG_DAILY_DUTY_ALLOCATION";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GETDATE", ObjHrBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", ObjHrBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet SecurityDutyRosterInsert_II(HRBAL ObjHrBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SG_DAILY_DUTY_ALLOCATION";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@GETDATE", ObjHrBal.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", ObjHrBal.SessionUserID);
        cmd.Parameters.AddWithValue("@TYPE", ObjHrBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetSecurityDutyRoster(HRBAL ObjBal)
    {
        cmd = new SqlCommand("SG_DAILY_DUTY_SELECT");
        cmd.Parameters.AddWithValue("@GETDATE", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    # endregion
}
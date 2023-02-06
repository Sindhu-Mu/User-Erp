using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for SFDAL
/// </summary>
public class SFDAL
{
    DatabaseFunctions databaseFunctins;
    ExamFunctions.DatabaseFunctions ExamdatabaseFunctins;
    SqlCommand cmd;
    public SFDAL()
    {
      
        databaseFunctins = new DatabaseFunctions();
        ExamdatabaseFunctins = new ExamFunctions.DatabaseFunctions();
        //
        // TODO: Add constructor logic here
        //
    }
    public string ExamRegFeeReceiveingInsert(SFBAL ObjBal)
    {
        cmd = new SqlCommand("EXAM_BACK_REG_FEE_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BACK_REG_MAIN_ID",ObjBal.balDemandId);
        cmd.Parameters.AddWithValue("@DEMAND_AMT",  Convert.ToDouble(ObjBal.balAmount));
        cmd.Parameters.AddWithValue("@FINE_AMT", Convert.ToDouble(ObjBal.balHeadAmt));
        cmd.Parameters.AddWithValue("@DISCOUNT_AMT", Convert.ToDouble(ObjBal.balAmt));
        cmd.Parameters.AddWithValue("@RECIEVE_AMT", Convert.ToDouble(ObjBal.balAdjAmount));
        cmd.Parameters.AddWithValue("@REG_TRAN_RMK",ObjBal.balRemark);
        cmd.Parameters.AddWithValue("@REG_BY",ObjBal.balSession);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.balType);
        cmd.Parameters.AddWithValue("@DUE", ObjBal.balData);
        cmd.Parameters.AddWithValue("@HSTL", Convert.ToDouble(ObjBal.balRate));
        return ExamdatabaseFunctins.GetSingleData(cmd);
    }

    public DataSet StuPermissionHeadInsert(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_PAYMENT_PERMISSION_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.balSession);
        cmd.Parameters.AddWithValue("@APP_BY", ObjBal.balEmpName);
        cmd.Parameters.AddWithValue("@APP_DATE", ObjBal.balDate);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.balReason);
        cmd.Parameters.AddWithValue("@DEMAND_ID", ObjBal.balDemandId);
        cmd.Parameters.AddWithValue("@AMOUNT", ObjBal.balAmount);
        cmd.Parameters.AddWithValue("@HEAD_ID", ObjBal.balHeadType);
        return databaseFunctins.GetDataSet(cmd);

    }

    public DataSet StuOpeningFeeUpdate(SFBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_OPENING_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@AMOUNT", ObjBal.balAmount);
        cmd.Parameters.AddWithValue("@FD_SUB_ID", ObjBal.balTempId);
        return databaseFunctins.GetDataSet(cmd);

    }

    public void InactiveModify(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_INACTIVE_STU_STS_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", Objbal.balStuAdmNo);
        cmd.Parameters.AddWithValue("@STATUS", Objbal.balStatus);
        cmd.Parameters.AddWithValue("@INS_BY", Objbal.balSession);
        databaseFunctins.ExecuteCommand(cmd);
    }

    public void InactiveInsert(SFBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_INACTIVE_STU_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLL", Objbal.balEnroll);
        cmd.Parameters.AddWithValue("@INS_BY", Objbal.balSession);
        databaseFunctins.ExecuteCommand(cmd);

    }

    public void DeactiveFacilityUpdate(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_DEACTIVE_FACILITY_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FD_SUB_ID", Objbal.balTempId);
        cmd.Parameters.AddWithValue("@FEE_MAIN_HEAD_ID", Objbal.balMainHeadId);
        cmd.Parameters.AddWithValue("@STU_ADM_NO", Objbal.balStuAdmNo);
        cmd.Parameters.AddWithValue("@by", Objbal.balInBy);
        databaseFunctins.ExecuteCommand(cmd);

    }

    public void FineAppDateCase(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_APP_DATE_CASE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATA", Objbal.balData);
        databaseFunctins.execute_non_query(cmd);
    }
    public string FeeReceiveTranInsert(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RCV_TRAN_INF_INSERT3";
        cmd.CommandType = CommandType.StoredProcedure;    
        cmd.Parameters.Add(new SqlParameter("@FEE_DEMAND_ID", Objbal.balDemandId));
        cmd.Parameters.Add(new SqlParameter("@TRAN_DATA", Objbal.XmlValue));
        cmd.Parameters.Add(new SqlParameter("@FEE_RCV_REMARK", Objbal.balRemark));
        cmd.Parameters.Add(new SqlParameter("@FEE_RCV_TRAN_BY", Objbal.balSession));
        cmd.Parameters.Add(new SqlParameter("@FEE_DEPOSIT_DT", Objbal.FromDate));
        cmd.Parameters.Add(new SqlParameter("@MODE_DATA", Objbal.XmlValue2));
        return databaseFunctins.GetSingleData(cmd);
    }
    public string StudentFeeReceiptUpdate(SFBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RECEIPT_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@RECEIPT_ID", Objbal.balCommonID));
        cmd.Parameters.Add(new SqlParameter("@XML_DATA", Objbal.XmlValue));
        cmd.Parameters.Add(new SqlParameter("@XML_DATA2", Objbal.XmlValue2));      
        cmd.Parameters.Add(new SqlParameter("@TRAN_BY", Objbal.balSession));
        return databaseFunctins.GetSingleData(cmd);
    }
}
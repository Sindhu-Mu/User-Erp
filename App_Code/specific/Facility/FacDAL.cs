using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for FacDAL
/// </summary>
public class FacDAL
{
    DatabaseFunctions databaseFunctions;
    SqlCommand cmd;
    public FacDAL()
    {
        databaseFunctions = new DatabaseFunctions();
    }
    #region RAVI
    #region COMPLEX TYPE MASTER

    #region Complex Type Master Insert
    public void ComplexTypeInsert(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_COMPLEX_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_VALUE", obj.Value);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Complex Type Update
    public void ComplexTypeUpdate(FacBAL obj)
    {
        SqlCommand cmd = new SqlCommand("FAC_COMPLEX_TYPE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_ID", obj.KeyID);
            cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_VALUE", obj.Value);
            cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Complex Type Modify
    public void ComplexTypeModify(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_COMPLEX_TYPE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Complex Master

    #region Complex Master Insert

    public void ComplexMasterInsert(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_COMPLEX_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_CMPLX_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@FAC_CMPLX_ROOM_NO", obj.Value);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Complex Master Update
    public void CompexMasterUpdate(FacBAL obj)
    {
        SqlCommand cmd = new SqlCommand("FAC_COMPLEX_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FAC_CMPLX_ID", obj.KeyID);
            cmd.Parameters.AddWithValue("@FAC_CMPLX_NAME", obj.Name);
            cmd.Parameters.AddWithValue("@FAC_CMPLX_TYP_ID", obj.CommonId);
            cmd.Parameters.AddWithValue("@FAC_CMPLX_ROOM_NO", obj.Value);
            cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion
    #region Complex Master Modify
    public void ComplexMasterModify(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_COMPLEX_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_CMPLX_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@FAC_CMPLX_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #endregion

    #region ROOM TYPE MASTER

    #region Room Type Master Insert
    public void RoomTypeInsert(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_ROOM_VALUE", obj.Value);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Room Type Master Update
    public void RoomTypeUpdate(FacBAL obj)
    {
        SqlCommand cmd = new SqlCommand("FAC_ROOM_TYPE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@FAC_ROOM_TYP_ID", obj.KeyID);
            cmd.Parameters.AddWithValue("@FAC_ROOM_VALUE", obj.Value);
            cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Room Type Master Modify
    public void RoomTypeModify(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_TYPE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_ROOM_TYP_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@FAC_ROOM_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Room Category Master Insert
    public void RoomCategoryInsert(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_CATEGORY_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_CHARGE", obj.Value);
        cmd.Parameters.AddWithValue("@FAC_BED_COUNT", obj.BedCount);
        cmd.Parameters.AddWithValue("@FAC_GENDER", obj.GenId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Room Category Master Update
    public void RoomCategoryUpdate(FacBAL obj)
    {
        SqlCommand cmd = new SqlCommand("FAC_ROOM_CATEGORY_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_CHARGE", obj.Value);
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_BED_CNT", obj.BedCount);
        cmd.Parameters.AddWithValue("@GEN_ID", obj.GenId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Room Category Master Modify
    public void RoomCategoryModify(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_CATEGORY_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@FAC_ROOM_CATEGORY_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #region ROOM MAIN MASTER

    #region Room Main Insert
    public void RoomMainInsert(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ROOM_NO", obj.Name);
        cmd.Parameters.AddWithValue("@ROOM_TYP_ID", obj.Id);
        cmd.Parameters.AddWithValue("@ROOM_CATEGORY_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@MAXIMUM_PRSN", obj.Value);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        cmd.Parameters.AddWithValue("@CMPLX_ID", obj.cmpxId);
        cmd.Parameters.AddWithValue("@ROOM_FLOOR", obj.RoomFloor);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Room Main Update
    public void RoomMainUpdate(FacBAL obj)
    {
        SqlCommand cmd = new SqlCommand("FAC_ROOM_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@ROOM_ID", obj.KeyID);
            cmd.Parameters.AddWithValue("@ROOM_NO", obj.Name);
            cmd.Parameters.AddWithValue("@ROOM_TYP_ID", obj.Id);
            cmd.Parameters.AddWithValue("@ROOM_CATEGORY_ID", obj.CommonId);
            cmd.Parameters.AddWithValue("@MAXIMUM_PRSN", obj.Value);
            cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
            cmd.Parameters.AddWithValue("@CMPLX_ID", obj.cmpxId);
            cmd.Parameters.AddWithValue("@ROOM_FLOOR", obj.RoomFloor);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Room Main Modify
    public void RoomMainModify(FacBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ROOM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ROOM_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #endregion


    #endregion
    #endregion
    #region PRACHI
    #region TRANSPORT
    #region ROUTE MASTER INSERT
    public void RouteMainInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_RTE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CITY_ID", objBal.CityId);
        cmd.Parameters.AddWithValue("@RTE_NAME", objBal.RteName);
        cmd.Parameters.AddWithValue("@RTE_DESC", objBal.RteDesc);
        cmd.Parameters.AddWithValue("@RATE_DAY", objBal.RateDay);
        cmd.Parameters.AddWithValue("@RATE_SEM", objBal.RateSem);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ROUTE MASTER UPDATE
    public void RouteMainUpdate(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_RTE_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@CITY_ID", objBal.CityId);
        cmd.Parameters.AddWithValue("@RTE_NAME", objBal.RteName);
        cmd.Parameters.AddWithValue("@RTE_DESC", objBal.RteDesc);
        cmd.Parameters.AddWithValue("@RATE_DAY", objBal.RateDay);
        cmd.Parameters.AddWithValue("@RATE_SEM", objBal.RateSem);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ROUTE MASTER DELETE
    public void RouteMainDelete(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_RTE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region BUS MASTER INSERT
    public void BusMainInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CITY_ID", objBal.CityId);
        cmd.Parameters.AddWithValue("@BUS_REG_NO", objBal.BusNo);
        cmd.Parameters.AddWithValue("@BUS_TYPE", objBal.BusType);
        cmd.Parameters.AddWithValue("@CAPICITY", objBal.Capicity);
        cmd.Parameters.AddWithValue("@IS_CHARGE ", objBal.IsCharge);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region BUS MASTER UPDATE
    public void BusMainUpdate(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@RTE_ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@BUS_REG_NO", objBal.BusNo);
        cmd.Parameters.AddWithValue("@BUS_TYPE", objBal.BusType);
        cmd.Parameters.AddWithValue("@CAPICITY", objBal.Capicity);
        cmd.Parameters.AddWithValue("@IS_CHARGE ", objBal.IsCharge);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region BUS MASTER DELETE
    public void BusMainDelete(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DATE REGISTRATION INSERT
    public void DateRegInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_REG_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("SLOT_ID", objBal.SlotId);
        cmd.Parameters.AddWithValue("@REG_SRT_DATE", objBal.RegSrtDate);
        cmd.Parameters.AddWithValue("@REG_END_DATE", objBal.RegEndDate);
        cmd.Parameters.AddWithValue("@REG_FINE_DATE", objBal.RegFineDate);
        cmd.Parameters.AddWithValue("@FINE_AMOUNT", objBal.FineAmt);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region DATE REGISTRATION UPDATE
    public void DateRegUpdate(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_REG_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.RegId);
        cmd.Parameters.AddWithValue("SLOT_ID", objBal.SlotId);
        cmd.Parameters.AddWithValue("@REG_SRT_DATE", objBal.RegSrtDate);
        cmd.Parameters.AddWithValue("@REG_END_DATE", objBal.RegEndDate);
        cmd.Parameters.AddWithValue("@REG_FINE_DATE", objBal.RegFineDate);
        cmd.Parameters.AddWithValue("@FINE_AMOUNT", objBal.FineAmt);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region DATE REGISTRATION DELETE
    public void DateRegDelete(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_REG_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.RegId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DATE SLOT INSERT
    public void DateSlotInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_SLOT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SRT_DATE", objBal.SrtDate);
        cmd.Parameters.AddWithValue("@END_DATE", objBal.EndDate);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #region DATE SLOT UPDATE
    public void DateSlotUpdate(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_SLOT_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.SlotId);
        cmd.Parameters.AddWithValue("@SRT_DATE", objBal.SrtDate);
        cmd.Parameters.AddWithValue("@END_DATE", objBal.EndDate);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region DATE SLOT DELETE
    public void DateSlotDelete(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_SLOT_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.SlotId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DAILY BUS IN TIME INSERT
    public void DailyBusInTimeInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DAILY_BUS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BUS_ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@IN_TIME", objBal.Time);
        cmd.Parameters.AddWithValue("@IN_DT", objBal.InDate);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region ROUTE APPROVAL INSERT
    public void RouteApprovalInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_PROVIDE_APPROVAL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_RTE_ID_XML", objBal.RegRteIdXml);
        cmd.Parameters.AddWithValue("@RTE_ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@BUS_ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@STOPPAGE", objBal.Stoppage);
        cmd.Parameters.AddWithValue("@INFO", objBal.Info);
        cmd.Parameters.AddWithValue("@APR_ID", objBal.AprId);
        cmd.Parameters.AddWithValue("@APR_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region FINANCE RECEIVE DETAIL INSERT
    public void TptFinRecInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_PAY_MODE_TRAN_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XML_DATA ", objBal.XmlValue);
        cmd.Parameters.AddWithValue("@TRAN_AMT", objBal.TranAmt);
        cmd.Parameters.AddWithValue("@TRAN_REMARK", objBal.TranRemark);
        cmd.Parameters.AddWithValue("@BANK_AC_ID", objBal.BankAccId);
        cmd.Parameters.AddWithValue("@TRAN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void TptFinMainInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_PAY_MAIN_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_RTE_ID", objBal.RegRteId);
        cmd.Parameters.AddWithValue("@FEE_DEMAND", objBal.FeeDemand);
        cmd.Parameters.AddWithValue("@DISC_AMT", objBal.DiscAmt);
        cmd.Parameters.AddWithValue("@RECEIVE_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region TRANSPORT FINANCE SPECIAL APPROVAL INSERT
    public void TptFinSplAppInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_FIN_PROVIDE_SPECIAL_APPROVAL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@PER_TYPE", objBal.PerType);
        cmd.Parameters.AddWithValue("@AMT", objBal.Amt);
        cmd.Parameters.AddWithValue("@AMT_DUE_DATE", objBal.AmtDueDate);
        cmd.Parameters.AddWithValue("@APR_BY", objBal.AprBy);
        cmd.Parameters.AddWithValue("@APR_DATE", objBal.AprDt);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region TPT BUS RTE MAPP INSERT
    public void BusRteMapInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_RTE_MAP_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CITY_ID", objBal.CityId);
        cmd.Parameters.AddWithValue("@RTE_ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@BUS_ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region TPT BUS RTE MAPP UPDATE
    public void BusRteMapUpdate(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_RTE_MAP_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.MappId);
        cmd.Parameters.AddWithValue("@CITY_ID", objBal.CityId);
        cmd.Parameters.AddWithValue("@RTE_ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@BUS_ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region TPT BUS RTE MAPP DELETE
    public void BusRteMapDelete(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_RTE_MAPP_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.MappId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region PROVIDE BUS INSERT
    public void ProvideBusInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_PROVIDE_BUS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RTE_ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@COUNT", objBal.Count);
        cmd.Parameters.AddWithValue("@BUS_ID", objBal.BusId);
        cmd.Parameters.AddWithValue("@INS_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region HSTL ALLOTMENT
    #region HSTL ALLOTMENT INSERT
    public string HstlAlmtInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_ALLOTMENT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ALLOTED_TO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@OCCUPIED_DATE", objBal.OccDt);
        cmd.Parameters.AddWithValue("@FLOOR_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.RoomId);
        cmd.Parameters.AddWithValue("@INSERT_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@OCCUPIED_ID", objBal.OccId);
        return databaseFunctions.GetSingleData(cmd);
    }

    public string HstlAlmtAllotInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_ALLOTMENT_INSERT_REG";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ALLOTED_TO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@OCCUPIED_DATE", objBal.OccDt);
        cmd.Parameters.AddWithValue("@FLOOR_ID", objBal.RoomFloor);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.RoomId);
        cmd.Parameters.AddWithValue("@INSERT_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@OCCUPIED_ID", objBal.OccId);
        cmd.Parameters.AddWithValue("@ALLOT_TYPE_ID", objBal.TypeId);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #region HSTL ALLOTMENT UPDATE
    public string HstlAlmtUpdate(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_ALLOTMENT_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ALLOTED_TO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@OCCUPIED_DATE", objBal.OccDt);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@FLOOR_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@OCCUPIED_ID", objBal.OccId);
        cmd.Parameters.AddWithValue("@INSERT_BY", objBal.SessionUserID);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #region HSTL VACANT INSERT
    public void HstlVcntInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_VACANT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ALLOTED_TO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@INSERT_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@LEAVING_DATE", objBal.LeavDt);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region HSTL CHANGE INSERT
    public string HstlChngInsert(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_CHANGE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ALLOTED_TO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@OCCUPIED_DATE", objBal.OccDt);
        cmd.Parameters.AddWithValue("@FLOOR_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.RoomId);
        cmd.Parameters.AddWithValue("@INSERT_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@OCCUPIED_ID", objBal.OccId);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #endregion

    #region FACILITY
    #region VEHICLE MAIN INSERT
    public void VehicleMainInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_VEHICLE_MASTER_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VEH_CAT", ObjBal.VehCat);
        cmd.Parameters.AddWithValue("@VEH_TYPE", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@VEH_REG_NO", ObjBal.RegId);
        cmd.Parameters.AddWithValue("@VEH_SEAT_CAPICITY", ObjBal.Seat);
        cmd.Parameters.AddWithValue("@VEH_MODEL_YEAR", ObjBal.Value);
        cmd.Parameters.AddWithValue("@VEH_CHASIS_NO", ObjBal.Info);
        cmd.Parameters.AddWithValue("@VEH_ENGINE_NO", ObjBal.No);
        cmd.Parameters.AddWithValue("@VEH_COLOR", ObjBal.Color);
        cmd.Parameters.AddWithValue("@VEH_INSURANCE_UPTO", ObjBal.Date);
        cmd.Parameters.AddWithValue("@VEH_POL_TEST_UPTO", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@MODELTYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@ROADTAX_DT", ObjBal.SrtDate);
        cmd.Parameters.AddWithValue("@ROUTE_PER_DT", ObjBal.RegSrtDate);
        cmd.Parameters.AddWithValue("@TOKEN_TAX_DT", ObjBal.RegEndDate);
        cmd.Parameters.AddWithValue("@FITNESS_DT", ObjBal.RegFineDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region VEHICLE MAIN UPDATE
    public void VehicleMainUpdate(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_VEHICLE_MASTER_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VEH_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@VEH_CAT", ObjBal.VehCat);
        cmd.Parameters.AddWithValue("@VEH_TYPE", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@VEH_REG_NO", ObjBal.RegId);
        cmd.Parameters.AddWithValue("@VEH_SEAT_CAPICITY", ObjBal.Seat);
        cmd.Parameters.AddWithValue("@VEH_MODEL_YEAR", ObjBal.Value);
        cmd.Parameters.AddWithValue("@VEH_CHASIS_NO", ObjBal.Info);
        cmd.Parameters.AddWithValue("@VEH_ENGINE_NO", ObjBal.No);
        cmd.Parameters.AddWithValue("@VEH_COLOR", ObjBal.Color);
        cmd.Parameters.AddWithValue("@VEH_INSURANCE_UPTO", ObjBal.Date);
        cmd.Parameters.AddWithValue("@VEH_POL_TEST_UPTO", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@MODELTYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@ROADTAX_DT", ObjBal.SrtDate);
        cmd.Parameters.AddWithValue("@ROUTE_PER_DT", ObjBal.RegSrtDate);
        cmd.Parameters.AddWithValue("@TOKEN_TAX_DT", ObjBal.RegEndDate);
        cmd.Parameters.AddWithValue("@FITNESS_DT", ObjBal.RegFineDate);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region DRIVER MAIN INSERT
    public void DriverMainInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_DRIVER_MAIN_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_CODE", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@DRIVER_LICENCE_NO", ObjBal.No);
        cmd.Parameters.AddWithValue("@DL_ISSUE_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DL_RENEW_DT", ObjBal.EndDate);
        cmd.Parameters.AddWithValue("@DL_ISSUE_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@DL_VAL_UPTO", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@DRIVER_AUTH_FOR", ObjBal.AuthFor);
        cmd.Parameters.AddWithValue("@DRIVER_BLD_GRP", ObjBal.BldGrp);
        cmd.Parameters.AddWithValue("@DRIVER_PHN", ObjBal.PhnNo);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region DRIVER MAIN UPDATE
    public void DriverMainUpdate(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_DRIVER_MAIN_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DRIVER_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@EMP_CODE", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@DRIVER_LICENCE_NO", ObjBal.No);
        cmd.Parameters.AddWithValue("@DL_ISSUE_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DL_RENEW_DT", ObjBal.EndDate);
        cmd.Parameters.AddWithValue("@DL_ISSUE_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@DL_VAL_UPTO", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@DRIVER_AUTH_FOR", ObjBal.AuthFor);
        cmd.Parameters.AddWithValue("@DRIVER_BLD_GRP", ObjBal.BldGrp);
        cmd.Parameters.AddWithValue("@DRIVER_PHN", ObjBal.PhnNo);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region DRIVER DELETE
    public void DriverMainDelete(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_DRIVER_MAIN_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_DRIVER_ID", objBal.KeyID);
        cmd.Parameters.AddWithValue("@DRIVER_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region VEHICLE REQUISITION DEATIL INSERT
    public void VehicleRequisitionInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_VEH_REQ_DETAIL_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REQ_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@CONTANCT_NO", ObjBal.PhnNo);
        cmd.Parameters.AddWithValue("@DEST_ADD", ObjBal.Address);
        cmd.Parameters.AddWithValue("@PICK_UP_LOC", ObjBal.PickUpLocation);
        cmd.Parameters.AddWithValue("@NOP", ObjBal.NoOfPer);
        cmd.Parameters.AddWithValue("@REQ_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@VISIT_PUR", ObjBal.Purpose);
        cmd.Parameters.AddWithValue("@JRNY_TYPE", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@JRNY_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@JRNY_TIME", ObjBal.ToTime);
        cmd.Parameters.AddWithValue("@EXCLUDE_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@REASON", ObjBal.Reason);
        cmd.Parameters.AddWithValue("@RJ_PICKUP", ObjBal.PerType);
        cmd.Parameters.AddWithValue("@RJ_DATE", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@RJ_NOP", ObjBal.No);
        cmd.Parameters.AddWithValue("@VR_REQ_FOR", ObjBal.AuthFor);
        cmd.Parameters.AddWithValue("@FORWARD_TO", ObjBal.Forward_To);
        cmd.Parameters.AddWithValue("@FROM_TIME", ObjBal.Time);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region VEHICLE REQUEST RECOMMEND
    public void FacVehReqReccomend(FacBAL ObjaBal)
    {
        cmd = new SqlCommand("FAC_VEHICLE_REQ_RECOMMEND");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VR_REQ_ID", ObjaBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FORWARD_TO", ObjaBal.Forward_To);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.TypeId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region VEHICLE REQUEST APPROVE
    public void FacVehReqApprove(FacBAL ObjaBal)
    {
        cmd = new SqlCommand("FAC_VEH_REQ_APPROVED");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VR_REQ_ID", ObjaBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FORWARD_TO", ObjaBal.Forward_To);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.TypeId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region VEHICLE REQUEST CANCEL
    public void FacVehReqCancel(FacBAL ObjaBal)
    {
        cmd = new SqlCommand("FAC_VEH_REQ_CANCELED");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@VR_REQ_ID", ObjaBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", ObjaBal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", ObjaBal.SessionUserID);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjaBal.TypeId);
        cmd.Parameters.AddWithValue("@STS", ObjaBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region VEHICLE DRIVER ASSIGNED
    public void VehDriverAssigned(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_VEHICLE_ASSIGNMENT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REQ_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@VEH_ID", ObjBal.VehCat);
        cmd.Parameters.AddWithValue("@DRIVER_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region BOOK REQUISITION INSERT
    public void BookRequisitionInsert(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_BOOK_REQ_DETAIL_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BOOK_TITLE", Objbal.Value);
        cmd.Parameters.AddWithValue("@BOOK_EDITION", Objbal.Info);
        cmd.Parameters.AddWithValue("@BOOK_AUTHOR_NAME", Objbal.Name);
        cmd.Parameters.AddWithValue("@BOOK_PRICE", Objbal.Amt);
        cmd.Parameters.AddWithValue("@BOOK_PUBLISHER", Objbal.AuthFor);
        cmd.Parameters.AddWithValue("@BOOK_NOS", Objbal.NoOfPer);
        cmd.Parameters.AddWithValue("@BOOK_NOC", Objbal.Count);
        cmd.Parameters.AddWithValue("@BOOK_ISBN_NO", Objbal.No);
        cmd.Parameters.AddWithValue("@BOOK_REQUEST_BY", Objbal.SessionUserID);
        cmd.Parameters.AddWithValue("@BOOK_REMARK", Objbal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region BOOK REQUEST RECOMMEND
    public void FacBookReqRecommend(FacBAL Objbal)
    {
        cmd = new SqlCommand("FAC_BOOK_REQ_RECOMMEND");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BOOK_REQ_ID", Objbal.Id);
        cmd.Parameters.AddWithValue("@PROC_TYPE", Objbal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", Objbal.SessionUserID);
        cmd.Parameters.AddWithValue("@FORWARD_TO", Objbal.Forward_To);
        cmd.Parameters.AddWithValue("@REMARK", Objbal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region BOOK REQUEST APPROVE
    public void FacBookReqApprove(FacBAL objBal)
    {
        cmd = new SqlCommand("FAC_BOOK_REQ_APPROVE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BOOK_REQ_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FORWARD_TO", objBal.Forward_To);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region BOOK REQUEST CANCEL
    public void FacBookReqCancel(FacBAL objBal)
    {
        cmd = new SqlCommand("FAC_BOOK_REQ_CANCEL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BOOK_REQ_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@STS", objBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region ISSUE TRACKING
    #region ISSUE MAIN INSERT & UPDATE
    public void IssueMainInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_TRACKING_MAIN_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@HEAD_VALUE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void IssueMainUpdate(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_TRACKING_MAIN_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@CAT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@HEAD_VALUE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ISSUE MAIN MODIFY
    public void IssueMainModify(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_TRACKING_MAIN_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ID", objBal.Id);
        cmd.Parameters.AddWithValue("@HEAD_STS", objBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ISSUE SOLUTION INSERT
    public void IssueSolutionInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_SOLUTION_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SOLTION_VALUE", ObjBal.ValueType);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region ISSUE SUB HEAD INSERT
    public void IssueSubHeadInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_SUB_HEAD_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@SUB_HEAD_VALUE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@SOL_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void IssueSubHeadUpdate(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_SUB_HEAD_UPADTE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_HEAD_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@HEAD_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@SOL_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@SUB_HEAD_VALUE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ISSUE SUB HEAD MODIFY
    public void IssueSubHeadModify(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_SUB_HEAD_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_HEAD_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region ISSUE SOLUTION and TRANSFERED
    public void IssueSolution(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ISSUE_SOLVED";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@SOLUTION", ObjBal.Description);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void IssueTransfer(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ISSUE_TRANSFERED";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@SOLUTION", ObjBal.Description);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region STUDENT PORTAL

    #region IMP CONTACTS INSERT
    public void ImpContactsInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "IMP_CONTACTS_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@DEPT", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@MAIL_VALUE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@DOMAIN", ObjBal.Address);
        cmd.Parameters.AddWithValue("@PHN_NO", ObjBal.PhnNo);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region STUDENT PWD
    public void UpdateStuPwd(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_STU_PWD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.AuthFor);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region HALL REQUISITION
    #region HALL REQUISITION INSERT
    public void HallRequisitionInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HALL_BOOKING_MASTER_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HALL_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@HALL_BOOK_FOR", ObjBal.AuthFor);
        cmd.Parameters.AddWithValue("@HALL_FROM_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@HALL_FROM_TIME", ObjBal.Time);
        cmd.Parameters.AddWithValue("@HALL_TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@HALL_TO_TIME", ObjBal.ToTime);
        cmd.Parameters.AddWithValue("@HALL_BOOK_NO", ObjBal.No);
        cmd.Parameters.AddWithValue("@HALL_SERVICE_REQ", ObjBal.Request);
        cmd.Parameters.AddWithValue("@HALL_BOOK_DETAIL", ObjBal.Description);
        cmd.Parameters.AddWithValue("@GUEST_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@GUEST_NO", ObjBal.PhnNo);
        cmd.Parameters.AddWithValue("@GUEST_ADD", ObjBal.Address);
        cmd.Parameters.AddWithValue("@ADM_REQ", ObjBal.AdmReq);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@ACTION_TO", ObjBal.Forward_To);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataTable BtnSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT_ACTION_TO";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", objBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    #endregion
    #region HALL REQUEST RECOMMEND
    public void HallReqRecommend(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_HALL_REQ_RECOMMEND");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HALL_REQ_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@FORWARD_TO", ObjBal.Forward_To);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region HALL REQUEST CANCEL
    public void HallReqCancel(FacBAL objBal)
    {
        cmd = new SqlCommand("FAC_HALL_REQ_CANCEL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HALL_REQ_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@PROC_TYPE", objBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@STS", objBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region HALL REQUEST APPROVE
    public void HallReqApprove(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_HALL_REQ_APPROVE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HALL_REQ_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region HALL CANCEL APPLY BOOKING
    public void HallCancelApplyBooking(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_HALL_CANCEL_APPLY");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@HALL_REQ_ID", ObjBal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region STUDENT RE-REG
    public void StudentReRegUpdate(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_UPDATE_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        cmd.Parameters.AddWithValue("@APR_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REG_ID", ObjBal.RegId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ReRegPrint(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_pRNT_DETAILS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_ID", ObjBal.RegId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ReRegMainInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "RE_REGISTRATION_MAIN_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SRT_DT", ObjBal.frdt);
        cmd.Parameters.AddWithValue("@END_DT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SESSION", ObjBal.SlotId);
        cmd.Parameters.AddWithValue("@SEM_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ReRegMainUpdate(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SEM_RE_REG_MAIN_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@SRT_DT", ObjBal.frdt);
        cmd.Parameters.AddWithValue("@END_DT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SESSION", ObjBal.SlotId);
        cmd.Parameters.AddWithValue("@SEM_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ReRegMainModify(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SEM_RE_REG_MAIN_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REG_ID", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region ISSUE
    public string EmpNewIssueInsert(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LOCATION", ObjBal.PickUpLocation);
        cmd.Parameters.AddWithValue("@CMPLX", ObjBal.cmpxId);
        cmd.Parameters.AddWithValue("@ISSUE_DETAIL", ObjBal.Description);
        cmd.Parameters.AddWithValue("@ISSUE_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SUB_ID", ObjBal.Id);
        return databaseFunctions.GetSingleData(cmd);
    }
    public string EmpNewIssueUpdate(FacBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_DETAIL_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", objbal.DeptId);
        cmd.Parameters.AddWithValue("@SUB_ID", objbal.Id);
        cmd.Parameters.AddWithValue("@LOCATION", objbal.PickUpLocation);
        cmd.Parameters.AddWithValue("@CMPLX", objbal.cmpxId);
        cmd.Parameters.AddWithValue("@DETAIL", objbal.Description);
        cmd.Parameters.AddWithValue("@ISSUE_ID", objbal.KeyID);
        return databaseFunctions.GetSingleData(cmd);
    }
    public void EmpNewIssueDelete(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_DELETE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ISSUE_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmpTransferIssueDelete(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_TRANSFER_ISSUE_DELETE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TRANSFER_ID", Objbal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void EmpMaterialDelete(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_MATERIAL_DETAIL_DELETE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_DET_ID", ObjBal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion

    #region Nisha

    public void HstlChngInsertByReg(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_CHANGE_INSERT_BY_REG";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ALLOTED_TO", objBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@OCCUPIED_DATE", objBal.OccDt);
        cmd.Parameters.AddWithValue("@FLOOR_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", objBal.Remark);
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.RoomId);
        cmd.Parameters.AddWithValue("@INSERT_BY", objBal.SessionUserID);
        cmd.Parameters.AddWithValue("@OCCUPIED_ID", objBal.OccId);
        databaseFunctions.ExecuteCommand(cmd);
    }

#endregion
}
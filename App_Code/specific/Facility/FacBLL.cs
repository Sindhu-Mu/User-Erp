
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FacBLL
/// </summary>
public class FacBLL
{

    FacDAL FAC_DAL;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    public FacBLL()
    {
        databaseFunctions = new DatabaseFunctions();
        FAC_DAL = new FacDAL();
        Msg = new Messages();
    }

    #region RAVI

    #region COMPLEX TYPE MASTER
    #region Complex Type Master Select
    public DataSet ComplexTypeSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_COMPLEX_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Complex Type Master Insert And Update
    public string ComplexTypeInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                FAC_DAL.ComplexTypeInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.ComplexTypeUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Complex Type Master Modify
    public string ComplexTypeModify(FacBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.ComplexTypeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion


    #region Complex Master

    #region Complex Master Insert And Update
    public string ComplexMasterInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                FAC_DAL.ComplexMasterInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.CompexMasterUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Complex Master Modify
    public string ComplexMasterModify(FacBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.ComplexMasterModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Complex Master Select
    public DataSet ComplexMasterSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_COMPLEX_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion

    #endregion

    #region ROOM MASTER

    #region Room Type Master Select
    public DataSet RoomTypeSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Room Type Master Insert And Update
    public string RoomTypeInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                FAC_DAL.RoomTypeInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.RoomTypeUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Room Type Master Modify
    public string RoomTypeModify(FacBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.RoomTypeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Room Category Master Insert And Update
    public string RoomCategoryInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                FAC_DAL.RoomCategoryInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.RoomCategoryUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region Room Category master Modify
    public string RoomCategoryModify(FacBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.RoomCategoryModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region Room Category master Select
    public DataSet RoomCategorySelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_CATEGORY_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion


    #region ROOM MAIN MASTER

    #region Room Main Insert And Update
    public string RoomMainInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                FAC_DAL.RoomMainInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.RoomMainUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Room Main modify
    public string RoomMainModify(FacBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.RoomMainModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region Room Main Select
    public DataSet RoomMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_ROOM_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion


    #endregion

    #endregion
    #region Hostel


    public DataTable SelectComplexId(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_ROOM_REQ_DATA");
        cmd.Parameters.AddWithValue("@USER_ID", ObjBal.balSession);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetHostelStudentDailyAtt(FacBAL ObjBal)
    {
        cmd = new SqlCommand("HOSTEL_STUDENT_DAILY_ATT");
        cmd.Parameters.AddWithValue("@DATE", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public int GetFeeRcvAmount(FacBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("FAC_HSTL_FEE_RCV_CHECK");
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.StuAdmNo);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.ExecuteScalar(cmd);
    }
    public int ChangeHeadStatus(FacBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "STU_HSTL_CHANGE_GROUP_HEAD_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", Objbal.StuAdmNo);
        cmd.Parameters.AddWithValue("@STATUS", Objbal.balsts);
        return databaseFunctions.execute_non_query(cmd);
    }
    public void DeleteStuHstlReq(FacBAL Objbal)
    {
        cmd = new SqlCommand("FAC_HSTL_REQ_DELETE");
        cmd.Parameters.AddWithValue("@ID", Objbal.Id);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", Objbal.StuAdmNo);
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions.execute_non_query(cmd);
    }
    public string GetStuAllotCheck(FacBAL Objbal)
    {
        cmd = new SqlCommand("GET_NEW_OLD_FOR_HOSTEL");
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", Objbal.KeyID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion

    #region PRACHI
    #region TRANSPORT
    #region ROUTE MASTER SELECT
    public DataSet RouteMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_RTE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region ROUTE MASTER INSERT & UPDATE
    public string RouteMainInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.RteId == "")
            {
                FAC_DAL.RouteMainInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.RouteMainUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region ROUTE MASTER DELETE
    public string RouteMainDelete(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.RouteMainDelete(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }

    }
    #endregion

    #region BUS MASTER SELECT
    public DataSet BusMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region BUS MASTER INSERT & UPDATE
    public string BusMainInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.BusId == "")
            {
                FAC_DAL.BusMainInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.BusMainUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region BUS MASTER DELETE
    public string BusMainDelete(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.BusMainDelete(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region DATE SLOT SELECT
    public DataSet DateSlotSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_SLOT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DATE SLOT INSERT & UPDATE
    public string DateSlotInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.SlotId == "")
            {

                FAC_DAL.DateSlotInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.DateSlotUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region DATE SLOT DELETE
    public string DateSlotDelete(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.DateSlotDelete(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region DATA REGISTRATION SELECT
    public DataSet DateRegSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DATE_REG_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DATE REGISTRATION INSERT & UPDATE
    public string DateRegInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.RegId == "")
            {

                FAC_DAL.DateRegInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.DateRegUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region DATE REGISTRATON DELETE
    public string DateRegDelete(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.DateRegDelete(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region DAILY BUS IN TIME SELECT
    public DataSet DailyBusInTimeSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_DAILY_BUS_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DAILY BUS IN TIME INSERT
    public string DailyBusInTimeInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.DailyBusInTimeInsert(objBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region ROUTE APPROVAL SELECT
    public DataSet RouteApprovalSelect(FacBAL objBal)
    {
        objBal.RegstId = (objBal.RegstId == null) ? "" : objBal.RegstId;
        objBal.CityId = (objBal.CityId == ".") ? "0" : objBal.CityId;
        objBal.SlotId = (objBal.SlotId == ".") ? "0" : objBal.SlotId;
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_GET_ROUTE_APPROVAL_LIST";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CIT_ID", objBal.CityId);
        cmd.Parameters.AddWithValue("@SLOT_ID", objBal.SlotId);
        cmd.Parameters.AddWithValue("@REG_ID", objBal.RegstId);

        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region ROUTE APPROVAL INSERT
    public string RouteApprovalInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.RouteApprovalInsert(objBal);
            return "Bus & Route Assigned Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region FINANCE RECEIVE DETAIL SELECT
    public DataSet FinRecSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_GET_FEE_RECEIVING_LIST";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", objBal.StuAdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region FINANCE RECEIVE DETAIL INSERT
    public string TptFinRecInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.TptFinMainInsert(objBal);
            FAC_DAL.TptFinRecInsert(objBal);

            return "Recevied Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region TRANSPORT FINANCE SPECIAL APPROVAL INSERT
    public string TptFinSplAppInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.TptFinSplAppInsert(objBal);

            return "Recevied Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region TRANSPORT FINANCE APPROVAL SELECT
    public DataSet TptFinAppSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_FIN_PROVIDE_SPECIAL_APPROVAL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", objBal.StuAdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region BUS RTE MAPP SELECT
    public DataSet BusRteMapSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_BUS_RTE_MAPP_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region BUS RTE MAP INSERT & UPDATE
    public string BusRteMapInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.MappId == "")
            {
                FAC_DAL.BusRteMapInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.BusRteMapUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region BUS RTE MAPP DELETE
    public string BusRteMapDelete(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.BusRteMapDelete(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region PENDING BUS APPROVAL LIST SELECT
    public DataSet PendingBusSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_GET_PENDING_BUS_PROVIDER_LIST";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region PROVIDE BUS APPROVAL LIST SELECT
    public DataSet ProvideBusSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_GET_BUS_PROVIDE_LIST";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@RTE_ID", objBal.RteId);
        cmd.Parameters.AddWithValue("@COUNT", objBal.Count);
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion
    #region PROVIDE BUS APPROVAL INSERT
    public string ProvideBusInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.ProvideBusInsert(objBal);
            return "Bus Assigned Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #endregion

    #region HOSTEL ROOM
    #region FAC HOSTEL ROOM ALLOTMENT SELECT
    public DataSet HstlRumAlmtSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_ALLOTMENT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.RoomId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region FAC HSTL ROOM ALLOTMENT INSERT
    public string HstlRoomAllotInsertUpdate(FacBAL objBal)
    {

        if (objBal.KeyID == "")
        {
            return FAC_DAL.HstlAlmtInsert(objBal);

        }
        else
        {
            return FAC_DAL.HstlAlmtUpdate(objBal);
        }

    }
    public string HstlRegAllotInsertUpdate(FacBAL objBal)
    {

        if (objBal.KeyID == "")
        {
            return FAC_DAL.HstlAlmtAllotInsert(objBal);

        }
        else
        {
            return FAC_DAL.HstlAlmtUpdate(objBal);
        }

    }
    #endregion
    #region FAC HSTL ROOM VACANT SELECT
    public DataSet HstlRumVctSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HSTL_ROOM_VACANT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ROOM_ID", objBal.RoomId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region FAC HOSTEL ROOM VACANT INSERT
    public string HstlVcntInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.HstlVcntInsert(objBal);
            return "Room Vacant Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }

    }
    #endregion
    #region FAC HOSTEL ROOM CHANGE INSERT
    public string HstlRoomChngeInsert(FacBAL objBal)
    {
        try
        {
            return FAC_DAL.HstlChngInsert(objBal);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }
    #endregion
    #endregion

    #region FACILITY
    #region Vehicle main Select
    public DataSet VehicleMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_VEHICLE_MASTER_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Vehicle INSERT & UPDATE
    public string VehicleMainInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.Id == "")
            {
                FAC_DAL.VehicleMainInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.VehicleMainUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region Driver Main Select
    public DataSet DriverMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_DRIVER_MAIN_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region DRIVER MAIN INSERT AND UPDATE
    public string DriverMainInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.Id == "")
            {
                FAC_DAL.DriverMainInsert(objBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.DriverMainUpdate(objBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region DRIVER DELETE
    public string DriverMasterModify(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.DriverMainDelete(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region VEHICLE REQUISITION INSERT
    public string VehicleRequisitionInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.VehicleRequisitionInsert(objBal);
            return "Your Vehicle Request is forwarded sucessfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    public DataSet getRoleId(FacBAL objbal)
    {
        cmd = new SqlCommand("GET_USER_ROLE");
        cmd.Parameters.AddWithValue("@USR_ID", objbal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region VEHICLE REQUEST RECOMMEND
    public string FacVehReqReccomend(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.FacVehReqReccomend(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }

    #endregion
    #region VEHICLE REQUEST APPROVE
    public string FacVehReqApprove(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.FacVehReqApprove(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region VEHICLE REQUEST CANCELLED
    public string FacVehReqCancel(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.FacVehReqCancel(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region VEHICLE REQUISITION APPROVAL
    public DataSet VehReqApproval(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_VEH_REQ_GET_DATA");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet VehRetDetail(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_VEH_REQ_GET_RETURN_DETAIL");
        cmd.Parameters.AddWithValue("VR_REQ_ID", ObjBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region VEHICLE APPROVED DETAIL
    public DataSet VehReqApproved(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_VEH_VEHICLE_APPROVE_DEATIL");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet VehRetApproved(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_VEH_REQ_RETURN_APPROVED");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@VR_REQ_ID", ObjBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string VehDriverAssigned(FacBAL objBal)
    {
        try
        {
            FAC_DAL.VehDriverAssigned(objBal);
            return "Vehicle & Driver Assigned Sucessfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    public DataSet GetsmsMAilDetail(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_GET_SMS_EMAIL_DETAIL");
        cmd.Parameters.AddWithValue("@VR_REQ_ID", ObjBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetTptPrintDetail(FacBAL ObjBal)
    {
        ObjBal.StuAdmNo = (ObjBal.StuAdmNo == null) ? "" : ObjBal.StuAdmNo;
        ObjBal.CityId = (ObjBal.CityId == ".") ? "0" : ObjBal.CityId;
        ObjBal.RteId = (ObjBal.RteId == ".") ? "0" : ObjBal.RteId;
        ObjBal.BusId = (ObjBal.BusId == ".") ? "0" : ObjBal.BusId;
        ObjBal.PerType = (ObjBal.PerType == ".") ? "0" : ObjBal.PerType;
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_STU_GET_PRINT_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@CITY_ID", ObjBal.CityId);
        cmd.Parameters.AddWithValue("@RTE_ID", ObjBal.RteId);
        cmd.Parameters.AddWithValue("@BUS_ID", ObjBal.BusId);
        cmd.Parameters.AddWithValue("@PRINT_TYPE", ObjBal.PerType);
        cmd.Parameters.AddWithValue("@COUNTER", ObjBal.Count);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region VEHICLE PREVIOUS REQUEST
    public DataSet VehPreviousReqSelect(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_EMP_PREVIOUS_VEH_REQ");
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string GetEmpNo(FacBAL ObjBal)
    {
        cmd = new SqlCommand("GET_EMP_PHN_NO");
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion

    public DataSet GetBookRequisitionDetail(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_BOOK_REQ_MAIN_SELECT");
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #region BOOK REQUISITION INSERT
    public string BookRequisitionInsert(FacBAL objBal)
    {
        try
        {
            FAC_DAL.BookRequisitionInsert(objBal);
            return "Book Request Forwarded Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region BOOK REQUISITION APPROVAL
    public DataSet BookReqApproval(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_BOOK_REQ_GET_DATA");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet BookDetail(FacBAL Objbal)
    {
        cmd = new SqlCommand("FAC_BOOK_DEATIL");
        cmd.Parameters.AddWithValue("@EMP_ID", Objbal.SessionUserID);
        cmd.Parameters.AddWithValue("@BOOK_REQ_ID", Objbal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region BOOK REQUEST RECOMMEND
    public string FacBookReqRecommend(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.FacBookReqRecommend(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region BOOK REQUEST APPROVE
    public string FacBookReqApprove(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.FacBookReqApprove(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region BOOK REQUEST CANCEL
    public string FacBookReqCancel(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.FacBookReqCancel(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region UPDATE BOOK DETAIL
    public string UpdateBook(FacBAL objBal)
    {
        try
        {
            cmd = new SqlCommand("FAC_BOOK_DEATIL_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BOOK_REQ_ID", objBal.Id);
            cmd.Parameters.AddWithValue("@PRICE", objBal.Amt);
            cmd.Parameters.AddWithValue("@NOC", objBal.Capicity);
            cmd.Parameters.AddWithValue("@ISBN_NO", objBal.No);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion
    #endregion

    #region ISSUE TRACKING
    #region ISSUE MAIN INSERT & UPDATE
    public string IssueMainInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.Id == "")
            {
                FAC_DAL.IssueMainInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.IssueMainUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region ISSUE MAIN SELECT
    public DataSet IssueMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_TRACKING_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region ISSUE MAIN MODIFY
    public string IssueMainModify(FacBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.IssueMainModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }
    }
    #endregion

    #region ISSUE SOLUTION INSERT
    public string IssueSolutionInsert(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.IssueSolutionInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region ISSUE SOLUTION SELECT
    public DataSet IssueSolSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_SOLUTION_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region ISSUE SUB HEAD INSERT & UPDATE
    public string IssueSubInsertUpdate(FacBAL ObjBal)
    {
        try
        {
            if (ObjBal.Id == "")
            {
                FAC_DAL.IssueSubHeadInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                FAC_DAL.IssueSubHeadUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }

    }
    #endregion
    #region INSERT SUB HEAD SELECT
    public DataSet IssueSubHeadSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ISSUE_SUB_HEAD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region INSERT SUB HEAD MODIFY
    public string IssueSubHeadModify(FacBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.IssueSubHeadModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion

    #region ISSUE PENDING REQUEST
    public DataSet IssuePendingRequest()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ISSUE_MAIN_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region ISSUE DETAIL
    public DataSet IssueDetail(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ISSUE_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", Objbal.Id);
        cmd.Parameters.AddWithValue("@SOLUTION", Objbal.Description);
        cmd.Parameters.AddWithValue("@INS_BY", Objbal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region ISSUE SOLUTION
    public string IssueSolution(FacBAL Objbal)
    {
        try
        {
            FAC_DAL.IssueSolution(Objbal);
            return "Solution Provided to the Issue";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        { FAC_DAL = null; }
    }
    #endregion
    #region ISSUE TRANSFERED
    public string IssueTransfer(FacBAL Objbal)
    {
        try
        {
            FAC_DAL.IssueTransfer(Objbal);
            return "Issue Transfered";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        { FAC_DAL = null; }
    }
    #endregion
    #endregion

    #region STUDENT PORTAL

    #region IMP CONTANCTS SELECT
    public DataSet ImpContactSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "IMP_CONTANCTS_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region IMP CONTACTS INSERT
    public string ImpContactInsert(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.ImpContactsInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region CHANGE PASSWORD
    public string UpdatePwd(FacBAL Objbal)
    {
        try
        {
            FAC_DAL.UpdateStuPwd(Objbal);
            return "Password Change to Date Of Birth";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #endregion

    #region TRANSPORT COUNTER

    #region REGISTRATION COUNTER
    public DataSet TptRegCounter(FacBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_REGISTRATION_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", objbal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", objbal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region APPROVED ROUTE COUNTER
    public DataSet TptAppRteCounter(FacBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_RTE_APP_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CITY_ID", objbal.CityId);
        cmd.Parameters.AddWithValue("@INS_ID", objbal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", objbal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region PAYMENT DONE COUNTER
    public DataSet TptPayCounter(FacBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_PAYMENT_DONE_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CITY_ID", objbal.CityId);
        cmd.Parameters.AddWithValue("@RTE_ID", objbal.RteId);
        cmd.Parameters.AddWithValue("@INS_ID", objbal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", objbal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #endregion
    #region HALL BOOKING INSERT
    public string HallBookingRequisition(FacBAL objBal)
    {
        try
        {
            FAC_DAL.HallRequisitionInsert(objBal);
            return "Hall Request Forwarded Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    public string[] BtnSelect(FacBAL ObjBal)
    {
        string[] data = new string[2];
        DataTable dt = FAC_DAL.BtnSelect(ObjBal);
        string HOD = dt.Rows[0][0].ToString();
        if (ObjBal.SessionUserID == HOD)
        {
            if (ObjBal.CommonId == "1")
            {
                data[0] = "5";
            }
            else
                data[0] = "3";

        }
        else
        {
            data[0] = "2";
        }
        return data;
    }
    #endregion
    #region HALL REQUISITION APPROVAL
    public DataSet HallReqApproval(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_HALL_REQ_DATA");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region HALL DETAIL
    public DataSet HallDeatil(FacBAL ObjBal)
    {
        cmd = new SqlCommand("FAC_HALL_DETAIL");
        cmd.Parameters.AddWithValue("@HALL_REQ_ID", ObjBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region HALL APPROVE DETAIL
    public DataSet HallApproveDetail(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_HALL_REQ_APPROVE_DATA";
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region HALL REQUEST RECOMMEND
    public string HallReqRecommend(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.HallReqRecommend(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region HALL REQUEST CANCEL
    public string HallReqCancel(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.HallReqCancel(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region HALL REQUEST APPROVE
    public string HallReqApprove(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.HallReqApprove(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region SELECT HALL BOOKING CANCEL
    public DataSet HallBokingCancel(FacBAL objBal)
    {
        cmd = new SqlCommand("FAC_CANCEL_HALL_BOOKING_SELECT");
        cmd.Parameters.AddWithValue("@emp_id", objBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region CANCEL APPLIED BOOKING
    public string HallCancelApply(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.HallCancelApplyBooking(ObjBal);
            return "Booking for Hall is Successfully Cancelled";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    #endregion
    #region RE REGISTRATION

    #region RE REGISTRATION APPROVAL
    public DataSet ReRegSelect(FacBAL ObjBal)
    {
        ObjBal.StuAdmNo = (ObjBal.StuAdmNo == null) ? "" : ObjBal.StuAdmNo;
        ObjBal.RegId = (ObjBal.RegId == ".") ? "0" : ObjBal.RegId;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        ObjBal.Status = (ObjBal.Status == ".") ? "0" : ObjBal.Status;
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_APP_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_FOR", ObjBal.RegId);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@INS", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM", ObjBal.Id);
        cmd.Parameters.AddWithValue("@BRN", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string StudentReRegUpdate(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.StudentReRegUpdate(ObjBal);
            return "Request Approved Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        { FAC_DAL = null; }
    }
    #endregion
    #region RE REGISTRATION PRINT
    public DataSet ReRegPrint(FacBAL ObjBal)
    {
        ObjBal.StuAdmNo = (ObjBal.StuAdmNo == null) ? "" : ObjBal.StuAdmNo;
        ObjBal.RegId = (ObjBal.RegId == ".") ? "0" : ObjBal.RegId;
        ObjBal.Value = (ObjBal.Value == ".") ? "0" : ObjBal.Value;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        ObjBal.Status = (ObjBal.Status == ".") ? "0" : ObjBal.Status;
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_FINAL_PRINT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_FOR", ObjBal.RegId);
        cmd.Parameters.AddWithValue("@REG_STS", ObjBal.Value);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@INS", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM", ObjBal.Id);
        cmd.Parameters.AddWithValue("@BRN", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string StuReRegPrint(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.ReRegPrint(ObjBal);
            return "Printed Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }

    #endregion
    public string ReRegInsertUpdate(FacBAL objBal)
    {

        if (objBal.KeyID == "")
        {
            FAC_DAL.ReRegMainInsert(objBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        else
        {
            FAC_DAL.ReRegMainUpdate(objBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }

    }
    public string ReRegModify(FacBAL objBal)
    {
        try
        {
            objBal.ChangeStatus = (objBal.ChangeStatus == "Deactivate") ? "0" : "1";
            FAC_DAL.ReRegMainModify(objBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { FAC_DAL = null; }

    }
    public DataSet ReRegMainSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SEM_RE_REG_MAIN_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region HOSTEL ATT REPORT
    public string GetStudentMainId(FacBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("SELECT STU_MAIN_ID FROM STU_MAIN_INF WHERE ENROLLMENT_NO = @ENROLLMENT_NO");
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.AuthFor);
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetDataSet(cmd).Tables[0].Rows[0][0].ToString();
    }
    public DataSet HstlAttRpt(FacBAL ObjBal)
    {
        ObjBal.StuAdmNo = (ObjBal.StuAdmNo == null) ? "" : ObjBal.StuAdmNo;
        ObjBal.cmpxId = (ObjBal.cmpxId == ".") ? "0" : ObjBal.cmpxId;
        ObjBal.RoomFloor = (ObjBal.RoomFloor == ".") ? "0" : ObjBal.RoomFloor;
        ObjBal.RoomId = (ObjBal.RoomId == ".") ? "0" : ObjBal.RoomId;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        ObjBal.RateSem = (ObjBal.RateSem == ".") ? "0" : ObjBal.RateSem;
        cmd = new SqlCommand();
        cmd.CommandText = "GET_STU_HSTL_ATT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.frdt);
        cmd.Parameters.AddWithValue("@CPLX_ID", ObjBal.cmpxId);
        cmd.Parameters.AddWithValue("@FLOOR", ObjBal.RoomFloor);
        cmd.Parameters.AddWithValue("@ROOM", ObjBal.RoomId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.RateSem);
        cmd.Parameters.AddWithValue("@STS", ObjBal.Status);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Hostel Student Count
    public DataSet GetHostelStuCount()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_HOSTEL_STUDENT_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region GET HALL STS
    public DataSet GetHallSts(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_HALL_BOOKING_DETAILS";
        cmd.Parameters.AddWithValue("@MONTH", Objbal.No);
        cmd.Parameters.AddWithValue("@YEAR", Objbal.RateDay);
        cmd.Parameters.AddWithValue("@HALL_TYPE_ID", Objbal.TypeId);
        cmd.Parameters.AddWithValue("@DATE", Objbal.FromDate);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public SqlDataReader GetHolidays(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_HOLIDAYS";
        cmd.Parameters.AddWithValue("@HOLIDAY_DT", Objbal.Date);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetReader(cmd);
    }
    #endregion
    #region EMP ISSUE
    public string EmpIssueInsertUpdate(FacBAL objBal)
    {
        try
        {
            if (objBal.KeyID == "")
            {
                return FAC_DAL.EmpNewIssueInsert(objBal);

            }
            else
            {
                return FAC_DAL.EmpNewIssueUpdate(objBal);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }

    public DataSet EmpIssueSelect(FacBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT_EMP_ISSUE_DETAIL";
        cmd.Parameters.AddWithValue("@EMP_ID", objbal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet IssueDetailSelect(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_DETAIL_SELECT";
        cmd.Parameters.AddWithValue("@ISSUE_ID", objBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet IssueDetailSelectII(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_DETAIL_SELECT_II";
        cmd.Parameters.AddWithValue("@YEAR", objBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet IssueDetailSelectIII(FacBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_DETAIL_SELECT_III";
        cmd.Parameters.AddWithValue("@ISSUE_ID", objBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string IssueDelete(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.EmpNewIssueDelete(ObjBal);
            return "Tiicket Deleted Sucessfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    public DataSet IssueSolutionSelect(FacBAL Objbal)
    {
        Objbal.DeptId = (Objbal.DeptId == ".") ? "0" : Objbal.DeptId;
        Objbal.CommonId = (Objbal.CommonId == ".") ? "0" : Objbal.CommonId;
        Objbal.No = (Objbal.No == "") ? "0" : Objbal.No;
        Objbal.Status = (Objbal.Status == ".") ? "0" : Objbal.Status;
        Objbal.Id = (Objbal.Id == ".") ? "0" : Objbal.Id;
        Objbal.frdt = (Objbal.frdt == "") ? "" : Objbal.frdt;
        Objbal.todt = (Objbal.todt == "") ? "" : Objbal.todt;
        SqlCommand cmd = new SqlCommand("EMP_ISSUE_SOLUTION_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", Objbal.DeptId);
        cmd.Parameters.AddWithValue("@COMPLEX_ID", Objbal.CommonId);
        cmd.Parameters.AddWithValue("@ISSUE_BY", Objbal.TypeId);
        cmd.Parameters.AddWithValue("@TOKEN_NO", Objbal.No);
        cmd.Parameters.AddWithValue("@ISSUE_STS", Objbal.Status);
        cmd.Parameters.AddWithValue("@SUB_HEAD", Objbal.Id);
        cmd.Parameters.AddWithValue("@TYPE", Objbal.Value);
        cmd.Parameters.AddWithValue("@FRM_DT", Objbal.frdt);
        cmd.Parameters.AddWithValue("@TO_DT", Objbal.todt);
        cmd.Parameters.AddWithValue("@USR_ID", Objbal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpissuedetailSelect(FacBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand("EMP_ISSUE_SOLUTION_DETAIL_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", Objbal.KeyID);
        cmd.Parameters.AddWithValue("@TRAN_BY", Objbal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpAssignDeatil(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_ASSIGN_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@TRANSFER_TO", ObjBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpIssueInprocess(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_IN_PROCESS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@WORK_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@MATERIAL_USED", ObjBal.Value);
        cmd.Parameters.AddWithValue("@ACTION_DT", ObjBal.SrtDate);
        cmd.Parameters.AddWithValue("@ACTION_BY", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpIssueFinish(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_FINISH";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ISSUE_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@WORK_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@MATERIAL_USED", ObjBal.Value);
        cmd.Parameters.AddWithValue("@ACTION_DT", ObjBal.SrtDate);
        cmd.Parameters.AddWithValue("@ACTION_BY", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet EmpIssueTransferTo(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_TRANSFER_TO_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TRANSFER_TO", Objbal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string EmpTransferDelete(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.EmpTransferIssueDelete(ObjBal);
            return "Issue assignment deleted successfully.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    public string EmpMaterialDelete(FacBAL ObjBal)
    {
        try
        {
            FAC_DAL.EmpMaterialDelete(ObjBal);
            return "Selected issue detail deleted successfully.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }
    public DataSet IssueCount(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_ISSUE_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", Objbal.DeptId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public string GetUserId(FacBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("SELECT USR_ID FROM USR_INF WHERE USR_LOGIN_ID = @EMP_ID");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetDataSet(cmd).Tables[0].Rows[0][0].ToString();
    }
    public DataSet GetDetailRoomAlmt(FacBAL objbal)
    {
        cmd = new SqlCommand("FAC_EMP_ROOM_ALMT_DETAIL");
        cmd.Parameters.AddWithValue("@ID", objbal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet TptRegCityCounter()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_REGISTRATION_CITY_COUNT";
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet DeptIssueCnt(FacBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "DEPT_ISSUE_COUNT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region SEND MAIL
    public void SendMail(FacBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "sendMail";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@mailMessage", Objbal.Value);
        cmd.Parameters.AddWithValue("@to", Objbal.Id);
        cmd.Parameters.AddWithValue("@subject", Objbal.Purpose);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion

    #region Harshita
    public DataSet getStuDetailForCancelation(FacBAL ObjBal)
    {
        cmd = new SqlCommand("TPT_GET_STU_DETAIL_FOR_CNCL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Id);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.RateSem);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getStuFinDetailForCancelation(FacBAL ObjBal)
    {
        cmd = new SqlCommand("TPT_GET_STU_FIN_DETAIL_FOR_CNCL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Id);
        cmd.Parameters.AddWithValue("@APP_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.RateSem);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string CancelRegistration(FacBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("TPT_STU_REG_CANCEL");
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@New_Fee_Demand", ObjBal.FeeDemand);
            cmd.Parameters.AddWithValue("@Cancl_Remark", ObjBal.TranRemark);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@Sem_ID", ObjBal.RateSem);
            cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.StuAdmNo);

            return databaseFunctions.GetSingleData(cmd);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public string CancelApproveRegist(FacBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("TPT_STU_REG_CANCEL_APPROVE");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);

            cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.StuAdmNo);

            return databaseFunctions.GetSingleData(cmd);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet UpdateDemamd(FacBAL ObjBal)
    {
        cmd = new SqlCommand("TPT_CANCL_UPDATE_DEMAND");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.StuAdmNo);
        cmd.Parameters.AddWithValue("@New_Fee_Demand", ObjBal.FeeDemand);
        cmd.Parameters.AddWithValue("@Sem_ID", ObjBal.RateSem);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Nisha

    public string HstlRoomChngeInsertByReg(FacBAL objBal)
    {
        try
        {
            FAC_DAL.HstlChngInsertByReg(objBal);
            return "Room Changed Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            FAC_DAL = null;
        }
    }


    #endregion
    #region mk
    public DataSet GetIssueReport(FacBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.EmpId = (ObjBal.EmpId == " ") ? "0" : ObjBal.EmpId;
        ObjBal.Description = (ObjBal.Description == " ") ? "0" : ObjBal.Description;
        cmd = new SqlCommand("GET_ISSUE_TRACKING_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@DATE_TYPE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@FROM_DATE", ObjBal.frdt);
        cmd.Parameters.AddWithValue("@TO_DATE", ObjBal.todt);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@CONCERN_DEPT", ObjBal.Description);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
}

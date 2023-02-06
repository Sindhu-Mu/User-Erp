using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ExaminationDal
/// </summary>
public class ExaminationDal
{
    DatabaseFunctions databaseFunctions;
    SqlCommand cmd;
	public ExaminationDal()
	{
        databaseFunctions = new DatabaseFunctions();
	}
    public string MinorOnlineExamInsert(ExaminationBal ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "MINOR_ONLINE_MAIN_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MINOR_SCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@CRS_CODE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@EXAM_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TT_SLOT_ID", ObjBal.Value);
        cmd.Parameters.AddWithValue("@QUESTION_FILE", ObjBal.View_File);       
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        return databaseFunctions.GetSingleData(cmd);
    }
    public string MinorOnlineExamUpdate(ExaminationBal ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "MINOR_ONLINE_MAIN_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MAINID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@MINOR_SCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@CRS_CODE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@EXAM_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@TT_SLOT_ID", ObjBal.Value);
        cmd.Parameters.AddWithValue("@QUESTION_FILE", ObjBal.View_File);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        return databaseFunctions.GetSingleData(cmd);
    }
    public void MinorOnlineStudentStatus(ExaminationBal ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "MINOR_ONLINE_STUDNET_STATUS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SUB_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
}
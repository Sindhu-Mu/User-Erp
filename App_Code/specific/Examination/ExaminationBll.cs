using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for ExaminationBll
/// </summary>
public class ExaminationBll
{
    ExaminationDal ObjDal;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
	public ExaminationBll()
	{
        databaseFunctions = new DatabaseFunctions();
        ObjDal = new ExaminationDal();
        Msg = new Messages();
	}
    public DataSet GetMinorOnlineMainInfo(ExaminationBal ObjBal)
    {
        cmd = new SqlCommand("MINOR_ONLINE_MAIN_SELECT");       
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    #region Minor Online Exam Insert Update

    public string MinorOnlineMainInsertUpdate(ExaminationBal ObjBal)
    {
        try
        {
            if (ObjBal.Id == "")
            {
                return ObjDal.MinorOnlineExamInsert(ObjBal);
    
            }
            else
            {
               return ObjDal.MinorOnlineExamUpdate(ObjBal);
             
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjDal = null; }
    }
    #endregion
    public DataSet GetMinorOnlinePaperWiseCount(ExaminationBal ObjBal)
    {
        cmd = new SqlCommand("GET_MINOR_ONLINE_PAPER_COUNT");
        cmd.Parameters.AddWithValue("@MAIN_ID", ObjBal.KeyID);        
        cmd.Parameters.AddWithValue("@MINOR_SCH_ID", ObjBal.ExamId);        
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetMinorOnlinePaperStudentDetail(ExaminationBal ObjBal)
    {
        cmd = new SqlCommand("GET_MINOR_ONLINE_STUDENT_DETAIL");
        cmd.Parameters.AddWithValue("@MAIN_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@MINOR_SCH_ID", ObjBal.ExamId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetMinorOnlineExamStudent(ExaminationBal ObjBal)
    {
        cmd = new SqlCommand("GET_MINOR_ONLINE_EXAM_STUDENT");
        cmd.Parameters.AddWithValue("@MAIN_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@MINOR_SCH_ID", ObjBal.ExamId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string MinorOnlineStudentStatus(ExaminationBal ObjBal)
    {

        try
        {          
            ObjDal.MinorOnlineStudentStatus(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjDal = null; }
    }


}
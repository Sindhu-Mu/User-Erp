using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls;


/// <summary>
/// Summary description for TPBLL
/// </summary>
public class TPBLL
{
    DatabaseFunctions databaseFunctions = new DatabaseFunctions();
    SqlCommand cmd;
    CommonFunctions common = new CommonFunctions();
    QueryFunctions queryFunction = new QueryFunctions();

    public TPBLL()
    {


        //
        // TODO: Add constructor logic here
        //
    }
    public void GETCOMPNAME(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_COMPANY_MASTER_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CM_COMPANY_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@CM_COMP_REG_BY ", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@CM_COMP_STATUS", ObjBal.Status);
        databaseFunctions.ExecuteCommand(cmd);
    }

    //public DataSet getBranch()
    //{
    //  return databaseFunctions.GetDataSet(queryFunction.GetCommand(QueryFunctions.QueryBaseType.branch));
    //}
    //public DataSet getProgram()
    //{
    //    return databaseFunctions.GetDataSet(queryFunction.GetCommand(QueryFunctions.QueryBaseType.Course));
    //}
    public void GetMain(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_GET_MAIN_INF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CIT_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@COMP_NAME", ObjBal.Name);
        cmd.Parameters.AddWithValue("@COMP_ADD", ObjBal.Address);
        cmd.Parameters.AddWithValue("@COMP_PHN", ObjBal.Phone);
        cmd.Parameters.AddWithValue("@COMP_EMAIL", ObjBal.Email);
        cmd.Parameters.AddWithValue("@COMP_WEB", ObjBal.Website);
        cmd.Parameters.AddWithValue("@COMP_PROFILE", ObjBal.Profile);
        cmd.Parameters.AddWithValue("@OTHERS",ObjBal.Others);
        cmd.Parameters.AddWithValue("@REG_BY", ObjBal.SessionUserId);
        cmd.Parameters.AddWithValue("@PER_NAME", ObjBal.Per_Name);
        cmd.Parameters.AddWithValue("@PER_PHN", ObjBal.Per_Phn);
        cmd.Parameters.AddWithValue("@PER_ADD", ObjBal.Per_Add);
        cmd.Parameters.AddWithValue("@PER_EMAIL", ObjBal.Per_Email);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet Comp_Detail(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_COMPANY_DETAIL_SELECT";
        //cmd.Parameters.AddWithValue("@COMP_Name", ObjBal.Name);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet PER_DETAIL(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_PERSON_DETAIL_SELECT";
        return databaseFunctions.GetDataSet(cmd);
    }
    
    
    public DataSet Edit_Details(TPBAL ObjBal)
    {
        cmd=new SqlCommand();
        cmd.CommandText="TNP_ACAD_EDIT DETAILS";
        cmd.CommandType=CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment",ObjBal.Enrollment);
        cmd.Parameters.AddWithValue("@PerMob",ObjBal.Per_Phn);
        cmd.Parameters.AddWithValue("@ParMob",ObjBal.Phone);
        cmd.Parameters.AddWithValue("@PerEmail",ObjBal.Per_Email);
        cmd.Parameters.AddWithValue("@DOMAIN",ObjBal.DOM);
        cmd.Parameters.AddWithValue("@HP",ObjBal.HP);
        cmd.Parameters.AddWithValue("@HU",ObjBal.HU);
        cmd.Parameters.AddWithValue("@HY",ObjBal.HY);
        cmd.Parameters.AddWithValue("@SP",ObjBal.SP);
        cmd.Parameters.AddWithValue("@SU",ObjBal.SU);
        cmd.Parameters.AddWithValue("@SY",ObjBal.SY);
        cmd.Parameters.AddWithValue("@GP",ObjBal.GP);
        cmd.Parameters.AddWithValue("@GU",ObjBal.GU);
        cmd.Parameters.AddWithValue("GY",ObjBal.GY);
        //cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enrollment);
        //cmd.Parameters.AddWithValue("@REG_BY", ObjBal.SessionUserId);
        //cmd.Parameters.AddWithValue("@RESUME", ObjBal.Resume);
        //cmd.Parameters.AddWithValue("@ASSISTANCE", ObjBal.Others);
     return databaseFunctions.GetDataSet(cmd);
    }
    public void GetProfile(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_JOB_MAIN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PROFILE", ObjBal.Profile);
        cmd.Parameters.AddWithValue("@COMP_ID", ObjBal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void GetCompProfile(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_COMP_PROFILE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PROFILE", ObjBal.Profile);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void GetIntSchedule(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_INT_SHEDULE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TNP_DATA", ObjBal.xml);
        //cmd.Parameters.AddWithValue("@COMP_ID", ObjBal.Id);
        // cmd.Parameters.AddWithValue("@INT_SHEDULE_MAIN_ID", ObjBal.Main_Id);
        //cmd.Parameters.AddWithValue("@JOB_ID", ObjBal.Job_Id);
        ////cmd.Parameters.AddWithValue("@BRN_ID",ObjBal.branch);
        //cmd.Parameters.AddWithValue("@SEM_ID",ObjBal.sem);
        //cmd.Parameters.AddWithValue("@SAL",ObjBal.Salary);
        //cmd.Parameters.AddWithValue("@VAC",ObjBal.Vaccancy);
        //cmd.Parameters.AddWithValue("@LOCATION", ObjBal.Location);
        //cmd.Parameters.AddWithValue("@SESN",ObjBal.sesn);
        //cmd.Parameters.AddWithValue("@DATE", ObjBal.ToDate);
        //cmd.Parameters.AddWithValue("@OTHERS", ObjBal.Others);

        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet GetIntShedSelect(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_INT_SCHEDULE_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@JOB_PROFILE", ObjBal.Profile);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GETJOBDETAILS(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_JOB_CRITERIA_DETAILS_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public void INT_DETAILS(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_INT_REG_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.Enrollment);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet INT_REG_COMP_DETAIL(TPBAL ObjBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "TNP_INT_REG_COMP_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet INT_REG_COMP_CRITERIA(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_JOB_CRITERIA_DETAILS_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet INT_ATT_SELECT(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_STU_INT_ATT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INTERVIEW_DT", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);

    }
    public void INT_ATT_INSERT(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_STU_INT_ATT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@ADD_DATA", ObjBal.xml);

        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ADD_INT_REG(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_ADD_STU_INT_REG";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ADD_DATA", ObjBal.xml);
        cmd.Parameters.AddWithValue("@INT_SHEDULE_MAIN_ID", ObjBal.Id);
        // cmd.Parameters.AddWithValue("@Enrollment", ObjBal.Enrollment);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public DataSet INT_RESULT(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_INT_RESULT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public void INT_RESULT_INSERT(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_INT_RESULT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ADD_DATA", ObjBal.xml);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public DataSet TNP_TRAINING_LETTER_INSERT(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_TRAINING_LETTER_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.Enrollment);
        cmd.Parameters.AddWithValue("@PRNT_BY", ObjBal.SessionUserId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet TRAINING_LETTER_SELECT(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_TRAINING_LETTER_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@LETTER_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet TRAINING_LETTER_SEL_DETAIL(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_TRAINING_LETTER_SEL_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.Enrollment);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet Resume_update(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_RESUME_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@resume", ObjBal.Resume);
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.Enrollment);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet resume_download(TPBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TNP_resume_download";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Enrollment);
        return databaseFunctions.GetDataSet(cmd);
    }

   
}



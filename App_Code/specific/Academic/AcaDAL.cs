using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


/// <summary>
/// Summary description for AcaDAL
/// </summary>
public class AcaDAL
{
    DatabaseFunctions databaseFunctions;
    SqlCommand cmd;
    public AcaDAL()
    {
        databaseFunctions = new DatabaseFunctions();
    }

    #region RAVIs



    #region ACADEMIC BATCH

    #region Academic Batch Insert
    public void AcaBatchInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BATCH_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BATCH_NAME", obj.KeyValue);
        cmd.Parameters.AddWithValue("@ACA_BATCH_START_DT", obj.Date);
        cmd.Parameters.AddWithValue("@ACA_BATCH_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Academic Bacth Update

    public void AcaBatchUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand("ACA_BATCH_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_BATCH_NAME", obj.KeyValue);
        cmd.Parameters.AddWithValue("@ACA_BATCH_START_DT", obj.Date);
        cmd.Parameters.AddWithValue("@ACA_BATCH_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion
    #region Academic Batch Modify

    public void AcaBatchModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BATCH_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_BATCH_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #endregion

    #region ACADEMIC QUOTA

    #region Academic Quota Insert
    public void QuotaInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_QUOTA_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QUOTA_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@QUOTA_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Academic Quota Update

    public void QuotaUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand("ADM_QUOTA_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QUOTA_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@QUOTA_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@QUOTA_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #region Academic Quota Modify

    public void QuotaModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_QUOTA_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QUOTA_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@QUOTA_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #endregion


    #region ACADEMIC PROGRAM TYPE

    #region Academic Program Type Insert
    public void ProgramTypeInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PRG_TYPE_VALUE", obj.Name);
        cmd.Parameters.AddWithValue("@PRG_TYPE_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Academic Program Type Update
    public void ProgramTypeUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand("PGM_TYPE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PRG_TYPE_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@PRG_TYPE_VALUE", obj.Name);
        cmd.Parameters.AddWithValue("@PRG_TYPE_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Academic Program Type Modify
    public void ProgramTypeModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_TYPE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PRG_TYPE_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@PRG_TYPE_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #endregion



    #region ACADEMIC QUALIFICATION
    #region Academic Qualification Insert
    public void QualificationInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_QUALIFI_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QUALIFI_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@QUALIFI_DESC", obj.Description);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region Academic Qualification Update

    public void QualificationUpdate(AcaBAL obj)
    {
        SqlCommand cmd = new SqlCommand("ACA_QUALIFI_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@QUALIFI_ID", obj.KeyID);
            cmd.Parameters.AddWithValue("@QUALIFI_NAME", obj.Name);
            cmd.Parameters.AddWithValue("@QUALIFI_DESC", obj.Description);
            cmd.Parameters.AddWithValue("@IN_BY", 1120);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Academic Qualification Modify

    public void QualificationModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_QUALIFI_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@QUALIFI_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@QUALIFI_STATUS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #endregion


    #region ENTRANCE EXAM MASTER
    #region Entrance Exam Insert
    public void EntranceExamInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_ENT_EXAM_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENT_EXAM_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@ENT_EXAM_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #region Entrance Exam Update

    public void EntranceExamUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_ENT_EXAM_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENT_EXAM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ENT_EXAM_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@ENT_EXAM_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion

    #region Entrance Exam Modify

    public void EntranceExamModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_ENT_EXAM_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENT_EXAM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ENT_EXAM_STATUS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #endregion

    #region ACADEMIC SUBJECT

    #region Insert
    public void AcaSubjectInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SUB_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SUB_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@ACA_DEPT_ID", obj.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region  Update

    public void AcaSubjectUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand("ACA_SUB_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SUB_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SUB_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@ACA_DEPT_ID", obj.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region Modify

    public void AcaSubjectModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SUB_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SUB_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SUB_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #endregion


    #region ACADEMIC PROGRAN
    #region  Insert
    public void ProgramInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PGM_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@PGM_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@PGM_DURATION", obj.KeyValue);
        cmd.Parameters.AddWithValue("@INS_ID", obj.ValueType);
        cmd.Parameters.AddWithValue("@PGM_TYPE_ID", obj.TypeId);
        cmd.Parameters.AddWithValue("@DGR_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@NDATA", obj.Value);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region  Update

    public void ProgramUpdate(AcaBAL obj)
    {
        SqlCommand cmd = new SqlCommand("INS_PGM_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cmd.Parameters.AddWithValue("@INS_PGM_ID", obj.KeyID);
            cmd.Parameters.AddWithValue("@PGM_FULL_NAME", obj.FullName);
            cmd.Parameters.AddWithValue("@PGM_SHORT_NAME", obj.Name);
            cmd.Parameters.AddWithValue("@PGM_DURATION", obj.KeyValue);
            cmd.Parameters.AddWithValue("@INS_ID", obj.ValueType);
            cmd.Parameters.AddWithValue("@PGM_TYPE_ID", obj.TypeId);
            cmd.Parameters.AddWithValue("@DGR_ID", obj.CommonId);
            cmd.Parameters.AddWithValue("@IN_BY", 1120);
            databaseFunctions.ExecuteCommand(cmd);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion
    #region  Modify

    public void ProgramModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_PGM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@PGM_STATUS", obj.ChangeStatus);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region Academic Program Semester Insert
    #region  Insert
    public void ProgramSemInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_SEM_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;

        //cmd.Parameters.AddWithValue("@FDATA", obj.XmlValue);
        cmd.Parameters.AddWithValue("@PGM_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@PGM_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@PGM_DURATION", obj.KeyValue);
        cmd.Parameters.AddWithValue("@INS_ID", obj.ValueType);
        cmd.Parameters.AddWithValue("@PGM_TYPE_ID", obj.TypeId);
        cmd.Parameters.AddWithValue("@DGR_ID", obj.CommonId);
        //cmd.Parameters.AddWithValue("@ACA_SEM_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        //cmd.Parameters.AddWithValue("@IN_BY", 1120);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    //#region Academic Course Modify
    //public void ProgramSemModify(AcaBAL obj)
    //{
    //    cmd = new SqlCommand();
    //    cmd.CommandText = "INS_PGM_SEM_INF_MODIFY";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@PGM_SEM_ID", obj.KeyID);
    //    cmd.Parameters.AddWithValue("@PGM_SEM_STS", obj.ChangeStatus);
    //    //cmd.Parameters.AddWithValue("@IN_BY", 1120);
    //    cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion
    #endregion


    #endregion


    #region ACADEMIC BRANCH

    #region Academic Branch Insert
    public void AcaBranchInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_BRN_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_PGM_ID", obj.KeyValue);
        cmd.Parameters.AddWithValue("@BRN_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@BRN_SHORT_NAME", obj.Name);
        //cmd.Parameters.AddWithValue("@INST_ID", obj.ValueType);
        //cmd.Parameters.AddWithValue("", obj.Description);
        cmd.Parameters.AddWithValue("@BRN_CAPACITY", obj.CommonId);
        cmd.Parameters.AddWithValue("@BRN_SEM_TYPE", obj.TypeId);
        cmd.Parameters.AddWithValue("@BRN_ROLL_TYPE", obj.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Academic Branch Update

    public void AcaBranchUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_BRN_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", obj.KeyValue);
        cmd.Parameters.AddWithValue("@BRN_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@BRN_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@BRN_CAPACITY", obj.CommonId);
        cmd.Parameters.AddWithValue("@BRN_SEM_TYPE", obj.TypeId);
        cmd.Parameters.AddWithValue("@BRN_ROLL_TYPE", obj.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }

    #endregion
    #region Academic Branch Modify

    public void AcaBranchModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_BRN_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@PGM_BRN_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    #endregion

    #region BOARD MASTER
    #region Board Master Insert
    public void BoardInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BRD_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BRD_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@ACA_BRD_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Board Master Update
    public void BoardUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BRD_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BRD_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_BRD_FULL_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@ACA_BRD_SHORT_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion
    #region Board Master Modify

    public void BoardModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BRD_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_BRD_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@STATUS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion

    #region DOCUMENT MASTER
    #region Insert
    public void DocumentInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_DOC_TYPE_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_VALUE", obj.FullName);
        cmd.Parameters.AddWithValue("@DOC_FOR_ID", obj.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region  Update
    public void DocumentUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand("STU_DOC_TYPE_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@DOC_VALUE", obj.FullName);
        cmd.Parameters.AddWithValue("@DOC_FOR_ID", obj.ValueType);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region Modify
    public void DocumentModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_DOC_TYPE_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@DOC_STATUS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


    #endregion


    #region BRANCH DEPARTMENT MAPPING MASTER

    #region Branch Dept Insert
    public void PgmDeptMapInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DEPT_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", obj.DeptId);
        cmd.Parameters.AddWithValue("@PGM_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Branch Dept Update
    public void PgmDeptMapUpdate(AcaBAL obj)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DEPT_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_PGM_MAP_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@DEPT_ID", obj.DeptId);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Branch Dept Modify
    public void PgmDeptMapModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DEPT_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_PGM_MAP_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@MAP_STATUS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion


    #region DOCUMENT MAPPING

    #region Document Mapping Insert
    public void DocumentMapInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DOC_MAP_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_PGM_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@DOC_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@DOC_QUOTA_ID", obj.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region Document Mapping Update
    public void DocumentMapUpdate(AcaBAL obj)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DOC_MAP_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PGM_DOC_MAP_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@DOC_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@DOC_QUOTA_ID", obj.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region Document Mapping Modify
    public void DocumentMapModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DOC_MAP_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PGM_DOC_MAP_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@DOC_MAP_STATUS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #endregion

    #region SEMESTER MASTER

    #region  Insert
    public void SemesterInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SEM_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SEM_NO", obj.Value);
        cmd.Parameters.AddWithValue("@SEM_TYPE_ID", obj.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region  Update
    public void SemesterUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SEM_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_NO", obj.Value);
        cmd.Parameters.AddWithValue("@SEM_TYPE_ID", obj.KeyValue);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    #endregion

    #region Modify
    public void SemesterModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SEM_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #endregion


    #endregion


    #region BP
    #region STUDENT
    #region SECTION CHANGE

    public void SectionChangeInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_SEC_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@FRM_DT", obj.FromDate);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion

    #region STUDENT INFORMATION SELECT
    public DataSet StudentInfSelect(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_PERSONAL_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.Name);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region STUDENT PERSONAL INFORMATION UPDATE
    public void StudentPersonalInfUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_PERSONAL_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.EmpId);
        cmd.Parameters.AddWithValue("@FIRST_NAME", obj.FullName);
        cmd.Parameters.AddWithValue("@MIDDLE_NAME", obj.Name);
        cmd.Parameters.AddWithValue("@LAST_NAME", obj.KeyValue);
        cmd.Parameters.AddWithValue("@FATHER_NAME", obj.AliasValue);
        cmd.Parameters.AddWithValue("@MOTHER_NAME", obj.Value);
        cmd.Parameters.AddWithValue("@FATHER_OCCUP", obj.ValueType);
        cmd.Parameters.AddWithValue("@MOBILE_NO", obj.DeptId);
        cmd.Parameters.AddWithValue("@STU_MAIL", obj.Description);
        cmd.Parameters.AddWithValue("@GEN_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@DT_OF_BIRTH", obj.Date);
        cmd.Parameters.AddWithValue("@REL_ID", obj.DeptId);
        cmd.Parameters.AddWithValue("@NAT_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@MOT_TON_ID", obj.TypeId);
        cmd.Parameters.AddWithValue("@BLO_GRP_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@CAS_ID", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region STUDENT ACADEMIC INFORMATION UPDATE
    public void StudnetACAInfUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ACA_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.Name);
        cmd.Parameters.AddWithValue("@QUOTA_ID", obj.CommonId);
        cmd.Parameters.AddWithValue("@ENT_EXAM_ID", obj.DeptId);
        cmd.Parameters.AddWithValue("@STU_TEST_RANK", obj.KeyValue);
        cmd.Parameters.AddWithValue("@STU_ENROLL_DT", obj.Date);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region STUDENT BRANCH INFORMATION UPDATE
    public void StudentBRNInfUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_BRN_SEM_INF_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.Name);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", obj.CommonId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region STUDENT PERMANENT ADDRESS INFORMATION INSERT
    public void StuPADRSInfUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ADD_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.KeyID);
        cmd.Parameters.AddWithValue("@ADD_TYPE_ID", 0);
        cmd.Parameters.AddWithValue("@ADD_1", obj.Description);
        cmd.Parameters.AddWithValue("@ADD_2", obj.Name);
        cmd.Parameters.AddWithValue("@CIT_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@FRM_DT", obj.FromDate);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion

    #region STUDENT CORRESPONDANCE ADDRESS INFORMATION INSERT
    public void StuCADRSInfUpdate(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_ADD_CNG_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", obj.KeyID);
        cmd.Parameters.AddWithValue("@ADD_TYPE_ID", 1);
        cmd.Parameters.AddWithValue("@ADD_1", obj.Description);
        cmd.Parameters.AddWithValue("@ADD_2", obj.Name);
        cmd.Parameters.AddWithValue("@CIT_ID", obj.InsId);
        cmd.Parameters.AddWithValue("@FRM_DT", obj.FromDate);
        cmd.Parameters.AddWithValue("@IN_BY", 1110);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #endregion
    #endregion


    #region Priya
    #region Evaluation Scheme
    public SqlCommand GetEvaluationSchemeHeading(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("ACA_GET_EVALUATION_SCHEME_HEADING");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ACA_BACH_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@CRS_BRA_ID", ObjBal.ValueType);
        command.Parameters.AddWithValue("@EVA_SCH_HEADING", ObjBal.Name);
        command.Parameters.AddWithValue("@EVA_SCH_IN_BY", ObjBal.SessionUserID);
        return command;
    }
    public void SaveNewEvaluationScheme(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("ACA_EVA_SCH_SUBJECT_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EVAL_DATA", ObjBal.XmlValue);
        databaseFunctions.ExecuteCommand(command);
    }
    #endregion

    #region Time Table
    public SqlCommand GetClasses(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        //if (ObjBal.Id == null)
        cmd.CommandText = "SELECT CLS_VALUE, CLS_ID FROM TT_CLS_NAME_INF WHERE CLS_STATUS = 1 AND INS_ID = @INS_ID";
        //else
        //{
        //    cmd.CommandText = "SELECT CLS_VALUE, CLS_SEM_ID FROM TT_CLS_NAME_INF INNER JOIN TT_CLS_SEM_INF ON TT_CLS_NAME_INF.CLS_ID = TT_CLS_SEM_INF.CLS_ID WHERE CLS_STATUS = 1 AND INS_ID = @INS_ID AND ACA_BAT_SEM_ID = @SEM_ID";
        //    cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Id);
        //}
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        return cmd;
    }
    public DataSet GetFacClasses(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "TT_GET_FAC_CLASS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetFacInstitute(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "TT_GET_INSTITUTE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    //public void SaveNewClass(AcaBAL ObjBal)
    //{
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandText = "TT_CLS_NAME_INSERT";
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@CLS_VALUE", ObjBal.Name);
    //    cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
    //    cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    public void DeleteClass(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "TT_CLS_NAME_DELETE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CLS_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataSet GetClassdata(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("TT_GET_CLASS_DATA");
        cmd.Parameters.AddWithValue("@CLS_SEM_ID", ObjBal.KeyID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet SaveClassSemester(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("TT_CLS_SEM_INF_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CLS_ID", ObjBal.CommonId);
        cmd.Parameters.AddWithValue("@ACA_BAT_SEM_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void SaveClassCordinator(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_CLS_CORD_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        command.Parameters.AddWithValue("@CLS_SEM_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@CLS_CORD_ID", ObjBal.EmpId);
        databaseFunctions.ExecuteCommand(command);
    }
    public DataSet GetPaperCode(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("TT_GET_PAPER_CODE_MULTI");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BRN_DATA", ObjBal.XmlValue);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetPaperCodeAlt(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("TT_GET_PAPER_CODE_MULTI_ALT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BRN_DATA", ObjBal.XmlValue);
        return databaseFunctions.GetDataSet(cmd);
    }
    public void SavePaperData(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_CLS_PAP_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        command.Parameters.AddWithValue("@CLS_SEM_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@PAP_DATA", ObjBal.XmlValue);
        databaseFunctions.ExecuteCommand(command);

    }
    public void SavePaperMapping(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_CLS_PAP_MAPPING");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@PAP_DATA", ObjBal.XmlValue);
        databaseFunctions.ExecuteCommand(command);

    }

    public DataSet GetPaperData(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("TT_GET_PAPER_DATA");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet SaveTimeTable(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_TIME_TABLE_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID", ObjBal.Id);
        command.Parameters.AddWithValue("@CLS_TYPE_ID", ObjBal.TypeId);
        command.Parameters.AddWithValue("@GRP_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@ROOM_ID", ObjBal.CommonId);
        command.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        command.Parameters.AddWithValue("@DATE_DATA", ObjBal.XmlValue);
        command.Parameters.AddWithValue("@MODE", ObjBal.ChangeStatus);
        command.Parameters.AddWithValue("@INSERT_BY", ObjBal.SessionUserID);

        return databaseFunctions.GetDataSet(command);
    }

    public void DeletePaperData(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_PAPER_COMBINATION_DELETE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID", ObjBal.Id);
        databaseFunctions.ExecuteCommand(command);
    }



    public void SaveFacultyType(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "TT_FACULTY_TYPE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TT_FAC_TYPE_VALUE", ObjBal.Name);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet GetFacultyTypeData(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_FACULTY_TYPE_DATA");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(command);
    }

    public string AssignFaculty(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "TT_ASSIGN_FACULTY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FAC_TYPE_ID", ObjBal.CommonId);
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@FROM_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@TO_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@USR_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@ASN_BY", ObjBal.SessionUserID);
        return databaseFunctions.GetSingleData(cmd);
    }

    public DataSet GetTimeTable(AcaBAL ObjBal)
    {
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        SqlCommand command = new SqlCommand("GET_TIME_TABLE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        command.Parameters.AddWithValue("@CLS_SEM_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@FIRST_DATE", ObjBal.FromDate);
        command.Parameters.AddWithValue("@SECOND_DATE", ObjBal.ToDate);
        command.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(command);
    }
    public DataSet GetTimeTable1(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("GET_TIME_TABLE1");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        command.Parameters.AddWithValue("@CLS_SEM_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@FIRST_DATE", ObjBal.FromDate);
        command.Parameters.AddWithValue("@SECOND_DATE", ObjBal.ToDate);
        return databaseFunctions.GetDataSet(command);
    }

    #endregion

    #region Student Group
    public DataSet GetStudentData(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_STUDENT_DATA");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(command);
    }

    public void SaveStuGroup(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_STU_GRP_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@GRP_ID", ObjBal.TypeId);
        command.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        command.Parameters.AddWithValue("@FROM_DATE", ObjBal.Date);
        command.Parameters.AddWithValue("@STU_DATA", ObjBal.XmlValue);
        databaseFunctions.ExecuteCommand(command);
    }
    public void CopyStuGroup(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_INSERT_STUDENT_GRP_BY_EXISTING_GRP");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID_EXT", ObjBal.KeyID);
        command.Parameters.AddWithValue("@TT_ID", ObjBal.TypeId);
        command.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(command);
    }

    public DataSet GetPaperCodeForGrp(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_CODE_OF_EXISTING_GRP");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CLS_SEM_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(command);
    }

    #endregion

    #region Student Attendance
    public string GetEvaSchID(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("SELECT EVA_SCH_ID FROM ACA_EVALUATION_SCHEME_INF WHERE PGM_BRN_ID = " + ObjBal.CommonId + " AND ACA_BATCH_ID = " + ObjBal.KeyID);
        //command.CommandType = CommandType.Text;
        //command.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.CommonId);
        //command.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(command).Tables[0].Rows[0][0].ToString();
    }

    public DataSet GetStudentForAtt(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_STUDENT_FOR_ATT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@SEM_ID", ObjBal.TypeId);
        command.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.CommonId);
        return databaseFunctions.GetDataSet(command);
    }

    public DataSet GetClassStudent(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_CLS_STUDENT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_DET_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(command);
    }

    public void SaveAttendance(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_STU_ATT_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@DATA", ObjBal.XmlValue);
        databaseFunctions.ExecuteCommand(command);
    }

    public void BlockClassData(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_BLOCK_CLASS");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_DET_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@TT_ATT_MIS_REM", ObjBal.Description);
        databaseFunctions.ExecuteCommand(command);
    }

    public DataSet GetMissingStudentAttendanceDetails(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_MISSING_STUDENT_ATTENDANCE_DETAIL");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("STU_MAIN_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("TT_PAP_ID", ObjBal.Id);
        command.Parameters.AddWithValue("USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(command);
    }
    public void SaveAttendanceLate(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_STU_ATT_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@DATA", ObjBal.XmlValue);
        command.Parameters.AddWithValue("@IS_LATE", ObjBal.AliasValue);
        databaseFunctions.ExecuteCommand(command);
    }

    public string SaveStudentAttendanceCredit(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("STU_ATT_CREDIT_INF_INSERT");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CR_TYPE_ID", ObjBal.TypeId);
        command.Parameters.AddWithValue("@ENROLL", ObjBal.KeyID);
        command.Parameters.AddWithValue("@APPROVED_BY", ObjBal.EmpId);
        command.Parameters.AddWithValue("@APPROVED_DT", ObjBal.Date);
        command.Parameters.AddWithValue("@CR_FROM", ObjBal.FromDate);
        command.Parameters.AddWithValue("@CR_TO", ObjBal.ToDate);
        command.Parameters.AddWithValue("@CR_REMARK", ObjBal.Description);
        command.Parameters.AddWithValue("@CR_BY", ObjBal.SessionUserID);

        return databaseFunctions.GetSingleData(command);
    }

    public void DeleteStudentAttendanceCredit(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("STU_ATT_CREDIT_INF_DELETE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@CR_ID", ObjBal.Id);

        databaseFunctions.ExecuteCommand(command);
    }

    public DataSet StudentAttendenceCreditDetail(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = "SELECT CREDIT_TYPE_INF.CREDIT_NAME, STU_ATT_CREDIT_INF.CR_FROM, STU_ATT_CREDIT_INF.CR_TO, STU_ATT_CREDIT_INF.APPROVED_DT, "
            + "STU_ATT_CREDIT_INF.CR_REMARK, STU_ATT_CREDIT_INF.CR_ID, EMP_VIEW.EMP_NAME+'('+ EMP_VIEW.DES_VALUE+')' AS 'EMP_NAME', @ENROLL AS 'ENROLL' "
            + "FROM STU_ATT_CREDIT_INF INNER JOIN CREDIT_TYPE_INF ON STU_ATT_CREDIT_INF.CR_TYPE_ID = CREDIT_TYPE_INF.CR_TYPE_ID INNER JOIN "
            + "EMP_VIEW ON STU_ATT_CREDIT_INF.APPROVED_BY = EMP_VIEW.EMP_ID WHERE CR_STATUS=1 AND STU_MAIN_ID=DBO.GET_STU_MAIN_ID(@ENROLL)";
        command.Parameters.AddWithValue("@ENROLL", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(command);
    }

    public DataSet GetAttClsNamePerDetails(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_ATT_CLS_PERCENTAGE_DETAIL");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@GRP_ID", ObjBal.CommonId);
        command.Parameters.AddWithValue("@CLS_TYPE_ID", ObjBal.TypeId);
        command.Parameters.AddWithValue("@SEC_ID", ObjBal.DeptId);
        command.Parameters.AddWithValue("@HELD", ObjBal.Description);
        command.Parameters.AddWithValue("@MARKED", ObjBal.ChangeStatus);
        command.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(command);
    }
    public DataSet GetDailyAttSummaryForCord(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_DAILY_ATT_SUMMARY_FOR_CORD");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("INS_ID", ObjBal.InsId);
        if (ObjBal.KeyID != "" && ObjBal.KeyID != ".")
            command.Parameters.AddWithValue("CLS_ID", ObjBal.KeyID);
        if (ObjBal.CommonId != "" && ObjBal.CommonId != ".")
            command.Parameters.AddWithValue("ACA_BAT_SEM_ID", ObjBal.CommonId);
        if (ObjBal.Date.ToString() != "1/1/0001 12:00:00 AM")
            command.Parameters.AddWithValue("DATE", ObjBal.Date);
        command.Parameters.AddWithValue("ATT_STS", ObjBal.ChangeStatus);
        return databaseFunctions.GetDataSet(command);
    }

    public DataSet GetAttendanceDetails(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_ATT_DETAIL");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_DET_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(command);
    }

    public DataSet GetAttendanceDailyAtt(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_STUDENT_PAPER_ATTENDANCE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        command.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(command);
    }

    public DataSet DeleteStudentAtt(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_ATT_DELETE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@TT_DET_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(command);
    }
    public DataSet GetStudentDetainPercentage(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("GET_STUDENT_DETAIN_PERCENTAGE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("BRANCH_ID", ObjBal.Brn_Id);
        command.Parameters.AddWithValue("SEM", ObjBal.Semid);
        command.Parameters.AddWithValue("PAPER_TYPE", ObjBal.TypeId);
        command.Parameters.AddWithValue("PERCENTAGE", ObjBal.Value);
        command.Parameters.AddWithValue("MAX_DATE", ObjBal.Date.ToString("MM/dd/yyyy"));
        return (databaseFunctions.GetDataSet(command));
    }

    #endregion
    #endregion

    #region PRACHI
    #region Event Master Insert
    public void EventInsert(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_EVENT_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_EVENT_VALUE", objbal.Name);
        cmd.Parameters.AddWithValue("@ACA_EVENT_DESC", objbal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", objbal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Update New Event
    public void UpdateNewEvent(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("ACA_EVENT_INF_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_EVENT_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@ACA_EVENT_VALUE", ObjBal.Name);
        cmd.Parameters.AddWithValue("@ACA_EVENT_DESC", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Modify NEW EVENT
    public void EventModify(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_EVENT_INF_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ACA_EVENT_ID", objbal.Id);
        cmd.Parameters.AddWithValue("@ACA_EVENT_STS", objbal.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", objbal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region INSERT EVNT SCHEDULE
    public void EventSchInsert(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EVENT_SCH_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EVENT_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@START_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@END_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@USE_BY", ObjBal.UseFor);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region UPDATE EVENT SCHEDULE
    public void EventSChUpdate(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EVENT_SCH_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@EVENT_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SRT_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@END_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@USE_BY", ObjBal.UseFor);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region MODIFY EVENT SCHEDULE
    public void EventSchModify(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EVENT_SCH_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region UPLOAD EVENT DOCUMENT
    public void UploadEventDocument(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_EVENT_UPLOAD_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FILE", ObjBal.FullName);
        cmd.Parameters.AddWithValue("@S_NO", ObjBal.Value);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region Insert NOTICE
    public void InsertNotice(AcaBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "NOTICE_ADD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NEWS_DT", Objbal.Date);
        cmd.Parameters.AddWithValue("@EXPIRED_ON", Objbal.ToDate);
        cmd.Parameters.AddWithValue("@HEADING", Objbal.Name);
        cmd.Parameters.AddWithValue("@NOTICE_FOR", Objbal.UseFor);
        cmd.Parameters.AddWithValue("@NOTICE_DIS", Objbal.Display);
        cmd.Parameters.AddWithValue("@DESC", Objbal.Description);
        cmd.Parameters.AddWithValue("@FILE_TYPE", Objbal.TypeId);
        cmd.Parameters.AddWithValue("@FILE_PATH", Objbal.File);
        cmd.Parameters.AddWithValue("@IN_BY", Objbal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region MODIFY NOTICE
    public void NoticeModify(AcaBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "MODIFY_NOTICE_CIRCULAR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NEWS_ID", objBal.Id);
        cmd.Parameters.AddWithValue("@STS", objBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region UPDATE NOTICE
    public void UpdateNotice(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_NOTICE_CIRCULAR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@NEWS_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@NEWS_DT", ObjBal.Date);
        cmd.Parameters.AddWithValue("@EXPIRE_DT", ObjBal.ToDate);
        cmd.Parameters.AddWithValue("@NOTICE_FOR", ObjBal.UseFor);
        cmd.Parameters.AddWithValue("@HEADING", ObjBal.Name);
        cmd.Parameters.AddWithValue("@DISPLAY", ObjBal.Display);
        cmd.Parameters.AddWithValue("@DESCRIPTION", ObjBal.Description);
        cmd.Parameters.AddWithValue("@VIEW_FILE", ObjBal.View_File);
        cmd.Parameters.AddWithValue("@DW_FILE", ObjBal.File);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region UPDATE STU STATUS
    public void UpdateSts(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STS_STU_CNG_INF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLL", ObjBal.Id);
        cmd.Parameters.AddWithValue("@STU_STS_ID", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@STU_FRM_DT", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@TRAN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Value);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region STUDENT DOC ISSUE
    public string StuDocInsert(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_DOC_ISSUE_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@SIGN_BY", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@ISSUE_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        cmd.Parameters.AddWithValue("@ISSUE_TYPE", ObjBal.TypeId);
        return databaseFunctions.GetSingleData(cmd);
    }
    #endregion
    #region STUDENT INFROMATION CHANGE
    public void StuPhnCng(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_STUDENT_PHONE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@PHN_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@PHN_NO", ObjBal.Phn_No);
        cmd.Parameters.AddWithValue("@FATHER_NAME", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@MOTHER_NAME", ObjBal.Value2);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void StuParPhnCng(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPADATE_PARENT_PHONE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@PHN_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@PHN", ObjBal.Par_Phn_No);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void StuMailCng(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_STUDENT_MAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@VALUE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@ID", ObjBal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region STUDENT MENTOR ASSIGN
    public void AssignMentor(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "MENTOR_ASSIGN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlValue);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void ReAssign_Mentor(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_REASSIGN_MENTOR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USER_ID", ObjBal.EmpId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void DeleteMentorStudnet(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "DELETE_STUDENT_MENTOR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void AddMEntorStu(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "ADD_STUDENT_MENTOR";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region STUDENT INF CNG
    public void StuInfCNgApp(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "GET_STU_INF_CHANGE_APPROVE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_INF_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@PROC_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    public DataSet GetStuDetainPrintDetail(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("GET_STUDENT_DETAIN_PRINT_DETAILS");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("BRANCH_ID", ObjBal.Brn_Id);
        command.Parameters.AddWithValue("SEM", ObjBal.Semid);
        command.Parameters.AddWithValue("PAPER_TYPE", ObjBal.TypeId);
        command.Parameters.AddWithValue("PERCENTAGE", ObjBal.Value);
        command.Parameters.AddWithValue("MAX_DATE", ObjBal.Max_Dt);
        command.Parameters.AddWithValue("TYPE", ObjBal.UseFor);
        return (databaseFunctions.GetDataSet(command));
    }
    #endregion
    #region Internal Marks
    public void InternalMarksInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_INT_EXAM_MARKS_INF_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XLM_DATA", obj.XmlValue);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_SUB_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion
    #region SPECIAL MINOR
    public DataSet StuSpecialMinir(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("INSERT_SPECIAL_MINOR_MARKS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public void UpdateFeeDefaulter(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "UPDATE_FEE_DEFAULTERS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Description);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Stu_AdmNo);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void VerfiyStudentMarks(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_MARKS_VERIFY_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@EVA_SCH_SUB_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void UpdateReRegSts(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_UPDATE_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@APR_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@XLM_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Value);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public void SendRemark(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_SEND_REMARK";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@APR_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Value);
        cmd.Parameters.AddWithValue("@SEM_REG_DTL_ID", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #region Academic Student Detained

    public void StudentDetainedModify(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FINAL_ATT_MODIFY";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ATT_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@DET_STS", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    #endregion
    public void UpdateIntMarks(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("STU_INT_MARKS_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_SUB_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@INT_ATT_STS", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@INT_MARKS", ObjBal.Marks);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);

    }
    public void regblockInsert(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "REG_BLOCK_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", objbal.Enroll_No);
        cmd.Parameters.AddWithValue("@REG_BLOCK_STS", objbal.ChangeStatus);
        cmd.Parameters.AddWithValue("@REMARK", objbal.Remark);
        cmd.Parameters.AddWithValue("@BLOCK_BY", objbal.SessionUserID);

        databaseFunctions.ExecuteCommand(cmd);
    }
    public void changeblockStatus(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "REG_BLOCK_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@stu_main_id", objbal.Enroll_No);
        cmd.Parameters.AddWithValue("@status", objbal.ChangeStatus);
        cmd.Parameters.AddWithValue("@BLOCK_BY", objbal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    #region Mudit
    #region Detain Marks
    public void DetainedMarksInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_DETAINED_MARKS_INFO_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XLM_DATA", obj.XmlValue);
        cmd.Parameters.AddWithValue("@EXAM_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
       

        databaseFunctions.ExecuteCommand(cmd);
    }
    #endregion


#endregion

    public void SecChngInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "Section_Change_Insert";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XLM_DATA", obj.XmlValue);
        //cmd.Parameters.AddWithValue("@Sec_Id", obj.Sec_Id);
        //cmd.Parameters.AddWithValue("@In_By", obj.InsertBy);
        //cmd.Parameters.AddWithValue("@Remark", obj.Remark);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public string StudnetUpgradeAction(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STUDENT_SEMESTER_UPGRADE_ACTION";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XML_DATA", obj.XmlValue);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@ACTION", obj.ChangeStatus);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        return databaseFunctions.GetSingleData(cmd);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;
using rw;

/// <summary>
/// Summary description for AcaBLL
/// </summary>
public class AcaBLL
{
    AcaDAL ACA_DAL;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    public AcaBLL()
    {
        databaseFunctions = new DatabaseFunctions();
        ACA_DAL = new AcaDAL();
        Msg = new Messages();
    }
    public DataTable GetStudentDocument(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STUDENT_DOCUMENT");
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@QUOTA_ID", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetResultSummaryForCourseFile(AcaBAL ObjBal)
    {
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.KeyValue = (ObjBal.KeyValue == "." || ObjBal.KeyValue == "") ? "0" : ObjBal.KeyValue;
        cmd = new SqlCommand("GET_RESULT_SUMMARY_FOR_COURSE_FILE");
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.Value);
        cmd.Parameters.AddWithValue("@CRS_CODE", ObjBal.KeyValue);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetCordinatorClass(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("TT_CLASS_CORDINATOR_SELECT");
        cmd.Parameters.AddWithValue("@login_id", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@sem_id", ObjBal.Semid);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public DataTable GetCordinatorClassCount(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_CLASS_ATT_COUNTER");
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@CLS_CORD_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);

        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetTTStudent(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_TT_STUDENT");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@GRP_ID", ObjBal.TypeId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetTTFaculty(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_TT_Faculty");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@GRP_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@CLS_TYPE_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetInternalMarksStudent(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_INTERNAL_MARKS_STUDENT");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@GRP_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_SUB_ID", ObjBal.Id);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    public DataTable GetTTStatus(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("GET_TT_STATUS");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@GRP_ID", ObjBal.TypeId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #region Abhinav
    #region StudentFinance
    public void InsertFeeConcession(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("STU_FIN_INSERT_CONCESSION");
        cmd.Parameters.AddWithValue("@MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@RULE_ID", ObjBal.BAL_RULE_ID);
        cmd.Parameters.AddWithValue("@SESSION_ID", ObjBal.BAL_SESSION_ID);
        cmd.Parameters.AddWithValue("@APPLIED_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@URL", ObjBal.Value);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        databaseFunctions.GetDataSet(cmd);
    }
    public DataTable SelectFeeConcession(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("STU_FIN_SELECT_CONCESSION");
        cmd.Parameters.AddWithValue("@MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #endregion
    #endregion

    #region Ravi
    #region ACADEMIC BATCH MASTER
    #region Academic Batch Select

    public DataSet AcaBatchSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BATCH_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion



    #region Academic Batch Insert Update
    public string AcaBatchInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.AcaBatchInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.AcaBatchUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #region Academic Batch  Modify
    public string AcaBatchModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.AcaBatchModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #endregion


    #region ACADEMIC QUOTA MASTER
    #region Academic Quota Select

    public DataSet QuotaSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_QUOTA_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Academic Quota Insert And Update

    public string QuotaInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.QuotaInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.QuotaUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }



    #endregion

    #region Academic Quota  Modify
    public string QuotaModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.QuotaModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }



    #endregion
    #endregion



    #region ACADEMIC QUALIFICATION MASTER
    #region Academic Qualification Select

    public DataSet QualificationSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_QUALIFI_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion


    #region Academic Qualification Insert
    public void QualificationInsert(AcaBAL obj)
    {

        try
        {
            ACA_DAL.QualificationInsert(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region Academic Qualification Update

    public void QualificationUpdate(AcaBAL obj)
    {
        try
        {
            ACA_DAL.QualificationUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #region Academic Qualification  Modify
    public void QualificationModify(AcaBAL obj)
    {
        try
        {
            ACA_DAL.QualificationModify(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #endregion

    #region ENTRANCE EXAM MASTER
    #region Entrance  Exam Select

    public DataSet EntranceExamSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ADM_ENT_EXAM_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Entrance Exam Insert And Update

    public string EntranceExamInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.EntranceExamInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.EntranceExamUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #region Entrance Exam  Modify
    public string EntranceExamModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.EntranceExamModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #endregion

    public DataSet GetClassCounter(AcaBAL ObjBal)
    {
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SUB_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region ACADEMIC SUBJECT MASTER

    #region Academic Subject Select
    public DataSet AcaSubjectSelect(AcaBAL ObjBal)
    {

        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SUB_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Academic Subject Insert And Update
    public string AcaSubjectInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.AcaSubjectInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.AcaSubjectUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }




    #endregion

    #region Academic Subject  Modify

    public string AcaSubjectModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.AcaSubjectModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }


    #endregion

    #endregion


    #region ACADEMIC Program
    #region  Select
    public DataSet ProgramSelect(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ((ObjBal.InsId == ".") ? "0" : ObjBal.InsId));
        cmd.Parameters.AddWithValue("@PGM_TYPE_ID", ((ObjBal.ValueType == ".") ? "0" : ObjBal.ValueType));
        cmd.Parameters.AddWithValue("@PGM_DGR_ID", ((ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID));

        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion



    #region   Modify
    public string ProgramModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.ProgramModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region Insert Update

    public string ProgramInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.ProgramInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.ProgramUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region   Program Semester Select
    public DataSet ProgramSemSelect(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_SEM_INF_SELECT";
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", obj.InsId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion



    #endregion


    #region ACADEMIC BRANCH MASTER
    #region Academic Branch Select
    public DataSet AcaBranchSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "INS_PGM_BRN_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion



    #region Academic Branch Insert Update

    public string AcaBranchInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.InsId == "")
            {
                ACA_DAL.AcaBranchInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.AcaBranchUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region Academic Branch  Modify
    public string AcaBranchModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.AcaBranchModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #endregion

    #region ACADEMIC PROGRAM TYPE MASTER
    #region Academic Program Type Select
    public DataSet ProgramTypeSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion

    #region Academic Program Type Insert

    public string ProgramTypeInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.ProgramTypeInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.ProgramTypeUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #region Academic Program Type Modify

    public string ProgramTypeModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.ProgramTypeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion


    #endregion

    #region BOARD MASTER
    #region Board Master Select

    public DataSet BoardSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_BRD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Board Master Insert Update

    public string BoardInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.BoardInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.BoardUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }


    #endregion
    #region Board Master Modify
    public string BoardModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.BoardModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion
    #endregion


    #region EVENT MASTER
    #region Event Master Select
    public DataSet EventSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_EVENT_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #endregion

    #region DOCUMENT MASTER
    #region Document Master Select
    public DataSet DocumentSelect(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_DOC_TYPE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DOC_FOR_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Document Master Insert Update
    public string DocumentInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.DocumentInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.DocumentUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion
    #region Document Master Modify
    public string DocumentModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.DocumentModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #endregion

    #region BRANCH DEPARTMENT MASTER
    #region Branch Department Select
    public DataSet PgmDeptMapSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DEPT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion


    #region Branch Department Insert Update

    public string PgmDeptMapInsertUpdate(AcaBAL ObjBal)
    {
        try
        {

            if (ObjBal.KeyID == "")
            {

                ACA_DAL.PgmDeptMapInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.PgmDeptMapUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #region Branch Department Modify
    public string PgmDeptMapModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.PgmDeptMapModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion
    #endregion



    #region DOCUMENT MAPPING
    #region Document Mapping Select
    public DataSet DocumentMapSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "PGM_DOC_MAP_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Document Mapping Insert & Update

    public string DocumentMapInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.DocumentMapInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.DocumentMapUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }


    #endregion

    #region Docment Mapping Modify

    public string DocumentMapModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.DocumentMapModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #endregion


    #region SEMESTER MASTER
    #region Semester Master Select
    public DataSet SemesterSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_SEM_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion


    #region Semester Master Insert And Update
    public string SemesterInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.KeyID == "")
            {
                ACA_DAL.SemesterInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.SemesterUpdate(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion


    #region Semester Master Modify

    public string SemesterModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.SemesterModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion

    #endregion
    #endregion

    #region BP
    #region STUDENT
    #region SECTION CHANGE
    public void SectionChange(AcaBAL obj)
    {
        try
        {
            ACA_DAL.SectionChangeInsert(obj);

        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region STUDENT INFORMATION SELECT
    public DataSet StudentInfSelect(AcaBAL obj)
    {
        try
        {
            return ACA_DAL.StudentInfSelect(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region STUDENT PERSONAL INFORMATION UPDTAE
    public void StudentPERSInfUpdate(AcaBAL obj)
    {
        try
        {
            ACA_DAL.StudentPersonalInfUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region STUDENT ACADEMIC INFORMATION UPDTAE
    public void StudentACAInfUpdate(AcaBAL obj)
    {
        try
        {
            ACA_DAL.StudnetACAInfUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region STUDENT BRANCH INFORMATION UPDTAE
    public void StudentBRNInfUpdate(AcaBAL obj)
    {
        try
        {
            ACA_DAL.StudentBRNInfUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    #region STUDENT PERMANENT INFORMATION INFORMATION UPDATE
    public void StudentPADRSInfUpdate(AcaBAL obj)
    {
        try
        {
            ACA_DAL.StuPADRSInfUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
    }
    #endregion

    #region STUDENT CORRESPONDANCE INFORMATION INFORMATION UPDATE
    public void StudentCADRSInfUpdate(AcaBAL obj)
    {
        try
        {
            ACA_DAL.StuCADRSInfUpdate(obj);
        }
        catch (Exception ex)
        { throw ex; }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #endregion
    #endregion

    #region Priya
    #region Evaluation Scheme
    #region Get SQL Command
    public SqlCommand GetSubjectName()
    {
        SqlCommand command = new SqlCommand("SELECT ACA_SUB_NAME, ACA_SUB_ID FROM ACA_SUBJECT_INF WHERE ACA_SUB_STS = 1 ORDER BY ACA_SUB_NAME");
        command.CommandType = CommandType.Text;
        return command;
    }

    public SqlCommand GetSemester()
    {
        SqlCommand command = new SqlCommand("SELECT ACA_SEM_NO, ACA_SEM_ID FROM ACA_SEM_INF WHERE ACA_SEM_STS = 1 ");
        command.CommandType = CommandType.Text;
        return command;
    }

    public SqlCommand EvaluationSchemeHeading(AcaBAL objBal)
    {
        SqlCommand command = new SqlCommand("SELECT EVA_SCH_HEADING, EVA_SCH_ID FROM ACA_EVALUATION_SCHEME_INF WHERE ACA_BATCH_ID = @ACA_BACH_ID AND PGM_BRN_ID = @PGM_BRN_ID AND EVA_SCH_STS = 1 ");
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@ACA_BACH_ID", objBal.KeyID);
        command.Parameters.AddWithValue("@PGM_BRN_ID", objBal.ValueType);
        return command;
    }

    public SqlCommand GetMarksTemplate(AcaBAL objBal)
    {
        SqlCommand command = new SqlCommand("SELECT EXAM_TEMP_MAIN_HEAD, EXAM_TEMP_MAIN_ID FROM ACA_EXAM_TEMP_MAIN_INF WHERE SUB_TYPE_ID = @SUB_TYPE_ID AND EXAM_TEMP_MAIN_STS = 1");
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@SUB_TYPE_ID", objBal.TypeId);
        return command;
    }

    public SqlCommand GetMarksTemplateDetails(AcaBAL objBal)
    {
        SqlCommand command = new SqlCommand("SELECT EXAM_TYPE_SUB_HEAD,EXAM_MAX_MARKS AS MARKS FROM ACA_EXAM_TEMP_MAIN_INF INNER JOIN "
            + "ACA_EXAM_TEMP_SUB_INF ON ACA_EXAM_TEMP_MAIN_INF.EXAM_TEMP_MAIN_ID = ACA_EXAM_TEMP_SUB_INF.EXAM_TEMP_MAIN_ID INNER JOIN "
            + "ACA_EXAM_TYPE_SUB_INF ON ACA_EXAM_TEMP_SUB_INF.EXAM_TYPE_SUB_ID = ACA_EXAM_TYPE_SUB_INF.EXAM_TYPE_SUB_ID WHERE ACA_EXAM_TEMP_MAIN_INF.EXAM_TEMP_MAIN_ID = @EXAM_TEMP_MAIN_ID");
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@EXAM_TEMP_MAIN_ID", objBal.Id);
        return command;
    }

    public SqlCommand GetEvaluationSchemeHeading(AcaBAL ObjBal)
    {
        return ACA_DAL.GetEvaluationSchemeHeading(ObjBal);
    }

    public SqlCommand GetExistingPapers(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("ACA_GET_EXISTING_PAPERS");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.CommonId);
        command.Parameters.AddWithValue("@EVA_SCH_ID", ObjBal.FullName);
        return command;
    }
    #endregion

    public string SaveNewEvaluationScheme(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SaveNewEvaluationScheme(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return "Dublicate data can not insert.";
        }

    }
    #endregion

    #region Time Table
    public SqlCommand GetClasses(AcaBAL ObjBal)
    {
        return ACA_DAL.GetClasses(ObjBal);
    }
    public DataSet GetFacClasses(AcaBAL ObjBal)
    {
        return ACA_DAL.GetFacClasses(ObjBal);
    }
    public DataSet GetFacInstitute(AcaBAL ObjBal)
    {
        return ACA_DAL.GetFacInstitute(ObjBal);
    }
    public SqlCommand GetClassPaper(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_CLASS_PAPER";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CLS_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Semid);
        return cmd;
    }
    public SqlCommand GetPaperForMapping(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_PAPER_FOR_MAPPING";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@BRANCH", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@SECTION", ObjBal.TypeId);
        return cmd;
    }
    //public string SaveNewClass(AcaBAL ObjBal)
    //{
    //    try
    //    {
    //        ACA_DAL.SaveNewClass(ObjBal);
    //        return Msg.GetMessage(Messages.DataMessType.Insert);
    //    }
    //    catch
    //    {
    //        return "Class already exists with this name ! Enter unique name.";
    //    }
    //    finally
    //    {
    //        ACA_DAL = null;
    //    }
    //}

    public string SaveClassCordinator(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SaveClassCordinator(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public string DeleteClass(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.DeleteClass(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public DataSet GetClassData(AcaBAL ObjBal)
    {
        return ACA_DAL.GetClassdata(ObjBal);
    }
    public DataSet SaveClassSemester(AcaBAL ObjBal)
    {
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        return ACA_DAL.SaveClassSemester(ObjBal);
    }
    public DataSet GetPaperCode(AcaBAL ObjBal)
    {
        return ACA_DAL.GetPaperCode(ObjBal);
    }
    public DataSet GetPaperCodeAlt(AcaBAL ObjBal)
    {
        return ACA_DAL.GetPaperCodeAlt(ObjBal);
    }
    public string SavePaperData(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SavePaperData(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public string SavePaperMapping(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SavePaperMapping(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {

        }
    }
    public DataSet GetPaperData(AcaBAL ObjBal)
    {
        return ACA_DAL.GetPaperData(ObjBal);
    }
    public XmlDocument GetXMLForTT(AcaBAL ObjBal, CheckBoxList chkDays)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT = xmlData.CreateElement("TT");
        xmlData.AppendChild(ROOT);

        DateTime startDate = ObjBal.FromDate;
        DateTime endDate = ObjBal.ToDate;

        XmlElement dataElement;
        XmlElement element;

        switch (Convert.ToInt32(ObjBal.Value))   //ddlReoccurance.SelectedValue
        {
            case 0:
                dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                element = xmlData.CreateElement("DATE");
                element.InnerText = startDate.ToString();
                dataElement.AppendChild(element);

                element = xmlData.CreateElement("TIME");
                element.InnerText = ObjBal.KeyID;
                dataElement.AppendChild(element);

                break;
            case 1:
                for (; startDate <= endDate; )
                {
                    dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    element = xmlData.CreateElement("DATE");
                    element.InnerText = startDate.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("TIME");
                    element.InnerText = ObjBal.KeyID;
                    dataElement.AppendChild(element);
                    startDate = startDate.AddDays(1);
                }
                break;
            case 2:
                for (; startDate <= endDate; )
                {
                    dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    element = xmlData.CreateElement("DATE");
                    element.InnerText = startDate.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("TIME");
                    element.InnerText = ObjBal.KeyID;
                    dataElement.AppendChild(element);

                    startDate = startDate.AddDays(7);
                }
                break;
            case 3:
                for (; startDate <= endDate; )
                {
                    dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    element = xmlData.CreateElement("DATE");
                    element.InnerText = startDate.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("TIME");
                    element.InnerText = ObjBal.KeyID;
                    dataElement.AppendChild(element);

                    startDate = startDate.AddMonths(1);
                }
                break;
            case 4:
                for (; startDate <= endDate; )
                {
                    dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    element = xmlData.CreateElement("DATE");
                    element.InnerText = startDate.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("TIME");
                    element.InnerText = ObjBal.KeyID;
                    dataElement.AppendChild(element);

                    startDate = startDate.AddDays(14);
                }
                break;
            case 5:
                for (; startDate <= endDate; )
                {
                    dataElement = xmlData.CreateElement("DATA");
                    ROOT.AppendChild(dataElement);

                    element = xmlData.CreateElement("DATE");
                    element.InnerText = startDate.ToString();
                    dataElement.AppendChild(element);

                    element = xmlData.CreateElement("TIME");
                    element.InnerText = ObjBal.KeyID;
                    dataElement.AppendChild(element);

                    foreach (ListItem days in chkDays.Items)
                    {
                        if (days.Selected == true)
                        {

                            dataElement = xmlData.CreateElement("DATA");
                            ROOT.AppendChild(dataElement);

                            element = xmlData.CreateElement("DATE");
                            element.InnerText = startDate.AddDays(Convert.ToInt32(days.Value) - Convert.ToInt32(startDate.DayOfWeek)).ToString();
                            dataElement.AppendChild(element);
                            element = xmlData.CreateElement("TIME");
                            element.InnerText = ObjBal.KeyID;
                            dataElement.AppendChild(element);
                        }
                    }

                    startDate = startDate.AddDays(7);
                }
                break;
            default:
                break;
        }
        return xmlData;
    }
    public DataSet SaveTimeTable(AcaBAL ObjBal)
    {
        return ACA_DAL.SaveTimeTable(ObjBal);
    }
    public string DeletePaperData(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.DeletePaperData(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public DataSet GetFacultyType()
    {
        cmd = new SqlCommand("SELECT TT_FAC_TYPE_VALUE FROM TT_FAC_TYPE_INF WHERE TT_FAC_TYPE_STS=1");
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetCourseExamType(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_COURSE_EXAM_TYPE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string SaveFacultyType(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SaveFacultyType(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }

    public DataSet GetFacultyTypeData(AcaBAL ObjBal)
    {
        return ACA_DAL.GetFacultyTypeData(ObjBal);
    }

    public string AssignFaculty(AcaBAL ObjBal)
    {
        return ACA_DAL.AssignFaculty(ObjBal);
    }
    public DataSet GetTimeTable(AcaBAL ObjBal)
    {
        return ACA_DAL.GetTimeTable(ObjBal);
    }
    public DataSet GetTimeTable1(AcaBAL ObjBal)
    {
        return ACA_DAL.GetTimeTable1(ObjBal);
    }
    public void GetTimeTable(ScheduleCalendar calender, AcaBAL ObjBal, DataSet dataSet)
    {
        calender.TimeScaleInterval = 30;
        calender.DateField = "CLS_DATE";
        calender.StartDate = Convert.ToDateTime(ObjBal.FromDate);
        TimeSpan span = ObjBal.ToDate.Subtract(ObjBal.FromDate);
        calender.NumberOfDays = span.Days + 1;
        calender.StartTimeField = "STR_TIME";
        calender.EndTimeField = "END_TIME";
        if (dataSet.Tables.Count > 0)
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                calender.DataSource = dataSet.Tables[0];
                calender.DataBind();
            }
    }
    #endregion


    #region Student Group
    public DataSet GetStudentData(AcaBAL ObjBal)
    {
        return ACA_DAL.GetStudentData(ObjBal);
    }

    public XmlDocument GetXMLForStudentGroup(GridView gvStu)
    {
        XmlDocument xmlData = new XmlDocument();
        XmlElement ROOT = xmlData.CreateElement("STU");
        xmlData.AppendChild(ROOT);


        XmlElement dataElement;
        XmlElement element;


        foreach (GridViewRow row in gvStu.Rows)
        {
            CheckBox chkStudent = (CheckBox)row.FindControl("chkStudent");
            if (chkStudent.Checked)
            {
                dataElement = xmlData.CreateElement("DATA");
                ROOT.AppendChild(dataElement);

                element = xmlData.CreateElement("TT_PAP_ID");
                element.InnerText = gvStu.DataKeys[row.RowIndex].Values[0].ToString();
                dataElement.AppendChild(element);


                element = xmlData.CreateElement("STU_MAIN_ID");
                element.InnerText = gvStu.DataKeys[row.RowIndex].Values[1].ToString();
                dataElement.AppendChild(element);
            }
        }
        return xmlData;
    }

    public string SaveStuGroup(AcaBAL ObjBal, GridView gvStu)
    {
        ObjBal.XmlValue = GetXMLForStudentGroup(gvStu).OuterXml;
        try
        {
            ACA_DAL.SaveStuGroup(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public string CopyStuGroup(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.CopyStuGroup(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }

    public DataSet GetPaperCodeForGrp(AcaBAL ObjBal)
    {
        return ACA_DAL.GetPaperCodeForGrp(ObjBal);
    }
    #endregion

    #region Student Attendance
    public string GetEvaSchID(AcaBAL ObjBal)
    {
        return ACA_DAL.GetEvaSchID(ObjBal);
    }

    public SqlCommand GetPaperCommand(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("SELECT ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE + '(' + ACA_SUBJECT_INF.ACA_SUB_NAME + ')' ,ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_ID" +
            " FROM ACA_EVA_SCH_SUBJECT_INF INNER JOIN ACA_SUBJECT_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SUB_ID = ACA_SUBJECT_INF.ACA_SUB_ID " +
            " WHERE (ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID = @EVA_SCH_ID) AND (ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = @ACA_SEM_ID) AND (ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_STS = 1)");
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@EVA_SCH_ID", ObjBal.Id);
        command.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.TypeId);
        return command;
    }

    public DataSet GetStudentForAtt(AcaBAL ObjBal)
    {
        return ACA_DAL.GetStudentForAtt(ObjBal);
    }

    public SqlCommand GetTimeSlotCommand(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_CLS_TIME");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        command.Parameters.AddWithValue("@DATE", ObjBal.Date);
        return command;
    }
    public DataSet GetClassStudent(AcaBAL ObjBal)
    {
        return ACA_DAL.GetClassStudent(ObjBal);
    }
    public void SaveAttendance(AcaBAL ObjBal)
    {
        ACA_DAL.SaveAttendance(ObjBal);
    }

    public SqlCommand GetMissingAttendance(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_MISSING_ATTENDANCE");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@EMP_ID", ObjBal.SessionUserID);
        return command;
    }

    public void BlockClassData(AcaBAL ObjBal)
    {
        ACA_DAL.BlockClassData(ObjBal);
    }

    public SqlCommand GetMissingStudentAttendanceSummary(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand("TT_GET_MISSING_STUDENT_ATTENDANCE_SUMMARY");
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("EMP_ID", ObjBal.SessionUserID);
        return command;
    }

    public DataSet GetMissingStudentAttendanceDetails(AcaBAL ObjBal)
    {
        return ACA_DAL.GetMissingStudentAttendanceDetails(ObjBal);
    }
    public void SaveAttendanceLate(AcaBAL ObjBal)
    {
        ACA_DAL.SaveAttendanceLate(ObjBal);
    }

    public SqlCommand GetApprovalAuthority(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = "SELECT DISTINCT DES_INF.DES_VALUE, USR_INF.USR_LOGIN_ID FROM USR_INF INNER JOIN UNIV_INS_HEAD_INF ON USR_INF.USR_ID = UNIV_INS_HEAD_INF.USR_ID INNER JOIN "
            + " DES_INF INNER JOIN EMP_DES_CNG_INF ON DES_INF.DES_ID = EMP_DES_CNG_INF.DES_ID ON USR_INF.USR_LOGIN_ID = EMP_DES_CNG_INF.EMP_ID "
            + " WHERE     (UNIV_INS_HEAD_INF.TO_DATE IS NULL) AND (EMP_DES_CNG_INF.TO_DATE IS NULL) AND INS_ID=" + ObjBal.InsId;
        return command;
    }
    public string SaveStudentAttendanceCredit(AcaBAL ObjBal)
    {
        return ACA_DAL.SaveStudentAttendanceCredit(ObjBal);
    }

    public void DeleteStudentAttendanceCredit(AcaBAL ObjBal)
    {
        ACA_DAL.DeleteStudentAttendanceCredit(ObjBal);
    }

    public DataSet StudentAttendenceCreditDetail(AcaBAL ObjBal)
    {
        return ACA_DAL.StudentAttendenceCreditDetail(ObjBal);
    }

    public SqlCommand GetStudentForCreditDetail(AcaBAL ObjBal)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = "SELECT DISTINCT StuView.STU_FULL_NAME+'('+StuView.ENROLLMENT_NO+')', StuView.STU_MAIN_ID FROM STU_ATT_CREDIT_INF INNER JOIN "
            + " StuView ON STU_ATT_CREDIT_INF.STU_MAIN_ID = StuView.STU_MAIN_ID WHERE (STU_ATT_CREDIT_INF.CR_STATUS = 1) AND (STU_ATT_CREDIT_INF.CR_BY = " + ObjBal.SessionUserID
            + ") ORDER BY StuView.STU_FULL_NAME+'('+StuView.ENROLLMENT_NO+')' ";
        return command;
    }

    public DataSet GetAttClsNamePerDetails(AcaBAL ObjBal)
    {
        return ACA_DAL.GetAttClsNamePerDetails(ObjBal);
    }
    public DataSet GetDailyAttSummaryForCord(AcaBAL ObjBal)
    {
        return ACA_DAL.GetDailyAttSummaryForCord(ObjBal);
    }

    public DataSet GetAttendanceDetails(AcaBAL ObjBal)
    {
        return ACA_DAL.GetAttendanceDetails(ObjBal);
    }
    public DataSet GetAttendanceDailyAtt(AcaBAL ObjBal)
    {
        return ACA_DAL.GetAttendanceDailyAtt(ObjBal);
    }
    public DataSet DeleteStudentAtt(AcaBAL ObjBal)
    {
        return ACA_DAL.DeleteStudentAtt(ObjBal);
    }
    public DataSet GetStudentDetainPercentage(AcaBAL ObjBal)
    {
        return ACA_DAL.GetStudentDetainPercentage(ObjBal);
    }
    #endregion
    #region Internal Marks
    public DataSet GetFacultyPaperCombination(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TT_GET_FAC_PAPER_DATA";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetFacultyForAsn(AcaBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TT_GET_FAC_PAPER_DATA_ASN";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", Objbal.EmpId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #endregion

    #region PRACHI
    #region STUDENT
    #region Insert

    public string SaveNewStudent(string enroll, string F_NAME, string M_NAME, string L_NAME, string GEN_ID, string DOB, string CAS_ID,
                                 string REL_ID, string NAT_ID, string BLO_GRP_ID, string FTH_NAME, string MTH_NAME, string FTH_OCC, string ComType, string INI_ID, string ADD_DATA,
        string PHN_DATA, string MAIL_DATA, string ACA_DATA, string FORM_NO, string BATCH_ID, string ADM_DATE, string TEST_RANK, string ADM_TYPE, string QUOTA, string ENT_EXAM, string PGM_ID,
        string PGM_BRN_ID, string SEM_ID, string SECTION_ID, string STUDOC, string REMARK, string SessionUserId)
    {
        try
        {

            CommonFunctions CommonFunction;
            CommonFunction = new CommonFunctions();
            if (ComType == "1")
                cmd = new SqlCommand("STU_NEW_INFORMATION_INSERT");

            else
                cmd = new SqlCommand("STU_INFORMATION_UPDATE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@F_NAME", F_NAME);
            cmd.Parameters.AddWithValue("@M_NAME", M_NAME);
            cmd.Parameters.AddWithValue("@L_NAME", L_NAME);
            cmd.Parameters.AddWithValue("@GEN_ID", GEN_ID);
            cmd.Parameters.AddWithValue("@DOB", CommonFunction.GetDateTime(DOB));
            CAS_ID = (CAS_ID == ".") ? "0" : CAS_ID;
            cmd.Parameters.AddWithValue("@CAS_ID", CAS_ID);
            cmd.Parameters.AddWithValue("@REL_ID", REL_ID);
            cmd.Parameters.AddWithValue("@NAT_ID", NAT_ID);
            cmd.Parameters.AddWithValue("@INI_ID", INI_ID);
            BLO_GRP_ID = (BLO_GRP_ID == ".") ? "0" : BLO_GRP_ID;
            cmd.Parameters.AddWithValue("@BLO_GRP_ID", BLO_GRP_ID);
            cmd.Parameters.AddWithValue("@FTH_NAME", FTH_NAME);
            cmd.Parameters.AddWithValue("@MTH_NAME", MTH_NAME);
            cmd.Parameters.AddWithValue("@FTH_OCC", FTH_OCC);
            cmd.Parameters.AddWithValue("@ADD_DATA", CommonFunction.ValidateParameter(ADD_DATA));
            cmd.Parameters.AddWithValue("@PHN_DATA", CommonFunction.ValidateParameter(PHN_DATA));
            cmd.Parameters.AddWithValue("@MAIL_DATA", CommonFunction.ValidateParameter(MAIL_DATA));
            cmd.Parameters.AddWithValue("@ACA_DATA", CommonFunction.ValidateParameter(ACA_DATA));
            cmd.Parameters.AddWithValue("@FORM_NO", FORM_NO);
            cmd.Parameters.AddWithValue("@BATCH_ID", BATCH_ID);
            cmd.Parameters.AddWithValue("@ADM_DATE", CommonFunction.GetDateTime(ADM_DATE));
            cmd.Parameters.AddWithValue("@TEST_RANK", TEST_RANK);
            cmd.Parameters.AddWithValue("@ADM_TYPE", ADM_TYPE);
            cmd.Parameters.AddWithValue("@QUOTA", QUOTA);
            ENT_EXAM = (ENT_EXAM == ".") ? "0" : ENT_EXAM;
            cmd.Parameters.AddWithValue("@ENT_EXAM", ENT_EXAM);
            cmd.Parameters.AddWithValue("@PGM_ID", PGM_ID);
            cmd.Parameters.AddWithValue("@PGM_BRN_ID", PGM_BRN_ID);
            cmd.Parameters.AddWithValue("@SEM_ID", SEM_ID);
            cmd.Parameters.AddWithValue("@SECTION_ID", SECTION_ID);
            cmd.Parameters.AddWithValue("@STUDOC", CommonFunction.ValidateParameter(STUDOC));
            cmd.Parameters.AddWithValue("@REMARK", REMARK);
            cmd.Parameters.AddWithValue("@IN_BY", SessionUserId);
            cmd.Parameters.AddWithValue("@ENROLLMENT_NO", enroll);
            databaseFunctions.ExecuteCommand(cmd);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion
    #endregion
    #region ACADEMIC CALENDER
    #region Select Event
    public DataSet GetEventList()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ACA_EVENT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Insert and Update Event
    public string EventInsertUpdate(AcaBAL ObjBal)
    {
        try
        {
            if (ObjBal.Id == "")
            {
                ACA_DAL.EventInsert(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.UpdateNewEvent(ObjBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #region Modify Event
    public string EventModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.EventModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #region INSERT UPDATE EVNT SCHEDULE
    public string EventSchInsertUpdate(AcaBAL Objbal)
    {
        try
        {
            if (Objbal.KeyID == "")
            {
                ACA_DAL.EventSchInsert(Objbal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.EventSChUpdate(Objbal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    #endregion
    #region SELECT EVENT SCHEDULE
    public DataSet SelectSch()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EVENT_SCH_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region MODIFY EVENT SCHEDULE
    public string EventSchModify(AcaBAL ObjBal)
    {
        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.EventSchModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally { ACA_DAL = null; }

    }
    #endregion
    #region UPLOAD DOCUMENT
    public string UploadEvntDoc(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL = new AcaDAL();
            ACA_DAL.UploadEventDocument(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally { ACA_DAL = null; }
    }
    #endregion
    #endregion
    #region NOTICE & CIRCULAR
    public string NoticeInsertUpdate(AcaBAL Objbal)
    {
        try
        {
            if (Objbal.Id == "")
            {
                ACA_DAL = new AcaDAL();
                ACA_DAL.InsertNotice(Objbal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ACA_DAL.UpdateNotice(Objbal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    public DataSet GetNotice()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT_NOTICE_INFO";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public string NoticeModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Deactivate") ? "0" : "1";
            ACA_DAL.NoticeModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
    #region STU DATA FORM
    public DataSet StuDataForm(AcaBAL ObjBal)
    {
        ObjBal.Stu_AdmNo = (ObjBal.Stu_AdmNo == null) ? "0" : ObjBal.Stu_AdmNo;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == "") ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.Sec_Id = (ObjBal.Sec_Id == ".") ? "0" : ObjBal.Sec_Id;
        cmd = new SqlCommand();
        cmd.CommandText = "STU_SELECT_DATA";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLL", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@BATCH", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@SECTION", ObjBal.Sec_Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Student Document Issue
    public DataSet StuDocIssue(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_DOC_ISSUE_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string StuDocInsert(AcaBAL ObjBal)
    {
        try
        {
            return ACA_DAL.StuDocInsert(ObjBal);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }

    public string GetStudentMainId(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("SELECT STU_MAIN_ID FROM STU_MAIN_INF WHERE ENROLLMENT_NO = @ENROLLMENT_NO");
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Stu_AdmNo);
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetDataSet(cmd).Tables[0].Rows[0][0].ToString();
    }

    #endregion
    #region TRANSPORT CHALLAN
    public string GetTptcln(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_GET_CHALLAN_PRINT_LIST";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.Id);
        return databaseFunctions.GetSingleData(cmd);
    }
    public DataSet GetChlData(AcaBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "TPT_GET_CHALLAN_DATA";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_RTE_ID", Objbal.Id);
        cmd.Parameters.AddWithValue("@PRT_BY", Objbal.SessionUserID);
        cmd.Parameters.AddWithValue("@BANK_ID", Objbal.CommonId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region STU STS CNG
    public string CngStuSts(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.UpdateSts(ObjBal);
            return "Status is Changed Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    #endregion
    #region STUDENT INFORMATION UPDATE
    public string StuPhnChange(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.StuPhnCng(ObjBal);
            return "Student information changed successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    public string StuParPhnChange(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL = new AcaDAL();
            ACA_DAL.StuParPhnCng(ObjBal);
            return "Student Parent Number Changed Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    public string StuMailChange(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL = new AcaDAL();
            ACA_DAL.StuMailCng(ObjBal);
            return "Student Mail Changed Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    #endregion
    #region MENTORSHIP
    public DataSet AssignMentor(AcaBAL Objbal)
    {
        Objbal.InsId = (Objbal.InsId == ".") ? "0" : Objbal.InsId;
        Objbal.Pgm_Id = (Objbal.Pgm_Id == ".") ? "0" : Objbal.Pgm_Id;
        Objbal.Brn_Id = (Objbal.Brn_Id == ".") ? "0" : Objbal.Brn_Id;
        Objbal.Semid = (Objbal.Semid == ".") ? "0" : Objbal.Semid;
        Objbal.Sec_Id = (Objbal.Sec_Id == ".") ? "0" : Objbal.Sec_Id;
        SqlCommand cmd = new SqlCommand("ASSIGN_STUDENT_MENTOR_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", Objbal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", Objbal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", Objbal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_ID", Objbal.Semid);
        cmd.Parameters.AddWithValue("@SEC_ID", Objbal.Sec_Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string AssignStuInsert(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.AssignMentor(ObjBal);
            return "Student Assigned Successfully";
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    public string ReAssignMentor(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.ReAssign_Mentor(ObjBal);
            return "Now Again Assign Student & Mentor";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ACA_DAL = null;
        }
    }
    public DataSet MentorDetail(AcaBAL objBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "MENTOR_STUDENT_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@emp_id", objBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string GetEmployeeUsrId(AcaBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand("select USR_ID FROM USR_INF WHERE USR_LOGIN_ID = @EMP_ID");
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.Text;
        return databaseFunctions.GetDataSet(cmd).Tables[0].Rows[0][0].ToString();
    }
    public string DeleteStuMentor(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.DeleteMentorStudnet(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public string AddStuMentor(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.AddMEntorStu(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    #endregion
    #region HOSTEL STUDENT INFO
    public DataSet HostelStuDetail(AcaBAL Objbal)
    {
        Objbal.Value = (Objbal.Value == ".") ? "0" : Objbal.Value;
        Objbal.DeptId = (Objbal.DeptId == ".") ? "0" : Objbal.DeptId;
        Objbal.Id = (Objbal.Id == "") ? "0" : Objbal.Id;
        SqlCommand cmd = new SqlCommand("HOSTEL_STU_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CMPLX_ID", Objbal.CommonId);
        cmd.Parameters.AddWithValue("@ROOM_NO", Objbal.Value);
        cmd.Parameters.AddWithValue("@FLOOR", Objbal.DeptId);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Student COunt Report
    public DataSet GetStuCount()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STUDENT_COUNT_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region STU STS
    public DataSet GetStuCngInf(AcaBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT_STU_CNF_INF";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STS_ID", Objbal.ChangeStatus);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string StuInfCngApp(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.StuInfCNgApp(ObjBal);
            return "Student Information Changed";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
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
    public DataSet GetInsStudent(AcaBAL ObjBal)
    {
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        ObjBal.KeyID = (ObjBal.KeyID == ".") ? "0" : ObjBal.KeyID;
        ObjBal.KeyValue = (ObjBal.KeyValue == ".") ? "0" : ObjBal.KeyValue;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        ObjBal.Value = (ObjBal.Value == ".") ? "0" : ObjBal.Value;
        ObjBal.UseFor = (ObjBal.UseFor == ".") ? "0" : ObjBal.UseFor;
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == ".") ? "0" : ObjBal.ChangeStatus;
        cmd = new SqlCommand("ACA_GET_INSTITUTION_STUDENT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Value);
        cmd.Parameters.AddWithValue("@GRP_ID", ObjBal.UseFor);
        cmd.Parameters.AddWithValue("@STU_STS_ID", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@ORDER", ObjBal.Description);

        return databaseFunctions.GetDataSet(cmd);
    }
    public SqlDataReader GetShortStuInfo(AcaBAL ObjBal)
    {

        ObjBal.KeyID = ObjBal.KeyID;
        cmd = new SqlCommand("GET_STU_SHORT_INFO");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.KeyID);
        return databaseFunctions.GetReader(cmd);
    }
    public DataSet GetStuPrintDetail(AcaBAL ObjBal)
    {
        return ACA_DAL.GetStuDetainPrintDetail(ObjBal);
    }
    #endregion

    #region Harshita
    public DataSet GetStudentProfile(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("ACA_GET_STU_PROFILE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetStudentDetail(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("ACA_GET_STUDENT_INFO");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string StudentDetailUpdate(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("ACA_STUDENT_INFO_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@STU_PHN_NO", ObjBal.Phn_No);
        cmd.Parameters.AddWithValue("@STU_MBL_NO", ObjBal.Mbl_No);
        cmd.Parameters.AddWithValue("@MAIL_VALUE", ObjBal.Id);
        cmd.Parameters.AddWithValue("@MAIL_DOMAIN_ID", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@PAR_PHN_NO", ObjBal.Par_Phn_No);
        cmd.Parameters.AddWithValue("@PAR_MBL_NO", ObjBal.Par_Mob_No);
        cmd.Parameters.AddWithValue("@PARENT_MAIL", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
        return Msg.GetMessage(Messages.DataMessType.Update);
    }


    public DataSet StuDocumentDetail(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") ? "0" : ObjBal.Brn_Id;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == ".") ? "0" : ObjBal.ChangeStatus;
        SqlCommand cmd = new SqlCommand("GET_STUDENT_DOC_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@BATCH_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion

    #region Academic Internal Marks Insert
    public string InternalMarksInsert(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.InternalMarksInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }

    #endregion


    #region SPECIAL MINOR
    public DataSet GetSpecialMinorDetail(AcaBAL ObjBAl)
    {
        cmd = new SqlCommand("GET_STUDENT_SPECIAL_MINOR_DATA");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBAl.Id);
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBAl.Pgm_Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet StuSpecialMinorMraks(AcaBAL Objbal)
    {
        return ACA_DAL.StuSpecialMinir(Objbal);
    }
    public DataSet GetInternalDetailRpt(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_CRS_INT_MARKS_SINGLE");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@EXAM_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetMultiMarksDetailRpt(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_CRS_INT_MARKS_ALL");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region STU STS
    public DataSet GetStuSts(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_STU_STS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Fee Defaulter
    public DataSet GetFeeDefaulter(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_EXAM_FEE_DEFAULT_AMT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string UpdateFeeDefaulter(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.UpdateFeeDefaulter(ObjBal);
            return "Selected Student is Cleared.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public DataSet GetDefaulterDetail(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == ".") ? "0" : ObjBal.ChangeStatus;
        SqlCommand cmd = new SqlCommand("GET_FEE_DEFAULTER");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@FROMDT", ObjBal.Max_Dt);
        cmd.Parameters.AddWithValue("@TODT", ObjBal.Value);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    //# region MajorMarks
    //public DataSet getMarksWeightage(AcaBAL ObjBal)
    //{
    //    cmd = new SqlCommand("GET_MAJOR_MARKS_WEIGHTAGE");
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);
    //    cmd.Parameters.AddWithValue("@MARKS", ObjBal.Marks);
    //    cmd.Parameters.AddWithValue("@WEIGHTAGE", ObjBal.KeyValue);
    //    cmd.Parameters.AddWithValue("@PAPER_CODE", ObjBal.Pap_Code);
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public DataSet MajorMarksInsert(AcaBAL ObjBal)
    //{

    //    cmd = new SqlCommand("STU_MAJOR_MAIN_INF_INSERT");
    //    cmd.Parameters.AddWithValue("@EXAM_MAIN_ID", ObjBal.KeyID);
    //    cmd.Parameters.AddWithValue("@MEM_EXAMINER", ObjBal.Id);
    //    cmd.Parameters.AddWithValue("@MEM_SCRUTINIZER", ObjBal.EmpId);
    //    cmd.Parameters.AddWithValue("@MEM_W_MARKS", ObjBal.KeyValue);
    //    cmd.Parameters.AddWithValue("@MEM_IN_BY", ObjBal.SessionUserID);
    //    cmd.Parameters.AddWithValue("@MARKS_DATA", ObjBal.XmlValue);
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    return databaseFunctions.GetDataSet(cmd);




    //}

    //public DataSet PrntMajorMarks(AcaBAL ObjBal)
    //{
    //    cmd = new SqlCommand("PRNT_MAJOR_MARKS");
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@MEM_ID", ObjBal.Id);
    //    return databaseFunctions.GetDataSet(cmd);
    //}

    //public DataSet GetMajorMarks(AcaBAL ObjBal)
    //{
    //    cmd = new SqlCommand("GET_MAJOR_MARKS");
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@EVA_SCH_PAPER_CODE", ObjBal.Pap_Code);
    //    cmd.Parameters.AddWithValue("@EXAM_MAIN_ID", ObjBal.Id);
    //    return databaseFunctions.GetDataSet(cmd);
    //}
    //public void MajorMarksUpdate(AcaBAL ObjBal)
    //{
    //    cmd = new SqlCommand("MAJOR_MARKS_UPDATE");
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.Parameters.AddWithValue("@MEM_W_MARKS", ObjBal.KeyValue);
    //    cmd.Parameters.AddWithValue("@MEM_ID", ObjBal.Id);
    //    cmd.Parameters.AddWithValue("@MARKS", ObjBal.Marks);
    //    cmd.Parameters.AddWithValue("@MEM_SUB_ID", ObjBal.KeyID);
    //    databaseFunctions.ExecuteCommand(cmd);
    //}
    //#endregion

    # region MajorMarks
    public DataSet getMarksWeightage(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_MAJOR_MARKS_WEIGHTAGE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);
        cmd.Parameters.AddWithValue("@MARKS", ObjBal.Marks);
        cmd.Parameters.AddWithValue("@WEIGHTAGE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@PAPER_CODE", ObjBal.Pap_Code);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet MajorMarksInsert(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("STU_MAJOR_MAIN_INF_INSERT");
        cmd.Parameters.AddWithValue("@EXAM_MAIN_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@MEM_EXAMINER", ObjBal.Id);
        cmd.Parameters.AddWithValue("@MEM_SCRUTINIZER", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@MEM_W_MARKS", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@MEM_IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@MARKS_DATA", ObjBal.XmlValue);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);




    }

    public DataSet PrntMajorMarks(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("PRNT_MAJOR_MARKS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MEM_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetMajorMarksForRevaluation(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_MAJOR_MARKS_FOR_REVALUATION");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EVA_SCH_PAPER_CODE", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@EXAM_MAIN_ID", ObjBal.Id);

        return databaseFunctions.GetDataSet(cmd);
    }
    public string MajorMarksRevaluateInsert(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("STU_MAJOR_REVALUATE_INF_INSERT");
        cmd.Parameters.AddWithValue("@EXAM_MAIN_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@REVALUATE_EXAMINER", ObjBal.Id);
        cmd.Parameters.AddWithValue("@MEM_IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@MARKS_DATA", ObjBal.XmlValue);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetSingleData(cmd);

    }
    public DataSet GetMajorMarks(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_MAJOR_MARKS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EVA_SCH_PAPER_CODE", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@EXAM_MAIN_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@MEM_ID", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public void MajorMarksUpdate(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("MAJOR_MARKS_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MEM_W_MARKS", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@MEM_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);
        cmd.Parameters.AddWithValue("@MARKS", ObjBal.Marks);
        cmd.Parameters.AddWithValue("@MEM_SUB_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        databaseFunctions.ExecuteCommand(cmd);
    }
    public DataSet GetMajorRePrint(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_MAJOR_REPRINT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAPER_CODE", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@DATE", ObjBal.KeyValue);
        return databaseFunctions.GetDataSet(cmd);

    }
    #endregion
    #region Verify Marks
    public DataSet GetStuMarksDetail(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STUDENT_MARKS_VERIFY_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@EVA_SUB_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string VerifyStuMarks(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.VerfiyStudentMarks(ObjBal);
            return "Marks is Verified";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
        }
    }
    public DataSet GetVerifiedMarks(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_VERIFIED_MARKS";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EVA_SUB_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetPendingInternalMarksDetail(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = ((ObjBal.Semid == ".")) ? "0" : ObjBal.Semid;
        cmd = new SqlCommand("GET_INTERNAL_NOT_SUBMITTED");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        return databaseFunctions.GetDataSet(cmd);

    }
    #endregion
    #region RE REGISTRATION ACCOUNT
    public DataSet ReRegAcntApp(AcaBAL ObjBal)
    {
        ObjBal.Id = (ObjBal.Id == null) ? "" : ObjBal.Id;
        ObjBal.KeyValue = (ObjBal.KeyValue == ".") ? "0" : ObjBal.KeyValue;
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.ChangeStatus = (ObjBal.ChangeStatus == ".") ? "0" : ObjBal.ChangeStatus;
        cmd = new SqlCommand();
        cmd.CommandText = "STU_RE_REG_APP_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@REG_FOR", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@INS", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@STS", ObjBal.ChangeStatus);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet FeeDemRcvSelect(AcaBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "STU_FIN_FEE_RECEIPT_DETAIL_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ADM_NO", Objbal.Enroll_No);
        cmd.Parameters.AddWithValue("@BRANCH_ID", Objbal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_NO", Objbal.Semid);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string UpdateReReg(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.UpdateReRegSts(ObjBal);
            return "Registration done successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    public string SendMessage(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SendRemark(ObjBal);
            return "Remark to selected Student has been Successfuly sent.";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion
    #region STUDENT VERIFIED MARKS
    public DataSet GetStuVerifiedMarks(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        cmd = new SqlCommand("GET_STU_MARKS_VERIFIED_DATA");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@SUB_TYPE", ObjBal.TypeId);

        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region STUDENT RESULT
    public DataSet GetStudentSemResult(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STUDENT_EXAM_SEM_FULL_RESULT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EXAM_STU_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region Icard
    public DataSet getCardDetail(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_GET_ICARD_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Enrollment", ObjBal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region EnrollmentProcess
    public DataSet GetEnrollmentData(AcaBAL ObjBal)
    {
        ObjBal.Year = (ObjBal.Year == ".") ? "0" : ObjBal.Year;
        ObjBal.TypeId = (ObjBal.TypeId == ".") ? "0" : ObjBal.TypeId;
        ObjBal.InsId = (ObjBal.InsId == "All") ? "" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == "All") ? "" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == "All") ? "" : ObjBal.Brn_Id;
        cmd = new SqlCommand("GET_ADMISSION_DATA");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@APP_YEAR", ObjBal.Year);
        cmd.Parameters.AddWithValue("@APP_LATERAL", ObjBal.Lateral);
        cmd.Parameters.AddWithValue("@ADM_REG_TYPE", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@UNIV_INS_SHORT_NAME", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_CRS_SHORT_NAME", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRANCH_SHORT_NAME", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@CASTE", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@APP_NO", ObjBal.KeyID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string EnrollStudent(AcaBAL ObjBal)
    {
        try
        {
            ObjBal.KeyID = (ObjBal.KeyID == "") ? "0" : ObjBal.KeyID;
            ObjBal.Year = (ObjBal.Year == "." || ObjBal.Year == " ") ? "0" : ObjBal.Year;
            ObjBal.TypeId = (ObjBal.TypeId == "." || ObjBal.TypeId == " ") ? "0" : ObjBal.TypeId;
            ObjBal.InsId = (ObjBal.InsId == "." || ObjBal.InsId == " ") ? "0" : ObjBal.InsId;
            ObjBal.Pgm_Id = (ObjBal.Pgm_Id == "." || ObjBal.InsId == " ") ? "0" : ObjBal.Pgm_Id;
            ObjBal.Brn_Id = (ObjBal.Brn_Id == "." || ObjBal.InsId == " ") ? "0" : ObjBal.Brn_Id;
            cmd = new SqlCommand("ENROLL_STUDENT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@APP_YEAR", ObjBal.Year);
            cmd.Parameters.AddWithValue("@APP_LATERAL", ObjBal.Lateral);
            cmd.Parameters.AddWithValue("@ADM_REG_TYPE", ObjBal.TypeId);
            cmd.Parameters.AddWithValue("@UNIV_INS_SHORT_NAME", ObjBal.InsId);
            cmd.Parameters.AddWithValue("@INS_CRS_SHORT_NAME", ObjBal.Pgm_Id);
            cmd.Parameters.AddWithValue("@BRANCH_SHORT_NAME", ObjBal.Brn_Id);
            cmd.Parameters.AddWithValue("@APP_NO", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@CASTE", ObjBal.KeyValue);
            cmd.Parameters.AddWithValue("@TRAN_BY", ObjBal.EmpId);
            return databaseFunctions.GetSingleData(cmd);

        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion

    #region Attendance

    public DataSet getStuListForAtt(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.Sec_Id = (ObjBal.Sec_Id == ".") ? "0" : ObjBal.Sec_Id;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        cmd = new SqlCommand("GET_STU_FOR_ATT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string MarkStuTempAtt(AcaBAL ObjBal)
    {
        try
        {
            cmd = new SqlCommand("MARK_STU_TEMP_ATT");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAP_CODE", ObjBal.Pap_Code);
            cmd.Parameters.AddWithValue("@TIME_SLOT", ObjBal.KeyID);
            cmd.Parameters.AddWithValue("@ATT_DATE", ObjBal.Date);
            cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
            cmd.Parameters.AddWithValue("@ATT_DATA", ObjBal.XmlValue);
            databaseFunctions.ExecuteCommand(cmd);
            return "Attendance Marked Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet getStuTempAtt(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        ObjBal.Sec_Id = (ObjBal.Sec_Id == ".") ? "0" : ObjBal.Sec_Id;
        ObjBal.Id = (ObjBal.Id == ".") ? "0" : ObjBal.Id;
        cmd = new SqlCommand("STU_TEMP_ATT_REPORT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@ATT_DATE", ObjBal.KeyValue);
        return databaseFunctions.GetDataSet(cmd);
    }

    # endregion


    #region Harshita

    public DataSet getClass(AcaBAL ObjBal)
    {
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == "") || (ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == "") || (ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;

        cmd = new SqlCommand("GET_TT_CLASS");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM", ObjBal.Semid);
        //cmd.Parameters.AddWithValue("@DATE", ObjBal.Date);
        return databaseFunctions.GetDataSet(cmd);

    }

    public DataSet getClassFacStuDetail(AcaBAL ObjBal)
    {
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == "") || (ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == "") || (ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        cmd = new SqlCommand("GET_CLASS_FAC_STU_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CLS_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet getStuMonthlyReport(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STU_MONTHLY_REPORT");
        ObjBal.InsId = ObjBal.InsId == "." ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = ObjBal.Pgm_Id == "." ? "0" : ObjBal.Pgm_Id;
        ObjBal.KeyID = ObjBal.KeyID == "." ? "0" : ObjBal.KeyID;
        ObjBal.Semid = ObjBal.Semid == "." ? "0" : ObjBal.Semid;
        ObjBal.Brn_Id = ObjBal.Brn_Id == "." ? "0" : ObjBal.Brn_Id;
        ObjBal.Sec_Id = ObjBal.Sec_Id == "." ? "0" : ObjBal.Sec_Id;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@COUNT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@IS_LAST", ObjBal.CommonId);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getStuMonthlyReportDetail(AcaBAL ObjBal)
    {
        ObjBal.InsId = ObjBal.InsId == "." ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = ObjBal.Pgm_Id == "." ? "0" : ObjBal.Pgm_Id;
        ObjBal.KeyID = ObjBal.KeyID == "." ? "0" : ObjBal.KeyID;
        ObjBal.Semid = ObjBal.Semid == "." ? "0" : ObjBal.Semid;
        ObjBal.Brn_Id = ObjBal.Brn_Id == "." ? "0" : ObjBal.Brn_Id;
        ObjBal.Sec_Id = ObjBal.Sec_Id == "." ? "0" : ObjBal.Sec_Id;
        cmd = new SqlCommand("GET_STUDENT_MONTHLY_REPORT_DATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@COUNT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@IS_LAST", ObjBal.CommonId);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);

        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    public DataSet CalculateStuAtt(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = ((ObjBal.Semid == ".")) ? "0" : ObjBal.Semid;
        ObjBal.Id = ((ObjBal.Id == ".")) ? "0" : ObjBal.Id;
        cmd = new SqlCommand("CALCULATE_STU_FINAL_ATT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@MAX_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);

    }

    public DataSet CalculateStuAttAfterCredit(AcaBAL ObjBal)
    {
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        ObjBal.Semid = ((ObjBal.Semid == ".")) ? "0" : ObjBal.Semid;
        ObjBal.Id = ((ObjBal.Id == ".")) ? "0" : ObjBal.Id;
        cmd = new SqlCommand("CALCULATE_STU_FINAL_ATT_AFTER_CREDIT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@PER", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@CREDIT", ObjBal.Value);
        cmd.Parameters.AddWithValue("@TYP", ObjBal.TypeId);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataTable GetStudentDetainedList(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STUDENT_DETAINED_LIST");
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.KeyID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #region Academic Student Detained
    public string StudentDetainedModify(AcaBAL ObjBal)
    {

        try
        {
            ObjBal.ChangeStatus = (ObjBal.ChangeStatus == "Clear") ? "0" : "1";
            ACA_DAL.StudentDetainedModify(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Status);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion

    public DataSet GetFacultyByDept(AcaBAL ObjBal)
    {
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        cmd = new SqlCommand("GET_FACULTY_BY_DEPT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetPaperCodeByFaculty(AcaBAL ObjBal)
    {
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        cmd = new SqlCommand("GET_PAPER_CODE_BY_FACULTY");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetIntMarksForUpdate(AcaBAL ObjBal)
    {
        ObjBal.DeptId = (ObjBal.DeptId == ".") ? "0" : ObjBal.DeptId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".")) ? "0" : ObjBal.Brn_Id;
        cmd = new SqlCommand("GET_STU_INT_MARKS_FOR_UPDATE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjBal.DeptId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_SUB_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string UpdateIntMarks(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.UpdateIntMarks(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }

    public DataSet getDueAmt(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DUE_AMT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    public String StuSemReg(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("STU_SEM_RE_REG_BY_EMP");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@INSTALLMENT", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@DUE_DATE", ObjBal.Value);
        cmd.Parameters.AddWithValue("@AUTHORISED_BY", ObjBal.EmpId);
        return databaseFunctions.GetSingleData(cmd);

    }

    public DataSet getRegSlip(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_SEM_REG_SLIP_PRINT");
        ObjBal.Enroll_No = (ObjBal.Enroll_No == null) ? "" : ObjBal.Enroll_No;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@COUNT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@IS_LAST", ObjBal.CommonId);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@enroll", ObjBal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet getRegStudent(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_SEM_REG_DETAIL");
        ObjBal.InsId = (ObjBal.InsId == ".") ? "0" : ObjBal.InsId;
        ObjBal.Pgm_Id = ((ObjBal.Pgm_Id == ".") || (ObjBal.Pgm_Id == "")) ? "0" : ObjBal.Pgm_Id;
        ObjBal.Brn_Id = ((ObjBal.Brn_Id == ".") || (ObjBal.Brn_Id == "")) ? "0" : ObjBal.Brn_Id;
        ObjBal.KeyID = ((ObjBal.KeyID == ".") || (ObjBal.KeyID == "")) ? "0" : ObjBal.KeyID;
        ObjBal.Sec_Id = ((ObjBal.Sec_Id == ".") || (ObjBal.Sec_Id == "")) ? "0" : ObjBal.Sec_Id;
        ObjBal.Semid = ((ObjBal.Semid == ".") || (ObjBal.Semid == "")) ? "0" : ObjBal.Semid;
        ObjBal.Enroll_No = ((ObjBal.Semid == ".") || (ObjBal.Enroll_No == "")) ? "0" : ObjBal.Enroll_No;
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@INS_PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@COUNT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@IS_LAST", ObjBal.CommonId);
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_SEC_ID", ObjBal.Sec_Id);
        cmd.Parameters.AddWithValue("@ENROLL", ObjBal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);
    }
    #region Riju

    public string regblockInsert(AcaBAL objbal)
    {
        try
        {
            ACA_DAL.regblockInsert(objbal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion
    #region riju
    public DataTable regblockSelect(AcaBAL objbal)
    {
        cmd = new SqlCommand("REG_BLOCK_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", objbal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }

    public string changeblockStatus(AcaBAL objbal)
    {
        try
        {
            ACA_DAL.changeblockStatus(objbal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }

    }

    public DataSet SectionChng(AcaBAL objbal)
    {
        cmd = new SqlCommand("Section_Change_Select");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ins", objbal.InsId);
        cmd.Parameters.AddWithValue("@crs", objbal.Pgm_Id);
        cmd.Parameters.AddWithValue("@brn", objbal.Brn_Id);
        cmd.Parameters.AddWithValue("@sem", objbal.Semid);
        cmd.Parameters.AddWithValue("@sec", objbal.Sec_Id);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string SectionChngInsert(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.SecChngInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }

    }

    public DataSet form_no(AcaBAL objbal)
    {
        cmd = new SqlCommand("FORM_NO_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public void form_no_insert(AcaBAL objbal)
    {
        cmd = new SqlCommand("TEMP_PIC_NOT_FOUND_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@FORM_NO", objbal.Id);
        databaseFunctions.ExecuteCommand(cmd);
    }


    public DataSet GetStuAsnDetail(AcaBAL Objbal)
    {
        cmd = new SqlCommand("GET_STU_ASSIGNMENT_DETAIL");
        cmd.Parameters.AddWithValue("@USR_ID", Objbal.EmpId);
        cmd.Parameters.AddWithValue("@Name", Objbal.Name);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);


    }

    public DataSet StuMentorInsert(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_MENTOR_ACHV_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ADD_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@Att", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@stu_main_id", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet StuMenteeVisit(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_MENTEE_VISIT_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ADD_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@Att", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@stu_main_id", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet StuBehParInsert(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_MENTOR_BEH_PAR_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Att", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@BEHAVE", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@PARENT", ObjBal.Id);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet StuMenRmkInsert(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_MENTOR_RMK_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Att", ObjBal.TypeId);
        //cmd.Parameters.AddWithValue("@Bhv", ObjBal.SessionUserID);
        //cmd.Parameters.AddWithValue("@Aca", ObjBal.Ev_Sch_Id);
        cmd.Parameters.AddWithValue("@AcaRmk", ObjBal.Display);
        cmd.Parameters.AddWithValue("@BhvRmk", ObjBal.Description);
        cmd.Parameters.AddWithValue("@AttRmk", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void STUACHVMISBEHAVINSERT(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_ACHV_MISBEHAVE_INSERT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@REMARK", ObjBal.Remark);
        cmd.Parameters.AddWithValue("@INS_BY", ObjBal.SessionUserID);
        cmd.Parameters.AddWithValue("@KEY_ID", ObjBal.KeyID);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public DataSet STUACHVMISBEHSELECT(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("STU_ACHV_MISBEHAVE_SELECT");
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }


    #endregion
    public DataSet GetStudentSemInternal(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STUDENT_INTERNAL_MARKS_FOR_PROFILE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Id);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetStuAttandence_2(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_STUDENT_ATTENDANCE_2");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }


    #region Mudit

    public string DetainedMarksInsert(AcaBAL ObjBal)
    {
        try
        {
            ACA_DAL.DetainedMarksInsert(ObjBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);

        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }


    public DataSet GetDetainedStudentInfo(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("Get_Detained_Student_Info");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CRS_CODE", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@EXAM_ID", ObjBal.EXAMID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetDetainMarks(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_DETAIN_MARKS_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@CRS_CODE", ObjBal.Id);
        cmd.Parameters.AddWithValue("@EXAM_ID", ObjBal.EXAMID);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);



        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetAllDetainPaperMarksList(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_REPRINT_DETAIN_MARKS_LIST");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);

        return databaseFunctions.GetDataSet(cmd);
    }
    public string ChangeBranchInsert(AcaBAL objbal)
    {
        try
        {
            cmd = new SqlCommand();
            cmd.CommandText = "BRANCH_CHANGE_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ENROLLMENT", objbal.Stu_AdmNo);
            cmd.Parameters.AddWithValue("@PGM_BRN_ID", objbal.KeyID);
            cmd.Parameters.AddWithValue("@SEM_ID", objbal.Semid);
            cmd.Parameters.AddWithValue("@REMARK", objbal.Remark);
            cmd.Parameters.AddWithValue("@IN_BY", objbal.SessionUserID);
            return databaseFunctions.GetSingleData(cmd);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
    }
    #endregion

    #region Minor
    public DataSet AllotSeat(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("MAKESEATINGPLANFORMINOR_ENROLLMENT");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@MINOR_SCH_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@ENROLLMENT", ObjBal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);

    }
    public DataSet GetMinorAttendancePrint(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_MINOR_ROOM_DETAIL";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATE", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@SHIFT_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@ROOM_ID_FROM", ObjBal.Value1);
        cmd.Parameters.AddWithValue("@ROOM_ID_TO", ObjBal.Value2);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet StuAdmitCardInfoSelect(AcaBAL ObjBal)
    {

        ObjBal.Brn_Id = (ObjBal.Brn_Id == ".") || (ObjBal.Brn_Id == "") ? "0" : ObjBal.Brn_Id;
        ObjBal.Pgm_Id = (ObjBal.Pgm_Id == ".") ? "0" : ObjBal.Pgm_Id;
        ObjBal.balENROLL_TO = (ObjBal.balENROLL_TO == "") ? "0" : ObjBal.balENROLL_TO;
        ObjBal.balENROLL_FROM = (ObjBal.balENROLL_FROM == "") ? "0" : ObjBal.balENROLL_FROM;
        cmd = new SqlCommand("STU_ADMIT_CARD_INFO_SELECT_IET");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjBal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", ObjBal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Semid);
        cmd.Parameters.AddWithValue("@ENROLLMENT_TO", ObjBal.balENROLL_TO);
        cmd.Parameters.AddWithValue("@ENROLLMENT_FROM", ObjBal.balENROLL_FROM);
        cmd.Parameters.AddWithValue("@STATUS", ObjBal.balSTATUS);
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet GetMinorSittingPlan(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_MINOR_SITTING_PLAN_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT_NO", ObjBal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);
    }
    public SqlDataReader GetMinorAttendanceSheet(AcaBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_MINOR_ATTENDATNCE_SHEET_IET";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATE", ObjBal.FromDate);
        cmd.Parameters.AddWithValue("@SHIFT_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@ROOM_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@TYPE", ObjBal.KeyValue);
        return databaseFunctions.GetReader(cmd);
    }
    #endregion
    public DataSet ChangeBatch(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "BATCH_CHANGE_UPDATE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", objbal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@BATCH_ID", objbal.KeyID);
        cmd.Parameters.AddWithValue("@REMARK", objbal.Remark);
        cmd.Parameters.AddWithValue("@IN_BY", objbal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet AddOpenElective(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("OPEN_ELECTIVE_INSERT");
        cmd.Parameters.AddWithValue("@SUB_TYPE_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@MARKS_TEMP", ObjBal.Marks);
        cmd.Parameters.AddWithValue("@FACULTY_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@SUB_NAME", ObjBal.PAPERNAME);
        cmd.Parameters.AddWithValue("@PAP_CODE", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);

        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);

    }
    public DataSet getOpenElecList(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_OPEN_ELEC_PAPERS_LIST";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetStudentDataOpnElec(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_STU_DATA_OPEN_ELEC";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", objbal.InsId);
        cmd.Parameters.AddWithValue("@PGM_ID", objbal.Pgm_Id);
        cmd.Parameters.AddWithValue("@BRN_ID", objbal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_ID", objbal.Semid);
        return databaseFunctions.GetDataSet(cmd);
    }


    public DataSet SaveOpnElecStu(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "OPEN_ELEC_STU_ADD_TEMP";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XML_DATA", obj.XmlValue);
        cmd.Parameters.AddWithValue("@PAP_ID", obj.Pap_Code);
        cmd.Parameters.AddWithValue("@ACTV_FROM", obj.Date);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);


        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet OpenElectiveAttendance(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_OPEN_ELEC_STU_ATT_LIST";
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PAP_ID", objbal.Pap_Code);
        cmd.Parameters.AddWithValue("@USR_ID", objbal.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet saveOpenElecAtt(AcaBAL ObjBal)
    {

        cmd = new SqlCommand("OPEN_ELEC_ATTEN_INSERT");
        cmd.Parameters.AddWithValue("@XML_DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@CLS_DATE", ObjBal.Date);
        //cmd.Parameters.AddWithValue("@PAP_CODE", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@IN_BY", ObjBal.SessionUserID);

        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);

    }
    public DataSet GetOpenElecExamType(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_OPEN_ELEC_EXAM_TYPE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAP_CODE", ObjBal.Pap_Code);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet OpenElecMarksInsert(AcaBAL obj)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "OPEN_ELEC_MARKS_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@XML_DATA", obj.XmlValue);
        cmd.Parameters.AddWithValue("@PAP_ID", obj.Pap_Code);
        cmd.Parameters.AddWithValue("@EXAM_TYPE_SUB_ID", obj.KeyID);
        cmd.Parameters.AddWithValue("@IN_BY", obj.SessionUserID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetOpenElecMarks(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_OPEN_ELEC_MARKS");
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBal.Pap_Code);
        cmd.Parameters.AddWithValue("@EXAM_ID", ObjBal.EXAMID);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.SessionUserID);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetOpenELecAttDetails(AcaBAL ObjBal)
    {
        ObjBal.Pap_Code = (ObjBal.Pap_Code == ".") ? "0" : ObjBal.Pap_Code;
        ObjBal.EmpId = (ObjBal.EmpId == " ") ? " " : ObjBal.EmpId;
        cmd = new SqlCommand("GET_OPEN_ELEC_ATT_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBal.Pap_Code);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetOpenELecMarksDetails(AcaBAL ObjBal)
    {
        ObjBal.Pap_Code = (ObjBal.Pap_Code == ".") ? "0" : ObjBal.Pap_Code;
        ObjBal.EmpId = (ObjBal.EmpId == " ") ? " " : ObjBal.EmpId;
        cmd = new SqlCommand("GET_OPEN_ELEC_Marks_DETAIL");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBal.Pap_Code);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataSet GetAssignmentDetail(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_ASSIGNMENT_DETAIL");

        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }



    public DataSet Assignment_Insert(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("ASN_FAC_INSERT");
        cmd.Parameters.AddWithValue("@TT_ID", ObjBal.KeyID);
        cmd.Parameters.AddWithValue("@PAP_ID", ObjBal.TypeId);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.EmpId);
        cmd.Parameters.AddWithValue("@URL", ObjBal.Value);
        cmd.Parameters.AddWithValue("@DUE_DATE", ObjBal.Date);
        cmd.Parameters.AddWithValue("@DOC_NAME", ObjBal.Name);

        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);

    }

    public DataSet AuditSelect(AcaBAL objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "Stu_Audit_Att_Select";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@ENROLLMENT", objbal.Enroll_No);
        return databaseFunctions.GetDataSet(cmd);
    }
    public DataTable GetInternalMarksExam(AcaBAL ObjBal)
    {
        cmd = new SqlCommand("GET_INTERNAL_MARKS_EXAM");
        cmd.Parameters.AddWithValue("@BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@SEM_ID", ObjBal.Semid);
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd).Tables[0];
    }
    #region Semester Upgrade
    public DataSet GetStudentListForSemesterUpgrade(AcaBAL ObjBal)
    {

        ObjBal.Semid = (ObjBal.Semid == ".") ? "0" : ObjBal.Semid;
        SqlCommand cmd = new SqlCommand("GET_STUDENT_LIST_FOR_SEM_UPGRADE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PGM_BRN_ID", ObjBal.Brn_Id);
        cmd.Parameters.AddWithValue("@ACA_BATCH_ID", ObjBal.Id);
        cmd.Parameters.AddWithValue("@ACA_SEM_ID", ObjBal.Semid);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string StudnetUpgradeAction(AcaBAL ObjBal)
    {
        try
        {
            return ACA_DAL.StudnetUpgradeAction(ObjBal);            
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ACA_DAL = null; }
    }
    #endregion
}
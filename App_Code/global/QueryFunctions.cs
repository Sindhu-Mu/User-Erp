using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for QueryFunctions
/// </summary>
public class QueryFunctions
{

    public enum QueryBaseType
    {
        /// <summary>
        ///  No Parameter
        /// </summary>
        Academic, Initial, Category, Caste, Religion, MotherTongue, BloodGroup, NextKinType, ServiceType, JobType, JobTypeWithoutAll, LeaveType, DayType, EmpSessionType,
        Designation, Institution, PhoneType, State, Board, Bank, University, MailDomain, ShiftValue, ShiftWithTime, Pattern, Organization, WarningType, DeptType,
        OrgType, EmployeeStatus, MenuHead, MenuSubHead, DocumentType, DocFor, Authority, Role, UserType, ExpType, Releived_Type, SemesterType, Country,
        ProgramType, DegreeType, DocumentSingle, Quota, Program, Semester, Status, Batch, AdmCategory, Section, CITY, DirectBranch, AdrsType, Relation, EmpID,
        Nationality, RoomCategoryType, ComplexType, SubjectType, branch, Semester_id, Semester_Batch, Complex, Group, TimeSlot, ExamTimeSlot, CreditType, SecurityQuestion,
        HOD, Year, NextSenior, HallCmplx, AcademicEvent, ComplexForTT, Stu_Status, Stu_Qual, Paper, AttType,CasteAlias,Notice_Type, Reg_Sem, HstlCmplx,
        Reg_Type, BlockType, StuInfSts, StuDocument, HstlRomType, Paper_type, PendingWith, sts, SemType, AdmType, 
        RoombyFloorAndCategory,SemByBranch,DetainedPaperCode,OpnElecPap,Examination,
        #region Facility
        Course, TptCity, RouteName, BusType, SlotPrd, BusNo, AprValue, PayMode, AcNo, PerType, EmpName, CmplxName, ResCmplxName, AllotedRoom, CityName, AppBy, RoomType,
        Driver, Vehicle, VehStatus, EvntItem, Evnt, IssueSts, EmpIssueCat,Room,RoomCategoryTypeByHstl,CurrentSession,RoomByFlrCmplx,
        #endregion
        #region inventory
        INV_CATEGORY, Store,
        Unit
            , Vendor, Req_Status, PurReqNo, ITEM, FANId, Dept_Name, PurId, AssignBy, FANStatus, RFQ_No, PurTerm, Sto_Rcv_By,
        Sto_Cat, PO_PurReqNo, PurOrderRpt, Status_Ind, POMod, Sub,TotlItem,Carry_Person,Gate_Pass_Rcv,
        # endregion
        #region store
        IND_BY_TYPE, IND_ID, Ind_Status, Sto_PO, GRN_NO, GRN_RcvBy, SIV_Id,
        #endregion/// <summary>
        # region issue
        IssueCat, IssueDept, SolDept,IssueDeptByUser,

        EmpCrs, Div,
        #endregion
        # region Payroll
        TempType,HeadType,PayScale, TranDate, TranRef, Ref,SalaryHead,
        #endregion
        #region Interview
        JobNo, IntMode, IntSts, IntDate, Job,
        #endregion
        Notice_For, Upload_Type, VacTyp,
        # region Notice

        #endregion
        #region Appraisal
        UnivLevel, OPMF, PAStatus,PAFacSts,
        #endregion
        #region MINOR
        Shift,
        #endregion

        ///  Single Parameter
        /// </summary>
        City, PrimeLocation, Department, Office_ByLocation, Office_ByCity, Office_ByState, Branch, EmpByDept, EmpDocument, Emp_ByArr,
        RoomNo, DesigByCategory,
        Dept_byArr, Document, ProgramByIns, NextSenior_ByDepartment, ProgramByDegree, DepartmentByType, Sem, Gender, Emp_Ins, Emp_Dept, pgm_dept, Doc_Issue, stu_main_id, Transfer,
        BusNoCity, ProgramByType,
        #region Facility
        CourseName, BranchName_ByCourse,  Route_Name, Bus_Type, Bus_No, Bus_Id, HstlFloor, HstlRoom,
        EmpResFloor, EmpResName, HostelComplex, EmpIssueAbut, EmpIssueDept, IssueSubHead, BusNO,
        #endregion
        #region TNP
        Profile, Company, Comp_profile, cmpny, Job_profile, Intdate, IntSTATUS, Job_Location,

        #endregion
        #region inventory
        SubCategory, Item, UNIT,
        STATUS, FanAmount, RFQ_Vendor, FanNo, RFQPurReqNo, Store_Item, POModify,
        # endregion
        #region store
        DirIndStore_Item, Sto_Indent, Item_Store, Sto_Name, Usr_id, PurOrder,GRN_NO_AVAL,GatePass,StoreItemForIndent,

        #endregion

        ///<summary>
        /// Double Parameter
        ///</summary>
        ///
        #region Facility
        RoomNO, EmpResRoom, RoomByType, PaperCode, CourseByBrnchSem, AwardId,
        #endregion
        #region Interview
        IntNo, IntStatus, IntTime, DeptJob, JobIntDate,
        #endregion

        /// Tri Parameter
        ///</summary>
        ///
        #region Facility
        RoomByFlrType, PaperByBrnchSem,CourseFilePaper,
        #endregion
        #region Student Finance
        GroupHeadId, HeadId, QuotaStu, Session,MainHeadId,FacilityMainHeadId, FeeFineRule, FeeProcess, FeeTemplate, FeeStructure, StuBranch, BankName, FeeAccount, PaymentCancelReason, CalculationType, FineHeads,
        AdjType, Mode, FeesHeadType, TopHeadId,ConcessionRule,FineCase,
        #endregion
        #region Hasrhita_academic_Rpt
        UsrIns, UsrDept,DeptPgm,
        #endregion
         #region MINOR
        SeatingRoom,

        #endregion
        #region Examintion
        /// <summary>
        ///  No Parameter
        MinorExam,
        /// </summary>
        ///  Single Parameter
        /// </summary>
        FacultyCourse
        /// Double Parameter
        /// </summary>
        /// Tri Parameter
        /// </summary>
        #endregion
    };
    public QueryFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public SqlCommand GetCommand(QueryBaseType type)
    {
        SqlCommand command = null;
        switch (type)
        {
            #region Student Finance
            case QueryBaseType.PaymentCancelReason:
                command = new SqlCommand("SELECT DESCP, R_ID FROM STU_FIN_FEE_MODE_CNL_REASON");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CalculationType:
                command = new SqlCommand("SELECT FINE_CAL_TYPE_VALUE, FINE_CAL_TYPE_ID FROM STU_FIN_FINE_CAL_TYPE_INF WHERE FINE_CAL_TYPE_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FeeFineRule:
                command = new SqlCommand("SELECT FINE_RULE_NAME, FINE_RULE_ID FROM STU_FIN_FINE_RULE_INF WHERE FINE_RULE_STS=1 ORDER BY FINE_RULE_ID DESC");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.BankName:
                command = new SqlCommand("SELECT BANK_VALUE, BANK_ID FROM BANK_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FeeAccount:
                command = new SqlCommand("SELECT BANK_AC_NO, BANK_AC_ID FROM FIN_BANK_ACC_DETAIL WHERE BANK_AC_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PayMode:
                command = new SqlCommand("SELECT PAY_MODE_VALUE, PAY_MODE_ID FROM PAY_MODE_INF WHERE PAY_MODE_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FeeProcess:
                command = new SqlCommand("SELECT FEE_PROS_NAME, FEE_PROS_ID FROM STU_FIN_FEE_PROCESS_INF WHERE FEE_PROS_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.GroupHeadId:
                command = new SqlCommand("SELECT [FEE_GROUP_HEAD_NAME],[FEE_GROUP_HEAD_ID] FROM [dbo].[STU_FIN_FEE_GROUP_HEAD_INF]");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.HeadId:
                command = new SqlCommand("SELECT FEE_MAIN_HEAD_NAME,FEE_MAIN_HEAD_ID FROM STU_FIN_FEE_MAIN_HEAD_INF WHERE FEE_GROUP_HEAD_ID IN (8,9) AND FEE_MAIN_HEAD_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.QuotaStu:
                command = new SqlCommand("SELECT QUOTA_NAME,QUOTA_CAT_ID FROM SAP_QUOTA_MASTER WHERE QUOTA_STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Session:
                command = new SqlCommand("SELECT ACA_SESSION_INF.ACA_SESN_VALUE, ACA_SESSION_INF.ACA_SESN_ID FROM ACA_SESSION_INF WHERE ACA_SESSION_INF.ACA_SESN_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.MainHeadId:
                command = new SqlCommand("SELECT FEE_MAIN_HEAD_NAME,FEE_MAIN_HEAD_ID FROM STU_FIN_FEE_MAIN_HEAD_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FacilityMainHeadId:
                command = new SqlCommand(" SELECT FEE_MAIN_HEAD_NAME,FEE_MAIN_HEAD_ID FROM STU_FIN_FEE_MAIN_HEAD_INF where STU_FIN_FEE_MAIN_HEAD_INF.FEE_MAIN_HEAD_ID in(13,14,15)");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Mode:
                command = new SqlCommand("SELECT PAY_MODE_VALUE,PAY_MODE_ID FROM PAY_MODE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FeesHeadType:
                command = new SqlCommand("SELECT HEAD_TYPE_FULL_NAME, HEAD_TYPE_ID FROM STU_FIN_FEE_HEAD_TYPE_INF  WHERE HEAD_TYPE_STS =1");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.TopHeadId:
                command = new SqlCommand("SELECT TOP_HEAD_NAME,TOP_HEAD_ID FROM STU_FIN_FEE_TOP_HEAD_INF WHERE TOP_HEAD_STS=1 ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FineCase:
                command = new SqlCommand("SELECT FINE_CASE,FINE_CASE_ID FROM STU_FIN_FINE_CASE");
                command.CommandType = CommandType.Text;
                break;

            #region RIJU
            case QueryBaseType.AdjType:
                command = new SqlCommand("SELECT REASON,ADJ_TYPE_ID FROM STU_FIN_ADJ_TYPE");
                command.CommandType = CommandType.Text;
                break;
            #endregion
 

        #endregion
            #region Payroll
            case QueryBaseType.Ref:
                command = new SqlCommand("SELECT REF_NO,RED_ID FROM  SAL_BANK_TRAN_REF");
                break;
            case QueryBaseType.TempType:
                command = new SqlCommand("SELECT SAL_TEMPLATE_NAME,SAL_TEMPLATE_ID FROM SAL_TEMPLATE_MASTER WHERE SAL_TEMP_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PayScale:
                command = new SqlCommand("SELECT SCALE,ID FROM SAL_SCALE_DESIG");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.HeadType:
                command = new SqlCommand("SELECT HEAD_NAME,HEAD_ID FROM SAL_HEAD_MASTER WHERE HEAD_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.TranDate:
                command = new SqlCommand("SELECT DISTINCT [TRAN_DATE] FROM SAL_EMP_FUND_TRAN");
                command.CommandType = CommandType.Text;
                break;
            #endregion
            #region TNP
            case QueryBaseType.Profile:
                command = new SqlCommand("SELECT JOB_PROFILE,JOB_PROFILE_ID FROM TNP_JOB_PROFILE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Comp_profile:
                command = new SqlCommand("SELECT PROFILE_VALUE,PROFILE_ID FROM TNP_COMP_PROFILE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.cmpny:
                command = new SqlCommand("SELECT COMP_NAME,COMP_ID FROM TNP_COMP_MAIN_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.IntSTATUS:
                command = new SqlCommand("SELECT STATUS_VALUE,STATUS_ID FROM TNP_STATUS_INF");
                command.CommandType = CommandType.Text;
                break;

            #endregion
            #region Examination
            case QueryBaseType.MinorExam:
                command = new SqlCommand("SELECT MINOR_VALUE,MINOR_SCH_ID FROM MINOR_SHEDULE_INF WHERE MINOR_SCH_STS=1");
                command.CommandType = CommandType.Text;             
                break;
            #endregion
            case QueryBaseType.Academic:
                command = new SqlCommand("SELECT ACA_BASE_FULL_NAME,ACA_BASE_ID FROM ACA_BASE_INF ORDER BY ACA_BASE_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AttType:
                command = new SqlCommand("SELECT ATT_TYPE_VALUE, ATT_TYPE_ID FROM EMP_ATT_TYPE_INF ORDER BY ATT_TYPE_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.RoomType:
                command = new SqlCommand("SELECT FAC_ROOM_VALUE, FAC_ROOM_TYP_ID FROM FAC_ROOM_TYPE_INF ORDER BY FAC_ROOM_TYP_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Initial:
                command = new SqlCommand("SELECT INI_VALUE, INI_ID FROM INI_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Authority:
                command = new SqlCommand("SELECT AUTHORITY_VALUE,AUTHORITY_ID FROM AUTHORITY_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Role:
                command = new SqlCommand("SELECT ROLE_VALUE,ROLE_ID FROM ROLE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Category:
                command = new SqlCommand("SELECT CAT_VALUE,CAT_ID FROM EMP_CAT_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Caste:
                command = new SqlCommand("SELECT CAS_VALUE, CAS_ID,CAS_ALIAS FROM CAS_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CasteAlias:
                command = new SqlCommand("SELECT CAS_ALIAS, CAS_ID FROM CAS_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Religion:
                command = new SqlCommand("SELECT REL_VALUE, REL_ID FROM REL_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.MotherTongue:
                command = new SqlCommand("SELECT MOT_TON_VALUE, MOT_TON_ID FROM MOT_TON_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.BloodGroup:
                command = new SqlCommand("SELECT BLO_GRP_VALUE, BLO_GRP_ID FROM BLO_GRP_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Department:
                command = new SqlCommand(" SELECT DEPT_VALUE, DEPT_ID FROM INS_DEPT_INF ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.LeaveType:
                command = new SqlCommand("SELECT  LV_VALUE, LV_ID FROM  LV_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.NextKinType:
                command = new SqlCommand("SELECT NEXT_KIN_VALUE, NEXT_KIN_ID FROM NEXT_KIN_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.DeptType:
                command = new SqlCommand("SELECT DEPT_TYPE_VALUE, DEPT_TYPE_ID FROM DEPT_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.DocumentType:
                command = new SqlCommand("SELECT DOC_NAME, DOC_ID FROM EMP_DOC_TYPE_INF WHERE DOC_STS=1 ORDER BY DOC_NAME");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ServiceType:
                command = new SqlCommand("SELECT SERV_TYPE_VALUE, SERV_TYPE_ID FROM SERV_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Designation:
                command = new SqlCommand("SELECT DES_VALUE, DES_ID FROM DES_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Institution:
                command = new SqlCommand("SELECT INS_VALUE, INS_ID FROM UNIV_INS_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.MenuHead:
                command = new SqlCommand(" SELECT HEAD_VALUE,HEAD_ID FROM PAGE_HEAD_INF WHERE HEAD_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.EmpSessionType:
                command = new SqlCommand("SELECT SES_TYPE_VALUE, SES_TYPE_ID FROM SES_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.State:
                command = new SqlCommand("SELECT STA_VALUE, STA_ID FROM STA_INF ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PhoneType:
                command = new SqlCommand("SELECT  PT.PHN_TYPE_VALUE, PT.PHN_TYPE_ID, PR.PHN_RULE_VALUE FROM PHN_TYPE_INF AS PT INNER JOIN PHN_TYPE_RULE_INF AS PTR ON PT.PHN_TYPE_ID = PTR.PHN_TYPE_ID INNER JOIN PHN_RULE_INF AS PR ON PTR.PHN_RULE_ID = PR.PHN_RULE_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Board:
                command = new SqlCommand("SELECT ACA_BRD_SHORT_NAME, ACA_BRD_ID FROM ACA_BRD_INF where ACA_BRD_INF.ACA_BRD_STS=1 ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Bank:
                command = new SqlCommand("SELECT BANK_VALUE, BANK_ID FROM BANK_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.University:
                command = new SqlCommand("SELECT UNIV_SHORT_NAME,UNIV_ID FROM UNIV_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.MailDomain:
                command = new SqlCommand("SELECT MAIL_DOM_VALUE,MAIL_DOM_ID FROM MAIL_DOM_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ShiftValue:
                command = new SqlCommand("SELECT SHIFT_VALUE, SHIFT_ID FROM SHIFT_INF WHERE SHIFT_STS=1 ORDER BY SHIFT_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ShiftWithTime:
                command = new SqlCommand("SELECT  SHIFT_INF.SHIFT_VALUE+'(InTime-'+ SHIFT_INF.IN_TIME+' With '+ Convert(varchar,SHIFT_TIME_INF.IN_AFT_TIME)+'Min After Out Time-'+ SHIFT_INF.OUT_TIME+' With'+Convert(varchar,SHIFT_TIME_INF.OUT_BFR_TIME)+' Min Before)'"
                    + " ,SHIFT_TIME_INF.TIME_ID FROM   SHIFT_INF INNER JOIN   SHIFT_TIME_INF ON SHIFT_INF.SHIFT_ID = SHIFT_TIME_INF.SHIFT_ID WHERE SHIFT_STS=1 AND SH_TIME_STS=1 ORDER BY SHIFT_TIME_INF.TIME_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Pattern:
                command = new SqlCommand("SELECT PTRN_VALUE, PTRN_ID FROM ACA_PATTERN_INF ORDER BY PTRN_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Organization:
                command = new SqlCommand("SELECT ORG_NAME, ORG_ID FROM EXP_ORG_INF ORDER BY ORG_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.OrgType:
                command = new SqlCommand("SELECT  OFF_TYPE_VALUE,OFF_TYPE_ID FROM ORG_TYPE_INF ORDER BY OFF_TYPE_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.WarningType:
                command = new SqlCommand("SELECT WARN_TYPE_DESC, WARN_TYPE_ID FROM WARNING_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.EmployeeStatus:
                command = new SqlCommand("SELECT STS_VALUE,STS_ID FROM EMP_STS_INF ORDER BY STS_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Country:
                command = new SqlCommand("SELECT COU_VALUE,COU_ID FROM COU_INF ORDER BY COU_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.JobType:
                command = new SqlCommand("SELECT  JOB_TYPE_VALUE, JOB_TYPE_ID FROM  JOB_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.JobTypeWithoutAll:
                command = new SqlCommand("SELECT  JOB_TYPE_VALUE, JOB_TYPE_ID FROM  JOB_TYPE_INF WHERE JOB_TYPE_ID<2");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.DayType:
                command = new SqlCommand(" SELECT DAY_TYPE_NAME, DAY_TYPE_ID FROM DAY_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.UserType:
                command = new SqlCommand(" SELECT USR_TYPE_VALUE, USR_TYPE_ID FROM USR_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.ExpType:
                command = new SqlCommand("SELECT EXP_TYPE_VALUE,EXP_TYPE_ID FROM EXP_TYPE_INF order by EXP_TYPE_VALUE");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Releived_Type:
                command = new SqlCommand("SELECT RELV_TYPE_VAL, RELV_TYPE_ID FROM RELV_TYPE_INF ORDER BY RELV_TYPE_VAL");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Status:
                command = new SqlCommand("SELECT STS_VALUE,STS_ID FROM EMP_STS_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Stu_Status:
                command = new SqlCommand("SELECT STU_STS_VALUE, STU_STS_ID FROM STU_STS_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.SemesterType:
                command = new SqlCommand("SELECT SEMESTER_TYPE_NAME,SEMESTER_TYPE_ID FROM SEMESTER_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ProgramType:
                command = new SqlCommand("SELECT PRG_TYPE_VALUE,PRG_TYPE_ID FROM PGM_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Stu_Qual:
                command = new SqlCommand("SELECT  ACA_BASE_SHORT_NAME, ACA_BASE_ID FROM ACA_BASE_INF WHERE (ACA_BASE_STS = 1)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.DegreeType:
                command = new SqlCommand("SELECT DRG_VALUE,DGR_ID FROM  PGM_DGR_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.DocumentSingle:
                command = new SqlCommand("SELECT DOC_VALUE,DOC_ID FROM  STU_DOC_TYPE_INF WHERE DOC_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Quota:
                command = new SqlCommand("SELECT QUOTA_NAME, QUOTA_ID FROM  ADM_QUOTA_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Semester:
                command = new SqlCommand("SELECT ACA_SEM_NO,ACA_SEM_ID FROM ACA_SEM_INF WHERE ACA_SEM_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Program:
                command = new SqlCommand("SELECT PGM_SHORT_NAME,INS_PGM_ID FROM INS_PGM_INF WHERE PGM_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Nationality:
                command = new SqlCommand("SELECT NAT_VALUE,NAT_ID FROM NATION_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AdmCategory:
                command = new SqlCommand("SELECT ENT_EXAM_SHORT_NAME,ENT_EXAM_ID FROM ADM_ENT_EXAM_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Section:
                command = new SqlCommand("SELECT ACA_SEC_NAME,ACA_SEC_ID FROM ACA_SEC_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CITY:
                command = new SqlCommand("SELECT CIT_VALUE,CIT_ID FROM CIT_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.DirectBranch:
                command = new SqlCommand("SELECT BRN_SHORT_NAME,PGM_BRN_ID FROM INS_PGM_BRN_INF WHERE PGM_BRN_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AdrsType:
                command = new SqlCommand("SELECT ADD_TYPE_VALUE,ADD_TYPE_ID FROM ADD_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Relation:
                command = new SqlCommand("SELECT RELATION_NAME,RELATION_ID FROM RELATION_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.EmpID:
                command = new SqlCommand("SELECT EMP_ID,EMP_ID FROM EMP_PF_INF WHERE PF_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.SubjectType:
                command = new SqlCommand("SELECT SUB_TYPE_VALUE, SUB_TYPE_ID FROM ACA_SUB_TYPE_INF WHERE STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.branch:
                command = new SqlCommand("SELECT BRN_SHORT_NAME,PGM_BRN_ID FROM INS_PGM_BRN_INF WHERE PGM_BRN_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.SecurityQuestion:
                command = new SqlCommand("SELECT QSN,QSN_ID FROM PAS_QSN_INF where status=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.HOD:
                command = new SqlCommand("SELECT DISTINCT EMP_MAIN_INF.EMP_NAME, EMP_MAIN_INF.EMP_ID FROM INS_DEPT_HEAD_INF INNER JOIN EMP_MAIN_INF ON INS_DEPT_HEAD_INF.TO_DATE IS NULL INNER JOIN "
                                        + "UserView ON EMP_MAIN_INF.EMP_ID = UserView.USR_LOGIN_ID AND INS_DEPT_HEAD_INF.USR_ID = UserView.USR_ID ORDER BY  EMP_MAIN_INF.EMP_NAME");

                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.NextSenior:
                command = new SqlCommand("SELECT DISTINCT EMP_MAIN_INF.EMP_NAME, EMP_NXT_SNR_CNG_INF.EMP_NEXT_SNR_ID FROM EMP_MAIN_INF INNER JOIN EMP_NXT_SNR_CNG_INF ON EMP_MAIN_INF.EMP_ID = EMP_NXT_SNR_CNG_INF.EMP_NEXT_SNR_ID WHERE TO_DATE IS NULL");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Year:
                command = new SqlCommand("SELECT DISTINCT YEAR(DOJ) AS YY FROM EMP_MAIN_INF WHERE DOJ IS NOT NULL ORDER BY YEAR(DOJ) DESC");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AcademicEvent:
                command = new SqlCommand("SELECT ACA_EVENT_VALUE, ACA_EVENT_ID FROM ACA_EVENT_INF WHERE ACA_EVENT_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Reg_Sem:
                command = new SqlCommand("SELECT CON_REG_NAME, CON_REG_ID FROM STU_SEM_REG_CONFIG_INF ORDER BY CON_REG_ID DESC");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Reg_Type:
                command = new SqlCommand("select SEM_REG_TYPE_VALUE,SEM_REG_TYPE_ID from SEM_RE_REG_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AdmType:
                command = new SqlCommand("select ADM_TYPE_VALUE,ADM_TYPE_ID FROM ADM_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.BlockType:
                command = new SqlCommand("select block_type_value,block_type_id from block_type_inf");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.StuInfSts:
                command = new SqlCommand("select STS_VALUE,STS_ID from PROC_STS_TYPE_INF where STS_ID in(6,0) order by STS_VALUE");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.StuDocument:
                command = new SqlCommand("SELECT STU_DOC_TYPE_INF.DOC_VALUE, STU_DOC_TYPE_INF.DOC_ID "
                                          + " FROM STU_DOC_TYPE_INF INNER JOIN PGM_DOC_MAP_INF ON STU_DOC_TYPE_INF.DOC_ID = PGM_DOC_MAP_INF.DOC_ID "
                                          + " WHERE (STU_DOC_TYPE_INF.DOC_STS = 1) AND (PGM_DOC_MAP_INF.INS_PGM_ID IN(0))");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.IssueSts:
                command = new SqlCommand("SELECT ISSUE_STS_VALUE, ISSUE_STS_ID FROM ISSUE_STS");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Paper_type:
                command = new SqlCommand("select sub_type_value,sub_type_id from ACA_SUB_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PendingWith:
                command = new SqlCommand("SELECT ROLE_VALUE,ROLE_ID FROM  ROLE_INF WHERE ROLE_ID in (1,2,4,5,71,64) AND ROLE_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            //case QueryBaseType.EmpName:
            //    command = new SqlCommand("SELECT EMP_NAME,TPT_SPL_APR_BY_INF.EMP_ID FROM TPT_SPL_APR_BY_INF inner join EMP_MAIN_INF on EMP_MAIN_INF.EMP_ID = TPT_SPL_APR_BY_INF.EMP_ID where STATUS = 1");
            //    command.CommandType = CommandType.Text;
            //    break;
            case QueryBaseType.EmpName:
                command = new SqlCommand("SELECT EMP_NAME,TPT_STU_FIN_SPL_INF.APR_BY FROM TPT_STU_FIN_SPL_INF inner join EMP_MAIN_INF on EMP_MAIN_INF.EMP_ID = TPT_STU_FIN_SPL_INF.APR_BY ");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.sts:
                command = new SqlCommand("select STS_VALUE,STS_ID from PROC_STS_TYPE_INF where STS_ID in(6,0,-2) order by STS_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.SemType:
                command = new SqlCommand("SELECT SEM_TYPE_VALUE,SEM_TYPE_ID from ACA_SEM_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ConcessionRule:
                command = new SqlCommand("SELECT  CONC_RULE_NAME,CONC_RULE_ID FROM STU_FIN_CONC_RULE_INF WHERE (RULE_STATUS = 1)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Examination:
                command = new SqlCommand("SELECT EXAM_NAME,EXAM_MAIN_ID FROM EXAMINATION..EXAM_MAIN_INF WHERE EXAM_STS=1 ORDER BY EXAM_MAIN_ID");
                command.CommandType = CommandType.Text;
                break;
            #region inventory
            case QueryBaseType.INV_CATEGORY:
                command = new SqlCommand("Select CAT_Name,CAT_Id from INV_CAT_MASTER WHERE CAT_STS=1  ORDER BY CAT_NAME");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Store:
                command = new SqlCommand("Select STO_NAME,STO_Id from INV_STORE_MASTER WHERE STO_STS=1 order by STO_NAME ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Unit:
                command = new SqlCommand("Select UNIT_NAME,UNIT_ID from INV_ITEM_UNIT_INFO WHERE (UNIT_STS = 1) ORDER BY UNIT_NAME");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Vendor:
                command = new SqlCommand("Select ORG_NAME,VENDOR_ID from INV_VENDOR_INF WHERE (VENDOR_STS = 1) ORDER BY ORG_NAME");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Req_Status:
                command = new SqlCommand("SELECT STS_VALUE,STS_ID FROM PROC_STS_TYPE_INF WHERE (STS_ID <> - 1) AND (STS_ID <> 8) ORDER BY STS_VALUE");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PurOrderRpt:
                command = new SqlCommand("SELECT PO_NO, PO_ID FROM INV_PUR_ORDER_MASTER ORDER BY PO_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Status_Ind:
                command = new SqlCommand("SELECT IND_STEP_VALUE, IND_STEP_ID FROM INV_STO_IND_STEP_INF" +
                                          " WHERE(IND_STEP_ID <> 4) ORDER BY IND_STEP_VALUE");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.POMod:
                command = new SqlCommand("SELECT PO_NO, PO_ID FROM  INV_PUR_ORDER_MASTER" +
                                         " WHERE (PO_ID  NOT IN (SELECT PO_ID FROM  INV_STO_GRN_INF))ORDER BY PO_ID desc");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.PurReqNo:
                command = new SqlCommand("SELECT PUR_REQ_NO, PUR_REQ_ID FROM INV_PUR_REQ_MASTER ORDER BY PUR_REQ_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ITEM:
                command = new SqlCommand("Select ITEM_NAME,ITEM_Id from INV_ITEM_MASTER  ORDER BY ITEM_NAME ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FANId:
                command = new SqlCommand("SELECT FAN_NO, FAN_ID FROM INV_PUR_FAN_MASTER WHERE(FAN_STATUS = 0)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Dept_Name:
                command = new SqlCommand("SELECT DEPT_VALUE,DEPT_ID FROM INS_DEPT_INF ORDER BY DEPT_value");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PurId:
                command = new SqlCommand("SELECT  DISTINCT INV_PUR_REQ_MASTER.PUR_REQ_NO,INV_PUR_FAN_MASTER.FAN_PUR_ID FROM INV_PUR_FAN_MASTER INNER JOIN INV_PUR_REQ_MASTER ON INV_PUR_FAN_MASTER.FAN_PUR_ID = INV_PUR_REQ_MASTER.PUR_REQ_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AssignBy:
                command = new SqlCommand("SELECT DISTINCT EMP_MAIN_INF.EMP_NAME, INV_PUR_FAN_MASTER.FAN_ASSIGN_BY FROM INV_PUR_FAN_MASTER INNER JOIN EMP_MAIN_INF ON INV_PUR_FAN_MASTER.FAN_ASSIGN_BY = EMP_MAIN_INF.EMP_ID");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.FANStatus:
                command = new SqlCommand("SELECT STS_VALUE, STS_ID FROM  INV_FAN_STATUS");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.RFQ_No:
                command = new SqlCommand("SELECT PUR_RFQ_NO, PUR_RFQ_ID FROM INV_PUR_RFQ_MASTER WHERE (PUR_RFQ_STS = 1)");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.PurTerm:
                command = new SqlCommand("SELECT PUR_TERM, PUR_TERM_ID FROM INV_PUR_TERM_MASTER WHERE(PUR_TERM_STATUS = 1)");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Sto_Rcv_By:
                command = new SqlCommand("SELECT dbo.EmployeeName(RCV_BY) AS RCV_BY_VALUE, RCV_BY FROM INV_STO_RCV_INF WHERE(RCV_TYPE_ID = 1) AND (STATUS = 1)");
                command.CommandType = CommandType.Text;
                break;


            case QueryBaseType.PO_PurReqNo:
                command = new SqlCommand("SELECT PUR_REQ_NO, PUR_REQ_ID, PUR_REQ_STS FROM INV_PUR_REQ_MASTER WHERE (PUR_REQ_STS = 5)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Sub:
                command = new SqlCommand("SELECT SUB_CAT_NAME, SUB_CAT_ID FROM INV_SUB_CAT_MASTER WHERE CAT_ID=165");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.GRN_NO_AVAL:
                command = new SqlCommand("SELECT   distinct  top 70  GRN_NO ,INV_STO_GRN_INF.GRN_ID FROM  INV_STO_GRN_INF INNER JOIN INV_STO_GRN_ITEM_INF ON INV_STO_GRN_INF.GRN_ID = INV_STO_GRN_ITEM_INF.GRN_ID INNER JOIN INV_PUR_ORDER_MASTER ON INV_STO_GRN_INF.PO_ID = INV_PUR_ORDER_MASTER.PO_ID INNER JOIN  INV_STORE_MASTER ON INV_PUR_ORDER_MASTER.PO_STORE_ID = INV_STORE_MASTER.STO_ID WHERE (INV_STO_GRN_ITEM_INF.AVLBL_QTY <> 0) and INV_STORE_MASTER.STO_NAME='general Store' order by GRN_NO desc");
                command.CommandType = CommandType.Text;
                break;
            # endregion
            #region store

            case QueryBaseType.IND_BY_TYPE:
                command = new SqlCommand("SELECT IND_BY_TYPE_VALUE, IND_BY_TYPE_ID FROM INV_STO_IND_BY_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.IND_ID:
                command = new SqlCommand("SELECT IND_CAL_ID, IND_ID FROM INV_STO_IND_INF");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Ind_Status:
                command = new SqlCommand("SELECT  STS_VALUE, STS_ID FROM PROC_STS_TYPE_INF WHERE(STS_ID <> - 1) AND (STS_ID <> 5)ORDER BY STS_VALUE");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Sto_PO:
                command = new SqlCommand("SELECT PO_NO, PO_ID FROM INV_PUR_ORDER_MASTER");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.GRN_NO:
                command = new SqlCommand("SELECT GRN_NO, GRN_ID FROM INV_STO_GRN_INF");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.GRN_RcvBy:
                command = new SqlCommand("SELECT DISTINCT EMP_VIEW.EMP_NAME, EMP_VIEW.EMP_ID FROM INV_STO_GRN_INF INNER JOIN EMP_VIEW ON INV_STO_GRN_INF.RCV_BY = EMP_VIEW.EMP_ID");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.SIV_Id:
                command = new SqlCommand("SELECT SIV_CAL_ID, SIV_ID FROM INV_STO_SIV_INF");
                command.CommandType = CommandType.Text;
                break;
            #endregion
            #region Facility
            case QueryBaseType.CurrentSession:
                command = new SqlCommand("SELECT max(ACA_SESSION_INF.ACA_SESN_VALUE),SLOT_ID " +
                                        "  FROM ACA_SESSION_INF INNER JOIN HSTL_REG_SLOT_MAPP_INF " +
                                        " ON HSTL_REG_SLOT_MAPP_INF.SESSION_ID=ACA_SESSION_INF.ACA_SESN_ID " +
                                        " WHERE (HSTL_REG_SLOT_MAPP_INF.STS=1) GROUP BY ACA_SESN_VALUE,SLOT_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Sem:
                command = new SqlCommand("SELECT DISTINCT ACA_SEM_NO, ACA_SEM_ID FROM ACA_SEM_INF WHERE ACA_SEM_STS = 1");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Room:
                command = new SqlCommand("SELECT ROOM_NO, ROOM_ID FROM FAC_ROOM_INF WHERE ROOM_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Gender:
                command = new SqlCommand("SELECT GEN_VALUE, GEN_ID FROM GEN_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.TptCity:
                command = new SqlCommand("SELECT CITY_NAME,CITY_ID FROM TPT_CITY_INF WHERE STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.RouteName:
                command = new SqlCommand("SELECT RTE_NAME,RTE_ID FROM TPT_RTE_INF WHERE STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.SlotPrd:
                command = new SqlCommand("SELECT SLOT_PRD,SLOT_ID FROM TPT_DATE_SLOT_MAPP_INF where STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.BusType:
                command = new SqlCommand("SELECT BUS_TYPE_VALUE,BUS_TYPE_ID FROM TPT_BUS_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.BusNo:
                command = new SqlCommand("SELECT BUS_ID FROM TPT_BUS_INF WHERE STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PerType:
                command = new SqlCommand("SELECT PER_VALUE, PER_TYPE, HAS_DATE, IS_FREE FROM TPT_FIN_SPL_PER_TYPE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ComplexType:
                command = new SqlCommand("SELECT  FAC_CMPLX_TYP_VALUE,FAC_CMPLX_TYP_ID  FROM FAC_COMPLEX_TYPE_INF WHERE FAC_CMPLX_TYP_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CmplxName:
                command = new SqlCommand("SELECT FAC_CMPLX_NAME, FAC_CMPLX_ID FROM FAC_COMPLEX_INF WHERE FAC_CMPLX_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.RoomCategoryType:
                command = new SqlCommand("SELECT  FAC_ROOM_CATEGORY_NAME,FAC_ROOM_CATEGORY_ID  FROM FAC_ROOM_CAT_INF where FAC_ROOM_CATEGORY_STS = 1 ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ResCmplxName:
                command = new SqlCommand("SELECT FAC_CMPLX_NAME,FAC_CMPLX_ID FROM FAC_COMPLEX_INF WHERE FAC_CMPLX_STS = 1 AND FAC_CMPLX_TYP_ID = 2");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AllotedRoom:
                command = new SqlCommand("SELECT EMP_VIEW.EMP_NAME + ':' + convert(varchar,FAC_HSTL_ROOM_ALLOTMENT.ALLOTED_TO) " +
                                          "FROM FAC_HSTL_ROOM_ALLOTMENT INNER JOIN " +
                                            "EMP_VIEW ON FAC_HSTL_ROOM_ALLOTMENT.ALLOTED_TO = EMP_VIEW.EMP_ID " +
                                                "WHERE(FAC_HSTL_ROOM_ALLOTMENT.LEAVING_DATE IS NULL)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.AprValue:
                command = new SqlCommand("SELECT APR_VALUE, APR_ID FROM TPT_APR_INF WHERE STATUS = 1 AND APR_ID IN (1,2)");
                command.CommandType = CommandType.Text;
                break;
            //case QueryBaseType.PayMode:
            //    command = new SqlCommand("SELECT PAY_MODE_VALUE,PAY_MODE_ID FROM PAY_MODE_INF WHERE PAY_MODE_STATUS = 1");
            //    command.CommandType = CommandType.Text;
            //    break;
            case QueryBaseType.AcNo:
                command = new SqlCommand("SELECT BANK_AC_NO, BANK_AC_ID FROM FIN_BANK_ACC_DETAIL WHERE BANK_AC_STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.HallCmplx:
                command = new SqlCommand("SELECT FAC_CMPLX_NAME, FAC_CMPLX_ID FROM FAC_COMPLEX_INF WHERE (FAC_CMPLX_TYP_ID = 4) AND (FAC_CMPLX_STS = 1)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CityName:
                command = new SqlCommand("SELECT CITY_NAME,CITY_ID FROM TPT_CITY_INF WHERE STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            //case QueryBaseType.AppBy:
            //    command = new SqlCommand("SELECT DISTINCT EMP_VIEW.EMP_NAME FROM TPT_STU_APR_INF INNER JOIN EMP_VIEW ON TPT_STU_APR_INF.APR_BY = EMP_VIEW.EMP_ID");
            //    command.CommandType = CommandType.Text;
            //    break;
            case QueryBaseType.AppBy:
                command = new SqlCommand("SELECT DISTINCT EMP_VIEW.EMP_NAME FROM TPT_STU_REG_TRAN_INF INNER JOIN EMP_VIEW ON TPT_STU_REG_TRAN_INF.IN_BY = EMP_VIEW.USR_ID");
                command.CommandType = CommandType.Text;
                break;
            
            case QueryBaseType.Driver:
                command = new SqlCommand("SELECT EMP_VIEW.EMP_NAME,FAC_DRIVER_MAIN.DRIVER_EMP_CODE FROM FAC_DRIVER_MAIN INNER JOIN EMP_VIEW ON FAC_DRIVER_MAIN.DRIVER_EMP_CODE = EMP_VIEW.EMP_ID WHERE FAC_DRIVER_MAIN.DRIVER_STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Vehicle:
                command = new SqlCommand("SELECT VEH_REG_NO,VEH_ID FROM FAC_VEHICLE_MAIN WHERE STATUS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.VehStatus:
                command = new SqlCommand("SELECT STS_VALUE, STS_ID FROM PROC_STS_TYPE_INF WHERE STS_ID < 5 and STS_ID != -1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.EvntItem:
                command = new SqlCommand("SELECT ITEM_VALUE,ITEM_ID FROM FAC_HALL_EVENT_STORE_ITEM");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Evnt:
                command = new SqlCommand("SELECT EVENT_INFO, EVENT_ID FROM EVENT_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.HstlCmplx:
                command = new SqlCommand("SELECT distinct  FAC_COMPLEX_INF.FAC_CMPLX_NAME,FAC_HSTL_STAFF_MAIN.CMPLX_ID FROM FAC_HSTL_STAFF_MAIN INNER JOIN FAC_COMPLEX_INF ON FAC_HSTL_STAFF_MAIN.CMPLX_ID = FAC_COMPLEX_INF.FAC_CMPLX_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.HstlRomType:
                command = new SqlCommand("SELECT DISTINCT CONVERT(varchar, MAXIMUM_PRSN) + ' seater',MAXIMUM_PRSN FROM FAC_ROOM_INF WHERE (CMPLX_ID in( 19,3,27))");
                command.CommandType = CommandType.Text;
                break;
            #region Priya
            case QueryBaseType.Course:
                command = new SqlCommand("SELECT PGM_SHORT_NAME,INS_PGM_ID  FROM INS_PGM_INF WHERE PGM_STS=1 ");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Batch:
                command = new SqlCommand("SELECT ACA_BATCH_NAME,ACA_BATCH_ID  FROM ACA_BATCH_INF WHERE ACA_BATCH_STS=1 ORDER BY ACA_BATCH_NAME DESC");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Semester_id:
                command = new SqlCommand("SELECT ACA_SEM_ID, ACA_BAT_SEM_ID FROM ACA_BATCH_SEM_INF WHERE ACA_BAT_SEM_STS = 1 ORDER BY ACA_SEM_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Semester_Batch:
                command = new SqlCommand("SELECT ACA_BATCH_SEM_INF.ACA_SEM_ID, ACA_BATCH_INF.ACA_BATCH_NAME FROM ACA_BATCH_INF INNER JOIN ACA_BATCH_SEM_INF ON ACA_BATCH_INF.ACA_BATCH_ID = ACA_BATCH_SEM_INF.ACA_BATCH_ID WHERE ACA_BAT_SEM_STS=1 AND ACA_BATCH_STS=1 ORDER BY ACA_BATCH_SEM_INF.ACA_SEM_ID");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Complex:
                command = new SqlCommand("SELECT FAC_CMPLX_NAME, FAC_CMPLX_ID FROM FAC_COMPLEX_INF WHERE FAC_CMPLX_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ComplexForTT:
                command = new SqlCommand("SELECT FAC_CMPLX_NAME, FAC_CMPLX_ID FROM FAC_COMPLEX_INF WHERE FAC_CMPLX_TYP_ID=1 AND FAC_CMPLX_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Group:
                command = new SqlCommand("SELECT GRP_VALUE, GRP_ID FROM TT_GRP_INF WHERE IS_VALID = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.TimeSlot:
                command = new SqlCommand("SELECT TT_SLOT_VALUE, TT_SLOT_ID FROM TT_TIME_SLOT_INF WHERE TT_SLOT_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.ExamTimeSlot:
                command = new SqlCommand("SELECT TT_SLOT_VALUE, TT_SLOT_ID FROM TT_TIME_SLOT_INF WHERE TT_EXAM_STS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CreditType:
                command = new SqlCommand("SELECT CREDIT_NAME,CR_TYPE_ID FROM CREDIT_TYPE_INF WHERE STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            #endregion
            #region issue
            case QueryBaseType.IssueCat:
                command = new SqlCommand("SELECT ISSUE_CAT_VALUE,ISSUE_CAT_ID FROM ISSUE_CATEGORY_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.IssueDept:
                command = new SqlCommand("SELECT HEAD_VALUE, HEAD_ID FROM ISSUE_HEAD_INF WHERE HEAD_STS = 1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.SolDept:
                command = new SqlCommand("SELECT SOL_SEC_VALUE,SOL_SEC_ID FROM ISSUE_SOLUTION_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.EmpIssueCat:
                command = new SqlCommand("SELECT HEAD_VALUE, HEAD_ID FROM ISSUE_HEAD_INF WHERE (ISSUE_CAT_ID = 2) AND (HEAD_STS = 1)");
                command.CommandType = CommandType.Text;
                break;
            #endregion

            case QueryBaseType.EmpCrs:
                command = new SqlCommand("SELECT ACA_CRS_VALUE, ACA_CRS_ID FROM ACA_CRS_INF WHERE (ACA_CRS_STS=1) ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Div:
                command = new SqlCommand("SELECT ACA_DIV_VALUE,ACA_DIV_ID FROM DIV_INF ");
                command.CommandType = CommandType.Text;
                break;


            # endregion
            #region Interview
            case QueryBaseType.JobNo:
                command = new SqlCommand("SELECT JOB_NO, JOB_ID FROM INT_JOB_MAIN_INF WHERE (STS = 1)");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.IntMode:
                command = new SqlCommand("SELECT INT_MODE_VALUE, INT_MODE_ID FROM INT_MODE_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.IntSts:
                command = new SqlCommand("SELECT INT_STS_VALUE, INT_STS_ID FROM INT_STS_INF WHERE (INT_STS_ID<9) OR (INT_STS_ID=11) ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.IntDate:
                command = new SqlCommand("SELECT CONVERT(VARCHAR,INT_DATE,103),INT_MAIN_ID FROM INT_MAIN_INF ");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Job:
                command = new SqlCommand("SELECT JOB_NO, JOB_ID FROM INT_JOB_MAIN_INF ");
                command.CommandType = CommandType.Text;
                break;

            #endregion
            #region Notice
            case QueryBaseType.Notice_For:
                command = new SqlCommand("SELECT NOTICE_FOR_VALUE, NOTICE_FOR_ID FROM NOTICE_FOR_MASTER");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.Upload_Type:
                command = new SqlCommand("SELECT  TYPE_VALUE,  TYPE_ID FROM  NOTICE_FILE_TYPE_MAIN");
                command.CommandType = CommandType.Text;
                break;
            #endregion
                #region MINOR
  case QueryBaseType.Shift:
                    command = new SqlCommand("SELECT  EXAM_SHIFT_VALUE,EXAM_SHIFT_ID FROM EXAM_SHIFT_INF");
                    command.CommandType = CommandType.Text;
                    break;
#endregion
  #region OpenElect
  case QueryBaseType.OpnElecPap:
                    command = new SqlCommand("SELECT PAPER_CODE,PAPER_ID FROM OPEN_ELEC_MAIN_INF");
                    command.CommandType = CommandType.Text;
                    break;
  #endregion
            case QueryBaseType.VacTyp:
                command = new SqlCommand("SELECT VAC_TYPE_VALUE, VAC_TYPE_ID FROM VAC_TYP_INF ");
                command.CommandType = CommandType.Text;
                break;
            #region Appraisal
            case QueryBaseType.UnivLevel:
                command = new SqlCommand("SELECT PA03_UNIV_LVL_VALUE, PA03_UNIV_LVL_ID FROM PA03_UNIV_LVL_INF  WHERE PA03_UNIV_LVL_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.OPMF:
                command = new SqlCommand("SELECT PA03_OPMF_VALUE, PA03_OPMF_ID FROM PA03_OPMF_INF  WHERE PA03_OPMF_STATUS=1");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PAStatus:
                command = new SqlCommand("SELECT PA03_PA_STATUS_VALUE, PA03_PA_STATUS_ID FROM PA03_PA_STATUS_INF");
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.PAFacSts:
                command = new SqlCommand("SELECT STAT_VALUE, STAT_ID FROM PA03_FAC_STATUS_INF ORDER BY STAT_ID");
                command.CommandType = CommandType.Text;
                break;
            #endregion

            case QueryBaseType.TotlItem:
                command = new SqlCommand("SELECT ITEM_NAME,ITEM_ID FROM INV_ITEM_MASTER  ORDER BY ITEM_NAME ");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Carry_Person:
                command = new SqlCommand("SELECT   case when CARRY_PERSON_TYPE=1 then EMP_VIEW.EMP_NAME+'-'+CONVERT(VARCHAR,EMP_VIEW.EMP_ID) else INV_GATE_PASS_INF.CARRY_PER_NAME end as NAME,PASS_ID from INV_GATE_PASS_INF left outer JOIN EMP_VIEW ON INV_GATE_PASS_INF.CARRY_PER_ID = EMP_VIEW.EMP_ID order by NAME ");
                command.CommandType = CommandType.Text;
                break;

            case QueryBaseType.Gate_Pass_Rcv:
                command = new SqlCommand("SELECT DISTINCT INV_GATE_PASS_INF.PASS_NUMBER,INV_GATE_PASS_INF.PASS_ID FROM INV_GATE_PASS_INF INNER JOIN INV_GATE_PASS_ITEM_INF "
 + " ON INV_GATE_PASS_INF.PASS_ID = INV_GATE_PASS_ITEM_INF.PASS_ID left outer join INV_GATE_PASS_RCV on INV_GATE_PASS_RCV.PASS_ID=INV_GATE_PASS_ITEM_INF.PASS_ID "
+ " left outer join INV_GATE_PASS_RCV_ITEM_DTL on INV_GATE_PASS_RCV_ITEM_DTL.RTN_ID=INV_GATE_PASS_RCV.RTN_ID "
+ " and INV_GATE_PASS_RCV_ITEM_DTL.ITEM_ID=INV_GATE_PASS_ITEM_INF.ITEM_ID "
+ "  WHERE  (INV_GATE_PASS_INF.PASS_TYPE = 1) group by PASS_NUMBER,INV_GATE_PASS_INF.PASS_ID,INV_GATE_PASS_ITEM_INF.ITEM_NAME,INV_GATE_PASS_ITEM_INF.QTY "
 + " having INV_GATE_PASS_ITEM_INF.QTY>ISNULL(SUM(INV_GATE_PASS_RCV_ITEM_DTL.RTN_QTY), 0) order by INV_GATE_PASS_INF.PASS_ID");
                command.CommandType = CommandType.Text;
                break;
           
            default:
                break;
        }
        return command;
    }
    public SqlCommand GetCommand(QueryBaseType type, string parameter)
    {
        SqlCommand command = null;
        switch (type)
        {
            #region Payroll
            case QueryBaseType.HeadType:
                command = new SqlCommand("SELECT HEAD_NAME,HEAD_ID FROM SAL_HEAD_MASTER WHERE HEAD_STATUS=1 AND HEAD_TYPE_ID= @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            #endregion
            #region Student Finance
            case QueryBaseType.FeeTemplate:
                command = new SqlCommand("SELECT DISTINCT FEE_TEMP_ID FROM STU_FIN_FEE_STRC_SUB_INF  WHERE  FEE_STRC_MAIN_ID= @PARAMETER ORDER BY  FEE_TEMP_ID");
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.StuBranch:
                command = new SqlCommand("SELECT DISTINCT BRN_SHORT_NAME,PGM_BRN_ID,StuView.STU_STS_ID FROM STUVIEW WHERE ENROLLMENT_NO = @PARAMETER ORDER BY StuView.STU_STS_ID");
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.FineHeads:
                command = new SqlCommand("SELECT FEE_MAIN_HEAD_NAME, FEE_MAIN_HEAD_ID FROM STU_FIN_FEE_MAIN_HEAD_INF WHERE FEE_MAIN_HEAD_STS =1 AND FEE_GROUP_HEAD_ID= @PARAMETER");
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                command.CommandType = CommandType.Text;
                break;

            #endregion
            #region TNP
            case QueryBaseType.Company:
                command = new SqlCommand("SELECT CM.COMP_NAME,CM.COMP_ID FROM TNP_COMP_MAIN_INF CM JOIN TNP_COMP_PROFILE_INF CP ON CM.COMP_PROFILE = CP.PROFILE_ID where CP.PROFILE_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Job_profile:
                command = new SqlCommand("SELECT JP.JOB_PROFILE,JP.JOB_PROFILE_ID FROM TNP_JOB_PROFILE_INF JP JOIN TNP_COMP_MAIN_INF CM ON JP.COMP_ID=CM.COMP_ID WHERE CM.COMP_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Intdate:
                command = new SqlCommand("SELECT CONVERT(VARCHAR,ISM.INTERVIEW_DT,103),ISM.INT_SHEDULE_MAIN_ID FROM TNP_INT_SHEDULE_MAIN_INF ISM JOIN TNP_JOB_MAIN_INF JM ON ISM.JOB_MAIN_ID=JM.JOB_MAIN_ID WHERE JOB_PROFILE_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Job_Location:
                command = new SqlCommand("Select JOB_LOCATION from TNP_JOB_MAIN_INF WHERE JOB_PROFILE_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;


            #endregion
            #region Examination
            case QueryBaseType.FacultyCourse:
                command = new SqlCommand("SELECT DISTINCT EVA_SCH_PAPER_CODE FROM  CRS_VW INNER JOIN "
                         + " TT_DET_INF ON CRS_VW.TT_ID = TT_DET_INF.TT_ID INNER JOIN"
                         + " TT_ASN_INF ON TT_ASN_INF.TT_DET_ID=TT_DET_INF.TT_DET_ID"
                         + " WHERE TT_DET_INF.CLS_STS_ID=1  AND EMP_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            #endregion
            case QueryBaseType.State:
                command = new SqlCommand("SELECT STA_VALUE, STA_ID FROM STA_INF WHERE COU_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.City:
                command = new SqlCommand("SELECT CIT_VALUE, CIT_ID FROM CIT_INF WHERE STA_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
              case QueryBaseType.INV_CATEGORY:
                command = new SqlCommand("Select CAT_Name,CAT_Id from INV_CAT_MASTER WHERE CAT_STS=1 AND STORE_ID=@PARAMETER  ORDER BY CAT_NAME");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
                case QueryBaseType.IssueDeptByUser:
                command = new SqlCommand("SELECT INS_DEPT_INF.DEPT_VALUE,INS_DEPT_INF.DEPT_ID FROM ISSUE_USR_MAPP_INF INNER JOIN INS_DEPT_INF ON ISSUE_USR_MAPP_INF.DEPT_ID=INS_DEPT_INF.DEPT_ID  WHERE TO_DATE IS NULL AND USR_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.PrimeLocation:
                command = new SqlCommand("SELECT PRI_LOC_VALUE, PRI_LOC_ID FROM PRI_LOC_INF WHERE CIT_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Department:
                command = new SqlCommand("SELECT DEPT_VALUE, DEPT_ID FROM INS_DEPT_INF WHERE INS_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.MenuSubHead:
                command = new SqlCommand(" SELECT SUB_HEAD_VALUE,SUB_HEAD_ID FROM PAGE_SUB_HEAD_INF WHERE SUB_HEAD_STS=1 AND HEAD_ID = @PARAMETER ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.EmpByDept:
                command = new SqlCommand("SELECT DISTINCT EM.EMP_NAME, EM.EMP_ID FROM EMP_MAIN_INF EM JOIN EMP_DEPT_CNG_INF ED ON EM.EMP_ID=ED.EMP_ID WHERE  ED.DEPT_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.EmpDocument:
                command = new SqlCommand("SELECT DOC_TYPE_INF.DOC_NAME, EMP_DOCUMENT_DETAIL.DOC_DTL_ID FROM EMP_DOC_DETAIL_INF EMP_DOCUMENT_DETAIL INNER JOIN DOC_TYPE_INF ON EMP_DOCUMENT_DETAIL.DOC_ID = DOC_TYPE_INF.DOC_ID WHERE DOC_DTL_ID NOT IN(SELECT DOC_DTL_ID FROM EMP_DOC_UPLD_INF) AND EMP_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Emp_ByArr:
                command = new SqlCommand("SELECT DISTINCT EMP_MAIN_INF.EMP_NAME, EMP_MAIN_INF.EMP_ID FROM  EMP_LV_ARR_INF INNER JOIN EMP_LV_APP_INF ON EMP_LV_ARR_INF.LV_APP_ID = EMP_LV_APP_INF.LV_APP_ID INNER JOIN USR_INF ON EMP_LV_APP_INF.USR_ID = USR_INF.USR_ID INNER JOIN EMP_MAIN_INF ON USR_INF.USR_LOGIN_ID = EMP_MAIN_INF.EMP_ID WHERE ARR_WITH=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Dept_byArr:
                command = new SqlCommand("SELECT DISTINCT INS_DEPT_INF.DEPT_VALUE, INS_DEPT_INF.DEPT_ID FROM  EMP_DEPT_CNG_INF INNER JOIN EMP_LV_ARR_INF INNER JOIN EMP_LV_APP_INF ON EMP_LV_ARR_INF.LV_APP_ID = EMP_LV_APP_INF.LV_APP_ID ON EMP_DEPT_CNG_INF.TO_DATE IS NULL INNER JOIN INS_DEPT_INF ON EMP_DEPT_CNG_INF.DEPT_ID = INS_DEPT_INF.DEPT_ID INNER JOIN USR_INF ON EMP_LV_APP_INF.USR_ID = USR_INF.USR_ID AND EMP_DEPT_CNG_INF.EMP_ID = USR_INF.USR_LOGIN_ID WHERE ARR_WITH=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Vendor:
                command = new SqlCommand("Select ORG_NAME,VENDOR_ID from INV_VENDOR_INF WHERE STO_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Document:
                command = new SqlCommand("SELECT DOC_TYPE_INF.DOC_NAME, EMP_DOCUMENT_DETAIL.DOC_DTL_ID FROM EMP_DOC_DETAIL_INF EMP_DOCUMENT_DETAIL INNER JOIN DOC_TYPE_INF DOC_TYPE_INF ON EMP_DOCUMENT_DETAIL.DOC_ID = DOC_TYPE_INF.DOC_ID WHERE DOC_DTL_ID NOT IN(SELECT DOC_DTL_ID FROM EMP_DOC_UPLD_INF) AND EMP_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.ProgramByIns:
                command = new SqlCommand("SELECT PGM_SHORT_NAME,INS_PGM_ID  FROM INS_PGM_INF WHERE INS_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.ProgramByType:
                command = new SqlCommand("SELECT PGM_SHORT_NAME,INS_PGM_ID FROM INS_PGM_INF WHERE PGM_TYPE_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.PurOrderRpt:
                command = new SqlCommand("SELECT PO_NO, PO_ID FROM INV_PUR_ORDER_MASTER WHERE PO_NO LIKE 'PO/'+@PARAMETER+'%' ORDER BY PO_ID DESC");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.NextSenior_ByDepartment:
                command = new SqlCommand("SELECT  DISTINCT   EMP_MAIN_INF.EMP_NAME, EMP_NXT_SNR_CNG_INF.EMP_NEXT_SNR_ID FROM  EMP_NXT_SNR_CNG_INF INNER JOIN " +
                    " EMP_MAIN_INF ON EMP_NXT_SNR_CNG_INF.EMP_NEXT_SNR_ID = EMP_MAIN_INF.EMP_ID WHERE EMP_NXT_SNR_CNG_INF.TO_DATE IS NULL AND (EMP_NXT_SNR_CNG_INF.EMP_ID IN (SELECT EMP_ID FROM EMP_DEPT_CNG_INF WHERE (DEPT_ID = @PARAMETER) )) ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.ProgramByDegree:
                command = new SqlCommand("SELECT PGM_FULL_NAME,INS_PGM_ID FROM INS_PGM_INF WHERE DGR_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Branch:
                command = new SqlCommand("SELECT BRN_SHORT_NAME,PGM_BRN_ID FROM INS_PGM_BRN_INF WHERE PGM_BRN_STS=1 AND INS_PGM_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.DepartmentByType:
                command = new SqlCommand("SELECT DEPT_VALUE, DEPT_ID FROM INS_DEPT_INF WHERE DEPT_STS=1 AND DEPT_TYPE_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.DocFor:
                command = new SqlCommand("SELECT DOC_FOR_VALUE,DOC_FOR_ID FROM DOC_FOR_INF WHERE DOC_FOR_TYPE=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.DesigByCategory:
                command = new SqlCommand("SELECT DES_VALUE, DES_ID FROM DES_INF WHERE DES_STS = 1 AND CAT_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Emp_Ins:
                command = new SqlCommand("SELECT USR_ROLE_TRAN.INS_DEPT_ID FROM USR_INF INNER JOIN" +
                         " USR_ROLE_INF ON USR_INF.USR_ID = USR_ROLE_INF.USR_ID INNER JOIN" +
                         " USR_ROLE_TRAN ON USR_ROLE_INF.USR_ROLE_ID = USR_ROLE_TRAN.USR_ROLE_ID" +
                         " WHERE (USR_ROLE_TRAN.REF_TYPE = 0) AND (USR_INF.USR_ID = @PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Emp_Dept:
                command = new SqlCommand("SELECT USR_ROLE_TRAN.INS_DEPT_ID FROM USR_INF INNER JOIN" +
                         " USR_ROLE_INF ON USR_INF.USR_ID = USR_ROLE_INF.USR_ID INNER JOIN" +
                         " USR_ROLE_TRAN ON USR_ROLE_INF.USR_ROLE_ID = USR_ROLE_TRAN.USR_ROLE_ID" +
                         " WHERE (USR_ROLE_TRAN.REF_TYPE = 1) AND (USR_INF.USR_ID = @PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.pgm_dept:
                command = new SqlCommand("SELECT INS_PGM_INF.PGM_SHORT_NAME,INS_PGM_INF.INS_PGM_ID" +
                                          " FROM USR_INF INNER JOIN" +
                         " USR_ROLE_INF ON USR_INF.USR_ID = USR_ROLE_INF.USR_ID INNER JOIN" +
                         " USR_ROLE_TRAN ON USR_ROLE_INF.USR_ROLE_ID = USR_ROLE_TRAN.USR_ROLE_ID INNER JOIN" +
                         " PGM_BRN_DEPT_INF ON PGM_BRN_DEPT_INF.DEPT_ID = USR_ROLE_TRAN.INS_DEPT_ID INNER JOIN" +
                         " INS_PGM_BRN_INF ON PGM_BRN_DEPT_INF.PGM_BRN_ID = INS_PGM_BRN_INF.PGM_BRN_ID INNER JOIN" +
                         " INS_PGM_INF ON INS_PGM_BRN_INF.INS_PGM_ID = INS_PGM_INF.INS_PGM_ID" +
                          " WHERE (USR_ROLE_TRAN.REF_TYPE = 1) AND (USR_INF.USR_ID = @PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Doc_Issue:
                command = new SqlCommand("select doc_name,doc_id from dept_doc_main INNER JOIN EMP_VIEW ON EMP_VIEW.DEPT_ID=dept_doc_main.DEPT_ID where EMP_ID= @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("PARAMETER", parameter);
                break;
            case QueryBaseType.stu_main_id:
                command = new SqlCommand("SELECT STU_MAIN_ID FROM STU_MAIN_INF WHERE ENROLLMENT_NO = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Transfer:
                command = new SqlCommand("SELECT ROLE_VALUE,ROLE_ID FROM  ROLE_INF WHERE (ROLE_ID in (1,2,4,5,71,64)) AND (ROLE_STS = 1) AND (ROLE_ID>@PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.StuDocument:
                command = new SqlCommand("SELECT STU_DOC_TYPE_INF.DOC_VALUE, STU_DOC_TYPE_INF.DOC_ID "
                                          + " FROM STU_DOC_TYPE_INF INNER JOIN PGM_DOC_MAP_INF ON STU_DOC_TYPE_INF.DOC_ID = PGM_DOC_MAP_INF.DOC_ID "
                                          + " WHERE (STU_DOC_TYPE_INF.DOC_STS = 1) AND (PGM_DOC_MAP_INF.INS_PGM_ID IN(0,@PARAMETER))");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.BusNO:
                command = new SqlCommand("SELECT TPT_BUS_RTE_MAPP.BUS_ID FROM TPT_BUS_RTE_MAPP INNER JOIN TPT_BUS_INF ON TPT_BUS_RTE_MAPP.BUS_ID = TPT_BUS_INF.BUS_ID WHERE TPT_BUS_RTE_MAPP.CITY_ID = @PARAMETER AND BUS_TYPE_ID = 4 ORDER BY TPT_BUS_RTE_MAPP.BUS_ID");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            # region inventory
            case QueryBaseType.SubCategory:
                command = new SqlCommand("Select SUB_CAT_Name,SUB_CAT_Id from INV_SUB_CAT_MASTER WHERE CAT_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Item:
                command = new SqlCommand("Select ITEM_NAME,ITEM_Id from INV_ITEM_MASTER WHERE ITEM_SUB_CAT_ID=@PARAMETER ORDER BY ITEM_NAME");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.UNIT:
                command = new SqlCommand("SELECT INV_ITEM_UNIT_INFO.UNIT_NAME, INV_ITEM_UNIT_INFO.UNIT_ID FROM INV_ITEM_MASTER INNER JOIN INV_ITEM_UNIT_INFO ON INV_ITEM_MASTER.UNIT_ID= INV_ITEM_UNIT_INFO.UNIT_ID WHERE(INV_ITEM_MASTER.ITEM_ID =@PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.STATUS:
                command = new SqlCommand("SELECT PUR_REQ_STS FROM INV_PUR_REQ_MASTER WHERE (PUR_REQ_NO =@PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.FanAmount:
                command = new SqlCommand("SELECT ISNULL(SUM(FAN_AMOUNT),0) FROM INV_PUR_FAN_MASTER WHERE(FAN_PUR_ID =@PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Store_Item:
                command = new SqlCommand("SELECT ITEM_NAME,ITEM_ID FROM INV_ITEM_MASTER WHERE (STO_ID = @PARAMETER ) ORDER BY ITEM_NAME");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.StoreItemForIndent:
                command = new SqlCommand("SELECT ITEM_NAME,ITEM_ID FROM INV_ITEM_MASTER WHERE (STO_ID = @PARAMETER ) AND ITEM_SUB_CAT_ID!=23 ORDER BY ITEM_NAME");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.POModify:
                command = new SqlCommand("SELECT PO_NO, PO_ID FROM  INV_PUR_ORDER_MASTER" +
                                         " WHERE (PO_ID  NOT IN (SELECT PO_ID FROM  INV_STO_GRN_INF)) AND (PO_STORE_ID =@PARAMETER ) ORDER BY PO_ID  ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.RFQ_Vendor:
                command = new SqlCommand("SELECT INV_VENDOR_INF.ORG_NAME, INV_VENDOR_INF.VENDOR_ID FROM INV_VENDOR_INF INNER JOIN" +
                      " INV_PUR_RFQ_DETAIL ON INV_VENDOR_INF.VENDOR_ID = INV_PUR_RFQ_DETAIL.RFQ_VENDOR_ID" +
                      " WHERE (INV_VENDOR_INF.VENDOR_STS = 1) AND (INV_PUR_RFQ_DETAIL.PUR_RFQ_ID =@PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.FanNo:
                command = new SqlCommand("SELECT FAN_NO, FAN_ID FROM INV_PUR_FAN_MASTER WHERE(FAN_STATUS = 0) AND (FAN_PUR_ID = @PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.RFQPurReqNo:
                command = new SqlCommand("SELECT PUR_REQ_NO, PUR_REQ_ID FROM INV_PUR_REQ_MASTER WHERE(PUR_REQ_STS = 5) AND (PUR_STORE_ID = @PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            #endregion
            #region store

            case QueryBaseType.DirIndStore_Item:
                command = new SqlCommand("SELECT ITEM_NAME+' ('+ CONVERT(VARCHAR,QTY) + ')' AS ITEM_NAME, ITEM_ID, QTY FROM INV_ITEM_MASTER WHERE(STO_ID = @PARAMETER ) ORDER BY  ITEM_NAME");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Sto_Indent:
                command = new SqlCommand("SELECT DISTINCT INV_STO_IND_INF.IND_CAL_ID, INV_STO_SIV_INF.IND_ID, INV_STO_IND_INF.STO_ID " +
                        "FROM INV_STO_SIV_INF INNER JOIN INV_STO_IND_INF ON INV_STO_SIV_INF.IND_ID = INV_STO_IND_INF.IND_ID " +
                        "WHERE(INV_STO_IND_INF.STO_ID = @PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Item_Store:

                command = new SqlCommand("SELECT INV_STORE_MASTER.STO_NAME, INV_STORE_MASTER.STO_ID " +
                          "FROM INV_STORE_MASTER INNER JOIN INV_STO_EMP_MAPP_INF ON INV_STORE_MASTER.STO_ID = INV_STO_EMP_MAPP_INF.STO_ID " +
                          "WHERE(INV_STORE_MASTER.STO_STS = 1) AND (INV_STO_EMP_MAPP_INF.USR_ID = @PARAMETER) AND GETDATE() BETWEEN INV_STO_EMP_MAPP_INF.FRM_DATE AND ISNULL(INV_STO_EMP_MAPP_INF.TO_DATE,GETDATE())");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Sto_Cat:
                command = new SqlCommand("SELECT DISTINCT  INV_CAT_MASTER.CAT_NAME, INV_CAT_MASTER.CAT_ID" +
                                        " FROM INV_STORE_MASTER INNER JOIN INV_ITEM_MASTER ON INV_STORE_MASTER.STO_ID = INV_ITEM_MASTER.STO_ID INNER JOIN" +
                      " INV_SUB_CAT_MASTER ON INV_ITEM_MASTER.ITEM_SUB_CAT_ID = INV_SUB_CAT_MASTER.SUB_CAT_ID INNER JOIN" +
                      " INV_CAT_MASTER ON INV_SUB_CAT_MASTER.CAT_ID = INV_CAT_MASTER.CAT_ID " +
                        " WHERE     (INV_STORE_MASTER.STO_ID= @PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.Sto_Name:
                command = new SqlCommand("SELECT STO_NAME FROM INV_STORE_MASTER WHERE(STO_ID = @PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Usr_id:
                command = new SqlCommand("SELECT USR_ID FROM USR_INF WHERE(USR_LOGIN_ID= @PARAMETER )");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.PurOrder:
                command = new SqlCommand("SELECT DISTINCT INV_PUR_ORDER_MASTER.PO_NO, INV_PUR_ORDER_MASTER.PO_ID, INV_STO_EMP_MAPP_INF.USR_ID" +
                      " FROM INV_PUR_ORDER_MASTER INNER JOIN INV_PUR_ORDER_DETAIL ON INV_PUR_ORDER_MASTER.PO_ID = INV_PUR_ORDER_DETAIL.PO_ID INNER JOIN" +
                      " INV_STO_EMP_MAPP_INF ON INV_PUR_ORDER_MASTER.PO_STORE_ID = INV_STO_EMP_MAPP_INF.STO_ID INNER JOIN" +
                      " INV_ITEM_MASTER ON INV_PUR_ORDER_DETAIL.ITEM_CODE = INV_ITEM_MASTER.ITEM_ID LEFT OUTER JOIN" +
                      " INV_STO_GRN_INF ON INV_PUR_ORDER_MASTER.PO_ID = INV_STO_GRN_INF.PO_ID LEFT OUTER JOIN" +
                      " INV_STO_GRN_ITEM_INF ON INV_STO_GRN_INF.GRN_ID = INV_STO_GRN_ITEM_INF.GRN_ID" +
                      " GROUP BY INV_PUR_ORDER_DETAIL.ITEM_CODE, INV_PUR_ORDER_DETAIL.QTY, INV_PUR_ORDER_MASTER.PO_ID, INV_ITEM_MASTER.ITEM_NAME," +
                      " INV_PUR_ORDER_DETAIL.RATE, INV_PUR_ORDER_MASTER.PO_NO, INV_PUR_ORDER_MASTER.PO_STATUS, INV_STO_EMP_MAPP_INF.USR_ID" +
                      " HAVING (INV_PUR_ORDER_DETAIL.QTY >= ISNULL(SUM(INV_STO_GRN_ITEM_INF.QTY), 0)) AND (INV_PUR_ORDER_MASTER.PO_STATUS = 2) AND" +
                      " (INV_STO_EMP_MAPP_INF.USR_ID = @PARAMETER) ORDER BY INV_PUR_ORDER_MASTER.PO_ID");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            #endregion
            #region Facility
            case QueryBaseType.Route_Name:
                command = new SqlCommand("SELECT RTE_NAME,RTE_ID,CITY_ID FROM TPT_RTE_INF WHERE CITY_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Bus_Type:
                command = new SqlCommand("SELECT TPT_BUS_TYPE_INF.BUS_TYPE_VALUE,TPT_BUS_INF.BUS_TYPE_ID FROM TPT_BUS_TYPE_INF JOIN TPT_BUS_INF ON TPT_BUS_TYPE_INF.BUS_TYPE_ID = TPT_BUS_INF.BUS_TYPE_ID WHERE CITY_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Bus_No:
                command = new SqlCommand("SELECT BUS_REG_NO,BUS_ID FROM TPT_BUS_INF WHERE BUS_TYPE_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.RoomCategoryTypeByHstl:
                command = new SqlCommand("SELECT  distinct FAC_ROOM_CAT_INF.FAC_ROOM_CATEGORY_NAME, FAC_ROOM_CAT_INF.FAC_ROOM_CATEGORY_ID "
                     + "FROM  FAC_COMPLEX_INF INNER JOIN FAC_ROOM_INF ON FAC_COMPLEX_INF.FAC_CMPLX_ID = FAC_ROOM_INF.CMPLX_ID INNER JOIN "
                       + " FAC_ROOM_CAT_INF ON FAC_ROOM_INF.ROOM_CATEGORY_ID = FAC_ROOM_CAT_INF.FAC_ROOM_CATEGORY_ID "
                 + "WHERE (FAC_COMPLEX_INF.FAC_CMPLX_ID =@PARAMETER) AND (FAC_ROOM_CAT_INF.FAC_ROOM_CATEGORY_STS = 1)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.Bus_Id:
                command = new SqlCommand("SELECT BUS_ID FROM TPT_BUS_RTE_MAPP WHERE RTE_ID = @PARAMETER ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.HstlFloor:
                command = new SqlCommand("SELECT DISTINCT ROOM_FLOOR FROM FAC_ROOM_INF WHERE CMPLX_ID= @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.HstlRoom:
                command = new SqlCommand("SELECT DISTINCT ROOM_NO, FAC_ROOM_INF.ROOM_ID FROM FAC_ROOM_INF JOIN FAC_HOST_ROOM_BED_INF ON FAC_ROOM_INF.ROOM_ID = FAC_HOST_ROOM_BED_INF.ROOM_ID WHERE CMPLX_ID=@PARAMETER AND ROOM_BED_ENGAGE = '0' ORDER BY ROOM_NO ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.EmpResFloor:
                command = new SqlCommand("SELECT DISTINCT ROOM_FLOOR FROM FAC_ROOM_INF WHERE CMPLX_ID= @PARAMETER AND ROOM_TYP_ID = 11");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.EmpResName:
                command = new SqlCommand("SELECT EMP_NAME,ALLOTED_TO FROM FAC_HSTL_ROOM_ALLOTMENT JOIN FAC_HSTL_OCCUPIED_DETAIL ON FAC_HSTL_ROOM_ALLOTMENT.OCCUPIED_ID = FAC_HSTL_OCCUPIED_DETAIL.HSTL_OCCUPIED_ID JOIN EMP_VIEW ON FAC_HSTL_ROOM_ALLOTMENT.ALLOTED_TO = EMP_VIEW.USR_ID JOIN FAC_HOST_ROOM_BED_INF ON FAC_HSTL_ROOM_ALLOTMENT.BED_ID = FAC_HOST_ROOM_BED_INF.ROOM_BED_AUTO_ID WHERE LEAVING_DATE IS NULL AND ROOM_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.HostelComplex:
                command = new SqlCommand("SELECT FAC_CMPLX_NAME, FAC_CMPLX_ID FROM FAC_COMPLEX_INF WHERE FAC_CMPLX_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.RoomType:
                command = new SqlCommand("SELECT DISTINCT CONVERT(varchar, MAXIMUM_PRSN) + ' seater',MAXIMUM_PRSN FROM FAC_ROOM_INF WHERE CMPLX_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.EmpIssueAbut:
                command = new SqlCommand("SELECT SUB_HEAD_VALUE, SUB_HEAD_ID FROM ISSUE_SUB_HEAD_INF WHERE (HEAD_ID = @PARAMETER) AND (SUB_STS = 1)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.EmpIssueDept:
                command = new SqlCommand("SELECT INS_DEPT_INF.DEPT_VALUE, ISSUE_DEPT_MAPP_INF.DEPT_ID FROM ISSUE_DEPT_MAPP_INF INNER JOIN "
                                          + " INS_DEPT_INF ON ISSUE_DEPT_MAPP_INF.DEPT_ID = INS_DEPT_INF.DEPT_ID"
                                           + " WHERE  (ISSUE_DEPT_MAPP_INF.ISSUE_SUB_HEAD_ID = @PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.IssueSubHead:
                command = new SqlCommand("SELECT DISTINCT ISSUE_SUB_HEAD_INF.SUB_HEAD_VALUE, ISSUE_DEPT_MAPP_INF.ISSUE_SUB_HEAD_ID "
                                           + " FROM ISSUE_USR_MAPP_INF INNER JOIN EMP_ISSUE_MASTER INNER JOIN "
                                            + " ISSUE_HEAD_INF INNER JOIN ISSUE_SUB_HEAD_INF ON ISSUE_HEAD_INF.HEAD_ID = ISSUE_SUB_HEAD_INF.HEAD_ID INNER JOIN "
                                            + " ISSUE_DEPT_MAPP_INF ON ISSUE_SUB_HEAD_INF.SUB_HEAD_ID = ISSUE_DEPT_MAPP_INF.ISSUE_SUB_HEAD_ID ON "
                                            + " EMP_ISSUE_MASTER.ISUUE_DEPT_MAPP_ID = ISSUE_DEPT_MAPP_INF.ISSUE_DEPT_ID ON ISSUE_USR_MAPP_INF.DEPT_ID = ISSUE_DEPT_MAPP_INF.DEPT_ID INNER JOIN "
                                            + " USR_ROLE_INF ON ISSUE_USR_MAPP_INF.USR_ID = USR_ROLE_INF.USR_ID "
                                           + " WHERE (ISSUE_USR_MAPP_INF.USR_ID = @PARAMETER) AND (USR_ROLE_INF.ROLE_ID = 31) AND (EMP_ISSUE_MASTER.ISSUE_STS = 2) order by SUB_HEAD_VALUE");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            #endregion
            #region Priya
            //case QueryBaseType.RoomNo:
            //    command = new SqlCommand("SELECT DISTINCT FAC_ROOM_INF.ROOM_NO, FAC_ROOM_INF.ROOM_ID FROM FAC_ROOM_INF INNER JOIN" +
            //                             " FAC_HOST_ROOM_BED_INF ON FAC_ROOM_INF.ROOM_ID = FAC_HOST_ROOM_BED_INF.ROOM_ID" +
            //                             " WHERE (FAC_ROOM_INF.ROOM_STS = 1) AND (FAC_HOST_ROOM_BED_INF.ROOM_BED_ENGAGE = 0) AND CMPLX_ID= @PARAMETER");
            //    command.Parameters.AddWithValue("@PARAMETER", parameter);
            //    command.CommandType = CommandType.Text;
            //    break;

            case QueryBaseType.RoomNo:
                command = new SqlCommand("SELECT ROOM_NO, ROOM_ID FROM FAC_ROOM_INF WHERE ROOM_STS = 1 AND CMPLX_ID= @PARAMETER");
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                command.CommandType = CommandType.Text;
                break;
            case QueryBaseType.CourseName:
                command = new SqlCommand("SELECT PGM_SHORT_NAME,INS_PGM_ID  FROM INS_PGM_INF  WHERE PGM_STS=1 AND INS_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            #endregion
            #region Interview
            case QueryBaseType.IntStatus:
                command = new SqlCommand("SELECT INT_STS_VALUE, INT_STS_ID FROM INT_STS_INF WHERE  (INT_STS_ID > @PARAMETER) AND (INT_STS_ID <9)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);

                break;
            case QueryBaseType.IntTime:
                command = new SqlCommand("SELECT CONVERT(VARCHAR(5),INT_MAIN_INF.INT_DATE,108),INT_MAIN_ID FROM INT_MAIN_INF WHERE (CONVERT(VARCHAR,INT_DATE,103)=@PARAMETER) ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.DeptJob:
                command = new SqlCommand("SELECT JOB_NO, JOB_ID FROM INT_JOB_MAIN_INF WHERE (DEPT_ID = @PARAMETER) ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.JobIntDate:
                command = new SqlCommand("SELECT CONVERT(VARCHAR,INT_DATE,103),INT_MAIN_ID FROM INT_MAIN_INF WHERE (INT_JOB_ID=@PARAMETER) ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            #endregion
            case QueryBaseType.Notice_Type:
                command = new SqlCommand("SELECT NOTICE_TYPE_VALUE, NOTICE_TYPE_ID FROM NOTICE_TYPE_MASTER WHERE (NOTICE_STS = 1) AND (NOTICE_FOR_ID = @PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
                # region Harshita_AcademicRpt
            case QueryBaseType.UsrIns:
                command = new SqlCommand("SELECT UNIV_INS_INF.INS_VALUE, UNIV_INS_INF.INS_ID FROM INS_DEPT_INF INNER JOIN "+
                                         " UNIV_INS_INF ON INS_DEPT_INF.INS_ID = UNIV_INS_INF.INS_ID INNER JOIN "+
                                         " USR_ROLE_INF INNER JOIN  USR_ROLE_TRAN ON USR_ROLE_INF.USR_ROLE_ID = USR_ROLE_TRAN.USR_ROLE_ID "+
                                         " ON INS_DEPT_INF.DEPT_ID = USR_ROLE_TRAN.INS_DEPT_ID WHERE     (USR_ROLE_INF.ROLE_ID = 2) "+
                                         " AND (USR_ROLE_TRAN.REF_TYPE = 1) AND (USR_ROLE_TRAN.TO_DT IS NULL) AND (USR_ROLE_INF.TO_DT IS NULL) "+
                                         " AND (USR_ROLE_INF.USR_ID = @PARAMETER)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.UsrDept:
                command = new SqlCommand("SELECT  INS_DEPT_INF.DEPT_VALUE, INS_DEPT_INF.DEPT_ID FROM INS_DEPT_INF INNER JOIN " +
                                       " USR_ROLE_INF INNER JOIN USR_ROLE_TRAN ON USR_ROLE_INF.USR_ROLE_ID = USR_ROLE_TRAN.USR_ROLE_ID " +
                                       " ON INS_DEPT_INF.DEPT_ID = USR_ROLE_TRAN.INS_DEPT_ID WHERE (USR_ROLE_INF.ROLE_ID = 2) " +
                                       " AND (USR_ROLE_TRAN.REF_TYPE = 1) AND (USR_ROLE_TRAN.TO_DT IS NULL) AND (USR_ROLE_INF.TO_DT IS NULL) AND " +
                                       " (USR_ROLE_INF.USR_ID = @PARAMETER)");
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.DeptPgm:
                command = new SqlCommand("SELECT INS_PGM_INF.PGM_SHORT_NAME, INS_PGM_INF.INS_PGM_ID FROM PGM_DEPT_INF INNER JOIN " +
                                       " INS_PGM_INF ON PGM_DEPT_INF.PGM_ID = INS_PGM_INF.INS_PGM_ID WHERE (PGM_DEPT_INF.DEPT_ID = @PARAMETER)");
                 command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            #endregion

            #region Mudit
            case QueryBaseType.SemByBranch:
                command = new SqlCommand("SELECT distinct  ACA_SEM_INF.ACA_SEM_NO, STU_BRN_SEM_INF.ACA_SEM_ID FROM  STU_BRN_SEM_INF INNER JOIN ACA_SEM_INF ON STU_BRN_SEM_INF.ACA_SEM_ID = ACA_SEM_INF.ACA_SEM_ID where  STU_BRN_SEM_INF.PGM_BRN_ID=@PARAMETER ORDER BY ACA_SEM_ID");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;

            case QueryBaseType.BusNoCity:
                command = new SqlCommand("SELECT BUS_REG_NO, BUS_ID from TPT_BUS_INF where BUS_TYPE_ID=4 AND CITY_ID=@PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            #endregion
            case QueryBaseType.GatePass:
                command = new SqlCommand("SELECT PASS_NUMBER, PASS_ID FROM INV_GATE_PASS_INF WHERE PASS_NUMBER like @PARAMETER+'%' ORDER BY PASS_ID DESC ");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            case QueryBaseType.SalaryHead:
                command = new SqlCommand("SELECT HEAD_NAME,SAL_HEAD_MASTER.HEAD_ID FROM SAL_HEAD_MASTER INNER JOIN"
                    + "  SAL_TEMP_HEAD_MAPP ON SAL_HEAD_MASTER.HEAD_ID=SAL_TEMP_HEAD_MAPP.HEAD_ID WHERE HEAD_STATUS=1 AND HEAD_TEMP_ID = @PARAMETER");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER", parameter);
                break;
            default:
                break;


        }
        return command;
    }
    public SqlCommand GetCommand(QueryBaseType type, string parameter1, string parameter2)
    {
        SqlCommand command = null;
        switch (type)
        {
            case QueryBaseType.ProgramByDegree:
                command = new SqlCommand("SELECT PGM_FULL_NAME,INS_PGM_ID FROM INS_PGM_INF WHERE DGR_ID=@PARAMETER1 AND INS_ID=@PARAMETER2");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
                 #region student finance
            case QueryBaseType.FeeStructure:
                command = new SqlCommand("SELECT FEE_STRC_MAIN_ID FROM STU_FIN_FEE_STRC_MAIN_INF WHERE FEE_STRC_STATUS =1 AND FEE_COURSE_ID= @PARAMETER1 AND FEE_BATCH_ID=@PARAMETER2");
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.CommandType = CommandType.Text;
                break;
            #endregion
            #region Facility
            case QueryBaseType.RoomNO:
                command = new SqlCommand("SELECT ROOM_NO,ROOM_ID FROM FAC_ROOM_INF WHERE CMPLX_ID= @PARAMETER1 AND ROOM_FLOOR = @PARAMETER2");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            case QueryBaseType.EmpResRoom:
                command = new SqlCommand("SELECT DISTINCT ROOM_NO, FAC_ROOM_INF.ROOM_ID FROM FAC_ROOM_INF JOIN FAC_HOST_ROOM_BED_INF ON FAC_ROOM_INF.ROOM_ID = FAC_HOST_ROOM_BED_INF.ROOM_ID WHERE  ROOM_FLOOR=@PARAMETER1 AND CMPLX_ID = @PARAMETER2 AND ROOM_BED_ENGAGE = '0' AND ROOM_TYP_ID = 11");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            case QueryBaseType.RoomByType:
                command = new SqlCommand("SELECT DISTINCT ROOM_NO, ROOM_ID FROM FAC_ROOM_INF WHERE (MAXIMUM_PRSN = @PARAMETER1) AND (CMPLX_ID = @PARAMETER2)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            #endregion
            case QueryBaseType.PaperCode:
                command = new SqlCommand("SELECT DISTINCT ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE, TT_CLS_PAP_INF.TT_PAP_ID FROM STU_INT_EXAM_MARKS_INF INNER JOIN "
                                         + " TT_CLS_PAP_INF ON STU_INT_EXAM_MARKS_INF.TT_PAP_ID = TT_CLS_PAP_INF.TT_PAP_ID INNER JOIN "
                                         + " ACA_EVA_SCH_SUBJECT_INF ON TT_CLS_PAP_INF.EVA_SCH_SUB_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_ID "
                                         + " INNER JOIN TT_DET_INF INNER JOIN TT_ASN_INF ON TT_DET_INF.TT_DET_ID = TT_ASN_INF.TT_DET_ID ON TT_CLS_PAP_INF.TT_ID = TT_DET_INF.TT_ID"
                                         + " INNER JOIN ACA_BATCH_SEM_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = ACA_BATCH_SEM_INF.ACA_SEM_ID"
                                         + " WHERE ACA_BAT_SEM_STS in (1,8) AND STU_INT_EXAM_MARKS_INF.INT_ATT_STS=0 AND (STU_INT_EXAM_MARKS_INF.STU_MAIN_ID = @PARAMETER1) AND (TT_ASN_INF.EMP_ID = @PARAMETER2)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            case QueryBaseType.RoomByFlrCmplx:
                command = new SqlCommand("SELECT DISTINCT ROOM_NO, ROOM_ID FROM FAC_ROOM_INF WHERE (ROOM_FLOOR = @PARAMETER1) and (CMPLX_ID = @PARAMETER2)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            case QueryBaseType.CourseByBrnchSem:
                command = new SqlCommand("SELECT '('+ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE+')'+ACA_SUBJECT_INF.ACA_SUB_NAME,ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE " +
                                        " FROM         ACA_EVALUATION_SCHEME_INF INNER JOIN "+
                                        " ACA_EVA_SCH_SUBJECT_INF ON ACA_EVALUATION_SCHEME_INF.EVA_SCH_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID INNER JOIN "+
                                        " ACA_SUBJECT_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SUB_ID = ACA_SUBJECT_INF.ACA_SUB_ID INNER JOIN "+
                                        " ACA_BATCH_SEM_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = ACA_BATCH_SEM_INF.ACA_SEM_ID AND ACA_EVALUATION_SCHEME_INF.ACA_BATCH_ID=ACA_BATCH_SEM_INF.ACA_BATCH_ID " +
                                        " WHERE(ACA_EVA_SCH_SUBJECT_INF.SUB_TYPE_ID = 0) AND (ACA_BATCH_SEM_INF.ACA_BAT_SEM_STS in (1)) AND (ACA_EVALUATION_SCHEME_INF.PGM_BRN_ID = @PARAMETER1) AND (ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = @PARAMETER2)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);

                break;
        
            case QueryBaseType.AwardId:
                command = new SqlCommand("SELECT distinct STU_MAJOR_MAIN_INF.MEM_ID FROM STU_MAJOR_MAIN_INF INNER JOIN " +
                        " STU_MAJOR_SUB_INF ON STU_MAJOR_MAIN_INF.MEM_ID = STU_MAJOR_SUB_INF.MEM_ID INNER JOIN " +
                      " ACA_EVA_SCH_SUBJECT_INF ON STU_MAJOR_SUB_INF.EVA_SCH_SUB_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_ID " +
                    "WHERE (ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE =@PARAMETER1) AND (STU_MAJOR_MAIN_INF.EXAM_MAIN_ID = @PARAMETER2)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            #region Examination
            case QueryBaseType.FacultyCourse:
                command = new SqlCommand("SELECT CRS_CODE,MAIN_ID FROM MINOR_ONLINE_MAIN_INF WHERE MINOR_SCH_ID=@PARAMETER1 AND IN_BY=@PARAMETER2");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;
            #endregion
            default:
                break;

            #region Interview
            case QueryBaseType.IntNo:
                command = new SqlCommand("SELECT CONVERT(VARCHAR,INT_MAIN_INF.INT_DATE,103) +' '+ CONVERT(VARCHAR(5),INT_MAIN_INF.INT_DATE,108)+' ('+ convert(varchar,count(INT_SUB_INF.INT_CAN_ID)) +')',INT_MAIN_INF.INT_MAIN_ID " +
                                       " FROM INT_MAIN_INF INNER JOIN  INT_SUB_INF ON INT_MAIN_INF.INT_MAIN_ID = INT_SUB_INF.INT_MAIN_ID " +
                                       " WHERE (INT_MAIN_INF.INT_JOB_ID = @PARAMETER1) AND (INT_MAIN_INF.INT_ROUND =@PARAMETER2) AND (INT_MAIN_INF.STS = 1) AND (INT_SUB_INF.STS = 1) group by INT_MAIN_INF.INT_MAIN_ID, INT_MAIN_INF.INT_DATE");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;

            #endregion

            #region Mudit
            case QueryBaseType.DetainedPaperCode:
                command = new SqlCommand("SELECT  DISTINCT  '(' + Examination.dbo.EXAM_CRS_MAIN_INF.CRS_CODE + ')' + Examination.dbo.EXAM_CRS_MAIN_INF.CRS_NAME AS CSR_NAME ,Examination.dbo.EXAM_CRS_MAIN_INF.CRS_CODE  FROM  Examination.dbo.EXAM_CRS_MAIN_INF INNER JOIN " +
                      " Examination.dbo.PGM_BRN_BATCH_MAPP_INF ON Examination.dbo.EXAM_CRS_MAIN_INF.PGM_MAPP_ID = Examination.dbo.PGM_BRN_BATCH_MAPP_INF.PGM_MAPP_ID INNER JOIN " +
                        " Examination.dbo.EXAM_BACK_REG_SUB_INF ON Examination.dbo.EXAM_CRS_MAIN_INF.CRS_EXAM_ID = Examination.dbo.EXAM_BACK_REG_SUB_INF.CRS_PAPER_ID INNER JOIN " +
                        " Examination.dbo.EXAM_BACK_REG_MAIN_INF ON Examination.dbo.EXAM_BACK_REG_SUB_INF.BACK_MAIN_ID = Examination.dbo.EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID INNER JOIN " +
                        " ERP.dbo.INS_PGM_BRN_INF ON Examination.dbo.PGM_BRN_BATCH_MAPP_INF.PGM_BRN_ID= ERP.dbo.INS_PGM_BRN_INF.PGM_BRN_ID WHERE (EXAM_BACK_REG_SUB_INF.EXAM_TYPE in (2,3)) " +
            " AND (EXAM_BACK_REG_SUB_INF.BACK_PAPER_STS = 2) AND EXAM_BACK_REG_MAIN_INF.EXAM_ID=46 AND PGM_BRN_BATCH_MAPP_INF.PGM_BRN_ID=@PARAMETER1 AND Examination.dbo.EXAM_CRS_MAIN_INF.ACA_SEM_ID=@PARAMETER2");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                break;


            #endregion

        }
        return command;
    }
    public SqlCommand GetCommand(QueryBaseType type, string parameter1, string parameter2, string parameter3)
    {
        SqlCommand command = null;
        switch (type)
        {
            #region Facility
            case QueryBaseType.RoomByFlrType:
                command = new SqlCommand("SELECT DISTINCT ROOM_NO, ROOM_ID FROM FAC_ROOM_INF WHERE (MAXIMUM_PRSN = @PARAMETER1) AND (ROOM_FLOOR = @PARAMETER2) and (CMPLX_ID = @PARAMETER3)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);
                break;
            case QueryBaseType.RoombyFloorAndCategory:
                command = new SqlCommand("SELECT ROOM_NO,ROOM_ID FROM FAC_ROOM_INF INNER JOIN FAC_ROOM_CAT_INF ON FAC_ROOM_INF.ROOM_CATEGORY_ID = FAC_ROOM_CAT_INF.FAC_ROOM_CATEGORY_ID  WHERE (ROOM_CATEGORY_ID= @PARAMETER1) AND (ROOM_FLOOR = @PARAMETER2) AND (CMPLX_ID = @PARAMETER3)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);
                break;
            case QueryBaseType.PaperByBrnchSem:
                command = new SqlCommand("SELECT DISTINCT '('+ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE+')'+ACA_SUBJECT_INF.ACA_SUB_NAME,ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_ID " +
                                        " FROM ACA_EVALUATION_SCHEME_INF INNER JOIN " +
                                        " ACA_EVA_SCH_SUBJECT_INF ON ACA_EVALUATION_SCHEME_INF.EVA_SCH_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID INNER JOIN " +
                                       " ACA_SUBJECT_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SUB_ID = ACA_SUBJECT_INF.ACA_SUB_ID  INNER JOIN "+
                                       " ACA_BATCH_SEM_INF ON ACA_EVALUATION_SCHEME_INF.ACA_BATCH_ID = ACA_BATCH_SEM_INF.ACA_BATCH_ID AND "+
                                       " ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = ACA_BATCH_SEM_INF.ACA_SEM_ID" +
                                       " WHERE(ACA_EVALUATION_SCHEME_INF.PGM_BRN_ID = @PARAMETER1) AND (ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = @PARAMETER2) "+
                                       " AND (SUB_TYPE_ID = @PARAMETER3) AND (ACA_BATCH_SEM_INF.ACA_BAT_SEM_STS=1)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);

                break;
            case QueryBaseType.CourseFilePaper:
                command = new SqlCommand("SELECT DISTINCT '('+ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE+')'+ACA_SUBJECT_INF.ACA_SUB_NAME,ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE " +
                                        " FROM ACA_EVALUATION_SCHEME_INF INNER JOIN " +
                                        " ACA_EVA_SCH_SUBJECT_INF ON ACA_EVALUATION_SCHEME_INF.EVA_SCH_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID INNER JOIN " +
                                       " ACA_SUBJECT_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SUB_ID = ACA_SUBJECT_INF.ACA_SUB_ID  " +
                                       " WHERE(ACA_EVALUATION_SCHEME_INF.PGM_BRN_ID = @PARAMETER1) AND (ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = @PARAMETER2) " +
                                       " AND (ACA_BATCH_ID = @PARAMETER3) AND (EVA_SCH_SUB_STS=1)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);

                break;
            #endregion

            case QueryBaseType.CourseByBrnchSem:
                command = new SqlCommand("SELECT DISTINCT '('+ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE+')'+ACA_SUBJECT_INF.ACA_SUB_NAME,ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_PAPER_CODE " +
                                        " FROM         ACA_EVALUATION_SCHEME_INF INNER JOIN " +
                                        " ACA_EVA_SCH_SUBJECT_INF ON ACA_EVALUATION_SCHEME_INF.EVA_SCH_ID = ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_ID INNER JOIN " +
                                        " ACA_SUBJECT_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SUB_ID = ACA_SUBJECT_INF.ACA_SUB_ID INNER JOIN " +
                                        " ACA_BATCH_SEM_INF ON ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = ACA_BATCH_SEM_INF.ACA_SEM_ID AND ACA_EVALUATION_SCHEME_INF.ACA_BATCH_ID=ACA_BATCH_SEM_INF.ACA_BATCH_ID INNER JOIN " +                                         
                                        " STU_MAJOR_SUB_INF ON STU_MAJOR_SUB_INF.EVA_SCH_SUB_ID=ACA_EVA_SCH_SUBJECT_INF.EVA_SCH_SUB_ID  INNER JOIN "+
                                        " STU_MAJOR_MAIN_INF ON STU_MAJOR_SUB_INF.MEM_ID=STU_MAJOR_SUB_INF.MEM_ID "+
                                        " WHERE(ACA_EVA_SCH_SUBJECT_INF.SUB_TYPE_ID = 0) AND EXAM_MAIN_ID=@PARAMETER3  AND (ACA_BATCH_SEM_INF.ACA_BAT_SEM_STS =1) AND (ACA_EVALUATION_SCHEME_INF.PGM_BRN_ID = @PARAMETER1) AND (ACA_EVA_SCH_SUBJECT_INF.ACA_SEM_ID = @PARAMETER2)");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);
                break;

            #region MINOR
            case QueryBaseType.SeatingRoom:
                command = new SqlCommand("SELECT  DISTINCT MINOR_INS_ROOM_INF.ROOM_VALUE,MINOR_INS_ROOM_INF.ROOM_ID FROM MINOR_SEATING_PLAN_INF INNER JOIN MINOR_ROOM_SEAT_INF ON MINOR_SEATING_PLAN_INF.SEAT_ID = MINOR_ROOM_SEAT_INF.SEAT_ID INNER JOIN"
                    + " MINOR_INS_ROOM_INF ON MINOR_ROOM_SEAT_INF.ROOM_ID = MINOR_INS_ROOM_INF.ROOM_ID INNER JOIN MINOR_CRS_SHEDULE_INF ON MINOR_SEATING_PLAN_INF.MIN_SHEDULE_ID = MINOR_CRS_SHEDULE_INF.MIN_SHEDULE_ID WHERE CONVERT(VARCHAR,SH_DATE,103)=@PARAMETER1  AND MINOR_CRS_SHEDULE_INF.SHIFT_ID=@PARAMETER2 AND MINOR_INS_ROOM_INF.INS_ID=@PARAMETER3 ORDER BY MINOR_INS_ROOM_INF.ROOM_ID");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);
                break;
            #endregion
         
            case QueryBaseType.DetainedPaperCode:
                command = new SqlCommand("SELECT  DISTINCT  '(' + Examination.dbo.EXAM_CRS_MAIN_INF.CRS_CODE + ')' + Examination.dbo.EXAM_CRS_MAIN_INF.CRS_NAME AS CSR_NAME ,Examination.dbo.EXAM_CRS_MAIN_INF.CRS_CODE  FROM  Examination.dbo.EXAM_CRS_MAIN_INF INNER JOIN " +
                      " Examination.dbo.PGM_BRN_BATCH_MAPP_INF ON Examination.dbo.EXAM_CRS_MAIN_INF.PGM_MAPP_ID = Examination.dbo.PGM_BRN_BATCH_MAPP_INF.PGM_MAPP_ID INNER JOIN " +
                        " Examination.dbo.EXAM_BACK_REG_SUB_INF ON Examination.dbo.EXAM_CRS_MAIN_INF.CRS_EXAM_ID = Examination.dbo.EXAM_BACK_REG_SUB_INF.CRS_PAPER_ID INNER JOIN " +
                        " Examination.dbo.EXAM_BACK_REG_MAIN_INF ON Examination.dbo.EXAM_BACK_REG_SUB_INF.BACK_MAIN_ID = Examination.dbo.EXAM_BACK_REG_MAIN_INF.BACK_REG_MAIN_ID INNER JOIN " +
                        " ERP.dbo.INS_PGM_BRN_INF ON Examination.dbo.PGM_BRN_BATCH_MAPP_INF.PGM_BRN_ID= ERP.dbo.INS_PGM_BRN_INF.PGM_BRN_ID WHERE (EXAM_BACK_REG_SUB_INF.EXAM_TYPE in (2,3)) " +
            " AND (EXAM_BACK_REG_SUB_INF.BACK_PAPER_STS = 2) AND EXAM_BACK_REG_MAIN_INF.EXAM_ID=@PARAMETER3 AND PGM_BRN_BATCH_MAPP_INF.PGM_BRN_ID=@PARAMETER1 AND Examination.dbo.EXAM_CRS_MAIN_INF.ACA_SEM_ID=@PARAMETER2");
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@PARAMETER1", parameter1);
                command.Parameters.AddWithValue("@PARAMETER2", parameter2);
                command.Parameters.AddWithValue("@PARAMETER3", parameter3);
                break;


          
            default:
                break;

        }
        return command;
    }
}



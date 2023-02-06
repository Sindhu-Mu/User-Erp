using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SFBAL
/// </summary>
public class SFBAL
{
    public SFBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region
    private string FeeGroupHeadId;
    private string MainHeadId;
    private string Status;
    private string HeadName;
    private string HeadOneTime;
    private string HeadInScho;
    private string HeadPriority;
    private string HeadInStruc;
    private string CourseId;
    private string BatchId;
    private string Data;
    private string CurUser;
    private string Quota;
    private string ConcPer;
    private string ConcMax;
    private string Session;
    private string ConcId;
    private string Date;
    private string Reason;
    private string ModeId;
    private string Enrol;
    private string Sem;
    private string Amt;
    private string DemandId;
    private string CommonId;
    private string InsId;
    private string SemType;
    private string BranchId;
    private string Enrollment;
    private string Branch;
    private string AdjAmount;
    private string ProcId;
    private string RuleId;
    private string HeadAmt;
    private string Percentage;
    private string Relation;
    private string PgmId;
    private string RcvId;
    private string Case;
    private string Count;
    private string program;
    private string TempId;
    private string StuAdmNo;
    private string RcptNo;
    public string XmlValue { get; set; }
    public string XmlValue2 { get; set; }
    public DateTime FromDate { get; set; }
    #endregion
    public string balRcptNo
    {
        get { return RcptNo; }
        set { RcptNo = value; }
    }
    public string balStuAdmNo
    {
        get { return StuAdmNo; }
        set { StuAdmNo = value; }
    }
    public string balCount
    {
        get { return Count; }
        set { Count = value; }
    }
    public string balRcvId
    {
        get { return RcvId; }
        set { RcvId = value; }
    }
    public string balProgram
    {
        get
        {
            return program;
        }
        set
        {
            program = value;
        
        }
    }
    #region Nisha_FeeProcess

    private string ProcessName;
    private string StrtDate;
    private string EndDate;
    private string InBy;
    private string ProcessId;
    #endregion
    #region FeeFineRuleMaster_Nisha
    private string Rule;
    private string Amount;
    private string Nod;
    private string EmpName;
    private string Type;
    #endregion
    # region Nisha
    private string Rate;
    private string CrncyTo;
    private string CrncyFrom;
    #endregion
    #region Riju
    private string AdjType;
    private string Remark;
    private string Enroll;
    private DateTime DateTime;
    #endregion

    #region FeeGroupHeadMaster_Nisha
    private string HeadType;
    private string TopHeadId;
    #endregion
    #region FeeChequeReport_Nisha
    private string ChequeNo;
    private string DateTo;
    private string DateFrom;
    private string Mode;

    #endregion

    #region definition
    public string balPgmId
    {
        get { return PgmId; }
        set { PgmId = value; }
    }
    public string balEnrollment
    {
        get { return Enrollment; }
        set { Enrollment = value; }
    }
    public string balBranch
    {
        get { return Branch; }
        set { Branch = value; }
    }
    public string balBranchId
    {
        get { return BranchId; }
        set { BranchId = value; }
    }
    public string balAdjAmount
    {
        get { return AdjAmount; }
        set { AdjAmount = value; }
    }
    public string balInsId
    {
        get { return InsId; }
        set { InsId = value; }
    }
    public string balCommonID
    {
        get { return CommonId; }
        set { CommonId = value; }
    }
    public string balAmt
    {
        get { return Amt; }
        set { Amt = value; }
    }
    public string balDemandId
    {
        get { return DemandId; }
        set { DemandId = value; }
    }
    public string balSemType
    {
        get { return SemType; }
        set { SemType = value; }
    }
    public string balSem
    {
        get { return Sem; }
        set { Sem = value; }
    }
    public string balEnrol
    {
        get { return Enrol; }
        set { Enrol = value; }
    }
    public string balDate
    {
        get { return Date; }
        set { Date = value; }
    }
    public string balModeId
    {
        get { return ModeId; }
        set { ModeId = value; }
    }
    public string balReason
    {
        get { return Reason; }
        set { Reason = value; }
    }
    public string balConcId
    {
        get { return ConcId; }
        set { ConcId = value; }
    }
    public string balConcMax
    {
        get { return ConcMax; }
        set { ConcMax = value; }
    }
    public string balSession
    {
        get { return Session; }
        set { Session = value; }
    }
    public string balConcPer
    {
        get { return ConcPer; }
        set { ConcPer = value; }
    }
    public string balQuota
    {
        get { return Quota; }
        set { Quota = value; }
    }
    public string balData
    {
        get { return Data; }
        set { Data = value; }
    }
    public string balCurUser
    {
        get { return CurUser; }
        set { CurUser = value; }
    }
    public string balBatchId
    {
        get { return BatchId; }
        set { BatchId = value; }
    }
    public string balCourseId
    {
        get { return CourseId; }
        set { CourseId = value; }
    }
    public string balFeeGroupHeadId
    {
        get { return FeeGroupHeadId; }
        set { FeeGroupHeadId = value; }
    }
    public string balStatus
    {
        get { return Status; }
        set { Status = value; }
    }
    public string balMainHeadId
    {
        get { return MainHeadId; }
        set { MainHeadId = value; }
    }
    public string balHeadName
    {
        get { return HeadName; }
        set { HeadName = value; }
    }
    public string balHeadOneTime
    {
        get { return HeadOneTime; }
        set { HeadOneTime = value; }
    }
    public string balHeadInScho
    {
        get { return HeadInScho; }
        set { HeadInScho = value; }
    }
    public string balHeadPriority
    {
        get { return HeadPriority; }
        set { HeadPriority = value; }
    }
    public string balHeadInStruc
    {
        get { return HeadInStruc; }
        set { HeadInStruc = value; }
    }
    public string balProcId
    {
        get { return ProcId; }
        set { ProcId = value; }
    }
    public string balRuleId
    {
        get { return RuleId; }
        set { RuleId = value; }
    }
    #endregion

    #region FeeChequeReport_Nisha
    public string balChequeNo
    {
        get
        {
            return ChequeNo;
        }
        set
        {
            ChequeNo = value;
        }
    }
    public string balDateTo
    {
        get
        {
            return DateTo;
        }
        set
        {
            DateTo = value;
        }
    }
    public string balDateFrom
    {
        get
        {
            return DateFrom;
        }
        set
        {
            DateFrom = value;
        }
    }
    public string balMode
    {
        get
        {
            return Mode;
        }
        set
        {
            Mode = value;
        }
    }
    #endregion


    #region FeeGroupHeadMaster_Nisha
    public string balHeadType
    {
        get
        {
            return HeadType;
        }
        set
        {
            HeadType = value;
        }
    }

    public string balTopHeadId
    {
        get
        {
            return TopHeadId;
        }
        set
        {
            TopHeadId = value;

        }
    }
    #endregion

    #region Nisha_FeeProcess

    public string balProcessName
    {
        get
        {
            return ProcessName;
        }
        set
        {
            ProcessName = value;
        }
    }
    public string balStrtDate
    {
        get
        {
            return StrtDate;
        }
        set
        {
            StrtDate = value;
        }
    }
    public string balEndDate
    {
        get
        {
            return EndDate;
        }
        set
        {
            EndDate = value;
        }
    }
    public string balInBy
    {
        get
        {
            return InBy;
        }
        set
        {
            InBy = value;
        }
    }
    public string balProcessId
    {
        get
        {
            return ProcessId;
        }
        set
        {
            ProcessId = value;
        }
    }

    #endregion
    #region FeeFineRuleMaster_Nisha
    public string balRule
    {
        get
        {
            return Rule;
        }
        set
        {
            Rule = value;
        }
    }
    public string balAmount
    {
        get
        {
            return Amount;
        }
        set
        {
            Amount = value;
        }
    }
    public string balNod
    {
        get
        {
            return Nod;
        }
        set
        {
            Nod = value;
        }
    }
    public string balEmpName
    {
        get
        {
            return EmpName;
        }
        set
        {
            EmpName = value;
        }
    }
    public string balType
    {
        get
        {
            return Type;
        }
        set
        {
            Type = value;
        }
    }
    #endregion
    #region Nisha
    public string balHeadAmt
    {
        get
        {
            return HeadAmt;
        }
        set
        {
            HeadAmt = value;
        }
    }
    public string balRate
    {
        get
        {
            return Rate;

        }
        set
        {
            Rate = value;
        }
    }
    public string balCrncyTo
    {
        get
        {
            return CrncyTo;
        }
        set
        {
            CrncyTo = value;
        }
    }
    public string balCrncyFrom
    {
        get
        {
            return CrncyFrom;

        }
        set
        {
            CrncyFrom = value;
        }
    }
    public string balPercentage
    {
        get
        {
            return Percentage;
        }
        set
        {
            Percentage = value;
        }
    }
    public string balCase
    {
        get {
            return Case;
        }
        set
        { 
            Case= value;
        }
    }
    #endregion
    #region Riju
    public string balAdjType
    {
        get { return AdjType; }
        set { AdjType = value; }
    }
    public string balRemark
    {
        get { return Remark; }
        set { Remark = value; }
    }
    public string balEnroll
    {
        get { return Enroll; }
        set { Enroll = value; }
    }
    public DateTime balDateTime
    {
        get { return DateTime; }
        set { DateTime = value; }
    }
    #endregion
    #region Abhinav
    public string balRelation
    {
        get
        {
            return Relation;
        }
        set
        {
            Relation = value;
        }
    
    }

    public string balTempId
    {
        get
        {
            return TempId;
        }
        set 
        {
            TempId = value;
        }
    }
    #endregion

    public string balConcession{ get; set; }
    public string balReceived { get; set; }
    public string balWAVE { get; set; }
}
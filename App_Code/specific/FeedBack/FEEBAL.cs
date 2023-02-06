using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FEEBAL
/// </summary>
public class FEEBAL
{
	public FEEBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region variable

    private string SemId;


    private string ID;
    private string Key_Value;
    private string Key_ID;
    private string Common_ID;
    private string Full_Name;
    private string Descp;
    private string Value_Type;
    private string Alias_Type;
    private string INSTITUTE_ID;
    private string EMP_ID;
    private string DEP_ID;
    private DateTime FRM_DATE;
    private DateTime TO_DATE;
    private DateTime DATE;
    private string NAME;
    private string CHANGE_STATUS;
    private string TYPE_ID;
    private string VALUE;
    private string XMLVALUE;
    private string Session_User_ID;
    private string Use_For;
    private string DISPLAY;
    private string V_FILE;
    private string FILE;
    private string PHN_NO;
    private string MBL_NO;
    private string PAR_PHN_NO;
    private string PAR_MOB_NO;
    private string PGM_ID;
    private string BRN_ID;
    private string SEC_ID;
    private string STU_ADM;
    private string MAX_DATE;
    private string ENROLL_NO;
    private string MARKS;
    private string PAP_CODE;
    private string EV_SCH_ID;
    private string LATERAL;
    private string YEAR;
    private string RULE_ID;
    private string SESSION_ID;
    private string INSERT_BY;
    private string REMARK;
    private string EXAM_ID;
    private string PAPER_NAME;
    #endregion

    #region Definition
    public string Semid
    {
        get { return SemId; }
        set { SemId = value; }
    }
    public string SessionUserID
    { get { return Session_User_ID; } set { Session_User_ID = value; } }
    public string Id
    {
        get { return ID; }
        set { ID = value; }
    }
    public string XmlValue
    {
        get { return XMLVALUE; }
        set { XMLVALUE = value; }
    }
    public string Value
    {
        get { return VALUE; }
        set { VALUE = value; }
    }
    public string FullName
    {
        get { return Full_Name; }
        set { Full_Name = value; }
    }
    public string KeyValue
    {
        get { return Key_Value; }
        set { Key_Value = value; }
    }
    public string KeyID
    {
        get { return Key_ID; }
        set { Key_ID = value; }
    }

    public string CommonId
    {
        get { return Common_ID; }
        set { Common_ID = value; }
    }

    public string Description
    {
        get { return Descp; }
        set { Descp = value; }
    }

    public string ValueType
    {
        get { return Value_Type; }
        set { Value_Type = value; }
    }

    public string AliasValue
    {
        get { return Alias_Type; }
        set { Alias_Type = value; }
    }
    public string TypeId
    { get { return TYPE_ID; } set { TYPE_ID = value; } }

    public string ChangeStatus
    {
        get { return CHANGE_STATUS; }
        set { CHANGE_STATUS = value; }
    }
    public string InsId
    {
        get { return INSTITUTE_ID; }
        set { INSTITUTE_ID = value; }
    }
    public string EmpId
    {
        get { return EMP_ID; }
        set { EMP_ID = value; }
    }
    public string DeptId
    {
        get { return DEP_ID; }
        set { DEP_ID = value; }
    }

    public DateTime FromDate
    {
        get { return FRM_DATE; }
        set { FRM_DATE = value; }
    }

    public DateTime ToDate
    {
        get { return TO_DATE; }
        set { TO_DATE = value; }
    }

    public DateTime Date
    { get { return DATE; } set { DATE = value; } }

    public string Name
    { get { return NAME; } set { NAME = value; } }

    public string UseFor
    {
        get { return Use_For; }
        set { Use_For = value; }
    }
    public string Display
    {
        get { return DISPLAY; }
        set { DISPLAY = value; }
    }
    public string View_File
    {
        get { return V_FILE; }
        set { V_FILE = value; }
    }
    public string File
    {
        get { return FILE; }
        set { FILE = value; }
    }
    public string Phn_No
    {
        get { return PHN_NO; }
        set { PHN_NO = value; }
    }

    public string Mbl_No
    {
        get { return MBL_NO; }
        set { MBL_NO = value; }
    }

    public string Par_Phn_No
    {
        get { return PAR_PHN_NO; }
        set { PAR_PHN_NO = value; }
    }

    public string Par_Mob_No
    {
        get { return PAR_MOB_NO; }
        set { PAR_MOB_NO = value; }
    }
    public string Pgm_Id
    {
        get { return PGM_ID; }
        set { PGM_ID = value; }
    }
    public string Brn_Id
    {
        get { return BRN_ID; }
        set { BRN_ID = value; }
    }
    public string Sec_Id
    {
        get { return SEC_ID; }
        set { SEC_ID = value; }
    }
    public string Stu_AdmNo
    {
        get { return STU_ADM; }
        set { STU_ADM = value; }
    }
    public string Max_Dt
    {
        get { return MAX_DATE; }
        set { MAX_DATE = value; }
    }
    public string Enroll_No
    {
        get { return ENROLL_NO; }
        set { ENROLL_NO = value; }
    }
    public string Marks
    {
        get { return MARKS; }
        set { MARKS = value; }
    }
    public string Pap_Code
    {
        get { return PAP_CODE; }
        set { PAP_CODE = value; }
    }
    public string Ev_Sch_Id
    {
        get { return EV_SCH_ID; }
        set { EV_SCH_ID = value; }
    }
    public string Lateral
    {
        get { return LATERAL; }
        set { LATERAL = value; }
    }
    public string Year
    {
        get { return YEAR; }
        set { YEAR = value; }
    }
    public string BAL_RULE_ID
    {
        get
        {
            return RULE_ID;
        }
        set
        {
            RULE_ID = value;
        }
    }
    public string BAL_SESSION_ID
    {
        get
        {
            return SESSION_ID;
        }
        set
        {
            SESSION_ID = value;
        }
    }
    #endregion

}
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
/// Summary description for AcaBAL
/// </summary>
public class HRBAL
{
    public HRBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region variable
    private string Session_User_ID;
    private string Key_Value;
    private string Key_ID;
    private string Common_ID;
    private string SHORT_NAME;
    private string Full_Name;
    private string Descp;
    private string Value_Type;
    private string Alias_Type;
    private string INSTITUTE_ID;
    private string EMP_ID;
    private string DEP_ID;
    private DateTime FRM_DATE;
    private DateTime TO_DATE;
    private string ACA_BASE_PRP;
    private string CODE;
    private string POST_ID;
    private string PAT;
    private string YER;
    private string PAG;
    private string ACC_NO;
    private string DES_ID;
    private string PASSWORD;
    private DateTime LAST_CHNG;
    private string QSN_ANS;
    private string PHN_NO;
    private string REM;
    private DateTime DATE;
    private string VIEW_TYPE;
    private DataSet ds;
    private string CHANGE_STATUS;
    private string TYPE_ID;
    private string IN_TIME;
    private string OUT_TIME;
    private string MIN_BFR_TIME;
    private string MIN_AFT_TIME;
    private string MAX_BFR_TIME;
    private string MAX_AFT_TIME;
    private string IN_BY;
    private string NAME;
    private string PAGE_NAME;
    private string HEAD_ID;
    private string SUB_HEAD_VALUE;
    private DateTime REGDATE;
    private string DOCUMENT;
    private string VALUE1;
    private string VALUE2;
    private string MIN;
    private string MAX;
    private string ORG_NAME;
    private string ORG_ADD;
    private string CIT_ID;
    private string ORG_TYPE_ID;
    private string TOTAL;
    private string LOCATION;
    private string ADMIN;
    private string CUR_CTC;
    private string EXP_CTC;
    private string MAIL_ID;
    private string MAIL_DOMAIN;
    private string F_NAME;
    private string M_NAME;
    private string L_NAME;
    private string XML_DATA;
    private string JOB_ID;
    private string EXP_DATA;
    
    #endregion


    #region definition

    public string SessionUserID
    { get { return Session_User_ID; } set { Session_User_ID = value; } }



    public string ORGNAME
    { get { return ORG_NAME; } set { ORG_NAME = value; } }

    public string ORGADD
    { get { return ORG_ADD; } set { ORG_ADD = value; } }

    public string CITYID
    { get { return CIT_ID; } set { CIT_ID = value; } }

    public string ORGTYPEID
    { get { return ORG_TYPE_ID; } set { ORG_TYPE_ID = value; } }

    public string Code
    { get { return CODE; } set { CODE = value; } }

    public string Name
    { get { return NAME; } set { NAME = value; } }

    public string PageName
    { get { return PAGE_NAME; } set { PAGE_NAME = value; } }

    public string HeadID
    { get { return HEAD_ID; } set { HEAD_ID = value; } }

    public string SubHeadValue
    { get { return SUB_HEAD_VALUE; } set { SUB_HEAD_VALUE = value; } }

    public string InTime
    { get { return IN_TIME; } set { IN_TIME = value; } }

    public string OutTime
    { get { return OUT_TIME; } set { OUT_TIME = value; } }

    public string ShortName
    { get { return SHORT_NAME; } set { SHORT_NAME = value; } }

    public string ShiftMinBefore
    {
        get { return MIN_BFR_TIME; }
        set { MIN_BFR_TIME = value; }
    }
    public string ShiftMinAfter
    {
        get { return MIN_AFT_TIME; }
        set { MIN_AFT_TIME = value; }
    }
    public string ShiftMaxBefore
    {
        get { return MAX_BFR_TIME; }
        set { MAX_BFR_TIME = value; }
    }
    public string ShiftMaxAfter
    {
        get { return MAX_AFT_TIME; }
        set { MAX_AFT_TIME = value; }
    }

    public string InBy
    {
        get { return IN_BY; }
        set { IN_BY = value; }
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

    public DataSet dsset
    {
        get { return ds; }
        set { ds = value; }
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

    public string BasePrp
    {
        get { return ACA_BASE_PRP; }
        set { ACA_BASE_PRP = value; }
    }



    public string PostId
    {
        get { return POST_ID; }
        set { POST_ID = value; }
    }

    public string Pattern
    {
        get { return PAT; }
        set { PAT = value; }
    }
    public string Year
    {
        get { return YER; }
        set { YER = value; }
    }

    public string Percentage
    {
        get { return PAG; }
        set { PAG = value; }
    }


    public string AccountNo
    {
        get { return ACC_NO; }
        set { ACC_NO = value; }
    }

    public string DesignationId
    {
        get { return DES_ID; }
        set { DES_ID = value; }
    }

    public string Password
    { get { return PASSWORD; } set { PASSWORD = value; } }

    public DateTime LastChange
    { get { return LAST_CHNG; } set { LAST_CHNG = value; } }

    public string QuestionAnswer
    { get { return QSN_ANS; } set { QSN_ANS = value; } }

    public string PhnNo
    { get { return PHN_NO; } set { PHN_NO = value; } }

    public string RemValue
    { get { return REM; } set { REM = value; } }

    public DateTime Date
    { get { return DATE; } set { DATE = value; } }

    public DateTime RegDate
    {
        get { return REGDATE; }
        set { REGDATE = value; }
    }

    public string ViewType
    { get { return VIEW_TYPE; } set { VIEW_TYPE = value; } }

    public string Document
    { get { return DOCUMENT; } set { DOCUMENT = value; } }

    public string Value1
    { get { return VALUE1; } set { VALUE1 = value; } }

    public string Value2
    { get { return VALUE2; } set { VALUE2 = value; } }

    public string Min
    { get { return MIN; } set { MIN = value; } }

    public string Max
    { get { return MAX; } set { MAX = value; } }

    public string Total
    { get { return TOTAL; } set { TOTAL = value; } }

    public string ExpData
    {
        get
        {
            return EXP_DATA;
        }
        set
        {
            EXP_DATA = value;
        }
    }
    public string JobId
    {
        get
        {
            return JOB_ID;
        }
        set
        {
            JOB_ID = value;
        }
    }

    public string XmlData
    {
        get
        {
            return XML_DATA;
        }
        set
        {
            XML_DATA = value;
        }
    }

    public string LName
    {
        get
        {
            return L_NAME;
        }
        set
        {
            L_NAME = value;
        }
    }
    public string MName
    {
        get
        {
            return M_NAME;
        }
        set
        {
            M_NAME = value;
        }
    }
    public string FName
    {
        get
        {
            return F_NAME;
        }
        set
        {
            F_NAME = value;
        }
    }
    public string MailId
    {
        get
        {
            return MAIL_ID;
        }
        set
        {
            MAIL_ID = value;
        }
    }


    public string Location
    {
        get
        {
            return LOCATION;
        }
        set
        {
            LOCATION = value;
        }
    }

    public string Admin
    {
        get
        {
            return ADMIN;
        }
        set
        {
            ADMIN = value;
        }
    }
    public string CurCTC
    {
        get
        {
            return CUR_CTC;
        }
        set
        {
            CUR_CTC = value;
        }
    }
    public string ExpCTC
    {
        get
        {
            return EXP_CTC;
        }
        set
        {
            EXP_CTC = value;
        }
    }
    public string MailDomain
    {
        get
        {
            return MAIL_DOMAIN;
        }
        set
        {
            MAIL_DOMAIN = value;
        }
    }
    
    #endregion
}
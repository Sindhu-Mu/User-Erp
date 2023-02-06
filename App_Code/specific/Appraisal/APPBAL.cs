using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for APPBAL
/// </summary>
public class APPBAL
{
    public APPBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region variable

    private string Session_User_ID;
    private string SEM;
    private string YEAR;
    private string ID;
    private string PAP_CODE;
    private string PAP_NAME;
    private string COUNT;
    private string LECTURE;
    private string TUTORIAL;
    private string PRACTICAL;
    private string REMARK;
    private string KEY_ID;
    private string DETAIL;
    private string DUTY;
    private string LEVEL;
    private string FROM_DATE;
    private string TO_DATE;
    private string OPMF;
    private string AWARD;
    private string MEMBERSHIP;
    private string NAME;
    private string SPONSOR;
    private string INSTITUE;
    private string PURPOSE;
    private string PLACE;
    private string OTHERS;
    private string CLASS;
    private string TITLE;
    private string SUPERVISOR;
    private string JOURNAL;
    private string VOLUME;
    private string PAGE;
    private string AUTHOR;
    private string CONFERENCE;
    private string PUBLISHER;
    private string FUND;
    private string FINANCE;
    private string STATUS;
    private string MONTH;
    private string PROGRAM;
    private string TASK;
    private string COMMENT;
    private string ENROLLMENT;
    private string USR_ID;
    private string XML;
    private string EMP_ID;
    private string DEPT;
    private string BATCH;
    private string START_DATE;
    private string END_DATE;

    #endregion


    #region definition


    public string SessionUserId
    {
        get
        {
            return Session_User_ID;
        }
        set
        {
            Session_User_ID = value;
        }
    }
    public string Sem
    {
        get
        {
            return SEM;
        }
        set
        {
            SEM = value;
        }
    }

    public string Year
    {
        get
        {
            return YEAR;
        }
        set
        {
            YEAR = value;
        }
    }

    public string Id
    {
        get
        {
            return ID;
        }
        set
        {
            ID = value;
        }
    }
    public string PaperCode
    {
        get
        {
            return PAP_CODE;
        }
        set
        {
            PAP_CODE = value;
        }
    }
    public string PaperName
    {
        get
        {
            return PAP_NAME;
        }
        set
        {
            PAP_NAME = value;
        }
    }
    public string Count
    {
        get
        {
            return COUNT;
        }
        set
        {
            COUNT = value;
        }
    }
    public string Lecture
    {
        get
        {
            return LECTURE;
        }
        set
        {
            LECTURE = value;
        }
    }
    public string Tutorail
    {
        get
        {
            return TUTORIAL;
        }
        set
        {
            TUTORIAL = value;
        }
    }

    public string Practical
    {
        get
        {
            return PRACTICAL;
        }
        set
        {
            PRACTICAL = value;
        }
    }
    public string Remark
    {
        get
        {
            return REMARK;
        }
        set
        {
            REMARK = value;
        }
    }
    public string KeyId
    {
        get
        {
            return KEY_ID;
        }
        set
        {
            KEY_ID = value;
        }
    }
    public string Detail
    {
        get
        {
            return DETAIL;
        }
        set
        {
            DETAIL = value;
        }
    }

    public string Duty
    {
        get
        {
            return DUTY;
        }
        set
        {
            DUTY = value;
        }
    }
    public string Level
    {
        get
        {
            return LEVEL;
        }
        set
        {
            LEVEL = value;
        }
    }
    public string FromDate
    {
        get
        {
            return FROM_DATE;
        }
        set
        {
            FROM_DATE = value;
        }
    }

    public string ToDate
    {
        get
        {
            return TO_DATE;
        }
        set
        {
            TO_DATE = value;
        }
    }
    public string Opmf
    {
        get
        {
            return OPMF;
        }
        set
        {
            OPMF = value;
        }
    }
    public string Award
    {
        get
        {
            return AWARD;
        }
        set
        {
            AWARD = value;
        }
    }
    public string Membership
    {
        get
        {
            return MEMBERSHIP;
        }
        set
        {
            MEMBERSHIP = value;
        }
    }
    public string Name
    {
        get
        {
            return NAME;
        }
        set
        {
            NAME = value;
        }
    }
    public string Sponsor
    {
        get
        {
            return SPONSOR;
        }
        set
        {
            SPONSOR = value;
        }
    }
    public string Institute
    {
        get
        {
            return INSTITUE;
        }
        set
        {
            INSTITUE = value;
        }
    }
    public string Purpose
    {
        get
        {
            return PURPOSE;
        }
        set
        {
            PURPOSE = value;
        }
    }
    public string Place
    {
        get
        {
            return PLACE;
        }
        set
        {
            PLACE = value;
        }
    }
    public string Others
    {
        get
        {
            return OTHERS;
        }
        set
        {
            OTHERS = value;
        }
    }
    public string Class
    {
        get
        {
            return CLASS;
        }
        set
        {
            CLASS = value;
        }
    }
    public string Title
    {
        get
        {
            return TITLE;
        }
        set
        {
            TITLE = value;
        }
    }

    public string Supervisor
    {
        get
        {
            return SUPERVISOR;
        }
        set
        {
            SUPERVISOR = value;
        }
    }
    public string Journal
    {
        get
        {
            return JOURNAL;
        }
        set
        {
            JOURNAL = value;
        }
    }
    public string Volume
    {
        get
        {
            return VOLUME;
        }
        set
        {
            VOLUME = value;
        }
    }
    public string Page
    {
        get
        {
            return PAGE;
        }
        set
        {
            PAGE = value;
        }
    }
    public string Author
    {
        get
        {
            return AUTHOR;
        }
        set
        {
            AUTHOR = value;
        }
    }
    public string Conference
    {
        get
        {
            return CONFERENCE;
        }
        set
        {
            CONFERENCE = value;
        }
    }
    public string Publisher
    {
        get
        {
            return PUBLISHER;
        }
        set
        {
            PUBLISHER = value;
        }
    }
    public string Fund
    {
        get
        {
            return FUND;
        }
        set
        {
            FUND = value;
        }
    }
    public string Finance
    {
        get
        {
            return FINANCE;
        }
        set
        {
            FINANCE = value;
        }
    }
    public string Status
    {
        get
        {
            return STATUS;
        }
        set
        {
            STATUS = value;
        }
    }
    public string Month
    {
        get
        {
            return MONTH;
        }
        set
        {
            MONTH = value;
        }
    }
    public string Program
    {
        get
        {
            return PROGRAM;
        }
        set
        {
            PROGRAM = value;
        }
    }
    public string Task
    {
        get
        {
            return TASK;
        }
        set
        {
            TASK = value;
        }
    }

    public string Comment
    {
        get
        {
            return COMMENT;
        }
        set
        {
            COMMENT = value;
        }
    }
    public string Enrollment
    {
        get
        {
            return ENROLLMENT;
        }
        set
        {
            ENROLLMENT = value;
        }
    }
    public string Usr_id
    {
        get
        {
            return USR_ID;
        }
        set
        {
            USR_ID = value;
        }
    }
    public string Xml
    {
        get
        {
            return XML;
        }
        set
        {
            XML = value;
        }
    }
    public string Emp_id
    {
        get
        {
            return EMP_ID;
        }
        set
        {
            EMP_ID = value;
        }
    }
    public string Dept
    {
        get
        {
            return DEPT;
        }
        set
        {
            DEPT = value;
        }
    }
    public string Batch
    {
        get
        {
            return BATCH;
        }
        set
        {
            BATCH = value;
        }
    }
    public string StartDate
    {
        get
        {
            return START_DATE;
        }
        set
        {
            START_DATE = value;
        }
    }
    public string EndDate
    {
        get
        {
            return END_DATE;
        }
        set
        {
            END_DATE = value;
        }
    }
    #endregion
}
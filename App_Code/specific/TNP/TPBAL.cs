using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TPBAL
/// </summary>
public class TPBAL
{
	public TPBAL()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region variable
    private string Session_User_ID;
    private string NAME;
    private string STATUS;
    private string ID;
    private string ACTION;
    private string PROFILE;
    private string TODATE;
    private string FROMDATE;
    private string SALARY;
    private string VACCANCY;
    private string ADDRESS;
    private string OTHERS;
    private string PHONE;
    private string WEBSITE;
    private string EMAIL;
    private string PER_NAME;
    private string PER_ADD;
    private string PER_PHN;
    private string PER_EMAIL;
    private string ENROLLMENT;
    private string RESUME;
    private string HSC_PERCENT;
    private string HSC_BOARD;
    private string HSC_YEAR;
    private string SSC_PERCENT;
    private string SSC_BOARD;
    private string SSC_YEAR;
    private string GRAD_PERCENT;
    private string GRAD_BOARD;
    private string GRAD_YEAR;
    private string KEY_ID;
    private string Xml;
    private string DOMAIN;
    private string BRANCH;
    private string SEM;
    private string SESN;
    private string LOCATION;
    private string JOB_ID;
    private string MAIN_ID;

     #endregion
  
    #region defination
    public string Main_Id
    {
        get
        {
            return MAIN_ID;
        }
        set
        {
            MAIN_ID = value;
        }
    }
    public string Job_Id
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
    public string sesn
    {
        get
        {
            return SESN;
        }
        set
        {
            SESN = value;
        }
    }
    public string sem
    {
        get {
            return SEM;
        }
        set {
            SEM = value;
        }
    }
    public string branch
    {
        get
        {
            return BRANCH;
        }
        set
        {
            BRANCH = value;
        }
    
    }
    public string DOM
    {
        get
        {
            return DOMAIN;
        }
        set { DOMAIN = value; }

    }
    public string Key_Id
    {
        get
        {
            return KEY_ID;
        }
        set {
            KEY_ID = value;
        }
    }
    public string GY
    {
        get
        {
            return GRAD_YEAR;
        }
        set
        {
            GRAD_YEAR = value;
        }
    }
    public string GU
    {
        get
        {
            return GRAD_BOARD;
        }
        set
        {
            GRAD_BOARD = value;
        }
    }
    public string GP
    {
        get
        {
            return GRAD_PERCENT;
        }
        set
        {
            GRAD_PERCENT = value;
        }
    }
    public string SY
    {
        get
        {
            return SSC_YEAR;
        }
        set
        {
            SSC_YEAR = value;
        }
    }
    public string SU
    {
        get
        {
            return SSC_BOARD;
        }
        set
        {
            SSC_BOARD = value;
        }
    }
    public string SP
    {
        get
        {
            return SSC_PERCENT;
        }
        set
        {
            SSC_PERCENT = value;
        }
    }
    public string HY
    {
   get
    {
        return HSC_YEAR;
    }
        set
        {
            HSC_YEAR = value;
        }
}
    public string HU
    {
        get
        {
            return HSC_BOARD;

        }
        set
        {
            HSC_BOARD = value;
        }
    }
    public string HP
    {
        get 
        {
            return HSC_PERCENT;
        }
        set
        {
            HSC_PERCENT = value;
        }
    }
    public string Resume
    {
        get 
        {
            return RESUME;
        }
        set
        {
            RESUME = value;
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
    public string Per_Email
    {
        get
        {
            return PER_EMAIL;
        }
        set
        {
            PER_EMAIL = value;
        }
    }
    public string Per_Phn
    {
        get
        {
            return PER_PHN;
        }
        set 
        {
            PER_PHN = value;
        }
    }
    public string Per_Add
    {
        get
        {
            return PER_ADD;
        }
        set
        {
            PER_ADD = value;
        }
    }
    public string Per_Name
    {
        get
        {
            return PER_NAME;
        }
        set
        {
            PER_NAME = value;
        }
    }

    public string Email
    {
        get 
        {
            return EMAIL;
        }
        set 
        {
            EMAIL = value;
        }
    }
    public string Website
    {
        get 
        {
            return WEBSITE;
        }
        set 
        {
            WEBSITE = value;
        }
    }
    public string Phone
    {
        get 
        {
            return PHONE;
        }
        set
        {
            PHONE = value;
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
    public string Address
    {
        get 
        {
            return ADDRESS;
        }
        set
        {
            ADDRESS = value;
        }
    }
    public string Vaccancy
    {
        get
        {
            return VACCANCY;
        }
        set 
        {
            VACCANCY = value;
        }
    }
    public string Salary
    {
        get
        {
            return SALARY;
        }
        set
        {
            SALARY = value;
        }
    
    }
    public string FromDate
    {
        get 
        {
            return FROMDATE;
        }
        set
        {
            FROMDATE = value;
        }
    }
    public string ToDate
    {
        get
        {
            return TODATE;
        }
        set
        {
            TODATE = value;
        }
    }


    public string Profile
    {
        get
        {
            return PROFILE;
        }
        set
        {
            PROFILE = value;
        }
    }
    public string Action
    {
        get
        {
            return ACTION;
        }
        set
        {
            ACTION = value;
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
    public string xml
    {
        get
        {
            return Xml;
        }
        set
        {
            Xml = value;
        }
    }
   #endregion
}
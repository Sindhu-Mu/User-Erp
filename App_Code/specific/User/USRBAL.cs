using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for USRBAL
/// </summary>

    public class USRBAL
    {
        public USRBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Paramiters Declearation
        private string KEY_ID;
        private string KEY_VALUE;
        private string KEY_TYPE_ID;
        private string USR_ID;
        private string USR_LOGIN_ID; 
        private string USR_TYPE_ID;
       // private string USR_TOKEN_NO;
        private string USR_IS_REG;
        private string USR_STS;
        private string USR_PASS;
        private string CH_TYPE;
        private string SEC_QSN_ID;
        private string USR_QSN_ANS;
        private string USR_NAME;
        private string INS_ID;
        private string Xml_Value;
        private DateTime From_Date;
        private string Hostel_Id;
        private string DEPT_ID;
        private string VALUE1;
        private string VALUE2;
        #endregion
        
        public string XmlValue
        {
            get { return Xml_Value; }
            set { Xml_Value = value; }
        }
        public DateTime FromDt
        {
            get { return From_Date; }
            set { From_Date = value; }
        }
        public string KEYID
        {
            get { return KEY_ID; }
            set { KEY_ID = value; }
        }
        public string KEYVALUE
        {
            get { return KEY_VALUE; }
            set { KEY_VALUE = value; }
        }
        public string KEYTYPEID
        {
            get { return KEY_TYPE_ID; }
            set { KEY_TYPE_ID = value; }
        }
        public string USRID
        {
            get { return USR_ID; }
            set { USR_ID = value; }
        }
        public string LOGINID
        {
            get { return USR_LOGIN_ID; }
            set { USR_LOGIN_ID = value; }
        }
        public string USRNAME
        {
            get { return USR_NAME; }
            set { USR_NAME = value; }
        }       
        public string USRTYPEID
        {
            get { return USR_TYPE_ID; }
            set { USR_TYPE_ID = value; }
        }
        public string USRISREG
        {
            get { return USR_IS_REG; }
            set { USR_IS_REG = value; }

        }
        public string USRSTS
        {
            get { return USR_STS; }
            set { USR_STS = value; }

        }
        public string USRPASS
        {
            get { return USR_PASS; }
            set { USR_PASS = value; }

        }
        public string CHTYPE
        {
            get { return CH_TYPE; }
            set { CH_TYPE = value; }

        }
        public string SECQSNID
        {
            get { return SEC_QSN_ID; }
            set { SEC_QSN_ID = value; }

        }
        public string USRQSNANS
        {
            get { return USR_QSN_ANS; }
            set { USR_QSN_ANS = value; }

        }
        public string Value1
        { get { return VALUE1; } set { VALUE1 = value; } }

        public string Value2
        { get { return VALUE2; } set { VALUE2 = value; } }

        public string InsID
        {
            get { return INS_ID; }
            set { INS_ID = value; }
        }
        public string HostelId
        {
            get { return Hostel_Id; }
            set { Hostel_Id = value; }
        }
        public string DeptID
        {
            get { return DEPT_ID; }
            set { DEPT_ID = value; }
        }
    }


    

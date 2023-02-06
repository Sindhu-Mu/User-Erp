using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for USRDAL
/// </summary>
/// 


    public class USRDAL
    {
        DatabaseFunctions databaseFunctions;
        SqlCommand cmd;

        public USRDAL()
        {
            databaseFunctions = new DatabaseFunctions();
            //
            // TODO: Add constructor logic here
            //
        }
        public String UserNewRegistration(USRBAL ObjUsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "USR_NEW_REGISTRATION";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USER_LOGIN_ID", ObjUsrBal.LOGINID);
            cmd.Parameters.AddWithValue("@USR_PASS", ObjUsrBal.USRPASS);
            cmd.Parameters.AddWithValue("@TOKEN_NO", ObjUsrBal.KEYTYPEID);
            cmd.Parameters.AddWithValue("@QES_ID", ObjUsrBal.SECQSNID);
            cmd.Parameters.AddWithValue("@QES_ANS", ObjUsrBal.USRQSNANS);
            return databaseFunctions.GetSingleData(cmd);

        }
        public DataSet GetUser(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "GETUSER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USR_LOGIN_ID", UsrBal.LOGINID);
            cmd.Parameters.AddWithValue("@USR_PASS", UsrBal.USRPASS);
            cmd.Parameters.AddWithValue("@USR_TYPE", UsrBal.USRTYPEID);
            return databaseFunctions.GetDataSet(cmd);
        }
        public string GetInsId(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT INS_DEPT_INF.INS_ID FROM EMP_DEPT_CNG_INF INNER JOIN INS_DEPT_INF ON EMP_DEPT_CNG_INF.DEPT_ID = INS_DEPT_INF.DEPT_ID WHERE (EMP_DEPT_CNG_INF.TO_DATE IS NULL) AND (EMP_DEPT_CNG_INF.EMP_ID = @EMP_ID)";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@EMP_ID", UsrBal.LOGINID);
            return databaseFunctions.GetSingleData(cmd);
        }
        public void UpdateUsr(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "UPDATE_EMP_PASS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USR_ID", UsrBal.USRID);
            cmd.Parameters.AddWithValue("@PWD", UsrBal.KEYVALUE);
            databaseFunctions.ExecuteCommand(cmd);
        }
        #region ROLE
        public void RoleInsert(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "ROLE_INF_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ROLE_VALUE", UsrBal.KEYVALUE);
            cmd.Parameters.AddWithValue("@AUTHORITY_ID", UsrBal.KEYTYPEID);
            cmd.Parameters.AddWithValue("@IN_BY", UsrBal.USRID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        public void RoleUpdate(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "ROLE_INF_UPDATE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ROLE_ID", UsrBal.KEYID);
            cmd.Parameters.AddWithValue("@ROLE_VALUE", UsrBal.KEYVALUE);
            cmd.Parameters.AddWithValue("@AUTHORITY_ID", UsrBal.KEYTYPEID);
            cmd.Parameters.AddWithValue("@IN_BY", UsrBal.USRID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        public void RoleModify(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "ROLE_INF_MODIFY";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ROLE_ID", UsrBal.KEYID);
            cmd.Parameters.AddWithValue("@ROLE_STS", UsrBal.CHTYPE);
            cmd.Parameters.AddWithValue("@IN_BY", UsrBal.USRID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        #region Role Transfer
        public DataSet GetRole(USRBAL ObjUsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "EMP_ROLE_SELECT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USR_LOGIN_ID", ObjUsrBal.LOGINID);
            return databaseFunctions.GetDataSet(cmd);
        }
        public void RoleTransfer(USRBAL ObjUsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "EMP_ROLE_TRANSFER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@XML_DATA", ObjUsrBal.XmlValue);
            cmd.Parameters.AddWithValue("@NEW_USR", ObjUsrBal.LOGINID);
            cmd.Parameters.AddWithValue("@FRM_DT", ObjUsrBal.FromDt);
            cmd.Parameters.AddWithValue("@IN_BY", ObjUsrBal.USRID);
            databaseFunctions.ExecuteCommand(cmd);
        }
        #endregion
        #endregion
        #region MENU
        public void RoleMenuInsert(USRBAL UsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "ROLE_ACC_INF_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ROLE_ID", UsrBal.KEYID);
            cmd.Parameters.AddWithValue("@MENU_ID", UsrBal.KEYTYPEID);
            cmd.Parameters.AddWithValue("@XML_DATA", UsrBal.KEYVALUE);          
            databaseFunctions.ExecuteCommand(cmd);
        }
        #endregion
        #region USERROLE
        public void UserRoleInsert(USRBAL ObjUsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "USR_ROLE_INF_INSERT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USR_LOGIN_ID", ObjUsrBal.USRID);
            cmd.Parameters.AddWithValue("@USR_TYPE_ID", ObjUsrBal.KEYTYPEID);
            cmd.Parameters.AddWithValue("@USR_ROLE", ObjUsrBal.KEYID);
            cmd.Parameters.AddWithValue("@IN_BY", ObjUsrBal.LOGINID);
            databaseFunctions.GetDataSet(cmd);
        }
        public void UserRoleDelete(USRBAL ObjUsrBal)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "USR_ROLE_INF_UPDATE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USR_ROLE_ID", ObjUsrBal.KEYID);
            cmd.Parameters.AddWithValue("@IN_BY", ObjUsrBal.USRID);
            databaseFunctions.GetDataSet(cmd);
        }
        #endregion
    }

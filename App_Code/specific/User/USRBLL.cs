using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.SessionState;
using System.Data.SqlClient;

/// <summary>
/// Summary description for USRHRBLL
/// </summary>

public class USRBLL
{
    USRDAL ObjUsrDal;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
    public USRBLL()
    {
        ObjUsrDal = new USRDAL();
        databaseFunctions = new DatabaseFunctions();
        Msg = new Messages();

    }
    public bool GetUserInformation(USRBAL ObjUserBal)
    {
        try
        {
            DataTable dt = ObjUsrDal.GetUser(ObjUserBal).Tables[0];
            if (dt.Rows.Count > 0)
            {
                ObjUserBal.USRID = dt.Rows[0][0].ToString();
                ObjUserBal.LOGINID = dt.Rows[0][1].ToString();
                ObjUserBal.USRNAME = dt.Rows[0][2].ToString();
                ObjUserBal.USRTYPEID = dt.Rows[0][3].ToString();
                ObjUserBal.InsID = dt.Rows[0][4].ToString();
                ObjUserBal.DeptID = dt.Rows[0][5].ToString();
                ObjUserBal.HostelId = dt.Rows[0][6].ToString();

                return true;
            }
            else
                return false;
        }
        catch
        {
            return false;
        }

    }
    public int UserRegistration(USRBAL ObjUserBal)
    {

        DataTable dt = ObjUsrDal.GetUser(ObjUserBal).Tables[0];
        if (dt.Rows.Count > 0)
        {
            ObjUserBal.USRID = dt.Rows[0][0].ToString();
            ObjUserBal.LOGINID = dt.Rows[0][1].ToString();
            ObjUserBal.USRNAME = dt.Rows[0][2].ToString();
            ObjUserBal.USRTYPEID = dt.Rows[0][3].ToString();
            return 1;
        }
        else
            return 0;
    }
    public string GetInsId(USRBAL ObjUserBal)
    {

        return ObjUsrDal.GetInsId(ObjUserBal);
    }
    public DataSet UserSelect(USRBAL Objbal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "EMP_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", Objbal.USRID);
        return databaseFunctions.GetDataSet(cmd);
    }
    public string EmpPassUpdate(USRBAL Objbal)
    {
        try
        {
            ObjUsrDal.UpdateUsr(Objbal);
            return Msg.GetMessage(Messages.DataMessType.Update);
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.Error);
        }
        finally
        {
            ObjUsrDal = null;
        }
    }
    #region USR ROLE TRANSFER
    public DataSet GetRole(USRBAL ObjUsrBal)
    {
        return ObjUsrDal.GetRole(ObjUsrBal);
    }
    public void RoleTransfer(USRBAL ObjUsrBal)
    {
        ObjUsrDal.RoleTransfer(ObjUsrBal);
    }
    #endregion
    #region OM
    #region ROLE
    #region ROLE SELECT
    public DataSet RoleSelect()
    {
        cmd = new SqlCommand();
        cmd.CommandText = "ROLE_INF_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region INSERT & UPDATE
    public string RoleInsertUpdate(USRBAL ObjUserBal)
    {
        try
        {
            if (ObjUserBal.KEYID == "")
            {
                ObjUsrDal.RoleInsert(ObjUserBal);
                return Msg.GetMessage(Messages.DataMessType.Insert);
            }
            else
            {
                ObjUsrDal.RoleUpdate(ObjUserBal);
                return Msg.GetMessage(Messages.DataMessType.Update);
            }
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjUsrDal = null; }

    }
    #endregion
    #region MODIFY
    public string RoleModify(USRBAL ObjUserBal)
    {
        try
        {
            ObjUserBal.CHTYPE = (ObjUserBal.CHTYPE == "Deactivate") ? "0" : "1";
            ObjUsrDal.RoleModify(ObjUserBal);
            return Msg.GetMessage(Messages.DataMessType.Status);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjUsrDal = null; }
    }
    #endregion
    #endregion
    public int GetMissPageRight(USRBAL ObjUsrBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_MISSING_PAGE_RIGHT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@PAGE_URL", ObjUsrBal.KEYID);

        return databaseFunctions.ExecuteScalar(cmd);
    }
    public string GetUserId(string EmpId)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "SELECT USR_ID FROM USR_INF WHERE USR_LOGIN_ID=@USR_LOGIN_ID";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@USR_LOGIN_ID", EmpId);
        return databaseFunctions.GetSingleData(cmd);
    }
    #region MENU SELECT
    public DataSet GETMENUPAGES(USRBAL ObjUsrBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_MENU_BY_HEAD";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@HEAD_ID", ObjUsrBal.KEYID);
        cmd.Parameters.AddWithValue("@ROLE_ID", ObjUsrBal.KEYTYPEID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region USER MENU SELECT
    public DataSet GETUSERROLES(USRBAL ObjUsrBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "GET_USR_ROLE";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@USR_ID", ObjUsrBal.USRID);
        cmd.Parameters.AddWithValue("@USR_TYPE", ObjUsrBal.KEYTYPEID);
        return databaseFunctions.GetDataSet(cmd);
    }
    #endregion
    #region USER ROLE INSERT
    public string UserRoleInsert(USRBAL ObjUserBal)
    {
        try
        {
            ObjUsrDal.UserRoleInsert(ObjUserBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjUsrDal = null; }

    }

    #endregion
    #region INSERT ROLE MENU
    public string RoleMenuInsert(USRBAL ObjUserBal)
    {
        try
        {
            ObjUsrDal.RoleMenuInsert(ObjUserBal);
            return Msg.GetMessage(Messages.DataMessType.Insert);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjUsrDal = null; }
    }
    #endregion
    #region DELETE USER ROLE
    public string UserRoleDelete(USRBAL ObjUserBal)
    {
        try
        {
            ObjUsrDal.UserRoleDelete(ObjUserBal);
            return Msg.GetMessage(Messages.DataMessType.Deleted);
        }
        catch
        { return Msg.GetMessage(Messages.DataMessType.Error); }
        finally
        { ObjUsrDal = null; }
    }
    #endregion
    #endregion
    #region Harshita
    public DataSet GetPendingLeave(USRBAL ObjUserBal)
    {
        ObjUserBal.InsID = (ObjUserBal.InsID == ".") ? "0" : ObjUserBal.InsID;
        ObjUserBal.KEYID = (ObjUserBal.KEYID == ".") ? "0" : ObjUserBal.KEYID;
        ObjUserBal.KEYVALUE = (ObjUserBal.KEYVALUE == "Select") ? "" : ObjUserBal.KEYVALUE;
        cmd = new SqlCommand("GET_PENDING_LEAVE");
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@INS_ID", ObjUserBal.InsID);
        cmd.Parameters.AddWithValue("@DEPT_ID", ObjUserBal.KEYID);
        cmd.Parameters.AddWithValue("@PENDING_WITH", ObjUserBal.KEYVALUE);
        cmd.Parameters.AddWithValue("@MONTH", ObjUserBal.Value1);
        cmd.Parameters.AddWithValue("@YEAR", ObjUserBal.Value2);
        return databaseFunctions.GetDataSet(cmd);
    }

    public string LeaveTransfer(USRBAL ObjUserBal)
    {
        try
        {
            cmd = new SqlCommand("TRANSFER_LEAVE");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@XML_DATA", ObjUserBal.XmlValue);
            cmd.Parameters.AddWithValue("@IN_BY", ObjUserBal.USRID);
            databaseFunctions.ExecuteCommand(cmd);
            return "Leave Transferred Successfully";
        }
        catch
        {
            return Msg.GetMessage(Messages.DataMessType.UpdateError);
        }
    }
    #endregion
}



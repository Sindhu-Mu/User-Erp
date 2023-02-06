using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

/// <summary>
/// Summary description for FEEBLL
/// </summary>
public class FEEBLL
{
    	
     FEEDAL FEE_DAL;
    SqlCommand cmd;
    DatabaseFunctions databaseFunctions;
    Messages Msg;
	public FEEBLL()
	{
	
 
        databaseFunctions = new DatabaseFunctions();
        FEE_DAL = new FEEDAL();
        Msg = new Messages();
    }
    

    #region Riju
    public DataSet FeedQuesSelect(FEEBAL Objbal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "FEED_FAC_QUES_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        return databaseFunctions.GetDataSet(cmd);
    }

    public DataSet FeedFacMarksInsert(FEEBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "FAC_FEED_MKS_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@DATA", ObjBal.XmlValue);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    public void FeedRmkInsert(FEEBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "FEED_RMK_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ID", ObjBal.Stu_AdmNo);
        cmd.Parameters.AddWithValue("@DATA", ObjBal.KeyValue);
        cmd.Parameters.AddWithValue("@USR_ID", ObjBal.Name);
        cmd.Parameters.AddWithValue("@RMK", ObjBal.Description);
        databaseFunctions.ExecuteCommand(cmd);
    }

    public void HostFeedRmkInsert(FEEBAL ObjBal)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "HOST_FEED_RMK_INSERT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_ID", ObjBal.Description);
        cmd.Parameters.AddWithValue("@RMK", ObjBal.Description);
        databaseFunctions.ExecuteCommand(cmd);

    }

    public DataSet FEED_REG_OPEN(FEEBAL ObjBal)
    {
        cmd = new SqlCommand();
        cmd.CommandText = "FAC_FEED_RULE_SELECT_2";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@STU_MAIN_ID", ObjBal.Stu_AdmNo);
        return databaseFunctions.GetDataSet(cmd);
    }

    #endregion
}
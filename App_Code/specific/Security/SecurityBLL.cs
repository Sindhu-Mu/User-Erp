using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SecurityBLL
/// </summary>
public class SecurityBLL
{
    SqlCommand cmd;
    DatabaseFunctions databaseFunction = new DatabaseFunctions();
    
	public SecurityBLL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataSet SecurityCardSelect(SecurityBAL ObjBal)
    {

        cmd = new SqlCommand();
        cmd.CommandText = "SECURITY_CARD_SELECT";
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@EMP_CODE", ObjBal.EMP_CODE);
        return databaseFunction.GetDataSet(cmd);
    }
}
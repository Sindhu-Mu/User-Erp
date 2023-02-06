using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/// <summary>
/// Summary description for FEEDAL
/// </summary>
public class FEEDAL
{
    DatabaseFunctions databaseFunctions;
    SqlCommand cmd;
	public FEEDAL()
	{
        databaseFunctions = new DatabaseFunctions();
	}
}
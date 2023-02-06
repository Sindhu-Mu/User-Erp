using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for PRDAL
/// </summary>
public class PRDAL
{
    DatabaseFunctions databaseFunctions;
    //SqlCommand cmd;
	public PRDAL()
	{
		//
		// TODO: Add constructor logic here
        databaseFunctions = new DatabaseFunctions();
		//
	}
}
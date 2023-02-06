using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SecurityBAL
/// </summary>
public class SecurityBAL
{
	public SecurityBAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string emp_code;

    public string EMP_CODE
    {
        get
        {
            return emp_code;
        }
        set
        {
            emp_code = value;
        }
    
    }
}
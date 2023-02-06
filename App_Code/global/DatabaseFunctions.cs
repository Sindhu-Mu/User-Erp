
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;
/// <summary>
/// Summary description for DatabseFunctions
/// </summary>
public class DatabaseFunctions
{
    SqlConnection connection;
    public enum ReturnType { Integer, DateTime, String };
    public enum ParameterType { Mandatory, Expected };
    string connectionString;
    public DatabaseFunctions()
    {
        connectionString = ConfigurationManager.AppSettings["conStr"].ToString();
    }
    #region StudentFinance
    public string ConvertNumberToWord(double Amount)
    {
        long CurrentNumber = (long)Amount;
        string sReturn = "";

        if (CurrentNumber >= 10000000)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 10000000, "Crore");
            CurrentNumber = CurrentNumber % 10000000;
        }
        if (CurrentNumber >= 100000)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 100000, "Lac");
            CurrentNumber = CurrentNumber % 100000;
        }

        if (CurrentNumber >= 1000)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 1000, "Thousand");
            CurrentNumber = CurrentNumber % 1000;
        }
        if (CurrentNumber >= 100)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber / 100, "Hundred");
            CurrentNumber = CurrentNumber % 100;
        }
        if (CurrentNumber >= 20)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber, "");
            CurrentNumber = CurrentNumber % 10;
        }
        else if (CurrentNumber > 0)
        {
            sReturn = sReturn + " " + GetWord(CurrentNumber, "");
            CurrentNumber = 0;
        }
        return sReturn.Replace("  ", " ").Trim();
    }
    private string GetWord(long nNumber, string sPrefix)
    {
        long nCurrentNumber = nNumber;
        string sReturn = "";
        while (nCurrentNumber > 0)
        {
            if (nCurrentNumber > 100)
            {
                sReturn = sReturn + " " + GetWord(nCurrentNumber / 100, "Hundred");
                nCurrentNumber = nCurrentNumber % 100;
            }
            else if (nCurrentNumber >= 20)
            {
                sReturn = sReturn + " " + GetTwentyWord(nCurrentNumber / 10);
                nCurrentNumber = nCurrentNumber % 10;
            }
            else
            {
                sReturn = sReturn + " " + GetLessThanTwentyWord(nCurrentNumber);
                nCurrentNumber = 0;
            }
        }
        sReturn = sReturn + " " + sPrefix;
        return sReturn;
    }
    private string GetTwentyWord(long nNumber)
    {
        string sReturn = "";
        switch (nNumber)
        {
            case 2: sReturn = "Twenty"; break;
            case 3: sReturn = "Thirty"; break;
            case 4: sReturn = "Forty"; break;
            case 5: sReturn = "Fifty"; break;
            case 6: sReturn = "Sixty"; break;
            case 7: sReturn = "Seventy"; break;
            case 8: sReturn = "Eighty"; break;
            case 9: sReturn = "Ninety"; break;
        }
        return sReturn;
    }
    private string GetLessThanTwentyWord(long nNumber)
    {
        string sReturn = "";
        switch (nNumber)
        {
            case 1: sReturn = "One"; break;
            case 2: sReturn = "Two"; break;
            case 3: sReturn = "Three"; break;
            case 4: sReturn = "Four"; break;
            case 5: sReturn = "Five"; break;
            case 6: sReturn = "Six"; break;
            case 7: sReturn = "Seven"; break;
            case 8: sReturn = "Eight"; break;
            case 9: sReturn = "Nine"; break;
            case 10: sReturn = "Ten"; break;
            case 11: sReturn = "Eleven"; break;
            case 12: sReturn = "Twelve"; break;
            case 13: sReturn = "Thirteen"; break;
            case 14: sReturn = "Forteen"; break;
            case 15: sReturn = "Fifteen"; break;
            case 16: sReturn = "Sixteen"; break;
            case 17: sReturn = "Seventeen"; break;
            case 18: sReturn = "Eighteen"; break;
            case 19: sReturn = "Nineteen"; break;
        }
        return sReturn;
    }
    #endregion

    public string GetSingleData(SqlCommand command)
    {
        string returnData;
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            command.Connection = connection;
            connection.Open();
            returnData = command.ExecuteScalar().ToString();
        }
        return returnData;
    }
    public XmlReader GetXmlData(SqlCommand command)
    {     
        connection = new SqlConnection(connectionString);
        command.Connection = connection;
        connection.Open();
        return command.ExecuteXmlReader();
    }
    public SqlDataReader GetReaderByQuery(string str)
    {
        connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(str);
        command.CommandType = CommandType.Text;
        command.Connection = connection;
        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
    }
    public SqlDataReader GetReader(SqlCommand command)
    {
        connection = new SqlConnection(connectionString);
        command.CommandTimeout = 5000;
        command.Connection = connection;
        connection.Open();
        return command.ExecuteReader(CommandBehavior.CloseConnection);
    }
    public void ExecuteCommand(SqlCommand command)
    {
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            command.Connection = connection;
            connection.Open();
            command.ExecuteNonQuery();
        }
    }
    public DataSet GetDataSet(SqlCommand command)
    {

        connection = new SqlConnection(connectionString);
        command.CommandTimeout = 500;
        SqlDataAdapter adapter;
        DataSet dataSet;
        using (connection)
        {
            adapter = new SqlDataAdapter(command);
            command.Connection = connection;
            dataSet = new DataSet();
            adapter.Fill(dataSet);
            
        }
        connection.Close();
        return dataSet;
    }
    public DataSet GetDataSetByQuery(string str)
    {
        SqlCommand command = new SqlCommand(str);
        command.CommandType = CommandType.Text;
        connection = new SqlConnection(connectionString);
        command.CommandTimeout = 500;
        SqlDataAdapter adapter;
        DataSet dataSet;
        
        using (connection)
        {
            adapter = new SqlDataAdapter(command);
            command.Connection = connection;
            dataSet = new DataSet();
            adapter.Fill(dataSet);
        }
        return dataSet;
    }
    public int execute_non_query(string strSql)
    {
        int IntResult = 0;
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            SqlCommand command = new SqlCommand(strSql, connection);
            command.CommandTimeout = 500;
            IntResult = command.ExecuteNonQuery();
        }
        return IntResult;
    }
    public int ExecuteScalarByQuery(string strSql)
    {
        int IntResult = 0;
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            SqlCommand command = new SqlCommand(strSql, connection);
            command.CommandTimeout = 500;
            IntResult =Convert.ToInt32(command.ExecuteScalar());
        }
        return IntResult;
    }
    public int ExecuteScalar(SqlCommand command)
    {
        int IntResult = 0;
        connection = new SqlConnection(connectionString);
        using (connection)
        {
            command.Connection= connection;           
            command.CommandTimeout = 500;
            connection.Open();
            IntResult = Convert.ToInt32(command.ExecuteScalar());
            connection.Close();
        }
        return IntResult;
    }
    public int execute_non_query(SqlCommand command)
    {
        int IntResult = 0;
        connection = new SqlConnection(connectionString);
        using (connection)
        {

            command.CommandTimeout = 0;
            command.Connection = connection;
            connection.Open();
            IntResult = command.ExecuteNonQuery();
            connection.Close();
        }
        return IntResult;
    }
}

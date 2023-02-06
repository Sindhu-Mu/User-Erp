
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
namespace ExamFunctions
{
    public class DatabaseFunctions
    {
        SqlConnection connection;
        public enum ReturnType { Integer, DateTime, String };
        public enum ParameterType { Mandatory, Expected };
        string connectionString;
        public DatabaseFunctions()
        {
            connectionString = ConfigurationManager.AppSettings["conStrExam"].ToString();
        }

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
                IntResult = Convert.ToInt32(command.ExecuteScalar());
            }
            return IntResult;
        }
        public int ExecuteScalar(SqlCommand command)
        {
            int IntResult = 0;
            connection = new SqlConnection(connectionString);
            using (connection)
            {
                command.Connection = connection;
                command.CommandTimeout = 500;
                connection.Open();
                IntResult = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
            return IntResult;
        }

    }
}
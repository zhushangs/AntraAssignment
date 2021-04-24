using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace MinionsApp.Data.Repository
{
    class DBHelper
    {
        IConfigurationBuilder builder;
        public DBHelper()
        {

        }
        public string GetConnectionString()
        {
            builder = new ConfigurationBuilder();
            var root = builder.AddJsonFile("appsettings.json").Build();
            string connectionString = root.GetConnectionString("MinionsDB");
            return connectionString;
        }

        public int ExecuteDML(string cmd, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlConnection.ConnectionString = GetConnectionString();
                sqlConnection.Open();
                sqlCommand.CommandText = cmd;
                if(parameters != null)
                {
                    foreach(var item in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                sqlCommand.Connection = sqlConnection;
                int result = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlCommand.Dispose();
                sqlCommand.Dispose();
            }
            return 0;
        }

        public DataTable GetData(string cmd, Dictionary<string, object> parameters, CommandType cmdType = CommandType.Text)
        {
            SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand();
            try
            {
                sqlConnection.ConnectionString = GetConnectionString();
                sqlConnection.Open();
                sqlCommand.CommandText = cmd;
                sqlCommand.CommandType = cmdType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        sqlCommand.Parameters.AddWithValue(item.Key, item.Value);
                    }
                }
                sqlCommand.Connection = sqlConnection;
                SqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                sqlConnection.Close();
                return dt;
            }
            catch (Exception ex)
            { }
            finally
            {
                sqlCommand.Dispose();
                sqlConnection.Dispose();
            }
            return null;
        }
    }
    
}

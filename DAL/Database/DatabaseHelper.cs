using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DAL.Database;
using System.Data;
using DAL.Interfaces;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.Extensions.Options;

namespace DAL.Database
{
    public class DatabaseHelper : IDatabaseHelper
    {
        public readonly string _connectionString; 
        public DatabaseHelper(IOptions<DatabaseSettings> dbSettings)
        {
            this._connectionString = dbSettings.Value.ConnectionString; 
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); 
        }

        //public int ExecuteNonQuery (string query, SqlParameter[] parameters = null)
        //{
        //    using (var connection = GetConnection() )
        //    {
        //        connection.Open();
        //        using (var command = new SqlCommand())
        //        {
        //            if (parameters != null)
        //            {
        //                command.Parameters.AddRange(parameters);
        //            }
        //            return command.ExecuteNonQuery(); 
        //        }
        //    }   
        //}
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    return command.ExecuteNonQuery();
                }
            }
        }

        public SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null )
        {
            var connection = GetConnection();
            connection.Open();
            var command = new SqlCommand(query,connection);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);     
            }
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
    }
}


//public DatabaseHelper()
//{
//    // Read the connection string from appsettings or config
//    _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
//}

//// Execute stored procedures with parameters
//public void ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters)
//{
//    using (SqlConnection conn = new SqlConnection(_connectionString))
//    {
//        using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
//        {
//            cmd.CommandType = CommandType.StoredProcedure;
//            if (parameters != null)
//            {
//                cmd.Parameters.AddRange(parameters);
//            }

//            conn.Open();
//            cmd.ExecuteNonQuery();
//        }
//    }
//}

//// Retrieve data from the database
//public DataTable ExecuteQuery(string storedProcedure, SqlParameter[] parameters = null)
//{
//    using (SqlConnection conn = new SqlConnection(_connectionString))
//    {
//        using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
//        {
//            cmd.CommandType = CommandType.StoredProcedure;
//            if (parameters != null)
//            {
//                cmd.Parameters.AddRange(parameters);
//            }

//            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
//            {
//                DataTable dataTable = new DataTable();
//                adapter.Fill(dataTable);
//                return dataTable;
//            }
//        }
//    }
//}
//}

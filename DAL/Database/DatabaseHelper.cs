using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL.Database
{
    class DatabaseHelper
    {
        public readonly string _connectionString; 
        public DatabaseHelper(string connectionString)
        {
            this._connectionString = connectionString; 
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString); 
        } 
        
        public int ExecuteNonQuery (string query, SqlParameter[] parameters = null)
        {
            using (var connection = GetConnection() )
            {
                connection.Open();
                using (var command = new SqlCommand())
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

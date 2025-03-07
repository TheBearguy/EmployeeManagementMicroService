using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IDatabaseHelper
    {
        SqlConnection GetConnection();
        int ExecuteNonQuery(string query, SqlParameter[] parameters = null);
        SqlDataReader ExecuteReader(string query, SqlParameter[] parameters = null);
    }
}

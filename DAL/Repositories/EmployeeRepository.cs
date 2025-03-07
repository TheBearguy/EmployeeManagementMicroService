using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;
using System.Data.SqlClient;

namespace DAL.Repositories
{
    class EmployeeRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public EmployeeRepository(string connectionString)
        {
            _databaseHelper = new DatabaseHelper(connectionString);
        }
        
        public List<Employee> GetAll()
        {
            var employees = new List<Employee>();
            var query = "EXEC ManageEmployees 'SELECT'";
            var reader = _databaseHelper.ExecuteReader(query);
            using (reader)
            {
                while ( reader.Read())
                {
                    employees.Add(
                        new Employee
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            Position = reader["position"].ToString(),
                            Salary = Convert.ToDecimal(reader["Salary"])
                        }
                    );
                }
            }
            return employees;
        }
        public Employee GetById()
        {
            var employee = new Employee();
            var query = "EXEC ManageEmployees 'SELECT', @Id";
            var reader = _databaseHelper.ExecuteReader(query);
            using (reader)
            {
                if (reader.Read())
                {
                    return new Employee
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        Position = reader["position"].ToString(),
                        Salary = Convert.ToDecimal(reader["Salary"])
                    };
                }
            }
            return null;
        }

        public void Insert(Employee employee)
        {
            var query = "EXEC ManageEmployees 'INSERT', @Name, @Position, @Salary";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Position", employee.Position),
                new SqlParameter("@Salary", employee.Salary)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        public void Update(Employee employee)
        {
            var query = "EXEC ManageEmployees 'UPDATE', @Id, @Name, @Position, @Salary";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", employee.Id),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Position", employee.Position),
                new SqlParameter("@Salary", employee.Salary)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        public void Delete(int id)
        {
            var query = "EXEC ManageEmployees 'DELETE', @Id";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", id)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}

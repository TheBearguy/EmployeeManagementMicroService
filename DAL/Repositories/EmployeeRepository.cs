using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels; 

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
    }
}

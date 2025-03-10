using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels; 
using System.Data.SqlClient;
using DAL.Database;
using DAL.Interfaces;
using Microsoft.Extensions.Options;

namespace DAL.Repositories
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public EmployeeProjectRepository(IOptions<DatabaseSettings> dbSettings)
        {
            _databaseHelper = new DatabaseHelper(dbSettings);
        }

        public void AssignEmployeeToProject(int employeeId, int projectId)
        {
            var query = "EXEC ManageEmployeeProjects 'ASSIGN' @EmployeeId, @ProjectId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@ProjectId", projectId)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        public void RemoveEmployeeFromProject(int employeeId, int projectId)
        {
            var query = "EXEC ManageEmployeeProjects 'REMOVE' @EmployeeId, @ProjectId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@ProjectId", projectId)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }

        public List<EmployeeProject> GetByEmployee(int employeeId)
        {
            var query = "EXEC ManageEmployeeProjects 'SELECT' @EmployeeId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@EmployeeId", employeeId),
            };
            List<EmployeeProject> employees = new List<EmployeeProject>();
            var reader = _databaseHelper.ExecuteReader(query, parameters);
            using (reader)
            {
                while (reader.Read())
                {
                    employees.Add( new EmployeeProject {
                        EmployeeId = (int)reader["EmployeeId"],
                        ProjectId = (int)reader["ProjectId"],
                    });
                }
            }
            return employees;
        }

        public List<EmployeeProject> GetByProject(int projectId)
        {
            var query = "EXEC ManageEmployeeProjects 'SELECT' @ProjectId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@ProjectId", projectId),
            };
            List<EmployeeProject> projects = new List<EmployeeProject>();
            var reader = _databaseHelper.ExecuteReader(query, parameters);
            using (reader)
            {
                while (reader.Read())
                {
                    projects.Add( new EmployeeProject
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        ProjectId = (int)reader["ProjectId"],
                    }
                    );
                }
            }
            return projects;
        }
    }
}

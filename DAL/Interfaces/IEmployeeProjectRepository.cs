using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IEmployeeProjectRepository
    {
        void AssignEmployeeToProject(int employeeId, int projectId);
        void RemoveEmployeeFromProject(int employeeId, int projectId);
        List<EmployeeProject> GetByEmployee(int employeeId);
        List<EmployeeProject> GetByProject(int projectId);
    }
}

using BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IEmployeeProjectService
    {
        void AssignEmployeeToProject(int employeeId, int projectId);
        List<EmployeeProjectDTO> GetAllEmployeeProjects(int employeeId);
    }
}

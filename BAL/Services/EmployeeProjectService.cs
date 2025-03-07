using BAL.DTOs;
using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BAL.Services
{
    public class EmployeeProjectService : IEmployeeProjectService
    {
        private readonly IEmployeeProjectRepository _employeeProjectRepository;

        public EmployeeProjectService(IEmployeeProjectRepository employeeProjectRepository)
        {
            _employeeProjectRepository = employeeProjectRepository;
        }

        public void AssignEmployeeToProject(int employeeId, int projectId)
        {
            _employeeProjectRepository.AssignEmployeeToProject(employeeId, projectId);
        }

        public List<EmployeeProjectDTO> GetAllEmployeeProjects(int employeeId)
        {
            var employeeProjects = _employeeProjectRepository.GetByEmployee(employeeId);
            var dtos = new List<EmployeeProjectDTO>();
            foreach (var ep in employeeProjects)
            {
                dtos.Add(new EmployeeProjectDTO
                {
                    EmployeeId = ep.EmployeeId,
                    ProjectId = ep.ProjectId,
                    AssignedDate = ep.AssignedDate
                });
            }
            return dtos;
        }


        public List<EmployeeProjectDTO> GetAllProjectEmployees(int projectId)
        {
            var projectEmployees = _employeeProjectRepository.GetByProject(projectId);
            var dtos = new List<EmployeeProjectDTO>();
            foreach (var p in projectEmployees)
            {
                dtos.Add(new EmployeeProjectDTO
                {
                    EmployeeId = p.EmployeeId,
                    ProjectId = p.ProjectId,
                    AssignedDate = p.AssignedDate
                });
            }
            return dtos;
        }
    }
}

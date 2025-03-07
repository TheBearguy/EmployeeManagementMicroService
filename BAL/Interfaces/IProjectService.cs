using BAL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interfaces
{
    public interface IProjectService
    {
        List<ProjectDTO> GetAllProjects();
        ProjectDTO GetProjectById(int id);
        void AddProject(ProjectDTO projectDTO);
        void DeleteProject(int id);
        void UpdateProject(int id);
    }
}

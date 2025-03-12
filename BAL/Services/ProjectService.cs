using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;




using DAL.Interfaces;
using BAL.Interfaces;
using BAL.DTOs;
using Microsoft.Identity.Client;

namespace BAL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<ProjectDTO> GetAllProjects()
        {
            var projects = _projectRepository.GetAll();
            var projectDTOs = new List<ProjectDTO>(); 
            foreach(var project in projectDTOs)
            {
                projectDTOs.Add(new ProjectDTO
                {
                    Id = project.Id,
                    Name = project.Name,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                });
            }
            return projectDTOs;
        }

        public ProjectDTO GetProjectById(int id)
        {
            var project = _projectRepository.GetById(id);
            if (project == null)
                return null;
            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            };
        }
        
        public void AddProject(ProjectDTO project)
        {
            _projectRepository.Insert(new Project
            {
                Name = project.Name,
                StartDate = project.StartDate,
                EndDate = project.EndDate
            });
        }

        public void DeleteProject(int id)
        {
            _projectRepository.Delete(id);
        }

        public void UpdateProject(ProjectDTO project)
        {
            _projectRepository.Update(_projectRepository.GetById(project.Id));
        }
    }
}

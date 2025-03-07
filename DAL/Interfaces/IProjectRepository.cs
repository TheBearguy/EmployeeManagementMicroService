using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IProjectRepository
    {
        List<Project> GetAll();
        Project GetById(int id);
        void Insert(Project project);
        void Update(Project project);
        void Delete(int id);
    }
}

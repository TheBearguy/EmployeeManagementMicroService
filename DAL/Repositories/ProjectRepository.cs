﻿using DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;
using System.Data.SqlClient;
using DAL.Interfaces;
using Microsoft.Extensions.Options;

namespace DAL.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DatabaseHelper _databaseHelper;
        public ProjectRepository(IOptions<DatabaseSettings> dbSettings)
        {
            _databaseHelper = new DatabaseHelper(dbSettings);
        }
        public List<Project> GetAll()
        {
            var projects = new List<Project>();
            var query = "EXEC ManageProjects 'SELECT'";
            var reader = _databaseHelper.ExecuteReader(query);
            using (reader)
            {
                while (reader.Read())
                {
                    projects.Add(
                        new Project
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            StartDate = Convert.ToDateTime(reader["StartDate"]),
                            EndDate = Convert.ToDateTime(reader["EndDate"])
                        }
                    );
                }
            }
            return projects;
        }
        public Project GetById(int id)
        {
            var project = new Project();
            var query = "EXEC ManageProjects 'SELECT', @Id";
            var parameters = new SqlParameter[]
            {
                    new SqlParameter("@Id", id)
            };
            var reader = _databaseHelper.ExecuteReader(query, parameters);
            using (reader)
            {
                if (reader.Read())
                {
                    return new Project
                    {
                        Id = (int)reader["Id"],
                        Name = reader["Name"].ToString(),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"])
                    };
                }
            }
            return project;
        }
        public void Insert(Project project)
        {
            var query = "EXEC ManageProjects 'INSERT', @Name, @StartDate, @EndDate";
            var parameters = new SqlParameter[]
            {
                    new SqlParameter("@Name", project.Name),
                    new SqlParameter("@StartDate", project.StartDate),
                    new SqlParameter("@EndDate", project.EndDate)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        public void Update(Project project)
        {
            var query = "EXEC ManageProjects 'UPDATE', @Id, @Name, @StartDate, @EndDate";
            var parameters = new SqlParameter[]
            {
                    new SqlParameter("@Id", project.Id),
                    new SqlParameter("@Name", project.Name),
                    new SqlParameter("@StartDate", project.StartDate),
                    new SqlParameter("@EndDate", project.EndDate)
            };
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
        public void Delete(int id)
        {
            var parameters = new SqlParameter[]
            {
                    new SqlParameter("@Id", id)
            };
            var query = "EXEC ManageProjects 'DELETE', @Id";
            _databaseHelper.ExecuteNonQuery(query, parameters);
        }
    }
}

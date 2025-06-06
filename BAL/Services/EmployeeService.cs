﻿using BAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using DAL.Interfaces;
using DomainModels;

namespace BAL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public List<EmployeeDTO> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            var employeeDTOs = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                employeeDTOs.Add(new EmployeeDTO
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Position = employee.Position,
                    Salary = employee.Salary,
                });
            }
            return employeeDTOs;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee == null)
            {
                return null;    
            }
            return new EmployeeDTO
            {
                Id = employee.Id,
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary
            };
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            _employeeRepository.Insert(new Employee
            {
                Name = employee.Name,
                Position = employee.Position,
                Salary = employee.Salary,
            });
        }

        public void UpdateEmployee (EmployeeDTO employee)
        {
            _employeeRepository.Update(_employeeRepository.GetById(employee.Id));
        }

        public void DeleteEmployee(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}

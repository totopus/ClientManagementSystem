using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeResponseModel> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);

            if (employee == null)
            {
                throw new Exception($"No Employee Found for this {id}");
            }
            var employeeDetails = new EmployeeResponseModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Password = employee.Password,
                Designation = employee.Designation,
            };


            return employeeDetails;

        }

        public async Task<List<EmployeeResponseModel>> GetEmployees()
        {
            var employees = await _employeeRepository.ListAllAsync();
            var employeesModels = new List<EmployeeResponseModel>();
            foreach (var emp in employees)
            {
                employeesModels.Add(new EmployeeResponseModel
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Password = emp.Password,
                    Designation = emp.Designation,

                });
            }

            return employeesModels;
        }



        public async Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel model)
        {
            var newEmployee = new Employee
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation,
            };

            var dbEmployee = await _employeeRepository.AddAsync(newEmployee);

            var employeeModel = new EmployeeResponseModel
            {
                Id = dbEmployee.Id,
                Name = dbEmployee.Name,
                Password = dbEmployee.Password,
                Designation = dbEmployee.Designation,

            };
            return employeeModel;
        }



        public async Task DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteAsync(id);

            

        }

        

        public async Task<Employee> UpdateEmployee(int id, EmployeeRequestModel model)
        {

            var dbEmployee = new Employee
            {
                Name = model.Name,
                Password = model.Password,
                Designation = model.Designation
            };
            var updatedEmployee = await _employeeRepository.UpdateAsync(id, dbEmployee);
            return updatedEmployee;
        }

        
    }
}


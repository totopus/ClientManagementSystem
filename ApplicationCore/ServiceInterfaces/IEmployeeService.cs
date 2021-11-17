using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeResponseModel>> GetEmployees();
        public Task<EmployeeResponseModel> GetEmployeeById(int id);
        public Task<EmployeeResponseModel> AddEmployee(EmployeeRequestModel model);
        public Task DeleteEmployee(int id);
        public Task<Employee> UpdateEmployee(int id,EmployeeRequestModel model);
    }
}

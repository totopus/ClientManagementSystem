using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models;

namespace TaskManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("ListEmployees")]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployees();

            if (!employees.Any())
            {
                return NotFound("No Users Found");
            }

            return Ok(employees);
        }

        //http://localhost/api/employee/1
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound($"No Employee Found For {id}");
            }
            return Ok(employee);
        }

        //http://localhost/api/addemployee
        [HttpPost]
        [Route("addemployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeRequestModel model)
        {
            var addEmployee = await _employeeService.AddEmployee(model);

            return Ok(addEmployee);
        }

        [HttpDelete]
        [Route("deleteemployee/{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await _employeeService.DeleteEmployee(id);
            return Ok();
        }

        [HttpPut]
        [Route("updateemployee/{id:int}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeRequestModel model)
        {
            var updatedEmployee = await _employeeService.UpdateEmployee(id, model);
            return Ok(updatedEmployee);
        }
    }
}

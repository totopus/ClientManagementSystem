using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ClientManagementSystemDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Employee> UpdateAsync(int id, Employee e)
        {
            var employee = _dbContext.Set<Employee>().Find(id);
            if (employee != null)
            {
                employee.Name = e.Name;
                employee.Password = e.Password;
                employee.Designation = e.Designation;
                int affected = await _dbContext.SaveChangesAsync();
                if (affected == 1)
                {
                    return employee;
                }
            }

            return null;


        }
    }
}

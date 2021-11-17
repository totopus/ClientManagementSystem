using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterfaces
{
    public interface IEmployeeRepository:IAsyncRepository<Employee>
    {
        //Task<List<Employee>> GetEmployees();
        //Task<List<Employee>> GetEmployeeById(int id);
    }
}

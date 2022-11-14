using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task UpdateAsync(int id, Employee employee);
    }
}

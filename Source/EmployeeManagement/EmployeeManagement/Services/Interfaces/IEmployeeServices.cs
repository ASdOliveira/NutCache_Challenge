using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task AddAsync(Employee employee);
        Task RemoveAsync(int id);
        Task UpdateAsync(int id, Employee employee);
    }
}

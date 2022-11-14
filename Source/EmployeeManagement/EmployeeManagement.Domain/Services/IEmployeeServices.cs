using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Services
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

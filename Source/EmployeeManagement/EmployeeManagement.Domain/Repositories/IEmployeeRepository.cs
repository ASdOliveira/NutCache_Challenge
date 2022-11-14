using System.Threading.Tasks;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task UpdateAsync(int id, Employee employee);
    }
}

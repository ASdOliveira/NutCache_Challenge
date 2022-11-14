using System.Threading.Tasks;
using System.Collections.Generic;
using EmployeeManagement.Domain.Models;

namespace EmployeeManagement.Domain.Repositories
{
   public interface IGenericRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T obj);
        Task RemoveAsync(int id);
        Task UpdateAsync(T obj);
    }
}

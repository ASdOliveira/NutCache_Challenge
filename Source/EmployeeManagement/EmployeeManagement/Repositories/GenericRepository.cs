using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Domain.Models;
using EmployeeManagement.DatabaseContext;
using EmployeeManagement.Domain.Repositories;

namespace EmployeeManagement.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        protected readonly AppDbContext context;
        protected readonly DbSet<T> dbSet;

        public GenericRepository(AppDbContext dbContext)
        {
            context = dbContext;
            dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public virtual async Task AddAsync(T obj)
        {
            dbSet.Add(obj);
            await context.SaveChangesAsync();
        }
        
        public virtual async Task RemoveAsync(int id)
        {
            var data = await dbSet.FirstOrDefaultAsync(r => r.Id == id);
            dbSet.Remove(data);
            await context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T obj)
        {
            if(!context.ChangeTracker.Entries<T>().Any(r => r.Entity.Id == obj.Id))
            {
                dbSet.Update(obj);
            }

            await context.SaveChangesAsync();
        }
    }
}

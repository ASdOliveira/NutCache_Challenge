using EmployeeManagement.DatabaseContext;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FirstOrDefaultAsync(r => r.Id == id);
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
            var data = await dbSet.FirstOrDefaultAsync(r => r.Id == obj.Id);

            if(data == null)
            {
                throw new Exception("Data not found"); //Improve here.
            }

            dbSet.Update(obj);
            await context.SaveChangesAsync();
        }
    }
}

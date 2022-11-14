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

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbSet.FirstOrDefault(r => r.Id == id);
        }

        public virtual void Add(T obj)
        {
            dbSet.Add(obj);
            context.SaveChanges();
        }
        
        public virtual void Remove(int id)
        {
            
            //dbSet.RemoveRange(r => r.Id == id);
            //context.SaveChanges();
            //temporaryRepo.RemoveAll(r => r.Id == id);
        }

        public virtual void Update(T obj)
        {
            if(dbSet.Any(s => s.Id == obj.Id))
            {
                dbSet.Update(obj);
            }
        }
    }
}

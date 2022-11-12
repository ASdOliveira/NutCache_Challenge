using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class GenericRepository<T> where T : Entity
    {
        private readonly List<T> temporaryRepo;

        public GenericRepository()
        {
            temporaryRepo = new List<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return temporaryRepo;
        }

        public virtual T GetById(int id)
        {
            return temporaryRepo.FirstOrDefault(r => r.Id == id);
        }

        public virtual void Add(T obj)
        {
            temporaryRepo.Add(obj);
        }
        
        public virtual void Remove(int id)
        {
            temporaryRepo.RemoveAll(r => r.Id == id);
        }

        public virtual void Update(T obj)
        {
            int index = temporaryRepo.FindIndex(s => s.Id == obj.Id);

            if(index == -1)
            {
                return;
            }

            temporaryRepo.RemoveAt(index);
            temporaryRepo.Add(obj);
        }
    }
}

using EmployeeManagement.DatabaseContext;
using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee> , IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext dbContext) : base(dbContext)
        {
  
        }

        public async Task UpdateAsync(int id, Employee employee)
        {
            var employeeInDb = await context.Employees.FirstOrDefaultAsync(e => e.Id == id);

            if(employeeInDb != null)
            {
                employeeInDb.Name = employee.Name;
                employeeInDb.BirthDate = employee.BirthDate;
                employeeInDb.Gender = employee.Gender;
                employeeInDb.Email = employee.Email;
                employeeInDb.CPF = employee.CPF;
                employeeInDb.StartDate = employee.StartDate;
                employeeInDb.Team = employee.Team;

                dbSet.Update(employeeInDb);

                await context.SaveChangesAsync();
            }
        }
    }
}

using EmployeeManagement.Models;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository employeeRepo;
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            employeeRepo = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await employeeRepo.GetAllAsync();

            return employees;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await employeeRepo.GetByIdAsync(id);
        }

        public async Task AddAsync(Employee employee)
        {
            await employeeRepo.AddAsync(employee);
        }

        public async Task RemoveAsync(int id)
        {
            await employeeRepo.RemoveAsync(id);
        }

        public async Task UpdateAsync(int id, Employee employee)
        {
            await employeeRepo.UpdateAsync(id, employee);
        }
    }
}

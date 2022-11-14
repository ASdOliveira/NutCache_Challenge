using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("v1/employee")]
    public class EmployeeController : ControllerBase
    { 
        private readonly IEmployeeRepository employeeRepo;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            employeeRepo = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var employees = await employeeRepo.GetAllAsync();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var employee = await employeeRepo.GetByIdAsync(id);

            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(); // Add message
            }

            await employeeRepo.AddAsync(employee);

            return Created($"v1/employee/{employee.Id}", employee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // Add message
            }

            var data = await employeeRepo.GetByIdAsync(id);

            if(data == null)
            {
                return BadRequest();
            }

            await employeeRepo.UpdateAsync(employee);

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {

            var data = await employeeRepo.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            await employeeRepo.RemoveAsync(id);

            return NoContent();
        }

    }
}

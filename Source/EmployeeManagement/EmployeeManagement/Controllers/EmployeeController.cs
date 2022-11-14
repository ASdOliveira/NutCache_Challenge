using EmployeeManagement.Models;
using EmployeeManagement.Repositories;
using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Services.Interfaces;
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
        private readonly IEmployeeServices service;
        public EmployeeController(IEmployeeServices employeeService)
        {
            service = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            try
            {
                var employees = await service.GetAllAsync();

                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Problem to retrieve data from database \n Exception: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var employee = await service.GetByIdAsync(id);

                return employee == null ? NotFound() : Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Problem to retrieve data from database \n Exception: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(); // Add message
                }

                await service.AddAsync(employee);

                return Created($"v1/employee/{employee.Id}", employee);
            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Problem when save data into database \n Exception: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] int id, [FromBody] Employee employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(); // Add message
                }

                var data = await service.GetByIdAsync(id);

                if (data == null)
                {
                    return BadRequest($"There are no data in the database with Id: {id}");
                }

                await service.UpdateAsync(id, employee);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Problem when update data into database \n Exception: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var data = await service.GetByIdAsync(id);
                if (data == null)
                {
                    return NotFound();
                }

                await service.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Problem when update data into database \n Exception: {ex.Message}");
            }
        }

    }
}

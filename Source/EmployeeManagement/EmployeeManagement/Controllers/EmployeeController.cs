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
        public ActionResult GetAllAsync()
        {
            var employees = employeeRepo.GetAll();

            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult GetById([FromRoute] int id)
        {
            var employee = employeeRepo.GetById(id);

            return employee == null ? NotFound() : Ok(employee);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Employee employee)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(); // Add message
            }

            employeeRepo.Add(employee);

            return Created($"v1/employee/{employee.Id}", employee);
        }

        [HttpPut("{id}")]
        public ActionResult Put([FromRoute] int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); // Add message
            }

            var data = employeeRepo.GetById(id);

            if(data == null)
            {
                return BadRequest();
            }

            employeeRepo.Update(employee);

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {

            var data = employeeRepo.GetById(id);
            if (data == null)
            {
                return NotFound();
            }

            employeeRepo.Remove(id);

            return NoContent();
        }

    }
}

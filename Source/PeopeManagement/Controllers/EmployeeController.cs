using Microsoft.AspNetCore.Mvc;
using PeopeManagement.Entities;
using PeopeManagement.Models;
using PeopeManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PeopeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        static readonly EmployeeRepositories EmployeeRepo = new EmployeeRepositories();
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return EmployeeRepo.GetAll().ToList();
        }

        [HttpPost]
        public HttpResponseMessage Post(Employee employee)
        {
            bool result = EmployeeRepo.Add(employee);
            if (result)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            EmployeeRepo.Remove(id);
            return new HttpResponseMessage(HttpStatusCode.NoContent);
        }

        [HttpPut]
        public HttpResponseMessage Put(Employee employee)
        {
            bool result = EmployeeRepo.Update(employee); //it should replace by Id, for example.

            if (result)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Created);
                return response;
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}

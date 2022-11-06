using Microsoft.AspNetCore.Mvc;
using PeopeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopeManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public EmployeeModel Get()
        {
            return new EmployeeModel();
        }
    }
}

using PeopleManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleManagement.Common.Models
{
    public class EmployeeModel : ModelBase<Employee>
    {
        public override bool IsValid()
        {
            if(string.IsNullOrEmpty(Value.Name))
            {
                return false;
            }
            if(Value.BirthDate == DateTime.MinValue)
            {
                return false;
            }
            if(string.IsNullOrEmpty(Value.Email))
            {
                return false;
            }
            if(string.IsNullOrEmpty(Value.CPF))
            {
                return false;
            }

            return true;
        }
    }
}

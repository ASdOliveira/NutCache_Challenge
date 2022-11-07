using PeopeManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopeManagement.Repositories
{
    public class EmployeeRepositories
    {
        private List<Employee> employees = new List<Employee>();

        public EmployeeRepositories()
        {
            Add(new Employee
            {
                BirthDate = DateTime.Now,
                CPF = "555",
                Email = "ok@google.com",
                Gender = Genders.FEMALE,
                Id = 1,
                Name = "Arysson",
                StartDate = DateTime.Now,
                Team = Teams.NONE
            });
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }

        public bool Add (Employee employee)
        {
            bool addResult = false;

            if(employee == null)
            {
                return addResult;
            }

            int index = employees.FindIndex(s => s.Id == employee.Id);
            
            if (index == -1)
            {
                employees.Add(employee);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        public void Remove(int id)
        {
            employees.RemoveAll(s => s.Id == id);
        }

        public bool Update(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("employee");
            }

            int index = employees.FindIndex(s => s.Id == employee.Id);
            if (index == -1)
            {
                return false;
            }

            employees.RemoveAt(index);
            employees.Add(employee);

            return true;
        }
    }
}

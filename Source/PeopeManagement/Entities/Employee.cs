using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopeManagement.Entities
{
    public enum Genders
    {
        UNINFORMED,
        MALE,
        FEMALE
    }

    public enum Teams
    {
        NONE,
        MOBILE,
        FRONTEND,
        BACKEND
    }

    public class Employee
    {
        public string Name { get; set; } //required
        public DateTime BirthDate { get; set; } // required
        public Genders Gender { get; set; } //required
        public string Email { get; set; } //required
        public string CPF { get; set; } //required
        public DateTime StartDate { get; set; }
        public Teams Team { get; set; }
    }
}

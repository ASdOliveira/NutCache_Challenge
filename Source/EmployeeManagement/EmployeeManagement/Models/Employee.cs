using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employee : Entity
    {
        [Required]
        public string Name { get; set; } 
        [Required]
        public DateTime BirthDate { get; set; } 
        [Required]
        public string Gender { get; set; } 
        [Required]
        public string Email { get; set; } 
        [Required]
        public string CPF { get; set; } 
        public DateTime StartDate { get; set; }
        public string Team { get; set; }
    }
}

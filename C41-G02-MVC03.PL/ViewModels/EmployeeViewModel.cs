using C41_G02_MVC03.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace C41_G02_MVC03.PL.ViewModels
{
    public class EmployeeViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public int? DepartmentId { get; set; } //Foreign Key
        public virtual Department Department { get; set; }
    }
        
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Models
{
    public enum Gender
    {
        Male = 1 , Female = 2
    }
    public enum EmpType
    {
        FullTime =1,
        PartTime =2,
    }
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length Is 50 Chars.")]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(22, 60, ErrorMessage = "Age Must Be Between 22 And 60.")]
        public int Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public string Address { get; set; }
        [Display (Name="Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression(@"^(\+201|01|00201)[0-2,5]{1}[0-9]{8}")]
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public Gender Gender { get; set; }
        public DateTime CreationDate { get; set; }= DateTime.Now;
        public bool IsDeleted { get; set; }
        public EmpType EmployeeType { get; set; }
    }
}

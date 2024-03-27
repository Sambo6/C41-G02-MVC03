using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1 ,
        [EnumMember(Value = "Female")]
        Female = 2
    }
    public enum EmpType
    {
        [EnumMember(Value = "Full Time")]
        FullTime =1,
        [EnumMember(Value = "Part Time")]
        PartTime =2,
    }
    public class Employee : ModelBase
    {
        
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length Is 50 Chars.")]
        [MinLength(5)]
        public string Name { get; set; }
        [Range(22, 60, ErrorMessage = "Age Must Be Between 22 And 60.")]
        public int Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$"
                            , ErrorMessage = "Address must be like 123-Street-City-Country")]
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Display (Name="Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression(@"^(\+201|01|00201)[0-2,5]{1}[0-9]{8}")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Hiring Date")]
        public DateTime HireDate { get; set; }
        public Gender Gender { get; set; }
        public EmpType EmployeeType { get; set; }
        [Display(Name = "Date Of Creation")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}

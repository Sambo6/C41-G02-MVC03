using C41_G02_MVC03.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;
using Microsoft.AspNetCore.Http;

namespace C41_G02_MVC03.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length Is 50 Chars.")]
        [MinLength(3)]
        public string Name { get; set; }
        [Range(17, 60, ErrorMessage = "Age Must Be Between 22 And 60.")]
        public int Age { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression(@"^(\+201|01|00201)[0-2,5]{1}[0-9]{8}")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HireDate { get; set; }
        [Display(Name = "Date Of Creation")]
        public DateTime CreationDate { get; set; }

        public int? DepartmentId { get; set; } //Foreign Key

        //Nav property ==> [One]
        public virtual Department Department { get; set; }
        public IFormFile Image { get; set; }
        public string ImageName { get; set; }
    }

}

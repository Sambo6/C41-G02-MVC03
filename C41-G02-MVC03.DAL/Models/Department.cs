using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Models
{
    //Model
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Display (Name ="Date Of Creation")]
        public DateTime DateOfCreation { get; set; } 

    }
}

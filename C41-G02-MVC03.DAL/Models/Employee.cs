using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
namespace C41_G02_MVC03.DAL.Models
{


    public class Employee : ModelBase
    {

        
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime CreationDate { get; set; } 
        public int? DepartmentId { get; set; } //Foreign Key
        //Nav property ==> [One]
        public virtual Department Department { get; set; }

        public string ImageName { get; set; }

    }
}

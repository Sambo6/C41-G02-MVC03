using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Models
{
    //Model
    public class Department : ModelBase
    {

        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
        // Nav property ==> [Many]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}

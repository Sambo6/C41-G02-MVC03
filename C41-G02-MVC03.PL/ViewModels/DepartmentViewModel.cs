using C41_G02_MVC03.DAL.Data.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace C41_G02_MVC03.PL.ViewModels
{
	public class DepartmentViewModel
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


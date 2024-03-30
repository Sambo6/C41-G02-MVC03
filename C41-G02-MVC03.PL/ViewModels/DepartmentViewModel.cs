using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using C41_G02_MVC03.DAL.Data.Migrations;

namespace C41_G02_MVC03.PL.ViewModels
{
	public class DepartmentViewModel
	{
        public int? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}

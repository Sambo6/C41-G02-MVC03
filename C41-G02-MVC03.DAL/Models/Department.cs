﻿using System;
using System.Collections.Generic;

namespace C41_G02_MVC03.DAL.Models
{
	//Model
	public class Department : ModelBase
    {    
        public string Code { get; set; }    
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }
        // Nav property ==> [Many]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}

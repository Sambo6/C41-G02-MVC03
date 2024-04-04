﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Models
{
	public class ApplicationUser: IdentityUser
	{
        public string FName { get; set; }
		public string LName { get; set; }
        public bool IsAgree { get; set; }

    }
}

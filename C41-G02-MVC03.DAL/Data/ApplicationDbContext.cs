using C41_G02_MVC03.DAL.Data.Configurations;
using C41_G02_MVC03.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Data
{
    public class ApplicationDbContext :IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}

		//public DbSet<Department> Departments { get; set; }
		public DbSet<Employee> Employees { get; set; }
		//public DbSet<IdentityUser> Users { get; set; }
		//public DbSet<IdentityUser> Roles { get; set; }



	}
}

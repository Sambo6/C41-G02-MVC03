using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C41_G02_MVC03.DAL.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Fluent APIs :
            builder.Property(D => D.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(D => D.Address).IsRequired();

        }
    }
}

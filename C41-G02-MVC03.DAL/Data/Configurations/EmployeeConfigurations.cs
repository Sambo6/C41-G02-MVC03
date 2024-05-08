using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C41_G02_MVC03.DAL.Data.Configurations
{
	internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //Fluent APIs :
            builder.Property(D => D.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(D => D.Address).IsRequired(); 
            builder.Property(e => e.Salary).HasColumnType("decimal(12,2)");

                
        }
    }
}
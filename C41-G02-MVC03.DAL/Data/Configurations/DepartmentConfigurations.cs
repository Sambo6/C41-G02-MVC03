using C41_G02_MVC03.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace C41_G02_MVC03.DAL.Data.Configurations
{
	public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10,10);
            builder.Property(D => D.Code).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(D => D.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();


            builder.HasMany(D => D.Employees)
                    .WithOne(E =>E.Department)
                    .HasForeignKey(E => E.DepartmentId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

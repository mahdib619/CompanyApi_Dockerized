using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyApi.Data.TypeConfigurations;

public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
{
	public void Configure(EntityTypeBuilder<Employee> builder)
	{
		builder.ToTable("Employees");
		builder.HasKey(e => e.Id);

		builder.Property(e => e.Name).IsRequired().HasMaxLength(50);
		builder.Property(e => e.Email).IsRequired().HasMaxLength(50);
		builder.Property(e => e.Phone).IsRequired().HasMaxLength(15);
		builder.Property(e => e.Title).IsRequired().HasMaxLength(50);

		builder.HasOne(e => e.Company).WithMany(c => c.Employees).HasForeignKey(c => c.CompanyId);
	}
}

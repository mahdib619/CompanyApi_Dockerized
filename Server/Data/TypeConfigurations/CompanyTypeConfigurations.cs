using CompanyApp.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyApp.Server.Data.TypeConfigurations;

public class CompanyTypeConfigurations : IEntityTypeConfiguration<Company>
{
	public void Configure(EntityTypeBuilder<Company> builder)
	{
		builder.HasKey(c => c.Id);
		builder.Property(c => c.Name).HasMaxLength(50).IsRequired();
		builder.Property(c => c.City).HasMaxLength(50).IsRequired();
		builder.Property(c => c.State).HasMaxLength(50).IsRequired();
		builder.Property(c => c.PostalCode).HasMaxLength(15).IsRequired();
	}
}

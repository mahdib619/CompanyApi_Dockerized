using System.Reflection;
using Microsoft.EntityFrameworkCore;
using CompanyApp.Server.Data;
using CompanyApp.Server.Models.Entities;

namespace CompanyApp.Server.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
	
	public DbSet<Company> Companies { get; set; }
	public DbSet<Employee> Employees { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(this.GetType()));
	}
}

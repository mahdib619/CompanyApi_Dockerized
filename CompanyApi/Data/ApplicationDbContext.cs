using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
		
	}
	
	public DbSet<Company> Companies { get; set; }
		
	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(this.GetType()));
	}
}
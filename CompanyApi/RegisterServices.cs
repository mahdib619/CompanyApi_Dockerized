using System.Reflection;
using CompanyApi.Services;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi;

public static class RegisterServices
{
	public static IServiceProvider ServiceProvider { get; private set; }
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		var services = builder.Services;

		services.AddDbContext<ApplicationDbContext>(opt =>
			opt.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnection"),
			sOpt => sOpt.MigrationsAssembly("SqlLiteMigrations")
		));

		services.AddFastEndpoints();
		services.AddSwaggerDoc();
		services.AddAuthentication();
		services.AddAutoMapper(Assembly.GetCallingAssembly());

		services.AddTransient<ICompanyService, CompanyService>();
		services.AddTransient<IEmployeeService, EmployeeService>();

		ServiceProvider = builder.Services.BuildServiceProvider();
	}
}
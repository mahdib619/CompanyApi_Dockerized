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
			opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
		));

		services.AddFastEndpoints();
		services.AddSwaggerDoc();
		services.AddAuthentication();
		services.AddAutoMapper(Assembly.GetCallingAssembly());

		services.AddTransient<ICompanyService, CompanyService>();
		services.AddTransient<IEmployeeService, EmployeeServiceContrib>();

		ServiceProvider = builder.Services.BuildServiceProvider();
	}
}
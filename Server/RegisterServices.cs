using System.Reflection;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;
using CompanyApp.Server.Data;
using CompanyApp.Server.Services;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;

namespace CompanyApp.Server;

public static class RegisterServices
{
	public static IServiceProvider ServiceProvider { get; private set; }
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		var services = builder.Services;

		services.AddCors(opt =>
		{
			opt.AddPolicy("All", p =>
			{
				p.AllowAnyOrigin()
				 .AllowAnyHeader()
				 .AllowAnyMethod();
			});
		});

		services.AddDbContext<ApplicationDbContext>(opt =>
			opt.UseSqlite(builder.Configuration.GetConnectionString("SqlLiteConnection"),
			sOpt => sOpt.MigrationsAssembly("SqlLiteMigrations")
		));

		builder.Services.Configure<JsonOptions>(options =>
		{
			options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		});

		services.AddFastEndpoints();
		services.AddSwaggerDoc();
		services.AddAuthentication();
		services.AddAutoMapper(Assembly.GetCallingAssembly());

		services.AddTransient<ICompanyService, CompanyService>();
		services.AddTransient<IEmployeeService, EmployeeService>();

		ServiceProvider = builder.Services.BuildServiceProvider();
	}
}

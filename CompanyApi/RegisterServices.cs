using CompanyApi.Data;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

namespace CompanyApi;

public static class RegisterServices
{
	public static void ConfigureServices(this WebApplicationBuilder builder)
	{
		var services = builder.Services;

		services.AddDbContext<ApplicationDbContext>(opt =>
			opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
		));

		services.AddFastEndpoints();
		services.AddSwaggerDoc();
		services.AddAuthentication();
	}
}
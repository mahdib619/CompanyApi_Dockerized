using CompanyApp.Server;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.UseCors("All");
app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseAuthentication();
app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();
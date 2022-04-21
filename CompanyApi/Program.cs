var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.UseFastEndpoints();
app.UseAuthentication();
app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();
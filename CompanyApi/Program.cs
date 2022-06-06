var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseAuthentication();
app.UseOpenApi();
app.UseSwaggerUi3();

app.Run();
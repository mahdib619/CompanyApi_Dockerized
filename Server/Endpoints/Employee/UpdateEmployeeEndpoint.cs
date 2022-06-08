using CompanyApp.Server.Mappers.EndpointMappers;
using CompanyApp.Server.Services;
using CompanyApp.Shared.Models.Request;

namespace CompanyApp.Server.Endpoints.Employee;

public class UpdateEmployeeEndpoint : Endpoint<UpdateEmployeeRequest, EmptyResponse, EmployeeEndpointMapper<UpdateEmployeeRequest>>
{
	private readonly IEmployeeService employeeService;

	public UpdateEmployeeEndpoint(IEmployeeService employeeService)
	{
		this.employeeService = employeeService;
	}
	public override void Configure()
	{
		Put();
		Routes("/employees/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(UpdateEmployeeRequest req, CancellationToken ct)
	{
		var employee = Map.ToEntity(req);
		employee.Id = Route<int>("id");

		if (await employeeService.Update(employee))
			await SendOkAsync(cancellation: ct);
		else
			await SendNotFoundAsync(cancellation: ct);
	}
}

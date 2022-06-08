using CompanyApp.Server.Mappers.EndpointMappers;
using CompanyApp.Server.Services;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Server.Endpoints.Employee;

public class GetEmployeeEndpoint : Endpoint<EmptyRequest, GetEmployeeResponse, EmployeeEndpointMapper<EmptyRequest>>
{
	private readonly IEmployeeService employeeService;

	public GetEmployeeEndpoint(IEmployeeService employeeService)
	{
		this.employeeService = employeeService;
	}

	public override void Configure()
	{
		Get();
		Routes("employees/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var id = Route<int>("id");
		var employee = await employeeService.GetEmployee(id);

		if (employee is null)
			await SendNotFoundAsync(cancellation: ct);

		var response = Map.FromEntity(employee);
		await SendAsync(response, cancellation: ct);
	}
}

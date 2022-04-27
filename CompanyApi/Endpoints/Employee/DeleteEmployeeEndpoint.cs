using CompanyApi.Services;

namespace CompanyApi.Endpoints.Employee;

public class DeleteEmployeeEndpoint : Endpoint<EmptyRequest, EmptyResponse>
{
	private readonly IEmployeeService employeeService;

	public DeleteEmployeeEndpoint(IEmployeeService employeeService)
	{
		this.employeeService = employeeService;
	}

	public override void Configure()
	{
		Delete();
		Routes("/employees/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var id = Route<int>("id");
		
		if(await employeeService.Remove(id))
			await SendOkAsync(cancellation: ct);
		else
			await SendNotFoundAsync(cancellation: ct);
	}
}

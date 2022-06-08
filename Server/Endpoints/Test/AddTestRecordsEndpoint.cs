using EmployeeE = CompanyApp.Server.Models.Entities.Employee;
using CompanyApp.Server.Services;

namespace CompanyApp.Server.Endpoints.Test;

public class AddTestRecordsEndpoint : EndpointWithoutRequest
{
	ICompanyService companyService;

	public AddTestRecordsEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}

	public override void Configure()
	{
		Get();
		Routes("test");
		AllowAnonymous();
	}

	public override async Task HandleAsync(CancellationToken ct)
	{
		var company = new Models.Entities.Company()
		{
			Name = $"Test company {DateTime.Now:ddhhmmss}",
			Address = "city",
			PostalCode = "4875224",
			City = "address",
			State = "state",
			Employees = new List<EmployeeE>
			{
				new EmployeeE
				{
					Name = "Test Employee1",
					Email = "a@ss",
					Phone = "02144",
					Title = "test"
				},
				new EmployeeE
				{
					Name = "Test Employee5",
					Email = "a@ss",
					Phone = "02144",
					Title = "test"
				},
				new EmployeeE
				{
					Name = "Test Employee4",
					Email = "a@ss",
					Phone = "02144",
					Title = "test"
				},
				new EmployeeE
				{
					Name = "Test Employee3",
					Email = "a@ss",
					Phone = "02144",
					Title = "test"
				},
				new EmployeeE
				{
					Name = "Test Employee2",
					Email = "a@ss",
					Phone = "02144",
					Title = "test"
				},
			}
		};
		await companyService.AddWithEmployees(company);

		await SendOkAsync(cancellation: ct);
	}
}

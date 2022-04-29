using CompanyApi.Mappers.EndpointMappers;
using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Company;

public class GetCompanyEndpoint : Endpoint<EmptyRequest, GetCompanyResponse, CompanyEndpointMapper>
{
	private readonly ICompanyService companyService;

	public GetCompanyEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}

	public override void Configure()
	{
		Get();
		Routes("companies/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var id = Route<int>("id");
		var includeEmployees = Query<bool>("includeEmployees", false);

		var company = await companyService.GetCompany(id, includeEmployees);

		if (company is null)
			await SendNotFoundAsync(cancellation: ct);

		var response = Map.FromEntity(company);
		await SendAsync(response, cancellation: ct);
	}
}

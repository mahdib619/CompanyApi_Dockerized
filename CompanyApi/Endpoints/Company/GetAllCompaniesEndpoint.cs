using CompanyApi.Mappers.EndpointMappers;
using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Company;

public class GetAllCompaniesEndpoint : Endpoint<EmptyRequest, GetAllCompaniesResponse, CompanyEndpointMapper>
{
	private readonly ICompanyService companyService;

	public GetAllCompaniesEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}

	public override void Configure()
	{
		Get();
		Routes("/companies");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var includeEmployees = Query<bool>("includeEmployees", isRequired: false);

		var companies = (await companyService.GetAll(includeEmployees)).Select(c => Map.FromEntity(c));
		var response = new GetAllCompaniesResponse { Companies = companies };

		await SendAsync(response, cancellation: ct);
	}
}
using CompanyApi.Mappers.EndpointMappers;
using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Company;

public class AddCompanyEndpoint : Endpoint<AddUpdateCompanyRequest, EmptyResponse, CompanyEndpointMapper>
{
	private readonly ICompanyService companyService;

	public AddCompanyEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}
	public override void Configure()
	{
		Post();
		Routes("/companies");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddUpdateCompanyRequest req, CancellationToken ct)
	{
		await companyService.Add(Map.ToEntity(req));
		await SendAsync(new EmptyResponse(), StatusCodes.Status201Created, cancellation: ct);
	}
}

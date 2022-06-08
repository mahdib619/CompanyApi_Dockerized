using CompanyApp.Server.Mappers.EndpointMappers;
using CompanyApp.Server.Services;
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Server.Endpoints.Company;

public class AddCompanyEndpoint : Endpoint<AddUpdateCompanyRequest, GetCompanyResponse, CompanyEndpointMapper>
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
		var newCompany = Map.FromEntity(await companyService.Add(Map.ToEntity(req)));
		await SendCreatedAtAsync<GetCompanyEndpoint>(new { newCompany.Id }, newCompany, generateAbsoluteUrl: true, cancellation: ct);
	}
}

using CompanyApi.Mappers.EndpointMappers;
using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Company;

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

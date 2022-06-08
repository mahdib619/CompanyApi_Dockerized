using CompanyApp.Server.Mappers.EndpointMappers;
using CompanyApp.Server.Services;
using CompanyApp.Shared.Models.Request;

namespace CompanyApp.Server.Endpoints.Company;

public class UpdateCompanyEndpoint : Endpoint<AddUpdateCompanyRequest, EmptyResponse, CompanyEndpointMapper>
{
	private readonly ICompanyService companyService;

	public UpdateCompanyEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}
	public override void Configure()
	{
		Put();
		Routes("/companies/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddUpdateCompanyRequest req, CancellationToken ct)
	{
		var company = Map.ToEntity(req);
		company.Id = Route<int>("id");

		if (await companyService.Update(company))
			await SendOkAsync(cancellation: ct);
		else
			await SendNotFoundAsync(cancellation: ct);
	}
}

using CompanyApp.Server.Mappers.EndpointMappers;
using CompanyApp.Server.Services;

namespace CompanyApp.Server.Endpoints.Company;

public class DeleteCompanyEndpoint : Endpoint<EmptyRequest, EmptyResponse, CompanyEndpointMapper>
{
	private readonly ICompanyService companyService;

	public DeleteCompanyEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}

	public override void Configure()
	{
		Delete();
		Routes("/companies/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
	{
		var id = Route<int>("id");
		
		if(await companyService.Remove(id))
			await SendOkAsync(cancellation: ct);
		else
			await SendNotFoundAsync(cancellation: ct);
	}
}

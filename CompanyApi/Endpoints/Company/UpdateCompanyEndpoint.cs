using CompanyApi.Models.Contracts;
using CompanyApi.Services;

namespace CompanyApi.Endpoints.Company;

public class UpdateCompanyEndpoint : Endpoint<AddUpdateCompanyRequest>
{
	private readonly ICompanyService companyService;

	public UpdateCompanyEndpoint(ICompanyService companyService)
	{
		this.companyService = companyService;
	}
	public override void Configure()
	{
		Post();
		Routes("/companies/{id:int}");
		AllowAnonymous();
	}

	public override async Task HandleAsync(AddUpdateCompanyRequest req, CancellationToken ct)
	{
		var id = Route<int>("id");

		if (await companyService.Update(id, req))
			await SendAsync(new EmptyResponse(), cancellation: ct);
		else
			await SendNotFoundAsync(cancellation: ct);
	}
}

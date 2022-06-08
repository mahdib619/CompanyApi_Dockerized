using CompanyApp.Shared.Models.Response;
namespace CompanyApp.Shared.Models.Response;

public class GetAllCompaniesResponse
{
	public IEnumerable<GetCompanyResponse> Companies { get; set; }
}

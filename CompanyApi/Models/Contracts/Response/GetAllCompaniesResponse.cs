namespace CompanyApi.Models.Contracts;

public class GetAllCompaniesResponse
{
	public IEnumerable<GetCompanyResponse> Companies { get; set; }
}
using CompanyApp.Shared.Models.Response;
namespace CompanyApp.Shared.Models.Response;

public class GetCompanyResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Address { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string PostalCode { get; set; }
	public ICollection<GetEmployeeResponse> Employees { get; set; }
}

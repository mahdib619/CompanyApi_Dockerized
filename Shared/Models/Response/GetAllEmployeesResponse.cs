using CompanyApp.Shared.Models.Response;
namespace CompanyApp.Shared.Models.Response;

public class GetAllEmployeesResponse
{
	public IEnumerable<GetEmployeeResponse> Employees { get; set; }
}

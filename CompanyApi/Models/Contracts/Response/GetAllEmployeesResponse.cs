namespace CompanyApi.Models.Contracts;

public class GetAllEmployeesResponse
{
	public IEnumerable<GetEmployeeResponse> Employees { get; set; }
}

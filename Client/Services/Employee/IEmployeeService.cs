using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Services;

public interface IEmployeeService
{
	Task<GetEmployeeResponse> Add(AddEmployeeRequest req);
	Task<bool> Delete(int id);
	Task<GetEmployeeResponse> Get(int id);
	Task<IEnumerable<GetEmployeeResponse>> GetAll();
	Task<bool> Update(int id, UpdateEmployeeRequest req);
}
using CompanyApp.Shared.Models.Request;
using CompanyApp.Shared.Models.Response;

namespace CompanyApp.Client.Services;

public interface ICompanyService
{
	Task<GetCompanyResponse> Add(AddUpdateCompanyRequest req);
	Task<bool> Delete(int id);
	Task<GetCompanyResponse> Get(int id, bool includeEmployees = false);
	Task<IEnumerable<GetCompanyResponse>> GetAll(bool includeEmployees = false);
	Task<bool> Update(int id, AddUpdateCompanyRequest req);
}